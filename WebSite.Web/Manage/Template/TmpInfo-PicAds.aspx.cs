using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using WebSite.Admin.DAL;
using WebSite.Lib;
using OrgUsers = WebSite.Admin.Model.OrgUsers;

namespace WebSite.Web.Manage.Template
{
    public partial class TmpInfo_PicAds : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        readonly Infos _infosDal = new Infos();
        readonly TemplatePar _templateParDal = new TemplatePar();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                var spid = Request.QueryString["spid"];

                if (!string.IsNullOrEmpty(spid))
                {
                    #region 左侧分类

                    var itid = Request.QueryString["itid"]; //分类id
                    if (!string.IsNullOrEmpty(itid))
                    {
                        var model = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                        if (null != model)
                        {

                            litType.Text = Service.GetType(Convert.ToInt32(model.ITID), spid);
                        }
                    }
                    else
                    {
                        litType.Text = Service.GetType(0, spid);
                    }

                    #endregion

                    #region 块内容

                    var tiid = Request.QueryString["tiid"];
                    if (!string.IsNullOrEmpty(tiid))
                    {
                        TempInfo _tempInfoDal = new TempInfo();
                        var timodel = _tempInfoDal.GetModel(Convert.ToInt32(tiid));
                        if (null != timodel)
                        {
                            #region 导航

                            var ptiid = Request.QueryString["ptiid"];
                            if (!string.IsNullOrEmpty(ptiid))
                            {
                                litStaName.Text = "<div  class=\"backup\"><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "&itid=" + Request.QueryString["itid"] +
                                                      "\" class=\"back_btn backfirst\">返回首页</a><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid +
                                                      "&tiid=" + ptiid + "&itid=" + Request.QueryString["itid"] +
                                                      "\" class=\"back_btn\">返回上级</a> </div>";
                            }
                            else
                            {
                                #region 分站名称

                                StaPackage _staPackageDal = new StaPackage();
                                OrgOrganize _orgOrganizeDal = new OrgOrganize();
                                var spmodel = _staPackageDal.GetModel(Convert.ToInt32(spid));
                                if (null != spmodel)
                                {
                                    var orgmodel = _orgOrganizeDal.GetModel(Convert.ToInt64(spmodel.OrgId));
                                    if (null != orgmodel)
                                    {
                                        litStaName.Text =
                                            "<div class=\"logo\"><img src=\"/images/LOGO-yt.png\" style=\"display: block; width: 50px; height: 50px;\" alt=\"沿途\" /></div><div class=\"title\"><strong>" +
                                            orgmodel.OrgName + "</strong><span>" + orgmodel.EnName + "</span></div>";
                                    }
                                }

                                #endregion
                            }

                            #endregion

                            #region 分页

                            litPager.Text = "<td><input type=\"button\" class=\"btn btn-sm delpage\" value=\"删除\" style=\"width: 50px;\" /></td>"; ;

                            #endregion

                            litInfo1.Text = GetBtn(timodel, 1);
                        }
                    }

                    #endregion
                }
            }
        }

        #region

        private string GetBtn(Admin.Model.TempInfo timodel, int sortNum)
        {
            var user = (OrgUsers)HttpContext.Current.Session["CurrentUser"];
            var res = "";
            List<SqlParameter> par1 = new List<SqlParameter>();
            var tmpPar1 = _templateParDal.GetModel(" TID=" + timodel.TID + " and SortNum=" + sortNum + " ", par1);

            var info1 = _infosDal.GetModel(" TIID=" + timodel.TIID + " and SortNum=" + sortNum + " ", par1);
            if (null != info1)
            {
                #region 纯图广告反显

                if (info1.IType == 6)
                {
                    res = "<div class=\"btnbox\" style=\"top:54%;display:none\"><a href=\"javascript:;\" class=\"btn edit-info\" data-iid=\"" +
                          info1.IID + "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑</a> <a href=\"javascript:;\" class=\"btn del-info\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">删除</a>";

                    if (1 == user.Type)
                    {
                        if (1 == info1.Status)
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" +
                                   info1.IID +
                                   "\">标记</a>";
                        }
                        else
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" +
                                   info1.IID +
                                   "\">取消标记</a>";
                        }

                    }
                    else
                    {
                        if (0 == info1.Status)
                        {
                            res += " <span class=\"btn btn-editing\">待修改</span>";
                        }
                    }
                    res += "</div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
                }

                #endregion
            }
            else
            {
                res = "<div class=\"btnbox\"><a href=\"javascript:;\" class=\"btn new-info\" data-sortnum=\"" + sortNum +
                      "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                      "\">新增</a>";
                //res += " <a href=\"javascript:;\" class=\"btn select-info\" data-sortnum=\"" + sortNum +
                //      "\">选择</a>";
                res += "</div><img>";
            }
            return res;
        }

        #endregion
    }

}