﻿using System;
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
    /// 部门管理
    /// </summary>
    public partial class SystemDepartmentInfo : WebPage
    {
        protected DataTable dataTable = new DataTable();
        SYS_DepartmentInfo mDpt = new SYS_DepartmentInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                BindDataTable();
            }
        }
        #region 部门管理
        private void BindDataTable()
        {
            DataSet dt = mDpt.GetList("");
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

        /// <summary>
        /// 搜索方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchDpt_Click(object sender, EventArgs e)
        {
            string dptName = txtDptName.Value;
            string dptid = "NULL";
            string dptparentId = "NULL";
            if (!string.IsNullOrEmpty(dptName))
            {
                DataSet dt = mDpt.GetList(" Dpt_Name like '%" + dptName.Trim() + "%'");

                if (dt.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        if (dt.Tables[0].Rows.Count > 1)
                        {
                            if (dt.Tables[0].Rows[i]["Dpt_ID"] != "" && dt.Tables[0].Rows[i]["Dpt_ID"] != null)
                            {
                                dptid += "," + dt.Tables[0].Rows[i]["Dpt_ID"];
                                dptparentId += "," + dt.Tables[0].Rows[i]["Dpt_ParentId"];
                            }
                        }
                        else
                        {
                            if (dt.Tables[0].Rows[i]["Dpt_ID"] != "" && dt.Tables[0].Rows[i]["Dpt_ID"] != null)
                            {
                                dptid = dt.Tables[0].Rows[i]["Dpt_ID"].ToString();
                                dptparentId = dt.Tables[0].Rows[i]["Dpt_ParentId"].ToString();
                            }
                        }
                    }
                }

                DataSet dts = mDpt.GetList(" Dpt_Name like '%" + dptName.Trim() + "%' or Dpt_ParentId in ( " + dptid + ") or Dpt_ID=" + dptparentId);
                dataTable = dts.Tables[0];
            }
            else
            {
                DataSet dt = mDpt.GetList(" ");
                dataTable = dt.Tables[0];
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