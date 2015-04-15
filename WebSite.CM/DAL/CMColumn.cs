/**  版本信息模板在安装目录下，可自行修改。
* CMColumn.cs
*
* 功 能： N/A
* 类 名： CMColumn
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/8/4 11:23:30   N/A    初版
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

namespace WebSite.CM.DAL
{
	/// <summary>
	/// 数据访问类:CMColumn
	/// </summary>
	public partial class CMColumn
	{
		public CMColumn()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ColId)+1 from CMColumn";
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
		public bool Exists(int ColId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from CMColumn where ColId=@ColId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ColId", DbType.Int32,ColId);
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
		public int Add(Model.CMColumn model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CMColumn(");
			strSql.Append("ColName,ParentId,Level,Status,AddTime,SeoKey,SeoDes,ClickRate)");

			strSql.Append(" values (");
			strSql.Append("@ColName,@ParentId,@Level,@Status,@AddTime,@SeoKey,@SeoDes,@ClickRate)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ColName", DbType.String, model.ColName);
			db.AddInParameter(dbCommand, "ParentId", DbType.Int32, model.ParentId);
			db.AddInParameter(dbCommand, "Level", DbType.Int32, model.Level);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
			db.AddInParameter(dbCommand, "SeoKey", DbType.String, model.SeoKey);
			db.AddInParameter(dbCommand, "SeoDes", DbType.String, model.SeoDes);
			db.AddInParameter(dbCommand, "ClickRate", DbType.Int32, model.ClickRate);
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
		public bool Update(Model.CMColumn model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CMColumn set ");
			strSql.Append("ColName=@ColName,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("Level=@Level,");
			strSql.Append("Status=@Status,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("SeoKey=@SeoKey,");
			strSql.Append("SeoDes=@SeoDes,");
			strSql.Append("ClickRate=@ClickRate");
			strSql.Append(" where ColId=@ColId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ColId", DbType.Int32, model.ColId);
			db.AddInParameter(dbCommand, "ColName", DbType.String, model.ColName);
			db.AddInParameter(dbCommand, "ParentId", DbType.Int32, model.ParentId);
			db.AddInParameter(dbCommand, "Level", DbType.Int32, model.Level);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
			db.AddInParameter(dbCommand, "SeoKey", DbType.String, model.SeoKey);
			db.AddInParameter(dbCommand, "SeoDes", DbType.String, model.SeoDes);
			db.AddInParameter(dbCommand, "ClickRate", DbType.Int32, model.ClickRate);
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
		public bool Delete(int ColId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMColumn ");
			strSql.Append(" where ColId=@ColId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ColId", DbType.Int32,ColId);
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
		public bool DeleteList(string ColIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMColumn ");
			strSql.Append(" where ColId in ("+ColIdlist + ")  ");
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
		public Model.CMColumn GetModel(int ColId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ColId,ColName,ParentId,Level,Status,AddTime,SeoKey,SeoDes,ClickRate from CMColumn ");
			strSql.Append(" where ColId=@ColId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ColId", DbType.Int32,ColId);
			Model.CMColumn model=null;
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
		public Model.CMColumn DataRowToModel(DataRow row)
		{
			Model.CMColumn model=new Model.CMColumn();
			if (row != null)
			{
				if(row["ColId"]!=null && row["ColId"].ToString()!="")
				{
					model.ColId=Convert.ToInt32(row["ColId"].ToString());
				}
				if(row["ColName"]!=null)
				{
					model.ColName=row["ColName"].ToString();
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId=Convert.ToInt32(row["ParentId"].ToString());
				}
				if(row["Level"]!=null && row["Level"].ToString()!="")
				{
					model.Level=Convert.ToInt32(row["Level"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=Convert.ToDateTime(row["AddTime"].ToString());
				}
				if(row["SeoKey"]!=null)
				{
					model.SeoKey=row["SeoKey"].ToString();
				}
				if(row["SeoDes"]!=null)
				{
					model.SeoDes=row["SeoDes"].ToString();
				}
				if(row["ClickRate"]!=null && row["ClickRate"].ToString()!="")
				{
					model.ClickRate=Convert.ToInt32(row["ClickRate"].ToString());
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
			strSql.Append("select ColId,ColName,ParentId,Level,Status,AddTime,SeoKey,SeoDes,ClickRate ");
			strSql.Append(" FROM CMColumn ");
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
			strSql.Append(" ColId,ColName,ParentId,Level,Status,AddTime,SeoKey,SeoDes,ClickRate ");
			strSql.Append(" FROM CMColumn ");
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
			strSql.Append("select count(1) FROM CMColumn ");
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
				strSql.Append("order by T.ColId desc");
			}
			strSql.Append(")AS Row, T.*  from CMColumn T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMColumn");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ColId");
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
		public List<Model.CMColumn> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ColId,ColName,ParentId,Level,Status,AddTime,SeoKey,SeoDes,ClickRate ");
			strSql.Append(" FROM CMColumn ");
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
			List<Model.CMColumn> list = new List<Model.CMColumn>();
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
		public Model.CMColumn ReaderBind(IDataReader dataReader)
		{
			Model.CMColumn model=new Model.CMColumn();
			object ojb; 
			ojb = dataReader["ColId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ColId=Convert.ToInt32(ojb);
			}
			model.ColName=dataReader["ColName"].ToString();
			ojb = dataReader["ParentId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ParentId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["Level"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Level=Convert.ToInt32(ojb);
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			ojb = dataReader["AddTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddTime=Convert.ToDateTime(ojb);
			}
			model.SeoKey=dataReader["SeoKey"].ToString();
			model.SeoDes=dataReader["SeoDes"].ToString();
			ojb = dataReader["ClickRate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ClickRate=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method

        #region ExMethod
        /// <summary>
        /// 获得栏目数据
        /// </summary>
        public DataSet GetDateList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CMColumn  ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        public DataSet GetDateList(string str)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CMColumn  ");
            if (!string.IsNullOrEmpty(str))
            {
                strSql.Append("where " + str + "");
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListColumn(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select row_number() over(order by ClickRate desc) as rownum,ColId,ColName,ClickRate ");
            strSql.Append(" FROM CMColumn ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        #endregion
	}
}

