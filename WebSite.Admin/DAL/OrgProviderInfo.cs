/**  版本信息模板在安装目录下，可自行修改。
* OrgProviderInfo.cs
*
* 功 能： N/A
* 类 名： OrgProviderInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-30 19:03:04   N/A    初版
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
	/// 数据访问类:OrgProviderInfo
	/// </summary>
	public partial class OrgProviderInfo
	{
		public OrgProviderInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(ProvId)+1 from OrgProviderInfo";
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
		public bool Exists(int ProvId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from OrgProviderInfo where ProvId=@ProvId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ProvId", DbType.Int32,ProvId);
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
		public int Add(Model.OrgProviderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into OrgProviderInfo(");
			strSql.Append("OrgId,BankAccount,BankName,BankAddress,Manager,ManagerPhone,ProviderType,AddTime)");

			strSql.Append(" values (");
			strSql.Append("@OrgId,@BankAccount,@BankName,@BankAddress,@Manager,@ManagerPhone,@ProviderType,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
			db.AddInParameter(dbCommand, "BankAccount", DbType.AnsiString, model.BankAccount);
			db.AddInParameter(dbCommand, "BankName", DbType.String, model.BankName);
			db.AddInParameter(dbCommand, "BankAddress", DbType.String, model.BankAddress);
			db.AddInParameter(dbCommand, "Manager", DbType.String, model.Manager);
			db.AddInParameter(dbCommand, "ManagerPhone", DbType.AnsiString, model.ManagerPhone);
			db.AddInParameter(dbCommand, "ProviderType", DbType.String, model.ProviderType);
			db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
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
		public bool Update(Model.OrgProviderInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update OrgProviderInfo set ");
			strSql.Append("OrgId=@OrgId,");
			strSql.Append("BankAccount=@BankAccount,");
			strSql.Append("BankName=@BankName,");
			strSql.Append("BankAddress=@BankAddress,");
			strSql.Append("Manager=@Manager,");
			strSql.Append("ManagerPhone=@ManagerPhone,");
			strSql.Append("ProviderType=@ProviderType,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where ProvId=@ProvId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ProvId", DbType.Int32, model.ProvId);
			db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
			db.AddInParameter(dbCommand, "BankAccount", DbType.AnsiString, model.BankAccount);
			db.AddInParameter(dbCommand, "BankName", DbType.String, model.BankName);
			db.AddInParameter(dbCommand, "BankAddress", DbType.String, model.BankAddress);
			db.AddInParameter(dbCommand, "Manager", DbType.String, model.Manager);
			db.AddInParameter(dbCommand, "ManagerPhone", DbType.AnsiString, model.ManagerPhone);
			db.AddInParameter(dbCommand, "ProviderType", DbType.String, model.ProviderType);
			db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
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
		public bool Delete(int ProvId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrgProviderInfo ");
			strSql.Append(" where ProvId=@ProvId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ProvId", DbType.Int32,ProvId);
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
		public bool DeleteList(string ProvIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from OrgProviderInfo ");
			strSql.Append(" where ProvId in ("+ProvIdlist + ")  ");
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
		public Model.OrgProviderInfo GetModel(int ProvId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProvId,OrgId,BankAccount,BankName,BankAddress,Manager,ManagerPhone,ProviderType,AddTime from OrgProviderInfo ");
			strSql.Append(" where ProvId=@ProvId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ProvId", DbType.Int32,ProvId);
			Model.OrgProviderInfo model=null;
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
		public Model.OrgProviderInfo DataRowToModel(DataRow row)
		{
			Model.OrgProviderInfo model=new Model.OrgProviderInfo();
			if (row != null)
			{
				if(row["ProvId"]!=null && row["ProvId"].ToString()!="")
				{
					model.ProvId=Convert.ToInt32(row["ProvId"].ToString());
				}
				if(row["OrgId"]!=null && row["OrgId"].ToString()!="")
				{
					model.OrgId=Convert.ToInt64(row["OrgId"].ToString());
				}
				if(row["BankAccount"]!=null)
				{
					model.BankAccount=row["BankAccount"].ToString();
				}
				if(row["BankName"]!=null)
				{
					model.BankName=row["BankName"].ToString();
				}
				if(row["BankAddress"]!=null)
				{
					model.BankAddress=row["BankAddress"].ToString();
				}
				if(row["Manager"]!=null)
				{
					model.Manager=row["Manager"].ToString();
				}
				if(row["ManagerPhone"]!=null)
				{
					model.ManagerPhone=row["ManagerPhone"].ToString();
				}
				if(row["ProviderType"]!=null)
				{
					model.ProviderType=row["ProviderType"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=Convert.ToDateTime(row["AddTime"].ToString());
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
			strSql.Append("select ProvId,OrgId,BankAccount,BankName,BankAddress,Manager,ManagerPhone,ProviderType,AddTime ");
			strSql.Append(" FROM OrgProviderInfo ");
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
			strSql.Append(" ProvId,OrgId,BankAccount,BankName,BankAddress,Manager,ManagerPhone,ProviderType,AddTime ");
			strSql.Append(" FROM OrgProviderInfo ");
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
			strSql.Append("select count(1) FROM OrgProviderInfo ");
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
				strSql.Append("order by T.ProvId desc");
			}
			strSql.Append(")AS Row, T.*  from OrgProviderInfo T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgProviderInfo");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ProvId");
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
		public List<Model.OrgProviderInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ProvId,OrgId,BankAccount,BankName,BankAddress,Manager,ManagerPhone,ProviderType,AddTime ");
			strSql.Append(" FROM OrgProviderInfo ");
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
			List<Model.OrgProviderInfo> list = new List<Model.OrgProviderInfo>();
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
		public Model.OrgProviderInfo ReaderBind(IDataReader dataReader)
		{
			Model.OrgProviderInfo model=new Model.OrgProviderInfo();
			object ojb; 
			ojb = dataReader["ProvId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ProvId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["OrgId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrgId=Convert.ToInt64(ojb);
			}
			model.BankAccount=dataReader["BankAccount"].ToString();
			model.BankName=dataReader["BankName"].ToString();
			model.BankAddress=dataReader["BankAddress"].ToString();
			model.Manager=dataReader["Manager"].ToString();
			model.ManagerPhone=dataReader["ManagerPhone"].ToString();
			model.ProviderType=dataReader["ProviderType"].ToString();
			ojb = dataReader["AddTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddTime=Convert.ToDateTime(ojb);
			}
			return model;
		}

		#endregion  Method
	}
}

