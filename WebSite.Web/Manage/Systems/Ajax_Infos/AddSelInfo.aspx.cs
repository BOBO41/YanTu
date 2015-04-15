using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_Infos
{
    public partial class AddSelInfo : UI.WebPage
    {
        private readonly Infos _infosDal = new Infos();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            var iid = Request.QueryString["siid"];
            var tiid = Request.QueryString["tiid"];
            if (!string.IsNullOrEmpty(iid) && !string.IsNullOrEmpty(tiid))
            {
                try
                {
                    var imodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    if (null != imodel)
                    {
                        var timodel = _tempInfoDal.GetModel(Convert.ToInt32(tiid));
                        if (null != timodel)
                        {
                            Database db = DatabaseFactory.CreateDatabase();
                            using (DbConnection conn = db.CreateConnection())
                            {
                                conn.Open();
                                DbTransaction trans = conn.BeginTransaction();
                                try
                                {
                                    AddInfo(db, trans, imodel, Convert.ToInt32(tiid), Convert.ToInt32(timodel.ITID));

                                    trans.Commit();
                                    conn.Close();
                                    Response.Write("0|~|");
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
        private void AddInfo(Database db, DbTransaction trans, Admin.Model.Infos oldinfomodel, int tiid, int itid)
        {
            #region 新增info

            
            var newPicAttaId = "";
            if (!string.IsNullOrEmpty(oldinfomodel.PicAttID))
            {
                var oldbpic = new FileInfo(Server.MapPath("/UploadFiles/" + oldinfomodel.PicAttID));
                newPicAttaId = Guid.NewGuid().ToString();
                if (oldbpic.Exists)
                {
                    if ("C0pY" == oldinfomodel.PicAttID.Substring(0, 4))
                    {
                        newPicAttaId = newPicAttaId + oldinfomodel.PicAttID.Substring(76);
                    }
                    else
                    {
                        newPicAttaId = newPicAttaId + oldinfomodel.PicAttID.Substring(36); ;
                    }
                    oldbpic.CopyTo(Server.MapPath("/UploadFiles/" + newPicAttaId));
                }
                else
                {
                    newPicAttaId = ""; ;
                }
            }
            var newVAttaId = "";
            if (!string.IsNullOrEmpty(oldinfomodel.VideoAttID))
            {
                var oldvideo = new FileInfo(Server.MapPath("/UploadFiles/" + oldinfomodel.VideoAttID));
                newVAttaId = Guid.NewGuid().ToString();
                if (oldvideo.Exists)
                {
                    if ("C0pY" == oldinfomodel.VideoAttID.Substring(0, 4))
                    {
                        newVAttaId = newVAttaId + oldinfomodel.VideoAttID.Substring(76);
                    }
                    else
                    {
                        newVAttaId = newVAttaId + oldinfomodel.VideoAttID.Substring(36); ;
                    }
                    oldvideo.CopyTo(Server.MapPath("/UploadFiles/" + newVAttaId));
                }
                else
                {
                    newVAttaId = "";
                }
            }
            var newadAttaId = "";
            if (!string.IsNullOrEmpty(oldinfomodel.ADPic))
            {
                var oldvideo = new FileInfo(Server.MapPath("/UploadFiles/" + oldinfomodel.ADPic));
                newadAttaId = Guid.NewGuid().ToString();
                if (oldvideo.Exists)
                {
                    if ("C0pY" == oldinfomodel.ADPic.Substring(0, 4))
                    {
                        newadAttaId = newadAttaId + oldinfomodel.ADPic.Substring(76);
                    }
                    else
                    {
                        newadAttaId = newadAttaId + oldinfomodel.ADPic.Substring(36); ;
                    }
                    oldvideo.CopyTo(Server.MapPath("/UploadFiles/" + newadAttaId));
                }
                else
                {
                    newadAttaId = "";
                }
            }
            StringBuilder addinfo = new StringBuilder();
            addinfo.Append("insert into Infos(");
            addinfo.Append(
                "IName,PicAttID,IType,TIID,LID,SortNum,Status,CreateDate,Context,ConPosition,ConColor,ConSize,XPosition,YPosition,VideoAttID,NType,HotType,ADTime,ADPic,ADLink)");

            addinfo.Append(" values (");
            addinfo.Append(
                "@IName,@PicAttID,@IType,@TIID,@LID,@SortNum,@Status,@CreateDate,@Context,@ConPosition,@ConColor,@ConSize,@XPosition,@YPosition,@VideoAttID,@NType,@HotType,@ADTime,@ADPic,@ADLink)");
            addinfo.Append(";select @@IDENTITY");
            DbCommand dbComAddInfo = db.GetSqlStringCommand(addinfo.ToString());
            db.AddInParameter(dbComAddInfo, "IName", DbType.String, oldinfomodel.IName);
            db.AddInParameter(dbComAddInfo, "PicAttID", DbType.String, newPicAttaId);
            db.AddInParameter(dbComAddInfo, "IType", DbType.Int32, oldinfomodel.IType);
            db.AddInParameter(dbComAddInfo, "TIID", DbType.Int32, tiid);
            db.AddInParameter(dbComAddInfo, "LID", DbType.Int32, oldinfomodel.LID);
            db.AddInParameter(dbComAddInfo, "SortNum", DbType.Int32, oldinfomodel.SortNum);
            db.AddInParameter(dbComAddInfo, "Status", DbType.Byte, oldinfomodel.Status);
            db.AddInParameter(dbComAddInfo, "CreateDate", DbType.DateTime, oldinfomodel.CreateDate);
            db.AddInParameter(dbComAddInfo, "Context", DbType.String, oldinfomodel.Context);
            db.AddInParameter(dbComAddInfo, "ConPosition", DbType.String, oldinfomodel.ConPosition);
            db.AddInParameter(dbComAddInfo, "ConColor", DbType.String, oldinfomodel.ConColor);
            db.AddInParameter(dbComAddInfo, "ConSize", DbType.String, oldinfomodel.ConSize);
            db.AddInParameter(dbComAddInfo, "XPosition", DbType.String, oldinfomodel.XPosition);
            db.AddInParameter(dbComAddInfo, "YPosition", DbType.String, oldinfomodel.YPosition);
            db.AddInParameter(dbComAddInfo, "VideoAttID", DbType.String, newVAttaId);
            db.AddInParameter(dbComAddInfo, "NType", DbType.Byte, oldinfomodel.NType);
            db.AddInParameter(dbComAddInfo, "HotType", DbType.Byte, oldinfomodel.HotType);
            db.AddInParameter(dbComAddInfo, "ADTime", DbType.String, oldinfomodel.ADTime);
            db.AddInParameter(dbComAddInfo, "ADPic", DbType.String, newadAttaId);
            db.AddInParameter(dbComAddInfo, "ADLink", DbType.String, oldinfomodel.ADLink);
            object niid = db.ExecuteScalar(dbComAddInfo, trans);

            #endregion

            #region 新增InfoLabel

            var infolabel = "select * from InfoLabel where IID=" + oldinfomodel.IID;
            DbCommand dbComInfoLabel = db.GetSqlStringCommand(infolabel);
            var dtInfoLabel = db.ExecuteDataSet(dbComInfoLabel, trans).Tables[0];
            if (dtInfoLabel.Rows.Count > 0)
            {
                var addinfolabel = "";
                for (int i = 0; i < dtInfoLabel.Rows.Count; i++)
                {
                    addinfolabel += "insert into InfoLabel(IID,ALID) values ('" + niid + "','" +
                                    dtInfoLabel.Rows[i]["ALID"] + "');";
                }
                DbCommand dbComAddInfoLabel = db.GetSqlStringCommand(addinfolabel);
                db.ExecuteNonQuery(dbComAddInfoLabel, trans);
            }

            #endregion

            #region 新增AdInfo

            var adInfo = "select * from AdInfos where IID=" + oldinfomodel.IID;
            DbCommand dbComAdInfo = db.GetSqlStringCommand(adInfo);
            var dtAdInfo = db.ExecuteDataSet(dbComAdInfo, trans).Tables[0];
            if (dtAdInfo.Rows.Count > 0)
            {
                var addAdInfo = "";
                for (int i = 0; i < dtAdInfo.Rows.Count; i++)
                {
                    addAdInfo += "insert into AdInfos(IID,Inf_IID) values ('" + niid + "','" +
                                    dtAdInfo.Rows[i]["Inf_IID"] + "');";
                }
                DbCommand dbComAddAdInfo = db.GetSqlStringCommand(addAdInfo);
                db.ExecuteNonQuery(dbComAddAdInfo, trans);
            }

            #endregion

            #region 新增AttaList

            var attalist = "select * from AttaList where IID=" + oldinfomodel.IID;
            DbCommand dbComAttaList = db.GetSqlStringCommand(attalist);
            var dtAttaList = db.ExecuteDataSet(dbComAttaList, trans).Tables[0];
            if (dtAttaList.Rows.Count > 0)
            {
                var addAttaList = "";
                for (int i = 0; i < dtAttaList.Rows.Count; i++)
                {
                    var newAttaId = "";
                    if ("" != dtAttaList.Rows[i]["AttID"].ToString())
                    {
                        var oldfile = new FileInfo(Server.MapPath("/UploadFiles/" + dtAttaList.Rows[i]["AttID"]));
                        newAttaId = Guid.NewGuid().ToString();
                        if (oldfile.Exists)
                        {
                            if ("C0pY" == dtAttaList.Rows[i]["AttID"].ToString().Substring(0, 4))
                            {
                                newAttaId = newAttaId + dtAttaList.Rows[i]["AttID"].ToString().Substring(76);
                            }
                            else
                            {
                                newAttaId = newAttaId + dtAttaList.Rows[i]["AttID"].ToString().Substring(36); ;
                            }
                            oldfile.CopyTo(Server.MapPath("/UploadFiles/" + newAttaId));
                        }
                        else
                        {
                            newAttaId = "";
                        }
                    }
                    addAttaList += "insert into AttaList(AttID,IID) values (N'" +
                                    newAttaId + "','" + niid + "');";
                }
                DbCommand dbComAddAttaList = db.GetSqlStringCommand(addAttaList);
                db.ExecuteNonQuery(dbComAddAttaList, trans);
            }

            #endregion

            #region 新增TemplateInfo

            var templatesql = "select * from TempInfo where ParentID=" + oldinfomodel.IID;
            DbCommand dbComTemplate = db.GetSqlStringCommand(templatesql);
            var dt = db.ExecuteDataSet(dbComTemplate, trans).Tables[0];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var addTempInfo = "";
                    var attidbp = dt.Rows[i]["AttID"];
                    var newAttaId = "";
                    if (DBNull.Value != attidbp)
                    {
                        if (!string.IsNullOrEmpty(attidbp.ToString()))
                        {
                            var oldfile = new FileInfo(Server.MapPath("/UploadFiles/" + attidbp));
                            
                            if (oldfile.Exists)
                            {
                                newAttaId = Guid.NewGuid().ToString();
                                if ("C0pY" == attidbp.ToString().Substring(0, 4))
                                {
                                    newAttaId = newAttaId + attidbp.ToString().Substring(76);
                                }
                                else
                                {
                                    newAttaId = newAttaId + attidbp.ToString().Substring(36); ;
                                }
                                oldfile.CopyTo(Server.MapPath("/UploadFiles/" + newAttaId));
                            }
                        }
                    }
                    if (dt.Rows[i]["TIPage"] == DBNull.Value)
                    {
                        addTempInfo = "insert into TempInfo(ITID,TID,ParentID,AttID) values ('" + itid +
                                      "','" + dt.Rows[i]["TID"] + "','" + niid + "',N'" + newAttaId + "');select @@IDENTITY";
                    }
                    else
                    {
                        addTempInfo = "insert into TempInfo(ITID,TID,TIPage,ParentID,AttID) values ('" + itid +
                                     "','" + dt.Rows[i]["TID"] + "','" + dt.Rows[i]["TIPage"] + "','" + niid +
                                     "',N'" + newAttaId + "');select @@IDENTITY";
                    }

                    DbCommand dbComAddTempInfo = db.GetSqlStringCommand(addTempInfo);
                    var ntiid = db.ExecuteScalar(dbComAddTempInfo, trans);

                    var infos = "select * from Infos where TIID=" + dt.Rows[i]["TIID"];
                    DbCommand dbComInfos = db.GetSqlStringCommand(infos);
                    var dtInfos = db.ExecuteDataSet(dbComInfos, trans).Tables[0];
                    if (dtInfos.Rows.Count > 0)
                    {
                        foreach (DataRow dataRow in dtInfos.Rows)
                        {
                            var imodel = _infosDal.DataRowToModel(dataRow);
                            AddInfo(db, trans, imodel, Convert.ToInt32(ntiid), itid);
                        }
                    }
                }
            }

            #endregion
        }
    }
}