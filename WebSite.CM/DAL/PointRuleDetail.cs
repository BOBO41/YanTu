/**  版本信息模板在安装目录下，可自行修改。
* PointRuleDetail.cs
*
* 功 能： N/A
* 类 名： PointRuleDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/2/25 14:35:56   N/A    初版
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
    /// 数据访问类:PointRuleDetail
    /// </summary>
    public partial class PointRuleDetail
    {
        public PointRuleDetail()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RDID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PointRuleDetail where RDID=@RDID ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RDID", DbType.Int32, RDID);
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
        public int Add(Model.PointRuleDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PointRuleDetail(");
            strSql.Append("RID,UID,AddTime,RxValue,RyValue)");

            strSql.Append(" values (");
            strSql.Append("@RID,@UID,@AddTime,@RxValue,@RyValue)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RID", DbType.Int32, model.RID);
            db.AddInParameter(dbCommand, "UID", DbType.Int32, model.UID);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
            db.AddInParameter(dbCommand, "RxValue", DbType.String, model.RxValue);
            db.AddInParameter(dbCommand, "RyValue", DbType.String, model.RyValue);
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
        public bool Update(Model.PointRuleDetail model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PointRuleDetail set ");
            strSql.Append("RID=@RID,");
            strSql.Append("UID=@UID,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("RxValue=@RxValue,");
            strSql.Append("RyValue=@RyValue");
            strSql.Append(" where RDID=@RDID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RDID", DbType.Int32, model.RDID);
            db.AddInParameter(dbCommand, "RID", DbType.Int32, model.RID);
            db.AddInParameter(dbCommand, "UID", DbType.Int32, model.UID);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
            db.AddInParameter(dbCommand, "RxValue", DbType.String, model.RxValue);
            db.AddInParameter(dbCommand, "RyValue", DbType.String, model.RyValue);
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
        public bool Delete(int RDID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PointRuleDetail ");
            strSql.Append(" where RDID=@RDID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RDID", DbType.Int32, RDID);
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
        public bool DeleteList(string RDIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PointRuleDetail ");
            strSql.Append(" where RDID in (" + RDIDlist + ")  ");
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
        public Model.PointRuleDetail GetModel(int RDID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RDID,RID,UID,AddTime,RxValue,RyValue from PointRuleDetail ");
            strSql.Append(" where RDID=@RDID ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RDID", DbType.Int32, RDID);
            Model.PointRuleDetail model = null;
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
        public Model.PointRuleDetail DataRowToModel(DataRow row)
        {
            Model.PointRuleDetail model = new Model.PointRuleDetail();
            if (row != null)
            {
                if (row["RDID"] != null && row["RDID"].ToString() != "")
                {
                    model.RDID = Convert.ToInt32(row["RDID"].ToString());
                }
                if (row["RID"] != null && row["RID"].ToString() != "")
                {
                    model.RID = Convert.ToInt32(row["RID"].ToString());
                }
                if (row["UID"] != null && row["UID"].ToString() != "")
                {
                    model.UID = Convert.ToInt32(row["UID"].ToString());
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = Convert.ToDateTime(row["AddTime"].ToString());
                }
                if (row["RxValue"] != null)
                {
                    model.RxValue = row["RxValue"].ToString();
                }
                if (row["RyValue"] != null)
                {
                    model.RyValue = row["RyValue"].ToString();
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
            strSql.Append("select RDID,RID,UID,AddTime,RxValue,RyValue ");
            strSql.Append(" FROM PointRuleDetail ");
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
            strSql.Append(" RDID,RID,UID,AddTime,RxValue,RyValue ");
            strSql.Append(" FROM PointRuleDetail ");
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
            strSql.Append("select count(1) FROM PointRuleDetail ");
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
                strSql.Append("order by T.RDID desc");
            }
            strSql.Append(")AS Row, T.*  from PointRuleDetail T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "PointRuleDetail");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "RDID");
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
        public List<Model.PointRuleDetail> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RDID,RID,UID,AddTime,RxValue,RyValue ");
            strSql.Append(" FROM PointRuleDetail ");
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
            List<Model.PointRuleDetail> list = new List<Model.PointRuleDetail>();
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
        public Model.PointRuleDetail ReaderBind(IDataReader dataReader)
        {
            Model.PointRuleDetail model = new Model.PointRuleDetail();
            object ojb;
            ojb = dataReader["RDID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RDID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["RID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["UID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UID = Convert.ToInt32(ojb);
            }
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = Convert.ToDateTime(ojb);
            }
            model.RxValue = dataReader["RxValue"].ToString();
            model.RyValue = dataReader["RyValue"].ToString();
            return model;
        }

        #endregion  Method
        #region ExMethod
        /// <summary>
        /// 获取秒杀详细
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public string GetDateList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select row_number() over(order by ADDTIME DESC) as rownum,* ");
            strSql.Append(" from PointRuleDetail ");
            strSql.Append(" where RID=2 ");
            return strSql.ToString();
        }
        #endregion
    }
}

