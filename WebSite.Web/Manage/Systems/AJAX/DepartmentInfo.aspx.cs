using System;
using System.Data;
using System.Web;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class DepartmentInfo : WebPage
    {
        SYS_DepartmentInfo mDpt = new SYS_DepartmentInfo();
        SYS_AdminUser mUser = new SYS_AdminUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var dpt_id = Request.QueryString["dpt_id"];
                var dptid = Request.QueryString["dptid"];
                var detdpt_id = Request.QueryString["detdpt_id"];
                var DeptName = HttpUtility.UrlDecode(Request.QueryString["DeptName"]);
                if (!string.IsNullOrEmpty(detdpt_id))
                {
                    DataSet dts = mUser.GetList(" Dpt_Id= " + detdpt_id);
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("该部门下存在用户，不能删除");
                        Response.End();
                    }
                    else
                    {
                        int ddpt_id = int.Parse(detdpt_id);//得到需要删除的记录的编号（Id）
                        DataSet dt = mDpt.GetList(" Dpt_ParentId =" + ddpt_id);
                        bool re = true;
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                            {
                                if (dt.Tables[0].Rows[i]["Dpt_Id"] != "" && dt.Tables[0].Rows[i]["Dpt_Id"] != null)
                                {
                                    re = mDpt.Delete(int.Parse(dt.Tables[0].Rows[i]["Dpt_Id"].ToString()));
                                }
                            }
                        }
                        if (re)
                        {
                            Response.Write(mDpt.Delete(ddpt_id) ? "删除成功" : "删除失败");
                            Response.End();
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(DeptName))
                    {
                        Response.Write("部门不能为空");
                        Response.End();
                    }
                    try
                    {


                        var dptInfo = new Admin.Model.SYS_DepartmentInfo();
                        dptInfo.Dpt_Name = DeptName;
                        if (!string.IsNullOrEmpty(dpt_id))
                        {
                            var dept = mDpt.GetModel(Convert.ToInt32(dpt_id));
                            if (dept != null)
                            {
                                var ds = mDpt.GetList(" Dpt_Name='" + DeptName + "' and Dpt_Id !=" + dpt_id);
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Response.Write("部门名称已存在");
                                    Response.End();
                                }
                                dptInfo.Dpt_Id = dept.Dpt_Id;
                                dptInfo.Dpt_Level = dept.Dpt_Level;
                                dptInfo.Dpt_ParentId = dept.Dpt_ParentId;
                                dptInfo.Dpt_SecurityID = dept.Dpt_SecurityID;
                                Response.Write(mDpt.Update(dptInfo) ? "保存成功" : "修改失败");
                                Response.End();
                            }
                            else
                            {
                                Response.Write("该部门不存在！");
                                Response.End();
                            }
                        }
                        else
                        {
                            var ds = mDpt.GetList(" Dpt_Name='" + DeptName + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Response.Write("部门已存在");
                                Response.End();
                            }
                            if (!string.IsNullOrEmpty(dptid))
                            {
                                dptInfo.Dpt_ParentId = Convert.ToInt32(dptid);
                            }
                            else
                            {
                                dptInfo.Dpt_ParentId = 0;
                            }
                            if (dptInfo.Dpt_ParentId != 0)
                            {
                                dptInfo.Dpt_Level = 2;
                            }
                            else
                            {
                                dptInfo.Dpt_Level = 1;
                            }
                            dptInfo.Dpt_SecurityID = Guid.NewGuid().ToString();
                            Response.Write(mDpt.Add(dptInfo) > 0 ? "保存成功" : "保存失败");
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