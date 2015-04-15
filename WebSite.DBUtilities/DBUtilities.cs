using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.DBUtilities
{
    public class DBUtilities
    {
        static private Database m_db = DatabaseFactory.CreateDatabase();
        static private object m_db_lock = new object();
        static public Database DB
        {
            get
            {
                if (m_db == null)
                    m_db = DatabaseFactory.CreateDatabase();
                return m_db;
            }
        }

        public DBUtilities()
        {
            //m_db = DatabaseFactory.CreateDatabase();
        }

        static public DataView GetDataViewBySql(string sqlstr)
        {
            string sqlCommand = sqlstr;
            DbCommand dbCommand = DB.GetSqlStringCommand(sqlCommand);
            return DB.ExecuteDataSet(dbCommand).Tables[0].DefaultView;

        }

        static public DataSet Query(string sqlstr, params object[] parameterValues)
        {
            string sqlCommand = sqlstr;
            DbCommand dbCommand = DB.GetSqlStringCommand(sqlCommand);
            foreach (SqlParameter parm in parameterValues)
                dbCommand.Parameters.Add(parm);
            return DB.ExecuteDataSet(dbCommand);

        }

        static public int ExecuteNonQuery(string sqlstr)
        {
            string sqlCommand = sqlstr;
            //    DbCommand dbCommand = DB.GetSqlStringCommand(sqlCommand);
            return DB.ExecuteNonQuery(CommandType.Text, sqlstr);
        }
        static public int ExecuteNonQuery(string sqlstr, params object[] parameterValues)
        {
            string sqlCommand = sqlstr;
            DbCommand dbCommand = DB.GetSqlStringCommand(sqlCommand);
            foreach (SqlParameter parm in parameterValues)
                dbCommand.Parameters.Add(parm);
            return DB.ExecuteNonQuery(dbCommand);
        }

        public DataView GetDataViewByCommand(SqlCommand cmd)
        {
            return DB.ExecuteDataSet(cmd).Tables[0].DefaultView;
        }

        public bool Exists(string sqlstr, params object[] parameterValues)
        {
            string sqlCommand = sqlstr;
            DbCommand dbCommand = DB.GetSqlStringCommand(sqlCommand);
            foreach (SqlParameter parm in parameterValues)
                dbCommand.Parameters.Add(parm);
            object ob = DB.ExecuteScalar(dbCommand);
            if (ob != null)
                return (ob.ToString() != "0");
            else return false;

        }

        public object GetObjBySql(string sqlstr)
        {
            SqlCommand sqlCommand = new SqlCommand(sqlstr);
            return GetObjByCommand(sqlCommand);
        }

        public object GetObjByCommand(SqlCommand cmd)
        {
            return DB.ExecuteScalar(cmd);
        }
    }
}