using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using WebSite.Admin.DAL;
using OrgUsers = WebSite.Admin.Model.OrgUsers;

namespace WebSite.Lib
{
    public class Service
    {
        private static readonly InfoType _infoTypeDal = new InfoType();
        private static readonly Infos infosDal = new Infos();
        private static readonly TemplatePar templateParDal = new TemplatePar();
        private static readonly TempInfo _tempInfoDal = new TempInfo();

        #region 左侧分类

        public static string GetType(int itid, string spid)
        {
            var type = "";

            #region

            List<SqlParameter> pars1 = new List<SqlParameter>();
            var par1 = new SqlParameter("@SPID", DbType.AnsiString) { Value = spid };
            pars1.Add(par1);
            var type1 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars1);
            if (null != type1)
            {
                type += "<li data-sort=\"1\" data-spid=\"" + spid + "\" title=\"分类ID-" + type1.ITID + "\" data-typeid=\"" + type1.ITID + "\" ";
                if (type1.ITID == itid || itid == 0)
                {
                    type += " class=\"li-type active\"";
                }
                else
                {
                    type += " class=\"li-type\"";
                }
                type += " >";
                type +=
                    "<div class=\"nav\"><a href=\"javascript:;\" class=\"ren-infotype\">编辑</a><a href=\"javascript:;\" class=\"del-infotype\">删除</a></div><span class=\"arrow down\"></span>";
                type += "<a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" src=\"/UploadFiles/" +
                        type1.AttaID + "\"></span>" + type1.IName +
                        "</a></li>";
            }
            else
            {
                type += "<li class=\"cre-infotype\" data-sort=\"1\" data-spid=\"" + spid +
                        "\"><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" /></span>新增</a></li>";
            }

            #endregion

            #region

            List<SqlParameter> pars2 = new List<SqlParameter>();
            var par2 = new SqlParameter("@SPID", DbType.AnsiString) { Value = spid };
            pars2.Add(par2);
            var type2 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=2 ", pars2);
            if (null != type2)
            {
                type += "<li data-sort=\"2\" data-spid=\"" + spid + "\" title=\"分类ID-" + type2.ITID + "\" data-typeid=\"" + type2.ITID + "\" " +
                        (type2.ITID == itid ? " class=\"li-type active\" " : " class=\"li-type\" ") +
                        "><div class=\"nav\"><a href=\"javascript:;\" class=\"ren-infotype\">编辑</a><a href=\"javascript:;\" class=\"del-infotype\">删除</a></div><span class=\"arrow up\"></span><span class=\"arrow down\"></span><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" src=\"/UploadFiles/" +
                        type2.AttaID + "\"></span>" + type2.IName +
                        "</a></li>";
            }
            else
            {
                type += "<li class=\"cre-infotype\" data-sort=\"2\" data-spid=\"" + spid +
                        "\"><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" /></span>新增</a></li>";
            }

            #endregion

            #region

            List<SqlParameter> pars3 = new List<SqlParameter>();
            var par3 = new SqlParameter("@SPID", DbType.AnsiString) { Value = spid };
            pars3.Add(par3);
            var type3 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=3 ", pars3);
            if (null != type3)
            {
                type += "<li data-sort=\"3\" data-spid=\"" + spid + "\" title=\"分类ID-" + type3.ITID + "\" data-typeid=\"" + type3.ITID + "\" " +
                        (type3.ITID == itid ? " class=\"li-type active\" " : " class=\"li-type\" ") +
                        "><div class=\"nav\"><a href=\"javascript:;\" class=\"ren-infotype\">编辑</a><a href=\"javascript:;\" class=\"del-infotype\">删除</a></div><span class=\"arrow up\"></span><span class=\"arrow down\"></span><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" src=\"/UploadFiles/" +
                        type3.AttaID + "\"></span>" + type3.IName +
                        "</a></li>";
            }
            else
            {
                type += "<li class=\"cre-infotype\" data-sort=\"3\" data-spid=\"" + spid +
                        "\"><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" /></span>新增</a></li>";
            }

            #endregion

            #region

