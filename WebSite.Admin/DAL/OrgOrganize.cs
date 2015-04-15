/**  版本信息模板在安装目录下，可自行修改。
* OrgOrganize.cs
*
* 功 能： N/A
* 类 名： OrgOrganize
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  12/24/2014 8:48:57 AM   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.


*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│

*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Admin.DAL
{
    /// <summary>
    /// 数据访问类:OrgOrganize
    /// </summary>
    public partial class OrgOrganize
    {
        public OrgOrganize()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long OrgId)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrgOrganize where OrgId=@OrgId ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, OrgId);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
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
        public long Add(Model.OrgOrganize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgOrganize(");
            strSql.Append("AreaId,OrgName,OrgAddress,OrgPhone,EnName,OrgFax,OrgType,OrgParentId,AddTime,Status,EndDate)");

            strSql.Append(" values (");
            strSql.Append("@AreaId,@OrgName,@OrgAddress,@OrgPhone,@EnName,@OrgFax,@OrgType,@OrgParentId,@AddTime,@Status,@EndDate)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString, model.AreaId);
            db.AddInParameter(dbCommand, "OrgName", DbType.String, model.OrgName);
            db.AddInParameter(dbCommand, "OrgAddress", DbType.String, model.OrgAddress);
            db.AddInParameter(dbCommand, "OrgPhone", DbType.AnsiString, model.OrgPhone);
            db.AddInParameter(dbCommand, "EnName", DbType.String, model.EnName);
            db.AddInParameter(dbCommand, "OrgFax", DbType.AnsiString, model.OrgFax);
            db.AddInParameter(dbCommand, "OrgType", DbType.Byte, model.OrgType);
            db.AddInParameter(dbCommand, "OrgParentId", DbType.Int64, model.OrgParentId);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, model.EndDate);
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
        public bool Update(Model.OrgOrganize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgOrganize set ");
            strSql.Append("AreaId=@AreaId,");
            strSql.Append("OrgName=@OrgName,");
            strSql.Append("OrgAddress=@OrgAddress,");
            strSql.Append("OrgPhone=@OrgPhone,");
            strSql.Append("EnName=@EnName,");
            strSql.Append("OrgFax=@OrgFax,");
            strSql.Append("OrgType=@OrgType,");
            strSql.Append("OrgParentId=@OrgParentId,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("Status=@Status,");
            strSql.Append("EndDate=@EndDate");
            strSql.Append(" where OrgId=@OrgId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, model.OrgId);
            db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString, model.AreaId);
            db.AddInParameter(dbCommand, "OrgName", DbType.String, model.OrgName);
            db.AddInParameter(dbCommand, "OrgAddress", DbType.String, model.OrgAddress);
            db.AddInParameter(dbCommand, "OrgPhone", DbType.AnsiString, model.OrgPhone);
            db.AddInParameter(dbCommand, "EnName", DbType.String, model.EnName);
            db.AddInParameter(dbCommand, "OrgFax", DbType.AnsiString, model.OrgFax);
            db.AddInParameter(dbCommand, "OrgType", DbType.Byte, model.OrgType);
            db.AddInParameter(dbCommand, "OrgParentId", DbType.Int64, model.OrgParentId);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, model.AddTime);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, model.Status);
            db.AddInParameter(dbCommand, "EndDate", DbType.DateTime, model.EndDate);
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
        public bool Delete(long OrgId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgOrganize ");
            strSql.Append(" where OrgId=@OrgId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, OrgId);
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
        public bool DeleteList(string OrgIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OrgOrganize ");
            strSql.Append(" where OrgId in (" + OrgIdlist + ")  ");
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
        public Model.OrgOrganize GetModel(long OrgId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrgId,AreaId,OrgName,OrgAddress,OrgPhone,EnName,OrgFax,OrgType,OrgParentId,AddTime,Status,EndDate from OrgOrganize ");
            strSql.Append(" where OrgId=@OrgId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, OrgId);
            Model.OrgOrganize model = null;
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
        public Model.OrgOrganize DataRowToModel(DataRow row)
        {
            Model.OrgOrganize model = new Model.OrgOrganize();
            if (row != null)
            {
                if (row["OrgId"] != null && row["OrgId"].ToString() != "")
                {
                    model.OrgId = Convert.ToInt64(row["OrgId"].ToString());
                }
                if (row["AreaId"] != null)
                {
                    model.AreaId = row["AreaId"].ToString();
                }
                if (row["OrgName"] != null)
                {
                    model.OrgName = row["OrgName"].ToString();
                }
                if (row["OrgAddress"] != null)
                {
                    model.OrgAddress = row["OrgAddress"].ToString();
                }
                if (row["OrgPhone"] != null)
                {
                    model.OrgPhone = row["OrgPhone"].ToString();
                }
                if (row["EnName"] != null)
                {
                    model.EnName = row["EnName"].ToString();
                }
                if (row["OrgFax"] != null)
                {
                    model.OrgFax = row["OrgFax"].ToString();
                }
                if (row["OrgType"] != null && row["OrgType"].ToString() != "")
                {
                    model.OrgType = Convert.ToInt32(row["OrgType"].ToString());
                }
                if (row["OrgParentId"] != null && row["OrgParentId"].ToString() != "")
                {
                    model.OrgParentId = Convert.ToInt64(row["OrgParentId"].ToString());
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = Convert.ToDateTime(row["AddTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = Convert.ToInt32(row["Status"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = Convert.ToDateTime(row["EndDate"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrgId,AreaId,OrgName,OrgAddress,OrgPhone,EnName,OrgFax,OrgType,OrgParentId,AddTime,Status,EndDate ");
            strSql.Append(" FROM OrgOrganize ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得前几行数据
        /// <param name="Top">int Top</param>
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetList(int Top, string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" OrgId,AreaId,OrgName,OrgAddress,OrgPhone,EnName,OrgFax,OrgType,OrgParentId,AddTime,Status,EndDate ");
            strSql.Append(" FROM OrgOrganize ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /*
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql=new StringBuilder();
            strSql.Append("select count(1) FROM OrgOrganize ");
            if(strWhere.Trim()!="")
            {
                strSql.Append(" where "+strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }*/
        /// <summary>
        /// 分页获取数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell  like写法:'%'+@Cell+'%' </param>
        /// <param name="orderby">string orderby</param>
        /// <param name="startIndex">开始页码</param>
        /// <param name="endIndex">结束页码</param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex, List<SqlParameter> parameters)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.OrgId desc");
            }
            strSql.Append(")AS Row, T.*  from OrgOrganize T ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "OrgOrganize");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "OrgId");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得数据列表（比DataSet效率高，推荐使用）
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public List<Model.OrgOrganize> GetListArray(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrgId,AreaId,OrgName,OrgAddress,OrgPhone,EnName,OrgFax,OrgType,OrgParentId,AddTime,Status,EndDate ");
            strSql.Append(" FROM OrgOrganize ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            List<Model.OrgOrganize> list = new List<Model.OrgOrganize>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
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
        public Model.OrgOrganize ReaderBind(IDataReader dataReader)
        {
            Model.OrgOrganize model = new Model.OrgOrganize();
            object ojb;
            ojb = dataReader["OrgId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrgId = Convert.ToInt64(ojb);
            }
            model.AreaId = dataReader["AreaId"].ToString();
            model.OrgName = dataReader["OrgName"].ToString();
            model.OrgAddress = dataReader["OrgAddress"].ToString();
            model.OrgPhone = dataReader["OrgPhone"].ToString();
            model.EnName = dataReader["EnName"].ToString();
            model.OrgFax = dataReader["OrgFax"].ToString();
            ojb = dataReader["OrgType"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrgType = Convert.ToInt32(ojb);
            }
            ojb = dataReader["OrgParentId"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.OrgParentId = Convert.ToInt64(ojb);
            }
            ojb = dataReader["AddTime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.AddTime = Convert.ToDateTime(ojb);
            }
            ojb = dataReader["Status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Status = Convert.ToInt32(ojb);
            }
            ojb = dataReader["EndDate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EndDate = Convert.ToDateTime(ojb);
            }
            return model;
        }

        #endregion  Method

        #region  扩展方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.OrgOrganize GetModel(string strWhere, List<SqlParameter> parameters)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from OrgOrganize ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            Model.OrgOrganize model = null;
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
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int iid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Infos join TempInfo on TempInfo.TIID=Infos.TIID join InfoType on InfoType.ITID=TempInfo.ITID join StaPackage on StaPackage.SPID=InfoType.SPID join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId where OrgOrganize.OrgName='全国热点' and Infos.IID=@IID ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "IID", DbType.Int64, iid);
            int cmdresult;
            object obj = db.ExecuteScalar(dbCommand);
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
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


        #region

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ALID, string LName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OrgOrganize where OrgName=@OrgName ");
            if (ALID != 0)
            {
                strSql.Append(" and OrgId!=" + ALID);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgName", DbType.String, LName);
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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DelList(string BrandIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ProductBrand ");
            strSql.Append(" where BrandId in (select * from SplitToTable(@BrandId,','))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            var parameter = new SqlParameter("@BrandId", DbType.AnsiString);
            parameter.Value = BrandIdlist;
            dbCommand.Parameters.Add(parameter);
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
        /// 添加品牌信息事务方法
        /// </summary>
        /// <param name="brandName">品牌信息名称</param>
        /// <param name="brandIds">品牌Id</param>
        /// <returns></returns>
        public bool InsertProBrands(string brandName, string brandIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ProductBrand(");
            strSql.Append("BrandName,addtime)");

            strSql.Append(" values (");
            strSql.Append("@BrandName,@addtime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "BrandName", DbType.AnsiString, brandName);
            db.AddInParameter(dbCommand, "addtime", DbType.DateTime, DateTime.Now);
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    object obj = db.ExecuteScalar(dbCommand, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("insert into [ProductBrandType] ([BrandId],[PTId]) select " + obj + ",fieldvalue from dbo.SplitToTable('" + brandIds + "',',')");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.ExecuteNonQuery(dbCommand2, trans);
                    trans.Commit();

                    result = true;
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        /// <summary>
        /// 修改品牌信息事务方法
        /// </summary>
        /// <param name="brandId">品牌Id</param>
        /// <param name="brandName">品牌信息名称</param>
        /// <param name="brandIds">品牌Id</param>
        /// <returns></returns>
        public bool UpdateProBrands(string brandId, string brandName, string brandIds)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ProductBrand");
            strSql.Append(" set BrandName=@BrandName ");
            strSql.Append(" where BrandId=@BrandId");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "BrandName", DbType.AnsiString, brandName);
            db.AddInParameter(dbCommand, "BrandId", DbType.Int32, brandId);
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    object obj = db.ExecuteScalar(dbCommand, trans);
                    StringBuilder strSql3 = new StringBuilder();
                    strSql3.Append("delete from  ProductBrandType where BrandId=@BrandId");
                    DbCommand dbCommandDel = db.GetSqlStringCommand(strSql3.ToString());
                    db.AddInParameter(dbCommandDel, "BrandId", DbType.Int32, brandId);
                    object objDel = db.ExecuteNonQuery(dbCommandDel, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("insert into [ProductBrandType] ([BrandId],[PTId]) select " + brandId + ",fieldvalue from dbo.SplitToTable('" + brandIds + "',',')");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.ExecuteNonQuery(dbCommand2, trans);
                    trans.Commit();
                    result = true;
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        /// <summary>
        /// 新增工作站事务方法
        /// </summary>
        /// <param name="aId">区域编号</param>
        /// <param name="name">工作站名称</param>
        /// <param name="size">规模</param>
        /// <param name="area">面积</param>
        /// <param name="addr">工作站地址</param>
        /// <param name="manager">负责人</param>
        /// <param name="managerPhone">负责人电话</param>
        /// <param name="phone">工作站电话</param>
        /// <returns></returns>
        public int Add(string aId, string name, string size, string area, string addr, string manager, string managerPhone, string phone, int orId)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgOrganize(");
            strSql.Append("AreaId,OrgName,OrgAddress,OrgPhone,OrgFax,OrgType,OrgParentId,AddTime,Status)");

            strSql.Append(" values (");
            strSql.Append("@AreaId,@OrgName,@OrgAddress,@OrgPhone,@OrgFax,@OrgType,@OrgParentId,@AddTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString, aId);
            db.AddInParameter(dbCommand, "OrgName", DbType.String, name);
            db.AddInParameter(dbCommand, "OrgAddress", DbType.String, addr);
            db.AddInParameter(dbCommand, "OrgPhone", DbType.AnsiString, phone);
            db.AddInParameter(dbCommand, "OrgFax", DbType.AnsiString, "");
            db.AddInParameter(dbCommand, "OrgType", DbType.Byte, 5);
            db.AddInParameter(dbCommand, "OrgParentId", DbType.Int64, 0);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, 1);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    var oId = db.ExecuteScalar(dbCommand, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("insert into OrgWorkStation(");
                    strSql2.Append("OrgId,Size,Area,Manager,ManagerPhone)");

                    strSql2.Append(" values (");
                    strSql2.Append("@OrgId,@Size,@Area,@Manager,@ManagerPhone)");
                    strSql2.Append(";select @@IDENTITY");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.AddInParameter(dbCommand2, "OrgId", DbType.Int64, oId);
                    db.AddInParameter(dbCommand2, "Size", DbType.String, size);
                    db.AddInParameter(dbCommand2, "Area", DbType.String, area);
                    db.AddInParameter(dbCommand2, "Manager", DbType.String, manager);
                    db.AddInParameter(dbCommand2, "ManagerPhone", DbType.AnsiString, managerPhone);
                    object obj = db.ExecuteScalar(dbCommand2, trans);
                    if (!int.TryParse(obj.ToString(), out result))
                    {
                        trans.Rollback();
                        return 0;
                    }
                    StringBuilder strSql3 = new StringBuilder();
                    strSql3.Append("insert into SWCompany(");
                    strSql3.Append("SWOrgId,COrgId)");

                    strSql3.Append(" values (");
                    strSql3.Append("@SWOrgId,@COrgId)");
                    DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
                    db.AddInParameter(dbCommand3, "SWOrgId", DbType.Int32, oId);
                    db.AddInParameter(dbCommand3, "COrgId", DbType.Int32, orId);
                    db.ExecuteScalar(dbCommand3, trans);
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }


        /// <summary>
        /// 更新工作站事务方法
        /// </summary>
        /// <param name="dt">dataTable</param>
        /// <returns></returns>
        public bool UpDateOrgWorStaTran(DataTable dt, string orgId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgOrganize set ");
            strSql.Append("OrgName=@OrgName,");
            strSql.Append("OrgAddress=@OrgAddress,");
            strSql.Append("OrgPhone=@OrgPhone,");
            strSql.Append("OrgFax=@OrgFax,");
            strSql.Append("OrgType=@OrgType,");
            strSql.Append("OrgParentId=@OrgParentId ");
            strSql.Append(" where OrgId=@OrgId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, dt.Rows[0]["OrgId"]);
            db.AddInParameter(dbCommand, "OrgName", DbType.String, dt.Rows[0]["OrgName"]);
            db.AddInParameter(dbCommand, "OrgAddress", DbType.String, dt.Rows[0]["OrgAddress"]);
            db.AddInParameter(dbCommand, "OrgPhone", DbType.AnsiString, dt.Rows[0]["OrgPhone"]);
            db.AddInParameter(dbCommand, "OrgFax", DbType.AnsiString, dt.Rows[0]["OrgFax"]);
            db.AddInParameter(dbCommand, "OrgType", DbType.Byte, dt.Rows[0]["OrgType"]);
            db.AddInParameter(dbCommand, "OrgParentId", DbType.Int64, dt.Rows[0]["OrgParentId"]);
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbCommand, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("update OrgWorkStation set ");
                    strSql2.Append("Size=@Size,");
                    strSql2.Append("Area=@Area,");
                    strSql2.Append("Manager=@Manager,");
                    strSql2.Append("ManagerPhone=@ManagerPhone");
                    strSql2.Append(" where OrgId=@OrgId ");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.AddInParameter(dbCommand2, "OrgId", DbType.Int64, dt.Rows[0]["OrgId"]);
                    db.AddInParameter(dbCommand2, "Size", DbType.String, dt.Rows[0]["Size"]);
                    db.AddInParameter(dbCommand2, "Area", DbType.String, dt.Rows[0]["Area"]);
                    db.AddInParameter(dbCommand2, "Manager", DbType.String, dt.Rows[0]["Manager"]);
                    db.AddInParameter(dbCommand2, "ManagerPhone", DbType.AnsiString, dt.Rows[0]["ManagerPhone"]);
                    db.ExecuteNonQuery(dbCommand2, trans);
                    SWCompany swcDal = new SWCompany();
                    Model.SWCompany swcInfo = swcDal.GetModelBySWOrgId(dt.Rows[0]["OrgId"].ToString());
                    StringBuilder strSql3 = new StringBuilder();
                    if (swcInfo != null)
                    {
                        strSql3.Append("Update  SWCompany set COrgId=@COrgId where SWOrgId=@SWOrgId");
                        DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
                        db.AddInParameter(dbCommand3, "SWOrgId", DbType.Int32, dt.Rows[0]["OrgId"]);
                        db.AddInParameter(dbCommand3, "COrgId", DbType.Int32, orgId);
                        db.ExecuteScalar(dbCommand3, trans);
                    }
                    else
                    {
                        strSql3.Append("insert into SWCompany(");
                        strSql3.Append("SWOrgId,COrgId)");

                        strSql3.Append(" values (");
                        strSql3.Append("@SWOrgId,@COrgId)");
                        DbCommand dbCommand3 = db.GetSqlStringCommand(strSql3.ToString());
                        db.AddInParameter(dbCommand3, "SWOrgId", DbType.Int32, dt.Rows[0]["OrgId"]);
                        db.AddInParameter(dbCommand3, "COrgId", DbType.Int32, orgId);
                        db.ExecuteScalar(dbCommand3, trans);
                    }

                    trans.Commit();
                    result = true;
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        /// <summary>
        /// 删除公司信息方法
        /// </summary>
        /// <param name="orgId">orgId</param>
        /// <returns></returns>
        public bool DelOrgWorStaTran(string orgId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgOrganize ");
            strSql.Append(" set Status=0 ");
            strSql.Append(" where OrgId in (select * from dbo.SplitToTable('" + orgId + "',','))");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    object objDel = db.ExecuteNonQuery(dbCommand, trans);
                    //StringBuilder strSql2 = new StringBuilder();
                    //strSql2.Append("update OrgEmployees ");
                    //strSql2.Append(" set Status=0 ");
                    //strSql2.Append(" where EmplId in (select * from dbo.SplitToTable('" + orgId + "',','))");
                    //DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    //db.ExecuteNonQuery(dbCommand2, trans);
                    trans.Commit();
                    result = true;
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        /// <summary>
        /// 获得工作站数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetWorStaList(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select row_number() over(order by  oo.Addtime desc,oo.OrgId DESC) as rownum,oo.* FROM OrgOrganize oo  ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 获得厂家数据列表
        /// <param name="strWhere">查询条件 Status=@Status and Cell=@Cell order by CreateDate Desc  like写法:'%'+@Cell+'%' </param>
        /// <param name="parameters">List<SqlParameter> parameters</param>
        /// </summary>
        public DataSet GetSupList(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select row_number() over(order by  oo.Addtime desc,oo.OrgId DESC) as rownum,oo.*,opi.BankAccount,opi.BankName,opi.BankAddress,opi.Manager,opi.ManagerPhone,opi.ProviderType FROM OrgOrganize oo join OrgProviderInfo opi on opi.[OrgId]=oo.[OrgId] ");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// 更新厂家事务方法
        /// </summary>
        /// <param name="dt">dataTable</param>
        /// <returns></returns>
        public bool UpDateOrgSupTran(DataTable dt)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OrgOrganize set ");
            strSql.Append("OrgName=@OrgName,");
            strSql.Append("OrgAddress=@OrgAddress,");
            strSql.Append("OrgPhone=@OrgPhone,");
            strSql.Append("OrgFax=@OrgFax,");
            strSql.Append("OrgType=@OrgType,");
            strSql.Append("OrgParentId=@OrgParentId ");
            strSql.Append(" where OrgId=@OrgId ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "OrgId", DbType.Int64, dt.Rows[0]["OrgId"]);
            db.AddInParameter(dbCommand, "OrgName", DbType.String, dt.Rows[0]["OrgName"]);
            db.AddInParameter(dbCommand, "OrgAddress", DbType.String, dt.Rows[0]["OrgAddress"]);
            db.AddInParameter(dbCommand, "OrgPhone", DbType.AnsiString, dt.Rows[0]["OrgPhone"]);
            db.AddInParameter(dbCommand, "OrgFax", DbType.AnsiString, dt.Rows[0]["OrgFax"]);
            db.AddInParameter(dbCommand, "OrgType", DbType.Byte, dt.Rows[0]["OrgType"]);
            db.AddInParameter(dbCommand, "OrgParentId", DbType.Int64, dt.Rows[0]["OrgParentId"]);
            bool result = false;
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    db.ExecuteNonQuery(dbCommand, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("update OrgProviderInfo set ");
                    strSql2.Append("BankAccount=@BankAccount,");
                    strSql2.Append("BankName=@BankName,");
                    strSql2.Append("BankAddress=@BankAddress,");
                    strSql2.Append("Manager=@Manager,");
                    strSql2.Append("ProviderType=@ProviderType,");
                    strSql2.Append("ManagerPhone=@ManagerPhone");
                    strSql2.Append(" where OrgId=@OrgId ");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.AddInParameter(dbCommand2, "OrgId", DbType.Int64, dt.Rows[0]["OrgId"]);
                    db.AddInParameter(dbCommand2, "BankAccount", DbType.String, dt.Rows[0]["BankAccount"]);
                    db.AddInParameter(dbCommand2, "BankName", DbType.String, dt.Rows[0]["BankName"]);
                    db.AddInParameter(dbCommand2, "BankAddress", DbType.String, dt.Rows[0]["BankAddress"]);
                    db.AddInParameter(dbCommand2, "Manager", DbType.String, dt.Rows[0]["Manager"]);
                    db.AddInParameter(dbCommand2, "ProviderType", DbType.String, dt.Rows[0]["ProviderType"]);
                    db.AddInParameter(dbCommand2, "ManagerPhone", DbType.AnsiString, dt.Rows[0]["ManagerPhone"]);
                    db.ExecuteNonQuery(dbCommand2, trans);
                    trans.Commit();
                    result = true;
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        /// <summary>
        /// 新增厂家事务方法
        /// </summary>
        /// <param name="aId">区域编号</param>
        /// <param name="name">工作站名称</param>
        /// <param name="bankAddress"></param>
        /// <param name="addr">工作站地址</param>
        /// <param name="manager">负责人</param>
        /// <param name="managerPhone">负责人电话</param>
        /// <param name="phone">工作站电话</param>
        /// <param name="bankAccount"></param>
        /// <param name="bankName"></param>
        /// <param name="providerType"></param>
        /// <returns></returns>
        public int AddSup(string aId, string name, string bankAccount, string bankName, string bankAddress, string addr, string manager, string managerPhone, string phone, string providerType)
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OrgOrganize(");
            strSql.Append("AreaId,OrgName,OrgAddress,OrgPhone,OrgFax,OrgType,OrgParentId,AddTime,Status)");

            strSql.Append(" values (");
            strSql.Append("@AreaId,@OrgName,@OrgAddress,@OrgPhone,@OrgFax,@OrgType,@OrgParentId,@AddTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "AreaId", DbType.AnsiString, aId);
            db.AddInParameter(dbCommand, "OrgName", DbType.String, name);
            db.AddInParameter(dbCommand, "OrgAddress", DbType.String, addr);
            db.AddInParameter(dbCommand, "OrgPhone", DbType.AnsiString, phone);
            db.AddInParameter(dbCommand, "OrgFax", DbType.AnsiString, "");
            db.AddInParameter(dbCommand, "OrgType", DbType.Byte, 3);
            db.AddInParameter(dbCommand, "OrgParentId", DbType.Int64, 0);
            db.AddInParameter(dbCommand, "AddTime", DbType.DateTime, DateTime.Now);
            db.AddInParameter(dbCommand, "Status", DbType.Byte, 1);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    var oId = db.ExecuteScalar(dbCommand, trans);
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("insert into OrgProviderInfo(");
                    strSql2.Append("OrgId,BankAccount,BankName,BankAddress,Manager,ManagerPhone,ProviderType,AddTime)");

                    strSql2.Append(" values (");
                    strSql2.Append("@OrgId,@BankAccount,@BankName,@BankAddress,@Manager,@ManagerPhone,@ProviderType,@AddTime1)");
                    strSql2.Append(";select @@IDENTITY");
                    DbCommand dbCommand2 = db.GetSqlStringCommand(strSql2.ToString());
                    db.AddInParameter(dbCommand2, "OrgId", DbType.Int64, oId);
                    db.AddInParameter(dbCommand2, "BankAccount", DbType.String, bankAccount);
                    db.AddInParameter(dbCommand2, "BankName", DbType.String, bankName);
                    db.AddInParameter(dbCommand2, "BankAddress", DbType.String, bankAddress);
                    db.AddInParameter(dbCommand2, "Manager", DbType.String, manager);
                    db.AddInParameter(dbCommand2, "ManagerPhone", DbType.AnsiString, managerPhone);
                    db.AddInParameter(dbCommand2, "ProviderType", DbType.AnsiString, providerType);
                    db.AddInParameter(dbCommand2, "AddTime1", DbType.DateTime, DateTime.Now);
                    object obj = db.ExecuteScalar(dbCommand2, trans);
                    if (!int.TryParse(obj.ToString(), out result))
                    {
                        trans.Rollback();
                        return 0;
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                }
                conn.Close();

                return result;
            }
        }

        public DataSet GetListArea(string strWhere, List<SqlParameter> parameters)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OrgId,a.AreaId,OrgName,OrgAddress,OrgPhone,OrgFax,OrgType,OrgParentId,AddTime,a.Status,b.AreaName ");
            strSql.Append(" FROM OrgOrganize a left join OrgArea b on a.AreaId=b.AreaId");
            Database db = DatabaseFactory.CreateDatabase();
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            if (parameters.Count > 0)
            {
                foreach (SqlParameter sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }
            }
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}

