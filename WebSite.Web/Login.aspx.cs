using System;
using System.Web;
using WebSite.Lib.Security;

namespace WebSite.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //TextBox1.Text = "ch";
                //TextBox2.Text = "1";

                try
                {
                    var httpCookie = Request.Cookies["UserName"];
                    var cookie = Request.Cookies["PassWord"];
                    if (httpCookie != null)
                        TextBox1.Text = DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(httpCookie.Value);

                    if (cookie != null)
                        TextBox2.Attributes.Add("value", DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(cookie.Value));
                    //if (httpCookie != null && cookie != null)
                    //{
                    //var res = SecurityMgr.Login(DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(httpCookie.Value), DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(cookie.Value));
                    //if (!string.IsNullOrEmpty(res))
                    //{
                    //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + res + "');</script>");
                    //}
                    //else
                    //{
                    //    Response.Redirect("/Manage/Systems/Default.aspx");
                    //}
                    //    CheckBox1.Checked = true;
                    //}
                }
                catch (Exception)
                {
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = TextBox1.Text.Trim();
            var passWord = TextBox2.Text.Trim();
            //var checkCode = TextBox3.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                TextBox1.Focus();
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入用户名');</script>");
                return;
            }
            if (string.IsNullOrEmpty(passWord))
            {
                TextBox2.Focus();
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入密码');</script>");
                return;
            }
            //if (checkCode != Session[ValidateCode.VALIDATECODEKEY].ToString())
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('验证码输入错误');</script>");
            //    TextBox3.Text = "";
            //    TextBox3.Focus();
            //    return;
            //}
            var res = SecurityMgr.Login(userName, passWord);
            if (!string.IsNullOrEmpty(res))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('" + res + "');</script>");
            }
            else
            {
                var httpCookie = Request.Cookies["UserName"];
                if (httpCookie != null)
                {
                    var cookName = DotNet.Framework.Common.DEncrypt.DESEncrypt.Decrypt(httpCookie.Value);
                    if (cookName != userName)
                    {
                        var cUserNameStore = new HttpCookie("UserName")
                                {
                                    Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(userName)
                                };
                        //var cPassWord = new HttpCookie("PassWord")
                        //    {
                        //        Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(passWord)
                        //    };
                        cUserNameStore.Expires = DateTime.Now.AddDays(30);
                        //cPassWord.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cUserNameStore);
                    }
                }
                else
                {
                    var cUserNameStore = new HttpCookie("UserName")
                    {
                        Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(userName)
                    };
                    //var cPassWord = new HttpCookie("PassWord")
                    //    {
                    //        Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(passWord)
                    //    };
                    cUserNameStore.Expires = DateTime.Now.AddDays(30);
                    //cPassWord.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cUserNameStore);
                }
                //Response.Cookies.Add(cPassWord);
                //if (CheckBox1.Checked)
                //{
                //    var cUserNameStore = new HttpCookie("UserName")
                //        {
                //            Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(userName)
                //        };
                //    var cPassWord = new HttpCookie("PassWord")
                //        {
                //            Value = DotNet.Framework.Common.DEncrypt.DESEncrypt.Encrypt(passWord)
                //        };
                //    cUserNameStore.Expires = DateTime.Now.AddDays(30);
                //    cPassWord.Expires = DateTime.Now.AddDays(30);

                //    Response.Cookies.Add(cUserNameStore);
                //    Response.Cookies.Add(cPassWord);
                //}
                //else
                //{
                //    var httpCookie = Response.Cookies["UserName"];
                //    if (httpCookie != null)
                //        httpCookie.Expires = DateTime.Now.AddSeconds(-1);//Expires过期时间 
                //    var cookie = Response.Cookies["PassWord"];
                //    if (cookie != null)
                //        cookie.Expires = DateTime.Now.AddSeconds(-1);//Expires过期时间 
                //}
                Response.Redirect("/Manage/Systems/Default.aspx");
            }
        }
    }
}