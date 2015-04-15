using System;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_Type
{
    public partial class EditPackageType : UI.WebPage
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
                        if (!string.IsNullOrEmpty(itmodel.AttaID))
                        {
                            //litPic.Text =
                            //"<div class=\"upatta\" title=\"\" data-file=\"" + itmodel.AttaID + "\"><div class=\"upsigin\"><div class=\"at-file\"><img width=\"100\" height=\"100\" id=\"at-img\" src=\"/UploadFiles/" + itmodel.AttaID + "\"><span class=\"at-name\">" + itmodel.AttaID.Substring(36) + "</span></div></div></div>";
                        }
                        var str = "";
                        for (int i = 1; i < 10; i++)
                        {
                            str +=
                                "<li><div class=\"upsigin\"><div><img src=\"/UploadFiles/classification" + i + ".png\"></div><span><input id=\"Radio1\" type=\"radio\" value=\"classification" + i + ".png\"";
                            var img = "classification" + i + ".png";
                            if (itmodel.AttaID == img)
                            {
                                str += "checked=\"checked\"";
                            }
                            str += " name=\"radclass\"></span></div></li>";
                        }
                        litPic.Text = str;
                    }
                }
            }
        }
    }

}