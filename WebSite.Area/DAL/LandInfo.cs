/**  版本信息模板在安装目录下，可自行修改。
* LandInfo.cs
*
* 功 能： N/A
* 类 名： LandInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/11 16:13:30   N/A    初版
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
    /// 数据访问类:LandInfo
    /// </summary>
    public partial class LandInfo
    {
        public LandInfo()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(LId)+1 from LandInfo";
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
        public bool Exists(int LId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LandInfo where LId=@LId ");
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
        /// 增加一条数据
        /// </summary>
        public int Add(Model.LandInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LandInfo(");
            strSql.Append("AreaId,LName,LArea,LMemo,ParentId,langitude,dimension)");

            strSql.Append(" values (");
            strSql.Append("@AreaId,@LName,@LArea,@LMemo,@ParentId,@langitude,@dimension)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString, model.AreaId);
            db.AddInParameter(dbCommand, "LName", DbType.String, model.LName);
            db.AddInParameter(dbCommand, "LArea", DbType.String, model.LArea);
            db.AddInParameter(dbCommand, "LMemo", DbType.String, model.LMemo);
            db.AddInParameter(dbCommand, "ParentId", DbType.Int32, model.ParentId);
            db.AddInParameter(dbCommand, "langitude", DbType.AnsiString, model.langitude);
            db.AddInParameter(dbCommand, "dimension", DbType.AnsiString, model.dimension);
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
        public bool Update(Model.LandInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LandInfo set ");
            strSql.Append("AreaId=@AreaId,");
            strSql.Append("LName=@LName,");
            strSql.Append("LArea=@LArea,");
            strSql.Append("LMemo=@LMemo,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("langitude=@langitude,");
            strSql.Append("dimension=@dimension");
            strSql.Append(" where LId=@LId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LId", DbType.Int32, model.LId);
            db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString, model.AreaId);
            db.AddInParameter(dbCommand, "LName", DbType.String, model.LName);
            db.AddInParameter(dbCommand, "LArea", DbType.String, model.LArea);
            db.AddInParameter(dbCommand, "LMemo", DbType.String, model.LMemo);
            db.AddInParameter(dbCommand, "ParentId", DbType.Int32, model.ParentId);
            db.AddInParameter(dbCommand, "langitude", DbType.AnsiString, model.langitude);
            db.AddInParameter(dbCommand, "dimension", DbType.AnsiString, model.dimension);
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
        public bool Delete(int LId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LandInfo ");
            strSql.Append(" where LId=@LId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LId", DbType.Int32, LId);
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
        public bool DeleteList(string LIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LandInfo ");
            strSql.Append(" where LId in (" + LIdlist + ")  ");
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
        public Model.LandInfo GetModel(int LId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LId,AreaId,LName,LArea,LMemo,ParentId,langitude,dimension from LandInfo ");
            strSql.Append(" where LId=@LId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "LId", DbType.Int32, LId);
            Model.LandInfo model = null;
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
        public Model.LandInfo DataRowToModel(DataRow row)
        {
            Model.LandInfo model = new Model.LandInfo();
            if (row != null)
            {
                if (row["LId"] != null && row["LId"].ToString() != "")
                {
                    model.LId = Convert.ToInt32(row["LId"].ToString());
                }
                if (row["AreaId"] != null)
                {
                    model.AreaId = row["AreaId"].ToString();
                }
                if (row["LName"] != null)
                {
                    model.LName = row["LName"].ToString();
                }
                if (row["LArea"] != null)
                {
                    model.LArea = row["LArea"].ToString();
                }
                if (row["LMemo"] != null)
                {
                    model.LMemo = row["LMemo"].ToString();
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = Convert.ToInt32(row["ParentId"].ToString());
                }
                if (row["langitude"] != null)
                {
                    model.langitude = row["langitude"].ToString();
                }
                if (row["dimension"] != null)
                {
                    model.dimension = row["dimension"].ToString();
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
            strSql.Append("select LId,AreaId,LName,LArea,LMemo,ParentId,langitude,dimension ");
            strSql.Append(" FROM LandInfo ");
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
            strSql.Append(" LId,AreaId,LName,LArea,LMemo,ParentId,langitude,dimension ");
            strSql.Append(" FROM LandInfo ");
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
            strSql.Append("select count(1) FROM LandInfo ");
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
                strSql.Append("order by T.LId desc");
            }
            strSql.Append(")AS Row, T.*  from LandInfo T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "LandInfo");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "LId");
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
        public List<Model.LandInfo> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LId,AreaId,LName,LArea,LMemo,ParentId,langitude,dimension ");
            strSql.Append(" FROM LandInfo ");
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
            List<Model.LandInfo> list = new List<Model.LandInfo>();
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
        public Model.LandInfo ReaderBind(IDataReader dataReader)
        {
            Model.LandInfo model = new Model.LandInfo();
            object ojb;
            ojb = dataReader["LId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LId = Convert.ToInt32(ojb);
            }
            model.AreaId = dataReader["AreaId"].ToString();
            model.LName = dataReader["LName"].ToString();
            model.LArea = dataReader["LArea"].ToString();
            model.LMemo = dataReader["LMemo"].ToString();
            ojb = dataReader["ParentId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ParentId = Convert.ToInt32(ojb);
            }
            model.langitude = dataReader["langitude"].ToString();
            model.dimension = dataReader["dimension"].ToString();
            return model;
        }

        #endregion  Method
        #region ExMethod
        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetWorStaList(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select row_number() over(order by  lid desc) as rownum,* FROM LandInfo  ");
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
        /// 删除事务方法
        /// </summary>
        /// <param name="lid">lid</param>
        /// <returns></returns>
        public bool DelLandInfo(string lid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LandAttributeValue ");
            strSql.Append(" where LID in (select * from dbo.SplitToTable('" + lid + "',','))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                db.ExecuteNonQuery(dbCommand, trans);
                try
                {
                    StringBuilder strSql3 = new StringBuilder();
                    strSql3.Append("delete from LandCustomer ");
                    strSql3.Append(" where LID in (select * from dbo.SplitToTable('" + lid + "',','))");
                    Database db3 = DatabaseFactory.CreateDatabase();
                    DbCommand dbCommand3 = db3.GetSqlStringCommand(strSql3.ToString());
                    db.ExecuteNonQuery(dbCommand3, trans);

                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("delete from LandInfo ");
                    strSql2.Append(" where LID in (select * from dbo.SplitToTable('" + lid + "',','))");
                    Database db2 = DatabaseFactory.CreateDatabase();
                    DbCommand dbCommand2 = db2.GetSqlStringCommand(strSql2.ToString());
                    int objDel = db.ExecuteNonQuery(dbCommand2, trans);
                    if (objDel > 0)
                    {

                        trans.Commit();
                        result = true;
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
        /// 新增地块
        /// </summary>
        /// <param name="AreaId"></param>
        /// <param name="LName"></param>
        /// <param name="LArea"></param>
        /// <param name="LMemo"></param>
        /// <param name="LAId"></param>
        /// <param name="LAValue"></param>
        /// <param name="EmplId"></param>
        /// <returns></returns>
        public int AddArea(string AreaId, string LName, string LArea, string LMemo, string LAId, string LAValue, int EmplId)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LandInfo(");
            strSql.Append("AreaId,LName,LArea,LMemo)");

            strSql.Append(" values (");
            strSql.Append("@AreaId,@LName,@LArea,@LMemo)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AreaId", DbType.Int32, AreaId);
            db.AddInParameter(dbCommand, "LName", DbType.String, LName);
            db.AddInParameter(dbCommand, "LArea", DbType.String, LArea);
            db.AddInParameter(dbCommand, "LMemo", DbType.String, LMemo);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    if (!string.IsNullOrEmpty(LAId) && !string.IsNullOrEmpty(LAValue))
                    {
                        var LId = db.ExecuteScalar(dbCommand, trans);
                        StringBuilder strSql2 = new StringBuilder();
                        var arrayid = LAId.Split(',');
                        var arrayval = LAValue.Split(',');
                        if (arrayid.Length != arrayval.Length)
                        {
                            return 0;
                        }
                        strSql2.Append("insert into LandAttributeValue(");
                        strSql2.Append(" LId,LAId,EmplId,LAValue,Addtime)");
                        for (int i = 0; i < arrayid.Length; i++)
                        {
                            strSql2.Append(" select " + LId + "," + arrayid[i] + "," + EmplId + ",'" + arrayval[i] + "','" + DateTime.Now + "' ");
                            if (i != arrayid.Length - 1)
                            {
                                strSql2.Append(" union ");
                            }
                        }
                        strSql2.Append(";select @@IDENTITY");
                        DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                        //db.AddInParameter(dbCommand2, "LId", DbType.Int64, LId);
                        //db.AddInParameter(dbCommand2, "LAId", DbType.String, LAId);
                        //db.AddInParameter(dbCommand2, "LAValue", DbType.String, LAValue);
                        //db.AddInParameter(dbCommand2, "EmplId", DbType.Int32, EmplId);
                        //db.AddInParameter(dbCommand2, "Addtime", DbType.DateTime, DateTime.Now);
                        object obj = db.ExecuteScalar(dbCommand2, trans);
                        if (!int.TryParse(obj.ToString(), out result))
                        {
                            trans.Rollback();
                            return 0;
                        }
                    }
                    else
                    {
                        object obj = db.ExecuteScalar(dbCommand, trans);
                        if (!int.TryParse(obj.ToString(), out result))
                        {
                            trans.Rollback();
                            return 0;
                        }
                    }
                    trans.Commit();
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
        /// 更新地块
        /// </summary>
        /// <param name="AreaId"></param>
        /// <param name="LName"></param>
        /// <param name="LArea"></param>
        /// <param name="LMemo"></param>
        /// <param name="LAId"></param>
        /// <param name="LAValue"></param>
        /// <param name="EmplId"></param>
        /// <returns></returns>
        public int UpdateArea(int LId, string AreaId, string LName, string LArea, string LMemo, string LAId, string LAValue, int EmplId)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LandInfo set ");
            strSql.Append("AreaId=@AreaId,");
            strSql.Append("LName=@LName,");
            strSql.Append("LArea=@LArea,");
            strSql.Append("LMemo=@LMemo ");
            strSql.Append(" where LId=@LId ");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AreaId", DbType.Int32, AreaId);
            db.AddInParameter(dbCommand, "LName", DbType.String, LName);
            db.AddInParameter(dbCommand, "LArea", DbType.String, LArea);
            db.AddInParameter(dbCommand, "LMemo", DbType.String, LMemo);
            db.AddInParameter(dbCommand, "LId", DbType.Int32, LId);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {

                    int rows = db.ExecuteNonQuery(dbCommand, trans);
                    if (rows > 0)
                    {

                        StringBuilder strSql2 = new StringBuilder();
                        var arrayid = LAId.Split(',');
                        var arrayval = LAValue.Split(',');
                        if (arrayid.Length != arrayval.Length)
                        {
                            return 0;
                        }
                        strSql2.Append(" delete from LandAttributeValue  where LId=" + LId + " ");
                        if (!string.IsNullOrEmpty(LAId) && !string.IsNullOrEmpty(LAValue))
                        {
                            strSql2.Append(" insert into LandAttributeValue(");
                            strSql2.Append(" LId,LAId,EmplId,LAValue,Addtime)");
                            for (int i = 0; i < arrayid.Length; i++)
                            {
                                strSql2.Append(" select " + LId + "," + arrayid[i] + "," + EmplId + ",'" + arrayval[i] + "','" + DateTime.Now + "' ");
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
                        }
                        else
                        {
                            DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                            result = db.ExecuteNonQuery(dbCommand2, trans);
                        }
                    }
                    trans.Commit();

                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }
        public bool DelLandInfo(int LId)
        {
            bool result = false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LandAttributeValue ");
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
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("delete from LandInfo ");
                    strSql2.Append(" where LId=@LID");
                    strSql2.Append(";select @@IDENTITY");
                    Database db2 = DatabaseFactory.CreateDatabase();
                    DbCommand dbCommand2 = db2.GetSqlStringCommand(strSql2.ToString());
                    db.AddInParameter(dbCommand2, "LId", DbType.Int32, LId);
                    int objDel = db.ExecuteNonQuery(dbCommand2, trans);
                    if (objDel > 0)
                    {
                        trans.Commit();
                        result = true;
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

        #endregion

    }
}

