using System;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class CheckPC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                if (string.IsNullOrEmpty(Request.Form["id"])) return;
                var orgid = Request.Form["id"];
                var sql = "SELECT COUNT(1) FROM OrgOrganize cpl JOIN (SELECT * FROM  dbo.getOrgAreaChild('" + orgid + "') ) b ON cpl.[AreaId]=b.[AreaId] and cpl.[Status]=1 ";
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
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
                    Response.Write("no");
                    Response.End();
                }
                else
                {
                    Response.Write("yes");
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception)
            {
            }
        }
    }
}
