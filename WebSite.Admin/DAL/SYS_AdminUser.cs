/**  版本信息模板在安装目录下，可自行修改。
* SYS_AdminUser.cs
*
* 功 能： N/A
* 类 名： SYS_AdminUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013-08-22 09:30:14   N/A    初版
*
* 




*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.DBUtilities;

namespace WebSite.Admin.DAL
{
    /// <summary>
    /// 数据访问类:SYS_AdminUser
    /// </summary>
    public partial class SYS_AdminUser
    {
        public SYS_AdminUser()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(Adn_Id)+1 from SYS_AdminUser";
            Database db = DatabaseFactory.CreateDatabase();
            object obj = db.ExecuteScalar(CommandType.Text, strsql);
            if (obj != null && obj != DBNull.Value)
            {
                return int.Parse(obj.ToString());
            }
            return 1;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Adn_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_AdminUser where Adn_Id=@Adn_Id ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, Adn_Id);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, global::System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.SYS_AdminUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SYS_AdminUser(");
            strSql.Append("Dpt_Id,Adn_UserName,Adn_Password,Adn_Mobile,Adn_AddTime,Adn_Flag,Adn_RealName,Adn_SecurityID,Adn_IsWorker,Adn_SelfCard,OpenId,Adn_IsConsultant,Wx_FakeId,Wx_NickName,Wx_ReMarkName,Wx_Username,Wx_Signature,Wx_Country,Wx_Province,Wx_City,Wx_Sex,Wx_GroupID,Wx_GroupName,Wx_UserImage,Wx_Status,Wx_MsgId,Wx_MsgCreateDateTime,Wx_MsgContent)");

            strSql.Append(" values (");
            strSql.Append("@Dpt_Id,@Adn_UserName,@Adn_Password,@Adn_Mobile,@Adn_AddTime,@Adn_Flag,@Adn_RealName,@Adn_SecurityID,@Adn_IsWorker,@Adn_SelfCard,@OpenId,@Adn_IsConsultant,@Wx_FakeId,@Wx_NickName,@Wx_ReMarkName,@Wx_Username,@Wx_Signature,@Wx_Country,@Wx_Province,@Wx_City,@Wx_Sex,@Wx_GroupID,@Wx_GroupName,@Wx_UserImage,@Wx_Status,@Wx_MsgId,@Wx_MsgCreateDateTime,@Wx_MsgContent)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Dpt_Id", DbType.Int32, model.Dpt_Id);
            db.AddInParameter(dbCommand, "Adn_UserName", DbType.AnsiString, model.Adn_UserName);
            db.AddInParameter(dbCommand, "Adn_Password", DbType.AnsiString, model.Adn_Password);
            db.AddInParameter(dbCommand, "Adn_Mobile", DbType.AnsiString, model.Adn_Mobile);
            db.AddInParameter(dbCommand, "Adn_AddTime", DbType.DateTime, model.Adn_AddTime);
            db.AddInParameter(dbCommand, "Adn_Flag", DbType.Int32, model.Adn_Flag);
            db.AddInParameter(dbCommand, "Adn_RealName", DbType.String, model.Adn_RealName);
            db.AddInParameter(dbCommand, "Adn_SecurityID", DbType.AnsiString, model.Adn_SecurityID);
            db.AddInParameter(dbCommand, "Adn_IsWorker", DbType.Byte, model.Adn_IsWorker);
            db.AddInParameter(dbCommand, "Adn_SelfCard", DbType.AnsiString, model.Adn_SelfCard);
            db.AddInParameter(dbCommand, "OpenId", DbType.AnsiString, model.OpenId);
            db.AddInParameter(dbCommand, "Adn_IsConsultant", DbType.Int32, model.Adn_IsConsultant);
            db.AddInParameter(dbCommand, "Wx_FakeId", DbType.String, model.Wx_FakeId);
            db.AddInParameter(dbCommand, "Wx_NickName", DbType.String, model.Wx_NickName);
            db.AddInParameter(dbCommand, "Wx_ReMarkName", DbType.String, model.Wx_ReMarkName);
            db.AddInParameter(dbCommand, "Wx_Username", DbType.String, model.Wx_Username);
            db.AddInParameter(dbCommand, "Wx_Signature", DbType.String, model.Wx_Signature);
            db.AddInParameter(dbCommand, "Wx_Country", DbType.String, model.Wx_Country);
            db.AddInParameter(dbCommand, "Wx_Province", DbType.String, model.Wx_Province);
            db.AddInParameter(dbCommand, "Wx_City", DbType.String, model.Wx_City);
            db.AddInParameter(dbCommand, "Wx_Sex", DbType.Byte, model.Wx_Sex);
            db.AddInParameter(dbCommand, "Wx_GroupID", DbType.Int32, model.Wx_GroupID);
            db.AddInParameter(dbCommand, "Wx_GroupName", DbType.String, model.Wx_GroupName);
            db.AddInParameter(dbCommand, "Wx_UserImage", DbType.String, model.Wx_UserImage);
            db.AddInParameter(dbCommand, "Wx_Status", DbType.Byte, model.Wx_Status);
            db.AddInParameter(dbCommand, "Wx_MsgId", DbType.Int64, model.Wx_MsgId);
            db.AddInParameter(dbCommand, "Wx_MsgCreateDateTime", DbType.DateTime, model.Wx_MsgCreateDateTime);
            db.AddInParameter(dbCommand, "Wx_MsgContent", DbType.String, model.Wx_MsgContent);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.SYS_AdminUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SYS_AdminUser set ");
            strSql.Append("Dpt_Id=@Dpt_Id,");
            strSql.Append("Adn_UserName=@Adn_UserName,");
            strSql.Append("Adn_Password=@Adn_Password,");
            strSql.Append("Adn_Mobile=@Adn_Mobile,");
            strSql.Append("Adn_AddTime=@Adn_AddTime,");
            strSql.Append("Adn_Flag=@Adn_Flag,");
            strSql.Append("Adn_RealName=@Adn_RealName,");
            strSql.Append("Adn_SecurityID=@Adn_SecurityID,");
            strSql.Append("Adn_IsWorker=@Adn_IsWorker,");
            strSql.Append("Adn_SelfCard=@Adn_SelfCard,");
            strSql.Append("OpenId=@OpenId,");
            strSql.Append("Adn_IsConsultant=@Adn_IsConsultant,");
            strSql.Append("Wx_FakeId=@Wx_FakeId,");
            strSql.Append("Wx_NickName=@Wx_NickName,");
            strSql.Append("Wx_ReMarkName=@Wx_ReMarkName,");
            strSql.Append("Wx_Username=@Wx_Username,");
            strSql.Append("Wx_Signature=@Wx_Signature,");
            strSql.Append("Wx_Country=@Wx_Country,");
            strSql.Append("Wx_Province=@Wx_Province,");
            strSql.Append("Wx_City=@Wx_City,");
            strSql.Append("Wx_Sex=@Wx_Sex,");
            strSql.Append("Wx_GroupID=@Wx_GroupID,");
            strSql.Append("Wx_GroupName=@Wx_GroupName,");
            strSql.Append("Wx_UserImage=@Wx_UserImage,");
            strSql.Append("Wx_Status=@Wx_Status,");
            strSql.Append("Wx_MsgId=@Wx_MsgId,");
            strSql.Append("Wx_MsgCreateDateTime=@Wx_MsgCreateDateTime,");
            strSql.Append("Wx_MsgContent=@Wx_MsgContent");
            strSql.Append(" where Adn_Id=@Adn_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, model.Adn_Id);
            db.AddInParameter(dbCommand, "Dpt_Id", DbType.Int32, model.Dpt_Id);
            db.AddInParameter(dbCommand, "Adn_UserName", DbType.AnsiString, model.Adn_UserName);
            db.AddInParameter(dbCommand, "Adn_Password", DbType.AnsiString, model.Adn_Password);
            db.AddInParameter(dbCommand, "Adn_Mobile", DbType.AnsiString, model.Adn_Mobile);
            db.AddInParameter(dbCommand, "Adn_AddTime", DbType.DateTime, model.Adn_AddTime);
            db.AddInParameter(dbCommand, "Adn_Flag", DbType.Int32, model.Adn_Flag);
            db.AddInParameter(dbCommand, "Adn_RealName", DbType.String, model.Adn_RealName);
            db.AddInParameter(dbCommand, "Adn_SecurityID", DbType.AnsiString, model.Adn_SecurityID);
            db.AddInParameter(dbCommand, "Adn_IsWorker", DbType.Byte, model.Adn_IsWorker);
            db.AddInParameter(dbCommand, "Adn_SelfCard", DbType.AnsiString, model.Adn_SelfCard);
            db.AddInParameter(dbCommand, "OpenId", DbType.AnsiString, model.OpenId);
            db.AddInParameter(dbCommand, "Adn_IsConsultant", DbType.Int32, model.Adn_IsConsultant);
            db.AddInParameter(dbCommand, "Wx_FakeId", DbType.String, model.Wx_FakeId);
            db.AddInParameter(dbCommand, "Wx_NickName", DbType.String, model.Wx_NickName);
            db.AddInParameter(dbCommand, "Wx_ReMarkName", DbType.String, model.Wx_ReMarkName);
            db.AddInParameter(dbCommand, "Wx_Username", DbType.String, model.Wx_Username);
            db.AddInParameter(dbCommand, "Wx_Signature", DbType.String, model.Wx_Signature);
            db.AddInParameter(dbCommand, "Wx_Country", DbType.String, model.Wx_Country);
            db.AddInParameter(dbCommand, "Wx_Province", DbType.String, model.Wx_Province);
            db.AddInParameter(dbCommand, "Wx_City", DbType.String, model.Wx_City);
            db.AddInParameter(dbCommand, "Wx_Sex", DbType.Byte, model.Wx_Sex);
            db.AddInParameter(dbCommand, "Wx_GroupID", DbType.Int32, model.Wx_GroupID);
            db.AddInParameter(dbCommand, "Wx_GroupName", DbType.String, model.Wx_GroupName);
            db.AddInParameter(dbCommand, "Wx_UserImage", DbType.String, model.Wx_UserImage);
            db.AddInParameter(dbCommand, "Wx_Status", DbType.Byte, model.Wx_Status);
            db.AddInParameter(dbCommand, "Wx_MsgId", DbType.Int64, model.Wx_MsgId);
            db.AddInParameter(dbCommand, "Wx_MsgCreateDateTime", DbType.DateTime, model.Wx_MsgCreateDateTime);
            db.AddInParameter(dbCommand, "Wx_MsgContent", DbType.String, model.Wx_MsgContent);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Adn_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_AdminUser ");
            strSql.Append(" where Adn_Id=@Adn_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, Adn_Id);
            int rows = db.ExecuteNonQuery(dbCommand);

            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Adn_Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SYS_AdminUser ");
            strSql.Append(" where Adn_Id in (" + Adn_Idlist + ")  ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            int rows = db.ExecuteNonQuery(dbCommand);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SYS_AdminUser GetModel(int Adn_Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Adn_Id,Dpt_Id,Adn_UserName,Adn_Password,Adn_Mobile,Adn_AddTime,Adn_Flag,Adn_RealName,Adn_SecurityID,Adn_IsWorker,Adn_SelfCard,OpenId,Adn_IsConsultant,Wx_FakeId,Wx_NickName,Wx_ReMarkName,Wx_Username,Wx_Signature,Wx_Country,Wx_Province,Wx_City,Wx_Sex,Wx_GroupID,Wx_GroupName,Wx_UserImage,Wx_Status,Wx_MsgId,Wx_MsgCreateDateTime,Wx_MsgContent from SYS_AdminUser ");
            strSql.Append(" where Adn_Id=@Adn_Id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_Id", DbType.Int32, Adn_Id);
            Model.SYS_AdminUser model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.SYS_AdminUser DataRowToModel(DataRow row)
        {
            Model.SYS_AdminUser model = new Model.SYS_AdminUser();
            if (row != null)
            {
                if (row["Adn_Id"] != null && row["Adn_Id"].ToString() != "")
                {
                    model.Adn_Id = int.Parse(row["Adn_Id"].ToString());
                }
                if (row["Dpt_Id"] != null && row["Dpt_Id"].ToString() != "")
                {
                    model.Dpt_Id = int.Parse(row["Dpt_Id"].ToString());
                }
                if (row["Adn_UserName"] != null)
                {
                    model.Adn_UserName = row["Adn_UserName"].ToString();
                }
                if (row["Adn_Password"] != null)
                {
                    model.Adn_Password = row["Adn_Password"].ToString();
                }
                if (row["Adn_Mobile"] != null)
                {
                    model.Adn_Mobile = row["Adn_Mobile"].ToString();
                }
                if (row["Adn_AddTime"] != null && row["Adn_AddTime"].ToString() != "")
                {
                    model.Adn_AddTime = DateTime.Parse(row["Adn_AddTime"].ToString());
                }
                if (row["Adn_Flag"] != null && row["Adn_Flag"].ToString() != "")
                {
                    model.Adn_Flag = int.Parse(row["Adn_Flag"].ToString());
                }
                if (row["Adn_RealName"] != null)
                {
                    model.Adn_RealName = row["Adn_RealName"].ToString();
                }
                if (row["Adn_SecurityID"] != null)
                {
                    model.Adn_SecurityID = row["Adn_SecurityID"].ToString();
                }
                if (row["Adn_IsWorker"] != null && row["Adn_IsWorker"].ToString() != "")
                {
                    model.Adn_IsWorker = int.Parse(row["Adn_IsWorker"].ToString());
                }
                if (row["Adn_SelfCard"] != null)
                {
                    model.Adn_SelfCard = row["Adn_SelfCard"].ToString();
                }
                if (row["OpenId"] != null)
                {
                    model.OpenId = row["OpenId"].ToString();
                }
                if (row["Adn_IsConsultant"] != null && row["Adn_IsConsultant"].ToString() != "")
                {
                    model.Adn_IsConsultant = int.Parse(row["Adn_IsConsultant"].ToString());
                }
                if (row["Wx_FakeId"] != null)
                {
                    model.Wx_FakeId = row["Wx_FakeId"].ToString();
                }
                if (row["Wx_NickName"] != null)
                {
                    model.Wx_NickName = row["Wx_NickName"].ToString();
                }
                if (row["Wx_ReMarkName"] != null)
                {
                    model.Wx_ReMarkName = row["Wx_ReMarkName"].ToString();
                }
                if (row["Wx_Username"] != null)
                {
                    model.Wx_Username = row["Wx_Username"].ToString();
                }
                if (row["Wx_Signature"] != null)
                {
                    model.Wx_Signature = row["Wx_Signature"].ToString();
                }
                if (row["Wx_Country"] != null)
                {
                    model.Wx_Country = row["Wx_Country"].ToString();
                }
                if (row["Wx_Province"] != null)
                {
                    model.Wx_Province = row["Wx_Province"].ToString();
                }
                if (row["Wx_City"] != null)
                {
                    model.Wx_City = row["Wx_City"].ToString();
                }
                if (row["Wx_Sex"] != null && row["Wx_Sex"].ToString() != "")
                {
                    model.Wx_Sex = int.Parse(row["Wx_Sex"].ToString());
                }
                if (row["Wx_GroupID"] != null && row["Wx_GroupID"].ToString() != "")
                {
                    model.Wx_GroupID = int.Parse(row["Wx_GroupID"].ToString());
                }
                if (row["Wx_GroupName"] != null)
                {
                    model.Wx_GroupName = row["Wx_GroupName"].ToString();
                }
                if (row["Wx_UserImage"] != null)
                {
                    model.Wx_UserImage = row["Wx_UserImage"].ToString();
                }
                if (row["Wx_Status"] != null && row["Wx_Status"].ToString() != "")
                {
                    model.Wx_Status = int.Parse(row["Wx_Status"].ToString());
                }
                if (row["Wx_MsgId"] != null && row["Wx_MsgId"].ToString() != "")
                {
                    model.Wx_MsgId = long.Parse(row["Wx_MsgId"].ToString());
                }
                if (row["Wx_MsgCreateDateTime"] != null && row["Wx_MsgCreateDateTime"].ToString() != "")
                {
                    model.Wx_MsgCreateDateTime = DateTime.Parse(row["Wx_MsgCreateDateTime"].ToString());
                }
                if (row["Wx_MsgContent"] != null)
                {
                    model.Wx_MsgContent = row["Wx_MsgContent"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Adn_Id,Dpt_Id,Adn_UserName,Adn_Password,Adn_Mobile,Adn_AddTime,Adn_Flag,Adn_RealName,Adn_SecurityID,Adn_IsWorker,Adn_SelfCard,OpenId,Adn_IsConsultant,Wx_FakeId,Wx_NickName,Wx_ReMarkName,Wx_Username,Wx_Signature,Wx_Country,Wx_Province,Wx_City,Wx_Sex,Wx_GroupID,Wx_GroupName,Wx_UserImage,Wx_Status,Wx_MsgId,Wx_MsgCreateDateTime,Wx_MsgContent ");
            strSql.Append(" FROM SYS_AdminUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Adn_Id,Dpt_Id,Adn_UserName,Adn_Password,Adn_Mobile,Adn_AddTime,Adn_Flag,Adn_RealName,Adn_SecurityID,Adn_IsWorker,Adn_SelfCard,OpenId,Adn_IsConsultant,Wx_FakeId,Wx_NickName,Wx_ReMarkName,Wx_Username,Wx_Signature,Wx_Country,Wx_Province,Wx_City,Wx_Sex,Wx_GroupID,Wx_GroupName,Wx_UserImage,Wx_Status,Wx_MsgId,Wx_MsgCreateDateTime,Wx_MsgContent ");
            strSql.Append(" FROM SYS_AdminUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        //public int GetRecordCount(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) FROM SYS_AdminUser ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    object obj = DbHelperSQL.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Adn_Id desc");
            }
            strSql.Append(")AS Row, T.*  from SYS_AdminUser T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            return db.ExecuteDataSet(dbCommand);
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "SYS_AdminUser");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "Adn_Id");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }*/

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// </summary>
        public List<Model.SYS_AdminUser> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Adn_Id,Dpt_Id,Adn_UserName,Adn_Password,Adn_Mobile,Adn_AddTime,Adn_Flag,Adn_RealName,Adn_SecurityID,Adn_IsWorker,Adn_SelfCard,OpenId,Adn_IsConsultant,Wx_FakeId,Wx_NickName,Wx_ReMarkName,Wx_Username,Wx_Signature,Wx_Country,Wx_Province,Wx_City,Wx_Sex,Wx_GroupID,Wx_GroupName,Wx_UserImage,Wx_Status,Wx_MsgId,Wx_MsgCreateDateTime,Wx_MsgContent ");
            strSql.Append(" FROM SYS_AdminUser ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<Model.SYS_AdminUser> list = new List<Model.SYS_AdminUser>();
            Database db = DatabaseFactory.CreateDatabase();
            using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }


        /// <summary>
        /// 对象实体绑定数据
        /// </summary>
        public Model.SYS_AdminUser ReaderBind(IDataReader dataReader)
        {
            Model.SYS_AdminUser model = new Model.SYS_AdminUser();
            object ojb;
            ojb = dataReader["Adn_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Adn_Id = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Dpt_Id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Dpt_Id = Convert.ToInt32(ojb);
            }
            model.Adn_UserName = dataReader["Adn_UserName"].ToString();
            model.Adn_Password = dataReader["Adn_Password"].ToString();
            model.Adn_Mobile = dataReader["Adn_Mobile"].ToString();
            ojb = dataReader["Adn_AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Adn_AddTime = (DateTime)ojb;
            }
            ojb = dataReader["Adn_Flag"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Adn_Flag = Convert.ToInt32(ojb);
            }
            model.Adn_RealName = dataReader["Adn_RealName"].ToString();
            model.Adn_SecurityID = dataReader["Adn_SecurityID"].ToString();
            ojb = dataReader["Adn_IsWorker"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Adn_IsWorker = Convert.ToInt32(ojb);
            }
            model.Adn_SelfCard = dataReader["Adn_SelfCard"].ToString();
            model.OpenId = dataReader["OpenId"].ToString();
            ojb = dataReader["Adn_IsConsultant"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Adn_IsConsultant = Convert.ToInt32(ojb);
            }
            model.Wx_FakeId = dataReader["Wx_FakeId"].ToString();
            model.Wx_NickName = dataReader["Wx_NickName"].ToString();
            model.Wx_ReMarkName = dataReader["Wx_ReMarkName"].ToString();
            model.Wx_Username = dataReader["Wx_Username"].ToString();
            model.Wx_Signature = dataReader["Wx_Signature"].ToString();
            model.Wx_Country = dataReader["Wx_Country"].ToString();
            model.Wx_Province = dataReader["Wx_Province"].ToString();
            model.Wx_City = dataReader["Wx_City"].ToString();
            ojb = dataReader["Wx_Sex"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Wx_Sex = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Wx_GroupID"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Wx_GroupID = Convert.ToInt32(ojb);
            }
            model.Wx_GroupName = dataReader["Wx_GroupName"].ToString();
            model.Wx_UserImage = dataReader["Wx_UserImage"].ToString();
            ojb = dataReader["Wx_Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Wx_Status = Convert.ToInt32(ojb);
            }
            ojb = dataReader["Wx_MsgId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Wx_MsgId = Convert.ToInt64(ojb);
            }
            ojb = dataReader["Wx_MsgCreateDateTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Wx_MsgCreateDateTime = (DateTime)ojb;
            }
            model.Wx_MsgContent = dataReader["Wx_MsgContent"].ToString();
            return model;
        }

        #endregion  Method

        #region

        /// <summary>
        /// 是否存在openId
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public bool Exists(string openId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_AdminUser where openId=@openId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "openId", DbType.String, openId);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ExistsUserName(string adnUserName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_AdminUser where Adn_UserName=@Adn_UserName ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "Adn_UserName", DbType.String, adnUserName);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 根据openId获取user
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public Model.SYS_AdminUser GetModel(string openId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from SYS_AdminUser ");
            strSql.Append(" where openId=@openId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "openId", DbType.String, openId);
            Model.SYS_AdminUser model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string userName, string mobile, int uStatus, int isWorker)
        {
            StringBuilder stmtStr = new StringBuilder();
            stmtStr.Append("select a.*,b.Dpt_Name, ");
            stmtStr.Append(" case Adn_Flag when 1 then '已审核' when 0 then '未审核' end  as Adn_Flag");
            stmtStr.Append(" from SYS_AdminUser a left join SYS_DepartmentInfo b on a.Dpt_Id = b.Dpt_Id  ");
            stmtStr.Append(" where Adn_IsWorker=" + isWorker.ToString() + " and a.Adn_RealName like '%" + userName + "%' and a.Adn_Mobile like '%" + mobile + "%' ");
            if (uStatus < 2)
            {
                stmtStr.Append(" and Adn_Flag=" + uStatus.ToString());
            }
            stmtStr.Append(" order by a.Adn_AddTime desc ");
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, stmtStr.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public string GetList(string userName, int uStatus, string dpt_id)
        {
            StringBuilder stmtStr = new StringBuilder();
            stmtStr.Append("select row_number() over(order by Adn_Id DESC) as rownum, Adn_Id,Adn_UserName,Adn_Mobile,Adn_AddTime,Adn_RealName,Adn_SelfCard,b.Dpt_Name, ");
            stmtStr.Append(" case Adn_Flag when 1 then '已审核' when 0 then '未审核' end  as Adn_Flag ,");
            stmtStr.Append(" case Adn_IsConsultant when 1 then '是' when 0 then '否' end  as Adn_IsConsultant");
            stmtStr.Append(" from SYS_AdminUser a left join SYS_DepartmentInfo b on a.Dpt_Id = b.Dpt_Id  ");
            stmtStr.Append(" where a.Adn_RealName like '%" + userName.Trim() + "%'");
            if (uStatus < 2)
            {
                stmtStr.Append(" and a.Adn_Flag=" + uStatus.ToString());
            }
            if (dpt_id != "")
            {
                stmtStr.Append(" and a.Dpt_id in ( " + dpt_id + ")");
            }
            return stmtStr.ToString();
        }

        /// <summary>
        /// 获得置业顾问数据列表
        /// </summary>
        public DataSet GetListConsultant(string userName, int uStatus, int isWorker, int isConsultant, string adn_ids)
        {
            StringBuilder stmtStr = new StringBuilder();
            stmtStr.Append("select Adn_Id,Adn_UserName,Adn_UserName,Adn_Mobile,Adn_AddTime,Adn_RealName,Adn_SelfCard,b.Dpt_Name, ");
            stmtStr.Append(" case Adn_Flag when 1 then '已审核' when 0 then '未审核' end  as Adn_Flag ,");
            stmtStr.Append(" case Adn_IsConsultant when 1 then '是' when 0 then '否' end  as Adn_IsConsultant");
            stmtStr.Append(" from SYS_AdminUser a left join SYS_DepartmentInfo b on a.Dpt_Id = b.Dpt_Id  ");
            stmtStr.Append(" where Adn_IsWorker=" + isWorker.ToString() + " and a.Adn_RealName like '%" + userName.Trim() + "%'  and a.Adn_IsConsultant=" + isConsultant.ToString());
            if (uStatus < 2)
            {
                stmtStr.Append(" and Adn_Flag=" + uStatus.ToString());
            }
            if (adn_ids != "")
            {
                stmtStr.Append(" and Adn_Id not in (" + adn_ids + ") ");
            }

            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, stmtStr.ToString());
        }
        /// <summary>
        /// 获得业务员数据列表
        /// </summary>
        public DataSet GetListConsultantUser(string userName, int uStatus, int isWorker, int isConsultant, string adn_conid)
        {
            StringBuilder stmtStr = new StringBuilder();
            stmtStr.Append("select Adn_Id,Adn_UserName,Adn_UserName,Adn_Mobile,Adn_AddTime,Adn_RealName,Adn_SelfCard,b.Dpt_Name, ");
            stmtStr.Append(" case Adn_Flag when 1 then '已审核' when 0 then '未审核' end  as Adn_Flag ,");
            stmtStr.Append(" case Adn_IsConsultant when 1 then '是' when 0 then '否' end  as Adn_IsConsultant");
            stmtStr.Append(" from SYS_AdminUser a left join SYS_DepartmentInfo b on a.Dpt_Id = b.Dpt_Id  ");
            stmtStr.Append(" where Adn_IsWorker=" + isWorker.ToString() + " and a.Adn_RealName like '%" + userName + "%'  and a.Adn_IsConsultant=" + isConsultant.ToString() + "  and a.Adn_Id in (" + adn_conid + ")");
            if (uStatus < 2)
            {
                stmtStr.Append(" and Adn_Flag=" + uStatus.ToString());
            }

            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, stmtStr.ToString());
        }

        /// <summary>
        /// 获得业务员数据列表
        /// </summary>
        public DataSet GetListConsUser(string userName, int uStatus, int isWorker, int isConsultant, string adn_conid)
        {
            StringBuilder stmtStr = new StringBuilder();
            stmtStr.Append("select Adn_Id,Adn_UserName,Adn_UserName,Adn_Mobile,Adn_AddTime,Adn_RealName,Adn_SelfCard,b.Dpt_Name, ");
            stmtStr.Append(" case Adn_Flag when 1 then '已审核' when 0 then '未审核' end  as Adn_Flag ,");
            stmtStr.Append(" case Adn_IsConsultant when 1 then '是' when 0 then '否' end  as Adn_IsConsultant");
            stmtStr.Append(" from SYS_AdminUser a left join SYS_DepartmentInfo b on a.Dpt_Id = b.Dpt_Id  ");
            stmtStr.Append(" where Adn_IsWorker=" + isWorker.ToString() + " and a.Adn_RealName like '%" + userName + "%'  and a.Adn_IsConsultant=" + isConsultant.ToString() + "  and a.Adn_Id not in (" + adn_conid + ")");
            if (uStatus < 2)
            {
                stmtStr.Append(" and Adn_Flag=" + uStatus.ToString());
            }

            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, stmtStr.ToString());
        }
        public int CheckSales(int adn_Id)
        {
            try
            {
                int res = 0;
                Database db = DatabaseUtiles.DB;
                DbCommand command = db.GetStoredProcCommand("Check_Sales");
                db.AddInParameter(command, "adn_Id", DbType.Int32, adn_Id);
                res = db.ExecuteNonQuery(command);
                return res;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 判断该功能页面是否对当前用户赋权
        /// </summary>
        /// <param name="pc_name"></param>
        /// <param name="adn_Id"></param>
        /// <returns></returns>
        public bool ExistsUsersPage(string pc_name, int adn_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from (select pc_id from dbo.SYS_RoleForPage where role_id in( ");
            strSql.Append("select role_Id from dbo.SYS_UserForRole where adn_id=@adn_Id)) a ");
            strSql.Append("where a.pc_id=(select pc_id from dbo.SYS_PageConfig where pc_name=@pc_name)");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "pc_name", DbType.String, pc_name);
            db.AddInParameter(dbCommand, "adn_Id", DbType.Int32, adn_Id);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Equals(obj, null)) || (Equals(obj, DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

