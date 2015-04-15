/**  版本信息模板在安装目录下，可自行修改。
* TempInfo.cs
*
* 功 能： N/A
* 类 名： TempInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  1/4/2015 6:02:05 PM   N/A    初版
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
    /// 数据访问类:TempInfo
    /// </summary>
    public partial class TempInfo
    {
        public TempInfo()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(TIID)+1 from TempInfo";
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
        public bool Exists(int TIID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TempInfo where TIID=@TIID ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TIID", DbType.Int32, TIID);
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
        public int Add(Model.TempInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TempInfo(");
            strSql.Append("ITID,TID,AttID,TIPage,ParentID)");

            strSql.Append(" values (");
            strSql.Append("@ITID,@TID,@AttID,@TIPage,@ParentID)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "ITID", DbType.Int32, model.ITID);
            db.AddInParameter(dbCommand, "TID", DbType.Int32, model.TID);
            db.AddInParameter(dbCommand, "AttID", DbType.String, model.AttID);
            db.AddInParameter(dbCommand, "TIPage", DbType.Int32, model.TIPage);
            db.AddInParameter(dbCommand, "ParentID", DbType.Int32, model.ParentID);
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
        public bool Update(Model.TempInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TempInfo set ");
            strSql.Append("ITID=@ITID,");
            strSql.Append("TID=@TID,");
            strSql.Append("AttID=@AttID,");
            strSql.Append("TIPage=@TIPage,");
            strSql.Append("ParentID=@ParentID");
            strSql.Append(" where TIID=@TIID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TIID", DbType.Int32, model.TIID);
            db.AddInParameter(dbCommand, "ITID", DbType.Int32, model.ITID);
            db.AddInParameter(dbCommand, "TID", DbType.Int32, model.TID);
            db.AddInParameter(dbCommand, "AttID", DbType.String, model.AttID);
            db.AddInParameter(dbCommand, "TIPage", DbType.Int32, model.TIPage);
            db.AddInParameter(dbCommand, "ParentID", DbType.Int32, model.ParentID);
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
        public bool Delete(int TIID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TempInfo ");
            strSql.Append(" where TIID=@TIID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TIID", DbType.Int32, TIID);
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
        public bool DeleteList(string TIIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TempInfo ");
            strSql.Append(" where TIID in (" + TIIDlist + ")  ");
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
        public Model.TempInfo GetModel(int TIID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TIID,ITID,TID,AttID,TIPage,ParentID from TempInfo ");
            strSql.Append(" where TIID=@TIID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "TIID", DbType.Int32, TIID);
            Model.TempInfo model = null;
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
        public Model.TempInfo DataRowToModel(DataRow row)
        {
            Model.TempInfo model = new Model.TempInfo();
            if (row != null)
            {
                if (row["TIID"] != null && row["TIID"].ToString() != "")
                {
                    model.TIID = Convert.ToInt32(row["TIID"].ToString());
                }
                if (row["ITID"] != null && row["ITID"].ToString() != "")
                {
                    model.ITID = Convert.ToInt32(row["ITID"].ToString());
                }
                if (row["TID"] != null && row["TID"].ToString() != "")
                {
                    model.TID = Convert.ToInt32(row["TID"].ToString());
                }
                if (row["AttID"] != null)
                {
                    model.AttID = row["AttID"].ToString();
                }
                if (row["TIPage"] != null && row["TIPage"].ToString() != "")
                {
                    model.TIPage = Convert.ToInt32(row["TIPage"].ToString());
                }
                if (row["ParentID"] != null && row["ParentID"].ToString() != "")
                {
                    model.ParentID = Convert.ToInt32(row["ParentID"].ToString());
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
            strSql.Append("select TIID,ITID,TID,AttID,TIPage,ParentID ");
            strSql.Append(" FROM TempInfo ");
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
            strSql.Append(" TIID,ITID,TID,AttID,TIPage,ParentID ");
            strSql.Append(" FROM TempInfo ");
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
            strSql.Append("select count(1) FROM TempInfo ");
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
                strSql.Append("order by T.TIID desc");
            }
            strSql.Append(")AS Row, T.*  from TempInfo T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "TempInfo");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "TIID");
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
        public List<Model.TempInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TIID,ITID,TID,AttID,TIPage,ParentID ");
            strSql.Append(" FROM TempInfo ");
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
            List<Model.TempInfo> list = new List<Model.TempInfo>();
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
        public Model.TempInfo ReaderBind(IDataReader dataReader)
        {
            Model.TempInfo model = new Model.TempInfo();
            object ojb;
            ojb = dataReader["TIID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TIID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["ITID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ITID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["TID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TID = Convert.ToInt32(ojb);
            }
            model.AttID = dataReader["AttID"].ToString();
            ojb = dataReader["TIPage"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TIPage = Convert.ToInt32(ojb);
            }
            ojb = dataReader["ParentID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentID = Convert.ToInt32(ojb);
            }
            return model;
        }

        #endregion  Method

        #region

        public Model.TempInfo GetModel(string strWhere, List<SqlParameter> parameters)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from TempInfo ");
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
            Model.TempInfo model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        public Model.TempInfo GetModel(string iid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from TempInfo join TmpInfoList on TmpInfoList.TIID=TempInfo.TIID ");
            Database db = DatabaseFactory.CreateDatabase();

            strSql.Append(" where TmpInfoList.IID=" + iid + " and TempInfo.TIPage=1 ");

            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());

            Model.TempInfo model = null;
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

