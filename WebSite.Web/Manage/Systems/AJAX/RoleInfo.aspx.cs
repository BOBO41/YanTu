using System;
using System.Data;
using System.Linq;
using System.Web;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class RoleInfo : WebPage
    {
        SYS_RoleInfo mRole = new SYS_RoleInfo();
        SYS_UserForRole mUfr = new SYS_UserForRole();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var role_id = Request.QueryString["role_id"];
                var RoleName = HttpUtility.UrlDecode(Request.QueryString["RoleName"]);
                var RoleMemo = HttpUtility.UrlDecode(Request.QueryString["RoleMemo"]);
                var IsSuper = Request.QueryString["IsSuper"];
                var adnUser_id = Request.QueryString["adnUser_id"];
                var gid_str = Request.QueryString["gid_str"];
                if (!string.IsNullOrEmpty(adnUser_id))
                {
                    if (string.IsNullOrEmpty(gid_str))
                    {
                        Response.Write("请选择要保存的数据！");
                        Response.End();
                    }
                    else
                    {
                        string[] stringSeparators = new string[] { "_" };
                        string[] sArray = gid_str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                        int res = 0;
                        DataSet dts = mUfr.GetList(" UId=" + adnUser_id);
                        if (dts.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                            {
                                if (dts.Tables[0].Rows[i]["UFR_Id"] != "" && dts.Tables[0].Rows[i]["UFR_Id"] != null)
                                {
                                    mUfr.Delete(int.Parse(dts.Tables[0].Rows[i]["UFR_Id"].ToString()));
                                }
                            }
                        }
                        for (int j = 0; j < sArray.Count(); j++)
                        {
                            Admin.Model.SYS_UserForRole userForRole = new Admin.Model.SYS_UserForRole();
                            userForRole.Adn_Id = Convert.ToInt32(adnUser_id);
                            userForRole.Role_Id = int.Parse(sArray[j]);
                            res = mUfr.Add(userForRole);
                            if (res > 0)
                            {
                                res++;
                            }
                        }
                        Response.Write(res > 0 ? "保存成功" : "保存失败");
                        Response.End();
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(RoleName))
                    {
                        Response.Write("角色名称不能为空");
                        Response.End();
                    }
                    try
                    {


                        var roleInfo = new Admin.Model.SYS_RoleInfo();
                        roleInfo.Role_Name = RoleName;
                        roleInfo.Role_Memo = RoleMemo;
                        roleInfo.Role_IsSuper = IsSuper == "rboIsSuperNo" ? 0 : 1; ;

                        if (!string.IsNullOrEmpty(role_id))
                        {
                            var role = mRole.GetModel(Convert.ToInt32(role_id));
                            if (role != null)
                            {
                                var ds = mRole.GetList(" Role_Name='" + RoleName + "' and Role_Id !=" + role_id);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Response.Write("角色名称已存在");
                                    Response.End();
                                }
                                roleInfo.Role_Id = role.Role_Id;
                                roleInfo.Role_Status = role.Role_Status;
                                roleInfo.Role_SecurityID = role.Role_SecurityID;
                                Response.Write(mRole.Update(roleInfo) ? "保存成功" : "修改失败");
                                Response.End();
                            }
                            else
                            {
                                Response.Write("该角色不存在！");
                                Response.End();
                            }
                        }
                        else
                        {
                            var ds = mRole.GetList(" Role_Name='" + RoleName + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Response.Write("角色已存在");
                                Response.End();
                            }
                            roleInfo.Role_Status = 1;
                            roleInfo.Role_SecurityID = Guid.NewGuid().ToString();
                            Response.Write(mRole.Add(roleInfo) > 0 ? "保存成功" : "保存失败");
                            Response.End();

                        }
                    }
                    catch (System.Threading.ThreadAbortException ex)
                    {
                    }
                    catch (Exception ex1)
                    {

                        Response.Write("保存失败");
                        Response.End();
                    }
                }
            }
        }

    }

}