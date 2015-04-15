using System;
using System.Data;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.Model;
using WebSite.DBUtilities;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class Left : WebPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
        }
        /// <summary>
        /// 获取访问节点
        /// </summary>
        /// <returns></returns>
        public DataTable GetUrl()
        {
            VerifyPage("", false);
            var user = Session["CurrentUser"] as SYS_AdminUser;
            if (user != null)
            {
                string sql = "select * from sys_pageconfig where pc_id in (select pc_id from sys_roleforpage where  role_id  in (select role_id from sys_userforrole where adn_id=@Adn_Id)) and PC_ParentId=0 order by pc_id desc";
                DataTable mtable;
                Database db = DatabaseFactory.CreateDatabase();
                var paramsStr = new StringBuilder();
                paramsStr.Append("@Adn_Id int");
                var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sql, paramsStr.ToString());
                db.AddInParameter(command, "Adn_Id", DbType.Int32, user.Adn_Id);
                mtable = db.ExecuteDataSet(command).Tables[0];
                return mtable;
            }
            else
            {
                string sql = "select pc.* from [SYS_PageConfig] pc join [SYS_RoleForPage] rfp on rfp.[PC_Id]=pc.[PC_Id] join [SYS_RoleInfo] ri on ri.[Role_Id]=rfp.[Role_Id] where ri.[Role_Name]='会员单位' and pc.PC_ParentId=0 ";
                Database db = DatabaseFactory.CreateDatabase();
                DataTable mtable = db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
                return mtable;
            }
        }
        /// <summary>
        /// 查询子功能地址
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string getTopURL(object o)
        {
            VerifyPage("", false);
            var user = Session["CurrentUser"] as SYS_AdminUser;
            if (user != null)
            {
                string sql =
                    "select * from sys_pageconfig where pc_id in (select pc_id from sys_roleforpage where  role_id  in (select role_id from sys_userforrole where adn_id=@Adn_Id)) and PC_ParentId=" + o + " order by pc_id desc";
                DataTable mtable;
                Database db = DatabaseFactory.CreateDatabase();
                var paramsStr = new StringBuilder();
                paramsStr.Append("@Adn_Id int");
                var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sql, paramsStr.ToString());
                db.AddInParameter(command, "Adn_Id", DbType.Int32, user.Adn_Id);
                mtable = db.ExecuteDataSet(command).Tables[0];
                if (mtable.Rows.Count > 0)
                {
                    return mtable.Rows[0]["PC_HrefUrl"].ToString();
                }
                return "";
            }
            else
            {
                string sql = "select pc.* from [SYS_PageConfig] pc join [SYS_RoleForPage] rfp on rfp.[PC_Id]=pc.[PC_Id] join [SYS_RoleInfo] ri on ri.[Role_Id]=rfp.[Role_Id] where ri.[Role_Name]='会员单位' and pc.PC_ParentId=" + o;
                Database db = DatabaseFactory.CreateDatabase();
                DataTable mtable = db.ExecuteDataSet(CommandType.Text, sql).Tables[0];
                if (mtable.Rows.Count > 0)
                {
                    return mtable.Rows[0]["PC_HrefUrl"].ToString();

                }
                return "";
            }
        }
    }
}