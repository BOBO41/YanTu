using System;
using System.Linq;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class Consultant : WebPage
    {
        SYS_UserForConsultant mUfc = new SYS_UserForConsultant();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var adn_id = Request.QueryString["adn_id"];
                var detadn_id = Request.QueryString["detadn_id"];
                var adnUser_id = Request.QueryString["adnUser_id"];
                var gid_str = Request.QueryString["gid_str"];
                var Deladn_id = Request.QueryString["Deladn_id"];
                var DelId_str = Request.QueryString["DelId_str"];
                if (!string.IsNullOrEmpty(Deladn_id))
                {
                    if (string.IsNullOrEmpty(DelId_str))
                    {
                        Response.Write("请选择您要删除的数据！");
                        Response.End();
                    }
                    else
                    {
                        bool b = false;
                        string[] stringSeparators = new string[] { "_" };
                        string[] sArray = DelId_str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < sArray.Count(); j++)
                        {
                            Admin.Model.SYS_UserForConsultant userForCon = mUfc.GetModel(Convert.ToInt32(Deladn_id), Convert.ToInt32(sArray[j]));
                            if (userForCon != null)
                            {
                                b = mUfc.Delete(userForCon.Con_Id);
                            }
                        }
                        Response.Write(b ? "删除成功" : "删除失败");
                        Response.End();
                    }
                }
                else
                {

                    if (!string.IsNullOrEmpty(adnUser_id))
                    {
                        if (string.IsNullOrEmpty(gid_str))
                        {
                            Response.Write("请选择您要保存的数据！");
                            Response.End();
                        }
                        else
                        {
                            string[] stringSeparators = new string[] { "_" };
                            string[] sArray = gid_str.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                            int res = 0;
                            for (int j = 0; j < sArray.Count(); j++)
                            {
                                Admin.Model.SYS_UserForConsultant userForCon = new Admin.Model.SYS_UserForConsultant();
                                userForCon.Adn_Id = Convert.ToInt32(adnUser_id);
                                userForCon.Adn_ConId = int.Parse(sArray[j]);
                                res = mUfc.Add(userForCon);
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
                        if (!string.IsNullOrEmpty(adn_id) && !string.IsNullOrEmpty(detadn_id))
                        {
                            int adnid = int.Parse(adn_id);
                            int adn_ConId = int.Parse(detadn_id);
                            Admin.Model.SYS_UserForConsultant userForCon = mUfc.GetModel(adnid, adn_ConId);
                            if (userForCon != null)
                            {
                                Response.Write(mUfc.Delete(userForCon.Con_Id) ? "删除成功" : "删除失败");
                                Response.End();
                            }

                        }

                    }
                }
            }
        }
    }
}