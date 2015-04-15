using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_TempInfo
{
    public partial class AddTempInfo : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            var itid = Request.QueryString["itid"];
            if (!string.IsNullOrEmpty(itid))
            {
                try
                {
                    var pid = string.IsNullOrEmpty(Request.QueryString["pid"]) ? 0 : Convert.ToInt32(Request.QueryString["pid"]);
                    //var page=string.IsNullOrEmpty(Request.QueryString["page"])?1:Convert.ToInt32(Request.QueryString["page"]);
                    var model = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                    if (null != model)
                    {
                        var timodel = new Admin.Model.TempInfo
                        {
                            ITID = model.ITID,
                            ParentID = pid,
                            TID = Convert.ToInt32(Request.QueryString["tid"])
                        };
                        var sql = " ITID='" + model.ITID + "' and ParentID='" + pid + "' ";
                        if (!string.IsNullOrEmpty(Request.QueryString["page"]))
                        {
                            timodel.TIPage = Convert.ToInt32(Request.QueryString["page"]);
                            sql += " and TIPage='" + timodel.TIPage + "' ";
                        }
                        else
                        {
                            sql += " and (TIPage is null or TIPage='') ";
                        }
                        var exit = _tempInfoDal.GetModel(sql, new List<SqlParameter>());
                        if (null != exit)
                        {
                            Response.Write("1|~|无法重复创建页面模板,请刷新后重试");
                            Response.End();
                        }
                        var tiid = _tempInfoDal.Add(timodel);
                        if (tiid > 0)
                        {
                            Response.Write("0|~|" + tiid);
                            Response.End();
                        }
                        else
                        {
                            Response.Write("1|~|操作失败");
                            Response.End();
                        }
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
}