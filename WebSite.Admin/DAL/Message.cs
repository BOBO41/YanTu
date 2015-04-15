/**  版本信息模板在安装目录下，可自行修改。
* Message.cs
*
* 功 能： N/A
* 类 名： Message
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/28 17:53:05   N/A    初版
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
	/// 数据访问类:Message
	/// </summary>
	public partial class Message
	{
		public Message()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Message where MID=@MID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "MID", DbType.Int32,MID);
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
		public int Add(Model.Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Message(");
			strSql.Append("MeContent,Datetime,AdminID,Status,ModefyAID)");

			strSql.Append(" values (");
			strSql.Append("@MeContent,@Datetime,@AdminID,@Status,@ModefyAID)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "MeContent", DbType.String, model.MeContent);
			db.AddInParameter(dbCommand, "Datetime", DbType.DateTime, model.Datetime);
			db.AddInParameter(dbCommand, "AdminID", DbType.Int32, model.AdminID);
			db.AddInParameter(dbCommand, "Status", DbType.Int16, model.Status);
			db.AddInParameter(dbCommand, "ModefyAID", DbType.Int32, model.ModefyAID);
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
		public bool Update(Model.Message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Message set ");
			strSql.Append("MeContent=@MeContent,");
			strSql.Append("Datetime=@Datetime,");
			strSql.Append("AdminID=@AdminID,");
			strSql.Append("Status=@Status,");
			strSql.Append("ModefyAID=@ModefyAID");
			strSql.Append(" where MID=@MID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "MID", DbType.Int32, model.MID);
			db.AddInParameter(dbCommand, "MeContent", DbType.String, model.MeContent);
			db.AddInParameter(dbCommand, "Datetime", DbType.DateTime, model.Datetime);
			db.AddInParameter(dbCommand, "AdminID", DbType.Int32, model.AdminID);
			db.AddInParameter(dbCommand, "Status", DbType.Int16, model.Status);
			db.AddInParameter(dbCommand, "ModefyAID", DbType.Int32, model.ModefyAID);
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
		public bool Delete(int MID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Message ");
			strSql.Append(" where MID=@MID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "MID", DbType.Int32,MID);
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
		public bool DeleteList(string MIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Message ");
			strSql.Append(" where MID in ("+MIDlist + ")  ");
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
		public Model.Message GetModel(int MID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MID,MeContent,Datetime,AdminID,Status,ModefyAID from Message ");
			strSql.Append(" where MID=@MID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "MID", DbType.Int32,MID);
			Model.Message model=null;
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
		public Model.Message DataRowToModel(DataRow row)
		{
			Model.Message model=new Model.Message();
			if (row != null)
			{
				if(row["MID"]!=null && row["MID"].ToString()!="")
				{
					model.MID=Convert.ToInt32(row["MID"].ToString());
				}
				if(row["MeContent"]!=null)
				{
					model.MeContent=row["MeContent"].ToString();
				}
				if(row["Datetime"]!=null && row["Datetime"].ToString()!="")
				{
					model.Datetime=Convert.ToDateTime(row["Datetime"].ToString());
				}
				if(row["AdminID"]!=null && row["AdminID"].ToString()!="")
				{
					model.AdminID=Convert.ToInt32(row["AdminID"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["ModefyAID"]!=null && row["ModefyAID"].ToString()!="")
				{
					model.ModefyAID=Convert.ToInt32(row["ModefyAID"].ToString());
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
			strSql.Append("select MID,MeContent,Datetime,AdminID,Status,ModefyAID ");
			strSql.Append(" FROM Message ");
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
			strSql.Append(" MID,MeContent,Datetime,AdminID,Status,ModefyAID ");
			strSql.Append(" FROM Message ");
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
			strSql.Append("select count(1) FROM Message ");
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
				strSql.Append("order by T.MID desc");
			}
			strSql.Append(")AS Row, T.*  from Message T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "Message");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "MID");
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
		public List<Model.Message> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select MID,MeContent,Datetime,AdminID,Status,ModefyAID ");
			strSql.Append(" FROM Message ");
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
			List<Model.Message> list = new List<Model.Message>();
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
		public Model.Message ReaderBind(IDataReader dataReader)
		{
			Model.Message model=new Model.Message();
			object ojb; 
			ojb = dataReader["MID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.MID=Convert.ToInt32(ojb);
			}
			model.MeContent=dataReader["MeContent"].ToString();
			ojb = dataReader["Datetime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Datetime=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["AdminID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AdminID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			ojb = dataReader["ModefyAID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ModefyAID=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method
	}
}

