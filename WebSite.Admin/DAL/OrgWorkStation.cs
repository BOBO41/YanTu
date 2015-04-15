/**  版本信息模板在安装目录下，可自行修改。
* OrgWorkStation.cs
*
* 功 能： N/A
* 类 名： OrgWorkStation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-30 19:03:05   N/A    初版
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

//Please add references
namespace WebSite.Admin.DAL
{
	/// <summary>
	/// 数据访问类:OrgWorkStation
	/// </summary>
	public partial class OrgWorkStation
	{
		public OrgWorkStation()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(WId)+1 from OrgWorkStation";
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
		public bool Exists(int WId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from OrgWorkStation where WId=@WId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "WId", DbType.Int32,WId);
			int cmdresult;
			object obj = db.ExecuteScalar(dbCommand);
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, global::System.DBNull.Value)))
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
		public int Add(Model.OrgWorkStation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrgWorkStation(");
			strSql.Append("OrgId,Size,Area,Manager,ManagerPhone,StartTime,ToolsMemo)");

			strSql.Append(" values (");
			strSql.Append("@OrgId,@Size,@Area,@Manager,@ManagerPhone,@StartTime,@ToolsMemo)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
			db.AddInParameter(dbCommand, "Size", DbType.String, model.Size);
			db.AddInParameter(dbCommand, "Area", DbType.String, model.Area);
			db.AddInParameter(dbCommand, "Manager", DbType.String, model.Manager);
			db.AddInParameter(dbCommand, "ManagerPhone", DbType.AnsiString, model.ManagerPhone);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "ToolsMemo", DbType.String, model.ToolsMemo);
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
		public bool Update(Model.OrgWorkStation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrgWorkStation set ");
			strSql.Append("OrgId=@OrgId,");
			strSql.Append("Size=@Size,");
			strSql.Append("Area=@Area,");
			strSql.Append("Manager=@Manager,");
			strSql.Append("ManagerPhone=@ManagerPhone,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("ToolsMemo=@ToolsMemo");
			strSql.Append(" where WId=@WId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "WId", DbType.Int32, model.WId);
			db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
			db.AddInParameter(dbCommand, "Size", DbType.String, model.Size);
			db.AddInParameter(dbCommand, "Area", DbType.String, model.Area);
			db.AddInParameter(dbCommand, "Manager", DbType.String, model.Manager);
			db.AddInParameter(dbCommand, "ManagerPhone", DbType.AnsiString, model.ManagerPhone);
			db.AddInParameter(dbCommand, "StartTime", DbType.DateTime, model.StartTime);
			db.AddInParameter(dbCommand, "ToolsMemo", DbType.String, model.ToolsMemo);
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
		public bool Delete(int WId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrgWorkStation ");
			strSql.Append(" where WId=@WId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "WId", DbType.Int32,WId);
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
		public bool DeleteList(string WIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrgWorkStation ");
			strSql.Append(" where WId in ("+WIdlist + ")  ");
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
		public Model.OrgWorkStation GetModel(int WId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select WId,OrgId,Size,Area,Manager,ManagerPhone,StartTime,ToolsMemo from OrgWorkStation ");
			strSql.Append(" where WId=@WId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "WId", DbType.Int32,WId);
			Model.OrgWorkStation model=null;
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
		public Model.OrgWorkStation DataRowToModel(DataRow row)
		{
			Model.OrgWorkStation model=new Model.OrgWorkStation();
			if (row != null)
			{
				if(row["WId"]!=null && row["WId"].ToString()!="")
				{
					model.WId=Convert.ToInt32(row["WId"].ToString());
				}
				if(row["OrgId"]!=null && row["OrgId"].ToString()!="")
				{
					model.OrgId=Convert.ToInt64(row["OrgId"].ToString());
				}
				if(row["Size"]!=null)
				{
					model.Size=row["Size"].ToString();
				}
				if(row["Area"]!=null)
				{
					model.Area=row["Area"].ToString();
				}
				if(row["Manager"]!=null)
				{
					model.Manager=row["Manager"].ToString();
				}
				if(row["ManagerPhone"]!=null)
				{
					model.ManagerPhone=row["ManagerPhone"].ToString();
				}
				if(row["StartTime"]!=null && row["StartTime"].ToString()!="")
				{
					model.StartTime=Convert.ToDateTime(row["StartTime"].ToString());
				}
				if(row["ToolsMemo"]!=null)
				{
					model.ToolsMemo=row["ToolsMemo"].ToString();
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
			strSql.Append("select WId,OrgId,Size,Area,Manager,ManagerPhone,StartTime,ToolsMemo ");
			strSql.Append(" FROM OrgWorkStation ");
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
			strSql.Append(" WId,OrgId,Size,Area,Manager,ManagerPhone,StartTime,ToolsMemo ");
			strSql.Append(" FROM OrgWorkStation ");
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
			strSql.Append("select count(1) FROM OrgWorkStation ");
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
				strSql.Append("order by T.WId desc");
			}
			strSql.Append(")AS Row, T.*  from OrgWorkStation T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgWorkStation");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "WId");
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
		public List<Model.OrgWorkStation> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select WId,OrgId,Size,Area,Manager,ManagerPhone,StartTime,ToolsMemo ");
			strSql.Append(" FROM OrgWorkStation ");
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
			List<Model.OrgWorkStation> list = new List<Model.OrgWorkStation>();
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
		public Model.OrgWorkStation ReaderBind(IDataReader dataReader)
		{
			Model.OrgWorkStation model=new Model.OrgWorkStation();
			object ojb; 
			ojb = dataReader["WId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.WId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["OrgId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrgId=Convert.ToInt64(ojb);
			}
			model.Size=dataReader["Size"].ToString();
			model.Area=dataReader["Area"].ToString();
			model.Manager=dataReader["Manager"].ToString();
			model.ManagerPhone=dataReader["ManagerPhone"].ToString();
			ojb = dataReader["StartTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.StartTime=Convert.ToDateTime(ojb);
			}
			model.ToolsMemo=dataReader["ToolsMemo"].ToString();
			return model;
		}

		#endregion  Method
	}
}

