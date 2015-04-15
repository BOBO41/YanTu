using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using WebSite.Admin.DAL;
using WebSite.Lib;
using OrgUsers = WebSite.Admin.Model.OrgUsers;

namespace WebSite.Web.Manage.Template
{
    public partial class TmpInfoPWInfo : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        readonly Infos _infosDal = new Infos();
        readonly TemplatePar _templateParDal = new TemplatePar();
        readonly AdInfos _adInfosDal = new AdInfos();
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
                            litStaName.Text = Service.Nav(timodel, Request.QueryString["spid"], Request.QueryString["itid"]);
                            #endregion

                            #region 分页

                            var pager = "";
                            List<SqlParameter> parDef = new List<SqlParameter>();
                            var preitModel =
                                _tempInfoDal.GetModel(
                                    " ITID=" + timodel.ITID + " and ParentID=" + timodel.ParentID + " and TIPage=" +
                                    (timodel.TIPage - 1), parDef);
                            if (null != preitModel)
                            {
                                pager += "<td><a href=\"/Manage/Template/Redircet.aspx?itid=" +
                                         Request.QueryString["itid"] + "&spid=" + Request.QueryString["spid"] + "&tiid=" +
                                         preitModel.TIID + "\" class=\"btn btnprev\" data-tiid=\"" + preitModel.TIID +
                                         "\">上页 </a></td>";
                            }
                            else
                            {
                                pager += "<td>&nbsp;</td>";
                            }
                            var count =
                                _tempInfoDal.GetList(" TIPage is not null and TIPage!='' and ITID=" + timodel.ITID + " and ParentID=" + timodel.ParentID,
                                    parDef).Tables[0].Rows.Count;
                            if (count > 1)
                            {
                                pager +=
                                    "<td>页码 </td><td><input type=\"text\" class=\"form-control input-sm iptpno\" value=\"" +
                                    timodel.TIPage +
                                    "\" style=\"width: 40px;display:inline;text-align: center;\" /> /" + count + "</td><td><input data-parcount=\"" + timodel.ParentID + "\" data-count=\"" + count + "\" type=\"button\" class=\"btn btn-sm repage\" value=\"跳转\" style=\"width: 70px;\" /></td><td><input type=\"button\" class=\"btn btn-sm editpno\" value=\"修改页码\" style=\"width: 70px;\" /></td><td><input type=\"button\" class=\"btn btn-sm delpage\" value=\"删除当前页\"/></td>";
                            }
                            else if (count == 1)
                            {
                                pager +=
                                    "<td><input type=\"button\" class=\"btn btn-sm delpage\" value=\"删除当前页\"/></td>";
                            }
                            var nexitModel =
                                _tempInfoDal.GetModel(
                                    " ITID=" + timodel.ITID + " and ParentID=" + timodel.ParentID + " and TIPage=" +
                                    (timodel.TIPage + 1), parDef);
                            if (null != nexitModel)
                            {
                                pager += "<td><a href=\"/Manage/Template/Redircet.aspx?itid=" +
                                         Request.QueryString["itid"] + "&spid=" + Request.QueryString["spid"] + "&tiid=" +
                                         nexitModel.TIID + "\" class=\"btn btnnext\" data-tiid=\"" +
                                         nexitModel.TIID + "\">下页 </a></td>";
                            }
                            else
                            {
                                pager += "<td>&nbsp;</td>";
                                litNewPage.Text = "<a href=\"/Manage/Systems/ChooseNewsTemplate.aspx?page=" +
                                                  (timodel.TIPage + 1) + "&pid=" + timodel.ParentID + "&itid=" +
                                                  Request.QueryString["itid"] + "&spid=" + Request.QueryString["spid"] +
                                                  "&tiid=" + timodel.TIID + "\" class=\"btn btn-add newpage\" style=\"top:33%\">新建内容页</a> <a href=\"/Manage/News/RedircetAD.aspx?itid=" +
                                         Request.QueryString["itid"] + "&spid=" + Request.QueryString["spid"] + "&tiid=" +
                                         timodel.TIID + "\" class=\"btn btn-add newpage\" style=\"top:53%\">添加文末广告</a>";
                            }
                            litPager.Text = pager;

