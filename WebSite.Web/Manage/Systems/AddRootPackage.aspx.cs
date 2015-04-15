using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;
using Infos = WebSite.Admin.Model.Infos;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddRootPackage : UI.WebPage
    {
        private readonly Admin.DAL.RootPackage _dataDal = new Admin.DAL.RootPackage();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        private readonly Admin.DAL.StaPackage _staPackageDal = new Admin.DAL.StaPackage();
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly Admin.DAL.Infos _infosDal = new Admin.DAL.Infos();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                rboSingle.Checked = true;
                BindOrgName();
                if (!string.IsNullOrEmpty(Request.QueryString["empId"]))
                {
                    BindData(Request.QueryString["empId"]);
                    cretype.Visible = false;
                    dorg.Visible = false;
                }
            }
        }

        private void BindData(string empId)
        {
            try
            {
                var model = _dataDal.GetModel(Convert.ToInt32(empId));
                txtName.Value = model.RPName;
            }
            catch (Exception)
            {
            }
        }
        private void BindOrgName()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();         //创建sql参数存储对象
            string sqlWhere = " 1=1 and Status=1 order by RPID desc";
            DataSet dtor = _dataDal.GetList(sqlWhere, parameters);
            ddlOrgName.DataSource = dtor;
            ddlOrgName.DataTextField = "RPName";
            ddlOrgName.DataValueField = "RPID";
            ddlOrgName.DataBind();
            ddlOrgName.Items.Insert(0, new ListItem("请选择资源包", "-1"));
            //ddlOrgName.SelectedIndex = 0;
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            var name = txtName.Value.Trim();
            var rpid = ddlOrgName.SelectedValue;
            var type = Request.Form["rboSelectType"];
            var orgid = hfCity.Value;
            if (string.IsNullOrEmpty(name))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写资源包名称！');</script>");
                return;
            }

            #region 修改资源包

            if (!string.IsNullOrEmpty(Request.QueryString["empId"]))
            {
                try
                {
                    var model = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["empId"]));
                    if (model == null)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('资源包不存在！');</script>");
                        return;
                    }
                    model.RPName = name;
                    if (_dataDal.Exists(Convert.ToInt32(Request.QueryString["empId"]), name))
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('资源包已经存在！');</script>");
                        return;
                    }
                    var res = _dataDal.Update(model);
                    if (res)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('更新失败！');</script>");
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
                }
            }
            #endregion

            #region 新增资源包

            else
            {
                if ("1" == type)
                {
                    #region 创建新的资源包

                    var model = new Admin.Model.RootPackage
                    {
                        CreateDate = DateTime.Now,
                        RPName = name,
                        Status = 0
                    };
                    if (_dataDal.Exists(0, name))
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('资源包已经存在！');</script>");
                        return;
                    }
                    var resAdd = _dataDal.Add(model);
                    if (resAdd > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('新增失败！');</script>");
                    }

                    #endregion
                }
                else if ("14" == type)
                {
                    if (!string.IsNullOrEmpty(rpid) && "-1" != rpid)
                    {
                        if (!string.IsNullOrEmpty(orgid))
                        {
                            if ("-1" != orgid)
                            {
                                var res = CopyPkg(orgid, rpid, name);
                                if (res != "")
                                {
                                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('复制失败！');</script>");
                                    return;
                                }
                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "",
                                    "<script>alert('请选择铁路局！');</script>");
                                return;
                            }
                        }
                        else
                        {
                            var res = CopyPkg("", rpid, name);
                            if (res != "")
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('复制失败！');</script>");
                                return;
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                            }
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                                    "<script>alert('请选择待复制的资源包！');</script>");
                        return;
                    }
                }
            }

            #endregion

        }

        #region

        private string CopyPkg(string orgid, string orpid, string name)
        {
            var res = "";
            if (_dataDal.Exists(0, name))
            {
                return "资源包名称已经存在！";
            }
            Database db = DatabaseFactory.CreateDatabase();
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("insert into RootPackage(");
                    strSql.Append("ORPID,Status,RPName,CreateDate)");

                    strSql.Append(" values (");
                    strSql.Append("@ORPID,@Status,@RPName,@CreateDate)");
                    strSql.Append(";select @@IDENTITY");
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "Status", DbType.Byte, 0);
                    db.AddInParameter(dbCommand, "ORPID", DbType.Int32, orpid);
                    db.AddInParameter(dbCommand, "RPName", DbType.String, name);
                    db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, DateTime.Now);
                    object nrpid = db.ExecuteScalar(dbCommand, trans);

                    if (!string.IsNullOrEmpty(orgid))
                    {
                        var sqllist =
                            "select StaPackage.* from StaPackage join OrgPkgList on OrgPkgList.SPID=StaPackage.SPID and OrgPkgList.OrgId=@OrgId and OrgPkgList.RPID=@RPID";
                        DbCommand dbCommandlist = db.GetSqlStringCommand(sqllist);
                        db.AddInParameter(dbCommandlist, "RPID", DbType.Int32, orpid);
                        db.AddInParameter(dbCommandlist, "OrgId", DbType.Int32, orgid);
                        var dt = db.ExecuteDataSet(dbCommandlist, trans).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            CopySpPkg(dt, db, trans, nrpid);
                        }
                    }
                    else
                    {
                        var sqllist =
                            "select StaPackage.* from StaPackage where RPID=@RPID and PkgType=0 ";
                        DbCommand dbCommandlist = db.GetSqlStringCommand(sqllist);
                        db.AddInParameter(dbCommandlist, "RPID", DbType.Int32, orpid);
                        var dt = db.ExecuteDataSet(dbCommandlist, trans).Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            CopySpPkg(dt, db, trans, nrpid);
                        }
                    }

                    trans.Commit();
                    conn.Close();
                    return res;
                }
                catch (ThreadAbortException ex)
                {
                }
                catch (Exception ee)
                {
                    trans.Rollback();
                    conn.Close();
                    return ee.Message;
                }
            }
            return res;
        }

        #region

        private void CopySpPkg(DataTable dt, Database db, DbTransaction trans, object nrpid)
        {
            foreach (DataRow dataRow in dt.Rows)
            {
                var spmodel = _staPackageDal.DataRowToModel(dataRow);

                #region 创建新spkg

                StringBuilder spadd = new StringBuilder();
                spadd.Append("insert into StaPackage(");
                spadd.Append("RPID,OrgId,SPPath,Status,CreateDate,PkgType)");

                spadd.Append(" values (");
                spadd.Append("@RPID,@OrgId,@SPPath,@Status,@CreateDate,@PkgType)");
                spadd.Append(";select @@IDENTITY");
                DbCommand dbCommandspadd = db.GetSqlStringCommand(spadd.ToString());
                db.AddInParameter(dbCommandspadd, "RPID", DbType.Int32, nrpid);
                db.AddInParameter(dbCommandspadd, "OrgId", DbType.Int32, spmodel.OrgId);
                db.AddInParameter(dbCommandspadd, "SPPath", DbType.String, Guid.NewGuid().ToString());
                db.AddInParameter(dbCommandspadd, "Status", DbType.Byte, 0);
                db.AddInParameter(dbCommandspadd, "CreateDate", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommandspadd, "PkgType", DbType.Byte, 0);
                object nspid = db.ExecuteScalar(dbCommandspadd, trans);

                #endregion

                #region 创建新的itype

                var typelist = "select * from InfoType where SPID='" + spmodel.SPID + "' ";
                DbCommand dbCommandtplist = db.GetSqlStringCommand(typelist);
                var dttypelist = db.ExecuteDataSet(dbCommandtplist, trans).Tables[0];

                if (dttypelist.Rows.Count > 0)
                {
                    foreach (DataRow drRow in dttypelist.Rows)
                    {
                        #region

                        var itmodel = _infoTypeDal.DataRowToModel(drRow);
                        StringBuilder strSqlit = new StringBuilder();
                        strSqlit.Append("insert into InfoType(");
                        strSqlit.Append("IName,SPID,AttaID,SortNum,Status)");

                        strSqlit.Append(" values (");
                        strSqlit.Append("@IName,@SPID,@AttaID,@SortNum,@Status)");
                        strSqlit.Append(";select @@IDENTITY");
                        DbCommand dbCommandit = db.GetSqlStringCommand(strSqlit.ToString());
                        db.AddInParameter(dbCommandit, "IName", DbType.String, itmodel.IName);
                        db.AddInParameter(dbCommandit, "SPID", DbType.Int32, nspid);
                        db.AddInParameter(dbCommandit, "AttaID", DbType.String, itmodel.AttaID);
                        db.AddInParameter(dbCommandit, "SortNum", DbType.Int32, itmodel.SortNum);
                        db.AddInParameter(dbCommandit, "Status", DbType.Byte, itmodel.Status);
                        object nitid = db.ExecuteScalar(dbCommandit, trans);

                        #endregion

                        #region tilist

                        var tilist = "select * from TempInfo where ITID='" + itmodel.ITID +
                                     "' and ParentID=0 ";
                        DbCommand dbCommandtilist = db.GetSqlStringCommand(tilist);
                        var dttilist = db.ExecuteDataSet(dbCommandtilist, trans).Tables[0];

                        if (dttilist.Rows.Count > 0)
                        {
                            foreach (DataRow tiRow in dttilist.Rows)
                            {
                                #region 创建新tempInfo

                                var timodel = _tempInfoDal.DataRowToModel(tiRow);
                                StringBuilder strSqlti = new StringBuilder();
                                strSqlti.Append("insert into TempInfo(");
                                strSqlti.Append("ITID,TID,AttID,TIPage,ParentID)");

                                strSqlti.Append(" values (");
                                strSqlti.Append("@ITID,@TID,@AttID,@TIPage,@ParentID)");
                                strSqlti.Append(";select @@IDENTITY");
                                var newAttaId = "";
                                if (!string.IsNullOrEmpty(timodel.AttID))
                                {
                                    var oldfile =
                                        new FileInfo(Server.MapPath("/UploadFiles/" + timodel.AttID));

                                    if (oldfile.Exists)
                                    {
                                        newAttaId = Guid.NewGuid().ToString();
                                        if ("C0pY" == timodel.AttID.Substring(0, 4))
                                        {
                                            newAttaId = "C0pY" + newAttaId + timodel.AttID.Substring(40);
                                        }
                                        else
                                        {
                                            newAttaId = "C0pY" + newAttaId + timodel.AttID;
                                        }
                                        oldfile.CopyTo(Server.MapPath("/UploadFiles/" + newAttaId));
                                    }
                                }
                                DbCommand dbCommandti = db.GetSqlStringCommand(strSqlti.ToString());
                                db.AddInParameter(dbCommandti, "ITID", DbType.Int32, nitid);
                                db.AddInParameter(dbCommandti, "TID", DbType.Int32, timodel.TID);
                                db.AddInParameter(dbCommandti, "AttID", DbType.String, newAttaId);
                                db.AddInParameter(dbCommandti, "TIPage", DbType.Int32, timodel.TIPage);
                                db.AddInParameter(dbCommandti, "ParentID", DbType.Int32,
                                    timodel.ParentID);
                                object ntiid = db.ExecuteScalar(dbCommandti, trans);

                                #endregion

                                #region 创建新info

                                var infolist = "select * from Infos where TIID='" + timodel.TIID + "'";
                                DbCommand dbCommandinfolist = db.GetSqlStringCommand(infolist);
                                var dtinfolist = db.ExecuteDataSet(dbCommandinfolist, trans).Tables[0];

                                if (dtinfolist.Rows.Count > 0)
                                {
                                    foreach (DataRow infoRow in dtinfolist.Rows)
                                    {
                                        var imodel = _infosDal.DataRowToModel(infoRow);
                                        AddInfo(db, trans, imodel, Convert.ToInt32(ntiid),
                                            Convert.ToInt32(nitid));
                                    }
                                }

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


        #endregion


        #region

        private void AddInfo(Database db, DbTransaction trans, Infos oldinfomodel, int tiid, int itid)
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