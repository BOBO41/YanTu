using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebSite.Admin.DAL;
using WebSite.Lib;

namespace WebSite.Web.Manage.Template
{
    public partial class TmpInfo_14 : UI.WebPage
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
                            litStaName.Text = Service.Nav(timodel, Request.QueryString["spid"], Request.QueryString["itid"]);
                            #endregion

                            #region 分页
                            var newpage = "";
                            litPager.Text = Service.Pager(timodel, Request.QueryString["spid"], Request.QueryString["itid"], out newpage);
                            litNewPage.Text = newpage;
                            #endregion

                            litInfo1.Text = Service.GetBtn(timodel, 1, Request.QueryString["spid"], Request.QueryString["itid"]);
                            litInfo2.Text = Service.GetBtn(timodel, 2, Request.QueryString["spid"], Request.QueryString["itid"]);
                            litInfo3.Text = Service.GetBtn(timodel, 3, Request.QueryString["spid"], Request.QueryString["itid"]);
                            litInfo4.Text = Service.GetBtn(timodel, 4, Request.QueryString["spid"], Request.QueryString["itid"]);
                            litInfo5.Text = Service.GetBtnNoSpace(timodel, 5, Request.QueryString["spid"], Request.QueryString["itid"]);
                            litInfo6.Text = Service.GetBtn(timodel, 6, Request.QueryString["spid"], Request.QueryString["itid"]);
                            litInfo7.Text = Service.GetBtn(timodel, 7, Request.QueryString["spid"], Request.QueryString["itid"]);
                            litInfo8.Text = Service.GetBtn(timodel, 8, Request.QueryString["spid"], Request.QueryString["itid"]);
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
                          "\">删除</a> <a href=\"/Manage/News/Redircet.aspx?spid=" + Request.QueryString["spid"] + "&itid=" + Request.QueryString["itid"] + "&pid=" + info1.IID + "\" class=\"btn enter-news\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">查看资讯</a></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
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
                          "\">删除</a></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
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
                          "\">删除</a> <a href=\"/Manage/Template/Redircet.aspx?spid=" + Request.QueryString["spid"] + "&itid=" + Request.QueryString["itid"] + "&pid=" + info1.IID + "\" class=\"btn\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">查看专题</a></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
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

        #region

        private string GetBtnNoSpace(Admin.Model.TempInfo timodel, int sortNum)
        {
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
                          "\">删除</a><a href=\"/Manage/News/Redircet.aspx?spid=" + Request.QueryString["spid"] + "&itid=" + Request.QueryString["itid"] + "&pid=" + info1.IID + "\" class=\"btn enter-news\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">查看资讯</a></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
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
                          "\">删除</a></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
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
                          "\">删除</a><a href=\"/Manage/Template/Redircet.aspx?spid=" + Request.QueryString["spid"] + "&itid=" + Request.QueryString["itid"] + "&pid=" + info1.IID + "\" class=\"btn\" data-iid=\"" + info1.IID +
                          "\" data-sortnum=\"" + sortNum +
                          "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                          "\">查看专题</a></div><img src=\"/UploadFiles/" + info1.PicAttID + "\">";
                }

                #endregion
            }
            else
            {
                res = "<div class=\"btnbox\"><a href=\"javascript:;\" class=\"btn new-info\" data-sortnum=\"" + sortNum +
                      "\" data-bgw=\"" + tmpPar1.BgWidth + "\" data-bgh=\"" + tmpPar1.BgHeight +
                      "\">新增</a><a href=\"javascript:;\" class=\"btn select-info\" data-sortnum=\"" + sortNum +
                      "\">选择</a></div><img>";
            }
            return res;
        }

        #endregion

    }
}