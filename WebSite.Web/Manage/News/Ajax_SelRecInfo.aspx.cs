using System;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class Ajax_SelRecInfo : UI.WebPage
    {
        private readonly Infos _infosDal = new Infos();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly AdInfos _adInfosDal = new AdInfos();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            var iid = Request.QueryString["iid"];
            var siid = Request.QueryString["siid"];
            var daiid = Request.QueryString["daiid"];

            try
            {
                if (!string.IsNullOrEmpty(daiid))
                {
                    var aimodel = _adInfosDal.GetModel(Convert.ToInt32(daiid));
                    if (null != aimodel)
                    {
                        var res = _adInfosDal.Delete(aimodel.AIID);
                        if (res)
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

                if (!string.IsNullOrEmpty(iid) && !string.IsNullOrEmpty(siid))
                {
                    var aimodel = new Admin.Model.AdInfos();
                    aimodel.IID = Convert.ToInt32(iid);
                    aimodel.Inf_IID = Convert.ToInt32(siid);
                    var res = _adInfosDal.Add(aimodel);
                    if (res > 0)
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