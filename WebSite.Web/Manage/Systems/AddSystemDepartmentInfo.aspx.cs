using System;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddSystemDepartmentInfo : WebPage
    {
        SYS_DepartmentInfo mDpt = new SYS_DepartmentInfo();
        private int dpt_id = 0;
        private int dptid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                dpt_id = Request.QueryString["dpt_id"] == null ? 0 : int.Parse(Request.QueryString["dpt_id"]);
                dptid = Request.QueryString["dptid"] == null ? 0 : int.Parse(Request.QueryString["dptid"]);
                if (dpt_id != 0)
                {
                    this.lblTitle.Text = "修改部门信息";
                    Admin.Model.SYS_DepartmentInfo deptInfo = mDpt.GetModel(dpt_id);
                    if (deptInfo != null)
                    {
                        this.txtDeptName.Value = deptInfo.Dpt_Name;
                    }
                }
                dept_id.Value = dpt_id.ToString();
                hidDptid.Value = dptid.ToString();
            }
        }

    }
}