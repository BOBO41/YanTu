/**  版本信息模板在安装目录下，可自行修改。
* BankCardInfo.cs
*
* 功 能： N/A
* 类 名： BankCardInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/7/28 11:23:14   N/A    初版
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
	/// 数据访问类:BankCardInfo
	/// </summary>
	public partial class BankCardInfo
	{
		public BankCardInfo()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CardNo)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from BankCardInfo where CardNo=@CardNo ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CardNo", DbType.AnsiString,CardNo);
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
		public bool Add(Model.BankCardInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BankCardInfo(");
			strSql.Append("CardNo,Status,OpenTime,CloseTime,CardType)");

			strSql.Append(" values (");
			strSql.Append("@CardNo,@Status,@OpenTime,@CloseTime,@CardType)");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CardNo", DbType.AnsiString, model.CardNo);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "OpenTime", DbType.DateTime, model.OpenTime);
			db.AddInParameter(dbCommand, "CloseTime", DbType.DateTime, model.CloseTime);
			db.AddInParameter(dbCommand, "CardType", DbType.Int32, model.CardType);
			int result;
			object obj = db.ExecuteNonQuery(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.BankCardInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BankCardInfo set ");
			strSql.Append("Status=@Status,");
			strSql.Append("OpenTime=@OpenTime,");
			strSql.Append("CloseTime=@CloseTime,");
			strSql.Append("CardType=@CardType");
			strSql.Append(" where CardNo=@CardNo ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CardNo", DbType.AnsiString, model.CardNo);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "OpenTime", DbType.DateTime, model.OpenTime);
			db.AddInParameter(dbCommand, "CloseTime", DbType.DateTime, model.CloseTime);
			db.AddInParameter(dbCommand, "CardType", DbType.Int32, model.CardType);
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
		public bool Delete(string CardNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BankCardInfo ");
			strSql.Append(" where CardNo=@CardNo ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CardNo", DbType.AnsiString,CardNo);
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
		public bool DeleteList(string CardNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BankCardInfo ");
			strSql.Append(" where CardNo in ("+CardNolist + ")  ");
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
		public Model.BankCardInfo GetModel(string CardNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CardNo,Status,OpenTime,CloseTime,CardType from BankCardInfo ");
			strSql.Append(" where CardNo=@CardNo ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CardNo", DbType.AnsiString,CardNo);
			Model.BankCardInfo model=null;
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
		public Model.BankCardInfo DataRowToModel(DataRow row)
		{
			Model.BankCardInfo model=new Model.BankCardInfo();
			if (row != null)
			{
				if(row["CardNo"]!=null)
				{
					model.CardNo=row["CardNo"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["OpenTime"]!=null && row["OpenTime"].ToString()!="")
				{
					model.OpenTime=Convert.ToDateTime(row["OpenTime"].ToString());
				}
				if(row["CloseTime"]!=null && row["CloseTime"].ToString()!="")
				{
					model.CloseTime=Convert.ToDateTime(row["CloseTime"].ToString());
				}
				if(row["CardType"]!=null && row["CardType"].ToString()!="")
				{
					model.CardType=Convert.ToInt32(row["CardType"].ToString());
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
			strSql.Append("select CardNo,Status,OpenTime,CloseTime,CardType ");
			strSql.Append(" FROM BankCardInfo ");
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
			strSql.Append(" CardNo,Status,OpenTime,CloseTime,CardType ");
			strSql.Append(" FROM BankCardInfo ");
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
			strSql.Append("select count(1) FROM BankCardInfo ");
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
				strSql.Append("order by T.CardNo desc");
			}
			strSql.Append(")AS Row, T.*  from BankCardInfo T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "BankCardInfo");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CardNo");
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
		public List<Model.BankCardInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CardNo,Status,OpenTime,CloseTime,CardType ");
			strSql.Append(" FROM BankCardInfo ");
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
			List<Model.BankCardInfo> list = new List<Model.BankCardInfo>();
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
		public Model.BankCardInfo ReaderBind(IDataReader dataReader)
		{
			Model.BankCardInfo model=new Model.BankCardInfo();
			object ojb; 
			model.CardNo=dataReader["CardNo"].ToString();
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			ojb = dataReader["OpenTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OpenTime=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["CloseTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CloseTime=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["CardType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CardType=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method
	}
}

