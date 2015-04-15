using System;
using System.IO;
using System.Web;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Adver
{
    public partial class Ajax_AddAd : UI.WebPage
    {
        private readonly Advertisement _infosDal = new Advertisement();
        string ePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            ePath = Server.MapPath("/UpLoad/");
            try
            {
                var batta = Request.QueryString["batta"];
                var name = HttpUtility.UrlDecode(HttpUtility.UrlDecode(Request.QueryString["name"]));
                var iid = Request.QueryString["aid"];

                if (!string.IsNullOrEmpty(iid))
                {
                    var infomodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    infomodel.AName = name;
                    if (batta != infomodel.AImg)
                    {
                        var fi = new FileInfo(ePath + batta);
                        if (fi.Exists)
                        {
                            fi.MoveTo(Server.MapPath("/UploadFiles/" + batta));
                            var ofi = new FileInfo(Server.MapPath("/UploadFiles/" + infomodel.AImg));
                            if (ofi.Exists)
                            {
                                ofi.Delete();
                            }
                            infomodel.AImg = batta;
                        }
                    }
                    if (_infosDal.Exists(Convert.ToInt32(iid), name))
                    {
                        Response.Write("1|~|广告名称已经存在！");
                        Response.End();
                    }
                    var upres = _infosDal.Update(infomodel);
                    if (upres)
                    {
                        Response.Write("0|~|" + iid);
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
                    var inmodel = new Admin.Model.Advertisement();
                    inmodel.AName = name;
                    inmodel.Status = 1;
                    inmodel.CreateDate = DateTime.Now;
                    var fi = new FileInfo(ePath + batta);
                    if (fi.Exists)
                    {
                        fi.MoveTo(Server.MapPath("/UploadFiles/" + batta));
                        inmodel.AImg = batta;
                    }
                    if (_infosDal.Exists(0, name))
                    {
                        Response.Write("1|~|广告名称已经存在！");
                        Response.End();
                    }
                    var aiid = _infosDal.Add(inmodel);
                    Response.Write("0|~|" + aiid);
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