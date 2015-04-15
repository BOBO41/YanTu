using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class Redircet : UI.WebPage
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
                var pid = Request.QueryString["pid"];
                var tiid = Request.QueryString["tiid"];
                if (!string.IsNullOrEmpty(tiid))
                {
                    var model = _tempInfoDal.GetModel(Convert.ToInt32(tiid));
                    if (null != model)
                    {
                        var template = _templatesDal.GetModel(Convert.ToInt32(model.TID));
                        if (null != template)
                        {
                            Response.Redirect(template.TLink + "?itid=" + model.ITID + "&tiid=" + tiid + "&spid=" + spid + "&pid=" + pid, true);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(pid) && !string.IsNullOrEmpty(itid) && !string.IsNullOrEmpty(spid))
                {
                    List<SqlParameter> parDef = new List<SqlParameter>();
                    parDef.Add(new SqlParameter("@ParentID", DbType.AnsiString) { Value = pid });
                    var timodel = _tempInfoDal.GetModel(" ParentID=@ParentID and TIPage=1 ", parDef);
                    if (null != timodel)
                    {
                        var template = _templatesDal.GetModel(Convert.ToInt32(timodel.TID));
                        if (null != template)
                        {
                            Response.Redirect(template.TLink + "?itid=" + timodel.ITID + "&tiid=" + timodel.TIID + "&spid=" + spid + "&pid=" + pid,
                                true);
                        }
                    }
                    
                    else
                    {
                        Response.Redirect("/Manage/Systems/CreateFirstNews.aspx" + "?page=1&spid=" + spid + "&itid=" + itid + "&pid=" + pid, true);
                    }
                }

                #endregion
            }
        }
    }

}