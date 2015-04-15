using System;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_Type
{
    public partial class DelPackageType : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                var itid = Request.QueryString["itid"];

                if (!string.IsNullOrEmpty(itid))
                {
                    var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                    if (null != itmodel)
                    {
                        var upres = _infoTypeDal.DelPackType(itmodel);
                        if (upres)
                        {
                            Response.Write("0|~|" + itid);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("1|~|操作失败");
                            Response.End();
                        }
                    }
                }
                else
                {
                    Response.Write("1|~|操作失败");
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ee)
            {
                Response.Write("1|~|" + ee.Message);
                Response.End();
            }
        }

    }

}