/**  版本信息模板在安装目录下，可自行修改。
* VisitLog.cs
*
* 功 能： N/A
* 类 名： VisitLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  4/9/2015 9:47:30 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.

*│　                                                                　│
*│　                                        　　　　　　　　　　　　　│

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
	/// 数据访问类:VisitLog
	/// </summary>
	public partial class VisitLog
	{
		public VisitLog()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(VLID)+1 from VisitLog";
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
		public bool Exists(int VLID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from VisitLog where VLID=@VLID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "VLID", DbType.Int32,VLID);
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
		public int Add(Model.VisitLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into VisitLog(");
			strSql.Append("IID,VisitDate,StayDate,RPID,OrgId,StaId,CreateDate)");

			strSql.Append(" values (");
			strSql.Append("@IID,@VisitDate,@StayDate,@RPID,@OrgId,@StaId,@CreateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "IID", DbType.Int32, model.IID);
			db.AddInParameter(dbCommand, "VisitDate", DbType.DateTime, model.VisitDate);
			db.AddInParameter(dbCommand, "StayDate", DbType.Int64, model.StayDate);
			db.AddInParameter(dbCommand, "RPID", DbType.Int32, model.RPID);
			db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
			db.AddInParameter(dbCommand, "StaId", DbType.Int64, model.StaId);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
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
		public bool Update(Model.VisitLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VisitLog set ");
			strSql.Append("IID=@IID,");
			strSql.Append("VisitDate=@VisitDate,");
			strSql.Append("StayDate=@StayDate,");
			strSql.Append("RPID=@RPID,");
			strSql.Append("OrgId=@OrgId,");
			strSql.Append("StaId=@StaId,");
			strSql.Append("CreateDate=@CreateDate");
			strSql.Append(" where VLID=@VLID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "VLID", DbType.Int32, model.VLID);
			db.AddInParameter(dbCommand, "IID", DbType.Int32, model.IID);
			db.AddInParameter(dbCommand, "VisitDate", DbType.DateTime, model.VisitDate);
			db.AddInParameter(dbCommand, "StayDate", DbType.Int64, model.StayDate);
			db.AddInParameter(dbCommand, "RPID", DbType.Int32, model.RPID);
			db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
			db.AddInParameter(dbCommand, "StaId", DbType.Int64, model.StaId);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
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
		public bool Delete(int VLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VisitLog ");
			strSql.Append(" where VLID=@VLID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "VLID", DbType.Int32,VLID);
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
		public bool DeleteList(string VLIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VisitLog ");
			strSql.Append(" where VLID in ("+VLIDlist + ")  ");
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
		public Model.VisitLog GetModel(int VLID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VLID,IID,VisitDate,StayDate,RPID,OrgId,StaId,CreateDate from VisitLog ");
			strSql.Append(" where VLID=@VLID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "VLID", DbType.Int32,VLID);
			Model.VisitLog model=null;
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
		public Model.VisitLog DataRowToModel(DataRow row)
		{
			Model.VisitLog model=new Model.VisitLog();
			if (row != null)
			{
				if(row["VLID"]!=null && row["VLID"].ToString()!="")
				{
					model.VLID=Convert.ToInt32(row["VLID"].ToString());
				}
				if(row["IID"]!=null && row["IID"].ToString()!="")
				{
					model.IID=Convert.ToInt32(row["IID"].ToString());
				}
				if(row["VisitDate"]!=null && row["VisitDate"].ToString()!="")
				{
					model.VisitDate=Convert.ToDateTime(row["VisitDate"].ToString());
				}
				if(row["StayDate"]!=null && row["StayDate"].ToString()!="")
				{
					model.StayDate=Convert.ToInt64(row["StayDate"].ToString());
				}
				if(row["RPID"]!=null && row["RPID"].ToString()!="")
				{
					model.RPID=Convert.ToInt32(row["RPID"].ToString());
				}
				if(row["OrgId"]!=null && row["OrgId"].ToString()!="")
				{
					model.OrgId=Convert.ToInt64(row["OrgId"].ToString());
				}
				if(row["StaId"]!=null && row["StaId"].ToString()!="")
				{
					model.StaId=Convert.ToInt64(row["StaId"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=Convert.ToDateTime(row["CreateDate"].ToString());
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
			strSql.Append("select VLID,IID,VisitDate,StayDate,RPID,OrgId,StaId,CreateDate ");
			strSql.Append(" FROM VisitLog ");
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
			strSql.Append(" VLID,IID,VisitDate,StayDate,RPID,OrgId,StaId,CreateDate ");
			strSql.Append(" FROM VisitLog ");
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
			strSql.Append("select count(1) FROM VisitLog ");
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
				strSql.Append("order by T.VLID desc");
			}
			strSql.Append(")AS Row, T.*  from VisitLog T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "VisitLog");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "VLID");
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
		public List<Model.VisitLog> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select VLID,IID,VisitDate,StayDate,RPID,OrgId,StaId,CreateDate ");
			strSql.Append(" FROM VisitLog ");
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
			List<Model.VisitLog> list = new List<Model.VisitLog>();
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
		public Model.VisitLog ReaderBind(IDataReader dataReader)
		{
			Model.VisitLog model=new Model.VisitLog();
			object ojb; 
			ojb = dataReader["VLID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VLID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["IID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["VisitDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.VisitDate=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["StayDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StayDate=Convert.ToInt64(ojb);
			}
			ojb = dataReader["RPID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RPID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["OrgId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrgId=Convert.ToInt64(ojb);
			}
			ojb = dataReader["StaId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StaId=Convert.ToInt64(ojb);
			}
			ojb = dataReader["CreateDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreateDate=Convert.ToDateTime(ojb);
			}
			return model;
		}

		#endregion  Method
	}
}

