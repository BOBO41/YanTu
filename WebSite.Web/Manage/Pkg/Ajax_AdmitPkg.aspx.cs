using System;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Pkg
{
    public partial class Ajax_AdmitPkg : UI.WebPage
    {
        private readonly OrgPkgList _orgPkgList = new OrgPkgList();
        private readonly Infos _infosDal = new Infos();
        private readonly StaPackage _staPackageDal = new StaPackage();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                var sspid = Request.QueryString["SSPID"];
                var type = Request.QueryString["type"];
                if (!string.IsNullOrEmpty(sspid) && !string.IsNullOrEmpty(type))
                {
                    var oplmodel = _orgPkgList.GetModel(Convert.ToInt32(sspid));
                    if (null != oplmodel)
                    {
                        #region 通过

                        if ("1" == type)
                        {
                            oplmodel.Status = 1;
                            _orgPkgList.Update(oplmodel);
                            var spmodel = _staPackageDal.GetModel(Convert.ToInt32(oplmodel.SPID));
                            spmodel.Status = 1;
                            _staPackageDal.Update(spmodel);
                            Response.Write("0|~|操作成功");
                            Response.End();
                        }

                        #endregion

                        #region 退回

                        if ("2" == type)
                        {
                            var spmodel = _staPackageDal.GetModel(Convert.ToInt32(oplmodel.SPID));
                            if (null != spmodel)
                            {
                                Database db = DatabaseFactory.CreateDatabase();
                                using (DbConnection conn = db.CreateConnection())
                                {
                                    conn.Open();
                                    DbTransaction trans = conn.BeginTransaction();
                                    try
                                    {
                                        #region 新增spkg

                                        StringBuilder strSql = new StringBuilder();
                                        strSql.Append("insert into StaPackage(");
                                        strSql.Append("RPID,OrgId,SPPath,Status,CreateDate,PkgType)");

                                        strSql.Append(" values (");
                                        strSql.Append("@RPID,@OrgId,@SPPath,@Status,@CreateDate,@PkgType)");
                                        strSql.Append(";select @@IDENTITY");
                                        DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                                        db.AddInParameter(dbCommand, "RPID", DbType.Int32, spmodel.RPID);
                                        db.AddInParameter(dbCommand, "OrgId", DbType.Int32, spmodel.OrgId);
                                        db.AddInParameter(dbCommand, "SPPath", DbType.String, Guid.NewGuid().ToString());
                                        db.AddInParameter(dbCommand, "Status", DbType.Byte, 4);
                                        db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, DateTime.Now);
                                        db.AddInParameter(dbCommand, "PkgType", DbType.Byte, 1);
                                        object nspid = db.ExecuteScalar(dbCommand, trans);

                                        #endregion

                                        #region 查找复制分类

                                        StringBuilder strSqlitype = new StringBuilder();
                                        strSqlitype.Append("select ITID,IName,SPID,AttaID,SortNum,Status ");
                                        strSqlitype.Append(" FROM InfoType where SPID=" + spmodel.SPID);
                                        DbCommand dbCommanditype = db.GetSqlStringCommand(strSqlitype.ToString());

                                        var itypedt = db.ExecuteDataSet(dbCommanditype, trans).Tables[0];
                                        if (itypedt.Rows.Count > 0)
                                        {
                                            for (int i = 0; i < itypedt.Rows.Count; i++)
                                            {
                                                #region 复制分类

                                                StringBuilder strSqlNtype = new StringBuilder();
                                                strSqlNtype.Append("insert into InfoType(");
                                                strSqlNtype.Append("IName,SPID,AttaID,SortNum,Status)");

                                                strSqlNtype.Append(" values (");
                                                strSqlNtype.Append("@IName,@SPID,@AttaID,@SortNum,@Status)");
                                                strSqlNtype.Append(";select @@IDENTITY");
                                                DbCommand dbCommandntype = db.GetSqlStringCommand(strSqlNtype.ToString());
                                                db.AddInParameter(dbCommandntype, "IName", DbType.String,
                                                    itypedt.Rows[i]["IName"]);
                                                db.AddInParameter(dbCommandntype, "SPID", DbType.Int32, nspid);
                                                db.AddInParameter(dbCommandntype, "AttaID", DbType.String,
                                                    itypedt.Rows[i]["AttaID"]);
                                                db.AddInParameter(dbCommandntype, "SortNum", DbType.Int32,
                                                    itypedt.Rows[i]["SortNum"]);
                                                db.AddInParameter(dbCommandntype, "Status", DbType.Byte,
                                                    itypedt.Rows[i]["Status"]);
                                                object ntypeId = db.ExecuteScalar(dbCommandntype, trans);


                                                #endregion

                                                #region 查找复制templateinfo

                                                StringBuilder strSqlim = new StringBuilder();
                                                strSqlim.Append("select TIID,ITID,TID,AttID,TIPage,ParentID ");
                                                strSqlim.Append(" FROM TempInfo where ParentID=0 and ITID=" + itypedt.Rows[i]["ITID"]);
                                                DbCommand dbCommandim = db.GetSqlStringCommand(strSqlim.ToString());

                                                var imdt = db.ExecuteDataSet(dbCommandim, trans).Tables[0];
                                                if (imdt.Rows.Count > 0)
                                                {
                                                    for (int j = 0; j < imdt.Rows.Count; j++)
                                                    {
                                                        #region 复制tempinfo

                                                        var newti = "";
                                                        if (DBNull.Value != imdt.Rows[j]["AttID"])
                                                        {
                                                            if (!string.IsNullOrEmpty(imdt.Rows[j]["AttID"].ToString()))
                                                            {
                                                                var oldti =
                                                            new FileInfo(
                                                                Server.MapPath("/UploadFiles/" + imdt.Rows[j]["AttID"]));
                                                                if (oldti.Exists)
                                                                {
                                                                    //newti = Guid.NewGuid() +
                                                                    //        imdt.Rows[j]["AttID"].ToString().Substring(36);
                                                                    //oldti.CopyTo(Server.MapPath("/UploadFiles/" + newti));

                                                                    newti = Guid.NewGuid().ToString();
                                                                    if ("C0pY" == imdt.Rows[j]["AttID"].ToString().Substring(0, 4))
                                                                    {
                                                                        newti = "C0pY" + newti + imdt.Rows[j]["AttID"].ToString().Substring(40);
                                                                    }
                                                                    else
                                                                    {
                                                                        newti = "C0pY" + newti + imdt.Rows[j]["AttID"].ToString();
                                                                    }
                                                                    oldti.CopyTo(Server.MapPath("/UploadFiles/" + newti));
                                                                }
                                                            }
                                                        }

                                                        StringBuilder strSqlti = new StringBuilder();
                                                        strSqlti.Append("insert into TempInfo(");
                                                        strSqlti.Append("ITID,TID,AttID,TIPage,ParentID)");

                                                        strSqlti.Append(" values (");
                                                        strSqlti.Append("@ITID,@TID,@AttID,@TIPage,@ParentID)");
                                                        strSqlti.Append(";select @@IDENTITY");
                                                        DbCommand dbCommandti =
                                                            db.GetSqlStringCommand(strSqlti.ToString());
                                                        db.AddInParameter(dbCommandti, "ITID", DbType.Int32,
                                                            ntypeId);
                                                        db.AddInParameter(dbCommandti, "TID", DbType.Int32,
                                                            imdt.Rows[j]["TID"]);
                                                        db.AddInParameter(dbCommandti, "AttID", DbType.String, newti);
                                                        db.AddInParameter(dbCommandti, "TIPage", DbType.Int32,
                                                            imdt.Rows[j]["TIPage"]);
                                                        db.AddInParameter(dbCommandti, "ParentID", DbType.Int32,
                                                            imdt.Rows[j]["ParentID"]);
                                                        object ntiid = db.ExecuteScalar(dbCommandti, trans);

                                                        #endregion

                                                        #region 复制info

                                                        StringBuilder strSqlii = new StringBuilder();
                                                        strSqlii.Append(
                                                            "select Infos.* from Infos where Infos.TIID=" +
                                                            imdt.Rows[j]["TIID"]);
                                                        DbCommand dbCommandii =
                                                            db.GetSqlStringCommand(strSqlii.ToString());

                                                        var iidt = db.ExecuteDataSet(dbCommandii, trans).Tables[0];
                                                        if (iidt.Rows.Count > 0)
                                                        {
                                                            foreach (DataRow dataRow in iidt.Rows)
                                                            {
                                                                var imodel = _infosDal.DataRowToModel(dataRow);
                                                                AddInfo(db, trans, imodel, Convert.ToInt32(ntiid), Convert.ToInt32(ntypeId));

                                                                #region 增加TmpInfoList

                                                                //StringBuilder strSqltil = new StringBuilder();
                                                                //strSqltil.Append("insert into TmpInfoList(");
                                                                //strSqltil.Append("IID,TIID)");

                                                                //strSqltil.Append(" values (");
                                                                //strSqltil.Append("@IID,@TIID)");
                                                                //strSqltil.Append(";select @@IDENTITY");
                                                                //DbCommand dbCommandtil =
                                                                //    db.GetSqlStringCommand(strSqltil.ToString());
                                                                //db.AddInParameter(dbCommandtil, "IID", DbType.Int32,
                                                                //    niid);
                                                                //db.AddInParameter(dbCommandtil, "TIID", DbType.Int32,
                                                                //    ntiid);
                                                                //object obj = db.ExecuteScalar(dbCommandtil, trans);

                                                                #endregion

                                                            }
                                                        }

                                                        #endregion
                                                    }
                                                }

                                                #endregion
                                            }
                                        }

                                        #endregion

                                        #region 新spkg和org关联

                                        StringBuilder strSqlopl = new StringBuilder();
                                        strSqlopl.Append("insert into OrgPkgList(");
                                        strSqlopl.Append("SPID,OrgId,OSPID,Status,CreateDate,RPID)");

                                        strSqlopl.Append(" values (");
                                        strSqlopl.Append("@SPID,@OrgId,@OSPID,@Status,@CreateDate,@RPID)");
                                        strSqlopl.Append(";select @@IDENTITY");
                                        DbCommand dbCommandopl = db.GetSqlStringCommand(strSqlopl.ToString());
                                        db.AddInParameter(dbCommandopl, "SPID", DbType.Int32, nspid);
                                        db.AddInParameter(dbCommandopl, "OrgId", DbType.Int32, oplmodel.OrgId);
                                        db.AddInParameter(dbCommandopl, "OSPID", DbType.Int32, oplmodel.SPID);
                                        db.AddInParameter(dbCommandopl, "Status", DbType.Byte, 2);
                                        db.AddInParameter(dbCommandopl, "CreateDate", DbType.DateTime, DateTime.Now);
                                        db.AddInParameter(dbCommandopl, "RPID", DbType.Int32, oplmodel.RPID);
                                        object nsspid = db.ExecuteScalar(dbCommandopl, trans);

                                        #endregion

                                        #region 删除原关联关系

                                        StringBuilder strSqldel = new StringBuilder();
                                        strSqldel.Append("delete from OrgPkgList ");
                                        strSqldel.Append(" where SSPID=@SSPID ");
                                        DbCommand dbCommanddel = db.GetSqlStringCommand(strSqldel.ToString());
                                        db.AddInParameter(dbCommanddel, "SSPID", DbType.Int32, oplmodel.SSPID);
                                        int rows = db.ExecuteNonQuery(dbCommanddel);

                                        #endregion

                                        trans.Commit();
                                        conn.Close();
                                        Response.Write("0|~|");
                                        Response.End();
                                    }
                                    catch (ThreadAbortException ex)
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

                        #endregion
                    }
                    else
                    {
                        Response.Write("1|~|分站资源包错误");
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

        //private object AddInfo(Database db, DbTransaction trans, Admin.Model.Infos oldinfomodel, int tiid, int itid)
        //{
        //    #region 新增info

        //    var oldbpic = new FileInfo(Server.MapPath("/UploadFiles/" + oldinfomodel.PicAttID));
        //    var newPicAttaId = "";
        //    if ("" != oldinfomodel.PicAttID && oldbpic.Exists)
        //    {
        //        newPicAttaId = Guid.NewGuid().ToString();
        //        newPicAttaId = newPicAttaId + oldinfomodel.PicAttID.Substring(36);
        //        oldbpic.CopyTo(Server.MapPath("/UploadFiles/" + newPicAttaId));
        //    }
        //    var newVAttaId = "";
        //    if (!string.IsNullOrEmpty(oldinfomodel.VideoAttID))
        //    {
        //        var oldvideo = new FileInfo(Server.MapPath("/UploadFiles/" + oldinfomodel.VideoAttID));
        //        newVAttaId = Guid.NewGuid().ToString();
        //        if (oldvideo.Exists)
        //        {
        //            newVAttaId = newVAttaId + oldinfomodel.VideoAttID.Substring(36);
        //            oldvideo.CopyTo(Server.MapPath("/UploadFiles/" + newVAttaId));
        //        }
        //        else
        //        {
        //            newVAttaId = oldinfomodel.VideoAttID;
        //        }
        //    }
        //    StringBuilder addinfo = new StringBuilder();
        //    addinfo.Append("insert into Infos(");
        //    addinfo.Append(
        //        "IName,PicAttID,IType,TIID,LID,SortNum,Status,CreateDate,Context,ConPosition,ConColor,ConSize,XPosition,YPosition,VideoAttID)");

        //    addinfo.Append(" values (");
        //    addinfo.Append(
        //        "@IName,@PicAttID,@IType,@TIID,@LID,@SortNum,@Status,@CreateDate,@Context,@ConPosition,@ConColor,@ConSize,@XPosition,@YPosition,@VideoAttID)");
        //    addinfo.Append(";select @@IDENTITY");
        //    DbCommand dbComAddInfo = db.GetSqlStringCommand(addinfo.ToString());
        //    db.AddInParameter(dbComAddInfo, "IName", DbType.String, oldinfomodel.IName);
        //    db.AddInParameter(dbComAddInfo, "PicAttID", DbType.String, newPicAttaId);
        //    db.AddInParameter(dbComAddInfo, "IType", DbType.Int32, oldinfomodel.IType);
        //    db.AddInParameter(dbComAddInfo, "TIID", DbType.Int32, tiid);
        //    db.AddInParameter(dbComAddInfo, "LID", DbType.Int32, oldinfomodel.LID);
        //    db.AddInParameter(dbComAddInfo, "SortNum", DbType.Int32, oldinfomodel.SortNum);
        //    db.AddInParameter(dbComAddInfo, "Status", DbType.Byte, oldinfomodel.Status);
        //    db.AddInParameter(dbComAddInfo, "CreateDate", DbType.DateTime, oldinfomodel.CreateDate);
        //    db.AddInParameter(dbComAddInfo, "Context", DbType.String, oldinfomodel.Context);
        //    db.AddInParameter(dbComAddInfo, "ConPosition", DbType.String, oldinfomodel.ConPosition);
        //    db.AddInParameter(dbComAddInfo, "ConColor", DbType.String, oldinfomodel.ConColor);
        //    db.AddInParameter(dbComAddInfo, "ConSize", DbType.String, oldinfomodel.ConSize);
        //    db.AddInParameter(dbComAddInfo, "XPosition", DbType.String, oldinfomodel.XPosition);
        //    db.AddInParameter(dbComAddInfo, "YPosition", DbType.String, oldinfomodel.YPosition);
        //    db.AddInParameter(dbComAddInfo, "VideoAttID", DbType.String, newVAttaId);
        //    object niid = db.ExecuteScalar(dbComAddInfo, trans);

        //    #endregion

        //    #region 新增InfoLabel

        //    var infolabel = "select * from InfoLabel where IID=" + oldinfomodel.IID;
        //    DbCommand dbComInfoLabel = db.GetSqlStringCommand(infolabel);
        //    var dtInfoLabel = db.ExecuteDataSet(dbComInfoLabel, trans).Tables[0];
        //    if (dtInfoLabel.Rows.Count > 0)
        //    {
        //        var addinfolabel = "";
        //        for (int i = 0; i < dtInfoLabel.Rows.Count; i++)
        //        {
        //            addinfolabel += "insert into InfoLabel(IID,ALID) values ('" + niid + "','" +
        //                            dtInfoLabel.Rows[i]["ALID"] + "');";
        //        }
        //        DbCommand dbComAddInfoLabel = db.GetSqlStringCommand(addinfolabel);
        //        db.ExecuteNonQuery(dbComAddInfoLabel, trans);
        //    }

        //    #endregion

        //    #region 新增AdInfo

        //    var adInfo = "select * from AdInfos where IID=" + oldinfomodel.IID;
        //    DbCommand dbComAdInfo = db.GetSqlStringCommand(adInfo);
        //    var dtAdInfo = db.ExecuteDataSet(dbComAdInfo, trans).Tables[0];
        //    if (dtAdInfo.Rows.Count > 0)
        //    {
        //        var addAdInfo = "";
        //        for (int i = 0; i < dtAdInfo.Rows.Count; i++)
        //        {
        //            addAdInfo += "insert into AdInfos(IID,Inf_IID) values ('" + niid + "','" +
        //                            dtAdInfo.Rows[i]["Inf_IID"] + "');";
        //        }
        //        DbCommand dbComAddAdInfo = db.GetSqlStringCommand(addAdInfo);
        //        db.ExecuteNonQuery(dbComAddAdInfo, trans);
        //    }

        //    #endregion

        //    #region 新增AttaList

        //    var attalist = "select * from AttaList where IID=" + oldinfomodel.IID;
        //    DbCommand dbComAttaList = db.GetSqlStringCommand(attalist);
        //    var dtAttaList = db.ExecuteDataSet(dbComAttaList, trans).Tables[0];
        //    if (dtAttaList.Rows.Count > 0)
        //    {
        //        var addAttaList = "";
        //        for (int i = 0; i < dtAttaList.Rows.Count; i++)
        //        {
        //            var oldfile = new FileInfo(Server.MapPath("/UploadFiles/" + dtAttaList.Rows[i]["AttID"]));
        //            var newAttaId = "";
        //            if ("" != dtAttaList.Rows[i]["AttID"].ToString() && oldfile.Exists)
        //            {
        //                newAttaId = Guid.NewGuid().ToString();
        //                newAttaId = newAttaId + dtAttaList.Rows[i]["AttID"].ToString().Substring(36);
        //                oldfile.CopyTo(Server.MapPath("/UploadFiles/" + newAttaId));
        //            }
        //            addAttaList += "insert into AttaList(AttID,IID) values ('" +
        //                            newAttaId + "','" + niid + "');";
        //        }
        //        DbCommand dbComAddAttaList = db.GetSqlStringCommand(addAttaList);
        //        db.ExecuteNonQuery(dbComAddAttaList, trans);
        //    }

        //    #endregion

        //    #region 新增TemplateInfo

        //    var templatesql = "select * from TempInfo where ParentID=" + oldinfomodel.IID;
        //    DbCommand dbComTemplate = db.GetSqlStringCommand(templatesql);
        //    var dt = db.ExecuteDataSet(dbComTemplate, trans).Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            var addTempInfo = "";
        //            var attidbp = dt.Rows[i]["AttID"];
        //            var newAttaId = "";
        //            if (DBNull.Value != attidbp)
        //            {
        //                if (!string.IsNullOrEmpty(attidbp.ToString()))
        //                {
        //                    var oldfile = new FileInfo(Server.MapPath("/UploadFiles/" + attidbp));

        //                    if (oldfile.Exists)
        //                    {
        //                        newAttaId = Guid.NewGuid().ToString();
        //                        newAttaId = newAttaId + attidbp.ToString().Substring(36);
        //                        oldfile.CopyTo(Server.MapPath("/UploadFiles/" + newAttaId));
        //                    }
        //                }
        //            }
        //            if (dt.Rows[i]["TIPage"] == DBNull.Value)
        //            {
        //                addTempInfo = "insert into TempInfo(ITID,TID,ParentID,AttID) values ('" + itid +
        //                              "','" + dt.Rows[i]["TID"] + "','" + niid + "','" + newAttaId + "');select @@IDENTITY";
        //            }
        //            else
        //            {
        //                addTempInfo = "insert into TempInfo(ITID,TID,TIPage,ParentID,AttID) values ('" + itid +
        //                             "','" + dt.Rows[i]["TID"] + "','" + dt.Rows[i]["TIPage"] + "','" + niid +
        //                             "','" + newAttaId + "');select @@IDENTITY";
        //            }

        //            DbCommand dbComAddTempInfo = db.GetSqlStringCommand(addTempInfo);
        //            var ntiid = db.ExecuteScalar(dbComAddTempInfo, trans);

        //            var infos = "select * from Infos where TIID=" + dt.Rows[i]["TIID"];
        //            DbCommand dbComInfos = db.GetSqlStringCommand(infos);
        //            var dtInfos = db.ExecuteDataSet(dbComInfos, trans).Tables[0];
        //            if (dtInfos.Rows.Count > 0)
        //            {
        //                foreach (DataRow dataRow in dtInfos.Rows)
        //                {
        //                    var imodel = _infosDal.DataRowToModel(dataRow);
        //                    AddInfo(db, trans, imodel, Convert.ToInt32(ntiid), itid);
        //                }
        //            }

        //        }
        //    }

        //    #endregion

        //    return niid;
        //}

        #region

        private void AddInfo(Database db, DbTransaction trans, Admin.Model.Infos oldinfomodel, int tiid, int itid)
        {
            #region 新增info

            var oldbpic = new FileInfo(Server.MapPath("/UploadFiles/" + oldinfomodel.PicAttID));
            var newPicAttaId = "";
            if ("" != oldinfomodel.PicAttID && oldbpic.Exists)
            {
                newPicAttaId = Guid.NewGuid().ToString();
                if ("C0pY" == oldinfomodel.PicAttID.Substring(0, 4))
                {
                    newPicAttaId = "C0pY" + newPicAttaId + oldinfomodel.PicAttID.Substring(40);
                }
                else
                {
                    newPicAttaId = "C0pY" + newPicAttaId + oldinfomodel.PicAttID;
                }

                oldbpic.CopyTo(Server.MapPath("/UploadFiles/" + newPicAttaId));
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
                        newVAttaId = "C0pY" + newVAttaId + oldinfomodel.VideoAttID.Substring(40);
                    }
                    else
                    {
                        newVAttaId = "C0pY" + newVAttaId + oldinfomodel.VideoAttID;
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
                        newadAttaId = "C0pY" + newadAttaId + oldinfomodel.ADPic.Substring(40);
                    }
                    else
                    {
                        newadAttaId = "C0pY" + newadAttaId + oldinfomodel.ADPic;
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
                    var oldfile = new FileInfo(Server.MapPath("/UploadFiles/" + dtAttaList.Rows[i]["AttID"]));
                    var newAttaId = "";
                    if ("" != dtAttaList.Rows[i]["AttID"].ToString() && oldfile.Exists)
                    {
                        newAttaId = Guid.NewGuid().ToString();
                        if ("C0pY" == dtAttaList.Rows[i]["AttID"].ToString().Substring(0, 4))
                        {
                            newAttaId = "C0pY" + newAttaId + dtAttaList.Rows[i]["AttID"].ToString().Substring(40);
                        }
                        else
                        {
                            newAttaId = "C0pY" + newAttaId + dtAttaList.Rows[i]["AttID"];
                        }
                        oldfile.CopyTo(Server.MapPath("/UploadFiles/" + newAttaId));
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
                                    newAttaId = "C0pY" + newAttaId + attidbp.ToString().Substring(40);
                                }
                                else
                                {
                                    newAttaId = "C0pY" + newAttaId + attidbp.ToString();
                                }
                                oldfile.CopyTo(Server.MapPath("/UploadFiles/" + newAttaId));
                            }
                        }
                    }
                    if (dt.Rows[i]["TIPage"] == DBNull.Value)
                    {
                        addTempInfo = "insert into TempInfo(ITID,TID,ParentID,AttID) values ('" + itid +
                                      "','" + dt.Rows[i]["TID"] + "','" + niid + "',N'" + newAttaId +
                                      "');select @@IDENTITY";
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

        #endregion
    }
}