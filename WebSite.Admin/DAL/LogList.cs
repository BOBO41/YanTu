/**  版本信息模板在安装目录下，可自行修改。
* LogList.cs
*
* 功 能： N/A
* 类 名： LogList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-03-03 10:11:54   N/A    初版
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
	/// 数据访问类:LogList
	/// </summary>
	public partial class LogList
	{
		public LogList()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long LLID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from LogList where LLID=@LLID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LLID", DbType.Int64,LLID);
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
		public long Add(Model.LogList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LogList(");
			strSql.Append("EmplId,PId,TName,MDate)");

			strSql.Append(" values (");
			strSql.Append("@EmplId,@PId,@TName,@MDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
			db.AddInParameter(dbCommand, "PId", DbType.Int32, model.PId);
			db.AddInParameter(dbCommand, "TName", DbType.String, model.TName);
			db.AddInParameter(dbCommand, "MDate", DbType.DateTime, model.MDate);
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
		public bool Update(Model.LogList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LogList set ");
			strSql.Append("EmplId=@EmplId,");
			strSql.Append("PId=@PId,");
			strSql.Append("TName=@TName,");
			strSql.Append("MDate=@MDate");
			strSql.Append(" where LLID=@LLID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LLID", DbType.Int64, model.LLID);
			db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
			db.AddInParameter(dbCommand, "PId", DbType.Int32, model.PId);
			db.AddInParameter(dbCommand, "TName", DbType.String, model.TName);
			db.AddInParameter(dbCommand, "MDate", DbType.DateTime, model.MDate);
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
		public bool Delete(long LLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LogList ");
			strSql.Append(" where LLID=@LLID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LLID", DbType.Int64,LLID);
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
		public bool DeleteList(string LLIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LogList ");
			strSql.Append(" where LLID in ("+LLIDlist + ")  ");
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
		public Model.LogList GetModel(long LLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LLID,EmplId,PId,TName,MDate from LogList ");
			strSql.Append(" where LLID=@LLID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LLID", DbType.Int64,LLID);
			Model.LogList model=null;
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
		public Model.LogList DataRowToModel(DataRow row)
		{
			Model.LogList model=new Model.LogList();
			if (row != null)
			{
				if(row["LLID"]!=null && row["LLID"].ToString()!="")
				{
					model.LLID=Convert.ToInt64(row["LLID"].ToString());
				}
				if(row["EmplId"]!=null && row["EmplId"].ToString()!="")
				{
					model.EmplId=Convert.ToInt32(row["EmplId"].ToString());
				}
				if(row["PId"]!=null && row["PId"].ToString()!="")
				{
					model.PId=Convert.ToInt32(row["PId"].ToString());
				}
				if(row["TName"]!=null)
				{
					model.TName=row["TName"].ToString();
				}
				if(row["MDate"]!=null && row["MDate"].ToString()!="")
				{
					model.MDate=Convert.ToDateTime(row["MDate"].ToString());
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
			strSql.Append("select LLID,EmplId,PId,TName,MDate ");
			strSql.Append(" FROM LogList ");
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
			strSql.Append(" LLID,EmplId,PId,TName,MDate ");
			strSql.Append(" FROM LogList ");
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
			strSql.Append("select count(1) FROM LogList ");
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
				strSql.Append("order by T.LLID desc");
			}
			strSql.Append(")AS Row, T.*  from LogList T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "LogList");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LLID");
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
		public List<Model.LogList> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LLID,EmplId,PId,TName,MDate ");
			strSql.Append(" FROM LogList ");
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
			List<Model.LogList> list = new List<Model.LogList>();
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
		public Model.LogList ReaderBind(IDataReader dataReader)
		{
			Model.LogList model=new Model.LogList();
			object ojb; 
			ojb = dataReader["LLID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LLID=Convert.ToInt64(ojb);
			}
			ojb = dataReader["EmplId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.EmplId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["PId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PId=Convert.ToInt32(ojb);
			}
			model.TName=dataReader["TName"].ToString();
			ojb = dataReader["MDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MDate=Convert.ToDateTime(ojb);
			}
			return model;
		}

		#endregion  Method
	}
}

