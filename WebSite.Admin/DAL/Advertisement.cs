/**  版本信息模板在安装目录下，可自行修改。
* Advertisement.cs
*
* 功 能： N/A
* 类 名： Advertisement
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/10/2015 5:11:08 PM   N/A    初版
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
	/// 数据访问类:Advertisement
	/// </summary>
	public partial class Advertisement
	{
		public Advertisement()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(AID)+1 from Advertisement";
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
		public bool Exists(int AID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Advertisement where AID=@AID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AID", DbType.Int32,AID);
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
		public int Add(Model.Advertisement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Advertisement(");
			strSql.Append("AName,AUrl,AImg,Status,CreateDate)");

			strSql.Append(" values (");
			strSql.Append("@AName,@AUrl,@AImg,@Status,@CreateDate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AName", DbType.String, model.AName);
			db.AddInParameter(dbCommand, "AUrl", DbType.String, model.AUrl);
			db.AddInParameter(dbCommand, "AImg", DbType.String, model.AImg);
			db.AddInParameter(dbCommand, "Status", DbType.Int16, model.Status);
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
		public bool Update(Model.Advertisement model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Advertisement set ");
			strSql.Append("AName=@AName,");
			strSql.Append("AUrl=@AUrl,");
			strSql.Append("AImg=@AImg,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate");
			strSql.Append(" where AID=@AID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AID", DbType.Int32, model.AID);
			db.AddInParameter(dbCommand, "AName", DbType.String, model.AName);
			db.AddInParameter(dbCommand, "AUrl", DbType.String, model.AUrl);
			db.AddInParameter(dbCommand, "AImg", DbType.String, model.AImg);
			db.AddInParameter(dbCommand, "Status", DbType.Int16, model.Status);
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
		public bool Delete(int AID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Advertisement ");
			strSql.Append(" where AID=@AID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AID", DbType.Int32,AID);
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
		public bool DeleteList(string AIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Advertisement ");
			strSql.Append(" where AID in ("+AIDlist + ")  ");
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
		public Model.Advertisement GetModel(int AID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AID,AName,AUrl,AImg,Status,CreateDate from Advertisement ");
			strSql.Append(" where AID=@AID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AID", DbType.Int32,AID);
			Model.Advertisement model=null;
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
		public Model.Advertisement DataRowToModel(DataRow row)
		{
			Model.Advertisement model=new Model.Advertisement();
			if (row != null)
			{
				if(row["AID"]!=null && row["AID"].ToString()!="")
				{
					model.AID=Convert.ToInt32(row["AID"].ToString());
				}
				if(row["AName"]!=null)
				{
					model.AName=row["AName"].ToString();
				}
				if(row["AUrl"]!=null)
				{
					model.AUrl=row["AUrl"].ToString();
				}
				if(row["AImg"]!=null)
				{
					model.AImg=row["AImg"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
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
			strSql.Append("select AID,AName,AUrl,AImg,Status,CreateDate ");
			strSql.Append(" FROM Advertisement ");
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
			strSql.Append(" AID,AName,AUrl,AImg,Status,CreateDate ");
			strSql.Append(" FROM Advertisement ");
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
			strSql.Append("select count(1) FROM Advertisement ");
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
				strSql.Append("order by T.AID desc");
			}
			strSql.Append(")AS Row, T.*  from Advertisement T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "Advertisement");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "AID");
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
		public List<Model.Advertisement> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AID,AName,AUrl,AImg,Status,CreateDate ");
			strSql.Append(" FROM Advertisement ");
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
			List<Model.Advertisement> list = new List<Model.Advertisement>();
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
		public Model.Advertisement ReaderBind(IDataReader dataReader)
		{
			Model.Advertisement model=new Model.Advertisement();
			object ojb; 
			ojb = dataReader["AID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AID=Convert.ToInt32(ojb);
			}
			model.AName=dataReader["AName"].ToString();
			model.AUrl=dataReader["AUrl"].ToString();
			model.AImg=dataReader["AImg"].ToString();
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
			return model;
		}

		#endregion  Method

	    #region 

	    /// <summary>
	    /// 是否存在该记录
	    /// </summary>
	    public bool Exists(int ALID, string LName)
	    {
	        Database db = DatabaseFactory.CreateDatabase();
	        StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Advertisement where AName=@AName ");
	        if (ALID != 0)
	        {
                strSql.Append(" and AID!=" + ALID);
	        }
	        DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AName", DbType.String, LName);
	        int cmdresult;
	        object obj = db.ExecuteScalar(dbCommand);
	        if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
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

	    #endregion


	}
}

