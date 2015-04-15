/**  版本信息模板在安装目录下，可自行修改。
* S_District.cs
*
* 功 能： N/A
* 类 名： S_District
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-09-27 09:51:44   N/A    初版
*
* 




*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Admin.DAL
{
	/// <summary>
	/// 数据访问类:S_District
	/// </summary>
	public partial class S_District
	{
		public S_District()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long DistrictID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from S_District where DistrictID=@DistrictID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DistrictID", DbType.Int64,DistrictID);
			int cmdresult;
			object obj = db.ExecuteScalar(dbCommand);
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, global::System.DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = Convert.ToInt32(obj.ToString());
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
		public long Add(Model.S_District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into S_District(");
			strSql.Append("DistrictName,CityID,DateCreated,DateUpdated)");

			strSql.Append(" values (");
			strSql.Append("@DistrictName,@CityID,@DateCreated,@DateUpdated)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DistrictName", DbType.String, model.DistrictName);
			db.AddInParameter(dbCommand, "CityID", DbType.Int64, model.CityID);
			db.AddInParameter(dbCommand, "DateCreated", DbType.DateTime, model.DateCreated);
			db.AddInParameter(dbCommand, "DateUpdated", DbType.DateTime, model.DateUpdated);
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
		public bool Update(Model.S_District model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update S_District set ");
			strSql.Append("DistrictName=@DistrictName,");
			strSql.Append("CityID=@CityID,");
			strSql.Append("DateCreated=@DateCreated,");
			strSql.Append("DateUpdated=@DateUpdated");
			strSql.Append(" where DistrictID=@DistrictID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DistrictID", DbType.Int64, model.DistrictID);
			db.AddInParameter(dbCommand, "DistrictName", DbType.String, model.DistrictName);
			db.AddInParameter(dbCommand, "CityID", DbType.Int64, model.CityID);
			db.AddInParameter(dbCommand, "DateCreated", DbType.DateTime, model.DateCreated);
			db.AddInParameter(dbCommand, "DateUpdated", DbType.DateTime, model.DateUpdated);
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
		public bool Delete(long DistrictID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_District ");
			strSql.Append(" where DistrictID=@DistrictID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DistrictID", DbType.Int64,DistrictID);
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
		public bool DeleteList(string DistrictIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from S_District ");
			strSql.Append(" where DistrictID in ("+DistrictIDlist + ")  ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);
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
		public Model.S_District GetModel(long DistrictID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DistrictID,DistrictName,CityID,DateCreated,DateUpdated from S_District ");
			strSql.Append(" where DistrictID=@DistrictID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "DistrictID", DbType.Int64,DistrictID);
			Model.S_District model=null;
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
		public Model.S_District DataRowToModel(DataRow row)
		{
			Model.S_District model=new Model.S_District();
			if (row != null)
			{
				if(row["DistrictID"]!=null && row["DistrictID"].ToString()!="")
				{
					model.DistrictID=long.Parse(row["DistrictID"].ToString());
				}
				if(row["DistrictName"]!=null)
				{
					model.DistrictName=row["DistrictName"].ToString();
				}
				if(row["CityID"]!=null && row["CityID"].ToString()!="")
				{
					model.CityID=long.Parse(row["CityID"].ToString());
				}
				if(row["DateCreated"]!=null && row["DateCreated"].ToString()!="")
				{
					model.DateCreated=DateTime.Parse(row["DateCreated"].ToString());
				}
				if(row["DateUpdated"]!=null && row["DateUpdated"].ToString()!="")
				{
					model.DateUpdated=DateTime.Parse(row["DateUpdated"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DistrictID,DistrictName,CityID,DateCreated,DateUpdated ");
			strSql.Append(" FROM S_District ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" DistrictID,DistrictName,CityID,DateCreated,DateUpdated ");
			strSql.Append(" FROM S_District ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) FROM S_District ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
        //public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("SELECT * FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby );
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.DistrictID desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from S_District T ");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "S_District");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "DistrictID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<Model.S_District> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select DistrictID,DistrictName,CityID,DateCreated,DateUpdated ");
			strSql.Append(" FROM S_District ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<Model.S_District> list = new List<Model.S_District>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
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
		public Model.S_District ReaderBind(IDataReader dataReader)
		{
			Model.S_District model=new Model.S_District();
			object ojb; 
			ojb = dataReader["DistrictID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DistrictID=Convert.ToInt64(ojb);
			}
			model.DistrictName=dataReader["DistrictName"].ToString();
			ojb = dataReader["CityID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CityID=Convert.ToInt64(ojb);
			}
			ojb = dataReader["DateCreated"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateCreated=(DateTime)ojb;
			}
			ojb = dataReader["DateUpdated"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DateUpdated=(DateTime)ojb;
			}
			return model;
		}

		#endregion  Method
	}
}

