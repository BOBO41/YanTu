/**  版本信息模板在安装目录下，可自行修改。
* SYS_RoleForPage.cs
*
* 功 能： N/A
* 类 名： SYS_RoleForPage
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-07-24 16:01:02   N/A    初版
*
* 




*/

//using Maticsoft.DBUtility;//Please add references

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Admin.DAL
{
    /// <summary>
    /// 数据访问类:SYS_RoleForPage
    /// </summary>
    public partial class SYS_RoleForPage
    {
        public SYS_RoleForPage()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(RFP_Id)+1 from SYS_RoleForPage";
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
        public bool Exists(int RFP_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_RoleForPage where RFP_Id=@RFP_Id ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RFP_Id", DbType.Int32, RFP_Id);
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
        public int Add(Model.SYS_RoleForPage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_RoleForPage(");
            strSql.Append("Role_Id,PC_Id)");

            strSql.Append(" values (");
            strSql.Append("@Role_Id,@PC_Id)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, model.Role_Id);
            db.AddInParameter(dbCommand, "PC_Id", DbType.Int32, model.PC_Id);
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
        public bool Update(Model.SYS_RoleForPage model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_RoleForPage set ");
            strSql.Append("Role_Id=@Role_Id,");
            strSql.Append("PC_Id=@PC_Id");
            strSql.Append(" where RFP_Id=@RFP_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RFP_Id", DbType.Int32, model.RFP_Id);
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, model.Role_Id);
            db.AddInParameter(dbCommand, "PC_Id", DbType.Int32, model.PC_Id);
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
        public bool Delete(int RFP_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_RoleForPage ");
            strSql.Append(" where RFP_Id=@RFP_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RFP_Id", DbType.Int32, RFP_Id);
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
        public bool DeleteList(string RFP_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_RoleForPage ");
            strSql.Append(" where RFP_Id in (" + RFP_Idlist + ")  ");
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
        public Model.SYS_RoleForPage GetModel(int RFP_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RFP_Id,Role_Id,PC_Id from SYS_RoleForPage ");
            strSql.Append(" where RFP_Id=@RFP_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "RFP_Id", DbType.Int32, RFP_Id);
            Model.SYS_RoleForPage model = null;
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
        public Model.SYS_RoleForPage GetModel(int Role_Id, int PC_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RFP_Id,Role_Id,PC_Id from SYS_RoleForPage ");
            strSql.Append(" where Role_Id=@Role_Id and  PC_Id=@PC_Id");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, Role_Id);
            db.AddInParameter(dbCommand, "PC_Id", DbType.Int32, PC_Id);
            Model.SYS_RoleForPage model = null;
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
        public Model.SYS_RoleForPage DataRowToModel(DataRow row)
        {
            Model.SYS_RoleForPage model = new Model.SYS_RoleForPage();
            if (row != null)
            {
                if (row["RFP_Id"] != null && row["RFP_Id"].ToString() != "")
                {
                    model.RFP_Id = int.Parse(row["RFP_Id"].ToString());
                }
                if (row["Role_Id"] != null && row["Role_Id"].ToString() != "")
                {
                    model.Role_Id = int.Parse(row["Role_Id"].ToString());
                }
                if (row["PC_Id"] != null && row["PC_Id"].ToString() != "")
                {
                    model.PC_Id = int.Parse(row["PC_Id"].ToString());
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
            strSql.Append("select RFP_Id,Role_Id,PC_Id ");
            strSql.Append(" FROM SYS_RoleForPage ");
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
            strSql.Append(" RFP_Id,Role_Id,PC_Id ");
            strSql.Append(" FROM SYS_RoleForPage ");
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
        //    strSql.Append("select count(1) FROM SYS_RoleForPage ");
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
                strSql.Append("order by T.RFP_Id desc");
            }
            strSql.Append(")AS Row, T.*  from SYS_RoleForPage T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "SYS_RoleForPage");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "RFP_Id");
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
        public List<Model.SYS_RoleForPage> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RFP_Id,Role_Id,PC_Id ");
            strSql.Append(" FROM SYS_RoleForPage ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.SYS_RoleForPage> list = new List<Model.SYS_RoleForPage>();
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
        public Model.SYS_RoleForPage ReaderBind(IDataReader dataReader)
        {
            Model.SYS_RoleForPage model = new Model.SYS_RoleForPage();
            object ojb;
            ojb = dataReader["RFP_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.RFP_Id = (int)ojb;
            }
            ojb = dataReader["Role_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Role_Id = (int)ojb;
            }
            ojb = dataReader["PC_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.PC_Id = (int)ojb;
            }
            return model;
        }

        #endregion  Method
    }
}

