using System;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class Label : UI.WebPage
    {
        private readonly ALabel _dataDal = new ALabel();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                BindData(false);
            }
        }

        /// <summary>
        /// 绑定数据 
        /// </summary>
        /// <param name="isFirstPage">搜索和删除用true IsPostBack用false</param>
        private void BindData(bool isFirstPage)
        {
            #region 分页
            //当前页码
            int pageNum = 1;
            int pageSize = 10;
            //分页查询语句
            string sql = "select row_number() over(order by  oo.ALID desc) as rownum,oo.* FROM ALabel oo where oo.[Status]=1 ";
            var name = string.Empty;
            if (!string.IsNullOrEmpty(txtRealName.Value))
            {
                name = txtRealName.Value;
                sql += " and  oo.LName like '%" + name + "%' ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                name = Request.QueryString["name"];
                txtRealName.Value = name;
                sql += " and  oo.LName like '%" + name + "%' ";
            }
            if (!isFirstPage)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["Page"])) //页数判断
                    {
                        pageNum = Convert.ToInt32(Request.QueryString["Page"]);
                    }
                }
                catch (Exception ex)
                {
                    pageNum = 1;
                }
            }
            //分页方法
            Pager1.GetDataBind("Repeater", "rptListWork", sql, pageNum, pageSize, "", "rownum", "Label.aspx?AreaId=" + Request.QueryString["AreaId"] + "&name=" + name + "&");
            #endregion
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelAll_Click(object sender, EventArgs e)
        {
            string delStr = "";
            foreach (RepeaterItem item in rptListWork.Items)
            {
                CheckBox cb = (CheckBox)item.FindControl("cbList");
                if (cb == null || !cb.Checked) continue;
                var litId = cb.ToolTip;
                if (litId != null)
                {
                    delStr += litId + ",";
                }
            }
            if (!string.IsNullOrEmpty(delStr))
            {
                delStr = delStr.Substring(0, delStr.Length - 1);
                var sql = "update ALabel set Status=0 where ALID in(" + delStr + ") ";
                Database db = DatabaseFactory.CreateDatabase();
                var res = db.ExecuteNonQuery(CommandType.Text, sql);
                if (res > 0)
                {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功！');</script>");
                    BindData(true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(true);
        }

        /// <summary>
        /// 删除单条数据方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, CommandEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.CommandName))
            {
                var sql = "update ALabel set Status=0 where ALID=" + e.CommandName + " ";
                Database db = DatabaseFactory.CreateDatabase();
                var res = db.ExecuteNonQuery(CommandType.Text, sql);
                if (res > 0)
                {
                    //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除成功！');</script>");
                    BindData(true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
            }
        }
    }
}