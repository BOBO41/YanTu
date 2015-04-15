using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;
using WebSite.DBUtilities;
using WebSite.Web.UI;
using FactroyInfo = WebSite.Admin.Model.FactroyInfo;
using SYS_AdminUser = WebSite.Admin.Model.SYS_AdminUser;

namespace WebSite.Web.Manage.Systems
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public partial class SystemRoleInfo : WebPage
    {
        protected int PageStart = 0;
        public int PageSize = 15;
        private int _pageCount;
        SYS_RoleInfo mRole = new SYS_RoleInfo();
        SYS_RoleForPage mRfg = new SYS_RoleForPage();
        SYS_UserForRole mUfr = new SYS_UserForRole();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                DBindMyRole("");

            }
        }
        #region  角色管理页面方法
        /// <summary>
        /// 绑定角色信息
        /// </summary>
        private void DBindMyRole(string rName)
        {
            #region 分页
            string sqlWhere = "";
            int pageNum = 1;
            if(!string.IsNullOrEmpty(Request.QueryString["RName"])){
                rName = Request.QueryString["RName"];
            }
            if (!string.IsNullOrEmpty(rName))
            {
                sqlWhere = "  Role_Name like '%" + rName.Trim() + "%'";
            }

            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Page"]))             //页数判断
                {
                    pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                }
            }
            catch (Exception)
            {
                pageNum = 1;
            }
            string sql = mRole.GetListRoleInfo(rName);
            //分页方法
            Pager1.GetDataBind("Repeater", "RepeaterMyRole", sql, pageNum, 10, "", "rownum", "SystemRoleInfo.aspx?id=" + Request.QueryString["id"] +"&RName="+rName+"&");

            #endregion
        }

        /// <summary>
        /// 搜索方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchRole_Click(object sender, EventArgs e)
        {
            string rName = txtRoleName.Value;
            //string status = ddlStatus.SelectedValue;
            DBindMyRole(rName);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelRole_Click(object sender, EventArgs e)
        {
            string rName = txtRoleName.Value;
            //string status = ddlStatus.SelectedValue;
            int i = 0;
            bool b = false;
            foreach (RepeaterItem item in RepeaterMyRole.Items)
            {

                CheckBox cb = (CheckBox)item.FindControl("cbSalesRole");
                if (cb == null || !cb.Checked) continue;
                var litId = cb.ToolTip;
                if (litId != null)
                {
                    i++;
                    DataSet ds = mRfg.GetList(" Role_Id=" + int.Parse(litId));
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    DataRow[] drs = dt.Select();
                    foreach (DataRow dr in drs)
                    {
                        mRfg.Delete(int.Parse(dr["RFP_Id"].ToString()));
                    }
                    DataSet dsUser = mUfr.GetList(" Role_Id=" + int.Parse(litId));
                    DataTable dtUser = new DataTable();
                    dtUser = dsUser.Tables[0];
                    DataRow[] drsUser = dtUser.Select();
                    foreach (DataRow drUser in drsUser)
                    {
                        mUfr.Delete(int.Parse(drUser["UFR_Id"].ToString()));
                    }
                    b = mRole.Delete(int.Parse(litId.ToString()));
                }
            }
            if (i == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
            }
            if (b)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除不成功！');</script>");
            }

            DBindMyRole(rName);
        }
        /// <summary>
        /// 删除角色信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteRole_Click(object sender, CommandEventArgs e)
        {
            string rName = txtRoleName.Value;
            //string status = ddlStatus.SelectedValue;
            int role_Id = int.Parse(e.CommandName);//得到需要删除的记录的编号（Id）
            DataSet ds = mRfg.GetList(" Role_Id=" + role_Id);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataRow[] drs = dt.Select();
            foreach (DataRow dr in drs)
            {
                mRfg.Delete(int.Parse(dr["RFP_Id"].ToString()));
            }
            DataSet dsUser = mUfr.GetList(" Role_Id=" + role_Id);
            DataTable dtUser = new DataTable();
            dtUser = dsUser.Tables[0];
            DataRow[] drsUser = dtUser.Select();
            foreach (DataRow drUser in drsUser)
            {
                mUfr.Delete(int.Parse(drUser["UFR_Id"].ToString()));
            }
            bool res = mRole.Delete(role_Id);
            if (res)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            }

            DBindMyRole(rName);
        }
        #endregion

        /// <summary>
        /// 获取访问节点
        /// </summary>
        /// <returns></returns>
        public DataTable GetUrl()
        {
            VerifyPage("", false);
            var user = Session["CurrentUser"] as SYS_AdminUser;
            var facUser = Session["CurrentFacUser"] as FactroyInfo;
            DataTable mtable = new DataTable();
            if (user != null)
            {
                string sql = "select * from sys_pageconfig where pc_id in (select pc_id from sys_roleforpage where  role_id  in (select role_id from sys_userforrole where adn_id=@Adn_Id)) and  PC_ParentId=" + Request.QueryString["id"] + " order by PC_Id desc";
                Database db = DatabaseFactory.CreateDatabase();
                var paramsStr = new StringBuilder();
                paramsStr.Append("@Adn_Id int");
                var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sql, paramsStr.ToString());
                db.AddInParameter(command, "Adn_Id", DbType.Int32, user.Adn_Id);
                mtable = db.ExecuteDataSet(command).Tables[0];
            }
            else if (facUser != null)
            {
                string sql =
                 "select pc.* from [SYS_PageConfig] pc join [SYS_RoleForPage] rfp on rfp.[PC_Id]=pc.[PC_Id] join [SYS_RoleInfo] ri on ri.[Role_Id]=rfp.[Role_Id] where ri.[Role_Name]='会员单位' and pc.PC_ParentId=" +
                    Request.QueryString["id"] + " order by PC_Id desc";
                Database db = DatabaseFactory.CreateDatabase();
                mtable = db.ExecuteDataSet(CommandType.Text, sql).Tables[0];

            }
            return mtable;
        }

        ///// <summary>
        ///// 状态搜索方法
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string rName = txtRoleName.Value;
        //    string status = ddlStatus.SelectedValue;
        //    DBindMyRole(rName, Convert.ToInt32(status));
        //}
    }
}