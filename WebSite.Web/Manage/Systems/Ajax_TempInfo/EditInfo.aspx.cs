using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_TempInfo
{
    public partial class EditInfo : UI.WebPage
    {
        private readonly ALabel _aLabelDal = new ALabel();
        private readonly Infos _infosDal = new Infos();
        private readonly InfoLabel _infoLabelDal = new InfoLabel();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly AttaList _attaListDal = new AttaList();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                litselinfo.Text = GetDdl("");
                var iid = Request.QueryString["iid"];
                if (!string.IsNullOrEmpty(iid))
                {
                    dorg.Visible = false;
                    rbNews.Disabled = true;
                    rbVideo.Disabled = true;
                    rbTopic.Disabled = true;
                    var imodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    if (null != imodel)
                    {
                        txtName.Value = imodel.IName;

                        if (!string.IsNullOrEmpty(imodel.PicAttID))
                        {
                            var fname = "";
                            if ("C0pY" == imodel.PicAttID.Substring(0, 4))
                            {
                                fname = imodel.PicAttID.Substring(76);
                            }
                            else
                            {
                                fname = imodel.PicAttID.Substring(36);
                            }
                            litPic.Text =
                            "<div class=\"upatta\"  title=\"" + fname + "\" data-file=\"" + imodel.PicAttID + "\"><div class=\"upsigin\"><div class=\"at-file\"><img width=\"220\" id=\"at-img\" src=\"/UploadFiles/" + imodel.PicAttID + "\"><span class=\"at-name\">" + (fname.Length > 15 ? fname.Substring(0, 15) + "..." : fname) + "</span></div></div></div>";
                        }
                        if (imodel.NType == 0)
                        {
                            radInfo.Checked = true;
                        }
                        if (imodel.NType == 1)
                        {
                            radAds.Checked = true;
                        }
                        if (imodel.IType == 1)
                        {
                            rbNews.Checked = true;
                        }
                        if (imodel.IType == 2)
                        {
                            rbVideo.Checked = true;
                            dorg.Visible = true;

                            #region 内容视频

                            if (!string.IsNullOrEmpty(imodel.VideoAttID))
                            {
                                //var vname = imodel.VideoAttID.Substring(36);
                                var vname = "";
                                if ("C0pY" == imodel.VideoAttID.Substring(0, 4))
                                {
                                    vname = imodel.VideoAttID.Substring(76);
                                }
                                else
                                {
                                    vname = imodel.VideoAttID.Substring(36);
                                }
                                litVideo.Text =
                                    "<div class=\"upatta2\" title=\"" + vname + "\" data-file=\"" +
                                    imodel.VideoAttID +
                                    "\"><div class=\"upsigin\"><div class=\"at-file\"><span class=\"at-name\">" +
                                    (vname.Length > 15 ? vname.Substring(0, 15) + "..." : vname) +
                                    "</span></div></div></div>";
                            }

                            #endregion

                            #region 暂停广告

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
                                litpausepic.Text =
                                    "<div class=\"upatta5\"  title=\"" + fname + "\" data-file=\"" + imodel.ADPic +
                                    "\"><div class=\"upsigin\"><div class=\"at-file\"><img width=\"220\" id=\"at-img\" src=\"/UploadFiles/" +
                                    imodel.ADPic + "\"><span class=\"at-name\">" +
                                    (fname.Length > 15 ? fname.Substring(0, 15) + "..." : fname) +
                                    "</span></div>";
                                litpausepic.Text += GetDdl(imodel.ADLink);
                                litpausepic.Text += "</div></div>";
                            }

                            #endregion

                            #region 广告视频

                            List<SqlParameter> parameters = new List<SqlParameter>();
                            parameters.Add(new SqlParameter("@IID", DbType.AnsiString) { Value = iid });
                            var dt = _attaListDal.GetList(" IID=@IID ", parameters).Tables[0];
                            var str = "";
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
                                            str +=
                                    "<div class=\"upatta6\"  title=\"" + fname + "\" data-file=\"" + dt.Rows[i]["AttID"] +
                                    "\"><div class=\"upsigin\"><div class=\"at-file\"><span class=\"at-name\">" +
                                    (fname.Length > 15 ? fname.Substring(0, 15) + "..." : fname) +
                                    "</span></div>";
                                            str += GetDdl(dt.Rows[i]["AD_IID"].ToString());
                                            str += "<span><a href=\"javascript:void(0)\" class=\"glyphicon glyphicon-remove delfile\" data-attid=\"" + dt.Rows[i]["AttID"].ToString() + "\" title=\"移除文件\">删除</a></span>";
                                            str += "</div></div>";
                                        }
                                    }
                                }
                            }
                            litpausevideo.Text = str;

                            #endregion

                            txtADTime.Value = imodel.ADTime;
                        }
                        if (imodel.IType == 3)
                        {
                            rbTopic.Checked = true;
                        }
                    }
                }
            }
        }
        protected DataSet GetLabel()
        {
            List<SqlParameter> parDef1 = new List<SqlParameter>();
            return _aLabelDal.GetList(" Status=1 ", parDef1);
        }

        public string selectCheck(string alid)
        {
            string ischek = "";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IID", DbType.AnsiString) { Value = Request.QueryString["iid"] });
            DataSet dt = _infoLabelDal.GetList(" IID=@IID ", parameters);
            if (dt != null)
            {
                if (dt.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        if (alid == dt.Tables[0].Rows[i]["ALID"].ToString())
                        {
                            ischek = "checked='checked'";
                            break;
                        }
                    }
                }
            }
            return ischek;
        }

        private string GetDdl(string siid)
        {
            var str = new StringBuilder();
            str.Append("<div style=\"margin-top: 5px;\" id=\"ddladlink\">");
            str.Append("<select class=\"ddlinfo\"><option value=\"\">无</option>");
            var timodel = _tempInfoDal.GetModel(Convert.ToInt32(Request.QueryString["tiid"]));
            if (null != timodel)
            {
                var sql = "select Infos.IID,Infos.IName from Infos join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID where InfoType.SPID=@SPID";
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                dbCommand.Parameters.Add(new SqlParameter("@SPID", DbType.Int32) { Value = Request.QueryString["spid"] });
                var dt = db.ExecuteDataSet(dbCommand).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (siid == dt.Rows[i]["IID"].ToString())
                        {
                            str.Append("<option selected=\"selected\" value=\"" + dt.Rows[i]["IID"] + "\">" + dt.Rows[i]["IName"] +
                                       "</option>");
                        }
                        else
                        {
                            str.Append("<option value=\"" + dt.Rows[i]["IID"] + "\">" + dt.Rows[i]["IName"] +
                                       "</option>");
                        }
                    }
                }
            }
            str.Append("</select>");
            str.Append("</div>");
            return str.ToString();
        }
    }

}