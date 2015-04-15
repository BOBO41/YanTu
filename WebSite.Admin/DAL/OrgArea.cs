/**  版本信息模板在安装目录下，可自行修改。
* OrgArea.cs
*
* 功 能： N/A
* 类 名： OrgArea
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-02-20 17:49:58   N/A    初版
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
	/// 数据访问类:OrgArea
	/// </summary>
	public partial class OrgArea
	{
		public OrgArea()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string AreaId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from OrgArea where AreaId=@AreaId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString,AreaId);
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
		public bool Add(Model.OrgArea model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrgArea(");
			strSql.Append("AreaId,AreaName,AreaLevel,ParentId,Status)");

			strSql.Append(" values (");
			strSql.Append("@AreaId,@AreaName,@AreaLevel,@ParentId,@Status)");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString, model.AreaId);
			db.AddInParameter(dbCommand, "AreaName", DbType.String, model.AreaName);
			db.AddInParameter(dbCommand, "AreaLevel", DbType.Int32, model.AreaLevel);
			db.AddInParameter(dbCommand, "ParentId", DbType.AnsiString, model.ParentId);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
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
		public bool Update(Model.OrgArea model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrgArea set ");
			strSql.Append("AreaName=@AreaName,");
			strSql.Append("AreaLevel=@AreaLevel,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("Status=@Status");
			strSql.Append(" where AreaId=@AreaId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString, model.AreaId);
			db.AddInParameter(dbCommand, "AreaName", DbType.String, model.AreaName);
			db.AddInParameter(dbCommand, "AreaLevel", DbType.Int32, model.AreaLevel);
			db.AddInParameter(dbCommand, "ParentId", DbType.AnsiString, model.ParentId);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
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
		public bool Delete(string AreaId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrgArea ");
			strSql.Append(" where AreaId=@AreaId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString,AreaId);
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
		public bool DeleteList(string AreaIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrgArea ");
			strSql.Append(" where AreaId in ("+AreaIdlist + ")  ");
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
		public Model.OrgArea GetModel(string AreaId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AreaId,AreaName,AreaLevel,ParentId,Status from OrgArea ");
			strSql.Append(" where AreaId=@AreaId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString,AreaId);
			Model.OrgArea model=null;
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
		public Model.OrgArea DataRowToModel(DataRow row)
		{
			Model.OrgArea model=new Model.OrgArea();
			if (row != null)
			{
				if(row["AreaId"]!=null)
				{
					model.AreaId=row["AreaId"].ToString();
				}
				if(row["AreaName"]!=null)
				{
					model.AreaName=row["AreaName"].ToString();
				}
				if(row["AreaLevel"]!=null && row["AreaLevel"].ToString()!="")
				{
					model.AreaLevel=Convert.ToInt32(row["AreaLevel"].ToString());
				}
				if(row["ParentId"]!=null)
				{
					model.ParentId=row["ParentId"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
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
			strSql.Append("select AreaId,AreaName,AreaLevel,ParentId,Status ");
			strSql.Append(" FROM OrgArea ");
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
			strSql.Append(" AreaId,AreaName,AreaLevel,ParentId,Status ");
			strSql.Append(" FROM OrgArea ");
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
			strSql.Append("select count(1) FROM OrgArea ");
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
				strSql.Append("order by T.AreaId desc");
			}
			strSql.Append(")AS Row, T.*  from OrgArea T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgArea");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "AreaId");
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
		public List<Model.OrgArea> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AreaId,AreaName,AreaLevel,ParentId,Status ");
			strSql.Append(" FROM OrgArea ");
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
			List<Model.OrgArea> list = new List<Model.OrgArea>();
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
		public Model.OrgArea ReaderBind(IDataReader dataReader)
		{
			Model.OrgArea model=new Model.OrgArea();
			object ojb; 
			model.AreaId=dataReader["AreaId"].ToString();
			model.AreaName=dataReader["AreaName"].ToString();
			ojb = dataReader["AreaLevel"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AreaLevel=Convert.ToInt32(ojb);
			}
			model.ParentId=dataReader["ParentId"].ToString();
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method

        #region 扩展
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public string MaxAreaId()
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max([AreaId])+1 from [OrgArea] ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            string cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, global::System.DBNull.Value)))
            {
                cmdresult = "1";
            }
            else
            {
                cmdresult = obj.ToString();
            }
            return cmdresult;
        }
        #endregion
	}
}

