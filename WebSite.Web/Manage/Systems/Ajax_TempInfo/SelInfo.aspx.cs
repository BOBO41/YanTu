using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.Ajax_TempInfo
{
    public partial class SelInfo : UI.WebPage
    {
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly Admin.DAL.StaPackage _staPackageDal = new Admin.DAL.StaPackage();
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                try
                {
                    BindOrgName();
                }
                catch (Exception ee)
                {
                    throw;
                }

            }
        }

        private void BindOrgName()
        {
            var timodel = _tempInfoDal.GetModel(Convert.ToInt32(Request.QueryString["tiid"]));
            if (null != timodel)
            {
                //var sql = "select Infos.* from Infos where TIID in (select TIID from TempInfo where (ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId where (OrgName='全国热点' or OrgOrganize.OrgId=(select OrgId from StaPackage join InfoType on InfoType.SPID=StaPackage.SPID where InfoType.ITID=@ITID)) ))) and TIID!=@TIID and TID=@TID) and Infos.SortNum=@SortNum ";
                //var sql = "select Infos.* from Infos where TIID in (select TIID from TempInfo where (ITID in(select ITID from InfoType where SPID in(select SPID from StaPackage join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId where (OrgOrganize.OrgId=(select OrgId from StaPackage join InfoType on InfoType.SPID=StaPackage.SPID where InfoType.ITID=@ITID)) ))) and TIID!=@TIID and TID=@TID) and Infos.SortNum=@SortNum ";

                var sql = @"select Infos.IID,RootPackage.RPName+'-'+
(case StaPackage.PkgType when 0 then '默认资源包' else 
(select OrgOrganize.OrgName from OrgPkgList join OrgOrganize on OrgOrganize.OrgId=OrgPkgList.OrgId 
and OrgPkgList.SPID=StaPackage.SPID) end)+'-'+Infos.IName  AS IName
 from Infos join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID
join StaPackage on StaPackage.SPID=InfoType.SPID join RootPackage
 on RootPackage.RPID=StaPackage.RPID join OrgOrganize on
 OrgOrganize.OrgId=StaPackage.OrgId where  StaPackage.OrgId=(select OrgId from StaPackage join InfoType on InfoType.SPID=StaPackage.SPID where InfoType.ITID=@ITID)
and TempInfo.TIID!=@TIID and TempInfo.TID=@TID and Infos.SortNum=@SortNum and (StaPackage.SPID in (select SPID from OrgPkgList) or StaPackage.SPID=@SPID) ";

                var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(timodel.ITID));
                if (null != itmodel)
                {
                    var smodel = _staPackageDal.GetModel(Convert.ToInt32(itmodel.SPID));
                    if (null != smodel)
                    {
                        var org = _orgOrganizeDal.GetModel(Convert.ToInt64(smodel.OrgId));
                        if ("全国热点" == org.OrgName)
                        {
                            //sql = "select Infos.IID,(Infos.IName +'-'+ OrgOrganize.OrgName) as IName from Infos join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID join StaPackage on StaPackage.SPID=InfoType.SPID join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId where OrgOrganize.OrgId in (select OrgId from OrgOrganize where OrgType=1 and OrgId!='" + smodel.OrgId + "') and TempInfo.TIID!=@TIID and TID=@TID and Infos.SortNum=@SortNum";
                            sql = @"select Infos.IID,RootPackage.RPName+'-'+
(case StaPackage.PkgType when 0 then '默认资源包' else 
(select OrgOrganize.OrgName from OrgPkgList join OrgOrganize on OrgOrganize.OrgId=OrgPkgList.OrgId 
and OrgPkgList.SPID=StaPackage.SPID) end)+'-'+Infos.IName  AS IName
 from Infos join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID
join StaPackage on StaPackage.SPID=InfoType.SPID join RootPackage
 on RootPackage.RPID=StaPackage.RPID join OrgOrganize on
 OrgOrganize.OrgId=StaPackage.OrgId where  StaPackage.OrgId in (select OrgId from OrgOrganize where OrgType=1 and ";
                            sql += "OrgId!='" + smodel.OrgId + "') and TempInfo.TIID!=@TIID and TempInfo.TID=@TID and Infos.SortNum=@SortNum and (StaPackage.SPID in (select SPID from OrgPkgList) or StaPackage.SPID=@SPID or StaPackage.SPID in (select StaPackage.SPID from StaPackage join RootPackage on RootPackage.RPID=StaPackage.RPID where StaPackage.PkgType=0 and RootPackage.RPID=(select RootPackage.RPID from RootPackage join StaPackage on RootPackage.RPID=StaPackage.RPID join InfoType on InfoType.SPID=StaPackage.SPID join TempInfo on InfoType.ITID=TempInfo.ITID where TempInfo.TIID=@TIID) )) ";
                        }
                    }
                }
                sql += " order by Infos.IID desc ";
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                dbCommand.Parameters.Add(new SqlParameter("@TID", DbType.Int32) { Value = timodel.TID });
                dbCommand.Parameters.Add(new SqlParameter("@SortNum", DbType.Int32) { Value = Request.QueryString["sortnum"] });
                dbCommand.Parameters.Add(new SqlParameter("@TIID", DbType.Int32) { Value = timodel.TIID });
                dbCommand.Parameters.Add(new SqlParameter("@ITID", DbType.Int32) { Value = timodel.ITID });
                if (null != itmodel)
                {
                    dbCommand.Parameters.Add(new SqlParameter("@SPID", DbType.Int32) { Value = itmodel.SPID });
                }
                else
                {
                    dbCommand.Parameters.Add(new SqlParameter("@SPID", DbType.Int32) { Value = "" });
                }
                var dt = db.ExecuteDataSet(dbCommand).Tables[0];
                ddlOrgName.DataSource = dt;
                ddlOrgName.DataTextField = "IName";
                ddlOrgName.DataValueField = "IID";
                ddlOrgName.DataBind();

                ddlOrgName.Items.Insert(0, new ListItem("请选择", "-1"));
                ddlOrgName.SelectedIndex = 0;
            }
        }

    }

}