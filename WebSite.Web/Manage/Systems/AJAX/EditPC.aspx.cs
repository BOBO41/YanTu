using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class EditPC : System.Web.UI.Page
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
                var model = bll.GetModel(id);
                model.AreaName = pcname;
                List<SqlParameter> parameters = new List<SqlParameter>();
                var parameter = new SqlParameter("@AreaName", DbType.AnsiString) { Value = pcname };
                parameters.Add(parameter);
                var parameter1 = new SqlParameter("@AreaId", DbType.AnsiString) { Value = id };
                parameters.Add(parameter1);
                var parameter2 = new SqlParameter("@ParentId", DbType.AnsiString) { Value = model.ParentId };
                parameters.Add(parameter2);
                if (bll.GetList(" AreaName=@AreaName and Status=1 and AreaId!=@AreaId ", parameters).Tables[0].Rows.Count > 0)
                {
                    Response.Write("区域名称已存在");
                    Response.End();
                }

                Response.Write(bll.Update(model) ? "修改成功" : "修改失败");
                Response.End();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception)
            {
                Response.Write("修改失败");
                Response.End();
            }

        }
    }
}
