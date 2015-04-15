/**  版本信息模板在安装目录下，可自行修改。
* CMPro.cs
*
* 功 能： N/A
* 类 名： CMPro
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/4/8 17:36:01   N/A    初版
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
    /// 数据访问类:CMPro
    /// </summary>
    public partial class CMPro
    {
        public CMPro()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.CMPro model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMPro(");
            strSql.Append("AId,PID)");

            strSql.Append(" values (");
            strSql.Append("@AId,@PID)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AId", DbType.Int32, model.AId);
            db.AddInParameter(dbCommand, "PID", DbType.Int32, model.PID);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMPro model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMPro set ");
            strSql.Append("AId=@AId,");
            strSql.Append("PID=@PID");
            strSql.Append(" where ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AId", DbType.Int32, model.AId);
            db.AddInParameter(dbCommand, "PID", DbType.Int32, model.PID);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMPro ");
            strSql.Append(" where ");
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
        public Model.CMPro GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AId,PID from CMPro ");
            strSql.Append(" where ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            Model.CMPro model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.CMPro DataRowToModel(DataRow row)
        {
            Model.CMPro model = new Model.CMPro();
            if (row != null)
            {
                if (row["AId"] != null && row["AId"].ToString() != "")
                {
                    model.AId = Convert.ToInt32(row["AId"].ToString());
                }
                if (row["PID"] != null && row["PID"].ToString() != "")
                {
                    model.PID = Convert.ToInt32(row["PID"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AId,PID ");
            strSql.Append(" FROM CMPro ");
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
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="Top">int Top</param>
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(int Top, string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" AId,PID ");
            strSql.Append(" FROM CMPro ");
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
            return db.ExecuteDataSet(dbCommand);
        }

        /*
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM CMPro ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from CMPro T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
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
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMPro");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
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
        public List<Model.CMPro> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AId,PID ");
            strSql.Append(" FROM CMPro ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            List<Model.CMPro> list = new List<Model.CMPro>();
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
        public Model.CMPro ReaderBind(IDataReader dataReader)
        {
            Model.CMPro model = new Model.CMPro();
            object ojb;
            ojb = dataReader["AId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["PID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PID = Convert.ToInt32(ojb);
            }
            return model;
        }

        #endregion  Method

        #region  扩展方法
        /// <summary>
        /// 增加商品
        /// </summary>
        public int AddPro(int aid, string FarmerIds)
        {
            int result = 0;
            Database db = DatabaseFactory.CreateDatabase();
            if (!string.IsNullOrEmpty(FarmerIds))
            {
                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    try
                    {

                        var farmIds = FarmerIds.Split(',');
                        for (int i = 0; i < farmIds.Length; i++)
                        {
                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("select * from CMPro ");
                            strSql.Append(" where AID=@AID AND PID =" + farmIds[i] + "");
                            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                            db.AddInParameter(dbCommand, "AID", DbType.Int32, aid);
                            int rows = db.ExecuteDataSet(dbCommand, trans).Tables[0].Rows.Count;
                            if (rows == 0)
                            {
                                StringBuilder strSql2 = new StringBuilder();
                                strSql2.Append("insert into CMPro (AId,PID) select " + aid + ",fieldvalue from dbo.SplitToTable('" + farmIds[i] + "',',')");
                                DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                                db.ExecuteNonQuery(dbCommand2, trans);

                            }
                        }
                        trans.Commit();
                        result = 1;

                    }
                    catch
                    {
                        trans.Rollback();
                    }
                    conn.Close();
                }
            }
            return result;
        }

        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListPro(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AId,a.PID,b.Title,b.OrgId ");
            strSql.Append(" FROM CMPro  a left join ProductInfo b on a.PID=b.PID ");
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
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeletePro(string strWhere)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMPro ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
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

      
        #endregion
    }
}

