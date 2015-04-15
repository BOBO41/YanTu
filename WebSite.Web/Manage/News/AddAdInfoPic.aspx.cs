using System;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class AddAdInfoPic : UI.WebPage
    {
        private readonly Infos _infosDal = new Infos();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var iid = Request.QueryString["iid"];
                if (!string.IsNullOrEmpty(iid))
                {
                    var imodel = _infosDal.GetModel(Convert.ToInt32(iid));
                    if (null != imodel)
                    {
                        txtName.Value = imodel.IName;

                        if (!string.IsNullOrEmpty(imodel.PicAttID))
                        {
                            var fname = "";
                            if ("C0pY" == imodel.PicAttID.Substring(0, 4))
                            {
                                fname = imodel.PicAttID.Substring(76);
                            }
                            else
                            {
                                fname = imodel.PicAttID.Substring(36);
                            }
                            litPic.Text =
                            "<div class=\"upatta\" title=\"" + fname + "\" data-file=\"" + imodel.PicAttID + "\"><div class=\"upsigin\"><div class=\"at-file\"><img width=\"220\" id=\"at-img\" src=\"/UploadFiles/" + imodel.PicAttID + "\"><span class=\"at-name\">" + (fname.Length > 15 ? fname.Substring(0, 15) + "..." : fname) + "</span></div></div></div>";
                        }
                    }
                }
            }
        }
    }
}