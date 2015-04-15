using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class AddHotPic : UI.WebPage
    {
        private readonly OrgEmployees _dataDal = new OrgEmployees();
        private readonly OrgUsers _dataDal1 = new OrgUsers();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        private readonly ALabel _aLabelDal = new ALabel();
        private readonly Infos _infosDal = new Infos();
        private readonly AttaList _attaListDal = new AttaList();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                rboSingle.Checked = true;
                rboDouble.Checked = false;
                dorg.Style.Add("display", "block");
                dvideo.Style.Add("display", "none");
                var iid = Request.QueryString["iid"];
                if (!string.IsNullOrEmpty(iid))
                {
                    var imodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    if (null != imodel)
                    {
                        if (!string.IsNullOrEmpty(imodel.ADPic))
                        {
                            var fname = "";
                            if ("C0pY" == imodel.ADPic.Substring(0, 4))
                            {
                                fname = imodel.ADPic.Substring(76);
                            }
                            else
                            {
                                fname = imodel.ADPic.Substring(36);
                            }
                            litPic.Text =
                            "<div class=\"upatta\"  title=\"" + fname + "\" data-file=\"" + imodel.ADPic + "\"><div class=\"upsigin\"><div class=\"at-file\"><img width=\"220\" id=\"at-img\" src=\"/UploadFiles/" + imodel.ADPic + "\"><span class=\"at-name\">" + (fname.Length > 15 ? fname.Substring(0, 15) + "..." : fname) + "</span></div></div></div>";
                        }

                        txtName.Value = imodel.IName;
                        txtXPosition.Value = imodel.XPosition;
                        txtYPosition.Value = imodel.YPosition;

                        #region

                        var css = "";
                        var str = "";
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        parameters.Add(new SqlParameter("@IID", DbType.AnsiString) { Value = iid });
                        var dt = _attaListDal.GetList(" IID=@IID ", parameters).Tables[0];

                        #region 热点图片

                        if (1 == imodel.HotType)
                        {
                            css = "upatta3";
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (DBNull.Value != dt.Rows[i]["AttID"])
                                    {
                                        if (!string.IsNullOrEmpty(dt.Rows[i]["AttID"].ToString()))
                                        {
                                            //var fname = dt.Rows[i]["AttID"].ToString().Substring(36);
                                            var fname = "";
                                            if ("C0pY" == dt.Rows[i]["AttID"].ToString().Substring(0, 4))
                                            {
                                                fname = dt.Rows[i]["AttID"].ToString().Substring(76);
                                            }
                                            else
                                            {
                                                fname = dt.Rows[i]["AttID"].ToString().Substring(36);
                                            }
                                            var img = "";
                                            if (1 == imodel.HotType)
                                            {
                                                img = "<img width=\"100\" height=\"100\" src=\"/UploadFiles/" +
                                                      dt.Rows[i]["AttID"] + "\">";
                                            }
                                            str += "<li class=\"" + css + "\" title=\"" + fname + "\" data-file=\"" +
                                                   dt.Rows[i]["AttID"] +
                                                   "\">" + img +
                                                   (fname.Length > 5 ? fname.Substring(0, 5) + "..." : fname) +
                                                   "<div class=\"load\" style=\"height: 0px;margin-top:0px;\"></div><a href=\"javascript:;\" class=\"del-hotpic\" data-alid=\"" +
                                                   dt.Rows[i]["ALID"] + "\">删除</a></li>";
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region 热点视频

                        else if (2 == imodel.HotType)
                        {
                            css = "upatta2";
                            if (dt.Rows.Count > 0)
                            {
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    if (DBNull.Value != dt.Rows[i]["AttID"])
                                    {
                                        if (!string.IsNullOrEmpty(dt.Rows[i]["AttID"].ToString()))
                                        {
                                            //var fname = dt.Rows[i]["AttID"].ToString().Substring(36);
                                            var fname = "";
                                            if ("C0pY" == dt.Rows[i]["AttID"].ToString().Substring(0, 4))
                                            {
                                                fname = dt.Rows[i]["AttID"].ToString().Substring(76);
                                            }
                                            else
                                            {
                                                fname = dt.Rows[i]["AttID"].ToString().Substring(36);
                                            }
                                            //var img = "";
                                            //if (1 == imodel.HotType)
                                            //{
                                            //    img = "<img width=\"100\" height=\"100\" src=\"/UploadFiles/" +
                                            //          dt.Rows[i]["AttID"] + "\">";
                                            //}
                                            //str += "<div class=\"" + css + "\" title=\"" + fname + "\" data-file=\"" +
                                            //       dt.Rows[i]["AttID"] +
                                            //       "\">" + img +
                                            //       (fname.Length > 5 ? fname.Substring(0, 5) + "..." : fname) +
                                            //       "<div class=\"load\" style=\"height: 0px;margin-top:0px;\"></div><a href=\"javascript:;\" class=\"del-hotpic\" data-alid=\"" +
                                            //       dt.Rows[i]["ALID"] + "\">删除</a></div>";
                                            str += "<div class=\"upatta2\" title=\"" + fname + "\" data-file=\"" +
                                    dt.Rows[i]["AttID"] +
                                    "\"><div class=\"upsigin\"><div class=\"at-file\"><span class=\"at-name\">" +
                                    (fname.Length > 15 ? fname.Substring(0, 15) + "..." : fname) +
                                    "</span></div></div></div>";
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                        #endregion

                        if (1 == imodel.HotType)
                        {
                            rboSingle.Checked = true;
                            rboDouble.Checked = false;
                            dorg.Style.Add("display", "block");
                            dvideo.Style.Add("display", "none");
                            litHotPic.Text = str;
                        }
                        else if (2 == imodel.HotType)
                        {
                            rboSingle.Checked = false;
                            rboDouble.Checked = true;
                            dvideo.Style.Add("display", "block");
                            dorg.Style.Add("display", "none");
                            Literal1.Text = str;
                        }
                    }
                }
            }
        }
    }

}