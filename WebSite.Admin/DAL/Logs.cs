/**  版本信息模板在安装目录下，可自行修改。
* Logs.cs
*
* 功 能： N/A
* 类 名： Logs
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-03-03 10:11:54   N/A    初版
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
    /// 数据访问类:Logs
    /// </summary>
    public partial class Logs
    {
        public Logs()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long LID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Logs where LID=@LID ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int64, LID);
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
        public long Add(Model.Logs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Logs(");
            strSql.Append("LLID,OValue,NValue,FName)");

            strSql.Append(" values (");
            strSql.Append("@LLID,@OValue,@NValue,@FName)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LLID", DbType.Int64, model.LLID);
            db.AddInParameter(dbCommand, "OValue", DbType.String, model.OValue);
            db.AddInParameter(dbCommand, "NValue", DbType.String, model.NValue);
            db.AddInParameter(dbCommand, "FName", DbType.String, model.FName);
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
        public bool Update(Model.Logs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Logs set ");
            strSql.Append("LLID=@LLID,");
            strSql.Append("OValue=@OValue,");
            strSql.Append("NValue=@NValue,");
            strSql.Append("FName=@FName");
            strSql.Append(" where LID=@LID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int64, model.LID);
            db.AddInParameter(dbCommand, "LLID", DbType.Int64, model.LLID);
            db.AddInParameter(dbCommand, "OValue", DbType.String, model.OValue);
            db.AddInParameter(dbCommand, "NValue", DbType.String, model.NValue);
            db.AddInParameter(dbCommand, "FName", DbType.String, model.FName);
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
        public bool Delete(long LID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Logs ");
            strSql.Append(" where LID=@LID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int64, LID);
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
        public bool DeleteList(string LIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Logs ");
            strSql.Append(" where LID in (" + LIDlist + ")  ");
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
        public Model.Logs GetModel(long LID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LID,LLID,OValue,NValue,FName from Logs ");
            strSql.Append(" where LID=@LID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LID", DbType.Int64, LID);
            Model.Logs model = null;
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
        public Model.Logs DataRowToModel(DataRow row)
        {
            Model.Logs model = new Model.Logs();
            if (row != null)
            {
                if (row["LID"] != null && row["LID"].ToString() != "")
                {
                    model.LID = Convert.ToInt64(row["LID"].ToString());
                }
                if (row["LLID"] != null && row["LLID"].ToString() != "")
                {
                    model.LLID = Convert.ToInt64(row["LLID"].ToString());
                }
                if (row["OValue"] != null)
                {
                    model.OValue = row["OValue"].ToString();
                }
                if (row["NValue"] != null)
                {
                    model.NValue = row["NValue"].ToString();
                }
                if (row["FName"] != null)
                {
                    model.FName = row["FName"].ToString();
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
            strSql.Append("select LID,LLID,OValue,NValue,FName ");
            strSql.Append(" FROM Logs ");
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
            strSql.Append(" LID,LLID,OValue,NValue,FName ");
            strSql.Append(" FROM Logs ");
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
            strSql.Append("select count(1) FROM Logs ");
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
                strSql.Append("order by T.LID desc");
            }
            strSql.Append(")AS Row, T.*  from Logs T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "Logs");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LID");
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
        public List<Model.Logs> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LID,LLID,OValue,NValue,FName ");
            strSql.Append(" FROM Logs ");
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
            List<Model.Logs> list = new List<Model.Logs>();
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
        public Model.Logs ReaderBind(IDataReader dataReader)
        {
            Model.Logs model = new Model.Logs();
            object ojb;
            ojb = dataReader["LID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LID = Convert.ToInt64(ojb);
            }
            ojb = dataReader["LLID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LLID = Convert.ToInt64(ojb);
            }
            model.OValue = dataReader["OValue"].ToString();
            model.NValue = dataReader["NValue"].ToString();
            model.FName = dataReader["FName"].ToString();
            return model;
        }

        #endregion  Method

        #region
        public void WriteLogs(List<InfoLog> infolist, string emplId, int aId, DateTime now, string tName)
        {
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("insert into LogList(");
            strSql1.Append("EmplId,PId,TName,MDate)");

            strSql1.Append(" values (");
            strSql1.Append("@EmplId,@PId,@TName,@MDate)");
            strSql1.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand1 = db.GetSqlStringCommand(strSql1.ToString());
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    db.AddInParameter(dbCommand1, "EmplId", DbType.Int32, emplId);
                    db.AddInParameter(dbCommand1, "PId", DbType.Int32, aId);
                    db.AddInParameter(dbCommand1, "TName", DbType.String, tName);
                    db.AddInParameter(dbCommand1, "MDate", DbType.DateTime, now);
                    int llid;
                    object obj = db.ExecuteScalar(dbCommand1, trans);
                    if (int.TryParse(obj.ToString(), out llid))
                    {
                        StringBuilder strSql = new StringBuilder();
                        foreach (InfoLog infoLog in infolist)
                        {
                            strSql.Append("insert into Logs(");
                            strSql.Append("LLID,OValue,NValue,FName)");

                            strSql.Append(" values (");
                            strSql.Append("'" + llid + "','" + infoLog.OValue + "','" + infoLog.NValue + "','" + infoLog.FName + "')");
                            strSql.Append(";");
                        }
                        DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                        int rows = db.ExecuteNonQuery(dbCommand, trans);
                        if (rows > 0)
                        {
                            trans.Commit();
                        }
                        else
                        {
                            trans.Rollback();
                        }
                    }
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

            }
        }
        public class InfoLog
        {
            public string OValue { get; set; }

            public string NValue { get; set; }
            public string FName { get; set; }

            public InfoLog(string nValue, string oValue, string fName)
            {
                NValue = nValue;
                OValue = oValue;
                FName = fName;
            }
        }
        #endregion
    }
}

