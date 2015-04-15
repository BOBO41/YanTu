/**  版本信息模板在安装目录下，可自行修改。
* SYS_DepartmentInfo.cs
*
* 功 能： N/A
* 类 名： SYS_DepartmentInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-07-24 16:01:02   N/A    初版
*
* 




*/

//using Maticsoft.DBUtility;//Please add references

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Admin.DAL
{
	/// <summary>
	/// 数据访问类:SYS_DepartmentInfo
	/// </summary>
	public partial class SYS_DepartmentInfo
	{
		public SYS_DepartmentInfo()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(Dpt_Id)+1 from SYS_DepartmentInfo";
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
		public bool Exists(int Dpt_Id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from SYS_DepartmentInfo where Dpt_Id=@Dpt_Id ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "Dpt_Id", DbType.Int32,Dpt_Id);
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
		public int Add(Model.SYS_DepartmentInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_DepartmentInfo(");
			strSql.Append("Dpt_Name,Dpt_ParentId,Dpt_Level,Dpt_SecurityID)");

			strSql.Append(" values (");
			strSql.Append("@Dpt_Name,@Dpt_ParentId,@Dpt_Level,@Dpt_SecurityID)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "Dpt_Name", DbType.String, model.Dpt_Name);
			db.AddInParameter(dbCommand, "Dpt_ParentId", DbType.Int32, model.Dpt_ParentId);
			db.AddInParameter(dbCommand, "Dpt_Level", DbType.Int32, model.Dpt_Level);
			db.AddInParameter(dbCommand, "Dpt_SecurityID", DbType.AnsiString, model.Dpt_SecurityID);
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
		public bool Update(Model.SYS_DepartmentInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_DepartmentInfo set ");
			strSql.Append("Dpt_Name=@Dpt_Name,");
			strSql.Append("Dpt_ParentId=@Dpt_ParentId,");
			strSql.Append("Dpt_Level=@Dpt_Level,");
			strSql.Append("Dpt_SecurityID=@Dpt_SecurityID");
			strSql.Append(" where Dpt_Id=@Dpt_Id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "Dpt_Id", DbType.Int32, model.Dpt_Id);
			db.AddInParameter(dbCommand, "Dpt_Name", DbType.String, model.Dpt_Name);
			db.AddInParameter(dbCommand, "Dpt_ParentId", DbType.Int32, model.Dpt_ParentId);
			db.AddInParameter(dbCommand, "Dpt_Level", DbType.Int32, model.Dpt_Level);
			db.AddInParameter(dbCommand, "Dpt_SecurityID", DbType.AnsiString, model.Dpt_SecurityID);
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
		public bool Delete(int Dpt_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_DepartmentInfo ");
			strSql.Append(" where Dpt_Id=@Dpt_Id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "Dpt_Id", DbType.Int32,Dpt_Id);
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
		public bool DeleteList(string Dpt_Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_DepartmentInfo ");
			strSql.Append(" where Dpt_Id in ("+Dpt_Idlist + ")  ");
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
		public Model.SYS_DepartmentInfo GetModel(int Dpt_Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Dpt_Id,Dpt_Name,Dpt_ParentId,Dpt_Level,Dpt_SecurityID from SYS_DepartmentInfo ");
			strSql.Append(" where Dpt_Id=@Dpt_Id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "Dpt_Id", DbType.Int32,Dpt_Id);
			Model.SYS_DepartmentInfo model=null;
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
		public Model.SYS_DepartmentInfo DataRowToModel(DataRow row)
		{
			Model.SYS_DepartmentInfo model=new Model.SYS_DepartmentInfo();
			if (row != null)
			{
				if(row["Dpt_Id"]!=null && row["Dpt_Id"].ToString()!="")
				{
					model.Dpt_Id=int.Parse(row["Dpt_Id"].ToString());
				}
				if(row["Dpt_Name"]!=null)
				{
					model.Dpt_Name=row["Dpt_Name"].ToString();
				}
				if(row["Dpt_ParentId"]!=null && row["Dpt_ParentId"].ToString()!="")
				{
					model.Dpt_ParentId=int.Parse(row["Dpt_ParentId"].ToString());
				}
				if(row["Dpt_Level"]!=null && row["Dpt_Level"].ToString()!="")
				{
					model.Dpt_Level=int.Parse(row["Dpt_Level"].ToString());
				}
				if(row["Dpt_SecurityID"]!=null)
				{
					model.Dpt_SecurityID=row["Dpt_SecurityID"].ToString();
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
			strSql.Append("select Dpt_Id,Dpt_Name,Dpt_ParentId,Dpt_Level,Dpt_SecurityID ");
			strSql.Append(" FROM SYS_DepartmentInfo ");
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
			strSql.Append(" Dpt_Id,Dpt_Name,Dpt_ParentId,Dpt_Level,Dpt_SecurityID ");
			strSql.Append(" FROM SYS_DepartmentInfo ");
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
        //    strSql.Append("select count(1) FROM SYS_DepartmentInfo ");
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
				strSql.Append("order by T.Dpt_Id desc");
			}
			strSql.Append(")AS Row, T.*  from SYS_DepartmentInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            return db.ExecuteDataSet(dbCommand);
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "SYS_DepartmentInfo");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "Dpt_Id");
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
		public List<Model.SYS_DepartmentInfo> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Dpt_Id,Dpt_Name,Dpt_ParentId,Dpt_Level,Dpt_SecurityID ");
			strSql.Append(" FROM SYS_DepartmentInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<Model.SYS_DepartmentInfo> list = new List<Model.SYS_DepartmentInfo>();
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
		public Model.SYS_DepartmentInfo ReaderBind(IDataReader dataReader)
		{
			Model.SYS_DepartmentInfo model=new Model.SYS_DepartmentInfo();
			object ojb; 
			ojb = dataReader["Dpt_Id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Dpt_Id=(int)ojb;
			}
			model.Dpt_Name=dataReader["Dpt_Name"].ToString();
			ojb = dataReader["Dpt_ParentId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Dpt_ParentId=(int)ojb;
			}
			ojb = dataReader["Dpt_Level"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Dpt_Level=(int)ojb;
			}
			model.Dpt_SecurityID=dataReader["Dpt_SecurityID"].ToString();
			return model;
		}

		#endregion  Method
	}
}

