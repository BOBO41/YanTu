/**  版本信息模板在安装目录下，可自行修改。
* OrgPkgList.cs
*
* 功 能： N/A
* 类 名： OrgPkgList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/18/2015 7:15:59 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

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
	/// 数据访问类:OrgPkgList
	/// </summary>
	public partial class OrgPkgList
	{
		public OrgPkgList()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(SSPID)+1 from OrgPkgList";
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
		public bool Exists(int SSPID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from OrgPkgList where SSPID=@SSPID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "SSPID", DbType.Int32,SSPID);
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
		public int Add(Model.OrgPkgList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrgPkgList(");
			strSql.Append("SPID,OrgId,OSPID,Status,CreateDate,RPID)");

			strSql.Append(" values (");
			strSql.Append("@SPID,@OrgId,@OSPID,@Status,@CreateDate,@RPID)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "SPID", DbType.Int32, model.SPID);
			db.AddInParameter(dbCommand, "OrgId", DbType.Int32, model.OrgId);
			db.AddInParameter(dbCommand, "OSPID", DbType.Int32, model.OSPID);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "RPID", DbType.Int32, model.RPID);
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
		public bool Update(Model.OrgPkgList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrgPkgList set ");
			strSql.Append("SPID=@SPID,");
			strSql.Append("OrgId=@OrgId,");
			strSql.Append("OSPID=@OSPID,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("RPID=@RPID");
			strSql.Append(" where SSPID=@SSPID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "SSPID", DbType.Int32, model.SSPID);
			db.AddInParameter(dbCommand, "SPID", DbType.Int32, model.SPID);
			db.AddInParameter(dbCommand, "OrgId", DbType.Int32, model.OrgId);
			db.AddInParameter(dbCommand, "OSPID", DbType.Int32, model.OSPID);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "RPID", DbType.Int32, model.RPID);
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
		public bool Delete(int SSPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrgPkgList ");
			strSql.Append(" where SSPID=@SSPID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "SSPID", DbType.Int32,SSPID);
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
		public bool DeleteList(string SSPIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrgPkgList ");
			strSql.Append(" where SSPID in ("+SSPIDlist + ")  ");
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
		public Model.OrgPkgList GetModel(int SSPID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SSPID,SPID,OrgId,OSPID,Status,CreateDate,RPID from OrgPkgList ");
			strSql.Append(" where SSPID=@SSPID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "SSPID", DbType.Int32,SSPID);
			Model.OrgPkgList model=null;
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
		public Model.OrgPkgList DataRowToModel(DataRow row)
		{
			Model.OrgPkgList model=new Model.OrgPkgList();
			if (row != null)
			{
				if(row["SSPID"]!=null && row["SSPID"].ToString()!="")
				{
					model.SSPID=Convert.ToInt32(row["SSPID"].ToString());
				}
				if(row["SPID"]!=null && row["SPID"].ToString()!="")
				{
					model.SPID=Convert.ToInt32(row["SPID"].ToString());
				}
				if(row["OrgId"]!=null && row["OrgId"].ToString()!="")
				{
					model.OrgId=Convert.ToInt32(row["OrgId"].ToString());
				}
				if(row["OSPID"]!=null && row["OSPID"].ToString()!="")
				{
					model.OSPID=Convert.ToInt32(row["OSPID"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=Convert.ToDateTime(row["CreateDate"].ToString());
				}
				if(row["RPID"]!=null && row["RPID"].ToString()!="")
				{
					model.RPID=Convert.ToInt32(row["RPID"].ToString());
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
			strSql.Append("select SSPID,SPID,OrgId,OSPID,Status,CreateDate,RPID ");
			strSql.Append(" FROM OrgPkgList ");
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
			strSql.Append(" SSPID,SPID,OrgId,OSPID,Status,CreateDate,RPID ");
			strSql.Append(" FROM OrgPkgList ");
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
			strSql.Append("select count(1) FROM OrgPkgList ");
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
				strSql.Append("order by T.SSPID desc");
			}
			strSql.Append(")AS Row, T.*  from OrgPkgList T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgPkgList");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "SSPID");
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
		public List<Model.OrgPkgList> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select SSPID,SPID,OrgId,OSPID,Status,CreateDate,RPID ");
			strSql.Append(" FROM OrgPkgList ");
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
			List<Model.OrgPkgList> list = new List<Model.OrgPkgList>();
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
		public Model.OrgPkgList ReaderBind(IDataReader dataReader)
		{
			Model.OrgPkgList model=new Model.OrgPkgList();
			object ojb; 
			ojb = dataReader["SSPID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SSPID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["SPID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SPID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["OrgId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrgId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["OSPID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OSPID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			ojb = dataReader["CreateDate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CreateDate=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["RPID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RPID=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method

	    #region 

	    /// <summary>
	    /// 得到一个对象实体
	    /// </summary>
	    public Model.OrgPkgList GetModel(string strWhere, List<SqlParameter> parameters)
	    {

	        StringBuilder strSql = new StringBuilder();
	        strSql.Append("select SSPID,SPID,OrgId,OSPID,Status,CreateDate,RPID from OrgPkgList ");
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
	        Model.OrgPkgList model = null;
	        using (IDataReader dataReader = db.ExecuteReader(dbCommand))
	        {
	            if (dataReader.Read())
	            {
	                model = ReaderBind(dataReader);
	            }
	        }
	        return model;
	    }

	    #endregion


	}
}

