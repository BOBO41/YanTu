using System;
using WebSite.CM.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.CM
{
    public partial class Point : WebPage
    {
        protected string RxValue = "";
        protected string RyValue = "";
        protected int RID;
        PointRule rDAL = new PointRule();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            var rModel = rDAL.GetModel(1);
            RID = 1;
            RxValue = rModel.RxValue;
            RyValue = rModel.RyValue;
        }
    }
}