            List<SqlParameter> pars4 = new List<SqlParameter>();
            var par4 = new SqlParameter("@SPID", DbType.AnsiString) { Value = spid };
            pars4.Add(par4);
            var type4 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=4 ", pars4);
            if (null != type4)
            {
                type += "<li data-sort=\"4\" data-spid=\"" + spid + "\" title=\"分类ID-" + type4.ITID + "\" data-typeid=\"" + type4.ITID + "\" " +
                        (type4.ITID == itid ? " class=\"li-type active\" " : " class=\"li-type\" ") +
                        "><div class=\"nav\"><a href=\"javascript:;\" class=\"ren-infotype\">编辑</a><a href=\"javascript:;\" class=\"del-infotype\">删除</a></div><span class=\"arrow up\"></span><span class=\"arrow down\"></span><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" src=\"/UploadFiles/" +
                        type4.AttaID + "\"></span>" + type4.IName +
                        "</a></li>";
            }
            else
            {
                type += "<li class=\"cre-infotype\" data-sort=\"4\" data-spid=\"" + spid +
                        "\"><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" /></span>新增</a></li>";
            }

            #endregion

            #region

            List<SqlParameter> pars5 = new List<SqlParameter>();
            var par5 = new SqlParameter("@SPID", DbType.AnsiString) { Value = spid };
            pars5.Add(par5);
            var type5 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=5 ", pars5);
            if (null != type5)
            {
                type += "<li data-sort=\"5\" data-spid=\"" + spid + "\" title=\"分类ID-" + type5.ITID + "\" data-typeid=\"" + type5.ITID + "\" " +
                        (type5.ITID == itid ? " class=\"li-type active\" " : " class=\"li-type\" ") +
                        "><div class=\"nav\"><a href=\"javascript:;\" class=\"ren-infotype\">编辑</a><a href=\"javascript:;\" class=\"del-infotype\">删除</a></div><span class=\"arrow up\"></span><span class=\"arrow down\"></span><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" src=\"/UploadFiles/" +
                        type5.AttaID + "\"></span>" + type5.IName +
                        "</a></li>";
            }
            else
            {
                type += "<li class=\"cre-infotype\" data-sort=\"5\" data-spid=\"" + spid +
                        "\"><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" /></span>新增</a></li>";
            }

            #endregion

            #region

            List<SqlParameter> pars6 = new List<SqlParameter>();
            var par6 = new SqlParameter("@SPID", DbType.AnsiString) { Value = spid };
            pars6.Add(par6);
            var type6 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=6 ", pars6);
            if (null != type6)
            {
                type += "<li data-sort=\"6\" data-spid=\"" + spid + "\" title=\"分类ID-" + type6.ITID + "\" data-typeid=\"" + type6.ITID + "\" " +
                        (type6.ITID == itid ? " class=\"li-type active\" " : " class=\"li-type\" ") +
                        "><div class=\"nav\"><a href=\"javascript:;\" class=\"ren-infotype\">编辑</a><a href=\"javascript:;\" class=\"del-infotype\">删除</a></div><span class=\"arrow up\"></span><span class=\"arrow down\"></span><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" src=\"/UploadFiles/" +
                        type6.AttaID + "\"></span>" + type6.IName +
                        "</a></li>";
            }
            else
            {
                type += "<li class=\"cre-infotype\" data-sort=\"6\" data-spid=\"" + spid +
                        "\"><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" /></span>新增</a></li>";
            }

            #endregion

            #region

            List<SqlParameter> pars7 = new List<SqlParameter>();
            var par7 = new SqlParameter("@SPID", DbType.AnsiString) { Value = spid };
            pars7.Add(par7);
            var type7 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=7 ", pars7);
            if (null != type7)
            {
                type += "<li data-sort=\"7\" data-spid=\"" + spid + "\" title=\"分类ID-" + type7.ITID + "\" data-typeid=\"" + type7.ITID + "\" " +
                        (type7.ITID == itid ? " class=\"li-type active\" " : " class=\"li-type\" ") +
                        "><div class=\"nav\"><a href=\"javascript:;\" class=\"ren-infotype\">编辑</a><a href=\"javascript:;\" class=\"del-infotype\">删除</a></div><span class=\"arrow up\"></span><span class=\"arrow down\"></span><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" src=\"/UploadFiles/" +
                        type7.AttaID + "\"></span>" + type7.IName +
                        "</a></li>";
            }
            else
            {
                type += "<li class=\"cre-infotype\" data-sort=\"7\" data-spid=\"" + spid +
                        "\"><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" /></span>新增</a></li>";
            }

