/**  版本信息模板在安装目录下，可自行修改。
* InfoType.cs
*
* 功 能： N/A
* 类 名： InfoType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  12/21/2014 10:56:44 PM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

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
    /// 数据访问类:InfoType
    /// </summary>
    public partial class InfoType
    {
        public InfoType()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(ITID)+1 from InfoType";
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
        public bool Exists(int ITID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from InfoType where ITID=@ITID ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ITID", DbType.Int32, ITID);
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
        public int Add(Model.InfoType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into InfoType(");
            strSql.Append("IName,SPID,AttaID,SortNum,Status)");

            strSql.Append(" values (");
            strSql.Append("@IName,@SPID,@AttaID,@SortNum,@Status)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "IName", DbType.String, model.IName);
            db.AddInParameter(dbCommand, "SPID", DbType.Int32, model.SPID);
            db.AddInParameter(dbCommand, "AttaID", DbType.String, model.AttaID);
            db.AddInParameter(dbCommand, "SortNum", DbType.Int32, model.SortNum);
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
        public bool Update(Model.InfoType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update InfoType set ");
            strSql.Append("IName=@IName,");
            strSql.Append("SPID=@SPID,");
            strSql.Append("AttaID=@AttaID,");
            strSql.Append("SortNum=@SortNum,");
            strSql.Append("Status=@Status");
            strSql.Append(" where ITID=@ITID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ITID", DbType.Int32, model.ITID);
            db.AddInParameter(dbCommand, "IName", DbType.String, model.IName);
            db.AddInParameter(dbCommand, "SPID", DbType.Int32, model.SPID);
            db.AddInParameter(dbCommand, "AttaID", DbType.String, model.AttaID);
            db.AddInParameter(dbCommand, "SortNum", DbType.Int32, model.SortNum);
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
        public bool Delete(int ITID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from InfoType ");
            strSql.Append(" where ITID=@ITID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ITID", DbType.Int32, ITID);
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
        public bool DeleteList(string ITIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from InfoType ");
            strSql.Append(" where ITID in (" + ITIDlist + ")  ");
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
        public Model.InfoType GetModel(int ITID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ITID,IName,SPID,AttaID,SortNum,Status from InfoType ");
            strSql.Append(" where ITID=@ITID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ITID", DbType.Int32, ITID);
            Model.InfoType model = null;
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
        public Model.InfoType DataRowToModel(DataRow row)
        {
            Model.InfoType model = new Model.InfoType();
            if (row != null)
            {
                if (row["ITID"] != null && row["ITID"].ToString() != "")
                {
                    model.ITID = Convert.ToInt32(row["ITID"].ToString());
                }
                if (row["IName"] != null)
                {
                    model.IName = row["IName"].ToString();
                }
                if (row["SPID"] != null && row["SPID"].ToString() != "")
                {
                    model.SPID = Convert.ToInt32(row["SPID"].ToString());
                }
                if (row["AttaID"] != null)
                {
                    model.AttaID = row["AttaID"].ToString();
                }
                if (row["SortNum"] != null && row["SortNum"].ToString() != "")
                {
                    model.SortNum = Convert.ToInt32(row["SortNum"].ToString());
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
            strSql.Append("select ITID,IName,SPID,AttaID,SortNum,Status ");
            strSql.Append(" FROM InfoType ");
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
            strSql.Append(" ITID,IName,SPID,AttaID,SortNum,Status ");
            strSql.Append(" FROM InfoType ");
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
            strSql.Append("select count(1) FROM InfoType ");
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
                strSql.Append("order by T.ITID desc");
            }
            strSql.Append(")AS Row, T.*  from InfoType T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "InfoType");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ITID");
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
        public List<Model.InfoType> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ITID,IName,SPID,AttaID,SortNum,Status ");
            strSql.Append(" FROM InfoType ");
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
            List<Model.InfoType> list = new List<Model.InfoType>();
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
        public Model.InfoType ReaderBind(IDataReader dataReader)
        {
            Model.InfoType model = new Model.InfoType();
            object ojb;
            ojb = dataReader["ITID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ITID = Convert.ToInt32(ojb);
            }
            model.IName = dataReader["IName"].ToString();
            ojb = dataReader["SPID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SPID = Convert.ToInt32(ojb);
            }
            model.AttaID = dataReader["AttaID"].ToString();
            ojb = dataReader["SortNum"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.SortNum = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = Convert.ToInt32(ojb);
            }
            return model;
        }

        #endregion  Method

        #region

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ALID, string LName, int SPID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from InfoType where IName=@IName and SPID=@SPID ");
            if (ALID != 0)
            {
                strSql.Append(" and ITID!=" + ALID);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "IName", DbType.String, LName);
            db.AddInParameter(dbCommand, "SPID", DbType.String, SPID);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
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
        /// 得到一个对象实体
        /// </summary>
        public Model.InfoType GetModel(string strWhere, List<SqlParameter> parameters)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from InfoType ");
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
            Model.InfoType model = null;
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
        /// 得到最大ID
        /// </summary>
        public int GetMaxId(int spid)
        {
            string strsql = "select max(SortNum)+1 from InfoType";
            strsql += " where SPID=@SPID and Status=1 ";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strsql.ToString());
            dbCommand.Parameters.Add(new SqlParameter("@SPID", DbType.Int32) { Value = spid });
            object obj = db.ExecuteScalar(dbCommand);
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return 1;
        }

        public bool DelPackType(Model.InfoType model)
        {
            Database db = DatabaseFactory.CreateDatabase();

            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {

                    #region 删除分类及资讯

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from AdInfos where ");
                    strSql.Append(
                        " Inf_IID in(select IID from dbo.Infos where TIID in (select TIID from dbo.TempInfo where ITID=@ITID )); ");

                    strSql.Append("delete from InfoLabel where ");
                    strSql.Append(
                        " IID in(select IID from dbo.Infos where TIID in (select TIID from dbo.TempInfo where ITID=@ITID )); ");

                    strSql.Append("delete from AttaList where ");
                    strSql.Append(
                        " IID in(select IID from dbo.Infos where TIID in (select TIID from dbo.TempInfo where ITID=@ITID )); ");

                    //strSql.Append(" delete from TmpInfoList where TIID in (select TIID from dbo.TempInfo where ITID=@ITID );");
                    strSql.Append(" delete from Infos where TIID in (select TIID from dbo.TempInfo where ITID=@ITID );");
                    strSql.Append(" delete from TempInfo where ITID=@ITID;");
                    strSql.Append(" delete from InfoType where ITID=@ITID;");
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "ITID", DbType.Int32, model.ITID);
                    object obj = db.ExecuteNonQuery(dbCommand, trans);

                    #endregion

                    StringBuilder strSql3 = new StringBuilder();
                    strSql3.Append("select * from  InfoType where SPID=" + model.SPID + " and SortNum>" + model.SortNum);
                    DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                    var dt = db.ExecuteDataSet(dbCommandDel, trans).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var sql = "update InfoType set SortNum=SortNum-1 where ITID=" +
                                      dt.Rows[i]["ITID"];
                            DbCommand dbCommand2 = db.GetSqlStringCommand(sql.ToString());
                            db.ExecuteNonQuery(dbCommand2, trans);
                        }
                    }
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

        #endregion
    }
}

