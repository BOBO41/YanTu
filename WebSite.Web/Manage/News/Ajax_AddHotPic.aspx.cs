using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class Ajax_AddHotPic : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Infos _infosDal = new Infos();
        private readonly AttaList _attaListDal = new AttaList();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        string ePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            ePath = Server.MapPath("/UpLoad/");
            try
            {
                var id = Request.QueryString["spid"];
                var sortnum = Request.QueryString["sortnum"];
                var itid = Request.QueryString["itid"];
                var batta = HttpUtility.UrlDecode(Request.QueryString["batta"]);
                var tiid = Request.QueryString["tiid"];
                var name = HttpUtility.UrlDecode(Request.QueryString["name"]);
                var iid = Request.QueryString["iid"];
                var xPosition = Request.QueryString["xposition"];
                var yPosition = Request.QueryString["yposition"];
                var diid = Request.QueryString["diid"];
                var bpic = HttpUtility.UrlDecode(Request.QueryString["bpic"]);
                var aatta = HttpUtility.UrlDecode(Request.QueryString["aatta"]);
                var adtype = Request.QueryString["adtype"];
                Database db = DatabaseFactory.CreateDatabase();

                #region 设置背景图

                if (!string.IsNullOrEmpty(bpic) && !string.IsNullOrEmpty(tiid))
                {
                    var timodel = _tempInfoDal.GetModel(Convert.ToInt32(tiid));
                    if (null != timodel)
                    {
                        if (bpic != timodel.AttID)
                        {
                            if (File.Exists(ePath + bpic))
                            {
                                var fi = new FileInfo(ePath + bpic);
                                fi.MoveTo(Server.MapPath("/UploadFiles/" + bpic));
                                timodel.AttID = bpic;
                                var res = _tempInfoDal.Update(timodel);
                                if (res)
                                {
                                    Response.Write("0|~|" + tiid);
                                    Response.End();
                                }
                                else
                                {
                                    Response.Write("1|~|操作失败");
                                    Response.End();
                                }
                            }
                        }
                        else
                        {
                            Response.Write("0|~|" + tiid);
                            Response.End();
                        }
                    }
                }

                #endregion

                #region 删除热点

                if (!string.IsNullOrEmpty(diid))
                {
                    var infomodel = _infosDal.GetModel(Convert.ToInt32(diid));
                    if (null != infomodel)
                    {
                        _infosDal.Delete(infomodel.IID);
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        var dtatta = _attaListDal.GetList(" IID=" + infomodel.IID, parameters).Tables[0];
                        if (dtatta.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtatta.Rows.Count; i++)
                            {
                                var del = "delete from AttaList where ALID='" + dtatta.Rows[i]["ALID"] +
                                          "'; ";
                                DbCommand dbCommanddel = db.GetSqlStringCommand(del);
                                db.ExecuteNonQuery(dbCommanddel);
                                if (DBNull.Value != dtatta.Rows[i]["AttID"])
                                {
                                    if (!string.IsNullOrEmpty(dtatta.Rows[i]["AttID"].ToString()))
                                    {
                                        if (File.Exists(Server.MapPath("/UploadFiles/" + dtatta.Rows[i]["AttID"])))
                                        {
                                            var fi = new FileInfo(Server.MapPath("/UploadFiles/" + dtatta.Rows[i]["AttID"]));
                                            fi.Delete();
                                        }
                                    }
                                }
                            }
                        }
                        Response.Write("0|~|" + iid);
                        Response.End();
                    }
                }

                #endregion

                var attsql = string.Empty;

                #region 修改热点

                if (!string.IsNullOrEmpty(iid))
                {
                    var infomodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    infomodel.IName = name;
                    infomodel.XPosition = xPosition;
                    infomodel.YPosition = yPosition;
                    infomodel.HotType = Convert.ToInt32(adtype);

                    #region 热点图片/视频

                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var dtatta = _attaListDal.GetList(" IID=" + infomodel.IID, parameters).Tables[0];
                    if (!string.IsNullOrEmpty(batta))
                    {
                        var list = batta.Split(':');
                        foreach (var s in list)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                if (dtatta.Select(" AttID='" + s + "' ").Length <=
                                    0)
                                {
                                    if (File.Exists(ePath + s))
                                    {
                                        var fi = new FileInfo(ePath + s);
                                        fi.MoveTo(Server.MapPath("/UploadFiles/" + s));
                                        attsql += "insert into AttaList(AttID,IID)values (N'" + s + "','" +
                                                  infomodel.IID + "');";
                                    }
                                }
                            }
                        }

                        if (dtatta.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtatta.Rows.Count; i++)
                            {
                                if (!list.Contains(dtatta.Rows[i]["AttID"]))
                                {
                                    var del = "delete from AttaList where ALID='" + dtatta.Rows[i]["ALID"] +
                                              "'; ";
                                    DbCommand dbCommanddel = db.GetSqlStringCommand(del);
                                    db.ExecuteNonQuery(dbCommanddel);
                                    if (DBNull.Value != dtatta.Rows[i]["AttID"])
                                    {
                                        if (!string.IsNullOrEmpty(dtatta.Rows[i]["AttID"].ToString()))
                                        {
                                            if (File.Exists(Server.MapPath("/UploadFiles/" + dtatta.Rows[i]["AttID"])))
                                            {
                                                var fi =
                                                    new FileInfo(
                                                        Server.MapPath("/UploadFiles/" + dtatta.Rows[i]["AttID"]));
                                                fi.Delete();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < dtatta.Rows.Count; i++)
                        {
                            var del = "delete from AttaList where ALID='" + dtatta.Rows[i]["ALID"] +
                                      "'; ";
                            DbCommand comdel = db.GetSqlStringCommand(del);
                            db.ExecuteNonQuery(comdel);
                            if (DBNull.Value != dtatta.Rows[i]["AttID"])
                            {
                                if (!string.IsNullOrEmpty(dtatta.Rows[i]["AttID"].ToString()))
                                {
                                    if (File.Exists(Server.MapPath("/UploadFiles/" + dtatta.Rows[i]["AttID"])))
                                    {
                                        var fi =
                                            new FileInfo(Server.MapPath("/UploadFiles/" + dtatta.Rows[i]["AttID"]));
                                        fi.Delete();
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    #region 热点图标

                    if (!string.IsNullOrEmpty(aatta))
                    {
                        if (aatta != infomodel.ADPic)
                        {
                            if (File.Exists(ePath + aatta))
                            {
                                var fi = new FileInfo(ePath + aatta);
                                fi.MoveTo(Server.MapPath("/UploadFiles/" + aatta));
                                infomodel.ADPic = aatta;
                            }
                        }
                    }
                    else
                    {
                        infomodel.ADPic = "";
                    }

                    #endregion

                    if (!string.IsNullOrEmpty(attsql))
                    {
                        DbCommand dbCommandAtt = db.GetSqlStringCommand(attsql);
                        db.ExecuteNonQuery(dbCommandAtt);
                    }
                    var upres = _infosDal.Update(infomodel);

                    if (upres)
                    {
                        Response.Write("0|~|" + iid);
                        Response.End();
                    }
                    else
                    {
                        Response.Write("1|~|操作失败");
                        Response.End();
                    }
                }
                #endregion

                #region 新增热点

                else
                {
                    var inmodel = new Admin.Model.Infos();
                    inmodel.IName = name;
                    inmodel.Status = 1;
                    inmodel.IType = 5;
                    inmodel.TIID = Convert.ToInt32(tiid);
                    inmodel.XPosition = xPosition;
                    inmodel.YPosition = yPosition;
                    inmodel.SortNum = 1;
                    inmodel.NType = 0;
                    inmodel.HotType = Convert.ToInt32(adtype);
                    if (!string.IsNullOrEmpty(aatta))
                    {
                        if (File.Exists(ePath + aatta))
                        {
                            var fi = new FileInfo(ePath + aatta);
                            fi.MoveTo(Server.MapPath("/UploadFiles/" + aatta));
                            inmodel.ADPic = aatta;
                        }
                    }
                    var aiid = _infosDal.Add(inmodel);
                    if (!string.IsNullOrEmpty(batta))
                    {
                        var labArray = batta.Split(':');
                        foreach (var s in labArray)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                if (File.Exists(ePath + s))
                                {
                                    var fi = new FileInfo(ePath + s);
                                    fi.MoveTo(Server.MapPath("/UploadFiles/" + s));
                                    var ilmodel = new Admin.Model.AttaList();
                                    ilmodel.IID = aiid;
                                    ilmodel.AttID = s;
                                    _attaListDal.Add(ilmodel);
                                }
                            }
                        }
                    }
                    Response.Write("0|~|" + aiid);
                    Response.End();
                }

                #endregion
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ee)
            {
                Response.Write("1|~|" + ee.Message);
                Response.End();
            }
        }

    }

}