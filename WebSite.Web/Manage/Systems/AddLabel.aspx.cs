using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddLabel : UI.WebPage
    {
        private readonly ALabel _dataDal = new ALabel();
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
                var str = " [Status]=1 and ALID=@OrgId ";
                var dt = _dataDal.GetList(str, parameters).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtName.Value = dt.Rows[0]["LName"].ToString();
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
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写标签名称！');</script>");
                return;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"]))
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                    parameters.Add(parameter);
                    var str = " [Status]=1 and ALID=@OrgId ";
                    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                    if (null == dt)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('标签不存在！');</script>");
                        return;
                    }
                    dt.LName = txtName.Value;
                    if (_dataDal.Exists(Convert.ToInt32(Request.QueryString["OrgId"]), txtName.Value))
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('标签已经存在！');</script>");
                        return;
                    }
                    var res = _dataDal.Update(dt);
                    if (res)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                            "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
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
                var model = new Admin.Model.ALabel()
                {
                    CreateDate = DateTime.Now,
                    LName = name,
                    Status = 1,
                    Creater = CurrentUser.UId
                };
                if (_dataDal.Exists(0, name))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('标签已经存在！');</script>");
                    return;
                }
                var resAdd = _dataDal.Add(model);
                if (resAdd > 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "",
                        "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('新增失败！');window.top.$modal.destroy();</script>");
                }
            }
        }
    }
}