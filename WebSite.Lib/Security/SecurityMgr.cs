using System;
using System.Data;
using System.Text;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;
using WebSite.DBUtilities;

namespace WebSite.Lib.Security
{
    public class SecurityMgr
    {
        /// <summary>
        /// 用户登录 返回空""成功,否则返回失败信息
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public static string Login(string userName, string userPassword)
        {
            try
            {
                var res = string.Empty;
                const string sqlUserName = "SELECT * FROM OrgUsers WHERE UserName = @Adn_UserName";
                var paramsStr = new StringBuilder();
                paramsStr.Append("@Adn_UserName nvarchar(50)");
                Database db = DatabaseFactory.CreateDatabase();
                var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sqlUserName, paramsStr.ToString());
                db.AddInParameter(command, "Adn_UserName", DbType.AnsiString, userName);
                var name = db.ExecuteScalar(command);
                if (name == null || name == DBNull.Value)
                {
                    const string sqlFacName = "SELECT * FROM FactroyInfo WHERE ConCell = @Adn_UserName";
                    var paramsStrFac = new StringBuilder();
                    paramsStrFac.Append("@Adn_UserName nvarchar(50)");
                    Database dbFac = DatabaseFactory.CreateDatabase();
                    var commandFac = SQLServerUtiles.Get_SP_ExecuteSQL(dbFac, sqlFacName, paramsStrFac.ToString());
                    dbFac.AddInParameter(commandFac, "Adn_UserName", DbType.AnsiString, userName);
                    var nameFac = dbFac.ExecuteScalar(commandFac);
                    if (nameFac == null || nameFac == DBNull.Value)
                    {
                        res = "用户名有误或不存在！";
                    }
                    else
                    {
                        const string sqlFac = "SELECT * FROM FactroyInfo WHERE ConCell = @Adn_UserName and PassWord=@Adn_Password";
                        paramsStrFac.Append(",@Adn_Password nvarchar(50)");
                        Database dbFacInfo = DatabaseFactory.CreateDatabase();
                        var commandFacInfo = SQLServerUtiles.Get_SP_ExecuteSQL(dbFacInfo, sqlFac, paramsStrFac.ToString());
                        dbFacInfo.AddInParameter(commandFacInfo, "Adn_UserName", DbType.AnsiString, userName);
                        dbFacInfo.AddInParameter(commandFacInfo, "Adn_Password", DbType.AnsiString, userPassword);
                        var dataReader = dbFacInfo.ExecuteReader(commandFacInfo);
                        if (dataReader.Read())
                        {
                            HttpContext.Current.Session["CurrentFacUser"] = new FactroyInfo().ReaderBind(dataReader);
                        }
                        else
                        {
                            res = "密码输入错误！";
                        }
                    }
                }
                else
                {
                    const string sqlUser = "SELECT * FROM OrgUsers WHERE Status=1 and UID=((SELECT UID FROM OrgUsers where EmplId =( SELECT EmplId FROM OrgEmployees WHERE  EmplId IN ( SELECT EmplId FROM OrgUsers WHERE UserName = @Adn_UserName and UserPwd=@Adn_Password))))";
                    paramsStr.Append(",@Adn_Password nvarchar(50)");
                    Database dbUser = DatabaseFactory.CreateDatabase();
                    var commandUser = SQLServerUtiles.Get_SP_ExecuteSQL(dbUser, sqlUser, paramsStr.ToString());
                    dbUser.AddInParameter(commandUser, "Adn_UserName", DbType.AnsiString, userName);
                    dbUser.AddInParameter(commandUser, "Adn_Password", DbType.AnsiString, userPassword);
                    var dataReader = dbUser.ExecuteReader(commandUser);
                    if (dataReader.Read())
                    {
                        var orgUsersDal = new OrgUsers();
                        var user = orgUsersDal.ReaderBind(dataReader);
                        user.LastLoginTime = DateTime.Now;
                        orgUsersDal.Update(user);
                        HttpContext.Current.Session["CurrentUser"] = user;
                    }
                    else
                    {
                        res = "用户名或密码输入错误！";
                    }
                }
                return res;
            }
            catch (Exception)
            {
                return "登录失败";
            }
        }

