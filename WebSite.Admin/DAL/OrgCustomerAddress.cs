/**  版本信息模板在安装目录下，可自行修改。
* OrgCustomerAddress.cs
*
* 功 能： N/A
* 类 名： OrgCustomerAddress
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-01-18 14:49:01   N/A    初版
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
    /// 数据访问类:OrgCustomerAddress
    /// </summary>
    public partial class OrgCustomerAddress
    {
        public OrgCustomerAddress()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(CAId)+1 from OrgCustomerAddress";
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
        public bool Exists(int CAId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrgCustomerAddress where CAId=@CAId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CAId", DbType.Int32, CAId);
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
        public int Add(Model.OrgCustomerAddress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgCustomerAddress(");
            strSql.Append("CId,Province,City,County,Address,ReciveName,RecivePhone,IsDefault,AddTime,Status)");

            strSql.Append(" values (");
            strSql.Append("@CId,@Province,@City,@County,@Address,@ReciveName,@RecivePhone,@IsDefault,@AddTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
            db.AddInParameter(dbCommand, "Province", DbType.AnsiString, model.Province);
            db.AddInParameter(dbCommand, "City", DbType.AnsiString, model.City);
            db.AddInParameter(dbCommand, "County", DbType.AnsiString, model.County);
            db.AddInParameter(dbCommand, "Address", DbType.String, model.Address);
            db.AddInParameter(dbCommand, "ReciveName", DbType.String, model.ReciveName);
            db.AddInParameter(dbCommand, "RecivePhone", DbType.AnsiString, model.RecivePhone);
            db.AddInParameter(dbCommand, "IsDefault", DbType.Byte, model.IsDefault);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
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
        public bool Update(Model.OrgCustomerAddress model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgCustomerAddress set ");
            strSql.Append("CId=@CId,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("County=@County,");
            strSql.Append("Address=@Address,");
            strSql.Append("ReciveName=@ReciveName,");
            strSql.Append("RecivePhone=@RecivePhone,");
            strSql.Append("IsDefault=@IsDefault,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Status=@Status");
            strSql.Append(" where CAId=@CAId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CAId", DbType.Int32, model.CAId);
            db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
            db.AddInParameter(dbCommand, "Province", DbType.AnsiString, model.Province);
            db.AddInParameter(dbCommand, "City", DbType.AnsiString, model.City);
            db.AddInParameter(dbCommand, "County", DbType.AnsiString, model.County);
            db.AddInParameter(dbCommand, "Address", DbType.String, model.Address);
            db.AddInParameter(dbCommand, "ReciveName", DbType.String, model.ReciveName);
            db.AddInParameter(dbCommand, "RecivePhone", DbType.AnsiString, model.RecivePhone);
            db.AddInParameter(dbCommand, "IsDefault", DbType.Byte, model.IsDefault);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
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
        public bool Delete(int CAId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgCustomerAddress ");
            strSql.Append(" where CAId=@CAId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CAId", DbType.Int32, CAId);
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
        public bool DeleteList(string CAIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgCustomerAddress ");
            strSql.Append(" where CAId in (" + CAIdlist + ")  ");
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
        public Model.OrgCustomerAddress GetModel(int CAId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CAId,CId,Province,City,County,Address,ReciveName,RecivePhone,IsDefault,AddTime,Status from OrgCustomerAddress ");
            strSql.Append(" where CAId=@CAId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CAId", DbType.Int32, CAId);
            Model.OrgCustomerAddress model = null;
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
        public Model.OrgCustomerAddress DataRowToModel(DataRow row)
        {
            Model.OrgCustomerAddress model = new Model.OrgCustomerAddress();
            if (row != null)
            {
                if (row["CAId"] != null && row["CAId"].ToString() != "")
                {
                    model.CAId = Convert.ToInt32(row["CAId"].ToString());
                }
                if (row["CId"] != null && row["CId"].ToString() != "")
                {
                    model.CId = Convert.ToInt32(row["CId"].ToString());
                }
                if (row["Province"] != null)
                {
                    model.Province = row["Province"].ToString();
                }
                if (row["City"] != null)
                {
                    model.City = row["City"].ToString();
                }
                if (row["County"] != null)
                {
                    model.County = row["County"].ToString();
                }
                if (row["Address"] != null)
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["ReciveName"] != null)
                {
                    model.ReciveName = row["ReciveName"].ToString();
                }
                if (row["RecivePhone"] != null)
                {
                    model.RecivePhone = row["RecivePhone"].ToString();
                }
                if (row["IsDefault"] != null && row["IsDefault"].ToString() != "")
                {
                    model.IsDefault = Convert.ToInt32(row["IsDefault"].ToString());
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = Convert.ToDateTime(row["AddTime"].ToString());
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
            strSql.Append("select CAId,CId,Province,City,County,Address,ReciveName,RecivePhone,IsDefault,AddTime,Status ");
            strSql.Append(" FROM OrgCustomerAddress ");
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
            strSql.Append(" CAId,CId,Province,City,County,Address,ReciveName,RecivePhone,IsDefault,AddTime,Status ");
            strSql.Append(" FROM OrgCustomerAddress ");
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
            strSql.Append("select count(1) FROM OrgCustomerAddress ");
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
                strSql.Append("order by T.CAId desc");
            }
            strSql.Append(")AS Row, T.*  from OrgCustomerAddress T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgCustomerAddress");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CAId");
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
        public List<Model.OrgCustomerAddress> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CAId,CId,Province,City,County,Address,ReciveName,RecivePhone,IsDefault,AddTime,Status ");
            strSql.Append(" FROM OrgCustomerAddress ");
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
            List<Model.OrgCustomerAddress> list = new List<Model.OrgCustomerAddress>();
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
        public Model.OrgCustomerAddress ReaderBind(IDataReader dataReader)
        {
            Model.OrgCustomerAddress model = new Model.OrgCustomerAddress();
            object ojb;
            ojb = dataReader["CAId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CAId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["CId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CId = Convert.ToInt32(ojb);
            }
            model.Province = dataReader["Province"].ToString();
            model.City = dataReader["City"].ToString();
            model.County = dataReader["County"].ToString();
            model.Address = dataReader["Address"].ToString();
            model.ReciveName = dataReader["ReciveName"].ToString();
            model.RecivePhone = dataReader["RecivePhone"].ToString();
            ojb = dataReader["IsDefault"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsDefault = Convert.ToInt32(ojb);
            }
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = Convert.ToDateTime(ojb);
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = Convert.ToInt32(ojb);
            }
            return model;
        }

        #endregion  Method

        #region 扩展
        public bool SetDefaultAddr(string cId, string caId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgCustomerAddress set ");
            strSql.Append("IsDefault=0");
            strSql.Append(" where CId=@CId  ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CId", DbType.Int32, cId);
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbCommand, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("update OrgCustomerAddress set ");
                    strSql2.Append("IsDefault=1 ");
                    strSql2.Append(" where CId=@CId and CAId=@CAId ");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.AddInParameter(dbCommand2, "CId", DbType.Int32, cId);
                    db.AddInParameter(dbCommand2, "CAId", DbType.Int32, caId);
                    db.ExecuteNonQuery(dbCommand2, trans);
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
        /// 得到一个对象实体
        /// </summary>
        public Model.OrgCustomerAddress GetModelByCid(int CId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CAId,CId,Province,City,County,Address,ReciveName,RecivePhone,IsDefault,AddTime,Status from OrgCustomerAddress ");
            strSql.Append(" where CId=@CId and IsDefault=1 ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CId", DbType.Int32, CId);
            Model.OrgCustomerAddress model = null;
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

