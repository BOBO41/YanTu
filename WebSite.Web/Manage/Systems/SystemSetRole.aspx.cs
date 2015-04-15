using System;
using System.Data;
using WebSite.Admin.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class SystemSetRole : WebPage
    {
        private int adn_id = 0;
        public bool isCheck = false;
        SYS_UserForRole mUfr = new SYS_UserForRole();
        SYS_RoleInfo mCusRole = new SYS_RoleInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                adn_id = Request.QueryString["adn_id"] == null ? 0 : int.Parse(Request.QueryString["adn_id"]);  //用户ID
                DBindMyRole("");
            }
        }
        #region  角色管理页面方法
        /// <summary>
        /// 选中角色方法
        /// </summary>
        public string selectCheck(string id)
        {
            string ischek = "";
            DataSet dts = mUfr.GetList(" UId=" + adn_id);
            if (dts.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    if (id == dts.Tables[0].Rows[i]["ROLE_ID"].ToString())
                    {
                        ischek = "checked='checked'";
                        break;
                    }
                }
            }
            return ischek;
        }



        /// <summary>
        /// 绑定角色信息
        /// </summary>
        private void DBindMyRole(string rName)
        {
            #region 分页
            DataTable dt = new DataTable();
            string sqlWhere = "";
            if (rName != "" && rName != null)
            {
                sqlWhere = "  Role_Name  like  '%" + rName + "%'";
            }
            dt = mCusRole.GetList(sqlWhere).Tables[0];
            if (dt.Rows.Count > 0)
            {
                RepeaterMyRole.DataSource = dt;
                RepeaterMyRole.DataBind();
            }
            else
            {
                RepeaterMyRole.DataSource = string.Empty;
                RepeaterMyRole.DataBind();
            }

            #endregion
        }



        #endregion

    }
}