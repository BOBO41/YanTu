using System;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class AddSystemAdminUser : WebPage
    {
        SYS_AdminUser mAdn = new SYS_AdminUser();
        private int adn_id = 0;
        private int dpt_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                adn_id = string.IsNullOrEmpty(Request.QueryString["adn_id"]) ? 0 : int.Parse(Request.QueryString["adn_id"]);
                hidDptid.Value = dpt_id.ToString();
                if (adn_id != 0)
                {
                    this.lblTitle.Text = "修改用户信息";
                    Admin.Model.SYS_AdminUser adminUserInfo = mAdn.GetModel(adn_id);
                    if (adminUserInfo != null)
                    {
                        this.txtAdnUserName.Value = adminUserInfo.Adn_UserName;
                        this.txtAdnRealName.Value = adminUserInfo.Adn_RealName;
                        if (!string.IsNullOrEmpty(adminUserInfo.Adn_Password))
                        {
                            txtAdnPassWord.Attributes.Add("value", adminUserInfo.Adn_Password);
                        }
                        this.txtAdnSelfCard.Value = adminUserInfo.Adn_SelfCard;
                        this.txtAdnMobile.Value = adminUserInfo.Adn_Mobile;
                        //if (adminUserInfo.Adn_IsWorker == 1)
                        //{
                        //    rboIsWorkTrue.Checked = true;
                        //    rboIsWorkFalse.Checked = false;
                        //}
                        //else
                        //{
                        //    rboIsWorkTrue.Checked = false;
                        //    rboIsWorkFalse.Checked = true;
                        //}
                        if (adminUserInfo.Adn_IsConsultant == 1)
                        {
                            rboIsConsultantOK.Checked = true;
                            rboIsConsultantNO.Checked = false;
                        }
                        else
                        {
                            rboIsConsultantOK.Checked = false;
                            rboIsConsultantNO.Checked = true;
                        }

                    }
                }
                hidadn_id.Value = adn_id.ToString();
            }
        }
    }
}