using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class OrgPackage : UI.WebPage
    {
        private readonly Admin.DAL.RootPackage _dataDal = new Admin.DAL.RootPackage();
        private readonly OrgEmployees _orgEmployeesDal = new OrgEmployees();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                BindOrgTrain();
                BindData(false);
            }
        }

        #region

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

        #endregion


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
            VerifyPage("", true);
            Database db = DatabaseFactory.CreateDatabase();
            var emp = _orgEmployeesDal.GetModel(Convert.ToInt32(CurrentUser.EmplId));
            #region 原始资源包


            //分页查询语句
            var sql = "select row_number() over(order by  OrgOrganize.OrgId DESC) as rownum,OrgOrganize.*,StaPackage.Status as spstatus,StaPackage.SPID,StaPackage.CreateDate from OrgOrganize left join StaPackage on OrgOrganize.OrgId=StaPackage.OrgId ";
            var name = string.Empty;
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue))
            {
                name = ddlSendType.SelectedValue;
                sql += " and StaPackage.RPID=@RPID ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                name = Request.QueryString["name"];
                ddlSendType.SelectedValue = name;
                sql += " and StaPackage.RPID=@RPID ";
            }
            if (!string.IsNullOrEmpty(name))
            {
                sql += "  and StaPackage.PkgType=0  where OrgOrganize.OrgType=1 and OrgOrganize.Status=1 and OrgOrganize.OrgId=" + emp.OrgId + "";
                DbCommand dbCommand = db.GetSqlStringCommand(sql);
                dbCommand.Parameters.Add(new SqlParameter("@RPID", DbType.AnsiString) { Value = name });
                var dt = db.ExecuteDataSet(dbCommand).Tables[0];
                rptListWork.DataSource = dt;
                rptListWork.DataBind();
            }
            else
            {
                rptListWork.DataSource = null;
                rptListWork.DataBind();
            }

            #endregion

            #region 特殊铁路局资源包

            //分页查询语句
            var sqlSp = "select row_number() over(order by  OrgOrganize.OrgId DESC) as rownum,OrgOrganize.OrgName,StaPackage.SPID,StaPackage.Status as spstatus,StaPackage.CreateDate,StaPackage.OrgId,OrgPkgList.SSPID from OrgOrganize join OrgPkgList on OrgPkgList.OrgId=OrgOrganize.OrgId join StaPackage on StaPackage.SPID=OrgPkgList.SPID where StaPackage.PkgType=1 and StaPackage.OrgId=" + emp.OrgId + " ";
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue))
            {
                sqlSp += " and OrgPkgList.RPID=@RPID ";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["name"]))
            {
                sqlSp += " and OrgPkgList.RPID=@RPID ";
            }
            DbCommand dbCommandSp = db.GetSqlStringCommand(sqlSp);
            dbCommandSp.Parameters.Add(new SqlParameter("@RPID", DbType.AnsiString) { Value = name });
            var dtSp = db.ExecuteDataSet(dbCommandSp).Tables[0];
            rptSp.DataSource = dtSp;
            rptSp.DataBind();

            #endregion
        }

        #region

        protected string GetStatus(object eval, object orgId, object spid)
        {
            //if (CurrentUser.Type == 14)
            //{
                if ("" == eval.ToString())
                {
                    return "<a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"createtype(this,'" + orgId +
                           "');\">开始编辑</a>";
                }
                if ("0" == eval.ToString())
                {
                    var str = "<a href=\"/Manage/Template/Redircet.aspx?spid=" + spid +
                           "\" class=\"btn btn-mini\">编辑</a> <a href=\"javascript:;\" onclick=\"exppkg('" + spid +
                           "')\" class=\"btn btn-mini\">导出</a>";
                    if (CurrentUser.Type == 15)
                    {
                        str += " <a href=\"javascript:;\" onclick=\"finpkg('" + spid +
                           "')\" class=\"btn btn-mini\">完稿</a>";
                    }
                    return str;
                }
                if ("1" == eval.ToString())
                {
                    return
                        "<span class=\"label label-success\">已完稿</span> <a href=\"javascript:;\" onclick=\"exppkg('" +
                        spid + "')\" class=\"btn btn-mini\">下载</a>";
                }
                if ("2" == eval.ToString())
                {
                    return "<span class=\"label label-info\">待审核</span> <a href=\"javascript:;\" onclick=\"exppkg('" +
                           spid + "')\" class=\"btn btn-mini\">导出</a>";
                }
                if ("3" == eval.ToString())
                {
                    return
                        "<span class=\"label label-success\">已发布</span> <a href=\"javascript:;\" onclick=\"exppkg('" +
                        spid + "')\" class=\"btn btn-mini\">下载</a>";
                }
                if ("4" == eval.ToString())
                {
                    var str = "<a href=\"/Manage/Template/Redircet.aspx?spid=" + spid +
                           "\" class=\"btn btn-mini btn-warning\">待编辑</a> <a href=\"javascript:;\" onclick=\"exppkg('" +
                           spid + "')\" class=\"btn btn-mini\">导出</a>";
                    if (CurrentUser.Type == 15)
                    {
                        str += " <a href=\"javascript:;\" onclick=\"finpkg('" + spid +
                           "')\" class=\"btn btn-mini\">完稿</a>";
                    }
                    return str;
                }
            //}

            #region 

            //if (CurrentUser.Type == 15)
            //{
            //    if ("" == eval.ToString())
            //    {
            //        return "<span class=\"label label-important\">未开始</span>";
            //    }
            //    if ("0" == eval.ToString())
            //    {
            //        return "<a href=\"javascript:;\" onclick=\"finpkg('" + spid +
            //               "')\" class=\"btn btn-mini\">完稿</a>";
            //    }
            //    if ("1" == eval.ToString())
            //    {
            //        return
            //            "<span class=\"label label-success\">已完稿</span> <a href=\"javascript:;\" onclick=\"exppkg('" +
            //            spid + "')\" class=\"btn btn-mini\">下载</a>";
            //    }
            //    if ("2" == eval.ToString())
            //    {
            //        return "<span class=\"label label-info\">待审核</span> <a href=\"javascript:;\" onclick=\"exppkg('" +
            //               spid + "')\" class=\"btn btn-mini\">导出</a>";
            //    }
            //    if ("3" == eval.ToString())
            //    {
            //        return
            //            "<span class=\"label label-success\">已发布</span> <a href=\"javascript:;\" onclick=\"exppkg('" +
            //            spid + "')\" class=\"btn btn-mini\">下载</a>";
            //    }
            //    if ("4" == eval.ToString())
            //    {
            //        return "<span class=\"label label-info\">待编辑</span> <a href=\"javascript:;\" onclick=\"exppkg('" +
            //               spid + "')\" class=\"btn btn-mini\">导出</a> <a href=\"javascript:;\" onclick=\"finpkg('" +
            //               spid + "')\" class=\"btn btn-mini\">完稿</a>";
            //    }
            //}

            #endregion

            return "错误";
        }

        #endregion

        #region

        protected string GetStatusSp(object eval, object orgId, object spid)
        {
            if ("0" == eval.ToString())
            {
                return "<a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "\" class=\"btn btn-mini\">编辑</a> <a href=\"javascript:;\" onclick=\"finpkg('" + spid + "')\" class=\"btn btn-mini\">完稿</a> <a href=\"/Manage/Pkg/Expkg.aspx?spid=" + spid + "\" class=\"btn btn-mini\">导出</a>";
            }
            if ("1" == eval.ToString())
            {
                return "<span class=\"label label-success\">已完稿</span> <a href=\"/Manage/Pkg/Expkg.aspx?spid=" + spid + "\" class=\"btn btn-mini\">下载</a>";
            }
            if ("2" == eval.ToString())
            {
                return "<span class=\"label label-info\">待审核</span> <a href=\"/Manage/Pkg/Expkg.aspx?spid=" + spid + "\" class=\"btn btn-mini\">导出</a>";
            }
            if ("3" == eval.ToString())
            {
                return "<span class=\"label label-success\">已发布</span> <a href=\"/Manage/Pkg/Expkg.aspx?spid=" + spid + "\" class=\"btn btn-mini\">下载</a>";
            }
            if ("4" == eval.ToString())
            {
                return "<a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "\" class=\"btn btn-mini\">待编辑</a> <a href=\"javascript:;\" onclick=\"finpkg('" + spid + "')\" class=\"btn btn-mini\">完稿</a> <a href=\"/Manage/Pkg/Expkg.aspx?spid=" + spid + "\" class=\"btn btn-mini\">导出</a>";
            }
            return "错误";
        }

        #endregion

        #region

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

        #endregion
    }
}