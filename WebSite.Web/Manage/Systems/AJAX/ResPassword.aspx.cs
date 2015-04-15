
//**************************************************************
// 文件名：ResPassword（重置密码处理页面）
// 数据表：UserAccount(会员信息表)
// 创建人： 田霄
// 创建时间： 2013年9月24日
//**************************************************************

using System;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class ResPassword : WebPage
    {
        UserAccount mUa = new UserAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var uid = Request.QueryString["uid"];                       //会员Id
                var pwdOne = Request.QueryString["pwdOne"];                //第一次输入密码
                var pwdTwo = Request.QueryString["pwdTwo"];                //第二次输入密码
                if (!string.IsNullOrEmpty(uid))                            //判断会员Id是否为空
                {
                    if (string.IsNullOrEmpty(pwdOne))                      //判断第一次密码是否为空
                    {
                        Response.Write("密码不能为空");
                        Response.End();
                    }
                    if (string.IsNullOrEmpty(pwdTwo))                      //判断第二次密码是否为空
                    {
                        Response.Write("再次输入密码不能为空");
                        Response.End();
                    }
                    if (pwdOne != pwdTwo)                                     //判断两次密码是否一致
                    {
                        Response.Write("两次密码输入内容不一致，请重新输入");
                        Response.End();
                    }
                    try
                    {
                        var userAccount = mUa.GetModel(Convert.ToInt64(uid));        //通过Id查询会员信息
                        if (userAccount != null)                                    //判断对象是否为空
                        {
                            userAccount.PassWord = pwdTwo;                          //给对象密码字段赋值

                            Response.Write(mUa.Update(userAccount) ? "密码重置成功" : "密码重置失败");          //判断修改方法是否成功，并给出提示
                            Response.End();
                        }
                    }
                    catch (System.Threading.ThreadAbortException ex)
                    {
                    }
                    catch (Exception ex1)
                    {

                        Response.Write("密码重置失败");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("请选择您要重置密码的数据");
                    Response.End();

                }
            }
        }

    }

}