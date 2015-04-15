using System;
using WebSite.Admin.DAL;
using WebSite.Lib;

namespace WebSite.Web.Manage.Systems
{
    public partial class CreateFirstNews : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Admin.DAL.StaPackage _staPackageDal = new Admin.DAL.StaPackage();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        readonly Infos _infosDal = new Infos();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                var spid = Request.QueryString["spid"];
                if (!string.IsNullOrEmpty(spid))
                {
                    #region 导航

                    var pid = Request.QueryString["pid"];
                    if ("0" != pid && !string.IsNullOrEmpty(pid))
                    {
                        var imodel = _infosDal.GetModel(Convert.ToInt32(pid));
                        if (null != imodel)
                        {
                            litStaName.Text = "<div class=\"backup\"><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "&itid=" + Request.QueryString["itid"] +
                                                      "\" class=\"back_btn backfirst\">返回首页</a><a href=\"/Manage/Template/Redircet.aspx?spid=" + spid +
                                              "&tiid=" + imodel.TIID + "&itid=" + Request.QueryString["itid"] +
                                              "\" class=\"back_btn\">返回上级</a> </div>";
                        }
                    }
                    else
                    {
                        #region 分站名称

                        var spmodel = _staPackageDal.GetModel(Convert.ToInt32(spid));
                        if (null != spmodel)
                        {
                            var orgmodel = _orgOrganizeDal.GetModel(Convert.ToInt64(spmodel.OrgId));
                            if (null != orgmodel)
                            {
                                litStaName.Text =
                                    "<div class=\"logo\"><img src=\"/images/LOGO-yt.png\" style=\"display: block; width: 50px; height: 50px;\" alt=\"沿途\" /></div><div class=\"title\"><strong>" +
                                    orgmodel.OrgName + "</strong><span>" + orgmodel.EnName + "</span></div>";
                            }
                        }

                        #endregion
                    }

                    #endregion

                    var itid = Request.QueryString["itid"];//分类id
                    if (!string.IsNullOrEmpty(itid))
                    {
                        var model = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                        if (null != model)
                        {

                            litType.Text = Service.GetType(Convert.ToInt32(model.ITID), spid);
                        }
                    }
                    else
                    {
                        litType.Text = Service.GetType(0, spid);
                    }
                }
            }
        }
    }
}