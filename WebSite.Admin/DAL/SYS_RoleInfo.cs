/**  版本信息模板在安装目录下，可自行修改。
* SYS_RoleInfo.cs
*
* 功 能： N/A
* 类 名： SYS_RoleInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-07-24 16:01:03   N/A    初版
*
* 




*/

//using Maticsoft.DBUtility;//Please add references

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
    /// 数据访问类:SYS_RoleInfo
    /// </summary>
    public partial class SYS_RoleInfo
    {
        public SYS_RoleInfo()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(Role_Id)+1 from SYS_RoleInfo";
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
        public bool Exists(int Role_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_RoleInfo where Role_Id=@Role_Id ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, Role_Id);
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
        public int Add(Model.SYS_RoleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_RoleInfo(");
            strSql.Append("Role_Name,Role_Memo,Role_Status,Role_IsSuper,Role_SecurityID)");

            strSql.Append(" values (");
            strSql.Append("@Role_Name,@Role_Memo,@Role_Status,@Role_IsSuper,@Role_SecurityID)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Role_Name", DbType.String, model.Role_Name);
            db.AddInParameter(dbCommand, "Role_Memo", DbType.String, model.Role_Memo);
            db.AddInParameter(dbCommand, "Role_Status", DbType.Int32, model.Role_Status);
            db.AddInParameter(dbCommand, "Role_IsSuper", DbType.Int32, model.Role_IsSuper);
            db.AddInParameter(dbCommand, "Role_SecurityID", DbType.AnsiString, model.Role_SecurityID);
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
        public bool Update(Model.SYS_RoleInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_RoleInfo set ");
            strSql.Append("Role_Name=@Role_Name,");
            strSql.Append("Role_Memo=@Role_Memo,");
            strSql.Append("Role_Status=@Role_Status,");
            strSql.Append("Role_IsSuper=@Role_IsSuper,");
            strSql.Append("Role_SecurityID=@Role_SecurityID");
            strSql.Append(" where Role_Id=@Role_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, model.Role_Id);
            db.AddInParameter(dbCommand, "Role_Name", DbType.String, model.Role_Name);
            db.AddInParameter(dbCommand, "Role_Memo", DbType.String, model.Role_Memo);
            db.AddInParameter(dbCommand, "Role_Status", DbType.Int32, model.Role_Status);
            db.AddInParameter(dbCommand, "Role_IsSuper", DbType.Int32, model.Role_IsSuper);
            db.AddInParameter(dbCommand, "Role_SecurityID", DbType.AnsiString, model.Role_SecurityID);
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
        public bool Delete(int Role_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_RoleInfo ");
            strSql.Append(" where Role_Id=@Role_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, Role_Id);
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
        public bool DeleteList(string Role_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_RoleInfo ");
            strSql.Append(" where Role_Id in (" + Role_Idlist + ")  ");
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
        public Model.SYS_RoleInfo GetModel(int Role_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Role_Id,Role_Name,Role_Memo,Role_Status,Role_IsSuper,Role_SecurityID from SYS_RoleInfo ");
            strSql.Append(" where Role_Id=@Role_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, Role_Id);
            Model.SYS_RoleInfo model = null;
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
        public Model.SYS_RoleInfo DataRowToModel(DataRow row)
        {
            Model.SYS_RoleInfo model = new Model.SYS_RoleInfo();
            if (row != null)
            {
                if (row["Role_Id"] != null && row["Role_Id"].ToString() != "")
                {
                    model.Role_Id = int.Parse(row["Role_Id"].ToString());
                }
                if (row["Role_Name"] != null)
                {
                    model.Role_Name = row["Role_Name"].ToString();
                }
                if (row["Role_Memo"] != null)
                {
                    model.Role_Memo = row["Role_Memo"].ToString();
                }
                if (row["Role_Status"] != null && row["Role_Status"].ToString() != "")
                {
                    model.Role_Status = int.Parse(row["Role_Status"].ToString());
                }
                if (row["Role_IsSuper"] != null && row["Role_IsSuper"].ToString() != "")
                {
                    model.Role_IsSuper = int.Parse(row["Role_IsSuper"].ToString());
                }
                if (row["Role_SecurityID"] != null)
                {
                    model.Role_SecurityID = row["Role_SecurityID"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Role_Id,Role_Name,Role_Memo, case Role_Status when 1 then '已审核' when 0 then '未审核' end  as Role_Status, case Role_IsSuper when 1 then '是' when 0 then '否' end  as Role_IsSuper ,Role_SecurityID ");
            strSql.Append(" FROM SYS_RoleInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Role_Id,Role_Name,Role_Memo,Role_Status,Role_IsSuper,Role_SecurityID ");
            strSql.Append(" FROM SYS_RoleInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) FROM SYS_RoleInfo ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Role_Id desc");
            }
            strSql.Append(")AS Row, T.*  from SYS_RoleInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            return db.ExecuteDataSet(dbCommand);
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "SYS_RoleInfo");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "Role_Id");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }*/

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Model.SYS_RoleInfo> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Role_Id,Role_Name,Role_Memo,Role_Status,Role_IsSuper,Role_SecurityID ");
            strSql.Append(" FROM SYS_RoleInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.SYS_RoleInfo> list = new List<Model.SYS_RoleInfo>();
            Database db = DatabaseFactory.CreateDatabase();
            using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
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
        public Model.SYS_RoleInfo ReaderBind(IDataReader dataReader)
        {
            Model.SYS_RoleInfo model = new Model.SYS_RoleInfo();
            object ojb;
            ojb = dataReader["Role_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Role_Id = (int)ojb;
            }
            model.Role_Name = dataReader["Role_Name"].ToString();
            model.Role_Memo = dataReader["Role_Memo"].ToString();
            ojb = dataReader["Role_Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Role_Status = (int)ojb;
            }
            ojb = dataReader["Role_IsSuper"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Role_IsSuper = (int)ojb;
            }
            model.Role_SecurityID = dataReader["Role_SecurityID"].ToString();
            return model;
        }

        #endregion  Method

        #region
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public string GetListRoleInfo(string roleName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select row_number() over(order by Role_Id DESC) as rownum,Role_Id,Role_Name,Role_Memo, case Role_Status when 1 then '已审核' when 0 then '未审核' end  as Role_Status, case Role_IsSuper when 1 then '是' when 0 then '否' end  as Role_IsSuper ,Role_SecurityID ");
            strSql.Append(" FROM SYS_RoleInfo ");
            strSql.Append(" where Role_Name like '%" + roleName.Trim() + "%'");

            return strSql.ToString();
        }

        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListAdmin(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UID from dbo.SYS_UserForRole");
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
        #endregion
    }
}

