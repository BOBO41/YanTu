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
    public partial class SystemConfig : WebPage
    {
        SYS_DepartmentInfo mDpt = new SYS_DepartmentInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                BindTreeView();
            }
        }

        #region 部门管理

        /// <summary>
        /// 绑定部门
        /// </summary>
        private void BindTreeView()
        {
            DataSet ds = mDpt.GetList(" ");
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataRow[] drs = dt.Select(" Dpt_ParentId = 0");  //选出所有根节点
            this.tvDaiLi.Nodes.Clear();
            TreeNode RootNode = new TreeNode();
            RootNode.Text = "<a href='SystemConfigMain.aspx?DPTId=0' onclick='aClick(this);' target='center' >组织机构</a>";
            RootNode.Value = "0";
            this.tvDaiLi.Nodes.Add(RootNode);
            foreach (DataRow dr in drs)
            {
                string DPTId = dr["Dpt_Id"].ToString();
                string DPTName = dr["Dpt_Name"].ToString();
                string DPTPARENTID = dr["Dpt_ParentId"].ToString();

                TreeNode RootNode2 = new TreeNode();
                RootNode2.Text = "<a href='SystemConfigMain.aspx?DPTId=" + DPTId + "' onclick='aClick(this);' target='center' >" + DPTName + "</a>";
                RootNode2.Value = DPTId;
                RootNode.ChildNodes.Add(RootNode2);
                string SonParentID = DPTId;
                CreateNode(SonParentID, RootNode2, dt);
            }
            //this.tvDaiLi.CollapseAll();
        }

        /// <summary>
        /// 绑定子节点
        /// </summary>
        /// <param name="ParentID"></param>
        /// <param name="ParentNode"></param>
        /// <param name="dr"></param>
        private void CreateNode(string PCPARENTID, TreeNode ParentNode, DataTable dt)
        {
            DataRow[] drs = dt.Select(" Dpt_ParentId= '" + PCPARENTID + "'");
            foreach (DataRow dr in drs)
            {
                string DPTId = dr["Dpt_Id"].ToString();
                string DPTName = dr["Dpt_Name"].ToString();

                TreeNode Node = new TreeNode();
                Node.Text = "<a href='SystemConfigMain.aspx?DPTId=" + DPTId + "' onclick='aClick(this);' target='center' >" + DPTName + "</a>";
                Node.Value = DPTId;
                string SonParentID = DPTId;
                if (ParentNode == null)
                {
                    this.tvDaiLi.Nodes.Clear();
                    ParentNode = new TreeNode();
                    this.tvDaiLi.Nodes.Add(ParentNode);
                }

                ParentNode.ChildNodes.Add(Node);
                CreateNode(SonParentID, Node, dt);
            }
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
    }
}