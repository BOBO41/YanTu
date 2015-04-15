using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;
using Infos = WebSite.Admin.Model.Infos;

namespace WebSite.Web.Manage.Systems.Ajax_TempInfo
{
    public partial class AddInfo : UI.WebPage
    {
        private readonly OrgEmployees _dataDal = new OrgEmployees();
        private readonly OrgUsers _dataDal1 = new OrgUsers();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        private readonly ALabel _aLabelDal = new ALabel();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                BindOrgName();
            }
        }

        private void BindOrgName()
        {
            var timodel = _tempInfoDal.GetModel(Convert.ToInt32(Request.QueryString["tiid"]));
            if (null != timodel)
            {
                var sql = "select Infos.IID,Infos.IName from Infos join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID where InfoType.SPID=@SPID";
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                dbCommand.Parameters.Add(new SqlParameter("@SPID", DbType.Int32) { Value = Request.QueryString["spid"] });
                var dt = db.ExecuteDataSet(dbCommand).Tables[0];
                ddlOrgName.DataSource = dt;
                ddlOrgName.DataTextField = "IName";
                ddlOrgName.DataValueField = "IID";
                ddlOrgName.DataBind();

                ddlOrgName.Items.Insert(0, new ListItem("无", ""));
                ddlOrgName.SelectedIndex = 0;
            }
        }


        //protected void btnSub_Click(object sender, EventArgs e)
        //{
        //    var name = txtName.Value.Trim();
        //    if (string.IsNullOrEmpty(name))
        //    {
        //        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写姓名！');</script>");
        //        return;
        //    }
        //    var orgid = "0";
        //    var type = Convert.ToInt32(Request.Form["rboSelectType"]);
        //    if (1 != type)
        //    {
        //        orgid = ddlOrgName.SelectedValue;
        //    }
        //    if (!string.IsNullOrEmpty(Request.QueryString["empId"]))
        //    {
        //        try
        //        {
        //            var model = _dataDal.GetModel(Convert.ToInt32(Request.QueryString["empId"]));
        //            if (model == null)
        //            {
        //                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('人员不存在！');</script>");
        //                return;
        //            }
        //            model.EmplName = name;
        //            model.Birthday = DateTime.Now;
        //            model.HomeAddress = "";
        //            model.Phone = cell;
        //            model.Sex = sex;
        //            var res = _dataDal.UpdateEmpUser(orgid, Request.QueryString["empId"], name, sex, DateTime.Now.ToString(), "", cell, userName, pwd, type, "");
        //            if (res == "1")
        //            {
        //                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
        //                //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
        //            }
        //            else
        //            {
        //                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户名已存在！');</script>");
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
        //        }
        //    }
        //    else
        //    {
        //        //if (!string.IsNullOrEmpty(Request.QueryString["aId"]))
        //        //{
        //        var model = new Admin.Model.OrgEmployees
        //        {
        //            Addtime = DateTime.Now,
        //            Birthday = Convert.ToDateTime(DateTime.Now),
        //            EmplName = name,
        //            HomeAddress = "",
        //            OrgId = Convert.ToInt64(Request.QueryString["oId"]),
        //            Sex = sex,
        //            Phone = cell,
        //            Status = 1
        //        };

        //        var resAdd = _dataDal.AddEmpUserType(orgid, name, sex, DateTime.Now.ToString(), "", cell, userName, pwd, type);
        //        if (resAdd > 0)
        //        {
        //            Page.ClientScript.RegisterStartupScript(GetType(), "",
        //                "<script>window.top.$op.location=window.top.$op.location;window.top.$modal.destroy();</script>");
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('用户名已存在！');</script>");
        //        }
        //        //}
        //        //else
        //        //{
        //        //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
        //        //}
        //    }
        //}
        protected DataSet GetLabel()
        {
            List<SqlParameter> parDef1 = new List<SqlParameter>();
            return _aLabelDal.GetList(" Status=1 ", parDef1);
        }


        protected void SchemaSeri(AttaList _attaListDal, Infos infomodel, string adpause)
        {
            StringBuilder strSqlAddLab = new StringBuilder();
            strSqlAddLab.Append("insert into InfoLabel(");
            strSqlAddLab.Append("IID,ALID)");

            strSqlAddLab.Append(" values (");
            strSqlAddLab.Append("@IID,@ALID)");
        }
    }

}