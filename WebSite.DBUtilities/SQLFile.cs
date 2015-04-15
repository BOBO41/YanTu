using System;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.DBUtilities
{
    public class SQLFile
    {
        public static void ExecText(string sqlText)
        {
            ExecText(string.Empty, sqlText);
        }

        public static void ExecText(string connectionname, string sqlText)
        {
            Trace.WriteLine(sqlText);
            if (sqlText.Trim().Equals(""))
            {
                return;
            }
            Database db;
            if (string.IsNullOrEmpty(connectionname))
                db = DBUtilities.DB;
            else
                db = DatabaseFactory.CreateDatabase(connectionname);
            DbCommand dbCommand = db.GetSqlStringCommand(sqlText);
            dbCommand.CommandTimeout = 0;
            db.ExecuteNonQuery(dbCommand);
            db = null;
        }

        static public Boolean Exec(string filename)
        {
            return Exec(string.Empty, filename);
        }

        static public Boolean Exec(string connectionname, string filename)
        {
            // Delete the file if it exists.

            string pathName;
            pathName = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
            pathName = pathName + @"\" + filename;
            if (!File.Exists(pathName))
            {
                //if (!File.Exists(filename))
                throw new Exception("no found " + filename);
                //return false;
            }

            //using EnterpriseUtils.SQL.ExecSQL.txt;
            //Open the stream and read it back.
            string strTemp;
            using (StreamReader sr = new StreamReader(pathName))
            {
                StringBuilder SQLStr = new StringBuilder();
                do
                {
                    strTemp = sr.ReadLine();
                    if (strTemp.Trim().Equals("go", StringComparison.OrdinalIgnoreCase))
                    {
                        ExecText(connectionname, SQLStr.ToString());
                        SQLStr = new StringBuilder();
                    }
                    else
                    {
                        SQLStr.AppendLine(strTemp);
                    }
                }
                while (!sr.EndOfStream);

                ExecText(connectionname, SQLStr.ToString());
            }

            return true;
        }
    }
}