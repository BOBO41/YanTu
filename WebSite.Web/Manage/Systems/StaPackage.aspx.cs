using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebSite.Web.Manage.Systems
{
    public partial class StaPackage : UI.WebPage
    {
        private readonly Admin.DAL.RootPackage _dataDal = new Admin.DAL.RootPackage();
        protected string name = string.Empty;
        protected int Orpid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                BindOrgTrain();
                if (!string.IsNullOrEmpty(Request.QueryString["name"]))
                {
                    name = Request.QueryString["name"];
                    ddlSendType.SelectedValue = name;
                }
                BindData(false);
            }
        }

        private void BindOrgTrain()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var str = " 1=1 order by CreateDate desc ";
            var dt = _dataDal.GetList(str, parameters).Tables[0];
            ddlSendType.DataSource = dt;
            ddlSendType.DataTextField = "RPName";
            ddlSendType.DataValueField = "RPID";
            ddlSendType.DataBind();
        }

        protected void ddlOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(true);
        }

        /// <summary>
        /// 绑定数据 
        /// </summary>
        /// <param name="isFirstPage">搜索和删除用true IsPostBack用false</param>
        private void BindData(bool isFirstPage)
        {
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue))
            {
                name = ddlSendType.SelectedValue;
            }

            if (!string.IsNullOrEmpty(name))
            {
                var rpmodel = _dataDal.GetModel(Convert.ToInt32(name));
                if (null != rpmodel)
                {
                    if (rpmodel.Status == 0)
                    {
                        litMsg.Text =
                            "<tr><td colspan=4 style=\"text-align: center;\"><span class=\"label label-important\" style=\"font-size:20px;line-height:20px;\">总站资源包未送审或发布,无法查看对应的铁路局资源包</span></td></tr>";
                        rptListWork.DataSource = null;
                        rptListWork.DataBind();
                    }
                    else
                    {
                        litMsg.Text = "";

                        Orpid = Convert.ToInt32(rpmodel.ORPID);

                        #region 分页

                        //当前页码
                        int pageNum = 1;
                        int pageSize = 10;
                        //分页查询语句
                        var sql =
                            "select row_number() over(order by  OrgOrganize.OrgId DESC) as rownum,OrgOrganize.* from OrgOrganize ";

                        sql += "  where OrgOrganize.OrgType=2 and OrgOrganize.Status=1 ";
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
                        Pager1.GetDataBind("Repeater", "rptListWork", sql, pageNum, pageSize, "", "rownum",
                            "StaPackage.aspx?AreaId=" + Request.QueryString["AreaId"] + "&name=" + name + "&");

                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelAll_Click(object sender, EventArgs e)
        {
            string delStr = "";
            foreach (RepeaterItem item in rptListWork.Items)
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
                var res = _dataDal.DelOrgWorStaTran(delStr);
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
                var res = _dataDal.DelOrgWorStaTran(e.CommandName);
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

        protected string IsCopy(object orgid)
        {
            var res = "";
            if (Orpid != 0)
            {
                res = "<a href=\"javascript:;\" onclick=\"expupkg('" + name + "','" + orgid + "')\" class=\"btn btn-mini\" data-title=\"导出更新包\">更新包</a>";
            }
            return res;
        }
    }
}