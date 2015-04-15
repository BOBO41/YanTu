using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddOrgWorStaUser : UI.WebPage
    {
        private readonly OrgEmployees _dataDal = new OrgEmployees();
        private readonly OrgUsers _dataDal1 = new OrgUsers();
        private readonly OrgOrganize _dataDal2 = new OrgOrganize();
        private readonly OrgCustomer _dataDal3 = new OrgCustomer();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                ddlLogis.DataSource = _dataDal2.GetList(" OrgType=5 and Status=1 ", parameters);
                ddlLogis.DataTextField = "OrgName";
                ddlLogis.DataValueField = "OrgId";
                ddlLogis.DataBind();
                ddlLogis.Items.Insert(0, new ListItem("请选择工作站", "0"));
                if (!string.IsNullOrEmpty(Request.QueryString["empId"]))
                {
                    BindData(Request.QueryString["empId"]);
                }
            }
        }

        private void BindData(string empId)
        {
            try
            {
                var model = _dataDal.GetModel(Convert.ToInt32(empId));
                ddlLogis.SelectedValue = model.OrgId.ToString();
                txtName.Value = model.EmplName;
                ddlSex.Value = model.Sex;
                txtBirthDay.Value = Convert.ToDateTime(model.Birthday).ToString("yyyy-MM-dd");
                txtAddr.Value = model.HomeAddress;
                txtCell.Value = model.Phone;
                List<SqlParameter> parameters = new List<SqlParameter>();
                var parameter = new SqlParameter("@EmplId", DbType.AnsiString) { Value = model.EmplId };
                parameters.Add(parameter);
                var str = " EmplId=@EmplId ";
                var dt = _dataDal1.GetList(str, parameters).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtUserName.Value = dt.Rows[0]["UserName"].ToString();
                    txtPwd.Attributes.Add("Value", dt.Rows[0]["UserPwd"].ToString());
                }
                List<SqlParameter> parametercus = new List<SqlParameter>();
                DataSet dts = _dataDal3.GetList("CID in (select CId from WorStaUserAcc where EmplId in (select * from dbo.SplitToTable('" + model.EmplId + "',',')))", parametercus);
                if (dts != null && dts.Tables[0].Rows.Count > 0)
                {
                    txtSelfCard.Value = dts.Tables[0].Rows[0]["SelfCard"].ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            var name = txtName.Value.Trim();
            var selfCard = txtSelfCard.Value.Trim();
            var sex = ddlSex.Value;
            var birthDay = txtBirthDay.Value;
            var addr = txtAddr.Value.Trim();
            var cell = txtCell.Value.Trim();
            var userName = txtUserName.Value.Trim();
            var pwd = txtPwd.Value.Trim();
            var orgId = ddlLogis.SelectedValue;
            if (string.IsNullOrEmpty(name))
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');window.parent.$modal.destroy();</script>");
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(selfCard))
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');window.parent.$modal.destroy();</script>");
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写身份证号！');</script>");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(selfCard, @"(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)"))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写正确的身份证号！');</script>");
                return;
            }
            if (orgId == "0")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择工作站！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(userName))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写用户名！');</script>");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(userName, @"^[\u4E00-\u9FA5\uf900-\ufa2d\w]{2,16}"))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户名只能用中文、英文、数字、下划线、2-16个字符，请重新输入！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(Request.QueryString["empId"]))
            {
                if (string.IsNullOrEmpty(pwd))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写密码！');</script>");
                    return;
                }
            }
            if (string.IsNullOrEmpty(sex))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择性别！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(birthDay))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写出生日期！');</script>");
                return;
            }
            try
            {
                Convert.ToDateTime(birthDay);
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('出生日期请输入正确的时间格式！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(addr))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写地址！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(cell))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写手机号码！');</script>");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(cell, @"^[1]+[3,4,5,8]+\d{9}"))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('手机号码格式错误，请重新输入！');</script>");
                return;

            }
            if (!string.IsNullOrEmpty(Request.QueryString["empId"]))
            {
                try
                {
                    var model = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["empId"]));
                    if (model == null)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('人员不存在！');</script>");
                        return;
                    }
                    model.EmplName = name;
                    model.Birthday = Convert.ToDateTime(birthDay);
                    model.HomeAddress = addr;
                    model.Phone = cell;
                    model.Sex = sex;
                    var res = _dataDal.UpdateEmpUser(orgId, Request.QueryString["empId"], name, sex, birthDay, addr, cell, userName, pwd, 5, selfCard);
                    if (res == "1")
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>window.top.$op.location = window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户名已存在！');</script>");
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
                }
            }
            else
            {
                //if (!string.IsNullOrEmpty(Request.QueryString["aId"]))
                //{
                //    var model = new Admin.Model.OrgEmployees
                //    {
                //        Addtime = DateTime.Now,
                //        Birthday = Convert.ToDateTime(birthDay),
                //        EmplName = name,
                //        HomeAddress = addr,
                //        OrgId = Convert.ToInt64(Request.QueryString["oId"]),
                //        Sex = sex,
                //        Phone = cell,
                //        Status = 1
                //    };
                var resAdd = _dataDal.AddEmpUser(orgId, name, sex, birthDay, addr, cell, userName, pwd, CurrentUser.UId, selfCard);
                if (resAdd == "1")
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location = window.top.$op.location;window.top.$modal.destroy();</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户名已存在');</script>");
                }
                //}
                //else
                //{
                //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
                //}
            }
        }
    }

}