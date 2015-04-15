using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebSite.Admin.DAL;
using WebSite.Lib;

namespace WebSite.Web.Manage.Template
{
    public partial class TmpInfoPicInfo : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        Infos infosDal = new Infos();
        TemplatePar templateParDal = new TemplatePar();
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

                            if (0 != timodel.ParentID)
                            {
                                var imodel = infosDal.GetModel(Convert.ToInt32(timodel.ParentID));
                                if (null != imodel)
                                {
                                    litStaName.Text = "<div  class=\"backup\"><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "&itid=" + Request.QueryString["itid"] +
                                                      "\" class=\"back_btn backfirst\">返回首页</a><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid +
                                                      "&tiid=" + imodel.TIID + "&itid=" + Request.QueryString["itid"] +
                                                      "\" class=\"back_btn\">返回上级</a> </div>";
                                }
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
                                    "\" style=\"width: 40px;display:inline;text-align: center;\" /> /" + count + "</td><td><input data-parcount=\"" + timodel.ParentID + "\" data-count=\"" + count + "\" type=\"button\" class=\"btn btn-sm repage\" value=\"跳转\" style=\"width: 70px;\" /></td><td><input type=\"button\" class=\"btn btn-sm editpno\" value=\"修改页码\" style=\"width: 70px;\" /></td><td><input type=\"button\" class=\"btn btn-sm delpage\" value=\"删除当前页\" /></td>";
                            }
                            else if (count == 1)
                            {
                                pager +=
                                    "<td><input type=\"button\" class=\"btn btn-sm delpage\" value=\"删除当前页\" /></td>";
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
                                                  "&tiid=" + timodel.TIID + "\" class=\" btn btn-add newpage\">新建内容页</a> <a href=\"/Manage/News/RedircetAD.aspx?itid=" +
                                         Request.QueryString["itid"] + "&spid=" + Request.QueryString["spid"] + "&tiid=" +
                                         timodel.TIID + "\" class=\"btn btn-add newpage\" style=\"top:50%\">添加文末广告</a>";
                            }
                            litPager.Text = pager;

                            #endregion

                            List<SqlParameter> par1 = new List<SqlParameter>();
                            var tmpPar1 = templateParDal.GetModel(" TID=" + timodel.TID + " and SortNum=1 ", par1);

                            var str = "<div class=\"box col-sm-12 ht2\" style=\"text-align:inherit\">";
                            var dtInfo = infosDal.GetList(" TIID=" + timodel.TIID, par1).Tables[0];
                            if (dtInfo.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtInfo.Rows.Count; i++)
                                {
                                    var point = "/images/hand.png";
                                    if ("" != dtInfo.Rows[i]["ADPic"].ToString())
                                    {
                                        point = "/UploadFiles/" + dtInfo.Rows[i]["ADPic"];
                                    }
                                    str +=
                                        "<div class=\"news-pic\" style=\"top:" + dtInfo.Rows[i]["YPosition"] +
                                        "px;left:" + dtInfo.Rows[i]["XPosition"] +
                                        "px;\"><a href=\"javascript:;\" data-iid=\"" + dtInfo.Rows[i]["IID"] +
                                        "\" class=\"btn edit-pic\">编辑</a> <a href=\"javascript:;\" data-iid=\"" +
                                        dtInfo.Rows[i]["IID"] +
                                        "\" class=\"btn del-pic\">删除</a><img src=\"" + point + "\" style=\"background-color:transparent\"/></div>";
                                }
                                if (dtInfo.Rows.Count < 4)
                                {
                                    str +=
                                        "<div class=\"btnbox\"><a href=\"javascript:;\" class=\"btn new-info\" data-bgw=\"" +
                                        tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                                        "\">新增热点</a> <a href=\"javascript:;\" class=\"btn edit-bpic\" data-bgw=\"" +
                                        tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                                        "\" data-tiid=\"" +
                                        timodel.TIID + "\">编辑背景</a></div>";
                                }
                                else
                                {
                                    str +=
                                        "<div class=\"btnbox\"><a href=\"javascript:;\" data-bgw=\"" +
                                        tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                                        "\" class=\"btn edit-bpic\" data-tiid=\"" +
                                        timodel.TIID + "\">编辑背景</a></div>";
                                }
                            }
                            else
                            {
                                str +=
                                        "<div class=\"btnbox\"><a href=\"javascript:;\" class=\"btn new-info\" data-bgw=\"" +
                                        tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                                        "\">新增热点</a> <a href=\"javascript:;\" class=\"btn edit-bpic\" data-bgw=\"" +
                                        tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                                        "\" data-tiid=\"" + timodel.TIID + "\">上传背景</a>";
                                //str += " <a href=\"javascript:;\" class=\"btn select-info\" data-sortnum=\"1\">选择</a>";
                                str += "</div>";
                            }
                            if (!string.IsNullOrEmpty(timodel.AttID))
                            {
                                str += "<img src=\"/UploadFiles/" + timodel.AttID + "\">";
                            }
                            else
                            {
                                str += "<img>";
                            }
                            str += "</div>";
                            litInfo1.Text = str;
                        }
                    }

                    #endregion
                }
            }
        }
    }

}