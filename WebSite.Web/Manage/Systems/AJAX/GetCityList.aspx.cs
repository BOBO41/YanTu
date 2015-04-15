using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class GetCityList : UI.WebPage
    {
        private readonly Admin.DAL.RootPackage _dataDal = new Admin.DAL.RootPackage();
        private readonly OrgPkgList _orgPkgListDal = new OrgPkgList();
        protected void Page_Load(object sender, EventArgs e)
        {
		VerifyPage("", false);
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["pId"]))
                {
                    var pModel = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["pId"]));
                    if (pModel != null)
                    {
                        var sql =
                            "select distinct(OrgPkgList.OrgId),OrgOrganize.OrgName from OrgPkgList join OrgOrganize on OrgOrganize.OrgId=OrgPkgList.OrgId and OrgPkgList.RPID=@RPID";
                        Database db = DatabaseFactory.CreateDatabase();
                        DbCommand dbCommand = db.GetSqlStringCommand(sql);

                        dbCommand.Parameters.Add(new SqlParameter("@RPID", DbType.AnsiString) { Value = Request.QueryString["pId"] });
                        var ds = db.ExecuteDataSet(dbCommand);
                        var str = string.Empty;
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            str = ds.Tables[0].Rows.Cast<DataRow>()
                                              .Aggregate(str,
                                                         (current, dr) =>
                                                         current + ("," + dr["OrgId"] + "|" + dr["OrgName"]));
                        }
                        Response.Write(str);
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("");
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception)
            {
                Response.Write("");
                Response.End();
            }
        }
    }
}
