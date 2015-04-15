using WebSite.Admin.Model;

namespace WebSite.Web.UI
{
    public class WebPage : System.Web.UI.Page
    {
        public OrgUsers CurrentUser = null;
        public Admin.DAL.OrgUsers MAdn = new Admin.DAL.OrgUsers();

        /// <summary>
        /// 验证登录权限和功能的使用权限
        /// </summary>
        /// <param name="desiredFunction"></param>
        /// <param name="isResponseEnd"></param>
        /// <returns></returns>
        public bool VerifyPage(string desiredFunction, bool isResponseEnd)
        {
            //验证登录权限
            //登录后在session中保存当前用户对象
            if (Session["CurrentUser"] == null && Session["CurrentFacUser"] == null)
            {
                Response.Write("<script>alert('登录超时,请重新登录');window.top.location='/Login.aspx';</script>");
                return false;
            }
            if (Session["CurrentUser"] == null) return Session["CurrentFacUser"] != null;
            CurrentUser = (OrgUsers)Session["CurrentUser"];
            // 验证菜单权限
            if (desiredFunction == "") return true;
            if (MAdn.ExistsUsersPage(desiredFunction, CurrentUser.UId))
            {
                return true;
            }
            if (!isResponseEnd) return false;
            Response.Write("您没有访问本页面的权限！");
            return false;
        }
    }
}