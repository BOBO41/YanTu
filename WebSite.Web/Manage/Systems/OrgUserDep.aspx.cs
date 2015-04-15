using System;
using System.Collections;
using System.Globalization;
using System.Web.UI.WebControls;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class OrgUserDep : UI.WebPage
    {
        private readonly OrgEmployees _dataDal = new OrgEmployees();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                BindData(false);
                int[][] aa = new int[4][];

                int[] a = { 1, 2, 3, 4, 5 };

                int[] b = { 6, 7, 8, 9 };

                int[] c = { 10, 11, 12 };

                int[] d = { 13, 14 };

                aa[0] = a;

                aa[1] = b;

                aa[2] = c;

                aa[3] = d;



                MyClass ff = new MyClass(aa);

                ff.MySelf();

                ArrayList dataSource = ff.FirstList;
            }
        }

        private class MyClass
        {
            private readonly int[][] _intList;
            private ArrayList firstList = new ArrayList();
            public ArrayList FirstList
            {
                get
                {
                    return firstList;
                }
            }
            public MyClass(int[][] intList)
            {
                this._intList = intList;
                firstList.AddRange(intList[0]);
            }
            public void MySelf()
            {
                for (int i = 1; i < _intList.Length; i++)
                {
                    Display(_intList[i]);
                }
            }
            private string _strCount;
            private void Display(int[] list)
            {
                _strCount = string.Empty;
                foreach (object t1 in firstList)
                {
                    foreach (int t in list)
                    {
                        _strCount += t1 + "," + t.ToString(CultureInfo.InvariantCulture) + "&";
                    }
                }
                firstList.Clear();
                firstList.AddRange(_strCount.Split('&'));
                firstList.RemoveAt(firstList.Count - 1);
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
            string sql = "select row_number() over(order by  OrgEmployees.Addtime desc,OrgEmployees.EmplId DESC) as rownum,OrgEmployees.*,OrgUsers.UId,OrgUsers.LastLoginTime,OrgUsers.Type ,OrgOrganize.OrgName,OrgUsers.UserName FROM OrgEmployees join OrgUsers on OrgUsers.EmplId=OrgEmployees.EmplId left join OrgOrganize on OrgOrganize.OrgId=OrgEmployees.OrgId and  OrgOrganize.Status=1  where OrgEmployees.Status=1 and OrgUsers.Status=1";
            var name = string.Empty;
            if (!string.IsNullOrEmpty(txtRealName.Value))
            {
                name = txtRealName.Value;
                sql += " and  EmplName like '%" + name + "%' ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                name = Request.QueryString["name"];
                txtRealName.Value = name;
                sql += " and  EmplName like '%" + name + "%' ";
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
            Pager1.GetDataBind("Repeater", "rptList", sql, pageNum, pageSize, "", "rownum", "OrgUserDep.aspx?id=" + Request.QueryString["id"] + "&name=" + name + "&");
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
                var res = _dataDal.DelEmpTran(delStr);
                if (res)
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
                var res = _dataDal.DelEmpTran(e.CommandName);
                if (res)
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

        protected string GetRoleName(object eval)
        {
            var res = "";
            switch (eval.ToString())
            {
                case "1":
                    res = "系统管理员";
                    break;
                case "14":
                    res = "分站编辑";
                    break;
                case "15":
                    res = "分站管理员";
                    break;
            }
            return res;
        }
    }

}