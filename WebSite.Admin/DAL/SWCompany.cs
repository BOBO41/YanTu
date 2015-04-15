/**  版本信息模板在安装目录下，可自行修改。
* SWCompany.cs
*
* 功 能： N/A
* 类 名： SWCompany
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/22 17:12:55   N/A    初版
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
    /// 数据访问类:SWCompany
    /// </summary>
    public partial class SWCompany
    {
        public SWCompany()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.SWCompany model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SWCompany(");
            strSql.Append("SWOrgId,COrgId)");

            strSql.Append(" values (");
            strSql.Append("@SWOrgId,@COrgId)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SWOrgId", DbType.Int32, model.SWOrgId);
            db.AddInParameter(dbCommand, "COrgId", DbType.Int32, model.COrgId);
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
        public bool Update(Model.SWCompany model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SWCompany set ");
            strSql.Append("SWOrgId=@SWOrgId,");
            strSql.Append("COrgId=@COrgId");
            strSql.Append(" where ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "SWOrgId", DbType.Int32, model.SWOrgId);
            db.AddInParameter(dbCommand, "COrgId", DbType.Int32, model.COrgId);
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
            strSql.Append("delete from SWCompany ");
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
        public Model.SWCompany GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SWOrgId,COrgId from SWCompany ");
            strSql.Append(" where ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            Model.SWCompany model = null;
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
        public Model.SWCompany DataRowToModel(DataRow row)
        {
            Model.SWCompany model = new Model.SWCompany();
            if (row != null)
            {
                if (row["SWOrgId"] != null && row["SWOrgId"].ToString() != "")
                {
                    model.SWOrgId = Convert.ToInt32(row["SWOrgId"].ToString());
                }
                if (row["COrgId"] != null && row["COrgId"].ToString() != "")
                {
                    model.COrgId = Convert.ToInt32(row["COrgId"].ToString());
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
            strSql.Append("select SWOrgId,COrgId ");
            strSql.Append(" FROM SWCompany ");
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
            strSql.Append(" SWOrgId,COrgId ");
            strSql.Append(" FROM SWCompany ");
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
            strSql.Append("select count(1) FROM SWCompany ");
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
            strSql.Append(")AS Row, T.*  from SWCompany T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "SWCompany");
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
        public List<Model.SWCompany> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SWOrgId,COrgId ");
            strSql.Append(" FROM SWCompany ");
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
            List<Model.SWCompany> list = new List<Model.SWCompany>();
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
        public Model.SWCompany ReaderBind(IDataReader dataReader)
        {
            Model.SWCompany model = new Model.SWCompany();
            object ojb;
            ojb = dataReader["SWOrgId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SWOrgId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["COrgId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.COrgId = Convert.ToInt32(ojb);
            }
            return model;
        }

        #endregion  Method
        #region   扩展方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SWCompany GetModelBySWOrgId(string orgId)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SWOrgId,COrgId from SWCompany ");
            strSql.Append(" where SWOrgId=" + orgId + "");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            Model.SWCompany model = null;
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

