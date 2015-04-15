using System;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_Infos
{
    public partial class Ajax_AdminInfo : UI.WebPage
    {
        private readonly Infos _infosDal = new Infos();
        string ePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            ePath = Server.MapPath("/UpLoad/");
            try
            {
                var iid = Request.QueryString["iid"];
                #region

                if (!string.IsNullOrEmpty(iid))
                {
                    var iimodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    if (null != iimodel)
                    {
                        var res = "";
                        if (1 == iimodel.Status)
                        {
                            iimodel.Status = 0;
                        }
                        else
                        {
                            iimodel.Status = 1;
                        }
                        var upres = _infosDal.Update(iimodel);
                        if (upres)
                        {
                            Response.Write("0|~|");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("1|~|操作失败");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("1|~|操作失败");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("1|~|操作失败");
                    Response.End();
                }

                #endregion

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