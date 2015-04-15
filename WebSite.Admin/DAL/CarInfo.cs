/**  版本信息模板在安装目录下，可自行修改。
* CarInfo.cs
*
* 功 能： N/A
* 类 名： CarInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/23 17:54:01   N/A    初版
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
	/// 数据访问类:CarInfo
	/// </summary>
	public partial class CarInfo
	{
		public CarInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(CarId)+1 from CarInfo";
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
		public bool Exists(int CarId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from CarInfo where CarId=@CarId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CarId", DbType.Int32,CarId);
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
		public int Add(Model.CarInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CarInfo(");
			strSql.Append("CarNo,LoadRepeat,CarType,Contacts,Phone,Status)");

			strSql.Append(" values (");
			strSql.Append("@CarNo,@LoadRepeat,@CarType,@Contacts,@Phone,@Status)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CarNo", DbType.AnsiString, model.CarNo);
			db.AddInParameter(dbCommand, "LoadRepeat", DbType.Decimal, model.LoadRepeat);
			db.AddInParameter(dbCommand, "CarType", DbType.Int32, model.CarType);
			db.AddInParameter(dbCommand, "Contacts", DbType.AnsiString, model.Contacts);
			db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, model.Phone);
			db.AddInParameter(dbCommand, "Status", DbType.Int32, model.Status);
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
		public bool Update(Model.CarInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CarInfo set ");
			strSql.Append("CarNo=@CarNo,");
			strSql.Append("LoadRepeat=@LoadRepeat,");
			strSql.Append("CarType=@CarType,");
			strSql.Append("Contacts=@Contacts,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Status=@Status");
			strSql.Append(" where CarId=@CarId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CarId", DbType.Int32, model.CarId);
			db.AddInParameter(dbCommand, "CarNo", DbType.AnsiString, model.CarNo);
			db.AddInParameter(dbCommand, "LoadRepeat", DbType.Decimal, model.LoadRepeat);
			db.AddInParameter(dbCommand, "CarType", DbType.Int32, model.CarType);
			db.AddInParameter(dbCommand, "Contacts", DbType.AnsiString, model.Contacts);
			db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, model.Phone);
			db.AddInParameter(dbCommand, "Status", DbType.Int32, model.Status);
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
		public bool Delete(int CarId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CarInfo ");
			strSql.Append(" where CarId=@CarId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CarId", DbType.Int32,CarId);
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
		public bool DeleteList(string CarIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CarInfo ");
			strSql.Append(" where CarId in ("+CarIdlist + ")  ");
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
		public Model.CarInfo GetModel(int CarId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CarId,CarNo,LoadRepeat,CarType,Contacts,Phone,Status from CarInfo ");
			strSql.Append(" where CarId=@CarId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "CarId", DbType.Int32,CarId);
			Model.CarInfo model=null;
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
		public Model.CarInfo DataRowToModel(DataRow row)
		{
			Model.CarInfo model=new Model.CarInfo();
			if (row != null)
			{
				if(row["CarId"]!=null && row["CarId"].ToString()!="")
				{
					model.CarId=Convert.ToInt32(row["CarId"].ToString());
				}
				if(row["CarNo"]!=null)
				{
					model.CarNo=row["CarNo"].ToString();
				}
				if(row["LoadRepeat"]!=null && row["LoadRepeat"].ToString()!="")
				{
					model.LoadRepeat=Convert.ToDecimal(row["LoadRepeat"].ToString());
				}
				if(row["CarType"]!=null && row["CarType"].ToString()!="")
				{
					model.CarType=Convert.ToInt32(row["CarType"].ToString());
				}
				if(row["Contacts"]!=null)
				{
					model.Contacts=row["Contacts"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
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
			strSql.Append("select CarId,CarNo,LoadRepeat,CarType,Contacts,Phone,Status ");
			strSql.Append(" FROM CarInfo ");
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
			strSql.Append(" CarId,CarNo,LoadRepeat,CarType,Contacts,Phone,Status ");
			strSql.Append(" FROM CarInfo ");
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
			strSql.Append("select count(1) FROM CarInfo ");
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
				strSql.Append("order by T.CarId desc");
			}
			strSql.Append(")AS Row, T.*  from CarInfo T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CarInfo");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CarId");
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
		public List<Model.CarInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select CarId,CarNo,LoadRepeat,CarType,Contacts,Phone,Status ");
			strSql.Append(" FROM CarInfo ");
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
			List<Model.CarInfo> list = new List<Model.CarInfo>();
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
		public Model.CarInfo ReaderBind(IDataReader dataReader)
		{
			Model.CarInfo model=new Model.CarInfo();
			object ojb; 
			ojb = dataReader["CarId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CarId=Convert.ToInt32(ojb);
			}
			model.CarNo=dataReader["CarNo"].ToString();
			ojb = dataReader["LoadRepeat"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LoadRepeat=Convert.ToDecimal(ojb);
			}
			ojb = dataReader["CarType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CarType=Convert.ToInt32(ojb);
			}
			model.Contacts=dataReader["Contacts"].ToString();
			model.Phone=dataReader["Phone"].ToString();
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method


        #region 扩展方法
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string CarId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CarInfo  ");
            strSql.Append(" where CarId in (select * from dbo.SplitToTable('" + CarId + "',',')) ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CarId", DbType.Int32, CarId);
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
        #endregion
	}
}

