/**  版本信息模板在安装目录下，可自行修改。
* OrgUsers.cs
*
* 功 能： N/A
* 类 名： OrgUsers
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
    /// 数据访问类:OrgUsers
    /// </summary>
    public partial class OrgUsers
    {
        public OrgUsers()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(UId)+1 from OrgUsers";
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
        public bool Exists(int UId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrgUsers where UId=@UId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UId", DbType.Int32, UId);
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
        public int Add(Model.OrgUsers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgUsers(");
            strSql.Append("EmplId,UserName,UserPwd,AddTime,Type,Status,LastLoginTime)");

            strSql.Append(" values (");
            strSql.Append("@EmplId,@UserName,@UserPwd,@AddTime,@Type,@Status,@LastLoginTime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
            db.AddInParameter(dbCommand, "UserPwd", DbType.AnsiString, model.UserPwd);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
            db.AddInParameter(dbCommand, "Type", DbType.Byte, model.Type);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "LastLoginTime", DbType.DateTime, model.LastLoginTime);
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
        public bool Update(Model.OrgUsers model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgUsers set ");
            strSql.Append("EmplId=@EmplId,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("UserPwd=@UserPwd,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Type=@Type,");
            strSql.Append("Status=@Status,");
            strSql.Append("LastLoginTime=@LastLoginTime");
            strSql.Append(" where UId=@UId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UId", DbType.Int32, model.UId);
            db.AddInParameter(dbCommand, "EmplId", DbType.Int32, model.EmplId);
            db.AddInParameter(dbCommand, "UserName", DbType.AnsiString, model.UserName);
            db.AddInParameter(dbCommand, "UserPwd", DbType.AnsiString, model.UserPwd);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
            db.AddInParameter(dbCommand, "Type", DbType.Byte, model.Type);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "LastLoginTime", DbType.DateTime, model.LastLoginTime);
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
        public bool Delete(int UId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgUsers ");
            strSql.Append(" where UId=@UId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UId", DbType.Int32, UId);
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
        public bool DeleteList(string UIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgUsers ");
            strSql.Append(" where UId in (" + UIdlist + ")  ");
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
        public Model.OrgUsers GetModel(int UId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,EmplId,UserName,UserPwd,AddTime,Type,Status,LastLoginTime from OrgUsers ");
            strSql.Append(" where UId=@UId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UId", DbType.Int32, UId);
            Model.OrgUsers model = null;
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
        public Model.OrgUsers DataRowToModel(DataRow row)
        {
            Model.OrgUsers model = new Model.OrgUsers();
            if (row != null)
            {
                if (row["UId"] != null && row["UId"].ToString() != "")
                {
                    model.UId = Convert.ToInt32(row["UId"].ToString());
                }
                if (row["EmplId"] != null && row["EmplId"].ToString() != "")
                {
                    model.EmplId = Convert.ToInt32(row["EmplId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserPwd"] != null)
                {
                    model.UserPwd = row["UserPwd"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = Convert.ToDateTime(row["AddTime"].ToString());
                }
                if (row["Type"] != null && row["Type"].ToString() != "")
                {
                    model.Type = Convert.ToInt32(row["Type"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(row["Status"].ToString());
                }
                if (row["LastLoginTime"] != null && row["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = Convert.ToDateTime(row["LastLoginTime"].ToString());
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
            strSql.Append("select UId,EmplId,UserName,UserPwd,AddTime,Type,Status,LastLoginTime ");
            strSql.Append(" FROM OrgUsers ");
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
            strSql.Append(" UId,EmplId,UserName,UserPwd,AddTime,Type,Status,LastLoginTime ");
            strSql.Append(" FROM OrgUsers ");
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
            strSql.Append("select count(1) FROM OrgUsers ");
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
                strSql.Append("order by T.UId desc");
            }
            strSql.Append(")AS Row, T.*  from OrgUsers T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgUsers");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "UId");
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
        public List<Model.OrgUsers> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,EmplId,UserName,UserPwd,AddTime,Type,Status,LastLoginTime ");
            strSql.Append(" FROM OrgUsers ");
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
            List<Model.OrgUsers> list = new List<Model.OrgUsers>();
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
        public Model.OrgUsers ReaderBind(IDataReader dataReader)
        {
            Model.OrgUsers model = new Model.OrgUsers();
            object ojb;
            ojb = dataReader["UId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UId = Convert.ToInt32(ojb);
            }
            ojb = dataReader["EmplId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EmplId = Convert.ToInt32(ojb);
            }
            model.UserName = dataReader["UserName"].ToString();
            model.UserPwd = dataReader["UserPwd"].ToString();
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = Convert.ToDateTime(ojb);
            }
            ojb = dataReader["Type"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Type = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = Convert.ToInt32(ojb);
            }
            ojb = dataReader["LastLoginTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.LastLoginTime = Convert.ToDateTime(ojb);
            }
            return model;
        }

        #endregion  Method

        #region
        /// <summary>
        /// 判断该功能页面是否对当前用户赋权
        /// </summary>
        /// <param name="pc_name"></param>
        /// <param name="adn_Id"></param>
        /// <returns></returns>
        public bool ExistsUsersPage(string pc_name, int adn_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from (select pc_id from dbo.SYS_RoleForPage where role_id in( ");
            strSql.Append("select role_Id from dbo.SYS_UserForRole where UId=@adn_Id)) a ");
            strSql.Append("where a.pc_id=(select pc_id from dbo.SYS_PageConfig where pc_name=@pc_name)");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "pc_name", DbType.String, pc_name);
            db.AddInParameter(dbCommand, "adn_Id", DbType.Int32, adn_Id);
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
        public Model.OrgUsers GetModelByEmplId(int emplId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,EmplId,UserName,UserPwd,AddTime,Type,Status,LastLoginTime from OrgUsers ");
            strSql.Append(" where EmplId=@emplId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "emplId", DbType.Int32, emplId);
            Model.OrgUsers model = null;
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
        public Model.OrgUsers GetModelByUserName(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UId,EmplId,UserName,UserPwd,AddTime,Type,Status,LastLoginTime from OrgUsers ");
            strSql.Append(" where Status=1 and UID=((SELECT UID FROM OrgUsers where EmplId =( SELECT EmplId FROM OrgEmployees WHERE OrgId!=1 and  EmplId IN ( SELECT EmplId FROM OrgUsers WHERE UserName = @userName))))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "userName", DbType.String, userName);
            Model.OrgUsers model = null;
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

