using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebSite.Admin.DAL;
using WebSite.Lib;

namespace WebSite.Web.Manage.Systems
{
    public partial class ChooseAdTemplate : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Templates _templatesDal = new Templates();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                BindData();
                var spid = Request.QueryString["spid"];
                if (!string.IsNullOrEmpty(spid))
                {

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

        private void BindData()
        {
            List<SqlParameter> pars1 = new List<SqlParameter>();
            var dt = _templatesDal.GetList(" Status=1 and TType=3 ", pars1).Tables[0];
            rptList.DataSource = dt;
            rptList.DataBind();
        }
    }

}