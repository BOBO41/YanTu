using System;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddSystemPageConfig : WebPage
    {
        SYS_PageConfig mPage = new SYS_PageConfig();
        private int pc_id = 0;
        private int pageid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                pc_id = Request.QueryString["pc_id"] == null ? 0 : int.Parse(Request.QueryString["pc_id"]);
                pageid = Request.QueryString["pageid"] == null ? 0 : int.Parse(Request.QueryString["pageid"]);
                //hidpageid.Value = pageid.ToString();
                if (pc_id != 0)
                {
                    //this.lblTitle.Text = "修改功能信息";
                    Admin.Model.SYS_PageConfig pageInfo = mPage.GetModel(pc_id);
                    if (pageInfo != null)
                    {
                        this.txtPCNames.Value = pageInfo.PC_Name;
                        this.txtPCMemo.Value = pageInfo.PC_Memo;
                        this.txtPCHrefUrl.Value = pageInfo.PC_HrefUrl;
                    }
                }
                //hidpc_id.Value = pc_id.ToString();
            }
        }

    }
}