        public static string UserLogin(string userName, string userPassword)
        {
            try
            {
                var res = string.Empty;
                const string sqlUserName = "SELECT * FROM UserAccount WHERE Mobile = @Mobile";
                var paramsStr = new StringBuilder();
                paramsStr.Append("@Mobile nvarchar(200)");
                Database db = DatabaseFactory.CreateDatabase();
                var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sqlUserName, paramsStr.ToString());
                db.AddInParameter(command, "Mobile", DbType.AnsiString, userName);
                var name = db.ExecuteScalar(command);
                if (name == null || name == DBNull.Value)
                {
                    const string sqlFacName = "SELECT * FROM UserAccount WHERE Mobile = @Mobile";
                    var paramsStrFac = new StringBuilder();
                    paramsStrFac.Append("@Mobile nvarchar(200)");
                    Database dbFac = DatabaseFactory.CreateDatabase();
                    var commandFac = SQLServerUtiles.Get_SP_ExecuteSQL(dbFac, sqlFacName, paramsStrFac.ToString());
                    dbFac.AddInParameter(commandFac, "Mobile", DbType.AnsiString, userName);
                    var nameFac = dbFac.ExecuteScalar(commandFac);
                    if (nameFac == null || nameFac == DBNull.Value)
                    {
                        res = "用户名有误或不存在！";
                    }
                    else
                    {
                        const string sqlFac = "SELECT * FROM  UserAccount WHERE Mobile = @Mobile and PassWord=@PassWord";
                        paramsStrFac.Append(",@PassWord nvarchar(50)");
                        Database dbFacInfo = DatabaseFactory.CreateDatabase();
                        var commandFacInfo = SQLServerUtiles.Get_SP_ExecuteSQL(dbFacInfo, sqlFac, paramsStrFac.ToString());
                        dbFacInfo.AddInParameter(commandFacInfo, "Mobile", DbType.AnsiString, userName);
                        dbFacInfo.AddInParameter(commandFacInfo, "PassWord", DbType.AnsiString, userPassword);
                        var dataReader = dbFacInfo.ExecuteReader(commandFacInfo);
                        if (dataReader.Read())
                        {
                            var user = new FactroyInfo().ReaderBind(dataReader);
                            if (user.Status != 1)
                            {
                                res = "帐号异常或被锁定！";
                            }
                            else
                            {
                                HttpContext.Current.Session["FrontUser"] = new UserAccount().ReaderBind(dataReader);
                            }
                        }
                        else
                        {
                            res = "密码输入错误！";
                        }
                    }
                }
                else
                {
                    const string sqlUser = "SELECT * FROM  UserAccount WHERE Mobile = @Mobile and PassWord=@PassWord ";
                    paramsStr.Append(",@PassWord nvarchar(50)");
                    Database dbUser = DatabaseFactory.CreateDatabase();
                    var commandUser = SQLServerUtiles.Get_SP_ExecuteSQL(dbUser, sqlUser, paramsStr.ToString());
                    dbUser.AddInParameter(commandUser, "Mobile", DbType.AnsiString, userName);
                    dbUser.AddInParameter(commandUser, "PassWord", DbType.AnsiString, userPassword);
                    var dataReader = dbUser.ExecuteReader(commandUser);
                    if (dataReader.Read())
                    {
                        var user = new UserAccount().ReaderBind(dataReader);
                        if (user.Status != 1)
                        {
                            res = "帐号异常或被锁定！";
                        }
                        else
                        {
                            HttpContext.Current.Session["FrontUser"] = new UserAccount().ReaderBind(dataReader);
                        }
                    }
                    else
                    {
                        res = "密码输入错误！";
                    }
                }
                return res;
            }
            catch (Exception)
            {
                return "登录失败";
            }
        }


        public static void Logoff()
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
            //var httpCookie = HttpContext.Current.Response.Cookies["UserName"];
            //if (httpCookie != null)
            //    httpCookie.Expires = DateTime.Now.AddSeconds(-1);//Expires过期时间 
            //var cookie = HttpContext.Current.Response.Cookies["PassWord"];
            //if (cookie != null)
            //    cookie.Expires = DateTime.Now.AddSeconds(-1);//Expires过期时间 
        }

        public static bool VerifyFunctionForEmpl(int userId, string DesiredFunction)
        {
            var sql = "select 1 from [SYS_RoleForPage] rfp join [SYS_PageConfig] pc on pc.[PC_Id]=rfp.[PC_Id] and rfp.[Role_Id] in (select [Role_Id] from [SYS_UserForRole] where [Adn_Id]=@Adn_Id) and [PC_Name]=@PC_Name ";
            Database db = DatabaseFactory.CreateDatabase();
            var paramsStr = new StringBuilder();
            paramsStr.Append("@Adn_Id int,@PC_Name nvarchar(100)");
            var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sql, paramsStr.ToString());
            db.AddInParameter(command, "Adn_Id", DbType.Int32, userId);
            db.AddInParameter(command, "PC_Name", DbType.AnsiString, DesiredFunction);
            var res = db.ExecuteScalar(command);
            return res != null && res != DBNull.Value;
        }

        public static DataTable GetUserFunction(string userId)
        {
            var sql = "select * from [SYS_RoleForPage] rfp join [SYS_PageConfig] pc on pc.[PC_Id]=rfp.[PC_Id] and rfp.[Role_Id] in (select [Role_Id] from [SYS_UserForRole] where [Adn_Id]=@Adn_Id) ";
            DataTable mtable;
            Database db = DatabaseFactory.CreateDatabase();
            var paramsStr = new StringBuilder();
            paramsStr.Append("@Adn_Id int");
            var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sql, paramsStr.ToString());
            db.AddInParameter(command, "Adn_Id", DbType.Int32, userId);
            mtable = db.ExecuteDataSet(command).Tables[0];
            return mtable;
        }

        public bool ChangeUserPwd(string UserName, string UserPwd)
        {
            return true;
        }

        public static DataTable GetOrgChildren(string oId)
        {
            var sql = "select * from [SYS_DepartmentInfo] where Dpt_ParentId=@Dpt_ParentId ";
            var paramsStr = new StringBuilder();
            paramsStr.Append("@Dpt_ParentId int");
            Database db = DatabaseFactory.CreateDatabase();
            var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sql, paramsStr.ToString());
            db.AddInParameter(command, "Dpt_ParentId", DbType.Int32, oId);
            return db.ExecuteDataSet(command).Tables[0];
        }

        /// <summary>
        /// 是否使用微信内置浏览器
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public static bool IsMicMsgBrowser(string userAgent)
        {
            return !string.IsNullOrEmpty(userAgent) && userAgent.Contains("MicroMessenger");
        }

        /// <summary>
        /// 前台登陆方法
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userPassword">密码</param>
        /// <returns></returns>
        public static string FrontUserLogin(string userName, string userPassword)
        {
            try
            {
                var res = string.Empty;
                const string sqlUserName = "SELECT * FROM OrgCustomer WHERE UserName = @UserName";
                var paramsStr = new StringBuilder();
                paramsStr.Append("@UserName nvarchar(200)");
                Database db = DatabaseFactory.CreateDatabase();
                var command = SQLServerUtiles.Get_SP_ExecuteSQL(db, sqlUserName, paramsStr.ToString());
                db.AddInParameter(command, "UserName", DbType.AnsiString, userName);
                var name = db.ExecuteScalar(command);
                if (name == null || name == DBNull.Value)
                {
                    const string sqlFacName = "SELECT * FROM OrgCustomer WHERE UserName = @UserName";
                    var paramsStrFac = new StringBuilder();
                    paramsStrFac.Append("@UserName nvarchar(200)");
                    Database dbFac = DatabaseFactory.CreateDatabase();
                    var commandFac = SQLServerUtiles.Get_SP_ExecuteSQL(dbFac, sqlFacName, paramsStrFac.ToString());
                    dbFac.AddInParameter(commandFac, "UserName", DbType.AnsiString, userName);
                    var nameFac = dbFac.ExecuteScalar(commandFac);
                    if (nameFac == null || nameFac == DBNull.Value)
                    {
                        res = "用户名有误或不存在！";
                    }
                    else
                    {
                        const string sqlFac = "SELECT * FROM  OrgCustomer WHERE UserName = @UserName and Password=@Password";
                        paramsStrFac.Append(",@Password nvarchar(50)");
                        Database dbFacInfo = DatabaseFactory.CreateDatabase();
                        var commandFacInfo = SQLServerUtiles.Get_SP_ExecuteSQL(dbFacInfo, sqlFac, paramsStrFac.ToString());
                        dbFacInfo.AddInParameter(commandFacInfo, "UserName", DbType.AnsiString, userName);
                        dbFacInfo.AddInParameter(commandFacInfo, "Password", DbType.AnsiString, userPassword);
                        var dataReader = dbFacInfo.ExecuteReader(commandFacInfo);
                        if (dataReader.Read())
                        {
                            var user = new FactroyInfo().ReaderBind(dataReader);
                            if (user.Status == 0 || user.Status == 2 || user.Status == 5 || user.Status == 6)
                            {
                                res = "帐号异常或被锁定！";
                            }
                            else
                            {
                                HttpContext.Current.Session["FrontUser"] = new UserAccount().ReaderBind(dataReader);
                            }
                        }
                        else
                        {
                            res = "密码输入错误！";
                        }
                    }
                }
                else
                {
                    const string sqlUser = "SELECT * FROM  OrgCustomer WHERE UserName = @UserName and Password=@Password ";
                    paramsStr.Append(",@Password nvarchar(50)");
                    Database dbUser = DatabaseFactory.CreateDatabase();
                    var commandUser = SQLServerUtiles.Get_SP_ExecuteSQL(dbUser, sqlUser, paramsStr.ToString());
                    dbUser.AddInParameter(commandUser, "UserName", DbType.AnsiString, userName);
                    dbUser.AddInParameter(commandUser, "Password", DbType.AnsiString, userPassword);
                    var dataReader = dbUser.ExecuteReader(commandUser);
                    if (dataReader.Read())
                    {
                        var user = new OrgCustomer().ReaderBind(dataReader);
                        if (user.Status == 0 || user.Status == 2 || user.Status == 5 || user.Status == 6)
                        {
                            res = "帐号异常或被锁定！";
                        }
                        else
                        {
                            HttpContext.Current.Session["FrontUser"] = new OrgCustomer().ReaderBind(dataReader);
                        }
                    }
                    else
                    {
                        res = "密码输入错误！";
                    }
                }
                return res;
            }
            catch (Exception)
            {
                return "登录失败";
            }
        }

    }
}