            #endregion

            #region

            List<SqlParameter> pars8 = new List<SqlParameter>();
            var par8 = new SqlParameter("@SPID", DbType.AnsiString) { Value = spid };
            pars8.Add(par8);
            var type8 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=8 ", pars8);
            if (null != type8)
            {
                type += "<li data-sort=\"8\" data-spid=\"" + spid + "\" title=\"分类ID-" + type8.ITID + "\" data-typeid=\"" + type8.ITID + "\" " +
                        (type8.ITID == itid ? " class=\"li-type active\" " : " class=\"li-type\" ") +
                        "><div class=\"nav\"><a href=\"javascript:;\" class=\"ren-infotype\">编辑</a><a href=\"javascript:;\" class=\"del-infotype\">删除</a></div><span class=\"arrow up\"></span><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" src=\"/UploadFiles/" +
                        type8.AttaID + "\"></span>" + type8.IName +
                        "</a></li>";
            }
            else
            {
                type += "<li class=\"cre-infotype\" data-sort=\"8\" data-spid=\"" + spid +
                        "\"><a href=\"javascript:;\"><span class=\"icon\"><img alt=\"\" /></span>新增</a></li>";
            }

            #endregion

            return type;
        }

        #endregion

        #region 分页

        public static string Pager(Admin.Model.TempInfo timodel, object spid, object itid, out string newpage)
        {
            #region 分页

            var pager = "";
            newpage = "";
            List<SqlParameter> parDef = new List<SqlParameter>();
            var preitModel =
                _tempInfoDal.GetModel(
                    " ITID=" + timodel.ITID + " and ParentID=" + timodel.ParentID + " and TIPage=" +
                    (timodel.TIPage - 1), parDef);
            if (null != preitModel)
            {
                pager += "<td><a href=\"/Manage/Template/Redircet.aspx?itid=" +
                         itid + "&spid=" + spid + "&tiid=" +
                         preitModel.TIID + "\" class=\"btn btnprev\" data-tiid=\"" + preitModel.TIID +
                         "\">上页 </a></td>";
            }
            else
            {
                pager += "<td>&nbsp;</td>";
            }
            var count =
                _tempInfoDal.GetList(" ITID=" + timodel.ITID + " and ParentID=" + timodel.ParentID,
                    parDef).Tables[0].Rows.Count;
            if (count > 1)
            {
                pager +=
                    "<td>页码 </td><td><input type=\"text\" class=\"form-control input-sm iptpno\" value=\"" +
                    timodel.TIPage +
                    "\" style=\"width: 40px;display:inline;text-align: center;\" /> /" + count + "</td><td><input data-parcount=\"" + timodel.ParentID + "\" data-count=\"" + count + "\" type=\"button\" class=\"btn btn-sm repage\" value=\"跳转\" style=\"width: 70px;\" /></td><td><input type=\"button\" class=\"btn btn-sm editpno\" value=\"修改页码\" style=\"width: 70px;\" /></td><td><input type=\"button\" class=\"btn btn-sm delpage\" value=\"删除本页模板\" /></td>";
            }
            else if (count == 1)
            {
                pager +=
                    "<td><input type=\"button\" class=\"btn btn-sm delpage\" value=\"删除本页模板\" /></td>";
            }
            var nexitModel =
                _tempInfoDal.GetModel(
                    " ITID=" + timodel.ITID + " and ParentID=" + timodel.ParentID + " and TIPage=" +
                    (timodel.TIPage + 1), parDef);
            if (null != nexitModel)
            {
                pager += "<td><a href=\"/Manage/Template/Redircet.aspx?itid=" +
                         itid + "&spid=" + spid + "&tiid=" +
                         nexitModel.TIID + "\" class=\"btn btnnext\" data-tiid=\"" +
                         nexitModel.TIID + "\">下页 </a></td>";
            }
            else
            {
                pager += "<td>&nbsp;</td>";
                newpage = "<a href=\"/Manage/Systems/ChooseTemplate.aspx?page=" +
                          (timodel.TIPage + 1) + "&pid=" + timodel.ParentID + "&itid=" +
                          itid + "&spid=" + spid +
                          "&tiid=" + timodel.TIID + "\" class=\"btn btn-add nepage\">新建模板页</a>";
            }
            return pager;

            #endregion
        }

