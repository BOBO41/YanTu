/**  版本信息模板在安装目录下，可自行修改。
* BankAccountOperateList.cs
*
* 功 能： N/A
* 类 名： BankAccountOperateList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-01-17 11:39:49   N/A    初版
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
	/// 数据访问类:BankAccountOperateList
	/// </summary>
	public partial class BankAccountOperateList
	{
		public BankAccountOperateList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(AOId)+1 from BankAccountOperateList";
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
		public bool Exists(int AOId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from BankAccountOperateList where AOId=@AOId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AOId", DbType.Int32,AOId);
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
		public int Add(Model.BankAccountOperateList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BankAccountOperateList(");
			strSql.Append("AccountNo,OpType,time,EmplId)");

			strSql.Append(" values (");
			strSql.Append("@AccountNo,@OpType,@time,@EmplId)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, model.AccountNo);
			db.AddInParameter(dbCommand, "OpType", DbType.Byte, model.OpType);
			db.AddInParameter(dbCommand, "time", DbType.DateTime, model.time);
			db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
			int result;
			object obj = db.ExecuteNonQuery(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BankAccountOperateList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BankAccountOperateList set ");
			strSql.Append("AccountNo=@AccountNo,");
			strSql.Append("OpType=@OpType,");
			strSql.Append("time=@time,");
			strSql.Append("EmplId=@EmplId");
			strSql.Append(" where AOId=@AOId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AOId", DbType.Int32, model.AOId);
			db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, model.AccountNo);
			db.AddInParameter(dbCommand, "OpType", DbType.Byte, model.OpType);
			db.AddInParameter(dbCommand, "time", DbType.DateTime, model.time);
			db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
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
		public bool Delete(int AOId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BankAccountOperateList ");
			strSql.Append(" where AOId=@AOId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AOId", DbType.Int32,AOId);
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
		public bool DeleteList(string AOIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BankAccountOperateList ");
			strSql.Append(" where AOId in ("+AOIdlist + ")  ");
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
		public Model.BankAccountOperateList GetModel(int AOId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AOId,AccountNo,OpType,time,EmplId from BankAccountOperateList ");
			strSql.Append(" where AOId=@AOId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AOId", DbType.Int32,AOId);
			Model.BankAccountOperateList model=null;
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
		public Model.BankAccountOperateList DataRowToModel(DataRow row)
		{
			Model.BankAccountOperateList model=new Model.BankAccountOperateList();
			if (row != null)
			{
				if(row["AOId"]!=null && row["AOId"].ToString()!="")
				{
					model.AOId=Convert.ToInt32(row["AOId"].ToString());
				}
				if(row["AccountNo"]!=null)
				{
					model.AccountNo=row["AccountNo"].ToString();
				}
				if(row["OpType"]!=null && row["OpType"].ToString()!="")
				{
					model.OpType=Convert.ToInt32(row["OpType"].ToString());
				}
				if(row["time"]!=null && row["time"].ToString()!="")
				{
					model.time=Convert.ToDateTime(row["time"].ToString());
				}
				if(row["EmplId"]!=null && row["EmplId"].ToString()!="")
				{
					model.EmplId=Convert.ToInt32(row["EmplId"].ToString());
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
			strSql.Append("select AOId,AccountNo,OpType,time,EmplId ");
			strSql.Append(" FROM BankAccountOperateList ");
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
			strSql.Append(" AOId,AccountNo,OpType,time,EmplId ");
			strSql.Append(" FROM BankAccountOperateList ");
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
			strSql.Append("select count(1) FROM BankAccountOperateList ");
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
				strSql.Append("order by T.AOId desc");
			}
			strSql.Append(")AS Row, T.*  from BankAccountOperateList T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "BankAccountOperateList");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "AOId");
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
		public List<Model.BankAccountOperateList> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AOId,AccountNo,OpType,time,EmplId ");
			strSql.Append(" FROM BankAccountOperateList ");
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
			List<Model.BankAccountOperateList> list = new List<Model.BankAccountOperateList>();
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
		public Model.BankAccountOperateList ReaderBind(IDataReader dataReader)
		{
			Model.BankAccountOperateList model=new Model.BankAccountOperateList();
			object ojb; 
			ojb = dataReader["AOId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AOId=Convert.ToInt32(ojb);
			}
			model.AccountNo=dataReader["AccountNo"].ToString();
			ojb = dataReader["OpType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OpType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["time"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.time=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["EmplId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmplId=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method

        #region  扩展方法
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByAccountNo(string AccountNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BankAccountOperateList ");
            strSql.Append(" where AccountNo=@AccountNo ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AccountNo", DbType.String, AccountNo);
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
        #endregion 
    }
}

