using System;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.DBUtilities
{
    public class SqlServer
    {
        static public void KillAllConnection(string databasename)
        {
            Database db = DatabaseFactory.CreateDatabase("master");
            DbCommand dbCommand;
            int spid = 0;

            StringBuilder SqlCmd = new StringBuilder();

            SqlCmd.Append("USE master; ");
            SqlCmd.Append("select @@spid as spid; ");

            dbCommand = db.GetSqlStringCommand(SqlCmd.ToString());

            SqlCmd = new StringBuilder();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    spid = int.Parse(dataReader["spid"].ToString());
                }
            }

            SqlCmd.Append("USE master; ");
            SqlCmd.Append("EXEC sp_who; ");

            dbCommand = db.GetSqlStringCommand(SqlCmd.ToString());

            SqlCmd = new StringBuilder();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    if ((dataReader["dbname"].ToString().CompareTo(databasename) == 0)
                        && (spid.ToString() != dataReader["spid"].ToString()))
                    {
                        SqlCmd.Append("kill " + dataReader["spid"] + "; ");
                    };
                }
            }

            if (!SqlCmd.ToString().Trim().Equals(""))
            {
                dbCommand = db.GetSqlStringCommand(SqlCmd.ToString());
                db.ExecuteNonQuery(dbCommand);
            }
            db = null;
        }

        static public DataSet PR_Pager(string Tables, string PrimaryKey, string Sort, int CurrentPage, int PageSize, string Fields, string Filter, string Group, out string RecordCount)
        {
            DbCommand command = DatabaseUtiles.DB.GetStoredProcCommand("PR_Page");

            DatabaseUtiles.DB.AddInParameter(command, "@Tables", DbType.String, Tables);
            DatabaseUtiles.DB.AddInParameter(command, "@PrimaryKey", DbType.String, PrimaryKey);
            DatabaseUtiles.DB.AddInParameter(command, "@Sort", DbType.String, Sort);
            DatabaseUtiles.DB.AddInParameter(command, "@CurrentPage", DbType.Int32, CurrentPage);
            DatabaseUtiles.DB.AddInParameter(command, "@PageSize", DbType.Int32, PageSize);
            DatabaseUtiles.DB.AddInParameter(command, "@Fields", DbType.String, Fields);
            DatabaseUtiles.DB.AddInParameter(command, "@Filter", DbType.String, Filter);
            DatabaseUtiles.DB.AddInParameter(command, "@Group", DbType.String, Group);
            DatabaseUtiles.DB.AddOutParameter(command, "@RecordCount", DbType.String, 20);

            RecordCount = DatabaseUtiles.DB.GetParameterValue(command, "@RecordCount").ToString();
            if (RecordCount == "")
            {
                RecordCount = "0";
            }
            return DatabaseUtiles.DB.ExecuteDataSet(command);
        }
        /// <summary>
        /// 自定义SQL语句获取分页数据
        /// </summary>
        /// <param name="Psql">select row_number() over(order by uID DESC) as RowNumName,*  from useraccount where realname='1' and email='1'  row_number() over(order by uID DESC)中order by 可以是多条件排序</param>
        /// <param name="PNum">当前页码</param>
        /// <param name="PSize">每页条数</param>
        /// <param name="Sort">空""</param>
        /// <param name="RowNumName">Psql中的row_number别名 如上面的RowNumName Psql中如未指定，可直接用表主键：uid</param>
        /// <param name="Pcount">总页数</param>
        /// <param name="Prcount">总数据</param>
        /// <returns></returns>
        static public DataSet PR_Pager(string Psql, int PNum, int PSize, string Sort, string RowNumName, out int Pcount, out int Prcount)
        {
            DbCommand command = DatabaseUtiles.DB.GetStoredProcCommand("Pager");

            DatabaseUtiles.DB.AddInParameter(command, "@Psql", DbType.String, Psql);
            DatabaseUtiles.DB.AddInParameter(command, "@PNum", DbType.Int32, PNum);
            DatabaseUtiles.DB.AddInParameter(command, "@Sort", DbType.String, "");
            DatabaseUtiles.DB.AddInParameter(command, "@PSize", DbType.Int32, PSize);
            DatabaseUtiles.DB.AddInParameter(command, "@RowNumName", DbType.String, RowNumName);
            DatabaseUtiles.DB.AddOutParameter(command, "@Pcount", DbType.Int32, 10);
            DatabaseUtiles.DB.AddOutParameter(command, "@Prcount", DbType.String, 10);
            var ds=DatabaseUtiles.DB.ExecuteDataSet(command);
            Pcount = Convert.ToInt32(DatabaseUtiles.DB.GetParameterValue(command, "@Pcount"));
            Prcount = Convert.ToInt32(DatabaseUtiles.DB.GetParameterValue(command, "@Prcount"));
            return ds;
        }
    }

}