/**  版本信息模板在安装目录下，可自行修改。
* CMArticle.cs
*
* 功 能： N/A
* 类 名： CMArticle
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/9/5 9:44:03   N/A    初版
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
	/// 数据访问类:CMArticle
	/// </summary>
	public partial class CMArticle
	{
		public CMArticle()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(AId)+1 from CMArticle";
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
		public bool Exists(int AId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from CMArticle where AId=@AId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AId", DbType.Int32,AId);
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
		public int Add(Model.CMArticle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CMArticle(");
			strSql.Append("ColId,ATId,Title,Description,Author,Source,Content,Hits,Status,IsTop,IsSplendid,PEmplId,CEmplId,AddTime,CheckTime,SeoTitle,SeoKeyword,SeoDes,AttType,OrgId,DisplayTime)");

			strSql.Append(" values (");
			strSql.Append("@ColId,@ATId,@Title,@Description,@Author,@Source,@Content,@Hits,@Status,@IsTop,@IsSplendid,@PEmplId,@CEmplId,@AddTime,@CheckTime,@SeoTitle,@SeoKeyword,@SeoDes,@AttType,@OrgId,@DisplayTime)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "ColId", DbType.Int32, model.ColId);
			db.AddInParameter(dbCommand, "ATId", DbType.Int32, model.ATId);
			db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
			db.AddInParameter(dbCommand, "Description", DbType.String, model.Description);
			db.AddInParameter(dbCommand, "Author", DbType.String, model.Author);
			db.AddInParameter(dbCommand, "Source", DbType.String, model.Source);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
			db.AddInParameter(dbCommand, "Hits", DbType.Int32, model.Hits);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "IsTop", DbType.Byte, model.IsTop);
			db.AddInParameter(dbCommand, "IsSplendid", DbType.Byte, model.IsSplendid);
			db.AddInParameter(dbCommand, "PEmplId", DbType.Int32, model.PEmplId);
			db.AddInParameter(dbCommand, "CEmplId", DbType.Int32, model.CEmplId);
			db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
			db.AddInParameter(dbCommand, "CheckTime", DbType.DateTime, model.CheckTime);
			db.AddInParameter(dbCommand, "SeoTitle", DbType.String, model.SeoTitle);
			db.AddInParameter(dbCommand, "SeoKeyword", DbType.String, model.SeoKeyword);
			db.AddInParameter(dbCommand, "SeoDes", DbType.String, model.SeoDes);
			db.AddInParameter(dbCommand, "AttType", DbType.Byte, model.AttType);
			db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
			db.AddInParameter(dbCommand, "DisplayTime", DbType.Int32, model.DisplayTime);
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
		public bool Update(Model.CMArticle model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CMArticle set ");
			strSql.Append("ColId=@ColId,");
			strSql.Append("ATId=@ATId,");
			strSql.Append("Title=@Title,");
			strSql.Append("Description=@Description,");
			strSql.Append("Author=@Author,");
			strSql.Append("Source=@Source,");
			strSql.Append("Content=@Content,");
			strSql.Append("Hits=@Hits,");
			strSql.Append("Status=@Status,");
			strSql.Append("IsTop=@IsTop,");
			strSql.Append("IsSplendid=@IsSplendid,");
			strSql.Append("PEmplId=@PEmplId,");
			strSql.Append("CEmplId=@CEmplId,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("CheckTime=@CheckTime,");
			strSql.Append("SeoTitle=@SeoTitle,");
			strSql.Append("SeoKeyword=@SeoKeyword,");
			strSql.Append("SeoDes=@SeoDes,");
			strSql.Append("AttType=@AttType,");
			strSql.Append("OrgId=@OrgId,");
			strSql.Append("DisplayTime=@DisplayTime");
			strSql.Append(" where AId=@AId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AId", DbType.Int32, model.AId);
			db.AddInParameter(dbCommand, "ColId", DbType.Int32, model.ColId);
			db.AddInParameter(dbCommand, "ATId", DbType.Int32, model.ATId);
			db.AddInParameter(dbCommand, "Title", DbType.String, model.Title);
			db.AddInParameter(dbCommand, "Description", DbType.String, model.Description);
			db.AddInParameter(dbCommand, "Author", DbType.String, model.Author);
			db.AddInParameter(dbCommand, "Source", DbType.String, model.Source);
			db.AddInParameter(dbCommand, "Content", DbType.String, model.Content);
			db.AddInParameter(dbCommand, "Hits", DbType.Int32, model.Hits);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "IsTop", DbType.Byte, model.IsTop);
			db.AddInParameter(dbCommand, "IsSplendid", DbType.Byte, model.IsSplendid);
			db.AddInParameter(dbCommand, "PEmplId", DbType.Int32, model.PEmplId);
			db.AddInParameter(dbCommand, "CEmplId", DbType.Int32, model.CEmplId);
			db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
			db.AddInParameter(dbCommand, "CheckTime", DbType.DateTime, model.CheckTime);
			db.AddInParameter(dbCommand, "SeoTitle", DbType.String, model.SeoTitle);
			db.AddInParameter(dbCommand, "SeoKeyword", DbType.String, model.SeoKeyword);
			db.AddInParameter(dbCommand, "SeoDes", DbType.String, model.SeoDes);
			db.AddInParameter(dbCommand, "AttType", DbType.Byte, model.AttType);
			db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
			db.AddInParameter(dbCommand, "DisplayTime", DbType.Int32, model.DisplayTime);
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
		public bool Delete(int AId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMArticle ");
			strSql.Append(" where AId=@AId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AId", DbType.Int32,AId);
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
		public bool DeleteList(string AIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CMArticle ");
			strSql.Append(" where AId in ("+AIdlist + ")  ");
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
		public Model.CMArticle GetModel(int AId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AId,ColId,ATId,Title,Description,Author,Source,Content,Hits,Status,IsTop,IsSplendid,PEmplId,CEmplId,AddTime,CheckTime,SeoTitle,SeoKeyword,SeoDes,AttType,OrgId,DisplayTime from CMArticle ");
			strSql.Append(" where AId=@AId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "AId", DbType.Int32,AId);
			Model.CMArticle model=null;
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
		public Model.CMArticle DataRowToModel(DataRow row)
		{
			Model.CMArticle model=new Model.CMArticle();
			if (row != null)
			{
				if(row["AId"]!=null && row["AId"].ToString()!="")
				{
					model.AId=Convert.ToInt32(row["AId"].ToString());
				}
				if(row["ColId"]!=null && row["ColId"].ToString()!="")
				{
					model.ColId=Convert.ToInt32(row["ColId"].ToString());
				}
				if(row["ATId"]!=null && row["ATId"].ToString()!="")
				{
					model.ATId=Convert.ToInt32(row["ATId"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Author"]!=null)
				{
					model.Author=row["Author"].ToString();
				}
				if(row["Source"]!=null)
				{
					model.Source=row["Source"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Hits"]!=null && row["Hits"].ToString()!="")
				{
					model.Hits=Convert.ToInt32(row["Hits"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["IsTop"]!=null && row["IsTop"].ToString()!="")
				{
					model.IsTop=Convert.ToInt32(row["IsTop"].ToString());
				}
				if(row["IsSplendid"]!=null && row["IsSplendid"].ToString()!="")
				{
					model.IsSplendid=Convert.ToInt32(row["IsSplendid"].ToString());
				}
				if(row["PEmplId"]!=null && row["PEmplId"].ToString()!="")
				{
					model.PEmplId=Convert.ToInt32(row["PEmplId"].ToString());
				}
				if(row["CEmplId"]!=null && row["CEmplId"].ToString()!="")
				{
					model.CEmplId=Convert.ToInt32(row["CEmplId"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=Convert.ToDateTime(row["AddTime"].ToString());
				}
				if(row["CheckTime"]!=null && row["CheckTime"].ToString()!="")
				{
					model.CheckTime=Convert.ToDateTime(row["CheckTime"].ToString());
				}
				if(row["SeoTitle"]!=null)
				{
					model.SeoTitle=row["SeoTitle"].ToString();
				}
				if(row["SeoKeyword"]!=null)
				{
					model.SeoKeyword=row["SeoKeyword"].ToString();
				}
				if(row["SeoDes"]!=null)
				{
					model.SeoDes=row["SeoDes"].ToString();
				}
				if(row["AttType"]!=null && row["AttType"].ToString()!="")
				{
					model.AttType=Convert.ToInt32(row["AttType"].ToString());
				}
				if(row["OrgId"]!=null && row["OrgId"].ToString()!="")
				{
					model.OrgId=Convert.ToInt64(row["OrgId"].ToString());
				}
				if(row["DisplayTime"]!=null && row["DisplayTime"].ToString()!="")
				{
					model.DisplayTime=Convert.ToInt32(row["DisplayTime"].ToString());
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
			strSql.Append("select AId,ColId,ATId,Title,Description,Author,Source,Content,Hits,Status,IsTop,IsSplendid,PEmplId,CEmplId,AddTime,CheckTime,SeoTitle,SeoKeyword,SeoDes,AttType,OrgId,DisplayTime ");
			strSql.Append(" FROM CMArticle ");
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
			strSql.Append(" AId,ColId,ATId,Title,Description,Author,Source,Content,Hits,Status,IsTop,IsSplendid,PEmplId,CEmplId,AddTime,CheckTime,SeoTitle,SeoKeyword,SeoDes,AttType,OrgId,DisplayTime ");
			strSql.Append(" FROM CMArticle ");
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
			strSql.Append("select count(1) FROM CMArticle ");
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
				strSql.Append("order by T.AId desc");
			}
			strSql.Append(")AS Row, T.*  from CMArticle T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMArticle");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "AId");
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
		public List<Model.CMArticle> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select AId,ColId,ATId,Title,Description,Author,Source,Content,Hits,Status,IsTop,IsSplendid,PEmplId,CEmplId,AddTime,CheckTime,SeoTitle,SeoKeyword,SeoDes,AttType,OrgId,DisplayTime ");
			strSql.Append(" FROM CMArticle ");
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
			List<Model.CMArticle> list = new List<Model.CMArticle>();
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
		public Model.CMArticle ReaderBind(IDataReader dataReader)
		{
			Model.CMArticle model=new Model.CMArticle();
			object ojb; 
			ojb = dataReader["AId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["ColId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ColId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["ATId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ATId=Convert.ToInt32(ojb);
			}
			model.Title=dataReader["Title"].ToString();
			model.Description=dataReader["Description"].ToString();
			model.Author=dataReader["Author"].ToString();
			model.Source=dataReader["Source"].ToString();
			model.Content=dataReader["Content"].ToString();
			ojb = dataReader["Hits"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Hits=Convert.ToInt32(ojb);
			}
			ojb = dataReader["Status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Status=Convert.ToInt32(ojb);
			}
			ojb = dataReader["IsTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsTop=Convert.ToInt32(ojb);
			}
			ojb = dataReader["IsSplendid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsSplendid=Convert.ToInt32(ojb);
			}
			ojb = dataReader["PEmplId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.PEmplId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["CEmplId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CEmplId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["AddTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AddTime=Convert.ToDateTime(ojb);
			}
			ojb = dataReader["CheckTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CheckTime=Convert.ToDateTime(ojb);
			}
			model.SeoTitle=dataReader["SeoTitle"].ToString();
			model.SeoKeyword=dataReader["SeoKeyword"].ToString();
			model.SeoDes=dataReader["SeoDes"].ToString();
			ojb = dataReader["AttType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.AttType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["OrgId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.OrgId=Convert.ToInt64(ojb);
			}
			ojb = dataReader["DisplayTime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.DisplayTime=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method



        #region ExMethod
        /// <summary>
        /// 获得文章数据
        /// </summary>
        public DataSet GetDateList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,c.ColName,at.ATName from CMArticle a ");
            strSql.Append(" join CMColumn c on c.ColId=a.ColId ");
            strSql.Append(" join CMArticleType at on at.ATId=a.ATId  ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 获得文章数据（含置顶）
        /// </summary>
        public DataSet GetDateListForTop()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select att.AttName,c.ColName,a.* ");
            strSql.Append(" from CMArticle a ");
            strSql.Append(" join CMAttchment att on a.AID=att.AID ");
            strSql.Append(" join CMColumn c on a.ColId=c.ColId ");
            strSql.Append(" order by a.IsTop desc,a.AddTime DESC ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        /// <summary>
        /// 获得文章数据（含置顶）
        /// </summary>
        public string GetDateListForTop(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  row_number() over(order by IsTop desc,b.AddTime desc) as rownum,b.AId,e.EmplName as CEmplName, ");
            strSql.Append(" b.ColId,b.AtId,Title,Description,Author,Content,Hits,b.Status,IsTop,IsSplendid,PEmplId,CEmplId, ");
            strSql.Append(" convert(varchar(10),b.AddTime,120) as AddTime ,convert(varchar(10),b.CheckTime,120) as CheckTime,SeoTitle,DisplayTime, ");
            strSql.Append(" SeoKeyword,b.SeoDes,AttType,c.AtName,d.ColName from  ");
            strSql.Append(" CMArticle b   ");
            strSql.Append("  left join CMArticleType c on b.ATID=c.ATID  ");
            strSql.Append(" left join CMColumn d on b.ColId=d.ColId  ");
            strSql.Append(" left join OrgEmployees e on b.CEmplId=e.EmplId  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return strSql.ToString();
        }
        /// <summary>
        /// 审核/取消审核
        /// </summary>
        /// <param name="aid">文章ID</param>
        /// <param name="status">当前审核状态（0未审核，1已审核）</param>
        /// <returns></returns>
        public bool UpdateState(int aid, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMArticle set ");
            strSql.Append("Status=@status");
            strSql.Append(" where AId=@aid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "status", DbType.Int32, status);
            db.AddInParameter(dbCommand, "aid", DbType.Int32, aid);
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
        /// 设置/取消置顶
        /// </summary>
        /// <param name="aid">文章ID</param>
        /// <param name="top">当前置顶状态（0正常，1置顶）</param>
        /// <returns></returns>
        public bool UpdateTop(int aid, int istop)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMArticle set ");
            strSql.Append("IsTop=@istop");
            strSql.Append(" where AId=@aid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "istop", DbType.Int32, istop);
            db.AddInParameter(dbCommand, "aid", DbType.Int32, aid);
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
        /// 删除商品信息事务方法
        /// </summary>
        /// <param name="pId">商品ID</param>
        /// <returns></returns>
        public bool DeleteArt(string aid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete  CMAttchment where AId in (select * from dbo.SplitToTable('" + aid + "',',')) ");
            strSql.Append("delete  CMArticle where AId in (select * from dbo.SplitToTable('" + aid + "',','))");
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
        /// 审核方法
        /// </summary>
        /// <param name="pIds">商品Id</param>
        /// <param name="status">审核状态</param>
        /// <returns></returns>
        public bool CheckList(string aid, int status, int cemplId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMArticle set Status=@Status,CheckTime=@CheckTime");
            strSql.Append(" ,CEmplId=@CEmplId");
            strSql.Append(" where AId in (select * from SplitToTable(@AId,','))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            var parameter1 = new SqlParameter("@Status", DbType.Int32);
            parameter1.Value = status;
            dbCommand.Parameters.Add(parameter1);
            var parameter2 = new SqlParameter("@CEmplId", DbType.Int32);
            parameter2.Value = cemplId;
            dbCommand.Parameters.Add(parameter2);
            var parameter = new SqlParameter("@AId", DbType.AnsiString);
            parameter.Value = aid;
            dbCommand.Parameters.Add(parameter);
            var parameter3 = new SqlParameter("@CheckTime", DbType.DateTime);
            parameter3.Value = DateTime.Now;
            dbCommand.Parameters.Add(parameter3);
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
        /// 删除文章事务
        /// </summary>
        /// <param name="aId"></param>
        /// <returns></returns>
        public bool DelArticleTran(int aId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete  CMAttchment where AId='" + aId + "' ");
            strSql.Append("delete  CMArticle where AId='" + aId + "' ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    object objDel = db.ExecuteNonQuery(dbCommand, trans);
                    trans.Commit();
                    result = true;
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        /// <summary>
        /// 获得文章访问量
        /// </summary>
        public string GetDateList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  row_number() over(order by Hits desc) as rownum,Title,d.ColName,Hits from  ");
            strSql.Append(" CMArticle b   ");
            strSql.Append(" left join CMColumn d on b.ColId=d.ColId   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return strSql.ToString();
        }

        /// <summary>
        /// 获得文章访问量
        /// </summary>
        public DataSet GetDateListDa(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select  row_number() over(order by Hits desc) as rownum,Title,d.ColName,Hits from  ");
            strSql.Append(" CMArticle b   ");
            strSql.Append(" left join CMColumn d on b.ColId=d.ColId   ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public int GetList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count (*)");
            strSql.Append(" from  CMArticle b   ");
            strSql.Append("  left join CMArticleType c on b.ATID=c.ATID  ");
            strSql.Append(" left join CMColumn d on b.ColId=d.ColId  ");
            strSql.Append(" left join OrgEmployees e on b.CEmplId=e.EmplId  where b.Status=0");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = Convert.ToInt32(obj.ToString());
            }

            return cmdresult;
        }
        #endregion
	}
}

