using System;
using WebSite.Admin.Model;

namespace WebSite.Web.Manage.Systems
{
    public partial class ChangePass : UI.WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["CurrentUser"] != null)
                {
                    var user = Session["CurrentUser"] as OrgUsers;
                    string uPwd = txtOldPwd.Text.Trim();
                    string nPwd = txtNewPwd.Text.Trim();
                    var nPwd2 = txtNewPwd2.Text.Trim();
                    var dalAccount = new Admin.DAL.OrgUsers();
                    if (user.UserPwd != uPwd)
                    {
                        DotNet.Framework.Common.MessageBox.Show(this, "原密码输入错误！");
                        return;
                    }
                    if (nPwd != nPwd2)
                    {
                        DotNet.Framework.Common.MessageBox.Show(this, "再次密码不一致！");
                        return;
                    }
                    user.UserPwd = nPwd2;
                    if (dalAccount.Update(user))
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                                "<script>alert('密码修改成功！');window.top.$op.location = window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>alert('密码修改失败！');</script>");
                    }
                }
                else if (Session["CurrentFacUser"] != null)
                {
                    var facUser = Session["CurrentFacUser"] as FactroyInfo;
                    string uPwd = txtOldPwd.Text.Trim();
                    string nPwd = txtNewPwd.Text.Trim();
                    var nPwd2 = txtNewPwd2.Text.Trim();
                    var dalAccount = new Admin.DAL.FactroyInfo();
                    if (facUser.PassWord != uPwd)
                    {
                        DotNet.Framework.Common.MessageBox.Show(this, "原密码输入错误！");
                        return;
                    }
                    if (nPwd != nPwd2)
                    {
                        DotNet.Framework.Common.MessageBox.Show(this, "再次密码不一致！");
                        return;
                    }
                    facUser.PassWord = nPwd2;
                    if (dalAccount.Update(facUser))
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>alert('密码修改成功！');window.top.$op.location = window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>alert('密码修改失败！');</script>");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx", true);
                }
            }
            catch (Exception)
            {
                DotNet.Framework.Common.MessageBox.Show(Page, "操作失败！");
            }
        }
    }
}