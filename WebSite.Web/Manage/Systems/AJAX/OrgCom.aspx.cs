using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class OrgCom : System.Web.UI.Page
    {
        OrgOrganize orgOrgDal = new OrgOrganize();
        OrgArea orgAreaDal = new OrgArea();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["ProvinceId"]))
                    {
                        string provinceId = Request.QueryString["ProvinceId"];
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        DataTable dts = orgAreaDal.GetList(" ParentId=" + provinceId + " and [Status]=1 ", parameters).Tables[0];
                        var areaName = string.Empty;
                        if (dts.Rows.Count > 0)
                        {
                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                areaName += "," + dts.Rows[i]["AreaId"] + "|";
                                areaName += dts.Rows[i]["AreaName"] + " ";
                            }
                        }
                        Response.Write(areaName);
                        Response.End();
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["CityId"]))
                    {
                        string cityId = Request.QueryString["CityId"];
                        List<SqlParameter> parameters = new List<SqlParameter>();
                        DataTable dts = orgAreaDal.GetList(" ParentId=" + cityId + " and [Status]=1 ", parameters).Tables[0];
                        var areaName = string.Empty;
                        if (dts.Rows.Count > 0)
                        {
                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                areaName += "," + dts.Rows[i]["AreaId"] + "|";
                                areaName += dts.Rows[i]["AreaName"] + " ";
                            }
                        }
                        Response.Write(areaName);
                        Response.End();
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["OrgId"]))
                    {
                        Response.Write(orgOrgDal.DelOrgWorStaTran(Request.QueryString["OrgId"]) ? "删除成功" : "删除失败");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("删除失败");
                        Response.End();
                    }

                }
                catch (System.Threading.ThreadAbortException ex)
                {
                }
                catch (Exception)
                {
                    Response.Write("删除失败");
                    Response.End();
                }
            }
        }
    }
}
