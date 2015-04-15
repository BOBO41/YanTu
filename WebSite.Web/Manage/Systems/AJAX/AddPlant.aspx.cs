using System;
using System.Text;
using WebSite.Area.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class AddPlant : System.Web.UI.Page
    {
        LandCustomer landDal = new LandCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (string.IsNullOrEmpty(Request.QueryString["LCID"]))
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("  <div class=\"control-group\"> ");
                        strSql.Append("  <div class=\"controls\"> ");
                        strSql.Append("  <input type=\"text\"  class=\"input-small\" id=\"txtPlant\" name=\"txtPlant\" placeholder=\"种植作物\" runat=\"server\" />");
                        strSql.Append("  <input type=\"text\"  class=\"input-small\" id=\"txtArea\" name=\"txtArea\" placeholder=\"面积\" runat=\"server\" />");
                        strSql.Append("  <a href=\"javascript:void(0);\" onclick=\"del(this);\">删除</a>");
                        strSql.Append("  </div> ");
                        strSql.Append("  </div>");
                        Response.Write(1 + strSql.ToString());
                        Response.End();
                    }
                    catch (System.Threading.ThreadAbortException ex)
                    {
                    }
                    catch (Exception)
                    {
                        Response.Write("添加种植信息失败！");
                        Response.End();
                    }
                }
                else
                {
                    try
                    {
                        bool re = landDal.Delete(Convert.ToInt32(Request.QueryString["LCID"]));
                        if (re)
                        {
                            Response.Write(1);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("删除种植信息失败！");
                            Response.End();
                        }
                    }
                    catch (System.Threading.ThreadAbortException ex)
                    {
                    }
                    catch (Exception)
                    {
                        Response.Write("删除种植信息失败！");
                        Response.End();
                    }
                }
            }
        }
    }
}
