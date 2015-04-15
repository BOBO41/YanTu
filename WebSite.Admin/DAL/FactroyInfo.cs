/**  版本信息模板在安装目录下，可自行修改。
* FactroyInfo.cs
*
* 功 能： N/A
* 类 名： FactroyInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-10-11 09:58:18   N/A    初版
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
	/// 数据访问类:FactroyInfo
	/// </summary>
	public partial class FactroyInfo
	{
		public FactroyInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(FIID)+1 from FactroyInfo";
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
		public bool Exists(int FIID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from FactroyInfo where FIID=@FIID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "FIID", DbType.Int32,FIID);
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
		public int Add(Model.FactroyInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FactroyInfo(");
			strSql.Append("FacName,Contact,ConCell,ConAddr,Status,CreateDate,Area,Business,QualificationLevel,FacType,S_City,S_District,S_Province,IsTop,latlng,PassWord,ShareCount)");

			strSql.Append(" values (");
			strSql.Append("@FacName,@Contact,@ConCell,@ConAddr,@Status,@CreateDate,@Area,@Business,@QualificationLevel,@FacType,@S_City,@S_District,@S_Province,@IsTop,@latlng,@PassWord,@ShareCount)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "FacName", DbType.String, model.FacName);
			db.AddInParameter(dbCommand, "Contact", DbType.String, model.Contact);
			db.AddInParameter(dbCommand, "ConCell", DbType.AnsiString, model.ConCell);
			db.AddInParameter(dbCommand, "ConAddr", DbType.String, model.ConAddr);
			db.AddInParameter(dbCommand, "Status", DbType.Int16, model.Status);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "Area", DbType.String, model.Area);
			db.AddInParameter(dbCommand, "Business", DbType.String, model.Business);
			db.AddInParameter(dbCommand, "QualificationLevel", DbType.String, model.QualificationLevel);
			db.AddInParameter(dbCommand, "FacType", DbType.Int16, model.FacType);
			db.AddInParameter(dbCommand, "S_City", DbType.Int32, model.S_City);
			db.AddInParameter(dbCommand, "S_District", DbType.Int32, model.S_District);
			db.AddInParameter(dbCommand, "S_Province", DbType.Int32, model.S_Province);
			db.AddInParameter(dbCommand, "IsTop", DbType.Boolean, model.IsTop);
			db.AddInParameter(dbCommand, "latlng", DbType.AnsiString, model.latlng);
			db.AddInParameter(dbCommand, "PassWord", DbType.AnsiString, model.PassWord);
			db.AddInParameter(dbCommand, "ShareCount", DbType.Int32, model.ShareCount);
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
		public bool Update(Model.FactroyInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FactroyInfo set ");
			strSql.Append("FacName=@FacName,");
			strSql.Append("Contact=@Contact,");
			strSql.Append("ConCell=@ConCell,");
			strSql.Append("ConAddr=@ConAddr,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Area=@Area,");
			strSql.Append("Business=@Business,");
			strSql.Append("QualificationLevel=@QualificationLevel,");
			strSql.Append("FacType=@FacType,");
			strSql.Append("S_City=@S_City,");
			strSql.Append("S_District=@S_District,");
			strSql.Append("S_Province=@S_Province,");
			strSql.Append("IsTop=@IsTop,");
			strSql.Append("latlng=@latlng,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("ShareCount=@ShareCount");
			strSql.Append(" where FIID=@FIID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "FIID", DbType.Int32, model.FIID);
			db.AddInParameter(dbCommand, "FacName", DbType.String, model.FacName);
			db.AddInParameter(dbCommand, "Contact", DbType.String, model.Contact);
			db.AddInParameter(dbCommand, "ConCell", DbType.AnsiString, model.ConCell);
			db.AddInParameter(dbCommand, "ConAddr", DbType.String, model.ConAddr);
			db.AddInParameter(dbCommand, "Status", DbType.Int16, model.Status);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "Area", DbType.String, model.Area);
			db.AddInParameter(dbCommand, "Business", DbType.String, model.Business);
			db.AddInParameter(dbCommand, "QualificationLevel", DbType.String, model.QualificationLevel);
			db.AddInParameter(dbCommand, "FacType", DbType.Int16, model.FacType);
			db.AddInParameter(dbCommand, "S_City", DbType.Int32, model.S_City);
			db.AddInParameter(dbCommand, "S_District", DbType.Int32, model.S_District);
			db.AddInParameter(dbCommand, "S_Province", DbType.Int32, model.S_Province);
			db.AddInParameter(dbCommand, "IsTop", DbType.Boolean, model.IsTop);
			db.AddInParameter(dbCommand, "latlng", DbType.AnsiString, model.latlng);
			db.AddInParameter(dbCommand, "PassWord", DbType.AnsiString, model.PassWord);
			db.AddInParameter(dbCommand, "ShareCount", DbType.Int32, model.ShareCount);
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
		public bool Delete(int FIID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FactroyInfo ");
			strSql.Append(" where FIID=@FIID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "FIID", DbType.Int32,FIID);
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
		/*
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string FIIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from FactroyInfo ");
			strSql.Append(" where FIID in ("+FIIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}*/

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.FactroyInfo GetModel(int FIID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FIID,FacName,Contact,ConCell,ConAddr,Status,CreateDate,Area,Business,QualificationLevel,FacType,S_City,S_District,S_Province,IsTop,latlng,PassWord,ShareCount from FactroyInfo ");
			strSql.Append(" where FIID=@FIID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "FIID", DbType.Int32,FIID);
			Model.FactroyInfo model=null;
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
		public Model.FactroyInfo DataRowToModel(DataRow row)
		{
			Model.FactroyInfo model=new Model.FactroyInfo();
			if (row != null)
			{
				if(row["FIID"]!=null && row["FIID"].ToString()!="")
				{
					model.FIID=Convert.ToInt32(row["FIID"].ToString());
				}
				if(row["FacName"]!=null)
				{
					model.FacName=row["FacName"].ToString();
				}
				if(row["Contact"]!=null)
				{
					model.Contact=row["Contact"].ToString();
				}
				if(row["ConCell"]!=null)
				{
					model.ConCell=row["ConCell"].ToString();
				}
				if(row["ConAddr"]!=null)
				{
					model.ConAddr=row["ConAddr"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=Convert.ToDateTime(row["CreateDate"].ToString());
				}
				if(row["Area"]!=null)
				{
					model.Area=row["Area"].ToString();
				}
				if(row["Business"]!=null)
				{
					model.Business=row["Business"].ToString();
				}
				if(row["QualificationLevel"]!=null)
				{
					model.QualificationLevel=row["QualificationLevel"].ToString();
				}
				if(row["FacType"]!=null && row["FacType"].ToString()!="")
				{
					model.FacType=Convert.ToInt32(row["FacType"].ToString());
				}
				if(row["S_City"]!=null && row["S_City"].ToString()!="")
				{
					model.S_City=Convert.ToInt32(row["S_City"].ToString());
				}
				if(row["S_District"]!=null && row["S_District"].ToString()!="")
				{
					model.S_District=Convert.ToInt32(row["S_District"].ToString());
				}
				if(row["S_Province"]!=null && row["S_Province"].ToString()!="")
				{
					model.S_Province=Convert.ToInt32(row["S_Province"].ToString());
				}
				if(row["IsTop"]!=null && row["IsTop"].ToString()!="")
				{
					if((row["IsTop"].ToString()=="1")||(row["IsTop"].ToString().ToLower()=="true"))
					{
						model.IsTop=true;
					}
					else
					{
						model.IsTop=false;
					}
				}
				if(row["latlng"]!=null)
				{
					model.latlng=row["latlng"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["ShareCount"]!=null && row["ShareCount"].ToString()!="")
				{
					model.ShareCount=Convert.ToInt32(row["ShareCount"].ToString());
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
			strSql.Append("select FIID,FacName,Contact,ConCell,ConAddr,Status,CreateDate,Area,Business,QualificationLevel,FacType,S_City,S_District,S_Province,IsTop,latlng,PassWord,ShareCount ");
			strSql.Append(" FROM FactroyInfo ");
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
			strSql.Append(" FIID,FacName,Contact,ConCell,ConAddr,Status,CreateDate,Area,Business,QualificationLevel,FacType,S_City,S_District,S_Province,IsTop,latlng,PassWord,ShareCount ");
			strSql.Append(" FROM FactroyInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM FactroyInfo ");
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
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.FIID desc");
			}
			strSql.Append(")AS Row, T.*  from FactroyInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}*/

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "FactroyInfo");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "FIID");
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
		public List<Model.FactroyInfo> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FIID,FacName,Contact,ConCell,ConAddr,Status,CreateDate,Area,Business,QualificationLevel,FacType,S_City,S_District,S_Province,IsTop,latlng,PassWord,ShareCount ");
			strSql.Append(" FROM FactroyInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<Model.FactroyInfo> list = new List<Model.FactroyInfo>();
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
		public Model.FactroyInfo ReaderBind(IDataReader dataReader)
		{
			Model.FactroyInfo model=new Model.FactroyInfo();
			object ojb; 
			ojb = dataReader["FIID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FIID=Convert.ToInt32(ojb);
			}
			model.FacName=dataReader["FacName"].ToString();
			model.Contact=dataReader["Contact"].ToString();
			model.ConCell=dataReader["ConCell"].ToString();
			model.ConAddr=dataReader["ConAddr"].ToString();
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
			model.Area=dataReader["Area"].ToString();
			model.Business=dataReader["Business"].ToString();
			model.QualificationLevel=dataReader["QualificationLevel"].ToString();
			ojb = dataReader["FacType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.FacType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["S_City"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.S_City=Convert.ToInt32(ojb);
			}
			ojb = dataReader["S_District"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.S_District=Convert.ToInt32(ojb);
			}
			ojb = dataReader["S_Province"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.S_Province=Convert.ToInt32(ojb);
			}
			ojb = dataReader["IsTop"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IsTop=(bool)ojb;
			}
			model.latlng=dataReader["latlng"].ToString();
			model.PassWord=dataReader["PassWord"].ToString();
			ojb = dataReader["ShareCount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ShareCount=Convert.ToInt32(ojb);
			}
			return model;
		}

		#endregion  Method
        #region ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListFactroy(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FIID,FacName,Contact,IsTop,ConCell,ConAddr,Status,CreateDate,Area,Business,QualificationLevel,FacType,ShareCount, ");
            strSql.Append("(select CityName from S_City where CityID=S_City ) as S_City,(select DistrictName from S_District where DistrictID=S_District ) as S_District,");
            strSql.Append(" (select ProvinceName from S_Province where ProvinceID=S_Province ) as  S_Province ");
            strSql.Append(" FROM FactroyInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }
        #endregion
	}
}

