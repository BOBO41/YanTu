using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddOrgDepUser : UI.WebPage
    {
        private readonly OrgEmployees _dataDal = new OrgEmployees();
        private readonly OrgUsers _dataDal1 = new OrgUsers();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                BindOrgName();
                if (!string.IsNullOrEmpty(Request.QueryString["empId"]))
                {
                    BindData(Request.QueryString["empId"]);
                }
                else
                {
                    rboDouble.Checked = true;
                }
            }
        }

        private void BindData(string empId)
        {
            try
            {
                var model = _dataDal.GetModel(Convert.ToInt32(empId));
                txtName.Value = model.EmplName;
                ddlSex.Value = model.Sex;
                //txtBirthDay.Value = Convert.ToDateTime(model.Birthday).ToString("yyyy-MM-dd");
                //txtAddr.Value = model.HomeAddress;
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
                    txtPwd.Attributes.Add("type", "password");

                    txtpw.Attributes.Add("Value", dt.Rows[0]["UserPwd"].ToString());
                    txtpw.Attributes.Add("type", "password");

                    if (dt.Rows[0]["Type"].ToString() == "15")
                    {
                        rboSinglestaadmin.Checked = true;
                        dorg.Style.Add("display", "block");
                        ddlOrgName.SelectedValue = model.OrgId.ToString();
                    }
                    else if (dt.Rows[0]["Type"].ToString() == "14")
                    {
                        rboDouble.Checked = true;
                        dorg.Style.Add("display", "block");
                        ddlOrgName.SelectedValue = model.OrgId.ToString();
                    }
                    else if (dt.Rows[0]["Type"].ToString() == "1")
                    {
                        rboSingle.Checked = true;
                        dorg.Style.Add("display", "none");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void BindOrgName()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();         //创建sql参数存储对象
            string sqlWhere = " Status =1 and OrgType=1 ";
            DataSet dtor = _orgOrganizeDal.GetList(sqlWhere, parameters);
            ddlOrgName.DataSource = dtor;
            ddlOrgName.DataTextField = "OrgName";
            ddlOrgName.DataValueField = "OrgId";
            ddlOrgName.DataBind();
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            var name = txtName.Value.Trim();
            var sex = ddlSex.Value;
            //var birthDay = txtBirthDay.Value;
            //var addr = txtAddr.Value.Trim();
            var cell = txtCell.Value.Trim();
            var userName = txtUserName.Value.Trim();
            var pwd = txtPwd.Value.Trim();
            var pw = txtpw.Value.Trim();
            if (string.IsNullOrEmpty(name))
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');window.parent.$modal.destroy();</script>");
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');</script>");
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
            if (pw != pwd)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('两次输入的密码不一致！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(sex))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择性别！');</script>");
                return;
            }
            //if (string.IsNullOrEmpty(birthDay))
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写出生日期！');</script>");
            //    return;
            //}
            //try
            //{
            //    Convert.ToDateTime(birthDay);
            //}
            //catch (Exception)
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('出生日期请输入正确的时间格式！');</script>");
            //    return;
            //}
            //if (string.IsNullOrEmpty(addr))
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写地址！');</script>");
            //    return;
            //}
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
            var orgid = "0";
            var type = Convert.ToInt32(Request.Form["rboSelectType"]);
            if (1 != type)
            {
                orgid = ddlOrgName.SelectedValue;
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
                    model.Birthday = DateTime.Now;
                    model.HomeAddress = "";
                    model.Phone = cell;
                    model.Sex = sex;
                    var res = _dataDal.UpdateEmpUser(orgid, Request.QueryString["empId"], name, sex, DateTime.Now.ToString(), "", cell, userName, pwd, type, "");
                    if (res == "1")
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                        //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
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
                var model = new Admin.Model.OrgEmployees
                {
                    Addtime = DateTime.Now,
                    Birthday = Convert.ToDateTime(DateTime.Now),
                    EmplName = name,
                    HomeAddress = "",
                    OrgId = Convert.ToInt64(Request.QueryString["oId"]),
                    Sex = sex,
                    Phone = cell,
                    Status = 1
                };

                var resAdd = _dataDal.AddEmpUserType(orgid, name, sex, DateTime.Now.ToString(), "", cell, userName, pwd, type);
                if (resAdd > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户名已存在！');</script>");
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