using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.DBUtilities
{
    public class SQLServerUtiles
    {
        static public DbCommand Get_SP_ExecuteSQL(Database db, string stmtStr, string paramsStr)
        {
            DbCommand command = db.GetStoredProcCommand("sp_executesql");
            db.AddInParameter(command, "stmt", DbType.String, stmtStr);
            db.AddInParameter(command, "params", DbType.String, paramsStr);
            return command;
        }
   }
}