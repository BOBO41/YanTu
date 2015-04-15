using System;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class UserRole : UI.WebPage
    {
        SYS_UserForRole mUfr = new SYS_UserForRole();
        SYS_RoleInfo mCusRole = new SYS_RoleInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindRoleList();
                GetNormal();
            }

        }

        private void GetNormal()
        {
            BindLeftList();
            BindRightList();

            //SetButtonEnable();
        }
        public static void ListBox_AppendItem(ListBox lstBox, DataTable dt, string textFieldName, string valueFieldName)
        {
            string strText;
            string strValue;
            foreach (DataRow dr in dt.Rows)
            {
                strText = dr[textFieldName].ToString();
                strValue = dr[valueFieldName].ToString();
                ListItem item = new ListItem(strText, strValue);
                lstBox.Items.Add(item);
            }
        }
        public static void DropDownList_AppendItem(DropDownList ddlist, DataTable dt, string textFieldName, string valueFieldName)
        {
            string strText;
            string strValue;
            foreach (DataRow dr in dt.Rows)
            {
                strText = dr[textFieldName].ToString();
                strValue = dr[valueFieldName].ToString();
                ListItem item = new ListItem(strText, strValue);
                ddlist.Items.Add(item);
            }
        }

        private void SetButtonEnable()
        {
            int countLeft = lstBoxLeft.Items.Count;
            int countRight = lstBoxRight.Items.Count;
            if (countLeft == 0)
            {
                lbtnToRight_All.Enabled = false;
            }
            else
            {
                if (lstBoxLeft.SelectedValue == "")
                {
                    //lbtnToRight_one.Enabled = false;
                }
            }
            if (countRight == 0)
            {
                lbtnToLeft_All.Enabled = false;
            }
            else
            {
                if (lstBoxRight.SelectedValue == "")
                {
                    //lbtnToLeft_one.Enabled = false;
                }
            }
        }

        private void BindRightList()
        {
            string sql = @"
select row_number() over(order by  OrgEmployees.Addtime desc,OrgEmployees.EmplId DESC) as rownum,OrgEmployees.*,OrgOrganize.OrgName,OrgUsers.UId FROM OrgEmployees join OrgOrganize on OrgOrganize.OrgId=OrgEmployees.OrgId join OrgUsers on OrgUsers.EmplId=OrgEmployees.EmplId where OrgEmployees.Status=1 and OrgOrganize.OrgType=" + DropDownList1.SelectedValue + " and  OrgUsers.UId in(select UId FROM SYS_UserForRole where Role_Id=" + ddlRole.SelectedValue + " )";
            Database db = DatabaseFactory.CreateDatabase();

            var dt = db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
            lstBoxRight.Items.Clear();
            ListBox_AppendItem(lstBoxRight, dt, "EmplName", "UId");
        }

        private void BindLeftList()
        {

            string sql = @"
select row_number() over(order by  OrgEmployees.Addtime desc,OrgEmployees.EmplId DESC) as rownum,OrgEmployees.*,OrgOrganize.OrgName,OrgUsers.UId FROM OrgEmployees join OrgOrganize on OrgOrganize.OrgId=OrgEmployees.OrgId join OrgUsers on OrgUsers.EmplId=OrgEmployees.EmplId where OrgEmployees.Status=1 and OrgOrganize.OrgType=" + DropDownList1.SelectedValue + " and  OrgUsers.UId not in(select UId FROM SYS_UserForRole where Role_Id=" + ddlRole.SelectedValue + " )";
            Database db = DatabaseFactory.CreateDatabase();

            var dt = db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
            lstBoxLeft.Items.Clear();
            ListBox_AppendItem(lstBoxLeft, dt, "EmplName", "UId");
        }

        private void BindRoleList()
        {
            DataTable dt = mCusRole.GetList("").Tables[0];
            DropDownList_AppendItem(ddlRole, dt, "Role_Name", "Role_Id");

        }

        protected void lbtnToRight_All_Click(object sender, EventArgs e)
        {
            ListItem lit = null;
            for (int i = 0; i < lstBoxLeft.Items.Count; i++)
            {
                lit = lstBoxLeft.Items[i];
                string UserID = lit.Value;
                string RoleID = ddlRole.SelectedValue;
                if (UserID != "" && RoleID != "")
                {
                    Admin.Model.SYS_UserForRole model = new Admin.Model.SYS_UserForRole
                    {
                        Role_Id = Convert.ToInt32(RoleID),
                        Adn_Id = Convert.ToInt32(UserID)
                    };
                    mUfr.Add(model);
                }
            }
            GetNormal();
        }

        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetNormal();
        }

        protected void lbtnToLeft_All_Click(object sender, EventArgs e)
        {
            ListItem lit = null;
            for (int i = 0; i < lstBoxRight.Items.Count; i++)
            {
                lit = lstBoxRight.Items[i];
                string UserID = lit.Value;
                string RoleID = ddlRole.SelectedValue;
                if (UserID != "" && RoleID != "")
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("delete from SYS_UserForRole ");
                    strSql.Append(" where Role_Id=@Role_Id and UId=@Adn_Id ");
                    Database db = DatabaseFactory.CreateDatabase();
                    DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                    db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, RoleID);
                    db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, UserID);
                    db.ExecuteNonQuery(dbCommand);
                }
            }
            GetNormal();

        }

        protected void lbtnToLeft_one_Click(object sender, EventArgs e)
        {
            string UserID = lstBoxRight.SelectedValue;
            string RoleID = ddlRole.SelectedValue;
            if (UserID != "" && RoleID != "")
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from SYS_UserForRole ");
                strSql.Append(" where Role_Id=@Role_Id and UId=@Adn_Id ");
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
                db.AddInParameter(dbCommand, "Role_Id", DbType.Int32, RoleID);
                db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, UserID);
                db.ExecuteNonQuery(dbCommand);
            }
            GetNormal();
        }

        protected void lbtnToRight_one_Click(object sender, EventArgs e)
        {
            string UserID = lstBoxLeft.SelectedValue;
            string RoleID = ddlRole.SelectedValue;
            if (UserID != "" && RoleID != "")
            {
                Admin.Model.SYS_UserForRole model = new Admin.Model.SYS_UserForRole
                {
                    Role_Id = Convert.ToInt32(RoleID),
                    Adn_Id = Convert.ToInt32(UserID)
                };
                mUfr.Add(model);
            }
            GetNormal();

        }
    }

}