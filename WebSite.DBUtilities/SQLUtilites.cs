using System.Text;

namespace WebSite.DBUtilities
{
    public class SQLUtilites
    {
        public static string GetPageSQL(string stmtText, int startRowIndex, int maximumRows)
        {
            StringBuilder stmtStr = new StringBuilder();
            stmtStr.AppendLine("with ResultData as");
            stmtStr.AppendLine("(");
            stmtStr.AppendLine(stmtText);
            stmtStr.AppendLine(")");
            stmtStr.AppendLine("select * from ResultData");
            stmtStr.AppendLine("where rownumber >= " + startRowIndex.ToString());
            stmtStr.AppendLine("and rownumber <= " + maximumRows.ToString());
            return stmtStr.ToString();
        }

        public static void SetPageSQL(ref StringBuilder stmtStr, int startRowIndex, int maximumRows)
        {
            //stmtStr.AppendLine("row_number() over(order by cpsp_Settlements.SettlementID) as rownumber");
            stmtStr.Insert(0, "with ResultData as (\n");
            stmtStr.AppendLine(")");
            stmtStr.AppendLine("select * from ResultData");
            stmtStr.AppendLine("where rownumber > " + startRowIndex.ToString());
            stmtStr.AppendLine("and rownumber <= " + (startRowIndex + maximumRows).ToString());
        }

        public static void GetCommandPageSQL(ref string stmtText, ref string paramsText)
        {
            StringBuilder stmtStr = new StringBuilder();
            StringBuilder paramsStr = new StringBuilder();
            stmtStr.AppendLine("with ResultData as");
            stmtStr.AppendLine("(");
            stmtStr.AppendLine(stmtText);
            stmtStr.AppendLine(")");
            stmtStr.AppendLine("select * from ResultData");
            stmtStr.AppendLine("where rownumber >= @startRowIndex and rownumber <= @maximumRows");
            stmtText = stmtStr.ToString();

            paramsStr.Append(paramsText);
            if (string.IsNullOrEmpty(paramsText.Trim()))
            {
                paramsStr.Append(",");
            }
            paramsStr.Append("@startRowIndex int");
            paramsStr.Append(",@maximumRows int");
            paramsStr.ToString();
        }
    }
}