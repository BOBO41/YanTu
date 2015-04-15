/**  版本信息模板在安装目录下，可自行修改。
* BankPayList.cs
*
* 功 能： N/A
* 类 名： BankPayList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/6/11 14:20:27   N/A    初版
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
    /// 数据访问类:BankPayList
    /// </summary>
    public partial class BankPayList
    {
        public BankPayList()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(PayId)+1 from BankPayList";
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
        public bool Exists(int PayId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from BankPayList where PayId=@PayId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "PayId", DbType.Int32, PayId);
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
        public int Add(Model.BankPayList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BankPayList(");
            strSql.Append("AccountNo,OrderNO,Fee,PayType,PayTime,status,CAccountNo)");

            strSql.Append(" values (");
            strSql.Append("@AccountNo,@OrderNO,@Fee,@PayType,@PayTime,@status,@CAccountNo)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, model.AccountNo);
            db.AddInParameter(dbCommand, "OrderNO", DbType.AnsiString, model.OrderNO);
            db.AddInParameter(dbCommand, "Fee", DbType.Currency, model.Fee);
            db.AddInParameter(dbCommand, "PayType", DbType.Byte, model.PayType);
            db.AddInParameter(dbCommand, "PayTime", DbType.DateTime, model.PayTime);
            db.AddInParameter(dbCommand, "status", DbType.Byte, model.status);
            db.AddInParameter(dbCommand, "CAccountNo", DbType.AnsiString, model.CAccountNo);
            int result;
            object obj = db.ExecuteNonQuery(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.BankPayList model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BankPayList set ");
            strSql.Append("AccountNo=@AccountNo,");
            strSql.Append("OrderNO=@OrderNO,");
            strSql.Append("Fee=@Fee,");
            strSql.Append("PayType=@PayType,");
            strSql.Append("PayTime=@PayTime,");
            strSql.Append("status=@status,");
            strSql.Append("CAccountNo=@CAccountNo");
            strSql.Append(" where PayId=@PayId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "PayId", DbType.Int32, model.PayId);
            db.AddInParameter(dbCommand, "AccountNo", DbType.AnsiString, model.AccountNo);
            db.AddInParameter(dbCommand, "OrderNO", DbType.AnsiString, model.OrderNO);
            db.AddInParameter(dbCommand, "Fee", DbType.Currency, model.Fee);
            db.AddInParameter(dbCommand, "PayType", DbType.Byte, model.PayType);
            db.AddInParameter(dbCommand, "PayTime", DbType.DateTime, model.PayTime);
            db.AddInParameter(dbCommand, "status", DbType.Byte, model.status);
            db.AddInParameter(dbCommand, "CAccountNo", DbType.AnsiString, model.CAccountNo);
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
        public bool Delete(int PayId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BankPayList ");
            strSql.Append(" where PayId=@PayId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "PayId", DbType.Int32, PayId);
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
        public bool DeleteList(string PayIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BankPayList ");
            strSql.Append(" where PayId in (" + PayIdlist + ")  ");
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
        public Model.BankPayList GetModel(int PayId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PayId,AccountNo,OrderNO,Fee,PayType,PayTime,status,CAccountNo from BankPayList ");
            strSql.Append(" where PayId=@PayId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "PayId", DbType.Int32, PayId);
            Model.BankPayList model = null;
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
        public Model.BankPayList DataRowToModel(DataRow row)
        {
            Model.BankPayList model = new Model.BankPayList();
            if (row != null)
            {
                if (row["PayId"] != null && row["PayId"].ToString() != "")
                {
                    model.PayId = Convert.ToInt32(row["PayId"].ToString());
                }
                if (row["AccountNo"] != null)
                {
                    model.AccountNo = row["AccountNo"].ToString();
                }
                if (row["OrderNO"] != null)
                {
                    model.OrderNO = row["OrderNO"].ToString();
                }
                if (row["Fee"] != null && row["Fee"].ToString() != "")
                {
                    model.Fee = Convert.ToDecimal(row["Fee"].ToString());
                }
                if (row["PayType"] != null && row["PayType"].ToString() != "")
                {
                    model.PayType = Convert.ToInt32(row["PayType"].ToString());
                }
                if (row["PayTime"] != null && row["PayTime"].ToString() != "")
                {
                    model.PayTime = Convert.ToDateTime(row["PayTime"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = Convert.ToInt32(row["status"].ToString());
                }
                if (row["CAccountNo"] != null)
                {
                    model.CAccountNo = row["CAccountNo"].ToString();
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
            strSql.Append("select PayId,AccountNo,PayType,Fee,PayTime,status,OrderNO,CAccountNo ");
            strSql.Append(" FROM BankPayList ");
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
            strSql.Append(" PayId,AccountNo,OrderNO,Fee,PayType,PayTime,status,CAccountNo ");
            strSql.Append(" FROM BankPayList ");
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
            strSql.Append("select count(1) FROM BankPayList ");
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
                strSql.Append("order by T.PayId desc");
            }
            strSql.Append(")AS Row, T.*  from BankPayList T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "BankPayList");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "PayId");
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
        public List<Model.BankPayList> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PayId,AccountNo,OrderNO,Fee,PayType,PayTime,status,CAccountNo ");
            strSql.Append(" FROM BankPayList ");
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
            List<Model.BankPayList> list = new List<Model.BankPayList>();
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
        public Model.BankPayList ReaderBind(IDataReader dataReader)
        {
            Model.BankPayList model = new Model.BankPayList();
            object ojb;
            ojb = dataReader["PayId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PayId = Convert.ToInt32(ojb);
            }
            model.AccountNo = dataReader["AccountNo"].ToString();
            model.OrderNO = dataReader["OrderNO"].ToString();
            ojb = dataReader["Fee"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Fee = Convert.ToDecimal(ojb);
            }
            ojb = dataReader["PayType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PayType = Convert.ToInt32(ojb);
            }
            ojb = dataReader["PayTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PayTime = Convert.ToDateTime(ojb);
            }
            ojb = dataReader["status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.status = Convert.ToInt32(ojb);
            }
            model.CAccountNo = dataReader["CAccountNo"].ToString();
            return model;
        }



        #endregion  Method

        #region  扩展方法
        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListData(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PayId,AccountNo,PayType,a.Fee,PayTime,a.status,a.OrderNO,c.Name,b.Fee as FeeMany,CAccountNo ");
            strSql.Append(" FROM BankPayList a left join OrderList b on a.OrderNO=b.OrderNO ");
            strSql.Append(" left join OrgCustomer c on b.CID=c.CID ");
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
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public string GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select row_number() over(order by PayTime desc) as rownum,PayId,AccountNo,PayType,Fee,PayTime,status,OrderNO,CAccountNo ");
            strSql.Append(" FROM BankPayList ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return strSql.ToString();
        }
        #endregion
    }
}

