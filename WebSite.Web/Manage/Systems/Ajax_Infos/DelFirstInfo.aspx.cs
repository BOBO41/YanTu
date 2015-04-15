using System;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_Infos
{
    public partial class DelFirstInfo : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly Infos _infosDal = new Infos();

        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            var iid = Request.QueryString["iid"];
            if (!string.IsNullOrEmpty(iid))
            {
                try
                {
                    var imodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    if (null != imodel)
                    {
                        Database db = DatabaseFactory.CreateDatabase();
                        using (DbConnection conn = db.CreateConnection())
                        {
                            conn.Open();
                            DbTransaction trans = conn.BeginTransaction();
                            try
                            {
                                var templatesql = "select TIID from TempInfo where ParentID=" + iid;
                                DbCommand dbComTemplate = db.GetSqlStringCommand(templatesql);
                                var dt = db.ExecuteDataSet(dbComTemplate, trans).Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        DelTemplate(db, trans, Convert.ToInt32(dt.Rows[i]["TIID"]));
                                    }
                                }
                                var delinfo = "delete from InfoLabel where IID=" + iid + ";delete from AdInfos where Inf_IID=" + iid + ";delete from AdInfos where IID=" + iid + ";delete from AttaList where IID=" + iid + ";delete from Infos where IID=" + iid;
                                DbCommand dbComDelInfo = db.GetSqlStringCommand(delinfo);
                                db.ExecuteNonQuery(dbComDelInfo, trans);
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

        protected void DelTemplate(Database db, DbTransaction trans, int tiid)
        {
            var infosql = "select IID from Infos where TIID=" + tiid;
            DbCommand dbComInfo = db.GetSqlStringCommand(infosql);
            var dtInfo = db.ExecuteDataSet(dbComInfo, trans).Tables[0];
            for (int j = 0; j < dtInfo.Rows.Count; j++)
            {
                var templatesql = "select TIID from TempInfo where ParentID=" + dtInfo.Rows[j]["IID"];
                DbCommand dbComTemplate = db.GetSqlStringCommand(templatesql);
                var dt = db.ExecuteDataSet(dbComTemplate, trans).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DelTemplate(db, trans, Convert.ToInt32(dt.Rows[i]["TIID"]));
                    }
                }
                var delinfo = "delete from InfoLabel where IID=" + dtInfo.Rows[j]["IID"] +
                              ";delete from AttaList where IID=" + dtInfo.Rows[j]["IID"] + ";delete from AdInfos where Inf_IID=" + dtInfo.Rows[j]["IID"] + ";delete from AdInfos where IID=" + dtInfo.Rows[j]["IID"] + ";delete from Infos where IID=" + dtInfo.Rows[j]["IID"];
                DbCommand dbComDelInfo = db.GetSqlStringCommand(delinfo);
                db.ExecuteNonQuery(dbComDelInfo, trans);
            }
            var delTemplate = "delete from TempInfo where TIID=" + tiid;
            DbCommand dbComDelTemplate = db.GetSqlStringCommand(delTemplate);
            db.ExecuteNonQuery(dbComDelTemplate, trans);
        }
    }
}