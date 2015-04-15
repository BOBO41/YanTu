using System;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class EditBPic : UI.WebPage
    {
        private readonly TempInfo _tempInfoDal = new TempInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var tiid = Request.QueryString["tiid"];
                if (!string.IsNullOrEmpty(tiid))
                {
                    var timodel = _tempInfoDal.GetModel(Convert.ToInt32(tiid));
                    if (null!=timodel&&!string.IsNullOrEmpty(timodel.AttID))
                    {
                        //var fname = timodel.AttID.Substring(36);
                        var fname = "";
                        if ("C0pY" == timodel.AttID.Substring(0, 4))
                        {
                            fname = timodel.AttID.Substring(76);
                        }
                        else
                        {
                            fname = timodel.AttID.Substring(36);
                        }
                        litPic.Text =
                            "<div class=\"upatta\"  title=\"" + fname + "\" data-file=\"" + timodel.AttID +
                            "\"><div class=\"upsigin\"><div class=\"at-file\"><img width=\"220\" id=\"at-img\" src=\"/UploadFiles/" +
                            timodel.AttID + "\"><span class=\"at-name\">" +
                            (fname.Length > 15 ? fname.Substring(0, 15) + "..." : fname) + "</span></div></div></div>";
                    }
                }
            }
        }
    }
}