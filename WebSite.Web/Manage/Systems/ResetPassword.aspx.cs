//**************************************************************
// 文件名：ResetPassword（重置密码页面）
// 数据表：UserAccount(会员信息表)
// 创建人： 田霄
// 创建时间： 2013年9月24日
//**************************************************************

using System;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class ResetPassword : WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
            }
        }

    }
}