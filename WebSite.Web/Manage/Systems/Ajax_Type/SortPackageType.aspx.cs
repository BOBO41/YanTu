using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_Type
{
    public partial class SortPackageType : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                var itid = Request.QueryString["itid"];
                if (!string.IsNullOrEmpty(itid))
                {
                    var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                    var type = Request.QueryString["type"];
                    if ("up" == type)
                    {
                        List<SqlParameter> pars1 = new List<SqlParameter>();
                        var preModel =
                            _infoTypeDal.GetModel(" SortNum=" + (itmodel.SortNum - 1) + " and SPID=" + itmodel.SPID, pars1);
                        if (null != preModel)
                        {
                            itmodel.SortNum = itmodel.SortNum - 1;
                            preModel.SortNum = preModel.SortNum + 1;
                            _infoTypeDal.Update(itmodel);
                            _infoTypeDal.Update(preModel);
                        }
                    }
                    if ("down" == type)
                    {
                        List<SqlParameter> pars1 = new List<SqlParameter>();
                        var nexModel =
                            _infoTypeDal.GetModel(" SortNum=" + (itmodel.SortNum + 1) + " and SPID=" + itmodel.SPID, pars1);
                        if (null != nexModel)
                        {
                            itmodel.SortNum = itmodel.SortNum + 1;
                            nexModel.SortNum = nexModel.SortNum - 1;
                            _infoTypeDal.Update(itmodel);
                            _infoTypeDal.Update(nexModel);
                        }
                    }
                    Response.Write("0|~|" + itid);
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ee)
            {
                Response.Write("1|~|" + ee.Message);
                Response.End();
            }
        }
    }
}