using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;
using WebSite.CM.DAL;
using OrgUsers = WebSite.Admin.Model.OrgUsers;

namespace WebSite.Web.Manage.SysLogs
{
    public partial class LogList : UI.WebPage
    {
        protected DataTable dataTable = new DataTable();// 创建dataTable对象
        CMArticle aDAL = new CMArticle(); //创建商品分类DAL对象
        SYS_RoleInfo sysRoleDal = new SYS_RoleInfo();          //用户角色关系表

        string areaId = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AreaId"]))
                {
                    areaId = Request.QueryString["AreaId"];
                }
                hidAreaId.Value = areaId;
                DataBingList(false);       //绑定商品分类列表信息
            }
        }
        /// <summary>
        /// 绑定商品信息列表方法
        /// </summary>
        /// <param name="isFirstPage">搜索和删除用true IsPostBack用false</param>
        private void DataBingList(bool isFirstPage)
        {
            #region 分页
            //当前页码
            int pageNum = 1;
            string sqlWhere = string.Empty;
            var name = string.Empty;
            var status = string.Empty;
            //if (!string.IsNullOrEmpty(hidPtid2.Value))
            //{
            //    ptid = Convert.ToInt32(hidPtid2.Value);
            //    sqlWhere += " and a.PTId=" + ptid;
            //}

            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue) && isFirstPage)
            {
                status = ddlStatus.SelectedValue;

                switch (status)
                {
                    case "ProductInfo":
                        sqlWhere = " select  row_number() over(order by [LogList].LLID desc) as rownum,ProductInfo.Title, [LogList].*,[OrgEmployees].[EmplName] from [LogList] join [OrgEmployees] on [OrgEmployees].[EmplId]=[LogList].[EmplId] ";        //查询条件
                        sqlWhere += " join ProductInfo on ProductInfo.PId=[LogList].PId where 1=1 ";
                        break;
                    case "CMArticle":
                        sqlWhere = " select  row_number() over(order by [LogList].LLID desc) as rownum, CMArticle.Title,[LogList].*,[OrgEmployees].[EmplName] from [LogList] join [OrgEmployees] on [OrgEmployees].[EmplId]=[LogList].[EmplId] ";        //查询条件
                        sqlWhere += " join CMArticle on CMArticle.AId=[LogList].PId where 1=1 ";
                        break;
                }
                sqlWhere += " and [LogList].TName ='" + status + "' ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["Status"]) && !isFirstPage)
            {
                status = Request.QueryString["Status"];
                ddlStatus.SelectedValue = status;
                switch (status)
                {
                    case "ProductInfo":
                        sqlWhere = " select  row_number() over(order by [LogList].LLID desc) as rownum,ProductInfo.Title, [LogList].*,[OrgEmployees].[EmplName] from [LogList] join [OrgEmployees] on [OrgEmployees].[EmplId]=[LogList].[EmplId] ";        //查询条件
                        sqlWhere += " join ProductInfo on ProductInfo.PId=[LogList].PId where 1=1 ";
                        break;
                    case "CMArticle":
                        sqlWhere = " select  row_number() over(order by [LogList].LLID desc) as rownum, CMArticle.Title,[LogList].*,[OrgEmployees].[EmplName] from [LogList] join [OrgEmployees] on [OrgEmployees].[EmplId]=[LogList].[EmplId] ";        //查询条件
                        sqlWhere += " join CMArticle on CMArticle.AId=[LogList].PId where 1=1 ";
                        break;
                }
                sqlWhere += " and [LogList].TName ='" + status + "' ";
            }
            else
            {
                status = ddlStatus.SelectedValue;

                switch (status)
                {
                    case "ProductInfo":
                        sqlWhere = " select  row_number() over(order by [LogList].LLID desc) as rownum,ProductInfo.Title, [LogList].*,[OrgEmployees].[EmplName] from [LogList] join [OrgEmployees] on [OrgEmployees].[EmplId]=[LogList].[EmplId] ";        //查询条件
                        sqlWhere += " join ProductInfo on ProductInfo.PId=[LogList].PId where 1=1 ";
                        break;
                    case "CMArticle":
                        sqlWhere = " select  row_number() over(order by [LogList].LLID desc) as rownum, CMArticle.Title,[LogList].*,[OrgEmployees].[EmplName] from [LogList] join [OrgEmployees] on [OrgEmployees].[EmplId]=[LogList].[EmplId] ";        //查询条件
                        sqlWhere += " join CMArticle on CMArticle.AId=[LogList].PId where 1=1 ";
                        break;
                }
                sqlWhere += " and [LogList].TName ='" + status + "' ";

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

            //分页方法
            Pager.GetDataBind("Repeater", "rptArticle", sqlWhere, pageNum, 10, " ", "rownum", "LogList.aspx?ProName=" + name + "&Status=" + status + "&");
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
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        public bool GetRole()
        {
            bool res = false;
            VerifyPage("", false);
            var user = Session["CurrentUser"] as OrgUsers;
            if (user != null)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sqlWhe = " Role_Id=(select Role_Id from dbo.SYS_RoleInfo where Role_Name like '%审核%') and UID=@UID";
                var parameter = new SqlParameter("@UID", DbType.AnsiString);
                parameter.Value = user.UId;
                parameters.Add(parameter);
                DataSet dts = sysRoleDal.GetListAdmin(sqlWhe, parameters);
                if (dts != null)
                {
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <returns></returns>
        public bool GetRoleLook()
        {
            bool res = false;
            VerifyPage("", false);
            var user = Session["CurrentUser"] as OrgUsers;
            if (user != null)
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                string sqlWhe = " Role_Id=(select Role_Id from dbo.SYS_RoleInfo where Role_Name ='系统管理员') and UID=@UID";
                var parameter = new SqlParameter("@UID", DbType.AnsiString);
                parameter.Value = user.UId;
                parameters.Add(parameter);
                DataSet dts = sysRoleDal.GetListAdmin(sqlWhe, parameters);
                if (dts != null)
                {
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        res = true;
                    }
                }
            }
            return res;
        }
    }

}