using System;
using System.Data;
using System.Linq;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.CM.Ajax
{
    public partial class ColumnShow : WebPage
    {
        WebSite.CM.DAL.CMColumn colDAL = new WebSite.CM.DAL.CMColumn();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);
                var ds = colDAL.GetDateList(" ParentId='" + id + "' ");
                var str = string.Empty;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    str = ds.Tables[0].Rows.Cast<DataRow>()
                                      .Aggregate(str,
                                                 (current, dr) =>
                                                 current + ("," + dr["ColId"]));
                }
                Response.Write(str);
                Response.End();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                throw ex;
            }
            catch
            {
                Response.Write("");
                Response.End();
            }
        }
    }
}