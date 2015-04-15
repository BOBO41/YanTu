/**  版本信息模板在安装目录下，可自行修改。
* BanKAccountInfo.cs
*
* 功 能： N/A
* 类 名： BanKAccountInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/23 14:17:19   N/A    初版
*
* 




*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Admin.DAL
{
    /// <summary>
    /// 数据访问类:BanKAccountInfo
    /// </summary>
    public partial class BanKAccountInfo
    {
        public BanKAccountInfo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AccountNo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BanKAccountInfo where AccountNo=@AccountNo ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, AccountNo);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.BanKAccountInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BanKAccountInfo(");
            strSql.Append("AccountNo,CId,CardNo,EmplId,InTotal,OutTotal,CurrentTotal,AccountPwd,OpenTime,status,EmpId,AuditTime)");

            strSql.Append(" values (");
            strSql.Append("@AccountNo,@CId,@CardNo,@EmplId,@InTotal,@OutTotal,@CurrentTotal,@AccountPwd,@OpenTime,@status,@EmpId,@AuditTime)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, model.AccountNo);
            db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
            db.AddInParameter(dbCommand, "CardNo", DbType.AnsiString, model.CardNo);
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "InTotal", DbType.Currency, model.InTotal);
            db.AddInParameter(dbCommand, "OutTotal", DbType.Currency, model.OutTotal);
            db.AddInParameter(dbCommand, "CurrentTotal", DbType.Currency, model.CurrentTotal);
            db.AddInParameter(dbCommand, "AccountPwd", DbType.AnsiString, model.AccountPwd);
            db.AddInParameter(dbCommand, "OpenTime", DbType.DateTime, model.OpenTime);
            db.AddInParameter(dbCommand, "status", DbType.Byte, model.status);
            db.AddInParameter(dbCommand, "EmpId", DbType.Int32, model.EmpId);
            db.AddInParameter(dbCommand, "AuditTime", DbType.DateTime, model.AuditTime);
            int result;
            object obj = db.ExecuteNonQuery(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.BanKAccountInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BanKAccountInfo set ");
            strSql.Append("CId=@CId,");
            strSql.Append("CardNo=@CardNo,");
            strSql.Append("EmplId=@EmplId,");
            strSql.Append("InTotal=@InTotal,");
            strSql.Append("OutTotal=@OutTotal,");
            strSql.Append("CurrentTotal=@CurrentTotal,");
            strSql.Append("AccountPwd=@AccountPwd,");
            strSql.Append("OpenTime=@OpenTime,");
            strSql.Append("status=@status,");
            strSql.Append("EmpId=@EmpId,");
            strSql.Append("AuditTime=@AuditTime");
            strSql.Append(" where AccountNo=@AccountNo ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, model.AccountNo);
            db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
            db.AddInParameter(dbCommand, "CardNo", DbType.AnsiString, model.CardNo);
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "InTotal", DbType.Currency, model.InTotal);
            db.AddInParameter(dbCommand, "OutTotal", DbType.Currency, model.OutTotal);
            db.AddInParameter(dbCommand, "CurrentTotal", DbType.Currency, model.CurrentTotal);
            db.AddInParameter(dbCommand, "AccountPwd", DbType.AnsiString, model.AccountPwd);
            db.AddInParameter(dbCommand, "OpenTime", DbType.DateTime, model.OpenTime);
            db.AddInParameter(dbCommand, "status", DbType.Byte, model.status);
            db.AddInParameter(dbCommand, "EmpId", DbType.Int32, model.EmpId);
            db.AddInParameter(dbCommand, "AuditTime", DbType.DateTime, model.AuditTime);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string AccountNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BanKAccountInfo ");
            strSql.Append(" where AccountNo=@AccountNo ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, AccountNo);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AccountNolist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BanKAccountInfo ");
            strSql.Append(" where AccountNo in (" + AccountNolist + ")  ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.BanKAccountInfo GetModel(string AccountNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccountNo,CId,CardNo,EmplId,InTotal,OutTotal,CurrentTotal,AccountPwd,OpenTime,status,EmpId,AuditTime from BanKAccountInfo ");
            strSql.Append(" where AccountNo=@AccountNo ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, AccountNo);
            Model.BanKAccountInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.BanKAccountInfo DataRowToModel(DataRow row)
        {
            Model.BanKAccountInfo model = new Model.BanKAccountInfo();
            if (row != null)
            {
                if (row["AccountNo"] != null)
                {
                    model.AccountNo = row["AccountNo"].ToString();
                }
                if (row["CId"] != null && row["CId"].ToString() != "")
                {
                    model.CId = Convert.ToInt32(row["CId"].ToString());
                }
                if (row["CardNo"] != null)
                {
                    model.CardNo = row["CardNo"].ToString();
                }
                if (row["EmplId"] != null && row["EmplId"].ToString() != "")
                {
                    model.EmplId = Convert.ToInt32(row["EmplId"].ToString());
                }
                if (row["InTotal"] != null && row["InTotal"].ToString() != "")
                {
                    model.InTotal = Convert.ToDecimal(row["InTotal"].ToString());
                }
                if (row["OutTotal"] != null && row["OutTotal"].ToString() != "")
                {
                    model.OutTotal = Convert.ToDecimal(row["OutTotal"].ToString());
                }
                if (row["CurrentTotal"] != null && row["CurrentTotal"].ToString() != "")
                {
                    model.CurrentTotal = Convert.ToDecimal(row["CurrentTotal"].ToString());
                }
                if (row["AccountPwd"] != null)
                {
                    model.AccountPwd = row["AccountPwd"].ToString();
                }
                if (row["OpenTime"] != null && row["OpenTime"].ToString() != "")
                {
                    model.OpenTime = Convert.ToDateTime(row["OpenTime"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = Convert.ToInt32(row["status"].ToString());
                }
                if (row["EmpId"] != null && row["EmpId"].ToString() != "")
                {
                    model.EmpId = Convert.ToInt32(row["EmpId"].ToString());
                }
                if (row["AuditTime"] != null && row["AuditTime"].ToString() != "")
                {
                    model.AuditTime = Convert.ToDateTime(row["AuditTime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccountNo,CId,CardNo,EmplId,InTotal,OutTotal,CurrentTotal,AccountPwd,OpenTime,status,EmpId,AuditTime ");
            strSql.Append(" FROM BanKAccountInfo ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="Top">int Top</param>
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(int Top, string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AccountNo,CId,CardNo,EmplId,InTotal,OutTotal,CurrentTotal,AccountPwd,OpenTime,status,EmpId,AuditTime ");
            strSql.Append(" FROM BanKAccountInfo ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /*
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM BanKAccountInfo ");
            if(strWhere.Trim()!="")
            {
                strSql.Append(" where "+strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }*/
        /// <summary>
        /// 分页获取数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell  like写法:'%'+@Cell+'%' </param>
        /// <param name="orderby">string orderby</param>
        /// <param name="startIndex">开始页码</param>
        /// <param name="endIndex">结束页码</param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, List<SqlParameter> parameters)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.AccountNo desc");
            }
            strSql.Append(")AS Row, T.*  from BanKAccountInfo T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "BanKAccountInfo");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "AccountNo");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public List<Model.BanKAccountInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccountNo,CId,CardNo,EmplId,InTotal,OutTotal,CurrentTotal,AccountPwd,OpenTime,status,EmpId,AuditTime ");
            strSql.Append(" FROM BanKAccountInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            List<Model.BanKAccountInfo> list = new List<Model.BanKAccountInfo>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Model.BanKAccountInfo ReaderBind(IDataReader dataReader)
        {
            Model.BanKAccountInfo model = new Model.BanKAccountInfo();
            object ojb;
            model.AccountNo = dataReader["AccountNo"].ToString();
            ojb = dataReader["CId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CId = Convert.ToInt32(ojb);
            }
            model.CardNo = dataReader["CardNo"].ToString();
            ojb = dataReader["EmplId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EmplId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["InTotal"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.InTotal = Convert.ToDecimal(ojb);
            }
            ojb = dataReader["OutTotal"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OutTotal = Convert.ToDecimal(ojb);
            }
            ojb = dataReader["CurrentTotal"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CurrentTotal = Convert.ToDecimal(ojb);
            }
            model.AccountPwd = dataReader["AccountPwd"].ToString();
            ojb = dataReader["OpenTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OpenTime = Convert.ToDateTime(ojb);
            }
            ojb = dataReader["status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.status = Convert.ToInt32(ojb);
            }
            ojb = dataReader["EmpId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EmpId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["AuditTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AuditTime = Convert.ToDateTime(ojb);
            }
            return model;
        }

        #endregion  Method


        #region 扩展

        /// <summary>
        /// 新增农户帐户
        /// </summary>
        /// <param name="cId">农户ID</param>
        /// <param name="cardNo">卡号</param>
        /// <param name="uId">操作员ID</param>
        /// <param name="inTotal">预存金额</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public string AddAcc(string cId, string cardNo, int uId, string inTotal, string pwd, int cardType)
        {
            string result = "新增失败";
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("select count(1) from BanKAccountInfo where CardNo=@CardNo ");
            DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
            db.AddInParameter(dbCommand3, "CardNo", DbType.AnsiString, cardNo);
            object obj3 = db.ExecuteScalar(dbCommand3);
            if (obj3.ToString() == "0")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into BankCardInfo(");
                strSql.Append("CardNo,Status,OpenTime,CardType)");

                strSql.Append(" values (");
                strSql.Append("@CardNo,@Status,@OpenTime,@CardType)");

                DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                db.AddInParameter(dbCommand, "CardNo", DbType.AnsiString, cardNo);
                db.AddInParameter(dbCommand, "Status", DbType.Byte, 1);
                db.AddInParameter(dbCommand, "OpenTime", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "CardType", DbType.Int32, cardType);

                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    try
                    {
                        int rows = db.ExecuteNonQuery(dbCommand, trans);
                        if (rows > 0)
                        {
                            StringBuilder strSql2 = new StringBuilder();
                            strSql2.Append("insert into BanKAccountInfo(");
                            strSql2.Append("AccountNo,CId,CardNo,EmplId,InTotal,OutTotal,CurrentTotal,AccountPwd,OpenTime,status)");

                            strSql2.Append(" values (");
                            strSql2.Append("@AccountNo,@CId,@CardNo,@EmplId,@InTotal,@OutTotal,@CurrentTotal,@AccountPwd,@OpenTime,@status)");

                            DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                            db.AddInParameter(dbCommand2, "AccountNo", DbType.AnsiString, cardNo);
                            db.AddInParameter(dbCommand2, "CId", DbType.Int32, cId);
                            db.AddInParameter(dbCommand2, "CardNo", DbType.AnsiString, cardNo);
                            db.AddInParameter(dbCommand2, "EmplId", DbType.Int32, uId);
                            db.AddInParameter(dbCommand2, "InTotal", DbType.Currency, inTotal);
                            db.AddInParameter(dbCommand2, "OutTotal", DbType.Currency, 0);
                            db.AddInParameter(dbCommand2, "CurrentTotal", DbType.Currency, inTotal);
                            db.AddInParameter(dbCommand2, "AccountPwd", DbType.AnsiString, pwd);
                            db.AddInParameter(dbCommand2, "OpenTime", DbType.DateTime, DateTime.Now);
                            db.AddInParameter(dbCommand2, "status", DbType.Byte, 5);
                            int obj = db.ExecuteNonQuery(dbCommand2, trans);
                            if (obj > 0)
                            {
                                StringBuilder strSql4 = new StringBuilder();
                                strSql4.Append("insert into BankAccountOperateList(");
                                strSql4.Append("AccountNo,OpType,time,EmplId)");

                                strSql4.Append(" values (");
                                strSql4.Append("@AccountNo,@OpType,@time,@EmplId)");
                                strSql4.Append(";select @@IDENTITY");
                                DbCommand dbCommand4 = db.GetSqlStringCommand(strSql4.ToString());
                                db.AddInParameter(dbCommand4, "AccountNo", DbType.AnsiString, cardNo);
                                db.AddInParameter(dbCommand4, "OpType", DbType.Byte, 3);

                                db.AddInParameter(dbCommand4, "time", DbType.DateTime, DateTime.Now);
                                db.AddInParameter(dbCommand4, "EmplId", DbType.Int32, uId);
                                db.ExecuteScalar(dbCommand4, trans);
                                result = "1";
                                trans.Commit();
                            }
                        }
                    }
                    catch (Exception ee)
                    {
                        result = ee.Message;
                        trans.Rollback();
                    }
                    conn.Close();

                    return result;
                }
            }
            result = "该卡已经绑定其他帐号";
            return result;
        }
        public string LockAcc(string cid, string cardNo, int empId, string type, int EmpId)
        {
            string result = "锁定失败";
            Database db = DatabaseFactory.CreateDatabase();

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    var card = cardNo.Split(',');
                    for (int i = 0; i < card.Length - 1; i++)
                    {
                        StringBuilder strSql3 = new StringBuilder();
                        strSql3.Append("insert into BankAccountOperateList(");
                        strSql3.Append("AccountNo,OpType,time,EmplId)");

                        strSql3.Append(" values (");
                        strSql3.Append("@AccountNo,@OpType,@time,@EmplId)");
                        strSql3.Append(";select @@IDENTITY");
                        DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
                        db.AddInParameter(dbCommand3, "AccountNo", DbType.AnsiString, card[i]);
                        if (type == "2")
                        {
                            db.AddInParameter(dbCommand3, "OpType", DbType.Byte, 1);
                        }
                        else if (type == "5")
                        {
                            db.AddInParameter(dbCommand3, "OpType", DbType.Byte, 2);
                        }
                        else if (type == "0")
                        {
                            db.AddInParameter(dbCommand3, "OpType", DbType.Byte, 4);
                        }
                        else if (type == "1")
                        {
                            db.AddInParameter(dbCommand3, "OpType", DbType.Byte, 8);
                        }
                        db.AddInParameter(dbCommand3, "time", DbType.DateTime, DateTime.Now);
                        db.AddInParameter(dbCommand3, "EmplId", DbType.Int32, empId);
                        object obj3 = db.ExecuteScalar(dbCommand3, trans);
                        int res;
                        if (int.TryParse(obj3.ToString(), out res))
                        {
                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("update BanKAccountInfo set ");
                            strSql.Append("status=@status,EmpId=@EmpId,AuditTime=@AuditTime");
                            strSql.Append(" where AccountNo=@AccountNo ");
                            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                            db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, card[i]);
                            db.AddInParameter(dbCommand, "EmpId", DbType.Int32, EmpId);
                            db.AddInParameter(dbCommand, "AuditTime", DbType.DateTime, DateTime.Now);
                            if (type == "5")
                            {
                                db.AddInParameter(dbCommand, "status", DbType.AnsiString, 1);
                            }
                            else
                            {
                                db.AddInParameter(dbCommand, "status", DbType.AnsiString, type);
                            }
                            db.ExecuteNonQuery(dbCommand, trans);
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                    if (type == "1" || type == "5")
                    {

                        if (!string.IsNullOrEmpty(cid))
                        {
                            var id = cid.Split(',');
                            for (int i = 0; i < id.Length - 1; i++)
                            {
                                StringBuilder strSql1 = new StringBuilder();
                                strSql1.Append("update OrgCustomer set ");
                                strSql1.Append("Status=@Status");
                                strSql1.Append(" where CId in( @CId )");
                                DbCommand dbCommand1 = db.GetSqlStringCommand(strSql1.ToString());
                                db.AddInParameter(dbCommand1, "CId", DbType.Int32, id[i]);

                                db.AddInParameter(dbCommand1, "Status", DbType.Int32, 1);
                                db.ExecuteNonQuery(dbCommand1, trans);
                            }
                        }
                    }
                    result = "1";
                    trans.Commit();

                }
                catch (Exception ee)
                {
                    result = ee.Message;
                    trans.Rollback();
                }
                conn.Close();
            }
            return result;
        }

        public string ChAccPwd(string cardNo, int empId, string pwd)
        {
            string result = "修改失败";
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("insert into BankAccountOperateList(");
            strSql3.Append("AccountNo,OpType,time,EmplId)");

            strSql3.Append(" values (");
            strSql3.Append("@AccountNo,@OpType,@time,@EmplId)");
            strSql3.Append(";select @@IDENTITY");
            DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
            db.AddInParameter(dbCommand3, "AccountNo", DbType.AnsiString, cardNo);

            db.AddInParameter(dbCommand3, "OpType", DbType.Byte, 5);
            db.AddInParameter(dbCommand3, "time", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand3, "EmplId", DbType.Int32, empId);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    object obj3 = db.ExecuteScalar(dbCommand3, trans);
                    int res;
                    if (int.TryParse(obj3.ToString(), out res))
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update BanKAccountInfo set ");
                        strSql.Append("AccountPwd=@AccountPwd");
                        strSql.Append(" where AccountNo=@AccountNo ");
                        DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                        db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, cardNo);
                        db.AddInParameter(dbCommand, "AccountPwd", DbType.AnsiString, pwd);
                        db.ExecuteNonQuery(dbCommand, trans);
                        result = "1";
                        trans.Commit();
                    }
                    else
                    {
                        trans.Rollback();
                    }
                }
                catch (Exception ee)
                {
                    result = ee.Message;
                    trans.Rollback();
                }
                conn.Close();
            }
            return result;
        }



        public string ChAcc(string cardNo, int empId, string newCardNo)
        {
            string result = "1改卡失败";
            Database db = DatabaseFactory.CreateDatabase();
            if (cardNo != newCardNo)
            {
                StringBuilder strSql3 = new StringBuilder();
                strSql3.Append("select count(1) from BankCardInfo where CardNo=@CardNo ");
                DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
                db.AddInParameter(dbCommand3, "CardNo", DbType.AnsiString, newCardNo);
                object obj3 = db.ExecuteScalar(dbCommand3);
                if (obj3.ToString() == "0")
                {
                    var model = new BanKAccountInfo().GetModel(cardNo);
                    if (model != null)
                    {
                        using (DbConnection conn = db.CreateConnection())
                        {
                            conn.Open();
                            DbTransaction trans = conn.BeginTransaction();
                            try
                            {
                                StringBuilder strSql2 = new StringBuilder();
                                strSql2.Append("update  BankPayList set AccountNo=@NewCardNo where AccountNo=@CardNo;");
                                strSql2.Append("update  BankAccountOperateList set AccountNo=@NewCardNo where AccountNo=@CardNo;");
                                strSql2.Append("update  BankAccountInList set AccountNo=@NewCardNo where AccountNo=@CardNo;");
                                strSql2.Append("update  BanKAccountInfo set CardNo=@NewCardNo,AccountNo=@NewCardNo where AccountNo=@CardNo;");
                                strSql2.Append("update  BankCardInfo set CardNo=@NewCardNo where CardNo=@CardNo;");
                                DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                                db.AddInParameter(dbCommand2, "CardNo", DbType.AnsiString, cardNo);
                                db.AddInParameter(dbCommand2, "NewCardNo", DbType.AnsiString, newCardNo);
                                int obj = db.ExecuteNonQuery(dbCommand2, trans);
                                if (obj > 0)
                                {
                                    StringBuilder strSql5 = new StringBuilder();
                                    strSql5.Append("insert into BankAccountOperateList(");
                                    strSql5.Append("AccountNo,OpType,time,EmplId)");

                                    strSql5.Append(" values (");
                                    strSql5.Append("@AccountNo,@OpType,@time,@EmplId)");
                                    strSql5.Append(";select @@IDENTITY");
                                    DbCommand dbCommand5 = db.GetSqlStringCommand(strSql5.ToString());
                                    db.AddInParameter(dbCommand5, "AccountNo", DbType.AnsiString, newCardNo);

                                    db.AddInParameter(dbCommand5, "OpType", DbType.Byte, 6);
                                    db.AddInParameter(dbCommand5, "time", DbType.DateTime, DateTime.Now);
                                    db.AddInParameter(dbCommand5, "EmplId", DbType.Int32, empId);
                                    db.ExecuteNonQuery(dbCommand5, trans);

                                    result = "1";
                                    trans.Commit();
                                }
                            }
                            catch (Exception ee)
                            {
                                result = ee.Message;
                                trans.Rollback();
                            }
                            conn.Close();
                        }
                    }
                    else
                    {
                        result = "不能对该卡进行操作!";
                    }
                }
                else
                {
                    result = "该卡已经绑定其他帐号";
                }
            }
            else
            {
                result = "改卡失败";
            }
            return result;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.BanKAccountInfo GetModel(int InId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select InId,AccountNo,CId,CardNo,EmplId,InTotal,OutTotal,CurrentTotal,AccountPwd,OpenTime,status from BanKAccountInfo ");
            strSql.Append(" where InId=@InId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "InId", DbType.Int32, InId);
            Model.BanKAccountInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListAcc(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AccountNo,CId,a.CardNo,a.EmplId,InTotal,OutTotal,CurrentTotal,AccountPwd,a.OpenTime,a.status,EmpId,convert(varchar(10),AuditTime,120) as AuditTime,b.EmplName,c.CardType ");
            strSql.Append(" FROM BanKAccountInfo  a left join dbo.OrgEmployees b on a.EmpId=b.EmplId  left join dbo.BankCardInfo c on a.CardNo=c.CardNo");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }


        public string DelAcc(string cardNo)
        {
            string result = "删除失败";
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("delete  from BankCardInfo  ");
            strSql3.Append("where CardNo=@CardNo");
            DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
            db.AddInParameter(dbCommand3, "CardNo", DbType.AnsiString, cardNo);

            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbCommand3, trans);

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from  BankAccountOperateList  ");
                    strSql.Append(" where AccountNo=@AccountNo ");
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, cardNo);
                    db.ExecuteNonQuery(dbCommand, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("delete from  BanKAccountInfo  ");
                    strSql2.Append(" where AccountNo=@AccountNo ");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.AddInParameter(dbCommand2, "AccountNo", DbType.AnsiString, cardNo);
                    db.ExecuteNonQuery(dbCommand2, trans);
                    result = "1";
                    trans.Commit();
                }
                catch (Exception ee)
                {
                    result = ee.Message;
                    trans.Rollback();
                }
                conn.Close();
            }
            return result;
        }
        #endregion

    }
}

