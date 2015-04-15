using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddOrgWorkStation : UI.WebPage
    {
        private readonly OrgOrganize _dataDal = new OrgOrganize();
        private readonly SWCompany _dataSWCDal = new SWCompany();
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
                var dt = _dataDal.GetWorStaList(str, parameters).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    txtName.Value = dt.Rows[0]["OrgName"].ToString();
                    txtManager.Value = dt.Rows[0]["OrgAddress"].ToString();
                    txtManPhone.Value = dt.Rows[0]["OrgPhone"].ToString();
                    txtEndDate.Value = Convert.ToDateTime(dt.Rows[0]["EndDate"]).ToString("yyyy-MM-dd");
                    txtEnName.Value = dt.Rows[0]["EnName"].ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            var name = txtName.Value.Trim();
            //var size = txtSize.Value.Trim();
            //var area = txtArea.Value.Trim();
            var manager = txtManager.Value.Trim();
            var managerPhone = txtManPhone.Value.Trim();
            var enddate = txtEndDate.Value.Trim();
            var enName = txtEnName.Value.Trim();
            if (string.IsNullOrEmpty(name))
            {
                //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');window.parent.$modal.destroy();</script>");
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写分站名称！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(enName))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写英文名称！');</script>");
                return;
            }
            //if (string.IsNullOrEmpty(size))
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写规模！');</script>");
            //    return;
            //}
            //if (string.IsNullOrEmpty(area))
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写面积！');</script>");
            //    return;
            //}
            if (string.IsNullOrEmpty(manager))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写负责人！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(managerPhone))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写负责人电话！');</script>");
                return;
            }
            if ((!System.Text.RegularExpressions.Regex.IsMatch(managerPhone, @"^[1]+[3,4,5,8]+\d{9}")) && (!System.Text.RegularExpressions.Regex.IsMatch(managerPhone, @"^(\d{3,4}-)?\d{6,8}$")))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('负责人电话格式错误，请重新输入！');</script>");
                return;
            }
            if (string.IsNullOrEmpty(enddate))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写合同到期时间！');</script>");
                return;
            }
            //if (string.IsNullOrEmpty(orgId))
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择分公司！');</script>");
            //    return;
            //}
            if (!string.IsNullOrEmpty(Request.QueryString["OrgId"]))
            {
                try
                {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    var parameter = new SqlParameter("@OrgId", DbType.AnsiString) { Value = Request.QueryString["OrgId"] };
                    parameters.Add(parameter);
                    var str = " oo.[Status]=1 and oo.[OrgId]=@OrgId ";
                    var dt = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["OrgId"]));
                    if (null == dt)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('分站不存在！');</script>");
                        return;
                    }
                    dt.OrgName = txtName.Value;
                    dt.EnName = enName;
                    dt.OrgAddress = txtManager.Value;
                    dt.OrgPhone = txtManPhone.Value;
                    dt.EndDate = Convert.ToDateTime(enddate);
                    if (_dataDal.Exists(Convert.ToInt32(Request.QueryString["OrgId"]), txtName.Value))
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('分站已经存在！');</script>");
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
                var model = new Admin.Model.OrgOrganize
                {
                    AreaId = "61000",
                    AddTime = DateTime.Now,
                    OrgAddress = manager,
                    OrgPhone = managerPhone,
                    OrgName = name,
                    Status = 1,
                    OrgType = 1,
                    EndDate = Convert.ToDateTime(enddate),
                    EnName = enName
                };
                if (_dataDal.Exists(0, name))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('分站已经存在！');</script>");
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