/**  版本信息模板在安装目录下，可自行修改。
* SYS_UserForConsultant.cs
*
* 功 能： N/A
* 类 名： SYS_UserForConsultant
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-08-08 18:27:10    N/A    初版
*
* 




*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Admin.DAL
{
    /// <summary>
    /// 数据访问类:SYS_UserForConsultant
    /// </summary>
    public partial class SYS_UserForConsultant
    {
        public SYS_UserForConsultant()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(CON_Id)+1 from SYS_UserForConsultant";
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
        public bool Exists(int CON_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_UserForConsultant where CON_Id=@CON_Id ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "CON_Id", DbType.Int32, CON_Id);
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
        public int Add(Model.SYS_UserForConsultant model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_UserForConsultant(");
            strSql.Append("Adn_Id,Adn_ConId)");

            strSql.Append(" values (");
            strSql.Append("@Adn_Id,@Adn_ConId)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, model.Adn_Id);
            db.AddInParameter(dbCommand, "Adn_ConId", DbType.Int32, model.Adn_ConId);
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
        public bool Update(Model.SYS_UserForConsultant model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_UserForConsultant set ");
            strSql.Append("Adn_Id=@Adn_Id,");
            strSql.Append("Adn_ConId=@Adn_ConId");
            strSql.Append(" where CON_Id=@CON_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "UFR_Id", DbType.Int32, model.Con_Id);
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, model.Adn_Id);
            db.AddInParameter(dbCommand, "Adn_ConId", DbType.Int32, model.Adn_ConId);
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
        public bool Delete(int Con_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_UserForConsultant ");
            strSql.Append(" where Con_Id=@Con_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Con_Id", DbType.Int32, Con_Id);
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
        public bool DeleteList(string Con_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_UserForConsultant ");
            strSql.Append(" where Con_Id in (" + Con_Idlist + ")  ");
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
        public Model.SYS_UserForConsultant GetModel(int Con_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Con_Id,Adn_Id,Adn_ConId from SYS_UserForConsultant ");
            strSql.Append(" where Con_Id=@Con_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Con_Id", DbType.Int32, Con_Id);
            Model.SYS_UserForConsultant model = null;
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
        public Model.SYS_UserForConsultant GetModel(int Adn_Id, int Adn_ConId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Con_Id,Adn_Id,Adn_ConId from SYS_UserForConsultant ");
            strSql.Append(" where Adn_Id=@Adn_Id and  Adn_ConId=@Adn_ConId");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, Adn_Id);
            db.AddInParameter(dbCommand, "Adn_ConId", DbType.Int32, Adn_ConId);
            Model.SYS_UserForConsultant model = null;
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
        public Model.SYS_UserForConsultant DataRowToModel(DataRow row)
        {
            Model.SYS_UserForConsultant model = new Model.SYS_UserForConsultant();
            if (row != null)
            {
                if (row["Con_Id"] != null && row["Con_Id"].ToString() != "")
                {
                    model.Con_Id = int.Parse(row["Con_Id"].ToString());
                }
                if (row["Adn_Id"] != null && row["Adn_Id"].ToString() != "")
                {
                    model.Adn_Id = int.Parse(row["Adn_Id"].ToString());
                }
                if (row["Adn_ConId"] != null && row["Adn_ConId"].ToString() != "")
                {
                    model.Adn_ConId = int.Parse(row["Adn_ConId"].ToString());
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
            strSql.Append("select Con_Id,Adn_Id,Adn_ConId ");
            strSql.Append(" FROM SYS_UserForConsultant ");
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
            strSql.Append(" Con_Id,Adn_Id,Adn_ConId ");
            strSql.Append(" FROM SYS_UserForConsultant ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

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
                strSql.Append("order by T.Con_Id desc");
            }
            strSql.Append(")AS Row, T.*  from SYS_UserForConsultant T ");
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

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Model.SYS_UserForConsultant> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UFR_Id,Adn_Id,Role_Id ");
            strSql.Append(" FROM SYS_UserForRole ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.SYS_UserForConsultant> list = new List<Model.SYS_UserForConsultant>();
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
        public Model.SYS_UserForConsultant ReaderBind(IDataReader dataReader)
        {
            Model.SYS_UserForConsultant model = new Model.SYS_UserForConsultant();
            object ojb;
            ojb = dataReader["Con_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Con_Id = (int)ojb;
            }
            ojb = dataReader["Adn_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Adn_Id = (int)ojb;
            }
            ojb = dataReader["Adn_ConId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Adn_ConId = (int)ojb;
            }
            return model;
        }

        #endregion  Method
    }
}

