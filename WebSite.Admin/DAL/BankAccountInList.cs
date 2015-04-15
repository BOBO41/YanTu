/**  版本信息模板在安装目录下，可自行修改。
* BankAccountInList.cs
*
* 功 能： N/A
* 类 名： BankAccountInList
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
	/// 数据访问类:BankAccountInList
	/// </summary>
	public partial class BankAccountInList
	{
		public BankAccountInList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(InId)+1 from BankAccountInList";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int InId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from BankAccountInList where InId=@InId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "InId", DbType.Int32,InId);
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
		public int Add(Model.BankAccountInList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BankAccountInList(");
			strSql.Append("AccountNo,InMoney,Type,Memo,Time,Status,EmplId,EmpId,AuditTime)");

			strSql.Append(" values (");
			strSql.Append("@AccountNo,@InMoney,@Type,@Memo,@Time,@Status,@EmplId,@EmpId,@AuditTime)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, model.AccountNo);
			db.AddInParameter(dbCommand, "InMoney", DbType.Currency, model.InMoney);
			db.AddInParameter(dbCommand, "Type", DbType.Byte, model.Type);
			db.AddInParameter(dbCommand, "Memo", DbType.String, model.Memo);
			db.AddInParameter(dbCommand, "Time", DbType.DateTime, model.Time);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
			db.AddInParameter(dbCommand, "EmpId", DbType.Int32, model.EmpId);
			db.AddInParameter(dbCommand, "AuditTime", DbType.DateTime, model.AuditTime);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BankAccountInList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BankAccountInList set ");
			strSql.Append("AccountNo=@AccountNo,");
			strSql.Append("InMoney=@InMoney,");
			strSql.Append("Type=@Type,");
			strSql.Append("Memo=@Memo,");
			strSql.Append("Time=@Time,");
			strSql.Append("Status=@Status,");
			strSql.Append("EmplId=@EmplId,");
			strSql.Append("EmpId=@EmpId,");
			strSql.Append("AuditTime=@AuditTime");
			strSql.Append(" where InId=@InId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "InId", DbType.Int32, model.InId);
			db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, model.AccountNo);
			db.AddInParameter(dbCommand, "InMoney", DbType.Currency, model.InMoney);
			db.AddInParameter(dbCommand, "Type", DbType.Byte, model.Type);
			db.AddInParameter(dbCommand, "Memo", DbType.String, model.Memo);
			db.AddInParameter(dbCommand, "Time", DbType.DateTime, model.Time);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
			db.AddInParameter(dbCommand, "EmpId", DbType.Int32, model.EmpId);
			db.AddInParameter(dbCommand, "AuditTime", DbType.DateTime, model.AuditTime);
			int rows=db.ExecuteNonQuery(dbCommand);

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
		public bool Delete(int InId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BankAccountInList ");
			strSql.Append(" where InId=@InId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "InId", DbType.Int32,InId);
			int rows=db.ExecuteNonQuery(dbCommand);

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
		public bool DeleteList(string InIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BankAccountInList ");
			strSql.Append(" where InId in ("+InIdlist + ")  ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			int rows=db.ExecuteNonQuery(dbCommand);

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
		public Model.BankAccountInList GetModel(int InId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select InId,AccountNo,InMoney,Type,Memo,Time,Status,EmplId,EmpId,AuditTime from BankAccountInList ");
			strSql.Append(" where InId=@InId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "InId", DbType.Int32,InId);
			Model.BankAccountInList model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.BankAccountInList DataRowToModel(DataRow row)
		{
			Model.BankAccountInList model=new Model.BankAccountInList();
			if (row != null)
			{
				if(row["InId"]!=null && row["InId"].ToString()!="")
				{
					model.InId=Convert.ToInt32(row["InId"].ToString());
				}
				if(row["AccountNo"]!=null)
				{
					model.AccountNo=row["AccountNo"].ToString();
				}
				if(row["InMoney"]!=null && row["InMoney"].ToString()!="")
				{
					model.InMoney=Convert.ToDecimal(row["InMoney"].ToString());
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=Convert.ToInt32(row["Type"].ToString());
				}
				if(row["Memo"]!=null)
				{
					model.Memo=row["Memo"].ToString();
				}
				if(row["Time"]!=null && row["Time"].ToString()!="")
				{
					model.Time=Convert.ToDateTime(row["Time"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["EmplId"]!=null && row["EmplId"].ToString()!="")
				{
					model.EmplId=Convert.ToInt32(row["EmplId"].ToString());
				}
				if(row["EmpId"]!=null && row["EmpId"].ToString()!="")
				{
					model.EmpId=Convert.ToInt32(row["EmpId"].ToString());
				}
				if(row["AuditTime"]!=null && row["AuditTime"].ToString()!="")
				{
					model.AuditTime=Convert.ToDateTime(row["AuditTime"].ToString());
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select InId,AccountNo,InMoney,Type,Memo,Time,Status,EmplId,EmpId,AuditTime ");
			strSql.Append(" FROM BankAccountInList ");
			Database db = DatabaseFactory.CreateDatabase();
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
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
		public DataSet GetList(int Top,string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" InId,AccountNo,InMoney,Type,Memo,Time,Status,EmplId,EmpId,AuditTime ");
			strSql.Append(" FROM BankAccountInList ");
			Database db = DatabaseFactory.CreateDatabase();
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
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
			strSql.Append("select count(1) FROM BankAccountInList ");
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.InId desc");
			}
			strSql.Append(")AS Row, T.*  from BankAccountInList T ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
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
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "BankAccountInList");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "InId");
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
		public List<Model.BankAccountInList> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select InId,AccountNo,InMoney,Type,Memo,Time,Status,EmplId,EmpId,AuditTime ");
			strSql.Append(" FROM BankAccountInList ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			if(parameters.Count > 0)
			{
				foreach (SqlParameter sqlParameter in parameters)
				{
					dbCommand.Parameters.Add(sqlParameter);
				}
			}
			List<Model.BankAccountInList> list = new List<Model.BankAccountInList>();
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
		public Model.BankAccountInList ReaderBind(IDataReader dataReader)
		{
			Model.BankAccountInList model=new Model.BankAccountInList();
			object ojb; 
			ojb = dataReader["InId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.InId=Convert.ToInt32(ojb);
			}
			model.AccountNo=dataReader["AccountNo"].ToString();
			ojb = dataReader["InMoney"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.InMoney=Convert.ToDecimal(ojb);
			}
			ojb = dataReader["Type"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Type=Convert.ToInt32(ojb);
			}
			model.Memo=dataReader["Memo"].ToString();
			ojb = dataReader["Time"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Time=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			ojb = dataReader["EmplId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmplId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["EmpId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmpId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["AuditTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AuditTime=Convert.ToDateTime(ojb);
			}
			return model;
		}

		#endregion  Method


        #region 扩展
        public bool AddRecharge(string accountNo, string inTotal, string mome, int uId)
        {
            bool result = false;
            var model = new BanKAccountInfo().GetModel(accountNo);
            if (model.status == 1)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into BankAccountInList(");
                strSql.Append("AccountNo,InMoney,Memo,Type,Time,Status,EmplId)");

                strSql.Append(" values (");
                strSql.Append("@AccountNo,@InMoney,@Memo,@Type,@Time,@Status,@EmplId)");
                strSql.Append(";select @@IDENTITY");
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, accountNo);
                db.AddInParameter(dbCommand, "InMoney", DbType.Currency, inTotal);
                db.AddInParameter(dbCommand, "Memo", DbType.AnsiString, mome);
                db.AddInParameter(dbCommand, "Type", DbType.Byte, 1);
                db.AddInParameter(dbCommand, "Time", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "Status", DbType.Byte, 0);
                db.AddInParameter(dbCommand, "EmplId", DbType.Int32, uId);

                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    try
                    {
                        object obj = db.ExecuteScalar(dbCommand);

                        trans.Commit();
                        result = true;
                    }
                    catch
                    {
                        trans.Rollback();
                    }
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="accountNo"></param>
        /// <param name="inTotal"></param>
        /// <param name="mome"></param>
        /// <param name="uId"></param>
        /// <returns></returns>
        public bool CanCelRecharge(string inId, string accountNo, string inTotal, string mome, int uId)
        {
            bool result = false;
            var model = new BanKAccountInfo().GetModel(accountNo);
            if (model.status == 1)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into BankAccountInList(");
                strSql.Append("AccountNo,InMoney,Memo,Type,Time,Status,EmplId)");

                strSql.Append(" values (");
                strSql.Append("@AccountNo,@InMoney,@Memo,@Type,@Time,@Status,@EmplId)");
                strSql.Append(";select @@IDENTITY");
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, accountNo);
                db.AddInParameter(dbCommand, "InMoney", DbType.Currency, inTotal);
                db.AddInParameter(dbCommand, "Memo", DbType.AnsiString, mome);
                db.AddInParameter(dbCommand, "Type", DbType.Byte, 1);
                db.AddInParameter(dbCommand, "Time", DbType.DateTime, DateTime.Now);
                db.AddInParameter(dbCommand, "Status", DbType.Byte, 1);
                db.AddInParameter(dbCommand, "EmplId", DbType.Int32, uId);

                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    try
                    {
                        int res;
                        object obj = db.ExecuteScalar(dbCommand);
                        if (int.TryParse(obj.ToString(), out res))
                        {
                            StringBuilder strSql2 = new StringBuilder();
                            strSql2.Append("update BanKAccountInfo set ");
                            strSql2.Append("CurrentTotal=CurrentTotal" + inTotal);
                            strSql2.Append(" where AccountNo=@AccountNo ");
                            DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                            db.AddInParameter(dbCommand2, "AccountNo", DbType.AnsiString, accountNo);
                            db.ExecuteNonQuery(dbCommand2, trans);
                            StringBuilder strSql3 = new StringBuilder();
                            strSql3.Append("update BankAccountInList set ");
                            strSql3.Append("Status=0");
                            strSql3.Append(" where InId=@InId ");
                            DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
                            db.AddInParameter(dbCommand3, "InId", DbType.Int32, inId);
                            db.ExecuteNonQuery(dbCommand3, trans);
                            trans.Commit();
                            result = true;
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                    }
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListAcc(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select InId,AccountNo,InMoney,Type,Memo,Time,a.Status,a.EmplId,EmpId,convert(varchar(10),AuditTime,120) as AuditTime,b.EmplName ");
            strSql.Append(" FROM BankAccountInList a left join dbo.OrgEmployees b on a.EmpId=b.EmplId ");
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

        #endregion
	}
}

