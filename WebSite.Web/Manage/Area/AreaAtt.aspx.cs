using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebSite.Area.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Area
{
    public partial class AreaAtt : WebPage
    {
        protected DataTable dataTable = new DataTable();
        LandAttribute laDAL = new LandAttribute(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                BindDataTable();       //绑定列表信息
            }
        }
        /// <summary>
        /// 绑定dataTable对象方法
        /// </summary>
        private void BindDataTable()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
            DataSet dt = laDAL.GetList("", parameters);               
            rptAreaAtt.DataSource = dt.Tables[0];
            rptAreaAtt.DataBind();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btndelList_Click(object sender, EventArgs e)
        {
            try
            {
                bool res = false;
                #region 获取删除土壤属性Id
                int i = 0;
                string delStr = "";
                foreach (RepeaterItem item in rptAreaAtt.Items)
                {
                    CheckBox cb = (CheckBox)item.FindControl("cbSelect");
                    if (cb == null || !cb.Checked) continue;
                    i++;
                    var litId = cb.ToolTip;
                    if (litId != null)
                    {
                        delStr += litId + ",";      //将Id拼接在一起形成字符串
                    }
                }
                #endregion
                if (delStr != "")
                {
                    res = laDAL.DeletePro(delStr.Substring(0, delStr.Length - 1));       //删除商品方法
                }
                if (i == 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请选择您要操作的数据！');</script>");
                }
                if (res)
                {
                    BindDataTable();       //绑定列表信息
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
                }
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败！');</script>");
            }
        }
    }
}