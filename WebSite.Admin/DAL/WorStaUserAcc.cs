/**  版本信息模板在安装目录下，可自行修改。
* WorStaUserAcc.cs
*
* 功 能： N/A
* 类 名： WorStaUserAcc
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-02-24 15:22:23   N/A    初版
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
    /// 数据访问类:WorStaUserAcc
    /// </summary>
    public partial class WorStaUserAcc
    {
        public WorStaUserAcc()
        { }
        #region  Method



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Model.WorStaUserAcc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WorStaUserAcc(");
            strSql.Append("EmplId,CId)");

            strSql.Append(" values (");
            strSql.Append("@EmplId,@CId)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
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
        public bool Update(Model.WorStaUserAcc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WorStaUserAcc set ");
            strSql.Append("EmplId=@EmplId,");
            strSql.Append("CId=@CId");
            strSql.Append(" where ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
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
            strSql.Append("delete from WorStaUserAcc ");
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
        public Model.WorStaUserAcc GetModel(string sqlWhere)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EmplId,CId from WorStaUserAcc ");
            if (!string.IsNullOrEmpty(sqlWhere))
            {
                strSql.Append(" where " + sqlWhere + "");
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            Model.WorStaUserAcc model = null;
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
        public Model.WorStaUserAcc DataRowToModel(DataRow row)
        {
            Model.WorStaUserAcc model = new Model.WorStaUserAcc();
            if (row != null)
            {
                if (row["EmplId"] != null && row["EmplId"].ToString() != "")
                {
                    model.EmplId = Convert.ToInt32(row["EmplId"].ToString());
                }
                if (row["CId"] != null && row["CId"].ToString() != "")
                {
                    model.CId = Convert.ToInt32(row["CId"].ToString());
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
            strSql.Append("select EmplId,CId ");
            strSql.Append(" FROM WorStaUserAcc ");
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
            strSql.Append(" EmplId,CId ");
            strSql.Append(" FROM WorStaUserAcc ");
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
            strSql.Append("select count(1) FROM WorStaUserAcc ");
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
            strSql.Append(")AS Row, T.*  from WorStaUserAcc T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "WorStaUserAcc");
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
        public List<Model.WorStaUserAcc> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EmplId,CId ");
            strSql.Append(" FROM WorStaUserAcc ");
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
            List<Model.WorStaUserAcc> list = new List<Model.WorStaUserAcc>();
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
        public Model.WorStaUserAcc ReaderBind(IDataReader dataReader)
        {
            Model.WorStaUserAcc model = new Model.WorStaUserAcc();
            object ojb;
            ojb = dataReader["EmplId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EmplId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["CId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CId = Convert.ToInt32(ojb);
            }
            return model;
        }

        #endregion  Method
    }
}

