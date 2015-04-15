using System;
using WebSite.Admin.Model;
using WebSite.Lib.Security;

namespace WebSite.Web.Manage.Systems
{
    public partial class Top : UI.WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (Session["CurrentUser"] != null)
            {
                litUserName.Text = ((SYS_AdminUser)Session["CurrentUser"]).Adn_RealName;
            }
            else if (Session["CurrentFacUser"] != null)
            {
                litUserName.Text = ((FactroyInfo)Session["CurrentFacUser"]).Contact;
            }
            else
            {
                divLogged.Visible = false;
            }
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            SecurityMgr.Logoff();
            Response.Redirect("/login.aspx");
        }
    }
}