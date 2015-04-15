using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.SysLogs
{
    public partial class ValueCompare : UI.WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["LId"]))
                {
                    try
                    {
                        var parameters = new List<SqlParameter>();
                        var parameter = new SqlParameter("@LLID", DbType.Int64) {Value = Request.QueryString["LId"]};
                        parameters.Add(parameter);
                        var dt = new Logs().GetList(" LLID=@LLID ", parameters).Tables[0];
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}