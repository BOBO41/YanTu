
//**************************************************************
// 文件名：SystemMember（会员管理）
// 数据表：UserAccount(会员信息表)
// 创建人： 田霄
// 创建时间： 2013年9月24日
//**************************************************************

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
    ///会员管理
    /// </summary>
    public partial class SystemMember : WebPage
    {
        protected int PageStart = 0;
        private int pageNum = 1;            //页数
        UserAccount mUa = new UserAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                DBindMyMember(Request.QueryString["rName"], Request.QueryString["contact"], Request.QueryString["createDate"], Request.QueryString["createDateEnd"]);
                txtRealName.Value = Request.QueryString["rName"];
                txtCell.Value = Request.QueryString["contact"];
                txtCreateDate.Value = Request.QueryString["createDate"];
                txtcreateDateEnd.Value = Request.QueryString["createDateEnd"];
            }
        }

        #region  会员管理页面方法
        /// <summary>
        /// 绑定会员信息
        /// </summary>
        private void DBindMyMember(string rName, string contact, string createDate, string createDateEnd)
        {
            #region 分页
            string sqlWhere = " a.Status!=2 ";
            if (!string.IsNullOrEmpty(rName))
            {
                sqlWhere += " and  RealName like '%" + rName + "%'";
            }
            if (!string.IsNullOrEmpty(createDate) && string.IsNullOrEmpty(createDateEnd))
            {
                sqlWhere += " and convert(varchar(10),CreateDate,120)>='" + createDate + "'"; ;
            }
            if (string.IsNullOrEmpty(createDate) && !string.IsNullOrEmpty(createDateEnd))
            {
                sqlWhere += " and convert(varchar(10),CreateDate,120)<='" + createDateEnd + "'";
            }
            if (!string.IsNullOrEmpty(createDate) && !string.IsNullOrEmpty(createDateEnd))
            {
                sqlWhere += " and convert(varchar(10),CreateDate,120)  between  '" + createDate + "' and  '" + createDateEnd + "' ";

            }
            //分页查询语句
            string sql = mUa.GetListUserAccount(sqlWhere);
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Page"]))             //页数判断
                {
                    pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //分页方法
            Pager1.GetDataBind("Repeater", "RepeaterMyMember", sql, pageNum, 10, "", "rownum", "SystemMember.aspx?id=" + Request.QueryString["id"] + "&rName=" + rName + "&contact=" + contact + "&createDate=" + createDate + "&createDateEnd=" + createDateEnd + "&");
            #endregion
        }

        /// <summary>
        /// 搜索方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchMember_Click(object sender, EventArgs e)
        {
            string rName = txtRealName.Value;
            string contact = txtCell.Value;
            string createDate = txtCreateDate.Value;
            string createDateEnd = txtcreateDateEnd.Value;
            DBindMyMember(rName, contact, createDate, createDateEnd);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelMember_Click(object sender, EventArgs e)
        {
            string rName = txtRealName.Value;
            string contact = txtCell.Value;
            string createDate = txtCreateDate.Value;
            string createDateEnd = txtcreateDateEnd.Value;
            int i = 0;
            var res = false;
            string delStr = "";
            foreach (RepeaterItem item in RepeaterMyMember.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("cbSalesMember");
                if (cb == null || !cb.Checked) continue;
                i++;
                var litId = cb.ToolTip;
                if (litId != null)
                {
                    delStr += litId + ",";
                }
            }
            if (delStr != "")
            {
                res = mUa.UpdateList(delStr.Substring(0, delStr.Length - 1));
            }

            if (i == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
            }
            if (res)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            }

            DBindMyMember(rName, contact, createDate, createDateEnd);
        }
        /// <summary>
        /// 删除会员信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteMember_Click(object sender, CommandEventArgs e)
        {
            string rName = txtRealName.Value;
            string contact = txtCell.Value;
            string createDate = txtCreateDate.Value;
            string createDateEnd = txtcreateDateEnd.Value;
            bool res = false;
            var uid = int.Parse(e.CommandName);//得到需要删除的记录的编号（Id）
            var userAccount = mUa.GetModel(Convert.ToInt64(uid));
            if (userAccount != null)
            {
                userAccount.Status = 2;
                res = mUa.Update(userAccount);
            }
            if (res)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功！');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            }
            DBindMyMember(rName, contact, createDate, createDateEnd);
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