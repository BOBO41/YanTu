/**  版本信息模板在安装目录下，可自行修改。
* UserAccount.cs
*
* 功 能： N/A
* 类 名： UserAccount
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-10 10:07:43   N/A    初版
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
	/// 数据访问类:UserAccount
	/// </summary>
	public partial class UserAccount
	{
		public UserAccount()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long UID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from UserAccount where UID=@UID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "UID", DbType.Int64,UID);
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
		public long Add(Model.UserAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserAccount(");
			strSql.Append("RealName,Sex,Email,PassWord,Status,CreateDate,OpenId,Mobile,Age,Addr,Descri,Integral)");

			strSql.Append(" values (");
			strSql.Append("@RealName,@Sex,@Email,@PassWord,@Status,@CreateDate,@OpenId,@Mobile,@Age,@Addr,@Descri,@Integral)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "RealName", DbType.String, model.RealName);
			db.AddInParameter(dbCommand, "Sex", DbType.Int16, model.Sex);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.AddInParameter(dbCommand, "PassWord", DbType.AnsiString, model.PassWord);
			db.AddInParameter(dbCommand, "Status", DbType.Int16, model.Status);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "OpenId", DbType.AnsiString, model.OpenId);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "Age", DbType.Int32, model.Age);
			db.AddInParameter(dbCommand, "Addr", DbType.String, model.Addr);
			db.AddInParameter(dbCommand, "Descri", DbType.String, model.Descri);
			db.AddInParameter(dbCommand, "Integral", DbType.Decimal, model.Integral);
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
		public bool Update(Model.UserAccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserAccount set ");
			strSql.Append("RealName=@RealName,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Email=@Email,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("OpenId=@OpenId,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Age=@Age,");
			strSql.Append("Addr=@Addr,");
			strSql.Append("Descri=@Descri,");
			strSql.Append("Integral=@Integral");
			strSql.Append(" where UID=@UID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "UID", DbType.Int64, model.UID);
			db.AddInParameter(dbCommand, "RealName", DbType.String, model.RealName);
			db.AddInParameter(dbCommand, "Sex", DbType.Int16, model.Sex);
			db.AddInParameter(dbCommand, "Email", DbType.AnsiString, model.Email);
			db.AddInParameter(dbCommand, "PassWord", DbType.AnsiString, model.PassWord);
			db.AddInParameter(dbCommand, "Status", DbType.Int16, model.Status);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "OpenId", DbType.AnsiString, model.OpenId);
			db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
			db.AddInParameter(dbCommand, "Age", DbType.Int32, model.Age);
			db.AddInParameter(dbCommand, "Addr", DbType.String, model.Addr);
			db.AddInParameter(dbCommand, "Descri", DbType.String, model.Descri);
			db.AddInParameter(dbCommand, "Integral", DbType.Decimal, model.Integral);
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
		public bool Delete(long UID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserAccount ");
			strSql.Append(" where UID=@UID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "UID", DbType.Int64,UID);
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
		public bool DeleteList(string UIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserAccount ");
			strSql.Append(" where UID in ("+UIDlist + ")  ");
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
		public Model.UserAccount GetModel(long UID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UID,RealName,Sex,Email,PassWord,Status,CreateDate,OpenId,Mobile,Age,Addr,Descri,Integral from UserAccount ");
			strSql.Append(" where UID=@UID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "UID", DbType.Int64,UID);
			Model.UserAccount model=null;
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
		public Model.UserAccount DataRowToModel(DataRow row)
		{
			Model.UserAccount model=new Model.UserAccount();
			if (row != null)
			{
				if(row["UID"]!=null && row["UID"].ToString()!="")
				{
					model.UID=Convert.ToInt64(row["UID"].ToString());
				}
				if(row["RealName"]!=null)
				{
					model.RealName=row["RealName"].ToString();
				}
				if(row["Sex"]!=null && row["Sex"].ToString()!="")
				{
					model.Sex=Convert.ToInt32(row["Sex"].ToString());
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=Convert.ToDateTime(row["CreateDate"].ToString());
				}
				if(row["OpenId"]!=null)
				{
					model.OpenId=row["OpenId"].ToString();
				}
				if(row["Mobile"]!=null)
				{
					model.Mobile=row["Mobile"].ToString();
				}
				if(row["Age"]!=null && row["Age"].ToString()!="")
				{
					model.Age=Convert.ToInt32(row["Age"].ToString());
				}
				if(row["Addr"]!=null)
				{
					model.Addr=row["Addr"].ToString();
				}
				if(row["Descri"]!=null)
				{
					model.Descri=row["Descri"].ToString();
				}
				if(row["Integral"]!=null && row["Integral"].ToString()!="")
				{
					model.Integral=Convert.ToDecimal(row["Integral"].ToString());
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
			strSql.Append("select UID,RealName,Sex,Email,PassWord,Status,CreateDate,OpenId,Mobile,Age,Addr,Descri,Integral ");
			strSql.Append(" FROM UserAccount ");
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
			strSql.Append(" UID,RealName,Sex,Email,PassWord,Status,CreateDate,OpenId,Mobile,Age,Addr,Descri,Integral ");
			strSql.Append(" FROM UserAccount ");
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
			strSql.Append("select count(1) FROM UserAccount ");
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
				strSql.Append("order by T.UID desc");
			}
			strSql.Append(")AS Row, T.*  from UserAccount T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "UserAccount");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "UID");
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
		public List<Model.UserAccount> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UID,RealName,Sex,Email,PassWord,Status,CreateDate,OpenId,Mobile,Age,Addr,Descri,Integral ");
			strSql.Append(" FROM UserAccount ");
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
			List<Model.UserAccount> list = new List<Model.UserAccount>();
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
		public Model.UserAccount ReaderBind(IDataReader dataReader)
		{
			Model.UserAccount model=new Model.UserAccount();
			object ojb; 
			ojb = dataReader["UID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.UID=Convert.ToInt64(ojb);
			}
			model.RealName=dataReader["RealName"].ToString();
			ojb = dataReader["Sex"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Sex=Convert.ToInt32(ojb);
			}
			model.Email=dataReader["Email"].ToString();
			model.PassWord=dataReader["PassWord"].ToString();
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
			model.OpenId=dataReader["OpenId"].ToString();
			model.Mobile=dataReader["Mobile"].ToString();
			ojb = dataReader["Age"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Age=Convert.ToInt32(ojb);
			}
			model.Addr=dataReader["Addr"].ToString();
			model.Descri=dataReader["Descri"].ToString();
			ojb = dataReader["Integral"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Integral=Convert.ToDecimal(ojb);
			}
			return model;
		}

		#endregion  Method
        #region 扩展方法

        /// <summary>
        /// 批量修改数据
        /// </summary>
        public bool UpdateList(string uiDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserAccount ");
            strSql.Append("set Status=2 where UID in (" + uiDlist + ")  ");
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
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// </summary>
        public string GetListUserAccount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select row_number() over(order by  a.CreateDate desc,a.UID DESC) as rownum,a.UID,RealName,Email,PassWord,Status,Mobile, ");
            strSql.Append("convert(varchar(10),CreateDate,120) as CreateDate,OpenId  ");
            
            strSql.Append(" FROM UserAccount a  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            return strSql.ToString();
        }
        /// <summary>
        /// 是否存在手机号（用户名）
        /// </summary>
        public bool ExistsMobile(string Mobile)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserAccount where Mobile=@Mobile ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Mobile", DbType.String, Mobile);
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
        /// 根据手机号（用户名）得到一个对象实体
        /// </summary>
        public Model.UserAccount GetModelforMobile(string Mobile)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UID,RealName,Email,PassWord,Status,CreateDate,OpenId,Mobile from UserAccount ");
            strSql.Append(" where Mobile=@Mobile ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Mobile", DbType.String, Mobile);
            Model.UserAccount model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }
        #endregion
	}
}

