/**  版本信息模板在安装目录下，可自行修改。
* RegisterUserInfo.cs
*
* 功 能： N/A
* 类 名： RegisterUserInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/18 14:05:44   N/A    初版
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
	/// 数据访问类:RegisterUserInfo
	/// </summary>
	public partial class RegisterUserInfo
	{
		public RegisterUserInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(RUID)+1 from RegisterUserInfo";
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
		public bool Exists(int RUID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from RegisterUserInfo where RUID=@RUID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "RUID", DbType.Int32,RUID);
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
		public int Add(Model.RegisterUserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RegisterUserInfo(");
			strSql.Append("ProvinceId,CityId,DistrictId,Address,Phone,Addtime,Name)");

			strSql.Append(" values (");
			strSql.Append("@ProvinceId,@CityId,@DistrictId,@Address,@Phone,@Addtime,@Name)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ProvinceId", DbType.String, model.ProvinceId);
			db.AddInParameter(dbCommand, "CityId", DbType.String, model.CityId);
			db.AddInParameter(dbCommand, "DistrictId", DbType.AnsiString, model.DistrictId);
			db.AddInParameter(dbCommand, "Address", DbType.String, model.Address);
			db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, model.Phone);
			db.AddInParameter(dbCommand, "Addtime", DbType.DateTime, model.Addtime);
			db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
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
		public bool Update(Model.RegisterUserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RegisterUserInfo set ");
			strSql.Append("ProvinceId=@ProvinceId,");
			strSql.Append("CityId=@CityId,");
			strSql.Append("DistrictId=@DistrictId,");
			strSql.Append("Address=@Address,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Addtime=@Addtime,");
			strSql.Append("Name=@Name");
			strSql.Append(" where RUID=@RUID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "RUID", DbType.Int32, model.RUID);
			db.AddInParameter(dbCommand, "ProvinceId", DbType.String, model.ProvinceId);
			db.AddInParameter(dbCommand, "CityId", DbType.String, model.CityId);
			db.AddInParameter(dbCommand, "DistrictId", DbType.AnsiString, model.DistrictId);
			db.AddInParameter(dbCommand, "Address", DbType.String, model.Address);
			db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, model.Phone);
			db.AddInParameter(dbCommand, "Addtime", DbType.DateTime, model.Addtime);
			db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
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
		public bool Delete(int RUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RegisterUserInfo ");
			strSql.Append(" where RUID=@RUID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "RUID", DbType.Int32,RUID);
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
		public bool DeleteList(string RUIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RegisterUserInfo ");
			strSql.Append(" where RUID in ("+RUIDlist + ")  ");
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
		public Model.RegisterUserInfo GetModel(int RUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RUID,ProvinceId,CityId,DistrictId,Address,Phone,Addtime,Name from RegisterUserInfo ");
			strSql.Append(" where RUID=@RUID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "RUID", DbType.Int32,RUID);
			Model.RegisterUserInfo model=null;
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
		public Model.RegisterUserInfo DataRowToModel(DataRow row)
		{
			Model.RegisterUserInfo model=new Model.RegisterUserInfo();
			if (row != null)
			{
				if(row["RUID"]!=null && row["RUID"].ToString()!="")
				{
					model.RUID=Convert.ToInt32(row["RUID"].ToString());
				}
				if(row["ProvinceId"]!=null)
				{
					model.ProvinceId=row["ProvinceId"].ToString();
				}
				if(row["CityId"]!=null)
				{
					model.CityId=row["CityId"].ToString();
				}
				if(row["DistrictId"]!=null)
				{
					model.DistrictId=row["DistrictId"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Addtime"]!=null && row["Addtime"].ToString()!="")
				{
					model.Addtime=Convert.ToDateTime(row["Addtime"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
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
			strSql.Append("select RUID,ProvinceId,CityId,DistrictId,Address,Phone,Addtime,Name ");
			strSql.Append(" FROM RegisterUserInfo ");
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
			strSql.Append(" RUID,ProvinceId,CityId,DistrictId,Address,Phone,Addtime,Name ");
			strSql.Append(" FROM RegisterUserInfo ");
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
			strSql.Append("select count(1) FROM RegisterUserInfo ");
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
				strSql.Append("order by T.RUID desc");
			}
			strSql.Append(")AS Row, T.*  from RegisterUserInfo T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "RegisterUserInfo");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "RUID");
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
		public List<Model.RegisterUserInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RUID,ProvinceId,CityId,DistrictId,Address,Phone,Addtime,Name ");
			strSql.Append(" FROM RegisterUserInfo ");
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
			List<Model.RegisterUserInfo> list = new List<Model.RegisterUserInfo>();
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
		public Model.RegisterUserInfo ReaderBind(IDataReader dataReader)
		{
			Model.RegisterUserInfo model=new Model.RegisterUserInfo();
			object ojb; 
			ojb = dataReader["RUID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RUID=Convert.ToInt32(ojb);
			}
			model.ProvinceId=dataReader["ProvinceId"].ToString();
			model.CityId=dataReader["CityId"].ToString();
			model.DistrictId=dataReader["DistrictId"].ToString();
			model.Address=dataReader["Address"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			ojb = dataReader["Addtime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Addtime=Convert.ToDateTime(ojb);
			}
			model.Name=dataReader["Name"].ToString();
			return model;
		}

		#endregion  Method
	}
}

