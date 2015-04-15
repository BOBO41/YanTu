using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;
using WebSite.Lib.Security;
using OrgUsers = WebSite.Admin.Model.OrgUsers;

namespace WebSite.Web.Manage.Systems
{
    public partial class Default : UI.WebPage
    {
        private string _num = "4";
        public string GetMenuCount()
        {
            return _num;
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            SecurityMgr.Logoff();
            Response.Redirect("/login.aspx");
        }
        private readonly OrgEmployees _orgEmployeesDal = new OrgEmployees();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            litRoleTree.Text = GetRoleTree();
            if (CurrentUser != null)
            {
                Admin.Model.OrgEmployees orgEmpl = _orgEmployeesDal.GetModel(int.Parse(CurrentUser.EmplId.ToString()));
                litUserName.Text = orgEmpl.EmplName;
                var title = "";
                if (CurrentUser.Type == 1)
                {
                    title = "沿途后台总站管理系统";
                }
                else
                {
                    var emp = _orgEmployeesDal.GetModel(Convert.ToInt32(CurrentUser.EmplId));
                    var org = _orgOrganizeDal.GetModel(Convert.ToInt64(emp.OrgId));
                    title = "沿途后台 " + org.OrgName + "管理系统";
                }
                litTitle.Text = title;
            }
        }

        private string GetRoleTree()
        {
            try
            {
                StringBuilder sbr = new StringBuilder();
                if (Session["CurrentUser"] != null)
                {
                    OrgUsers dtUser = Session["CurrentUser"] as OrgUsers;
                    string sqlFather = @"SELECT * FROM SYS_PageConfig WHERE PC_Id IN(
SELECT PC_Id FROM SYS_RoleForPage WHERE Role_Id IN (SELECT Role_Id FROM SYS_UserForRole WHERE UId= " + dtUser.UId + @")) and PC_State=1 and PC_ParentId=0 ";
                    Database db = DatabaseFactory.CreateDatabase();
                    DataTable dt = db.ExecuteDataSet(CommandType.Text, sqlFather).Tables[0];
                    _num = dt.Rows.Count.ToString();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int mi = i + 1;
                        if (GetSongCount(mi, dt.Rows[i]["PC_ParentId"].ToString(), sbr, dtUser.UId.ToString()) == 0)
                            continue;
                        sbr.Append("<dl><dt><span>-</span>");
                        sbr.Append(dt.Rows[i]["PC_Name"]);
                        sbr.Append("</dt>");
                        //循环子菜单
                        GetSonMenu(mi, dt.Rows[i]["PC_Id"].ToString(), sbr, dtUser.UId.ToString());
                        sbr.Append("</dl>");
                    }
                }
                return sbr.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private int GetSongCount(int ii, string PARENTPAGENO, StringBuilder sbr, string userID)
        {
            string sqlSon = @"SELECT * FROM SYS_PageConfig WHERE PC_Id IN(
SELECT PC_Id FROM SYS_RoleForPage WHERE Role_Id IN (SELECT Role_Id FROM SYS_UserForRole WHERE UId= " + userID + @")) and PC_State=1 AND PC_ParentId = " + PARENTPAGENO;

            Database db = DatabaseFactory.CreateDatabase();
            DataTable dt = db.ExecuteDataSet(CommandType.Text, sqlSon).Tables[0];
            if (dt == null)
            {
                return 0;
            }
            else
                return dt.Rows.Count;
        }

        private void GetSonMenu(int ii, string PARENTPAGENO, StringBuilder sbr, string userID)
        {
            string sqlSon = @"SELECT * FROM SYS_PageConfig WHERE PC_Id IN(
SELECT PC_Id FROM SYS_RoleForPage WHERE Role_Id IN (SELECT Role_Id FROM SYS_UserForRole WHERE UId= " + userID + @")) and PC_State=1 AND PC_ParentId = " + PARENTPAGENO;

            Database db = DatabaseFactory.CreateDatabase();
            DataTable dt = db.ExecuteDataSet(CommandType.Text, sqlSon).Tables[0];
            if (dt != null && dt.Rows.Count != 0)
            {
                sbr.Append("<ul>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbr.Append("<li>");
                    sbr.Append("<a href=\"javascript:;\" title=\"" + dt.Rows[i]["PC_Name"] + "\"");
                    sbr.Append(" name=\"" + dt.Rows[i]["PC_HrefUrl"] + "\">" + dt.Rows[i]["PC_Name"]);



                    sbr.Append("</a>");
                    //GetSonMenu(ii, dt.Rows[i]["PC_Id"].ToString(), sbr, userID);
                    sbr.Append("</li>");
                }
                sbr.Append("</ul>");
            }
        }
        /// <summary>
        /// 库管员
        /// </summary>
        /// <returns></returns>
        public bool GetKG()
        {
            SYS_RoleInfo sysRoleDal = new SYS_RoleInfo();          //用户角色关系表

            bool resVisit = false;
            VerifyPage("", false);
            var user = Session["CurrentUser"] as OrgUsers;
            if (user != null)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sqlWhe = " Role_Id in (select Role_Id from dbo.SYS_RoleInfo where Role_Name like '%库管%' or Role_Name like '%物流经理%') and UID=@UID";
                var parameter = new SqlParameter("@UID", DbType.AnsiString);
                parameter.Value = user.UId;
                parameters.Add(parameter);
                DataSet dts = sysRoleDal.GetListAdmin(sqlWhe, parameters);
                if (dts != null)
                {
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        resVisit = true;
                    }
                }
            }
            return resVisit;
        }

    }
}