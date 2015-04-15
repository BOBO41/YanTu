using System;
using System.Data;
using System.Linq;
using System.Web;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class PageInfo : WebPage
    {
        SYS_PageConfig mPage = new SYS_PageConfig();
        SYS_RoleForPage mRfp = new SYS_RoleForPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var pageid = Request.QueryString["pageid"];
                var pc_id = Request.QueryString["pc_id"];
                var detpg_id = Request.QueryString["detpg_id"];
                var PCNames = HttpUtility.UrlDecode(Request.QueryString["PCNames"]);
                var PCMemo = HttpUtility.UrlDecode(Request.QueryString["PCMemo"]);
                var PCHrefUrl = Request.QueryString["PCHrefUrl"];
                var role_id = Request.QueryString["role_id"];
                var gid_str = Request.QueryString["gid_str"];
                if (!string.IsNullOrEmpty(role_id))
                {
                    if (string.IsNullOrEmpty(gid_str))
                    {
                        Response.Write("请选择要保存的数据！");
                        Response.End();
                    }
                    else
                    {
                        string[] stringSeparators = new string[] { "_" };
                        string[] sArray = gid_str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                        int res = 0;
                        DataSet dts = mRfp.GetList(" Role_Id=" + role_id);
                        if (dts.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                            {
                                if (dts.Tables[0].Rows[i]["RFP_Id"] != "" && dts.Tables[0].Rows[i]["RFP_Id"] != null)
                                {
                                    mRfp.Delete(int.Parse(dts.Tables[0].Rows[i]["RFP_Id"].ToString()));
                                }
                            }
                        }
                        for (int j = 0; j < sArray.Count(); j++)
                        {
                            Admin.Model.SYS_RoleForPage roleForPage = new Admin.Model.SYS_RoleForPage();
                            roleForPage.Role_Id = Convert.ToInt32(role_id);
                            roleForPage.PC_Id = int.Parse(sArray[j]);
                            res = mRfp.Add(roleForPage);
                            if (res > 0)
                            {
                                res++;
                            }
                        }
                        Response.Write(res > 0 ? "保存成功" : "保存失败");
                        Response.End();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(detpg_id))
                    {
                        int dtpg_id = int.Parse(detpg_id);//得到需要删除的记录的编号（Id）
                        DataSet dt = mPage.GetList(" PC_ParentId =" + dtpg_id);
                        bool res = false;
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                            {
                                if (dt.Tables[0].Rows[i]["PC_Id"] != "" && dt.Tables[0].Rows[i]["PC_Id"] != null)
                                {
                                    DataSet dts = mRfp.GetList(" Pc_Id= " + dt.Tables[0].Rows[i]["PC_Id"]);
                                    if (dts.Tables[0].Rows.Count > 0)
                                    {
                                        for (int j = 0; j < dts.Tables[0].Rows.Count; j++)
                                        {
                                            res = mRfp.Delete(int.Parse(dts.Tables[0].Rows[j]["RFP_Id"].ToString()));

                                        }
                                    }
                                    mPage.Delete(int.Parse(dt.Tables[0].Rows[i]["PC_Id"].ToString()));
                                }
                            }
                        }
                        bool re = false;
                        DataSet dtPc = mRfp.GetList(" Pc_Id= " + dtpg_id);
                        if (dtPc.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < dtPc.Tables[0].Rows.Count; j++)
                            {
                                re = mRfp.Delete(int.Parse(dtPc.Tables[0].Rows[j]["RFP_Id"].ToString()));
                            }
                        }
                        Response.Write(mPage.Delete(dtpg_id) ? "删除成功" : "删除失败");
                        Response.End();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(PCNames))
                        {
                            Response.Write("功能名称不能为空");
                            Response.End();
                        }
                        if (string.IsNullOrEmpty(PCHrefUrl))
                        {
                            Response.Write("链接页面不能为空");
                            Response.End();
                        }
                        try
                        {


                            var pageInfo = new Admin.Model.SYS_PageConfig();
                            pageInfo.PC_Name = PCNames;
                            pageInfo.PC_Memo = PCMemo;
                            pageInfo.PC_HrefUrl = PCHrefUrl;

                            if (!string.IsNullOrEmpty(pc_id))
                            {
                                var page = mPage.GetModel(Convert.ToInt32(pc_id));
                                if (page != null)
                                {
                                    var ds = mPage.GetList(" PC_Name='" + PCNames + "' and PC_Id !=" + pc_id );
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        Response.Write("功能名称已存在");
                                        Response.End();
                                    }
                                    pageInfo.PC_Id = page.PC_Id;
                                    pageInfo.PC_ParentId = page.PC_ParentId;
                                    pageInfo.PC_State = page.PC_State;
                                    pageInfo.PC_HaveChild = page.PC_HaveChild;
                                    Response.Write(mPage.Update(pageInfo) ? "保存成功" : "修改失败");
                                    Response.End();
                                }
                                else
                                {
                                    Response.Write("该功能名称不存在！");
                                    Response.End();
                                }
                            }
                            else
                            {
                                string sqlWher = "";
                                if (!string.IsNullOrEmpty(pageid))
                                {
                                    sqlWher = " PC_Name='" + PCNames + "' and PC_ParentId=" + pageid;
                                }
                                else
                                {
                                    sqlWher = " PC_Name='" + PCNames + "' and PC_ParentId=0";
                                }
                                var ds = mPage.GetList(sqlWher);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Response.Write("功能名称已存在");
                                    Response.End();
                                }
                                pageInfo.PC_State = 1;
                                if (!string.IsNullOrEmpty(pageid))
                                {
                                    pageInfo.PC_ParentId = int.Parse(pageid);
                                }
                                else
                                {
                                    pageInfo.PC_ParentId = 0;
                                }
                                pageInfo.PC_State = 1;
                                pageInfo.PC_HaveChild = 0;
                                Response.Write(mPage.Add(pageInfo) > 0 ? "保存成功" : "保存失败");
                                Response.End();

                            }
                        }
                        catch (System.Threading.ThreadAbortException ex)
                        {
                        }
                        catch (Exception ex1)
                        {

                            Response.Write("保存失败");
                            Response.End();
                        }
                    }
                }
            }
        }

    }

}