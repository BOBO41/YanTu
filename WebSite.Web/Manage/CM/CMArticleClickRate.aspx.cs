using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.CM
{
    public partial class CMArticleClickRate : WebPage
    {
        protected DataTable dataTable = new DataTable();// 创建dataTable对象
        WebSite.CM.DAL.CMArticle aDAL = new WebSite.CM.DAL.CMArticle(); //创建商品分类DAL对象
        WebSite.CM.DAL.CMColumn cDAL = new WebSite.CM.DAL.CMColumn();

        public int pageNum = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                DBindLm();//绑定栏目
                if (!string.IsNullOrEmpty(Request.QueryString["Column"]))
                {
                    ddlColumn.SelectedValue = Request.QueryString["Column"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["ProName"]))
                {
                    txtProName.Value = Request.QueryString["ProName"];
                }
                DataBingList(false);       //绑定商品分类列表信息
            }
        }
        /// <summary>
        /// 绑定栏目
        /// </summary>
        private void DBindLm()
        {
            ddlColumn.Items.Add(new ListItem("栏目", "0"));
            var dataTable = cDAL.GetDateList().Tables[0];
            var table1 = GetNewDataTable(dataTable, " Level=1 ", " ColId ");
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                ddlColumn.Items.Add(new ListItem(table1.Rows[i]["ColName"].ToString(),//绑定父类
                                                 table1.Rows[i]["ColID"].ToString()));
                var table2 = GetNewDataTable(dataTable, " ParentID='" + table1.Rows[i]["ColID"] + "'", " ColId ");
                if (table2.Rows.Count > 0)
                {
                    for (int k = 0; k < table2.Rows.Count; k++)
                    {
                        ddlColumn.Items.Add(new ListItem(HttpUtility.HtmlDecode("&nbsp;┠┄┄" + table2.Rows[k]["ColName"]),//绑定子类
                                                         table2.Rows[k]["ColID"].ToString()));
                        var table3 = GetNewDataTable(dataTable, " ParentID='" + table2.Rows[k]["ColID"] + "'",
                                                 " ColId");
                        if (table3.Rows.Count > 0)
                        {

                            for (int j = 0; j < table3.Rows.Count; j++)
                            {
                                ddlColumn.Items.Add(new ListItem(HttpUtility.HtmlDecode("&nbsp;┠┄┄┄┄" + table3.Rows[j]["ColName"]),//绑定二级子类
                                                         table3.Rows[j]["ColID"].ToString()));
                            }
                        }
                    }
                }
            }
        }


        public DataTable GetNewDataTable(DataTable dt, string condition, string sortOrder)
        {
            var newdt = dt.Clone();
            var dr = dt.Select(condition, sortOrder);
            foreach (var t in dr)
            {
                newdt.ImportRow(t);
            }
            return newdt;
        }
        /// <summary>
        /// 绑定商品信息列表方法
        /// </summary>
        /// <param name="isFirstPage">搜索和删除用true IsPostBack用false</param>
        private void DataBingList(bool isFirstPage)
        {
            #region 分页
            //当前页码
            string sqlWhere = " b.Status!=2 ";        //查询条件
            var name = string.Empty;
            var status = string.Empty;
            var type = string.Empty;
            var column = string.Empty;

            if (!string.IsNullOrEmpty(ddlColumn.SelectedValue) && ddlColumn.SelectedValue != "0")
            {
                column = ddlColumn.SelectedValue;
                sqlWhere += " and d.ColId =" + column;
            }

            if (!string.IsNullOrEmpty(txtProName.Value))
            {
                name = txtProName.Value.Trim();
                sqlWhere += " and Title like '%" + name + "%'";
            }
            if (!isFirstPage)
            {
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
            }

            string sql = aDAL.GetDateList(sqlWhere);          //查询商品sql方法
            //分页方法
            Pager.GetDataBind("Repeater", "rptArticle", sql, pageNum, 10, " ", "rownum", "CMArticleClickRate.aspx?ProName=" + name + "&Column=" + column + "&");
            #endregion
        }

        /// <summary>
        /// 搜索方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataBingList(true);               //商品列表绑定方法参数商品名称
        }



        /// <summary>
        /// 栏目搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBingList(true);
        }

        /// <summary>
        /// 导出功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Command(object sender, CommandEventArgs e)
        {
            var table = new StringBuilder();
            #region 查询条件
            string sqlWhere = " b.Status!=2 ";        //查询条件
            var name = string.Empty;
            var status = string.Empty;
            var type = string.Empty;
            var column = string.Empty;

            if (!string.IsNullOrEmpty(ddlColumn.SelectedValue) && ddlColumn.SelectedValue != "0")
            {
                column = ddlColumn.SelectedValue;
                sqlWhere += " and d.ColId =" + column;
            }

            if (!string.IsNullOrEmpty(txtProName.Value))
            {
                name = txtProName.Value.Trim();
                sqlWhere += " and Title like '%" + name + "%'";
            }

            #endregion
            var dt = aDAL.GetDateListDa(sqlWhere).Tables[0];          //查询文章访问量
            if (dt.Rows.Count > 0)
            {
                var dtOut = dt;
                dtOut.Columns["rownum"].ColumnName = "序号";
                dtOut.Columns["Title"].ColumnName = "标题";
                dtOut.Columns["ColName"].ColumnName = "栏目";
                dtOut.Columns["Hits"].ColumnName = "访问量(次)";

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "gb2312";
                Response.AppendHeader("Content-Disposition",
                    "attachment;filename=" +
                    HttpUtility.UrlEncode("文章访问量统计信息" + DateTime.Now.ToString("yyyyMMddhhmm") + ".xls", Encoding.UTF8));
                Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                Response.ContentType = "application/msExcel";
                table.Append("<table border='1' >");
                table.Append("<tr>");
                for (int i = 0; i < dtOut.Columns.Count; i++)
                {
                    table.Append("<td>");
                    table.Append(dtOut.Columns[i].Caption); //标格的标题                  
                    table.Append("</td>");
                }
                table.Append("</tr>");

                for (var i = 0; i < dtOut.Rows.Count; i++)
                {
                    table.Append("<tr>");
                    for (var j = 0; j < dtOut.Columns.Count; j++)
                    {
                        table.Append("<td>");
                        table.Append(dtOut.Rows[i][j]);
                        table.Append("</td>");

                    }
                    table.Append("</tr>");

                }

                table.Append("</table>");
                Response.Write(table.ToString());
                Response.End();
            }
        }
    }
}