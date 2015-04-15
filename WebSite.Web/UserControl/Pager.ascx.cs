using System;
using System.Globalization;
using System.Web.UI.WebControls;
using WebSite.DBUtilities;

namespace WebSite.Web.UserControl
{
    public partial class Pager : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="controlType">控件类型：DataList，Repeater，GridView</param>
        /// <param name="controlId">控件Id:RepeaterMyMember</param>
        /// <param name="pSql">查询语句</param>
        /// <param name="pNum">当前页码</param>
        /// <param name="pSiz">每页数据条数</param>
        /// <param name="sort">排序：order by uid desc</param>
        /// <param name="rowNumName">Psql中的row_number别名 如上面的RowNumName Psql中如未指定，可直接用表主键：uid</param>
        /// <param name="url">跳转链接带参数的：/userInfo.aspx?id=1& 不带参数：/userInfo.aspx?</param>
        public void GetDataBind(string controlType, string controlId, string pSql, int pNum, int pSiz, string sort, string rowNumName, string url)
        {
            int rCount;//记录总数
            int pCount;//页总数
            var ds = SqlServer.PR_Pager(pSql, pNum, pSiz, sort, rowNumName, out pCount, out rCount);
            //litPageSize.Text = pSiz.ToString(CultureInfo.InvariantCulture);
            labPcount.Text = pCount==0?"1":pCount.ToString(CultureInfo.InvariantCulture);
            lblCount.Text = rCount.ToString(CultureInfo.InvariantCulture);
            litPageNo.Text = pNum.ToString();
            switch (controlType)
            {
                case "DataList":
                    ((DataList)(Parent.FindControl(controlId))).DataSource = ds;
                    Parent.FindControl(controlId).DataBind();
                    break;
                case "Repeater":
                    ((Repeater)(Parent.FindControl(controlId))).DataSource = ds;
                    Parent.FindControl(controlId).DataBind();
                    break;
                default:
                    ((GridView)(Parent.FindControl(controlId))).AllowSorting = true;
                    ((GridView)(Parent.FindControl(controlId))).DataSource = ds;
                    Parent.FindControl(controlId).DataBind();
                    break;
            }
            var str = string.Empty;
            if (pCount > 1)
            {
                str += "<li><a  href='" + url + "Page=1'>首页</a> </li>";

                if (pNum >= 10)
                {
                    if (pNum + 5 <= pCount)
                    {
                        for (int i = pNum - 5; i < pNum + 5; i++)
                        {
                            if (i == pNum)
                            {
                                str += "<li class=\"active\"><a  href='javascript:void(0)'>" + i + "</a> </li>";
                            }
                            else
                            {
                                str += "<li><a  href='" + url + "Page=" + i + "'>" + i + "</a></li>";
                            }
                        }
                    }
                    else
                    {
                        for (int i = pCount - 9; i <= pCount; i++)
                        {
                            if (i == pNum)
                            {
                                str += "<li class=\"active\"><a  href='javascript:void(0)'>" + i + "</a> </li>";
                            }
                            else
                            {
                                str += "<li><a  href='" + url + "Page=" + i + "'>" + i + "</a></li>";
                            }
                        }
                    }
                }
                else
                {
                    if (pCount >= 10)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            if (i == pNum)
                            {
                                str += "<li class=\"active\"><a  href='javascript:void(0)'>" + i + "</a> </li>";
                            }
                            else
                            {
                                str += "<li><a  href='" + url + "Page=" + i + "'>" + i + "</a></li>";
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= pCount; i++)
                        {
                            if (i == pNum)
                            {
                                str += "<li class=\"active\"><a  href='javascript:void(0)'>" + i + "</a> </li>";
                            }
                            else
                            {
                                str += "<li><a  href='" + url + "Page=" + i + "'>" +
                                       i + "</a></li>";
                            }
                        }
                    }
                }
                str += "<li><a  href='" + url + "Page=" + pCount + "'>尾页</a></li>";
            }
            litPag.Text = str;
        }
    }
}