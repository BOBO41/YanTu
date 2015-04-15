using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_Infos
{
    public partial class AddFirstInfo : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Infos _infosDal = new Infos();
        private readonly InfoLabel _infoLabelDal = new InfoLabel();
        private readonly AttaList _attaListDal = new AttaList();
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
                var vatta = HttpUtility.UrlDecode(Request.QueryString["vatta"]);
                var tiid = Request.QueryString["tiid"];
                var itype = Request.QueryString["itype"];
                var name = HttpUtility.UrlDecode(Request.QueryString["name"]);
                var iid = Request.QueryString["iid"];
                var labs = Request.QueryString["labs"];
                var ntype = Request.QueryString["ntype"];
                var adpause = HttpUtility.UrlDecode(Request.QueryString["adpause"]);
                var pausetime = Request.QueryString["pausetime"];
                var adpausepic = HttpUtility.UrlDecode(Request.QueryString["adpausepic"]);
                var adpauseid = Request.QueryString["adpauseid"];
                var adpausepicid = Request.QueryString["adpausepicid"];
                if (!string.IsNullOrEmpty(itid))
                {
                    var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                    if (null != itmodel)
                    {
                        #region 修改info

                        if (!string.IsNullOrEmpty(iid))
                        {
                            Database db = DatabaseFactory.CreateDatabase();
                            using (DbConnection conn = db.CreateConnection())
                            {
                                conn.Open();
                                DbTransaction trans = conn.BeginTransaction();
                                try
                                {
                                    var infomodel = _infosDal.GetModel(Convert.ToInt32(iid));
                                    infomodel.IName = name;
                                    infomodel.NType = Convert.ToInt32(ntype);
                                    infomodel.ADTime = pausetime;
                                    #region 背景图片

                                    if (batta != infomodel.PicAttID)
                                    {
                                        var fi = new FileInfo(ePath + batta);
                                        if (fi.Exists)
                                        {
                                            fi.MoveTo(Server.MapPath("/UploadFiles/" + batta));
                                            if (!string.IsNullOrEmpty(infomodel.PicAttID))
                                            {
                                                var ofi =
                                                    new FileInfo(Server.MapPath("/UploadFiles/" + infomodel.PicAttID));
                                                if (ofi.Exists)
                                                {
                                                    ofi.Delete();
                                                }
                                            }
                                            infomodel.PicAttID = batta;
                                        }
                                    }

                                    #endregion

                                    if ("2" == itype)
                                    {
                                        #region 内容视频

                                        if (vatta != infomodel.VideoAttID)
                                        {
                                            var fi = new FileInfo(ePath + vatta);
                                            if (fi.Exists)
                                            {
                                                fi.MoveTo(Server.MapPath("/UploadFiles/" + vatta));
                                                if (!string.IsNullOrEmpty(infomodel.VideoAttID))
                                                {
                                                    var ofi =
                                                        new FileInfo(
                                                            Server.MapPath("/UploadFiles/" + infomodel.VideoAttID));
                                                    if (ofi.Exists)
                                                    {
                                                        ofi.Delete();
                                                    }
                                                }
                                                infomodel.VideoAttID = vatta;
                                            }
                                        }

                                        #endregion

                                        #region 广告图片

                                        if (!string.IsNullOrEmpty(adpausepic) && "undefined" != adpausepic)
                                        {
                                            if (infomodel.ADPic != adpausepic)
                                            {
                                                var vfi = new FileInfo(ePath + adpausepic);
                                                if (vfi.Exists)
                                                {
                                                    vfi.MoveTo(Server.MapPath("/UploadFiles/" + adpausepic));
                                                    infomodel.ADPic = adpausepic;
                                                }
                                            }
                                        }

                                        infomodel.ADLink = adpausepicid;

                                        #endregion

                                        #region 修改广告视频

                                        List<SqlParameter> parameters = new List<SqlParameter>();
                                        var dtatta = _attaListDal.GetList(" IID=" + infomodel.IID, parameters).Tables[0];
                                        if (!string.IsNullOrEmpty(adpause))
                                        {
                                            var advArray = adpause.Split(':');
                                            var addadvList = "";
                                            var advidarray = adpauseid.Split(':');
                                            for (int i = 0; i < advArray.Length; i++)
                                            {
                                                if (!string.IsNullOrEmpty(advArray[i]))
                                                {
                                                    var dr = dtatta.Select(" AttID='" + advArray[i] + "' ");
                                                    if (dr.Length <= 0)
                                                    {
                                                        var vfi = new FileInfo(ePath + advArray[i]);
                                                        if (vfi.Exists)
                                                        {
                                                            vfi.MoveTo(Server.MapPath("/UploadFiles/" + advArray[i]));
                                                            addadvList +=
                                                                "insert into AttaList(AttID,IID,AD_IID) values (N'" +
                                                                advArray[i] + "','" +
                                                                infomodel.IID + "','" + advidarray[i] + "');";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (advidarray[i] != dr[0]["AD_IID"].ToString())
                                                        {
                                                            addadvList += "update AttaList set AD_IID='" + advidarray[i] + "' where ALID='" + dr[0]["ALID"] + "';";
                                                        }
                                                    }
                                                }
                                            }
                                            if (!string.IsNullOrEmpty(addadvList))
                                            {
                                                DbCommand dbComAddadvList = db.GetSqlStringCommand(addadvList);
                                                db.ExecuteNonQuery(dbComAddadvList, trans);
                                            }

                                            if (dtatta.Rows.Count > 0)
                                            {
                                                for (int i = 0; i < dtatta.Rows.Count; i++)
                                                {
                                                    if (!advArray.Contains(dtatta.Rows[i]["AttID"]))
                                                    {
                                                        var del = "delete from AttaList where ALID='" +
                                                                  dtatta.Rows[i]["ALID"] +
                                                                  "'; ";
                                                        DbCommand dbCommanddel = db.GetSqlStringCommand(del);
                                                        db.ExecuteNonQuery(dbCommanddel, trans);
                                                        if (DBNull.Value != dtatta.Rows[i]["AttID"])
                                                        {
                                                            if (!string.IsNullOrEmpty(dtatta.Rows[i]["AttID"].ToString()))
                                                            {
                                                                if (File.Exists(Server.MapPath("/UploadFiles/" + dtatta.Rows[i]["AttID"])))
                                                                {
                                                                    var fi =
                                                                        new FileInfo(
                                                                            Server.MapPath("/UploadFiles/" +
                                                                                           dtatta.Rows[i]["AttID"]));
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
                                                db.ExecuteNonQuery(comdel, trans);
                                                if (DBNull.Value != dtatta.Rows[i]["AttID"])
                                                {
                                                    if (!string.IsNullOrEmpty(dtatta.Rows[i]["AttID"].ToString()))
                                                    {
                                                        if (
                                                            File.Exists(
                                                                Server.MapPath("/UploadFiles/" + dtatta.Rows[i]["AttID"])))
                                                        {
                                                            var fi =
                                                                new FileInfo(
                                                                    Server.MapPath("/UploadFiles/" +
                                                                                   dtatta.Rows[i]["AttID"]));
                                                            fi.Delete();
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        #endregion
                                    }

                                    #region 更新info

                                    StringBuilder strSqlUpdate = new StringBuilder();
                                    strSqlUpdate.Append("update Infos set ");
                                    strSqlUpdate.Append("IName=@IName,");
                                    strSqlUpdate.Append("PicAttID=@PicAttID,");
                                    strSqlUpdate.Append("VideoAttID=@VideoAttID,");
                                    strSqlUpdate.Append("NType=@NType,");
                                    strSqlUpdate.Append("ADTime=@ADTime,");
                                    strSqlUpdate.Append("ADPic=@ADPic,");
                                    strSqlUpdate.Append("ADLink=@ADLink");
                                    strSqlUpdate.Append(" where IID=@IID ");
                                    DbCommand dbCommandUpdate = db.GetSqlStringCommand(strSqlUpdate.ToString());
                                    db.AddInParameter(dbCommandUpdate, "IID", DbType.Int32, infomodel.IID);
                                    db.AddInParameter(dbCommandUpdate, "IName", DbType.String, infomodel.IName);
                                    db.AddInParameter(dbCommandUpdate, "PicAttID", DbType.String, infomodel.PicAttID);
                                    db.AddInParameter(dbCommandUpdate, "VideoAttID", DbType.String, infomodel.VideoAttID);
                                    db.AddInParameter(dbCommandUpdate, "NType", DbType.Byte, infomodel.NType);
                                    db.AddInParameter(dbCommandUpdate, "ADTime", DbType.String, infomodel.ADTime);
                                    db.AddInParameter(dbCommandUpdate, "ADPic", DbType.String, infomodel.ADPic);
                                    db.AddInParameter(dbCommandUpdate, "ADLink", DbType.String, infomodel.ADLink);
                                    db.ExecuteNonQuery(dbCommandUpdate);

                                    #endregion

                                    var dellab = "delete from InfoLabel where IID=" + infomodel.IID;
                                    DbCommand dbCommand = db.GetSqlStringCommand(dellab);
                                    db.ExecuteNonQuery(dbCommand, trans);
                                    if (!string.IsNullOrEmpty(labs))
                                    {
                                        StringBuilder strSqlAddLab = new StringBuilder();
                                        var labArray = labs.Split(',');
                                        foreach (var alid in labArray)
                                        {
                                            if (!string.IsNullOrEmpty(alid))
                                            {
                                                strSqlAddLab.Append("insert into InfoLabel(");
                                                strSqlAddLab.Append("IID,ALID)");
                                                strSqlAddLab.Append(" values (");
                                                strSqlAddLab.Append("'" + infomodel.IID + "','" + alid + "')");
                                            }
                                        }
                                        if (!string.IsNullOrEmpty(strSqlAddLab.ToString()))
                                        {
                                            DbCommand dbCommandAddLab = db.GetSqlStringCommand(strSqlAddLab.ToString());
                                            db.ExecuteNonQuery(dbCommandAddLab, trans);
                                        }
                                    }

                                    trans.Commit();
                                    conn.Close();
                                    Response.Write("0|~|" + infomodel.IID);
                                    Response.End();
                                }
                                catch (System.Threading.ThreadAbortException ex)
                                {
                                }
                                catch (Exception ee)
                                {
                                    trans.Rollback();
                                    conn.Close();
                                    Response.Write("1|~|" + ee.Message);
                                    Response.End();
                                }
                            }
                        }
                        #endregion

                        #region 新增info

                        else
                        {
                            var sql = " TIID='" + tiid + "' and SortNum='" + sortnum + "' ";
                            var exit = _infosDal.GetModel(sql, new List<SqlParameter>());
                            if (null != exit)
                            {
                                Response.Write("1|~|操作失败");
                                Response.End();
                            }
                            Database db = DatabaseFactory.CreateDatabase();
                            using (DbConnection conn = db.CreateConnection())
                            {
                                conn.Open();
                                DbTransaction trans = conn.BeginTransaction();
                                try
                                {
                                    #region 新增info

                                    var picattid = "";
                                    var fi = new FileInfo(ePath + batta);
                                    if (fi.Exists)
                                    {
                                        fi.MoveTo(Server.MapPath("/UploadFiles/" + batta));
                                        picattid = batta;
                                    }
                                    var videoatta = "";
                                    if (!string.IsNullOrEmpty(vatta))
                                    {
                                        var vfi = new FileInfo(ePath + vatta);
                                        if (vfi.Exists)
                                        {
                                            vfi.MoveTo(Server.MapPath("/UploadFiles/" + vatta));
                                            videoatta = vatta;
                                        }
                                    }
                                    var papic = "";
                                    if (!string.IsNullOrEmpty(adpausepic) && "undefined" != adpausepic)
                                    {
                                        var vfi = new FileInfo(ePath + adpausepic);
                                        if (vfi.Exists)
                                        {
                                            vfi.MoveTo(Server.MapPath("/UploadFiles/" + adpausepic));
                                            papic = adpausepic;
                                        }
                                    }
                                    var papicid = "";
                                    if (!string.IsNullOrEmpty(adpausepicid) && "undefined" != adpausepicid)
                                    {
                                        papicid = adpausepicid;
                                    }
                                    StringBuilder addinfo = new StringBuilder();
                                    addinfo.Append("insert into Infos(");
                                    addinfo.Append(
                                        "IName,PicAttID,IType,TIID,SortNum,Status,VideoAttID,NType,ADTime,ADPic,ADLink)");

                                    addinfo.Append(" values (");
                                    addinfo.Append(
                                        "@IName,@PicAttID,@IType,@TIID,@SortNum,@Status,@VideoAttID,@NType,@ADTime,@ADPic,@ADLink)");
                                    addinfo.Append(";select @@IDENTITY");
                                    DbCommand dbComAddInfo = db.GetSqlStringCommand(addinfo.ToString());
                                    db.AddInParameter(dbComAddInfo, "IName", DbType.String, name);
                                    db.AddInParameter(dbComAddInfo, "PicAttID", DbType.String, picattid);
                                    db.AddInParameter(dbComAddInfo, "IType", DbType.Int32, itype);
                                    db.AddInParameter(dbComAddInfo, "TIID", DbType.Int32, tiid);
                                    db.AddInParameter(dbComAddInfo, "SortNum", DbType.Int32, sortnum);
                                    db.AddInParameter(dbComAddInfo, "Status", DbType.Byte, 1);
                                    db.AddInParameter(dbComAddInfo, "VideoAttID", DbType.String, videoatta);
                                    db.AddInParameter(dbComAddInfo, "NType", DbType.Byte, ntype);
                                    db.AddInParameter(dbComAddInfo, "ADTime", DbType.String, pausetime);
                                    db.AddInParameter(dbComAddInfo, "ADPic", DbType.String, papic);
                                    db.AddInParameter(dbComAddInfo, "ADLink", DbType.String, papicid);
                                    object niid = db.ExecuteScalar(dbComAddInfo, trans);

                                    #endregion

                                    #region 新增lab

                                    if (!string.IsNullOrEmpty(labs))
                                    {
                                        var labArray = labs.Split(',');
                                        var addlabList = "";
                                        foreach (var s in labArray)
                                        {
                                            if (!string.IsNullOrEmpty(s))
                                            {
                                                addlabList += "insert into InfoLabel(IID,ALID) values ('" +
                                                              niid + "','" + s + "');";
                                            }
                                        }
                                        DbCommand dbComAddlabList = db.GetSqlStringCommand(addlabList);
                                        db.ExecuteNonQuery(dbComAddlabList, trans);
                                    }

                                    #endregion

                                    #region 新增广告视频

                                    if (!string.IsNullOrEmpty(adpause))
                                    {
                                        var advArray = adpause.Split(':');
                                        var addadvList = "";
                                        var advidarray = adpauseid.Split(':');
                                        for (int i = 0; i < advArray.Length; i++)
                                        {
                                            if (!string.IsNullOrEmpty(advArray[i]))
                                            {
                                                var vfi = new FileInfo(ePath + advArray[i]);
                                                if (vfi.Exists)
                                                {
                                                    vfi.MoveTo(Server.MapPath("/UploadFiles/" + advArray[i]));
                                                    addadvList += "insert into AttaList(AttID,IID,AD_IID) values (N'" + advArray[i] + "','" +
                                                              niid + "','" + advidarray[i] + "');";
                                                }
                                            }
                                        }
                                        DbCommand dbComAddadvList = db.GetSqlStringCommand(addadvList);
                                        db.ExecuteNonQuery(dbComAddadvList, trans);
                                    }

                                    #endregion
                                    trans.Commit();
                                    conn.Close();
                                    Response.Write("0|~|" + niid);
                                    Response.End();
                                }
                                catch (System.Threading.ThreadAbortException ex)
                                {
                                }
                                catch (Exception ee)
                                {
                                    trans.Rollback();
                                    conn.Close();
                                    Response.Write("1|~|" + ee.Message);
                                    Response.End();
                                }
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        Response.Write("1|~|操作失败");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("1|~|操作失败");
                    Response.End();
                }
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