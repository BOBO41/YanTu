using System;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddSystemRoleInfo : WebPage
    {
        SYS_RoleInfo mRole = new SYS_RoleInfo();
        private int role_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                role_id = Request.QueryString["role_id"] == null ? 0 : int.Parse(Request.QueryString["role_id"]);

                if (role_id != 0)
                {
                    Admin.Model.SYS_RoleInfo roleInfo = mRole.GetModel(role_id);
                    if (roleInfo != null)
                    {
                        this.txtRoleNames.Value = roleInfo.Role_Name;
                        this.txtRoleMemo.Value = roleInfo.Role_Memo;

                    }
                }
            }
        }
    }
}