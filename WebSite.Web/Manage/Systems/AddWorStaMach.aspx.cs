using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddWorStaMach : UI.WebPage
    {
        private readonly Admin.DAL.OrgWorkStation _dataDal = new Admin.DAL.OrgWorkStation();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["OrgId"]))
                {
                    BindData(Request.QueryString["OrgId"]);
                }
            }
        }

        private void BindData(string orgId)
        {
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = orgId };
                parameters.Add(parameter);
                var str = " oo.[Status]=1 and oo.[OrgId]=@OrgId ";
                var dt = _dataDal.GetModel(Convert.ToInt32(orgId));
                if (dt != null)
                {
                    txtName.Value = dt.ToolsMemo;
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            var name = txtName.Value.Trim();
            if (string.IsNullOrEmpty(name))
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');window.parent.$modal.destroy();</script>");
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写设备编号！');</script>");
                return;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"]))
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                    parameters.Add(parameter);
                    var str = " oo.[Status]=1 and oo.[OrgId]=@OrgId ";
                    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                    if (dt == null)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
                        return;
                    }
                    dt.ToolsMemo = txtName.Value.Trim();
                    var res = _dataDal.Update(dt);
                    if (res)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>alert('更新成功！');window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('更新失败！');window.top.$modal.destroy();</script>");
                    }
                }
                catch (Exception)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');window.top.$modal.destroy();</script>");
            }
        }
    }

}