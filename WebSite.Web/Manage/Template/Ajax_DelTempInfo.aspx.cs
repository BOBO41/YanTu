using System;
using System.Data.Common;
using System.Text;
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Template
{
    public partial class Ajax_DelTempInfo : UI.WebPage
    {
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly Infos _infosDal = new Infos();

        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            var tiid = Request.QueryString["tiid"];
            var rtiid = Request.QueryString["rtiid"];
            var tipage = Request.QueryString["tipage"];
            var delad = Request.QueryString["delad"];
            try
            {
                #region 删除页面

                if (!string.IsNullOrEmpty(tiid))
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
                                DelTemplate(db, trans, Convert.ToInt32(timodel.TIID));
                                StringBuilder strSql3 = new StringBuilder();
                                strSql3.Append("select * from  TempInfo where ParentID="+timodel.ParentID+" and ITID=" + timodel.ITID + " and TIPage>" +
                                               timodel.TIPage);
                                DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                                var dt = db.ExecuteDataSet(dbCommandDel, trans).Tables[0];
                                if (dt.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        var sql = "update TempInfo set TIPage=TIPage-1 where TIID=" +
                                                  dt.Rows[i]["TIID"];
                                        DbCommand dbCommand2 = db.GetSqlStringCommand(sql.ToString());
                                        db.ExecuteNonQuery(dbCommand2, trans);
                                    }
                                }
                                trans.Commit();
                                conn.Close();
                                Response.Write("0|~|" + (timodel.ParentID.ToString()=="0"?"":timodel.ParentID.ToString()));
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

                #region 修改页码

                if (!string.IsNullOrEmpty(rtiid) && !string.IsNullOrEmpty(tipage))
                {
                    var timodel = _tempInfoDal.GetModel(Convert.ToInt32(rtiid));
                    if (null != timodel)
                    {
                        Database db = DatabaseFactory.CreateDatabase();
                        using (DbConnection conn = db.CreateConnection())
                        {
                            conn.Open();
                            DbTransaction trans = conn.BeginTransaction();
                            try
                            {
                                StringBuilder strSql4 = new StringBuilder();
                                strSql4.Append("select * from  TempInfo where ITID=" + timodel.ITID + " and ParentID=" +
                                               timodel.ParentID);
                                DbCommand dbCommand4 = db.GetSqlStringCommand(strSql4.ToString());
                                var dt4 = db.ExecuteDataSet(dbCommand4, trans).Tables[0];
                                if (dt4.Rows.Count < Convert.ToInt32(tipage))
                                {
                                    conn.Close();
                                    Response.Write("1|~|页码必须小于总页数");
                                    Response.End();
                                }
                                if (Convert.ToInt32(tipage) == timodel.TIPage)
                                {
                                    conn.Close();
                                    Response.Write("0|~|");
                                    Response.End();
                                }
                                if (Convert.ToInt32(tipage) > timodel.TIPage)
                                {
                                    StringBuilder strSql3 = new StringBuilder();
                                    strSql3.Append("select * from  TempInfo where ITID=" + timodel.ITID +
                                                   " and ParentID=" +
                                                   timodel.ParentID + " and TIPage>" +
                                                   timodel.TIPage + " and TIPage<=" + Convert.ToInt32(tipage));
                                    DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                                    var dt = db.ExecuteDataSet(dbCommandDel, trans).Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            var sql = "update TempInfo set TIPage=TIPage-1 where TIID=" +
                                                      dt.Rows[i]["TIID"];
                                            DbCommand dbCommand2 = db.GetSqlStringCommand(sql.ToString());
                                            db.ExecuteNonQuery(dbCommand2, trans);
                                        }
                                    }
                                    var osql = "update TempInfo set TIPage=" + Convert.ToInt32(tipage) + " where TIID=" +
                                                      timodel.TIID;
                                    DbCommand dbCommando = db.GetSqlStringCommand(osql.ToString());
                                    db.ExecuteNonQuery(dbCommando, trans);
                                }
                                else
                                {
                                    StringBuilder strSql3 = new StringBuilder();
                                    strSql3.Append("select * from  TempInfo where ITID=" + timodel.ITID + " and ParentID=" +
                                                   timodel.ParentID + " and TIPage>=" +
                                                   Convert.ToInt32(tipage) + " and TIPage<" + timodel.TIPage);
                                    DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                                    var dt = db.ExecuteDataSet(dbCommandDel, trans).Tables[0];
                                    if (dt.Rows.Count > 0)
                                    {
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            var sql = "update TempInfo set TIPage=TIPage+1 where TIID=" +
                                                      dt.Rows[i]["TIID"];
                                            DbCommand dbCommand2 = db.GetSqlStringCommand(sql.ToString());
                                            db.ExecuteNonQuery(dbCommand2, trans);
                                        }
                                    }
                                    var osql = "update TempInfo set TIPage=" + Convert.ToInt32(tipage) + " where TIID=" +
                                                      timodel.TIID;
                                    DbCommand dbCommando = db.GetSqlStringCommand(osql.ToString());
                                    db.ExecuteNonQuery(dbCommando, trans);
                                }

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

                #region 删除广告

                if (!string.IsNullOrEmpty(delad))
                {
                    Database db = DatabaseFactory.CreateDatabase();
                    using (DbConnection conn = db.CreateConnection())
                    {
                        conn.Open();
                        DbTransaction trans = conn.BeginTransaction();
                        try
                        {
                            DelTemplate(db, trans, Convert.ToInt32(delad));

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