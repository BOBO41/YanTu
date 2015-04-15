using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class OrgUserWorkStation : UI.WebPage
    {
        private readonly OrgEmployees _dataDal = new OrgEmployees();
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
            string sql = "select row_number() over(order by  OrgEmployees.Addtime desc,OrgEmployees.EmplId DESC) as rownum,OrgEmployees.*,OrgOrganize.OrgName,OrgUsers.UId FROM OrgEmployees join OrgOrganize on OrgOrganize.OrgId=OrgEmployees.OrgId join OrgUsers on OrgUsers.EmplId=OrgEmployees.EmplId where OrgEmployees.Status=1  and OrgUsers.Status=1  and OrgOrganize.OrgType=5 ";
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
            Pager1.GetDataBind("Repeater", "rptList", sql, pageNum, pageSize, "", "rownum", "OrgUserWorkStation.aspx?id=" + Request.QueryString["id"] + "&name=" + name + "&");
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
                WorStaUserAcc worsUserDal = new WorStaUserAcc();

                string sql = " EmplId IN (" + delStr + ")";
                List<SqlParameter> parametersUser = new List<SqlParameter>();
                DataSet dtsUser = worsUserDal.GetList(sql, parametersUser);
                var cids = "";
                if (dtsUser != null)
                {
                    if (dtsUser.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dtsUser.Tables[0].Rows.Count; i++)
                        {
                            cids += dtsUser.Tables[0].Rows[i]["CID"] + ",";
                        }

                    }
                }
                BanKAccountInfo bandAccountDal = new BanKAccountInfo();
                string sqlWhere = " CID IN (" + cids.Substring(0, cids.Length - 1) + ")";
                List<SqlParameter> parameters = new List<SqlParameter>();
                DataSet dts = bandAccountDal.GetList(sqlWhere, parameters);
                if (dts != null)
                {
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('该帐号已存在账户信息不能删除！');</script>");
                    }
                    else
                    {
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
                WorStaUserAcc worsUserDal = new WorStaUserAcc();

                string sql = " EmplId IN (" + e.CommandName + ")";
                List<SqlParameter> parametersUser = new List<SqlParameter>();
                DataSet dtsUser = worsUserDal.GetList(sql, parametersUser);
                var cids = "";
                if (dtsUser != null)
                {
                    if (dtsUser.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dtsUser.Tables[0].Rows.Count; i++)
                        {
                            cids += dtsUser.Tables[0].Rows[i]["CID"] + ",";
                        }

                    }
                }
                if (!string.IsNullOrEmpty(cids))
                {
                    BanKAccountInfo bandAccountDal = new BanKAccountInfo();
                    string sqlWhere = " CID IN (" + cids.Substring(0, cids.Length - 1) + ")";
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    DataSet dts = bandAccountDal.GetList(sqlWhere, parameters);
                    if (dts != null)
                    {
                        if (dts.Tables[0].Rows.Count > 0)
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('该帐号已存在账户信息不能删除！');</script>");
                        }
                        else
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
                    }
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('操作失败！');</script>");
            }
        }

    }

}