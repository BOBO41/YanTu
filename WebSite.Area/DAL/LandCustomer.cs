/**  版本信息模板在安装目录下，可自行修改。
* LandCustomer.cs
*
* 功 能： N/A
* 类 名： LandCustomer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/6/24 10:04:31   N/A    初版
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

namespace WebSite.Area.DAL
{
	/// <summary>
	/// 数据访问类:LandCustomer
	/// </summary>
	public partial class LandCustomer
	{
		public LandCustomer()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(LCId)+1 from LandCustomer";
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
		public bool Exists(int LCId)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from LandCustomer where LCId=@LCId ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LCId", DbType.Int32,LCId);
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
		public int Add(Model.LandCustomer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LandCustomer(");
			strSql.Append("LId,CId,ZwName,Area)");

			strSql.Append(" values (");
			strSql.Append("@LId,@CId,@ZwName,@Area)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LId", DbType.Int32, model.LId);
			db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
			db.AddInParameter(dbCommand, "ZwName", DbType.String, model.ZwName);
			db.AddInParameter(dbCommand, "Area", DbType.Double, model.Area);
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
		public bool Update(Model.LandCustomer model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LandCustomer set ");
			strSql.Append("LId=@LId,");
			strSql.Append("CId=@CId,");
			strSql.Append("ZwName=@ZwName,");
			strSql.Append("Area=@Area");
			strSql.Append(" where LCId=@LCId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LCId", DbType.Int32, model.LCId);
			db.AddInParameter(dbCommand, "LId", DbType.Int32, model.LId);
			db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
			db.AddInParameter(dbCommand, "ZwName", DbType.String, model.ZwName);
			db.AddInParameter(dbCommand, "Area", DbType.Double, model.Area);
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
		public bool Delete(int LCId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LandCustomer ");
			strSql.Append(" where LCId=@LCId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LCId", DbType.Int32,LCId);
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
		public bool DeleteList(string LCIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LandCustomer ");
			strSql.Append(" where LCId in ("+LCIdlist + ")  ");
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
		public Model.LandCustomer GetModel(int LCId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LCId,LId,CId,ZwName,Area from LandCustomer ");
			strSql.Append(" where LCId=@LCId ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "LCId", DbType.Int32,LCId);
			Model.LandCustomer model=null;
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
		public Model.LandCustomer DataRowToModel(DataRow row)
		{
			Model.LandCustomer model=new Model.LandCustomer();
			if (row != null)
			{
				if(row["LCId"]!=null && row["LCId"].ToString()!="")
				{
					model.LCId=Convert.ToInt32(row["LCId"].ToString());
				}
				if(row["LId"]!=null && row["LId"].ToString()!="")
				{
					model.LId=Convert.ToInt32(row["LId"].ToString());
				}
				if(row["CId"]!=null && row["CId"].ToString()!="")
				{
					model.CId=Convert.ToInt32(row["CId"].ToString());
				}
				if(row["ZwName"]!=null)
				{
					model.ZwName=row["ZwName"].ToString();
				}
				if(row["Area"]!=null && row["Area"].ToString()!="")
				{
					model.Area=Convert.ToDecimal(row["Area"].ToString());
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
			strSql.Append("select LCId,LId,CId,ZwName,Area ");
			strSql.Append(" FROM LandCustomer ");
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
			strSql.Append(" LCId,LId,CId,ZwName,Area ");
			strSql.Append(" FROM LandCustomer ");
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
			strSql.Append("select count(1) FROM LandCustomer ");
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
				strSql.Append("order by T.LCId desc");
			}
			strSql.Append(")AS Row, T.*  from LandCustomer T ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "LandCustomer");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LCId");
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
		public List<Model.LandCustomer> GetListArray(string strWhere, List<SqlParameter> parameters)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LCId,LId,CId,ZwName,Area ");
			strSql.Append(" FROM LandCustomer ");
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
			List<Model.LandCustomer> list = new List<Model.LandCustomer>();
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
		public Model.LandCustomer ReaderBind(IDataReader dataReader)
		{
			Model.LandCustomer model=new Model.LandCustomer();
			object ojb; 
			ojb = dataReader["LCId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LCId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["LId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.LId=Convert.ToInt32(ojb);
			}
			ojb = dataReader["CId"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.CId=Convert.ToInt32(ojb);
			}
			model.ZwName=dataReader["ZwName"].ToString();
			ojb = dataReader["Area"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.Area=Convert.ToDecimal(ojb);
			}
			return model;
		}

		#endregion  Method


        #region   扩展方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsBylid(int LId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LandCustomer where LId=@LId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LId", DbType.Int32, LId);
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
        /// 增加农户
        /// </summary>
        public int AddLandCostomer(int LId, string FarmerIds, string FarmerDes, string FarmerArea)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LandCustomer ");
            strSql.Append(" where LId=@LID");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LId", DbType.Int32, LId);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    int rows = db.ExecuteNonQuery(dbCommand, trans);
                    if (rows >= 0)
                    {
                        StringBuilder strSql2 = new StringBuilder();
                        var arrayid = FarmerIds.Split(',');
                        var arraydes = FarmerDes.Split(',');
                        var arrayarea = FarmerArea.Split(',');

                        if (arrayid.Length != arraydes.Length - 1 || arrayid.Length != arrayarea.Length - 1)
                        {
                            return 0;
                        }
                        strSql2.Append(" insert into LandCustomer(");
                        strSql2.Append(" LId,CId,ZwName,Area)");
                        for (int i = 0; i < arrayid.Length; i++)
                        {
                            strSql2.Append(" select " + LId + "," + Convert.ToInt32(arrayid[i]) + ",'" + arraydes[i] + "','" + arrayarea[i] + "'");
                            if (i != arrayid.Length - 1)
                            {
                                strSql2.Append(" union ");
                            }
                        }
                        strSql2.Append(";select @@IDENTITY");
                        DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                        object obj = db.ExecuteScalar(dbCommand2, trans);
                        if (!int.TryParse(obj.ToString(), out result))
                        {
                            trans.Rollback();
                            return 0;
                        }
                        trans.Commit();
                    }
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteByCid(int CId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LandCustomer ");
            strSql.Append(" where CId=@CId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CId", DbType.Int32, CId);
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

