/**  版本信息模板在安装目录下，可自行修改。
* SYS_UserForRole.cs
*
* 功 能： N/A
* 类 名： SYS_UserForRole
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
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Admin.DAL
{
    /// <summary>
    /// 数据访问类:SYS_UserForRole
    /// </summary>
    public partial class SYS_UserForRole
    {
        public SYS_UserForRole()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(UFR_Id)+1 from SYS_UserForRole";
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
        public bool Exists(int UFR_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_UserForRole where UFR_Id=@UFR_Id ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UFR_Id", DbType.Int32, UFR_Id);
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
        public int Add(Model.SYS_UserForRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_UserForRole(");
            strSql.Append("UId,Role_Id)");

            strSql.Append(" values (");
            strSql.Append("@Adn_Id,@Role_Id)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, model.Adn_Id);
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, model.Role_Id);
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
        public bool Update(Model.SYS_UserForRole model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_UserForRole set ");
            strSql.Append("Adn_Id=@Adn_Id,");
            strSql.Append("Role_Id=@Role_Id");
            strSql.Append(" where UFR_Id=@UFR_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UFR_Id", DbType.Int32, model.UFR_Id);
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, model.Adn_Id);
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, model.Role_Id);
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
        public bool Delete(int UFR_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_UserForRole ");
            strSql.Append(" where UFR_Id=@UFR_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UFR_Id", DbType.Int32, UFR_Id);
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
        public bool DeleteList(string UFR_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_UserForRole ");
            strSql.Append(" where UFR_Id in (" + UFR_Idlist + ")  ");
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
        public Model.SYS_UserForRole GetModel(int UFR_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UFR_Id,Adn_Id,Role_Id from SYS_UserForRole ");
            strSql.Append(" where UFR_Id=@UFR_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UFR_Id", DbType.Int32, UFR_Id);
            Model.SYS_UserForRole model = null;
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
        public Model.SYS_UserForRole GetModel(int Adn_Id, int Role_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UFR_Id,Adn_Id,Role_Id from SYS_UserForRole ");
            strSql.Append(" where Adn_Id=@Adn_Id and Role_Id=@Role_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, Adn_Id);
            db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, Role_Id);
            Model.SYS_UserForRole model = null;
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
        public Model.SYS_UserForRole DataRowToModel(DataRow row)
        {
            Model.SYS_UserForRole model = new Model.SYS_UserForRole();
            if (row != null)
            {
                if (row["UFR_Id"] != null && row["UFR_Id"].ToString() != "")
                {
                    model.UFR_Id = int.Parse(row["UFR_Id"].ToString());
                }
                if (row["Adn_Id"] != null && row["Adn_Id"].ToString() != "")
                {
                    model.Adn_Id = int.Parse(row["Adn_Id"].ToString());
                }
                if (row["Role_Id"] != null && row["Role_Id"].ToString() != "")
                {
                    model.Role_Id = int.Parse(row["Role_Id"].ToString());
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
            strSql.Append("select UFR_Id,UId,Role_Id ");
            strSql.Append(" FROM SYS_UserForRole ");
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
            strSql.Append(" UFR_Id,Adn_Id,Role_Id ");
            strSql.Append(" FROM SYS_UserForRole ");
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
        //    strSql.Append("select count(1) FROM SYS_UserForRole ");
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
                strSql.Append("order by T.UFR_Id desc");
            }
            strSql.Append(")AS Row, T.*  from SYS_UserForRole T ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "SYS_UserForRole");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "UFR_Id");
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
        public List<Model.SYS_UserForRole> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UFR_Id,Adn_Id,Role_Id ");
            strSql.Append(" FROM SYS_UserForRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.SYS_UserForRole> list = new List<Model.SYS_UserForRole>();
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
        public Model.SYS_UserForRole ReaderBind(IDataReader dataReader)
        {
            Model.SYS_UserForRole model = new Model.SYS_UserForRole();
            object ojb;
            ojb = dataReader["UFR_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UFR_Id = (int)ojb;
            }
            ojb = dataReader["Adn_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Adn_Id = (int)ojb;
            }
            ojb = dataReader["Role_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Role_Id = (int)ojb;
            }
            return model;
        }

        #endregion  Method
    }
}

