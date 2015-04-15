using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.CM
{
    public partial class CMColumnClickRate : WebPage
    {
        protected DataTable dataTable = new DataTable();// 创建dataTable对象
        WebSite.CM.DAL.CMColumn cDAL = new WebSite.CM.DAL.CMColumn(); //创建商品分类DAL对象
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                BindDataTable();       //绑定商品分类列表信息
            }
        }
        /// <summary>
        /// 绑定dataTable对象方法
        /// </summary>
        private void BindDataTable()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
            DataSet dt = cDAL.GetList(" 1=1 order by ClickRate desc", parameters);               //查询所有商品分类信息方法
            dataTable = dt.Tables[0];          //将查询的商品分类信息赋值给dataTable对象
        }

        /// <summary>
        /// 执行DataTable中的查询返回新的DataTable
        /// </summary>
        /// <param name="dt">源数据DataTable</param>
        /// <param name="condition">查询条件</param>
        /// <param name="sortOrder"> </param>
        /// <returns></returns>
        public DataTable GetNewDataTable(DataTable dt, string condition)
        {
            var pagedData = new PagedDataSource();
            var newdt = dt.Clone();
            var dr = dt.Select(condition);
            foreach (var t in dr)
            {
                newdt.ImportRow(t);
            }
            return newdt;//返回的查询结果
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
            string sqlWhere = "  ParentId=0 order by ClickRate desc ";        //查询条件
            #endregion
            var dt = cDAL.GetListColumn(sqlWhere).Tables[0];          //查询文章访问量
            if (dt.Rows.Count > 0)
            {
                var dtOut = dt;
                dtOut.Columns["rownum"].ColumnName = "序号";
                dtOut.Columns["ColName"].ColumnName = "栏目名称";
                dtOut.Columns["ClickRate"].ColumnName = "访问量(次)";

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "gb2312";
                Response.AppendHeader("Content-Disposition",
                    "attachment;filename=" +
                    HttpUtility.UrlEncode("模块访问量统计信息" + DateTime.Now.ToString("yyyyMMddhhmm") + ".xls", Encoding.UTF8));
                Response.ContentEncoding = Encoding.GetEncoding("gb2312");
                Response.ContentType = "application/msExcel";
                table.Append("<table border='1' >");
                table.Append("<tr>");
                for (int i = 0; i < dtOut.Columns.Count; i++)
                {
                    if (i != 1)
                    {
                        table.Append("<td>");
                        table.Append(dtOut.Columns[i].Caption); //标格的标题                  
                        table.Append("</td>");
                    }
                }
                table.Append("</tr>");

                for (var i = 0; i < dtOut.Rows.Count; i++)
                {
                    var chDat = cDAL.GetListColumn(" ParentId=" + dtOut.Rows[i][1] + "  order by ClickRate desc ").Tables[0];          //查询文章访问量

                    table.Append("<tr>");
                    for (var j = 0; j < dtOut.Columns.Count; j++)
                    {
                        if (j != 1)
                        {
                            if (j == 3)
                            {
                                table.Append("<td>");
                                table.Append(dtOut.Rows[i][j]);
                                table.Append("</td>");
                            }
                            else
                            {
                                if (chDat != null)
                                {
                                    if (chDat.Rows.Count > 0)
                                    {
                                        int con = chDat.Rows.Count + 1;
                                        if (j == 0)
                                        {
                                            table.Append("<td rowspan=" + con + ">");
                                            table.Append(dtOut.Rows[i][j]);
                                            table.Append("</td>");
                                        }
                                        else
                                        {
                                            table.Append("<td>");
                                            table.Append(dtOut.Rows[i][j]);
                                            table.Append("</td>");
                                        }
                                    }
                                    else
                                    {
                                        table.Append("<td>");
                                        table.Append(dtOut.Rows[i][j]);
                                        table.Append("</td>");
                                    }
                                }
                            }
                        }
                    }

                    if (chDat != null)
                    {
                        if (chDat.Rows.Count > 0)
                        {
                            table.Append("</tr>");
                            for (var h = 0; h < chDat.Rows.Count; h++)
                            {
                                table.Append("<tr>");
                                for (var g = 0; g < chDat.Columns.Count; g++)
                                {
                                    if (g != 1)
                                    {
                                        if (g == 3)
                                        {
                                            table.Append("<td>");
                                            table.Append(chDat.Rows[h][g]);
                                            table.Append("</td>");
                                        }
                                        else
                                        {
                                            if (g != 0)
                                            {
                                                table.Append("<td>");
                                                table.Append("&nbsp;&nbsp;" + chDat.Rows[h][g]);
                                                table.Append("</td>");
                                            }
                                        }
                                    }
                                }
                                table.Append("</tr>");
                            }
                        }
                    }
                    else
                    {
                        table.Append("</tr>");
                    }

                }

                table.Append("</table>");
                Response.Write(table.ToString());
                Response.End();
            }
        }
    }
}