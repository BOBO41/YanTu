using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class CreateStaPackage : System.Web.UI.Page
    {
        private readonly Admin.DAL.StaPackage _staPackageDal = new Admin.DAL.StaPackage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["orgid"]) && !string.IsNullOrEmpty(Request.QueryString["rpid"]))
                {
                    var orgid = Request.QueryString["orgid"];
                    var rpid = Request.QueryString["rpid"];
                    List<SqlParameter> pars3 = new List<SqlParameter>();
                    pars3.Add(new SqlParameter("@RPID", DbType.AnsiString) { Value = rpid });
                    pars3.Add(new SqlParameter("@OrgId", DbType.AnsiString) { Value = orgid });
                    var model = _staPackageDal.GetModel(" RPID=@RPID and PkgType=0 and OrgId=@OrgId ", pars3);
                    if (null != model)
                    {
                        Response.Write("0");
                        Response.End();
                    }
                    else
                    {
                        var nmodel = new Admin.Model.StaPackage
                        {
                            CreateDate = DateTime.Now,
                            OrgId = Convert.ToInt32(orgid),
                            RPID = Convert.ToInt32(rpid),
                            Status = 0,
                            SPPath = Guid.NewGuid().ToString(),
                            PkgType = 0
                        };
                        var spid = _staPackageDal.Add(nmodel);
                        if (spid > 0)
                        {
                            Response.Write(spid);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("0");
                            Response.End();
                        }
                    }

                }
                else
                {
                    Response.Write("0");
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception)
            {
                Response.Write("0");
                Response.End();
            }

        }

    }

}