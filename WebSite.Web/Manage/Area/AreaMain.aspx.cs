using System;
using System.Web.UI.WebControls;
using WebSite.Area.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Area
{
    public partial class AreaMain : WebPage
    {
        private readonly LandInfo liDal = new LandInfo();
        LandAttributeValue lavDAL = new LandAttributeValue();
        protected string aid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                aid = Request.QueryString["AreaId"];
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
            string sql = "select row_number() over(order by li.LId desc) as rownum,li.* ,oa.AreaName from LandInfo li join OrgArea oa on oa.AreaId=li.AreaId and oa.AreaId in (select AreaId from [dbo].[getOrgAreaChild]('" + Request.QueryString["AreaId"] + "'))";
            var name = string.Empty;
            if (!string.IsNullOrEmpty(txtRealName.Value))
            {
                name = txtRealName.Value;
                sql += " and  LName like '%" + name.Trim() + "%' ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                name = Request.QueryString["name"];
                txtRealName.Value = name;
                sql += " and  LName like '%" + name + "%' ";
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
            Pager1.GetDataBind("Repeater", "rptList", sql, pageNum, pageSize, "", "rownum", "AreaMain.aspx?id=" + Request.QueryString["id"] + "&name=" + name + "&");
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
            foreach (RepeaterItem item in rptList.Items)
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
                var res = liDal.DelLandInfo(delStr);
                if (res)
                {
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
                var res = liDal.DelLandInfo(Convert.ToString(e.CommandName));
                if (res)
                {
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


        protected string BindAtt(object lid)
        {
            var ds = lavDAL.GetDateInfo(Convert.ToInt32(lid));
            string str = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["LAId"].ToString() == "5")
                    {
                        str += ds.Tables[0].Rows[i]["LAName"].ToString() + ":" + ds.Tables[0].Rows[i]["LAValue"].ToString();
                    }
                    else
                    {
                        str += ds.Tables[0].Rows[i]["LAName"].ToString() + ":" + ds.Tables[0].Rows[i]["LAValue"].ToString() + "%";
                    }
                    if (i!=ds.Tables[0].Rows.Count-1)
                    {
                        str += ",";
                    }
                }
            }
            return str;
        }
    }
}