                            #endregion

                            #region

                            var sortNum = 1;
                            List<SqlParameter> par1 = new List<SqlParameter>();
                            var tmpPar1 =
                                _templateParDal.GetModel(" TID=" + timodel.TID + " and SortNum=" + sortNum + " ", par1);

                            var info1 = _infosDal.GetModel(" TIID=" + timodel.TIID + " and SortNum=" + sortNum + " ",
                                par1);
                            if (null != info1)
                            {
                                #region 图文资讯反显
                                var user = (OrgUsers)HttpContext.Current.Session["CurrentUser"];
                                if (info1.IType == 4)
                                {
                                    litInfo1.Text =
                                        "<div class=\"btnbox\" style=\"top:54%;display:none\"><a href=\"javascript:;\" class=\"btn edit-info\" data-iid=\"" +
                                        info1.IID + "\" data-sortnum=\"" + sortNum +
                                        "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                                        "\">编辑</a> <a href=\"javascript:;\" class=\"btn del-info\" data-iid=\"" +
                                        info1.IID +
                                        "\" data-sortnum=\"" + sortNum +
                                        "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                                        "\">删除</a>";

                                    if (1 == user.Type)
                                    {
                                        if (1 == info1.Status)
                                        {
                                            litInfo1.Text += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" +
                                                   info1.IID +
                                                   "\">标记</a>";
                                        }
                                        else
                                        {
                                            litInfo1.Text += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" +
                                                   info1.IID +
                                                   "\">取消标记</a>";
                                        }

                                    }
                                    else
                                    {
                                        if (0 == info1.Status)
                                        {
                                            litInfo1.Text += " <span class=\"btn btn-editing\">待修改</span>";
                                        }
                                    }
                                    litInfo1.Text += "</div>";

                                    litInfo1.Text += "<div class=\"txtbox tbox" + info1.ConPosition + "\"><div class=\"pd\" style=\"font-size:" + info1.ConSize + "px;color:#" + info1.ConColor + "; word-break: break-all;\">" + info1.Context + "</div></div><img src=\"/UploadFiles/" + info1.PicAttID + "\" style=\"height:606px; display:block; width:100%;\">";
                                    List<SqlParameter> par = new List<SqlParameter>();
                                    par.Add(new SqlParameter("@IID", DbType.AnsiString) { Value = info1.IID });
                                    var dt = _adInfosDal.GetListAI(" AdInfos.IID=@IID ", par).Tables[0];

                                }

                                #endregion
                            }
                            else
                            {
                                litInfo1.Text =
                                    "<div class=\"btnbox\"><a href=\"javascript:;\" class=\"btn new-info\" data-sortnum=\"" +
                                    sortNum +
                                    "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                                    "\">编辑</a>";
                                //litInfo1.Text += " <a href=\"javascript:;\" class=\"btn select-info\" data-sortnum=\"" +
                                //    sortNum +
                                //    "\">选择</a>";
                                litInfo1.Text += "</div><img>";
                            }

                            #endregion

                        }
                    }

                    #endregion
                }
            }
        }

        #region

        private string GetBtn(Admin.Model.TempInfo timodel, int sortNum)
        {
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
                          "\">删除</a></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
                }

                #endregion
            }
            else
            {
                res = "<div class=\"btnbox\"><a href=\"javascript:;\" class=\"btn new-info\" data-sortnum=\"" + sortNum +
                      "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                      "\">新增</a> <a href=\"javascript:;\" class=\"btn select-info\" data-sortnum=\"" + sortNum +
                      "\">选择</a></div><img>";
            }
            return res;
        }

        #endregion
    }

}