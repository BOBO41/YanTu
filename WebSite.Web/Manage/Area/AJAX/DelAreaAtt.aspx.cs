using System;
using WebSite.Area.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Area.AJAX
{
    public partial class DelAreaAtt : WebPage
    {
        LandAttribute laDAL = new LandAttribute();
        LandAttributeValue landAttDAL = new LandAttributeValue();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                if (!IsPostBack)
                {
                    var laid = Request.QueryString["laid"];           //删除属性ID

                    var rs = laDAL.Delete(Convert.ToInt32(laid));
                    if (rs)
                    {
                        Response.Write("删除成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("删除失败");
                        Response.End();
                    }
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                throw ex;
            }
            catch
            {
                Response.Write("该属性已被地块使用，不能删除");
                Response.End();
            }
        }
    }
}