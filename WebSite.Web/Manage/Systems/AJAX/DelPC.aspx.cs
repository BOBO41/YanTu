using System;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class DelPC : System.Web.UI.Page
    {
        private readonly OrgArea _dalOrgArea = new OrgArea();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                if (!string.IsNullOrEmpty(Request.Form["id"]))
                {
                    var orgid = Request.Form["id"];
                    var sql = "SELECT COUNT(1) FROM OrgOrganize cpl JOIN (SELECT * FROM  dbo.getOrgAreaChild('" + orgid + "') ) b ON cpl.[AreaId]=b.[AreaId] and cpl.[Status]=1 ";
                    Database db = DatabaseFactory.CreateDatabase();
                    DbCommand dbCommand = db.GetSqlStringCommand(sql);
                    int cmdresult;
                    object obj = db.ExecuteScalar(dbCommand);
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, global::System.DBNull.Value)))
                    {
                        cmdresult = 0;
                    }
                    else
                    {
                        cmdresult = int.Parse(obj.ToString());
                    }
                    if (cmdresult == 0)
                    {
                        var model = _dalOrgArea.GetModel(orgid);
                        if (null==model)
                        {
                            Response.Write("删除失败！区域不存在！");
                            Response.End();
                        }
                        model.Status = 0;
                        if (_dalOrgArea.Update(model))
                        {
                            Response.Write("删除成功");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("删除失败");
                            Response.End();
                        }

                    }
                    else
                    {
                        Response.Write("删除失败,该区域下还有组织机构");
                        Response.End();
                    }

                }
                else
                {
                    Response.Write("删除失败");
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception)
            {
                Response.Write("删除失败");
                Response.End();
            }

        }
    }
}
