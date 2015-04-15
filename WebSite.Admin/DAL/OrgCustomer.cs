/**  版本信息模板在安装目录下，可自行修改。
* OrgCustomer.cs
*
* 功 能： N/A
* 类 名： OrgCustomer
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014-01-16 16:50:22   N/A    初版
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
    /// 数据访问类:OrgCustomer
    /// </summary>
    public partial class OrgCustomer
    {
        public OrgCustomer()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(CId)+1 from OrgCustomer";
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
        public bool Exists(int CId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrgCustomer where CId=@CId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CId", DbType.Int32, CId);
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
        public int Add(Model.OrgCustomer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgCustomer(");
            strSql.Append("OrgId,Name,Sex,Birthday,HomeAddress,SelfCard,AddTime,Status,UId,UserName,Password,Mobile)");

            strSql.Append(" values (");
            strSql.Append("@OrgId,@Name,@Sex,@Birthday,@HomeAddress,@SelfCard,@AddTime,@Status,@UId,@UserName,@Password,@Mobile)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
            db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
            db.AddInParameter(dbCommand, "Sex", DbType.String, model.Sex);
            db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, model.Birthday);
            db.AddInParameter(dbCommand, "HomeAddress", DbType.String, model.HomeAddress);
            db.AddInParameter(dbCommand, "SelfCard", DbType.AnsiString, model.SelfCard);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
            db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
            db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
            db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
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
        public bool Update(Model.OrgCustomer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgCustomer set ");
            strSql.Append("OrgId=@OrgId,");
            strSql.Append("Name=@Name,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("HomeAddress=@HomeAddress,");
            strSql.Append("SelfCard=@SelfCard,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Status=@Status,");
            strSql.Append("UId=@UId,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("Mobile=@Mobile");
            strSql.Append(" where CId=@CId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CId", DbType.Int32, model.CId);
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
            db.AddInParameter(dbCommand, "Name", DbType.String, model.Name);
            db.AddInParameter(dbCommand, "Sex", DbType.String, model.Sex);
            db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, model.Birthday);
            db.AddInParameter(dbCommand, "HomeAddress", DbType.String, model.HomeAddress);
            db.AddInParameter(dbCommand, "SelfCard", DbType.AnsiString, model.SelfCard);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
            db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
            db.AddInParameter(dbCommand, "Password", DbType.AnsiString, model.Password);
            db.AddInParameter(dbCommand, "Mobile", DbType.AnsiString, model.Mobile);
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
        public bool Delete(int CId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgCustomer ");
            strSql.Append(" where CId=@CId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CId", DbType.Int32, CId);
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
        public bool DeleteList(string CIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgCustomer ");
            strSql.Append(" where CId in (" + CIdlist + ")  ");
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
        public Model.OrgCustomer GetModel(int CId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,OrgId,Name,Sex,Birthday,HomeAddress,SelfCard,AddTime,Status,UId,UserName,Password,Mobile from OrgCustomer ");
            strSql.Append(" where CId=@CId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CId", DbType.Int32, CId);
            Model.OrgCustomer model = null;
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
        public Model.OrgCustomer DataRowToModel(DataRow row)
        {
            Model.OrgCustomer model = new Model.OrgCustomer();
            if (row != null)
            {
                if (row["CId"] != null && row["CId"].ToString() != "")
                {
                    model.CId = Convert.ToInt32(row["CId"].ToString());
                }
                if (row["OrgId"] != null && row["OrgId"].ToString() != "")
                {
                    model.OrgId = Convert.ToInt64(row["OrgId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = Convert.ToDateTime(row["Birthday"].ToString());
                }
                if (row["HomeAddress"] != null)
                {
                    model.HomeAddress = row["HomeAddress"].ToString();
                }
                if (row["SelfCard"] != null)
                {
                    model.SelfCard = row["SelfCard"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = Convert.ToDateTime(row["AddTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(row["Status"].ToString());
                }
                if (row["UId"] != null && row["UId"].ToString() != "")
                {
                    model.UId = Convert.ToInt32(row["UId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
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
            strSql.Append("select CId,OrgId,Name,Sex,Birthday,HomeAddress,SelfCard,AddTime,Status,UId,UserName,Password,Mobile ");
            strSql.Append(" FROM OrgCustomer ");
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
            strSql.Append(" CId,OrgId,Name,Sex,Birthday,HomeAddress,SelfCard,AddTime,Status,UId,UserName,Password,Mobile ");
            strSql.Append(" FROM OrgCustomer ");
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
            strSql.Append("select count(1) FROM OrgCustomer ");
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
                strSql.Append("order by T.CId desc");
            }
            strSql.Append(")AS Row, T.*  from OrgCustomer T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgCustomer");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "CId");
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
        public List<Model.OrgCustomer> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,OrgId,Name,Sex,Birthday,HomeAddress,SelfCard,AddTime,Status,UId,UserName,Password,Mobile ");
            strSql.Append(" FROM OrgCustomer ");
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
            List<Model.OrgCustomer> list = new List<Model.OrgCustomer>();
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
        public Model.OrgCustomer ReaderBind(IDataReader dataReader)
        {
            Model.OrgCustomer model = new Model.OrgCustomer();
            object ojb;
            ojb = dataReader["CId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.CId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["OrgId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrgId = Convert.ToInt64(ojb);
            }
            model.Name = dataReader["Name"].ToString();
            model.Sex = dataReader["Sex"].ToString();
            ojb = dataReader["Birthday"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Birthday = Convert.ToDateTime(ojb);
            }
            model.HomeAddress = dataReader["HomeAddress"].ToString();
            model.SelfCard = dataReader["SelfCard"].ToString();
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
            ojb = dataReader["UId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UId = Convert.ToInt32(ojb);
            }
            model.UserName = dataReader["UserName"].ToString();
            model.Password = dataReader["Password"].ToString();
            model.Mobile = dataReader["Mobile"].ToString();
            return model;
        }

        #endregion  Method
        #region ExMethod
        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListByAid(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select oc.*,oe.EmplName,oo.[OrgName] from [OrgCustomer] oc ");
            strSql.Append("join [OrgOrganize] oo on oo.[OrgId]=oc.[OrgId] ");
            strSql.Append("join [OrgArea] oa on oa.[AreaId]=oo.[AreaId] ");
            strSql.Append("join [OrgUsers] ou on ou.[UId]=oc.[UId] ");
            strSql.Append("join [OrgEmployees] oe on oe.[EmplId]=ou.[EmplId] ");
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
        /// 是否存在该记录
        /// </summary>
        public bool ExistsUserName(string UserName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrgCustomer where UserName=@UserName ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UserName", DbType.String, UserName);
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
        /// 删除人员信息
        /// </summary>
        /// <param name="cId">会员ID</param>
        /// <returns></returns>
        public bool DeleteUser(string cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" delete  OrgCustomer where CId in (select * from dbo.SplitToTable('" + cid + "',',')) ");
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
        /// 获得会员数据
        /// </summary>
        public string GetDateList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select row_number() over(order by CID DESC) as rownum,CId,OrgId,Name,Sex,Birthday,HomeAddress,SelfCard,AddTime,Status,UId,UserName,Password,Mobile,Point   ");
            strSql.Append(" from OrgCustomer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return strSql.ToString();
        }
        /// <summary>
        /// 启用会员方法
        /// </summary>
        /// <param name="aid">商品Id</param>
        /// <param name="status">审核状态</param>
        /// <returns></returns>
        public bool CheckUser(string aid, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgCustomer set Status=@Status");
            strSql.Append(" where AId in (select * from SplitToTable(@AId,','))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            var parameter1 = new SqlParameter("@Status", DbType.Int32);
            parameter1.Value = status;
            dbCommand.Parameters.Add(parameter1);
            var parameter = new SqlParameter("@AId", DbType.AnsiString);
            parameter.Value = aid;
            dbCommand.Parameters.Add(parameter);
            var parameter3 = new SqlParameter("@CheckTime", DbType.DateTime);
            parameter3.Value = DateTime.Now;
            dbCommand.Parameters.Add(parameter3);
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
        /// 启用/停用注册会员
        /// </summary>
        /// <param name="cid">会员ID</param>
        /// <param name="status">当前审核状态（1 注册用户启用，2 注册用户停用，3 注册用户删除）</param>
        /// <returns></returns>
        public bool UpdateState(int cid, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgCustomer set ");
            strSql.Append("Status=@status");
            strSql.Append(" where CId=@cid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "status", DbType.Int32, status);
            db.AddInParameter(dbCommand, "cid", DbType.Int32, cid);
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
        /// 根据用户名获取用户ID
        /// </summary>
        public Model.OrgCustomer GetModelByUserName(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CId,OrgId,Name,Sex,Birthday,HomeAddress,SelfCard,AddTime,Status,UId,UserName,Password,Mobile,Des,Age,Nickname,WineAge,ProductLike,Point,RecName from OrgCustomer ");
            strSql.Append(" where UserName=@UserName ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UserName", DbType.String, UserName);
            Model.OrgCustomer model = null;
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
        /// 根据用户ID获取该ID下所有下属会员数据列表
        /// </summary>
        public DataSet GetListByUID(int UID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CID,Name,Point ");
            strSql.Append(" FROM OrgCustomer ");
            strSql.Append(" where RecName=@RecName ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RecName", DbType.String, UID);
            return db.ExecuteDataSet(dbCommand);
        } /// <summary>
        /// <summary>
        /// 删除农户帐户事务方法
        /// </summary>
        /// <param name="cId">orgId</param>
        /// <returns></returns>
        public bool DelCusTran(string cId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgCustomer ");
            strSql.Append(" set Status=0 ");
            strSql.Append(" where CId in (select * from dbo.SplitToTable('" + cId + "',','))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    object objDel = db.ExecuteNonQuery(dbCommand, trans);
                    //StringBuilder strSql2 = new StringBuilder();
                    //strSql2.Append("update OrgEmployees ");
                    //strSql2.Append(" set Status=0 ");
                    //strSql2.Append(" where EmplId in (select * from dbo.SplitToTable('" + orgId + "',','))");
                    //DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    //db.ExecuteNonQuery(dbCommand2, trans);
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
        public DataSet GetListData(string sql)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(sql.ToString());

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}

