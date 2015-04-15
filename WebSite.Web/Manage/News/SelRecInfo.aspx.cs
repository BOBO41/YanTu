using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class SelRecInfo : UI.WebPage
    {
        private readonly TempInfo _tempInfoDal = new TempInfo();
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
                //var sql = "select Infos.* from Infos where IID in(select IID from InfoLabel where ALID in(select ALID from InfoLabel where IID=@IID)) and IID not in (select Inf_IID from AdInfos where IID=@OIID) ";
                var sql =
                    "select distinct(Infos.IID),Infos.IName from Infos join InfoLabel on InfoLabel.IID=Infos.IID and InfoLabel.ALID in(select ALID from InfoLabel where IID=@IID) and Infos.IID not in (select Inf_IID from AdInfos where IID=@OIID) join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID where InfoType.SPID in(select InfoType.SPID from InfoType join TempInfo on TempInfo.ITID=InfoType.ITID and TempInfo.TIID=@TIID)";
                sql += " order by Infos.IID desc ";
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                //dbCommand.Parameters.Add(new SqlParameter("@TID", DbType.Int32) { Value = timodel.TID });
                //dbCommand.Parameters.Add(new SqlParameter("@SortNum", DbType.Int32) { Value = Request.QueryString["sortnum"] });
                dbCommand.Parameters.Add(new SqlParameter("@IID", DbType.Int32) { Value = timodel.ParentID });
                dbCommand.Parameters.Add(new SqlParameter("@OIID", DbType.Int32) { Value = Request.QueryString["iid"] });
                dbCommand.Parameters.Add(new SqlParameter("@TIID", DbType.Int32) { Value = timodel.TIID });
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