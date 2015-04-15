using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class RedircetAD : UI.WebPage
    {
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Templates _templatesDal = new Templates();
        private readonly Infos _infosDal = new Infos();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                #region

                var itid = Request.QueryString["itid"];
                var spid = Request.QueryString["spid"];
                var tiid = Request.QueryString["tiid"];
                if (!string.IsNullOrEmpty(tiid) && !string.IsNullOrEmpty(itid) && !string.IsNullOrEmpty(spid))
                {
                    var timodel = _tempInfoDal.GetModel(Convert.ToInt32(tiid));
                    if (null != timodel)
                    {
                        List<SqlParameter> parDef = new List<SqlParameter>();
                        parDef.Add(new SqlParameter("@ParentID", DbType.AnsiString) { Value = timodel.ParentID });
                        var admodel = _tempInfoDal.GetModel(" ParentID=@ParentID and TIPage is NULL and(TID=17 or TID=18)", parDef);
                        if (null != admodel)
                        {
                            var template = _templatesDal.GetModel(Convert.ToInt32(admodel.TID));
                            if (null != template)
                            {
                                Response.Redirect(
                                    template.TLink + "?ptiid=" + timodel.TIID + "&itid=" + admodel.ITID + "&tiid=" +
                                    admodel.TIID + "&spid=" + spid + "&pid=" +
                                timodel.ParentID,
                                    true);
                            }
                        }
                        else
                        {
                            Response.Redirect("/Manage/Systems/CreateFirstAd.aspx" + "?ptiid=" + timodel.TIID + "&spid=" + spid + "&itid=" + itid + "&pid=" +
                                timodel.ParentID, true);
                        }

                    }
                }

                #endregion
            }
        }
    }

}