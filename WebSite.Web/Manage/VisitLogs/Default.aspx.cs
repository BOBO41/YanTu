using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.VisitLogs
{
    public partial class Default : UI.WebPage
    {
        private readonly Advertisement _dataDal = new Advertisement();
        private readonly RootPackage _rootPackageDal = new RootPackage();
        private readonly InfoLabel _infoLabelDal = new InfoLabel();
        protected string sort = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                BindOrgTrain();
                if (!string.IsNullOrEmpty(Request.QueryString["rpid"]))
                {
                    ddlSendType.SelectedValue = Request.QueryString["rpid"];

                }
                BindSta();
                if (!string.IsNullOrEmpty(Request.QueryString["orgid"]))
                {
                    DropDownList1.SelectedValue = Request.QueryString["orgid"];
                }
                if (!string.IsNullOrEmpty(Request.QueryString["sdate"]))
                {
                    txtRealName.Value = Convert.ToDateTime(Request.QueryString["sdate"]).ToString("yyyy-MM-dd");
                }
                if (!string.IsNullOrEmpty(Request.QueryString["edate"]))
                {
                    Text1.Value = Convert.ToDateTime(Request.QueryString["edate"]).ToString("yyyy-MM-dd");
                }
                if (!string.IsNullOrEmpty(Request.QueryString["sort"]))
                {
                    sort = Request.QueryString["sort"];
                }
                BindData(false);
            }
        }

        private void BindOrgTrain()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var str = " Status=1 order by CreateDate desc ";
            var dt = _rootPackageDal.GetList(str, parameters).Tables[0];
            ddlSendType.DataSource = dt;
            ddlSendType.DataTextField = "RPName";
            ddlSendType.DataValueField = "RPID";
            ddlSendType.DataBind();
            ddlSendType.Items.Insert(0, new ListItem("全部", "-1"));
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
            int pageSize = 20;
            //分页查询语句
            if (string.IsNullOrEmpty(sort))
            {
                sort = "a.IID";
            }
            hfsort.Value = sort;
            string sql = "select row_number() over(order by " + sort + " desc) as rownum,RootPackage.RPName,a.minDate,a.maxDate,Infos.IID,Infos.IName,Infos.IType,Infos.NType,a.ttime,a.atime,a.vcount,OrgOrganize.OrgName,InfoType.IName as TName from Infos left join (select CONVERT(varchar(100), max(VisitDate), 20) as maxDate,CONVERT(varchar(100), min(VisitDate), 20) as minDate,VisitLog.IID,sum(StayDate) as ttime,avg(StayDate) as atime,count(*) as vcount from VisitLog where 1=1 ";
            //var rpid = string.Empty;
            //if (!string.IsNullOrEmpty(ddlSendType.SelectedValue) && "-1" != ddlSendType.SelectedValue)
            //{
            //    rpid = ddlSendType.SelectedValue;
            //    sql += " and  VisitLog.RPID ='" + rpid + "' ";
            //    if (!string.IsNullOrEmpty(DropDownList1.SelectedValue) && "-1" != DropDownList1.SelectedValue)
            //    {
            //        sql += " and  VisitLog.OrgId ='" + DropDownList1.SelectedValue + "' ";
            //    }
            //}
            //var sdate = string.Empty;
            //if (!string.IsNullOrEmpty(txtRealName.Value))
            //{
            //    sdate = txtRealName.Value;
            //    sql += " and VisitDate>='" + Convert.ToDateTime(txtRealName.Value) + "' ";
            //}
            //var edate = string.Empty;
            //if (!string.IsNullOrEmpty(Text1.Value))
            //{
            //    edate = Text1.Value;
            //    sql += " and VisitDate<='" + Convert.ToDateTime(Text1.Value) + "' ";
            //}
            sql += " group by VisitLog.IID) a on Infos.IID=a.IID join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID join StaPackage on StaPackage.SPID=InfoType.SPID ";
            var rpid = string.Empty;
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue) && "-1" != ddlSendType.SelectedValue && !string.IsNullOrEmpty(DropDownList1.SelectedValue) && "-1" != DropDownList1.SelectedValue)
            {
                rpid = ddlSendType.SelectedValue;
                sql += " and StaPackage.SPID in (select SPID from OrgPkgList where RPID='" + rpid + "' and OrgId='" + DropDownList1.SelectedValue + "') ";
            }
            sql += " join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId join RootPackage on RootPackage.RPID=StaPackage.RPID where 1=1 ";
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue) && "-1" != ddlSendType.SelectedValue)
            {
                sql += " and RootPackage.RPID ='" + rpid + "' ";
            }
            var sdate = string.Empty;
            if (!string.IsNullOrEmpty(txtRealName.Value))
            {
                sdate = txtRealName.Value;
                sql += " and a.minDate>='" + Convert.ToDateTime(txtRealName.Value).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            }
            var edate = string.Empty;
            if (!string.IsNullOrEmpty(Text1.Value))
            {
                edate = Text1.Value;
                sql += " and a.maxDate<='" + Convert.ToDateTime(Text1.Value).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
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
            Pager1.GetDataBind("Repeater", "rptListWork", sql, pageNum, pageSize, "", "rownum", "Default.aspx?sort=" + sort + "&orgid=" + DropDownList1.SelectedValue + "&sdate=" + sdate + "&edate=" + edate + "&rpid=" + rpid + "&");
            #endregion
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(true);
        }
        protected void btnCount_Click(object sender, EventArgs e)
        {
            sort = "a.vcount";
            BindData(true);
        }
        protected void btnTime_Click(object sender, EventArgs e)
        {
            sort = "a.ttime";
            BindData(true);
        }

        #region

        /// <summary>
        /// 删除单条数据方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnDel_Click(object sender, CommandEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.CommandName))
            {
                var res = _dataDal.DeleteList(e.CommandName);
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
                var res = _dataDal.DeleteList(delStr);
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

        #endregion


        //protected void import_Click(object sender, EventArgs e)
        //{
        //    var sberror = new StringBuilder();
        //    int resultExTxt;
        //    var path = FilePath(sberror);
        //    IDataParameter[] parameters = {
        //                                              new SqlParameter("@path", SqlDbType.NVarChar, 500),
        //                                          };
        //    parameters[0].Value = path;
        //    try
        //    {
        //        Database db = DatabaseFactory.CreateDatabase();
        //        DbCommand dbCommand = db.GetStoredProcCommand("ImportCsvbulk");
        //        db.AddInParameter(dbCommand, "@path", DbType.AnsiString, path);
        //        //db.AddInParameter(dbCommand, "@SourceFilePath", DbType.AnsiString, Server.MapPath("~/TempFile/Excel/"));
        //        //db.AddInParameter(dbCommand, "@SourceFileName", DbType.AnsiString, fuExcel.FileName);
        //        //db.AddInParameter(dbCommand, "@DestTableName", DbType.Int32, "VisitLog");
        //        db.AddParameter(dbCommand, "ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, "", DataRowVersion.Current, null);
        //        db.ExecuteNonQuery(dbCommand);
        //        var res = db.GetParameterValue(dbCommand, "ReturnValue").ToString();
        //        if ("0" == res)
        //        {
        //            Page.ClientScript.RegisterStartupScript(GetType(), "",
        //                " <script lanuage=javascript>alert('导入成功');</script>");
        //            return;
        //        }
        //        else
        //        {
        //            Page.ClientScript.RegisterStartupScript(GetType(), "",
        //                " <script lanuage=javascript>alert('导入失败');</script>");
        //            return;
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        Page.ClientScript.RegisterStartupScript(GetType(), "", " <script lanuage=javascript>alert('导入失败');</script>");
        //        return;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        //private string FilePath(StringBuilder error)
        //{
        //    var path = string.Empty;
        //    var fileName = fuExcel.FileName.Trim();
        //    var extension = Path.GetExtension(fileName);
        //    if (extension == null)
        //    {
        //    }
        //    else
        //    {
        //        var fileExition = extension.ToLower();
        //        if (fileExition.ToLower() != ".csv")
        //        {
        //            //上传的不是txt文件
        //            error.Append("上传的不是csv文件\n");
        //        }
        //        else
        //        {
        //            //绝对路径
        //            path = Server.MapPath("~/TempFile/Excel/" + DateTime.Now.ToString("yyyyMMddhhMMss") + "log.csv");
        //            //path = Server.MapPath("~/TempFile/Excel/" + fileName);
        //            fuExcel.SaveAs(path);
        //        }
        //    }
        //    return path;
        //}

        protected void ddlOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSta();
            BindData(true);
        }

        private void BindSta()
        {
            var sql = "select distinct(OrgOrganize.OrgId),OrgOrganize.OrgName from OrgOrganize join OrgPkgList on OrgOrganize.OrgId=OrgPkgList.OrgId and OrgPkgList.RPID='" + ddlSendType.SelectedValue + "' ";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            var dt = db.ExecuteDataSet(dbCommand).Tables[0];
            DropDownList1.DataSource = dt;
            DropDownList1.DataTextField = "OrgName";
            DropDownList1.DataValueField = "OrgId";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("全部", "-1"));
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(true);
        }

        protected string GetIType(object eval)
        {
            var res = "";
            if (eval.ToString() == "1")
            {
                res = "资讯";
            }
            else if (eval.ToString() == "2")
            {
                res = "视频";
            }
            else if (eval.ToString() == "3")
            {
                res = "专题";
            }
            return res;
        }

        protected string GetNType(object eval)
        {
            var res = "";
            if (eval.ToString() == "0" || "" == eval.ToString())
            {
                res = "内容";
            }
            else if (eval.ToString() == "1")
            {
                res = "广告";
            }
            return res;
        }


        protected string GetP(object eval)
        {
            var sql =
                "select ALabel.LName from InfoLabel join ALabel on ALabel.ALID=InfoLabel.ALID where InfoLabel.IID='" + eval + "' ";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            var dt = db.ExecuteDataSet(dbCommand).Tables[0];
            var res = "";
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    res += dt.Rows[i]["LName"] + ",";
                }
            }
            if (!string.IsNullOrEmpty(res))
            {
                res = res.Substring(0, res.Length - 1);
            }
            return res;
        }

        protected string FormatTime(object eval)
        {
            var res = "";
            if (eval.ToString() != "")
            {
                var time = Convert.ToInt64(eval);
                if (time / 60 >= 1)
                {
                    if (time / 3600 >= 1)
                    {
                        res = time / 3600 + "小时" + time % 3600 + "分";
                    }
                    else
                    {
                        res = time / 60 + "分" + time % 60 + "秒";
                    }
                }
                else
                {
                    res = time + "秒";
                }
            }
            return res;
        }

        protected string First(object iid)
        {
            var res = "";
            var sql = "select min(VisitDate) as VisitDate from VisitLog where IID=" +
                      "'" + iid + "' ";
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue) && "-1" != ddlSendType.SelectedValue)
            {
                sql += " and  RPID ='" + ddlSendType.SelectedValue + "' ";
                if (!string.IsNullOrEmpty(DropDownList1.SelectedValue) && "-1" != DropDownList1.SelectedValue)
                {
                    sql += " and  OrgId ='" + DropDownList1.SelectedValue + "' ";
                }
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            var dt = db.ExecuteDataSet(dbCommand).Tables[0];
            if (dt.Rows.Count > 0)
            {
                res = Convert.ToDateTime(dt.Rows[0]["VisitDate"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            return res;
        }

        protected string Last(object iid)
        {
            var res = "";
            var sql = "select max(VisitDate) as VisitDate from VisitLog where IID='" + iid + "' ";
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue) && "-1" != ddlSendType.SelectedValue)
            {
                sql += " and  RPID ='" + ddlSendType.SelectedValue + "' ";
                if (!string.IsNullOrEmpty(DropDownList1.SelectedValue) && "-1" != DropDownList1.SelectedValue)
                {
                    sql += " and  OrgId ='" + DropDownList1.SelectedValue + "' ";
                }
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            var dt = db.ExecuteDataSet(dbCommand).Tables[0];
            if (dt.Rows.Count > 0)
            {
                res = Convert.ToDateTime(dt.Rows[0]["VisitDate"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            return res;
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hfsort.Value))
            {
                sort = "a.IID";
            }
            else
            {
                sort = hfsort.Value;
            }
            string sql = "select row_number() over(order by " + sort + " desc) as rownum,RootPackage.RPName,a.minDate,a.maxDate,Infos.IID,Infos.IName,Infos.IType,Infos.NType,a.ttime,a.atime,a.vcount,OrgOrganize.OrgName,InfoType.IName as TName from Infos left join (select CONVERT(varchar(100), max(VisitDate), 20) as maxDate,CONVERT(varchar(100), min(VisitDate), 20) as minDate,VisitLog.IID,sum(StayDate) as ttime,avg(StayDate) as atime,count(*) as vcount from VisitLog where 1=1 ";

            sql += " group by VisitLog.IID) a on Infos.IID=a.IID join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID join StaPackage on StaPackage.SPID=InfoType.SPID ";
            var rpid = string.Empty;
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue) && "-1" != ddlSendType.SelectedValue && !string.IsNullOrEmpty(DropDownList1.SelectedValue) && "-1" != DropDownList1.SelectedValue)
            {
                rpid = ddlSendType.SelectedValue;
                sql += " and StaPackage.SPID in (select SPID from OrgPkgList where RPID='" + rpid + "' and OrgId='" + DropDownList1.SelectedValue + "') ";
            }
            sql += " join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId join RootPackage on RootPackage.RPID=StaPackage.RPID where 1=1 ";
            if (!string.IsNullOrEmpty(ddlSendType.SelectedValue) && "-1" != ddlSendType.SelectedValue)
            {
                sql += " and RootPackage.RPID ='" + rpid + "' ";
            }
            var sdate = string.Empty;
            if (!string.IsNullOrEmpty(txtRealName.Value))
            {
                sdate = txtRealName.Value;
                sql += " and a.minDate>='" + Convert.ToDateTime(txtRealName.Value).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            }
            var edate = string.Empty;
            if (!string.IsNullOrEmpty(Text1.Value))
            {
                edate = Text1.Value;
                sql += " and a.maxDate<='" + Convert.ToDateTime(Text1.Value).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(sql);
            var dt = db.ExecuteDataSet(dbCommand);
            if (dt.Tables[0].Rows.Count > 0)
            {
                CreateExcel(dt);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('没有数据,修改查询条件试试');</script>");
            }
        }

        protected void CreateExcel(DataSet ds)
        {
            Response.Clear();
            //Response.Buffer = true;
            Response.Charset = "utf8";
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("阅读日志" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls", Encoding.UTF8));
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "application/vnd.ms-excel";
            StringBuilder table = new StringBuilder();
            table.Append("<table border='1' ><tr>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("资源包名称");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("资讯ID");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("资讯标题");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("资讯属性");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("资讯类型");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("所属分站");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("分类名称");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("阅读次数");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("总阅读时间(秒)");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("平均阅读时间(秒)");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("首次阅读");
            table.Append("</strong></td>");
            table.Append("<td align=\"center\"><strong>");
            table.Append("最后阅读");
            table.Append("</strong></td>");
            table.Append("</tr>");

            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //1） 文本：vnd.ms-excel.numberformat:@ 
                //2） 日期：vnd.ms-excel.numberformat:yyyy/mm/dd 
                //3） 数字：vnd.ms-excel.numberformat:#,##0.00 
                //4） 货币：vnd.ms-excel.numberformat:￥#,##0.00 
                //5） 百分比：vnd.ms-excel.numberformat: #0.00% 
                table.Append("<tr>");

                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["RPName"]);
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:#0'>");
                table.Append(ds.Tables[0].Rows[i]["IID"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["IName"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(GetNType(ds.Tables[0].Rows[i]["NType"]));
                table.Append("</td>");

                table.Append("<td>");
                table.Append(GetIType(ds.Tables[0].Rows[i]["IType"]));
                table.Append("</td>");

                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["OrgName"]);
                table.Append("</td>");
                table.Append("<td>");
                table.Append(ds.Tables[0].Rows[i]["TName"]);
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:#,##0'>");
                table.Append(ds.Tables[0].Rows[i]["vcount"].ToString() == "" ? "" : ds.Tables[0].Rows[i]["vcount"].ToString());
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:#,##0'>");
                table.Append(ds.Tables[0].Rows[i]["ttime"].ToString() == "" ? "" : ds.Tables[0].Rows[i]["ttime"].ToString());
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:#,##0'>");
                table.Append(ds.Tables[0].Rows[i]["atime"].ToString() == "" ? "" : ds.Tables[0].Rows[i]["atime"].ToString());
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:yyyy-mm-dd hh:mm:ss'>");
                table.Append(ds.Tables[0].Rows[i]["minDate"].ToString() == "" ? "" : ds.Tables[0].Rows[i]["minDate"].ToString());
                table.Append("</td>");
                table.Append("<td style='vnd.ms-excel.numberformat:yyyy-mm-dd hh:mm:ss'>");
                table.Append(ds.Tables[0].Rows[i]["maxDate"].ToString() == "" ? "" : ds.Tables[0].Rows[i]["maxDate"].ToString());
                table.Append("</td>");

                table.Append("</tr>");
            }
            table.Append("</table>");
            Response.Write(table.ToString());
            //InitGrdiView();
            Response.End();
        }

        public void CreateExcel1(DataSet ds)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(" <html xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
            strb.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
            strb.Append("xmlns=\"http://www.w3.org/TR/REC-html40\"");
            strb.Append(" <head> <meta http-equiv='Content-Type' content='text/html; charset=gb2312'>");
            strb.Append(" <style>");
            strb.Append(".xl26");
            strb.Append(" {mso-style-parent:style0;");
            strb.Append(" font-family:\"Times New Roman\", serif;");
            strb.Append(" mso-font-charset:0;");
            strb.Append(" mso-number-format:\"@\";}");
            strb.Append(" </style>");
            strb.Append(" <xml>");
            strb.Append(" <x:ExcelWorkbook>");
            strb.Append(" <x:ExcelWorksheets>");
            strb.Append(" <x:ExcelWorksheet>");
            strb.Append(" <x:Name>Sheet1 </x:Name>");
            strb.Append(" <x:WorksheetOptions>");
            strb.Append(" <x:DefaultRowHeight>285 </x:DefaultRowHeight>");
            strb.Append(" <x:Selected/>");
            strb.Append(" <x:Panes>");
            strb.Append(" <x:Pane>");
            strb.Append(" <x:Number>3 </x:Number>");
            strb.Append(" <x:ActiveCol>1 </x:ActiveCol>");
            strb.Append(" </x:Pane>");
            strb.Append(" </x:Panes>");
            ////设置工作表只读属性
            //strb.Append(" <x:ProtectContents>False </x:ProtectContents>");
            //strb.Append(" <x:ProtectObjects>False </x:ProtectObjects>");
            //strb.Append(" <x:ProtectScenarios>False </x:ProtectScenarios>");
            strb.Append(" </x:WorksheetOptions>");
            strb.Append(" </x:ExcelWorksheet>");
            strb.Append(" <x:WindowHeight>6750 </x:WindowHeight>");
            strb.Append(" <x:WindowWidth>10620 </x:WindowWidth>");
            strb.Append(" <x:WindowTopX>480 </x:WindowTopX>");
            strb.Append(" <x:WindowTopY>75 </x:WindowTopY>");
            strb.Append(" <x:ProtectStructure>False </x:ProtectStructure>");
            strb.Append(" <x:ProtectWindows>False </x:ProtectWindows>");
            strb.Append(" </x:ExcelWorkbook>");
            strb.Append(" </xml>");
            strb.Append("");
            strb.Append(" </head> <body> <table align=\"center\" style='border-collapse:collapse;table-layout:fixed'> <tr>");
            //if (ds.Tables.Count > 0)
            //{
            strb.Append("<td align=\"center\">");
            strb.Append("资源包名称");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("资讯ID");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("资讯标题");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("资讯属性");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("资讯类型");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("所属分站");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("分类名称");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("阅读次数");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("总阅读时间(秒)");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("平均阅读时间(秒)");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("首次阅读");
            strb.Append("</td>");
            strb.Append("<td align=\"center\">");
            strb.Append("最后阅读");
            strb.Append("</td>");
            strb.Append(" </tr>");

            for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //1） 文本：vnd.ms-excel.numberformat:@ 
                //2） 日期：vnd.ms-excel.numberformat:yyyy/mm/dd 
                //3） 数字：vnd.ms-excel.numberformat:#,##0.00 
                //4） 货币：vnd.ms-excel.numberformat:￥#,##0.00 
                //5） 百分比：vnd.ms-excel.numberformat: #0.00% 
                strb.Append("<tr>");

                strb.Append("<td>");
                strb.Append(ds.Tables[0].Rows[i]["RPName"]);
                strb.Append("</td>");
                strb.Append("<td style='vnd.ms-excel.numberformat:#0'>");
                strb.Append(ds.Tables[0].Rows[i]["IID"]);
                strb.Append("</td>");
                strb.Append("<td>");
                strb.Append(ds.Tables[0].Rows[i]["IName"]);
                strb.Append("</td>");
                strb.Append("<td>");
                strb.Append(GetNType(ds.Tables[0].Rows[i]["NType"]));
                strb.Append("</td>");

                strb.Append("<td>");
                strb.Append(GetIType(ds.Tables[0].Rows[i]["IType"]));
                strb.Append("</td>");

                strb.Append("<td>");
                strb.Append(ds.Tables[0].Rows[i]["OrgName"]);
                strb.Append("</td>");
                strb.Append("<td>");
                strb.Append(ds.Tables[0].Rows[i]["TName"]);
                strb.Append("</td>");
                strb.Append("<td style='vnd.ms-excel.numberformat:#,##0'>");
                strb.Append(ds.Tables[0].Rows[i]["vcount"]);
                strb.Append("</td>");
                strb.Append("<td style='vnd.ms-excel.numberformat:#,##0'>");
                strb.Append(ds.Tables[0].Rows[i]["ttime"]);
                strb.Append("</td>");
                strb.Append("<td style='vnd.ms-excel.numberformat:#,##0'>");
                strb.Append(ds.Tables[0].Rows[i]["atime"]);
                strb.Append("</td>");
                strb.Append("<td style='vnd.ms-excel.numberformat:yyyy-mm-dd hh:mm:ss'>");
                strb.Append(ds.Tables[0].Rows[i]["minDate"]);
                strb.Append("</td>");
                strb.Append("<td style='vnd.ms-excel.numberformat:yyyy-mm-dd hh:mm:ss'>");
                strb.Append(ds.Tables[0].Rows[i]["maxDate"]);
                strb.Append("</td>");

                strb.Append("</tr>");
            }

            strb.Append("</table></body></html>");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "GB2312";
            Response.AppendHeader("Content-Disposition", "attachment;filename=1213.xls");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置输出流为简体中文
            Response.ContentType = "application/ms-excel";//设置输出文件类型为excel文件。
            //this.EnableViewState = false;
            Response.Write(strb);
            Response.End();

        }
    }
}