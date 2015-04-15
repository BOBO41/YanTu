/**  版本信息模板在安装目录下，可自行修改。
* CMAttchment.cs
*
* 功 能： N/A
* 类 名： CMAttchment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/12/27 16:56:19   N/A    初版
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
    /// 数据访问类:CMAttchment
    /// </summary>
    public partial class CMAttchment
    {
        public CMAttchment()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(AttId)+1 from CMAttchment";
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
        public bool Exists(int AttId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMAttchment where AttId=@AttId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AttId", DbType.Int32, AttId);
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
        public int Add(Model.CMAttchment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMAttchment(");
            strSql.Append("AId,Type,AttName,Status)");

            strSql.Append(" values (");
            strSql.Append("@AId,@Type,@AttName,@Status)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AId", DbType.Int32, model.AId);
            db.AddInParameter(dbCommand, "Type", DbType.Byte, model.Type);
            db.AddInParameter(dbCommand, "AttName", DbType.String, model.AttName);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMAttchment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMAttchment set ");
            strSql.Append("AId=@AId,");
            strSql.Append("Type=@Type,");
            strSql.Append("AttName=@AttName,");
            strSql.Append("Status=@Status");
            strSql.Append(" where AttId=@AttId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AttId", DbType.Int32, model.AttId);
            db.AddInParameter(dbCommand, "AId", DbType.Int32, model.AId);
            db.AddInParameter(dbCommand, "Type", DbType.Byte, model.Type);
            db.AddInParameter(dbCommand, "AttName", DbType.String, model.AttName);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
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
        public bool Delete(int AttId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMAttchment ");
            strSql.Append(" where AttId=@AttId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AttId", DbType.Int32, AttId);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string AttIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMAttchment ");
            strSql.Append(" where AttId in (" + AttIdlist + ")  ");
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
        public Model.CMAttchment GetModel(int AttId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AttId,AId,Type,AttName,Status from CMAttchment ");
            strSql.Append(" where AttId=@AttId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AttId", DbType.Int32, AttId);
            Model.CMAttchment model = null;
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
        public Model.CMAttchment DataRowToModel(DataRow row)
        {
            Model.CMAttchment model = new Model.CMAttchment();
            if (row != null)
            {
                if (row["AttId"] != null && row["AttId"].ToString() != "")
                {
                    model.AttId = Convert.ToInt32(row["AttId"].ToString());
                }
                if (row["AId"] != null && row["AId"].ToString() != "")
                {
                    model.AId = Convert.ToInt32(row["AId"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = Convert.ToInt32(row["Type"].ToString());
                }
                if (row["AttName"] != null)
                {
                    model.AttName = row["AttName"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(row["Status"].ToString());
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
            strSql.Append("select AttId,AId,Type,AttName,Status ");
            strSql.Append(" FROM CMAttchment ");
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
            strSql.Append(" AttId,AId,Type,AttName,Status ");
            strSql.Append(" FROM CMAttchment ");
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
            strSql.Append("select count(1) FROM CMAttchment ");
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
                strSql.Append("order by T.AttId desc");
            }
            strSql.Append(")AS Row, T.*  from CMAttchment T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "CMAttchment");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "AttId");
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
        public List<Model.CMAttchment> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AttId,AId,Type,AttName,Status ");
            strSql.Append(" FROM CMAttchment ");
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
            List<Model.CMAttchment> list = new List<Model.CMAttchment>();
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
        public Model.CMAttchment ReaderBind(IDataReader dataReader)
        {
            Model.CMAttchment model = new Model.CMAttchment();
            object ojb;
            ojb = dataReader["AttId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AttId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["AId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Type"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Type = Convert.ToInt32(ojb);
            }
            model.AttName = dataReader["AttName"].ToString();
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = Convert.ToInt32(ojb);
            }
            return model;
        }

        #endregion  Method
        #region 扩展方法
        /// <summary>
        /// 文章中是否村存在图片
        /// </summary>
        /// <param name="AId">文章ID</param>
        /// <param name="Type">类型ID</param>
        /// <returns></returns>
        public bool Exists(int AId, int Type)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMAttchment where AId=@AId and Type=@Type");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AId", DbType.Int32, AId);
            db.AddInParameter(dbCommand, "Type", DbType.Int32, Type);
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
        /// 根据文章和类型得到一个对象实体
        /// </summary>
        /// <param name="AttId">文章ID</param>
        /// <param name="Type">类型ID(0为图片，1为附件)</param>
        /// <returns></returns>
        public Model.CMAttchment GetModel(int AId, int Type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AttId,AId,Type,AttName,Status from CMAttchment ");
            strSql.Append(" where AId=@AId and Type=@Type");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AId", DbType.Int32, AId);
            db.AddInParameter(dbCommand, "Type", DbType.Int32, Type);
            Model.CMAttchment model = null;
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteByAid(int Aid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMAttchment ");
            strSql.Append(" where Aid=@Aid and Type=1");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Aid", DbType.Int32, Aid);
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

