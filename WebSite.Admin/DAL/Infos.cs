/**  版本信息模板在安装目录下，可自行修改。
* Infos.cs
*
* 功 能： N/A
* 类 名： Infos
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  3/31/2015 11:58:11 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.

*│　                                                                　│
*│　                                        　　　　　　　　　　　　　│

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
	/// 数据访问类:Infos
	/// </summary>
	public partial class Infos
	{
		public Infos()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(IID)+1 from Infos";
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
		public bool Exists(int IID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from Infos where IID=@IID ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "IID", DbType.Int32,IID);
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
		public int Add(Model.Infos model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Infos(");
			strSql.Append("IName,PicAttID,IType,TIID,LID,SortNum,Status,CreateDate,Context,ConPosition,ConColor,ConSize,XPosition,YPosition,VideoAttID,NType,HotType,ADTime,ADPic,ADLink)");

			strSql.Append(" values (");
			strSql.Append("@IName,@PicAttID,@IType,@TIID,@LID,@SortNum,@Status,@CreateDate,@Context,@ConPosition,@ConColor,@ConSize,@XPosition,@YPosition,@VideoAttID,@NType,@HotType,@ADTime,@ADPic,@ADLink)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "IName", DbType.String, model.IName);
			db.AddInParameter(dbCommand, "PicAttID", DbType.String, model.PicAttID);
			db.AddInParameter(dbCommand, "IType", DbType.Int32, model.IType);
			db.AddInParameter(dbCommand, "TIID", DbType.Int32, model.TIID);
			db.AddInParameter(dbCommand, "LID", DbType.Int32, model.LID);
			db.AddInParameter(dbCommand, "SortNum", DbType.Int32, model.SortNum);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "Context", DbType.String, model.Context);
			db.AddInParameter(dbCommand, "ConPosition", DbType.String, model.ConPosition);
			db.AddInParameter(dbCommand, "ConColor", DbType.String, model.ConColor);
			db.AddInParameter(dbCommand, "ConSize", DbType.String, model.ConSize);
			db.AddInParameter(dbCommand, "XPosition", DbType.String, model.XPosition);
			db.AddInParameter(dbCommand, "YPosition", DbType.String, model.YPosition);
			db.AddInParameter(dbCommand, "VideoAttID", DbType.String, model.VideoAttID);
			db.AddInParameter(dbCommand, "NType", DbType.Byte, model.NType);
			db.AddInParameter(dbCommand, "HotType", DbType.Byte, model.HotType);
			db.AddInParameter(dbCommand, "ADTime", DbType.String, model.ADTime);
			db.AddInParameter(dbCommand, "ADPic", DbType.String, model.ADPic);
			db.AddInParameter(dbCommand, "ADLink", DbType.String, model.ADLink);
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
		public bool Update(Model.Infos model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Infos set ");
			strSql.Append("IName=@IName,");
			strSql.Append("PicAttID=@PicAttID,");
			strSql.Append("IType=@IType,");
			strSql.Append("TIID=@TIID,");
			strSql.Append("LID=@LID,");
			strSql.Append("SortNum=@SortNum,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateDate=@CreateDate,");
			strSql.Append("Context=@Context,");
			strSql.Append("ConPosition=@ConPosition,");
			strSql.Append("ConColor=@ConColor,");
			strSql.Append("ConSize=@ConSize,");
			strSql.Append("XPosition=@XPosition,");
			strSql.Append("YPosition=@YPosition,");
			strSql.Append("VideoAttID=@VideoAttID,");
			strSql.Append("NType=@NType,");
			strSql.Append("HotType=@HotType,");
			strSql.Append("ADTime=@ADTime,");
			strSql.Append("ADPic=@ADPic,");
			strSql.Append("ADLink=@ADLink");
			strSql.Append(" where IID=@IID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "IID", DbType.Int32, model.IID);
			db.AddInParameter(dbCommand, "IName", DbType.String, model.IName);
			db.AddInParameter(dbCommand, "PicAttID", DbType.String, model.PicAttID);
			db.AddInParameter(dbCommand, "IType", DbType.Int32, model.IType);
			db.AddInParameter(dbCommand, "TIID", DbType.Int32, model.TIID);
			db.AddInParameter(dbCommand, "LID", DbType.Int32, model.LID);
			db.AddInParameter(dbCommand, "SortNum", DbType.Int32, model.SortNum);
			db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
			db.AddInParameter(dbCommand, "CreateDate", DbType.DateTime, model.CreateDate);
			db.AddInParameter(dbCommand, "Context", DbType.String, model.Context);
			db.AddInParameter(dbCommand, "ConPosition", DbType.String, model.ConPosition);
			db.AddInParameter(dbCommand, "ConColor", DbType.String, model.ConColor);
			db.AddInParameter(dbCommand, "ConSize", DbType.String, model.ConSize);
			db.AddInParameter(dbCommand, "XPosition", DbType.String, model.XPosition);
			db.AddInParameter(dbCommand, "YPosition", DbType.String, model.YPosition);
			db.AddInParameter(dbCommand, "VideoAttID", DbType.String, model.VideoAttID);
			db.AddInParameter(dbCommand, "NType", DbType.Byte, model.NType);
			db.AddInParameter(dbCommand, "HotType", DbType.Byte, model.HotType);
			db.AddInParameter(dbCommand, "ADTime", DbType.String, model.ADTime);
			db.AddInParameter(dbCommand, "ADPic", DbType.String, model.ADPic);
			db.AddInParameter(dbCommand, "ADLink", DbType.String, model.ADLink);
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
		public bool Delete(int IID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Infos ");
			strSql.Append(" where IID=@IID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "IID", DbType.Int32,IID);
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
		public bool DeleteList(string IIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Infos ");
			strSql.Append(" where IID in ("+IIDlist + ")  ");
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
		public Model.Infos GetModel(int IID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select IID,IName,PicAttID,IType,TIID,LID,SortNum,Status,CreateDate,Context,ConPosition,ConColor,ConSize,XPosition,YPosition,VideoAttID,NType,HotType,ADTime,ADPic,ADLink from Infos ");
			strSql.Append(" where IID=@IID ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "IID", DbType.Int32,IID);
			Model.Infos model=null;
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
		public Model.Infos DataRowToModel(DataRow row)
		{
			Model.Infos model=new Model.Infos();
			if (row != null)
			{
				if(row["IID"]!=null && row["IID"].ToString()!="")
				{
					model.IID=Convert.ToInt32(row["IID"].ToString());
				}
				if(row["IName"]!=null)
				{
					model.IName=row["IName"].ToString();
				}
				if(row["PicAttID"]!=null)
				{
					model.PicAttID=row["PicAttID"].ToString();
				}
				if(row["IType"]!=null && row["IType"].ToString()!="")
				{
					model.IType=Convert.ToInt32(row["IType"].ToString());
				}
				if(row["TIID"]!=null && row["TIID"].ToString()!="")
				{
					model.TIID=Convert.ToInt32(row["TIID"].ToString());
				}
				if(row["LID"]!=null && row["LID"].ToString()!="")
				{
					model.LID=Convert.ToInt32(row["LID"].ToString());
				}
				if(row["SortNum"]!=null && row["SortNum"].ToString()!="")
				{
					model.SortNum=Convert.ToInt32(row["SortNum"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=Convert.ToInt32(row["Status"].ToString());
				}
				if(row["CreateDate"]!=null && row["CreateDate"].ToString()!="")
				{
					model.CreateDate=Convert.ToDateTime(row["CreateDate"].ToString());
				}
				if(row["Context"]!=null)
				{
					model.Context=row["Context"].ToString();
				}
				if(row["ConPosition"]!=null)
				{
					model.ConPosition=row["ConPosition"].ToString();
				}
				if(row["ConColor"]!=null)
				{
					model.ConColor=row["ConColor"].ToString();
				}
				if(row["ConSize"]!=null)
				{
					model.ConSize=row["ConSize"].ToString();
				}
				if(row["XPosition"]!=null)
				{
					model.XPosition=row["XPosition"].ToString();
				}
				if(row["YPosition"]!=null)
				{
					model.YPosition=row["YPosition"].ToString();
				}
				if(row["VideoAttID"]!=null)
				{
					model.VideoAttID=row["VideoAttID"].ToString();
				}
				if(row["NType"]!=null && row["NType"].ToString()!="")
				{
					model.NType=Convert.ToInt32(row["NType"].ToString());
				}
				if(row["HotType"]!=null && row["HotType"].ToString()!="")
				{
					model.HotType=Convert.ToInt32(row["HotType"].ToString());
				}
				if(row["ADTime"]!=null)
				{
					model.ADTime=row["ADTime"].ToString();
				}
				if(row["ADPic"]!=null)
				{
					model.ADPic=row["ADPic"].ToString();
				}
				if(row["ADLink"]!=null)
				{
					model.ADLink=row["ADLink"].ToString();
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
			strSql.Append("select IID,IName,PicAttID,IType,TIID,LID,SortNum,Status,CreateDate,Context,ConPosition,ConColor,ConSize,XPosition,YPosition,VideoAttID,NType,HotType,ADTime,ADPic,ADLink ");
			strSql.Append(" FROM Infos ");
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
			strSql.Append(" IID,IName,PicAttID,IType,TIID,LID,SortNum,Status,CreateDate,Context,ConPosition,ConColor,ConSize,XPosition,YPosition,VideoAttID,NType,HotType,ADTime,ADPic,ADLink ");
			strSql.Append(" FROM Infos ");
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
			strSql.Append("select count(1) FROM Infos ");
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
				strSql.Append("order by T.IID desc");
			}
			strSql.Append(")AS Row, T.*  from Infos T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "Infos");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "IID");
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
		public List<Model.Infos> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select IID,IName,PicAttID,IType,TIID,LID,SortNum,Status,CreateDate,Context,ConPosition,ConColor,ConSize,XPosition,YPosition,VideoAttID,NType,HotType,ADTime,ADPic,ADLink ");
			strSql.Append(" FROM Infos ");
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
			List<Model.Infos> list = new List<Model.Infos>();
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
		public Model.Infos ReaderBind(IDataReader dataReader)
		{
			Model.Infos model=new Model.Infos();
			object ojb; 
			ojb = dataReader["IID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IID=Convert.ToInt32(ojb);
			}
			model.IName=dataReader["IName"].ToString();
			model.PicAttID=dataReader["PicAttID"].ToString();
			ojb = dataReader["IType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.IType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["TIID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.TIID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["LID"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LID=Convert.ToInt32(ojb);
			}
			ojb = dataReader["SortNum"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.SortNum=Convert.ToInt32(ojb);
			}
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
			model.Context=dataReader["Context"].ToString();
			model.ConPosition=dataReader["ConPosition"].ToString();
			model.ConColor=dataReader["ConColor"].ToString();
			model.ConSize=dataReader["ConSize"].ToString();
			model.XPosition=dataReader["XPosition"].ToString();
			model.YPosition=dataReader["YPosition"].ToString();
			model.VideoAttID=dataReader["VideoAttID"].ToString();
			ojb = dataReader["NType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.NType=Convert.ToInt32(ojb);
			}
			ojb = dataReader["HotType"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.HotType=Convert.ToInt32(ojb);
			}
			model.ADTime=dataReader["ADTime"].ToString();
			model.ADPic=dataReader["ADPic"].ToString();
			model.ADLink=dataReader["ADLink"].ToString();
			return model;
		}

		#endregion  Method

        #region

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Infos GetModel(string strWhere, List<SqlParameter> parameters)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Infos ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            Model.Infos model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        public Model.Infos GetModel(int tiid, int sortnum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Infos join TmpInfoList on TmpInfoList.IID=Infos.IID where Infos.SortNum=" + sortnum + " and TmpInfoList.TIID=" + tiid);
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());

            Model.Infos model = null;
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

