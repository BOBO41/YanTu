using System;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_Type
{
    public partial class AddPackageType : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var itid = Request.QueryString["itid"];
                if (!string.IsNullOrEmpty(itid))
                {
                    var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                    if (null != itmodel)
                    {
                        txtName.Value = itmodel.IName;
                        
                        //litPic.Text =
                        //    "<div class=\"upatta\" title=\"\" data-file=\"" + itmodel.AttaID + "\"><div class=\"upsigin\"><div class=\"at-file\"><img width=\"100\" height=\"100\" id=\"at-img\" src=\"/UploadFiles/" + itmodel.AttaID + "\"><span class=\"at-name\">" + itmodel.AttaID.Substring(36) + "</span></div></div></div>";
                    }
                }
            }
        }
    }
}