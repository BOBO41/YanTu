using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class PkgManage : System.Web.UI.Page
    {
        private readonly Admin.DAL.StaPackage _staPackageDal = new Admin.DAL.StaPackage();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        private readonly OrgPkgList _orgPkgListDal = new OrgPkgList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                #region 分站完稿

                if (!string.IsNullOrEmpty(Request.QueryString["fspid"]))
                {
                    var spid = Request.QueryString["fspid"];
                    var model = _staPackageDal.GetModel(Convert.ToInt32(spid));
                    if (null != model)
                    {
                        model.Status = 1;
                        _staPackageDal.Update(model);
                        List<SqlParameter> pars3 = new List<SqlParameter>();
                        pars3.Add(new SqlParameter("@SPID", DbType.Int32)
                        {
                            Value = spid
                        });
                        var opl = _orgPkgListDal.GetModel(" SPID=@SPID and Status=2 ", pars3);
                        if (null != opl)
                        {
                            opl.Status = 0;
                            _orgPkgListDal.Update(opl);
                        }
                        Response.Write("1");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("0");
                        Response.End();
                    }
                }

                #endregion


                #region 管理员送审

                if (!string.IsNullOrEmpty(Request.QueryString["spids"]) && !string.IsNullOrEmpty(Request.QueryString["rpid"]))
                {
                    List<SqlParameter> pars3 = new List<SqlParameter>();
                    var orglist = _orgOrganizeDal.GetList(" OrgType=2 and Status=1", pars3).Tables[0];
                    var spid = Request.QueryString["spids"].Split(',');
                    var rpid = Request.QueryString["rpid"];
                    var str = "";
                    if (orglist.Rows.Count > 0)
                    {
                        for (int i = 0; i < orglist.Rows.Count; i++)
                        {
                            foreach (var obj in spid)
                            {
                                if (!string.IsNullOrEmpty(obj))
                                {
                                    str += "insert into OrgPkgList(SPID,OrgId,OSPID,Status,CreateDate,RPID) values ('" + obj + "','" + orglist.Rows[i]["OrgId"] + "',0,0,'" + DateTime.Now + "','" + rpid + "');update StaPackage set Status=2  where SPID='" + obj + "';";
                                }
                            }
                        }
                        str += "update RootPackage set Status=1 where RPID=" + rpid + ";";
                    }
                    if (str != "")
                    {
                        Database db = DatabaseFactory.CreateDatabase();
                        DbCommand dbCommand = db.GetSqlStringCommand(str);
                        db.ExecuteNonQuery(dbCommand);
                    }
                    Response.Write("1");
                    Response.End();
                }

                #endregion


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