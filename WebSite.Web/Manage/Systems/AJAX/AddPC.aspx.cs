using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class AddPC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                if (string.IsNullOrEmpty(Request.Form["id"])) return;
                var id = Request.Form["id"];
                if (string.IsNullOrEmpty(Request.Form["name"])) return;
                var pcname = Request.Form["name"];
                var bll = new OrgArea();
                List<SqlParameter> parameters = new List<SqlParameter>();
                var parameter = new SqlParameter("@AreaName", DbType.AnsiString) { Value = pcname };
                parameters.Add(parameter);
                if (bll.GetList(" AreaName=@AreaName and Status=1 ", parameters).Tables[0].Rows.Count > 0)
                {
                    Response.Write("区域名称已存在");
                    Response.End();
                }
                
                var model = new Admin.Model.OrgArea
                {
                    AreaName = pcname,
                    ParentId = id,
                    AreaId=bll.MaxAreaId(),
                    AreaLevel=3,
                    Status = 1
                };

                Response.Write(bll.Add(model) ? "保存成功" : "保存失败");
                Response.End();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception)
            {
                Response.Write("保存失败");
                Response.End();
            }
        }
    }
}
