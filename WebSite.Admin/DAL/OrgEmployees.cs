/**  版本信息模板在安装目录下，可自行修改。
* OrgEmployees.cs
*
* 功 能： N/A
* 类 名： OrgEmployees
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-12-30 19:03:04   N/A    初版
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

//Please add references
namespace WebSite.Admin.DAL
{
    /// <summary>
    /// 数据访问类:OrgEmployees
    /// </summary>
    public partial class OrgEmployees
    {
        public OrgEmployees()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(EmplId)+1 from OrgEmployees";
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
        public bool Exists(int EmplId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrgEmployees where EmplId=@EmplId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, EmplId);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, global::System.DBNull.Value)))
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
        public int Add(Model.OrgEmployees model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgEmployees(");
            strSql.Append("OrgId,EmplName,Sex,Birthday,HomeAddress,Phone,Status,Addtime)");

            strSql.Append(" values (");
            strSql.Append("@OrgId,@EmplName,@Sex,@Birthday,@HomeAddress,@Phone,@Status,@Addtime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
            db.AddInParameter(dbCommand, "EmplName", DbType.String, model.EmplName);
            db.AddInParameter(dbCommand, "Sex", DbType.AnsiString, model.Sex);
            db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, model.Birthday);
            db.AddInParameter(dbCommand, "HomeAddress", DbType.String, model.HomeAddress);
            db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, model.Phone);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "Addtime", DbType.DateTime, model.Addtime);
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
        public bool Update(Model.OrgEmployees model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgEmployees set ");
            strSql.Append("OrgId=@OrgId,");
            strSql.Append("EmplName=@EmplName,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("HomeAddress=@HomeAddress,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Status=@Status,");
            strSql.Append("Addtime=@Addtime");
            strSql.Append(" where EmplId=@EmplId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
            db.AddInParameter(dbCommand, "EmplName", DbType.String, model.EmplName);
            db.AddInParameter(dbCommand, "Sex", DbType.AnsiString, model.Sex);
            db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, model.Birthday);
            db.AddInParameter(dbCommand, "HomeAddress", DbType.String, model.HomeAddress);
            db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, model.Phone);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "Addtime", DbType.DateTime, model.Addtime);
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
        public bool Delete(int EmplId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgEmployees ");
            strSql.Append(" where EmplId=@EmplId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, EmplId);
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
        public bool DeleteList(string EmplIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgEmployees ");
            strSql.Append(" where EmplId in (" + EmplIdlist + ")  ");
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
        public Model.OrgEmployees GetModel(int EmplId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EmplId,OrgId,EmplName,Sex,Birthday,HomeAddress,Phone,Status,Addtime from OrgEmployees ");
            strSql.Append(" where EmplId=@EmplId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, EmplId);
            Model.OrgEmployees model = null;
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
        public Model.OrgEmployees DataRowToModel(DataRow row)
        {
            Model.OrgEmployees model = new Model.OrgEmployees();
            if (row != null)
            {
                if (row["EmplId"] != null && row["EmplId"].ToString() != "")
                {
                    model.EmplId = Convert.ToInt32(row["EmplId"].ToString());
                }
                if (row["OrgId"] != null && row["OrgId"].ToString() != "")
                {
                    model.OrgId = Convert.ToInt64(row["OrgId"].ToString());
                }
                if (row["EmplName"] != null)
                {
                    model.EmplName = row["EmplName"].ToString();
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
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(row["Status"].ToString());
                }
                if (row["Addtime"] != null && row["Addtime"].ToString() != "")
                {
                    model.Addtime = Convert.ToDateTime(row["Addtime"].ToString());
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
            strSql.Append("select EmplId,OrgId,EmplName,Sex,Birthday,HomeAddress,Phone,Status,Addtime ");
            strSql.Append(" FROM OrgEmployees ");
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
            strSql.Append(" EmplId,OrgId,EmplName,Sex,Birthday,HomeAddress,Phone,Status,Addtime ");
            strSql.Append(" FROM OrgEmployees ");
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
            strSql.Append("select count(1) FROM OrgEmployees ");
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
                strSql.Append("order by T.EmplId desc");
            }
            strSql.Append(")AS Row, T.*  from OrgEmployees T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgEmployees");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "EmplId");
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
        public List<Model.OrgEmployees> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select EmplId,OrgId,EmplName,Sex,Birthday,HomeAddress,Phone,Status,Addtime ");
            strSql.Append(" FROM OrgEmployees ");
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
            List<Model.OrgEmployees> list = new List<Model.OrgEmployees>();
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
        public Model.OrgEmployees ReaderBind(IDataReader dataReader)
        {
            Model.OrgEmployees model = new Model.OrgEmployees();
            object ojb;
            ojb = dataReader["EmplId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EmplId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["OrgId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrgId = Convert.ToInt64(ojb);
            }
            model.EmplName = dataReader["EmplName"].ToString();
            model.Sex = dataReader["Sex"].ToString();
            ojb = dataReader["Birthday"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Birthday = Convert.ToDateTime(ojb);
            }
            model.HomeAddress = dataReader["HomeAddress"].ToString();
            model.Phone = dataReader["Phone"].ToString();
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Addtime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Addtime = Convert.ToDateTime(ojb);
            }
            return model;
        }

        #endregion  Method

        #region  扩展方法

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DelList(string BrandIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductBrand ");
            strSql.Append(" where BrandId in (select * from SplitToTable(@BrandId,','))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            var parameter = new SqlParameter("@BrandId", DbType.AnsiString);
            parameter.Value = BrandIdlist;
            dbCommand.Parameters.Add(parameter);
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
        /// 添加品牌信息事务方法
        /// </summary>
        /// <param name="brandName">品牌信息名称</param>
        /// <param name="brandIds">品牌Id</param>
        /// <returns></returns>
        public bool InsertProBrands(string brandName, string brandIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductBrand(");
            strSql.Append("BrandName,addtime)");

            strSql.Append(" values (");
            strSql.Append("@BrandName,@addtime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "BrandName", DbType.AnsiString, brandName);
            db.AddInParameter(dbCommand, "addtime", DbType.DateTime, DateTime.Now);
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    object obj = db.ExecuteScalar(dbCommand, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("insert into [ProductBrandType] ([BrandId],[PTId]) select " + obj + ",fieldvalue from dbo.SplitToTable('" + brandIds + "',',')");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
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
        /// 修改品牌信息事务方法
        /// </summary>
        /// <param name="brandId">品牌Id</param>
        /// <param name="brandName">品牌信息名称</param>
        /// <param name="brandIds">品牌Id</param>
        /// <returns></returns>
        public bool UpdateProBrands(string brandId, string brandName, string brandIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductBrand");
            strSql.Append(" set BrandName=@BrandName ");
            strSql.Append(" where BrandId=@BrandId");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "BrandName", DbType.AnsiString, brandName);
            db.AddInParameter(dbCommand, "BrandId", DbType.Int32, brandId);
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    object obj = db.ExecuteScalar(dbCommand, trans);
                    StringBuilder strSql3 = new StringBuilder();
                    strSql3.Append("delete from  ProductBrandType where BrandId=@BrandId");
                    DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                    db.AddInParameter(dbCommandDel, "BrandId", DbType.Int32, brandId);
                    object objDel = db.ExecuteNonQuery(dbCommandDel, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("insert into [ProductBrandType] ([BrandId],[PTId]) select " + brandId + ",fieldvalue from dbo.SplitToTable('" + brandIds + "',',')");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
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
        /// 删除人员信息事务方法
        /// </summary>
        /// <param name="emplIds">EmplIds</param>
        /// <returns></returns>
        public bool DelEmpTran(string emplIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgUsers ");
            strSql.Append(" set Status=0 ");
            strSql.Append(" where EmplId in (select * from dbo.SplitToTable('" + emplIds + "',','))");
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
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("update OrgEmployees ");
                    strSql2.Append(" set Status=0 ");
                    strSql2.Append(" where EmplId in (select * from dbo.SplitToTable('" + emplIds + "',','))");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.ExecuteNonQuery(dbCommand2, trans);
                    //StringBuilder strSql3 = new StringBuilder();
                    //strSql3.Append("update OrgCustomer ");
                    //strSql3.Append(" set Status=0 ");
                    //strSql3.Append(" where CId in (select CId from WorStaUserAcc where EmplId in (select * from dbo.SplitToTable('" + emplIds + "',',')))");
                    //DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
                    //db.ExecuteNonQuery(dbCommand3, trans);
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
        /// 新增人员及用户名事务方法
        /// </summary>
        /// <param name="orgId">组织机构编号</param>
        /// <param name="emplName">人员姓名</param>
        /// <param name="sex">性别</param>
        /// <param name="birthday">生日</param>
        /// <param name="homeAddress">家庭地址</param>
        /// <param name="phone">电话</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="type">添加哪种类型人员(1.我公司人员；2.物流公司人员；4.农技推广站人员)</param>
        /// <returns></returns>
        public int AddEmpUserType(string orgId, string emplName, string sex, string birthday, string homeAddress, string phone, string userName, string userPwd, int type)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgEmployees(");
            strSql.Append("OrgId,EmplName,Sex,Birthday,HomeAddress,Phone,Status,AddTime)");

            strSql.Append(" values (");
            strSql.Append("@OrgId,@EmplName,@Sex,@Birthday,@HomeAddress,@Phone,@Status,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.AnsiString, orgId);
            db.AddInParameter(dbCommand, "EmplName", DbType.String, emplName);
            db.AddInParameter(dbCommand, "Sex", DbType.String, sex);
            db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, birthday);
            db.AddInParameter(dbCommand, "HomeAddress", DbType.AnsiString, homeAddress);
            db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, phone);
            db.AddInParameter(dbCommand, "Status", DbType.Int32, 1);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, DateTime.Now);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    var empId = db.ExecuteScalar(dbCommand, trans);
                    StringBuilder strSql3 = new StringBuilder();

                    strSql3.Append("select count(1) from OrgUsers  a join OrgEmployees b on a.EmplId=b.EmplId  where a.UserName=@UserName and a.Status=1 and b.Status=1 ");

                    DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
                    db.AddInParameter(dbCommand3, "UserName", DbType.AnsiString, userName);
                    object obj3 = db.ExecuteScalar(dbCommand3, trans);
                    if (obj3.ToString() == "0")
                    {
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("insert into OrgUsers(");
                        strSql2.Append("EmplId,UserName,UserPwd,AddTime,Type,Status)");

                        strSql2.Append(" values (");
                        strSql2.Append("@EmplId,@UserName,@UserPwd,@AddTime,@Type,@Status)");
                        strSql2.Append(";select @@IDENTITY");
                        DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                        db.AddInParameter(dbCommand2, "EmplId", DbType.Int64, empId);
                        db.AddInParameter(dbCommand2, "UserName", DbType.String, userName);
                        db.AddInParameter(dbCommand2, "UserPwd", DbType.String, userPwd);
                        db.AddInParameter(dbCommand2, "AddTime", DbType.DateTime, DateTime.Now);
                        db.AddInParameter(dbCommand2, "Type", DbType.AnsiString, type);
                        db.AddInParameter(dbCommand2, "Status", DbType.Int32, 1);
                        object obj = db.ExecuteScalar(dbCommand2, trans);
                        if (!int.TryParse(obj.ToString(), out result))
                        {
                            trans.Rollback();
                            return 0;
                        }

                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append("insert into SYS_UserForRole(");
                        strSql1.Append("UId,Role_Id)");

                        strSql1.Append(" values (");
                        strSql1.Append("@Adn_Id,@Role_Id)");
                        strSql1.Append(";select @@IDENTITY");
                        DbCommand dbCommand1 = db.GetSqlStringCommand(strSql1.ToString());
                        db.AddInParameter(dbCommand1, "Adn_Id", DbType.Int32, obj);
                        db.AddInParameter(dbCommand1, "Role_Id", DbType.Int32, type);
                        object obj1 = db.ExecuteScalar(dbCommand1, trans);
                        if (!int.TryParse(obj1.ToString(), out result))
                        {
                            trans.Rollback();
                            return 0;
                        }
                        trans.Commit();
                    }
                    else
                    {
                        trans.Rollback();
                        return 0;
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
        /// 新增工作站人员,用户名及默认代付帐户事务方法
        /// </summary>
        /// <param name="orgId">组织机构编号</param>
        /// <param name="emplName">人员姓名</param>
        /// <param name="sex">性别</param>
        /// <param name="birthday">生日</param>
        /// <param name="homeAddress">家庭地址</param>
        /// <param name="phone">电话</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="uId">操作人</param>
        /// <returns></returns>
        public string AddEmpUser(string orgId, string emplName, string sex, string birthday, string homeAddress, string phone, string userName, string userPwd, int uId, string selfCard)
        {
            string result = "操作失败！";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgEmployees(");
            strSql.Append("OrgId,EmplName,Sex,Birthday,HomeAddress,Phone,Status,AddTime)");

            strSql.Append(" values (");
            strSql.Append("@OrgId,@EmplName,@Sex,@Birthday,@HomeAddress,@Phone,@Status,@AddTime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, orgId);
            db.AddInParameter(dbCommand, "EmplName", DbType.String, emplName);
            db.AddInParameter(dbCommand, "Sex", DbType.String, sex);
            db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, birthday);
            db.AddInParameter(dbCommand, "HomeAddress", DbType.AnsiString, homeAddress);
            db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, phone);
            db.AddInParameter(dbCommand, "Status", DbType.Int32, 1);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, DateTime.Now);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    StringBuilder strSql0 = new StringBuilder();
                    strSql0.Append("select count(1) from OrgUsers  a left join OrgEmployees b on a.EmplId=b.EmplId left join  OrgOrganize c on c.OrgId=b.OrgId  where a.UserName=@UserName and a.Status=1 and b.Status=1 and b.OrgId=@OrgId and c.OrgType=5");

                    DbCommand dbCommand0 = db.GetSqlStringCommand(strSql0.ToString());
                    db.AddInParameter(dbCommand0, "OrgId", DbType.Int64, orgId);
                    db.AddInParameter(dbCommand0, "UserName", DbType.AnsiString, userName);
                    object obj0 = db.ExecuteScalar(dbCommand0, trans);
                    if (obj0.ToString() == "0")
                    {
                        var empId = db.ExecuteScalar(dbCommand, trans);

                        #region 插入站长默认代付帐户

                        StringBuilder strSql4 = new StringBuilder();
                        strSql4.Append("insert into OrgCustomer(");
                        strSql4.Append(
                            "OrgId,Name,Sex,Birthday,HomeAddress,SelfCard,AddTime,Status,UId,UserName,Password,Mobile)");

                        strSql4.Append(" values (");
                        strSql4.Append(
                            "@OrgId,@Name,@Sex,@Birthday,@HomeAddress,@SelfCard,@AddTime,@Status,@UId,@UserName,@Password,@Mobile)");
                        strSql4.Append(";select @@IDENTITY");
                        DbCommand dbCommand4 = db.GetSqlStringCommand(strSql4.ToString());
                        db.AddInParameter(dbCommand4, "OrgId", DbType.Int64, orgId);
                        db.AddInParameter(dbCommand4, "Name", DbType.String, emplName);
                        db.AddInParameter(dbCommand4, "Sex", DbType.String, sex);
                        db.AddInParameter(dbCommand4, "Birthday", DbType.DateTime, birthday);
                        db.AddInParameter(dbCommand4, "HomeAddress", DbType.String, homeAddress);
                        db.AddInParameter(dbCommand4, "SelfCard", DbType.AnsiString, selfCard);
                        db.AddInParameter(dbCommand4, "AddTime", DbType.DateTime, DateTime.Now);
                        db.AddInParameter(dbCommand4, "Status", DbType.Byte, 2);
                        db.AddInParameter(dbCommand4, "UId", DbType.Int32, uId);
                        db.AddInParameter(dbCommand4, "UserName", DbType.AnsiString, userName);
                        db.AddInParameter(dbCommand4, "Password", DbType.AnsiString, userPwd);
                        db.AddInParameter(dbCommand4, "Mobile", DbType.AnsiString, phone);
                        object obj4 = db.ExecuteScalar(dbCommand4, trans);
                        var cId = 0;
                        if (!int.TryParse(obj4.ToString(), out cId))
                        {
                            trans.Rollback();
                        }

                        #endregion

                        #region 插入站长帐户信息关系表

                        StringBuilder strSql5 = new StringBuilder();
                        strSql5.Append("insert into WorStaUserAcc(");
                        strSql5.Append("EmplId,CId)");

                        strSql5.Append(" values (");
                        strSql5.Append("@EmplId,@CId)");
                        DbCommand dbCommand5 = db.GetSqlStringCommand(strSql5.ToString());
                        db.AddInParameter(dbCommand5, "EmplId", DbType.Int32, empId);
                        db.AddInParameter(dbCommand5, "CId", DbType.Int32, cId);
                        int obj5 = db.ExecuteNonQuery(dbCommand5, trans);
                        if (obj5 <= 0)
                        {
                            trans.Rollback();
                        }

                        #endregion


                        #region 插入站长登录帐户

                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("insert into OrgUsers(");
                        strSql2.Append("EmplId,UserName,UserPwd,AddTime,Type,Status)");

                        strSql2.Append(" values (");
                        strSql2.Append("@EmplId,@UserName,@UserPwd,@AddTime,@Type,@Status)");
                        strSql2.Append(";select @@IDENTITY");
                        DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                        db.AddInParameter(dbCommand2, "EmplId", DbType.Int64, empId);
                        db.AddInParameter(dbCommand2, "UserName", DbType.String, userName);
                        db.AddInParameter(dbCommand2, "UserPwd", DbType.String, userPwd);
                        db.AddInParameter(dbCommand2, "AddTime", DbType.DateTime, DateTime.Now);
                        db.AddInParameter(dbCommand2, "Type", DbType.AnsiString, "");
                        db.AddInParameter(dbCommand2, "Status", DbType.Int32, 1);
                        object obj = db.ExecuteScalar(dbCommand2, trans);
                        int res;
                        if (!int.TryParse(obj.ToString(), out res))
                        {
                            trans.Rollback();
                        }

                        #endregion

                        #region 添加送货地址
                        StringBuilder strSqlAdd = new StringBuilder();
                        strSqlAdd.Append("insert into OrgCustomerAddress(");
                        strSqlAdd.Append("CId,Province,City,County,Address,ReciveName,RecivePhone,IsDefault,AddTime,Status)");

                        strSqlAdd.Append(" values (");
                        strSqlAdd.Append("@CId,@Province,@City,@County,@Address,@ReciveName,@RecivePhone,@IsDefault,@AddTime,@Status)");
                        strSqlAdd.Append(";select @@IDENTITY");
                        DbCommand dbCommandAdd = db.GetSqlStringCommand(strSqlAdd.ToString());
                        db.AddInParameter(dbCommandAdd, "CId", DbType.Int32, cId);
                        db.AddInParameter(dbCommandAdd, "Province", DbType.AnsiString, null);
                        db.AddInParameter(dbCommandAdd, "City", DbType.AnsiString, null);
                        db.AddInParameter(dbCommandAdd, "County", DbType.AnsiString, null);
                        db.AddInParameter(dbCommandAdd, "Address", DbType.String, homeAddress);
                        db.AddInParameter(dbCommandAdd, "ReciveName", DbType.String, emplName);
                        db.AddInParameter(dbCommandAdd, "RecivePhone", DbType.AnsiString, phone);
                        db.AddInParameter(dbCommandAdd, "IsDefault", DbType.Byte, 1);
                        db.AddInParameter(dbCommandAdd, "AddTime", DbType.DateTime, DateTime.Now);
                        db.AddInParameter(dbCommandAdd, "Status", DbType.Byte, 1);
                        object objAdd = db.ExecuteScalar(dbCommandAdd, trans);
                        int resAdd;
                        if (!int.TryParse(obj.ToString(), out resAdd))
                        {
                            trans.Rollback();
                        }
                        #endregion
                        trans.Commit();
                        result = "1";
                    }
                    else
                    {
                        trans.Rollback();
                        return "该工作站下已存在站长！";
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
        /// 更新人员及用户名事务方法
        /// </summary>
        /// <param name="orgId">组织机构编号</param>
        /// <param name="emplId">人员编号</param>
        /// <param name="emplName">人员姓名</param>
        /// <param name="sex">性别</param>
        /// <param name="birthday">生日</param>
        /// <param name="homeAddress">家庭地址</param>
        /// <param name="phone">电话</param>
        /// <param name="userName">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <param name="type">添加哪种类型人员(1.我公司人员；2.物流公司人员；4.农技推广站人员;5.工作站人员)</param>
        /// <returns></returns>
        public string UpdateEmpUser(string orgId, string emplId, string emplName, string sex, string birthday, string homeAddress, string phone, string userName, string userPwd, int type, string selfCard)
        {
            string result = "更新失败";
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql3 = new StringBuilder();

            strSql3.Append("select count(1) from OrgUsers a  join OrgEmployees b on a.EmplId=b.EmplId where a.Status=1 and b.Status=1 and UserName=@UserName  and  a.EmplId!=@EmplId");

            DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
            db.AddInParameter(dbCommand3, "UserName", DbType.AnsiString, userName);
            db.AddInParameter(dbCommand3, "EmplId", DbType.AnsiString, emplId);
            db.AddInParameter(dbCommand3, "OrgId", DbType.AnsiString, orgId);
            object obj3 = db.ExecuteScalar(dbCommand3);
            if (obj3.ToString() == "0")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update OrgEmployees set ");
                strSql.Append("OrgId=@OrgId,");
                strSql.Append("EmplName=@EmplName,");
                strSql.Append("Sex=@Sex,");
                strSql.Append("Birthday=@Birthday,");
                strSql.Append("HomeAddress=@HomeAddress,");
                strSql.Append("Phone=@Phone");
                strSql.Append(" where EmplId=@EmplId ");

                DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                db.AddInParameter(dbCommand, "EmplId", DbType.Int32, emplId);
                db.AddInParameter(dbCommand, "OrgId", DbType.Int64, orgId);
                db.AddInParameter(dbCommand, "EmplName", DbType.String, emplName);
                db.AddInParameter(dbCommand, "Sex", DbType.AnsiString, sex);
                db.AddInParameter(dbCommand, "Birthday", DbType.DateTime, birthday);
                db.AddInParameter(dbCommand, "HomeAddress", DbType.String, homeAddress);
                db.AddInParameter(dbCommand, "Phone", DbType.AnsiString, phone);

                using (DbConnection conn = db.CreateConnection())
                {
                    conn.Open();
                    DbTransaction trans = conn.BeginTransaction();
                    try
                    {
                        int rows = db.ExecuteNonQuery(dbCommand, trans);
                        StringBuilder strSql2 = new StringBuilder();
                        strSql2.Append("update OrgUsers set ");
                        strSql2.Append("UserName=@UserName,Type=@Type");
                        if (!string.IsNullOrEmpty(userPwd))
                        {
                            strSql2.Append(",UserPwd=@UserPwd ");
                        }
                        strSql2.Append(" where EmplId=@EmplId ");
                        DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                        db.AddInParameter(dbCommand2, "EmplId", DbType.Int32, emplId);
                        db.AddInParameter(dbCommand2, "UserName", DbType.AnsiString, userName);
                        db.AddInParameter(dbCommand2, "Type", DbType.Int32, type);
                        if (!string.IsNullOrEmpty(userPwd))
                        {
                            db.AddInParameter(dbCommand2, "UserPwd", DbType.AnsiString, userPwd);
                        }
                        db.ExecuteNonQuery(dbCommand2, trans);

                        StringBuilder strSql9 = new StringBuilder();
                        strSql9.Append("select UId from  OrgUsers ");
                        strSql9.Append(" where EmplId=@EmplId ");
                        DbCommand dbCommand9 = db.GetSqlStringCommand(strSql9.ToString());
                        db.AddInParameter(dbCommand9, "EmplId", DbType.Int32, emplId);
                        var uid = db.ExecuteScalar(dbCommand9, trans);

                        StringBuilder strSql0 = new StringBuilder();
                        strSql0.Append("update SYS_UserForRole set ");
                        strSql0.Append("Role_Id=@Role_Id");
                        strSql0.Append(" where UId=@UId ");
                        DbCommand dbCommand4 = db.GetSqlStringCommand(strSql0.ToString());
                        db.AddInParameter(dbCommand4, "UId", DbType.Int32, uid);
                        db.AddInParameter(dbCommand4, "Role_Id", DbType.Int32, type);
                        db.ExecuteNonQuery(dbCommand4, trans);

                        result = "1";
                        trans.Commit();
                    }
                    catch (Exception ee)
                    {
                        result = ee.Message;
                        trans.Rollback();
                    }
                    conn.Close();

                    return result;
                }
            }
            else
            {
                result = "用户名已经存在";
            }
            return result;
        }

        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListEmp(string sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM dbo.OrgEmployees  where EmplId IN (SELECT EmplId FROM dbo.OrgUsers ");
            strSql.Append(" where UID IN (select UID from dbo.SYS_UserForRole where Role_Id ");
            strSql.Append(" in (select Role_Id from dbo.SYS_RoleInfo where Role_Name='库管员' or Role_Name='物流经理' ))) and Status!=0 ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}