        #endregion

        #region 导航

        public static string Nav(Admin.Model.TempInfo timodel, object spid, object itid)
        {
            #region 导航

            var str = "";
            if (0 != timodel.ParentID)
            {
                var imodel = infosDal.GetModel(Convert.ToInt32(timodel.ParentID));
                if (null != imodel)
                {
                    str = "<div  class=\"backup\"><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "&itid=" + itid +
                                                      "\" class=\"back_btn backfirst\">返回首页</a><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid +
                                                      "&tiid=" + imodel.TIID + "&itid=" + itid +
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
                        str =
                            "<div class=\"logo\"><img src=\"/images/LOGO-yt.png\" style=\"display: block; width: 50px; height: 50px;\" alt=\"沿途\" /></div><div class=\"title\"><strong>" +
                            orgmodel.OrgName + "</strong><span>" + orgmodel.EnName + "</span></div>";
                    }
                }

                #endregion
            }
            return str;

            #endregion
        }

        #endregion

        #region 模板内容反显

        public static string GetBtn(Admin.Model.TempInfo timodel, int sortNum, object spid, object itid)
        {
            var user = (OrgUsers)HttpContext.Current.Session["CurrentUser"];
            var res = "";
            List<SqlParameter> par1 = new List<SqlParameter>();
            var tmpPar1 = templateParDal.GetModel(" TID=" + timodel.TID + " and SortNum=" + sortNum + " ", par1);

            var info1 = infosDal.GetModel(" TIID=" + timodel.TIID + " and SortNum=" + sortNum + " ", par1);
            if (null != info1)
            {
                #region 资讯反显

                if (info1.IType == 1)
                {
                    res = "<div class=\"btnbox\" style=\"top:54%;display:none\"><a href=\"javascript:;\" class=\"btn edit-info\" data-iid=\"" +
                          info1.IID + "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑</a> <a href=\"javascript:;\" class=\"btn del-info\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">删除</a> <a href=\"/Manage/News/Redircet.aspx?spid=" + spid + "&itid=" + itid + "&pid=" + info1.IID + "\" class=\"btn enter-news\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑内容</a>";

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
                    if (info1.NType == 1)
                    {
                        res += "<div class=\"btnbox\" style=\"width:50px;top: 0;left: 0;\"><a style=\"background-color: red;\" href=\"javascript:;\" class=\"btn\">广告</a></div>";
                    }
                }

                #endregion

                #region 视频反显

                if (info1.IType == 2)
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
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
                                   "\">标记</a>";
                        }
                        else
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
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

                    res += "</div><div class=\"video-pre\"></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
                    if (info1.NType == 1)
                    {
                        res += "<div class=\"btnbox\" style=\"width:50px;top: 0;left: 0;\"><a style=\"background-color: red;\" href=\"javascript:;\" class=\"btn\">广告</a></div>";
                    }
                }

                #endregion

                #region 专题反显

                if (info1.IType == 3)
                {
                    res = "<div class=\"btnbox\" style=\"top:54%;display:none\"><a href=\"javascript:;\" class=\"btn edit-info\" data-iid=\"" +
                          info1.IID + "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑</a> <a href=\"javascript:;\" class=\"btn del-info\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">删除</a> <a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "&itid=" + itid + "&pid=" + info1.IID + "\" class=\"btn\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑专题</a>";
                    if (1 == user.Type)
                    {
                        if (1 == info1.Status)
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
                                   "\">标记</a>";
                        }
                        else
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
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
                    if (info1.NType == 1)
                    {
                        res += "<div class=\"btnbox\" style=\"width:50px;top: 0;left: 0;\"><a style=\"background-color: red;\" href=\"javascript:;\" class=\"btn\">广告</a></div>";
                    }
                }

                #endregion
            }
            else
            {
                res = "<div class=\"btnbox\"><a href=\"javascript:;\" class=\"btn new-info\" data-sortnum=\"" + sortNum +
                      "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                      "\">新增</a>";
                if (timodel.ParentID == 0)
                {
                    res += " <a href=\"javascript:;\" class=\"btn select-info\" data-sortnum=\"" + sortNum +
                      "\">选择</a>";
                }
                res += "</div><img>";
            }
            return res;
        }

        #endregion

        #region 模板内容反显去按钮空格

        public static string GetBtnNoSpace(Admin.Model.TempInfo timodel, int sortNum, object spid, object itid)
        {
            var user = (OrgUsers)HttpContext.Current.Session["CurrentUser"];
            var res = "";
            List<SqlParameter> par1 = new List<SqlParameter>();
            var tmpPar1 = templateParDal.GetModel(" TID=" + timodel.TID + " and SortNum=" + sortNum + " ", par1);

            var info1 = infosDal.GetModel(" TIID=" + timodel.TIID + " and SortNum=" + sortNum + " ", par1);
            if (null != info1)
            {
                #region 资讯反显

                if (info1.IType == 1)
                {
                    res = "<div class=\"btnbox\" style=\"top:54%;display:none\"><a href=\"javascript:;\" class=\"btn edit-info\" data-iid=\"" +
                          info1.IID + "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑</a><a href=\"javascript:;\" class=\"btn del-info\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">删除</a><a href=\"/Manage/News/Redircet.aspx?spid=" + spid + "&itid=" + itid + "&pid=" + info1.IID + "\" class=\"btn enter-news\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑内容</a>";

                    if (1 == user.Type)
                    {
                        if (1 == info1.Status)
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
                                   "\">标记</a>";
                        }
                        else
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
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
                    if (info1.NType == 1)
                    {
                        res += "<div class=\"btnbox\" style=\"width:50px;top: 0;left: 0;\"><a style=\"background-color: red;\" href=\"javascript:;\" class=\"btn\">广告</a></div>";
                    }
                }

                #endregion

                #region 视频反显

                if (info1.IType == 2)
                {
                    res = "<div class=\"btnbox\" style=\"top:54%;display:none\"><a href=\"javascript:;\" class=\"btn edit-info\" data-iid=\"" +
                          info1.IID + "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑</a><a href=\"javascript:;\" class=\"btn del-info\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">删除</a>";
                    if (1 == user.Type)
                    {
                        if (1 == info1.Status)
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
                                   "\">标记</a>";
                        }
                        else
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
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

                    res += "</div><div class=\"video-pre\"></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
                    if (info1.NType == 1)
                    {
                        res += "<div class=\"btnbox\" style=\"width:50px;top: 0;left: 0;\"><a style=\"background-color: red;\" href=\"javascript:;\" class=\"btn\">广告</a></div>";
                    }
                }

                #endregion

                #region 专题反显

                if (info1.IType == 3)
                {
                    res = "<div class=\"btnbox\" style=\"top:54%;display:none\"><a href=\"javascript:;\" class=\"btn edit-info\" data-iid=\"" +
                          info1.IID + "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑</a><a href=\"javascript:;\" class=\"btn del-info\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">删除</a><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "&itid=" + itid + "&pid=" + info1.IID + "\" class=\"btn\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">编辑专题</a>";
                    if (1 == user.Type)
                    {
                        if (1 == info1.Status)
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
                                   "\">标记</a>";
                        }
                        else
                        {
                            res += " <a href=\"javascript:;\" class=\"btn sin-info btn-warning\" data-iid=\"" + info1.IID +
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
                    if (info1.NType == 1)
                    {
                        res += "<div class=\"btnbox\" style=\"width:50px;top: 0;left: 0;\"><a style=\"background-color: red;\" href=\"javascript:;\" style=\"background-color: red;\" class=\"btn\">广告</a></div>";
                    }
                }

                #endregion
            }
            else
            {
                res = "<div class=\"btnbox\"><a href=\"javascript:;\" class=\"btn new-info\" data-sortnum=\"" + sortNum +
                      "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                      "\">新增</a>";
                if (timodel.ParentID == 0)
                {
                    res += "<a href=\"javascript:;\" class=\"btn select-info\" data-sortnum=\"" + sortNum +
                      "\">选择</a>";
                }
                res += "</div><img>";
            }
            return res;
        }

        #endregion
    }
}
