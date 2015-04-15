/**  版本信息模板在安装目录下，可自行修改。
* UserPointDetail.cs
*
* 功 能： N/A
* 类 名： UserPointDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/3/7 15:54:36   N/A    初版
*
* Copyright (c) 2013 Wiimedia Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：西安微媒软件有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
namespace ECommerce.CM.DAL
{
	/// <summary>
	/// 数据访问类:UserPointDetail
	/// </summary>
	public partial class UserPointDetail
	{
		public UserPointDetail()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists()
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from UserPointDetail where PDID=@PDID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PDID", DbType.Int32,PDID);
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
		public int Add(ECommerce.CM.Model.UserPointDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserPointDetail(");
			strSql.Append("UID,Point,Datetime,FlagType,Price,RDID)");

			strSql.Append(" values (");
			strSql.Append("@UID,@Point,@Datetime,@FlagType,@Price,@RDID)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "UID", DbType.Int32, model.UID);
			db.AddInParameter(dbCommand, "Point", DbType.String, model.Point);
			db.AddInParameter(dbCommand, "Datetime", DbType.DateTime, model.Datetime);
			db.AddInParameter(dbCommand, "FlagType", DbType.Int32, model.FlagType);
			db.AddInParameter(dbCommand, "Price", DbType.Currency, model.Price);
			db.AddInParameter(dbCommand, "RDID", DbType.Int32, model.RDID);
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
		public bool Update(ECommerce.CM.Model.UserPointDetail model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserPointDetail set ");
			strSql.Append("UID=@UID,");
			strSql.Append("Point=@Point,");
			strSql.Append("Datetime=@Datetime,");
			strSql.Append("FlagType=@FlagType,");
			strSql.Append("Price=@Price,");
			strSql.Append("RDID=@RDID");
			strSql.Append(" where PDID=@PDID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PDID", DbType.Int32, model.PDID);
			db.AddInParameter(dbCommand, "UID", DbType.Int32, model.UID);
			db.AddInParameter(dbCommand, "Point", DbType.String, model.Point);
			db.AddInParameter(dbCommand, "Datetime", DbType.DateTime, model.Datetime);
			db.AddInParameter(dbCommand, "FlagType", DbType.Int32, model.FlagType);
			db.AddInParameter(dbCommand, "Price", DbType.Currency, model.Price);
			db.AddInParameter(dbCommand, "RDID", DbType.Int32, model.RDID);
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
		public bool Delete(int PDID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserPointDetail ");
			strSql.Append(" where PDID=@PDID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PDID", DbType.Int32,PDID);
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
		public bool DeleteList(string PDIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserPointDetail ");
			strSql.Append(" where PDID in ("+PDIDlist + ")  ");
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
		public ECommerce.CM.Model.UserPointDetail GetModel(int PDID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PDID,UID,Point,Datetime,FlagType,Price,RDID from UserPointDetail ");
			strSql.Append(" where PDID=@PDID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "PDID", DbType.Int32,PDID);
			ECommerce.CM.Model.UserPointDetail model=null;
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
		public ECommerce.CM.Model.UserPointDetail DataRowToModel(DataRow row)
		{
			ECommerce.CM.Model.UserPointDetail model=new ECommerce.CM.Model.UserPointDetail();
			if (row != null)
			{
				if(row["PDID"]!=null && row["PDID"].ToString()!="")
				{
					model.PDID=Convert.ToInt32(row["PDID"].ToString());
				}
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=Convert.ToInt32(row["UID"].ToString());
				}
				if(row["Point"]!=null)
				{
					model.Point=row["Point"].ToString();
				}
				if(row["Datetime"]!=null && row["Datetime"].ToString()!="")
				{
					model.Datetime=Convert.ToDateTime(row["Datetime"].ToString());
				}
				if(row["FlagType"]!=null && row["FlagType"].ToString()!="")
				{
					model.FlagType=Convert.ToInt32(row["FlagType"].ToString());
				}
				if(row["Price"]!=null && row["Price"].ToString()!="")
				{
					model.Price=Convert.ToDecimal(row["Price"].ToString());
				}
				if(row["RDID"]!=null && row["RDID"].ToString()!="")
				{
					model.RDID=Convert.ToInt32(row["RDID"].ToString());
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
			strSql.Append("select PDID,UID,Point,Datetime,FlagType,Price,RDID ");
			strSql.Append(" FROM UserPointDetail ");
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
			strSql.Append(" PDID,UID,Point,Datetime,FlagType,Price,RDID ");
			strSql.Append(" FROM UserPointDetail ");
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
			strSql.Append("select count(1) FROM UserPointDetail ");
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
				strSql.Append("order by T.PDID desc");
			}
			strSql.Append(")AS Row, T.*  from UserPointDetail T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "UserPointDetail");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "PDID");
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
		public List<ECommerce.CM.Model.UserPointDetail> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PDID,UID,Point,Datetime,FlagType,Price,RDID ");
			strSql.Append(" FROM UserPointDetail ");
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
			List<ECommerce.CM.Model.UserPointDetail> list = new List<ECommerce.CM.Model.UserPointDetail>();
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
		public ECommerce.CM.Model.UserPointDetail ReaderBind(IDataReader dataReader)
		{
			ECommerce.CM.Model.UserPointDetail model=new ECommerce.CM.Model.UserPointDetail();
			object ojb; 
			ojb = dataReader["PDID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PDID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["UID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UID=Convert.ToInt32(ojb);
			}
			model.Point=dataReader["Point"].ToString();
			ojb = dataReader["Datetime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Datetime=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["FlagType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FlagType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["Price"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Price=Convert.ToDecimal(ojb);
			}
			ojb = dataReader["RDID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.RDID=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method
        #region ExMethod
        /// <summary>
        /// 获取用户积分详细信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetDateList(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Point,Datetime,FlagType from UserPointDetail ");
            strSql.Append(" where UID=" + UID + " ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 按月份获取用户积分详细信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetDateListByMonth(int month, int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from UserPointDetail ");
            strSql.Append(" where month(Datetime)='" + month + "' and UID=" + UID + " ");
            strSql.Append(" order by Datetime ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 按月份获取用户积分详细信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetDateListByMonthandYear(string month, int year, int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from UserPointDetail ");
            strSql.Append(" where UID=" + UID + " ");
            strSql.Append(" and month(Datetime)='" + month + "' ");
            if (year != 0)
            {
                strSql.Append(" and year(Datetime)='" + year + "'");
            }

            strSql.Append(" order by Datetime ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 按月份获取用户积分详细信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetDateListCount(int year, int month, int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(cast(Point as int)) as PointCount,sum(Price) as PriceCount from UserPointDetail ");
            strSql.Append(" where month(Datetime)='" + month + "' and year(Datetime)='" + year + "' and UID=" + UID + " ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion

	}
}

