using System;
using System.Web.UI.WebControls;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class PkgStationList : UI.WebPage
    {
        private readonly OrgOrganize _dataDal = new OrgOrganize();
        private readonly Admin.DAL.RootPackage _rootPackageDal = new Admin.DAL.RootPackage();
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
            var orgid = Request.QueryString["orgid"];
            var rpid = Request.QueryString["rpid"];
            if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(rpid))
            {
                var rpkmodel = _rootPackageDal.GetModel(Convert.ToInt32(rpid));
                if (null != rpkmodel)
                {
                    litInfo.Text = rpkmodel.RPName;
                }
                var omodel = _dataDal.GetModel(Convert.ToInt64(orgid));
                if (null != omodel)
                {
                    litInfo.Text += "-" + omodel.OrgName;
                }

                #region 分页

                //当前页码
                int pageNum = 1;
                int pageSize = 10;
                //分页查询语句
                string sql =
                    "select row_number() over(order by  oo.Addtime desc,oo.OrgId DESC) as rownum,oo.*,opl.SSPID,opl.SPID,opl.Status as sstatus from dbo.OrgOrganize oo join StaPackage spk on spk.OrgId=oo.OrgId join OrgPkgList opl on opl.SPID=spk.SPID where opl.OrgId='" +
                    orgid + "' and opl.RPID='" + rpid + "' ";


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
                    "OrgWorkStation.aspx?orgid=" + Request.QueryString["orgid"] + "&rpid=" + rpid + "&");

                #endregion
            }
            else
            {
                rptListWork.DataSource = null;
                rptListWork.DataBind();
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

        #region

        protected string GetStatus(object eval, object sspid, object spid)
        {
            if ("0" == eval.ToString())
            {
                return "<a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"admitData('" + sspid + "','1');\">通过</a> <a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"admitData('" + sspid + "','2');\">退回</a>";
            }
            if ("1" == eval.ToString())
            {
                return "<span class=\"label label-success\">已通过</span>";
            }
            if ("2" == eval.ToString())
            {
                return "<a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"admitData('" + sspid + "','1');\">通过</a> <a href=\"/Manage/Template/Redircet.aspx?spid=" + spid + "\" class=\"btn btn-mini btn-warning\">待编辑</a>";
            }
            return "错误";
        }

        #endregion
    }
}