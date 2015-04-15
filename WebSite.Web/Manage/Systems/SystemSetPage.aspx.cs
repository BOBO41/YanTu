using System;
using System.Data;
using System.Web.UI.WebControls;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class SystemSetPage : WebPage
    {
        private int role_id = 0;
        protected DataTable dataTable = new DataTable();
        SYS_RoleForPage mRfg = new SYS_RoleForPage();
        SYS_PageConfig mPages = new SYS_PageConfig();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                role_id = Request.QueryString["role_id"] == null ? 0 : int.Parse(Request.QueryString["role_id"]);  //角色ID
                hidRoleId.Value = role_id.ToString();
                BindDataTable();

            }
        }
        #region  功能管理页面方法

        /// <summary>
        /// 选中功能方法
        /// </summary>
        public string selectCheck(string id)
        {
            string ischek = "";
            DataSet dts = mRfg.GetList(" Role_Id=" + role_id);
            if (dts.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    if (id == dts.Tables[0].Rows[i]["PC_ID"].ToString())
                    {
                        ischek = "checked='checked'";
                        break;
                    }
                }
            }
            return ischek;
        }



        private void BindDataTable()
        {
            DataSet dt = mPages.GetList(" PC_State=1 ");
            dataTable = dt.Tables[0];
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

        #endregion

    }
}