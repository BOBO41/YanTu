using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.News
{
    public partial class SelInfo : UI.WebPage
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
                var sql = "select Infos.* from Infos join TempInfo on Infos.TIID=TempInfo.TIID join Templates on TempInfo.TID=Templates.TID where Templates.TID=@TID and Infos.SortNum=@SortNum and TempInfo.TIID!=@TIID";
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                dbCommand.Parameters.Add(new SqlParameter("@TID", DbType.Int32) { Value = timodel.TID });
                dbCommand.Parameters.Add(new SqlParameter("@SortNum", DbType.Int32) { Value = Request.QueryString["sortnum"] });
                dbCommand.Parameters.Add(new SqlParameter("@TIID", DbType.Int32) { Value = Request.QueryString["tiid"] });
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