using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using WebSite.Area.DAL;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Area.AJAX
{
    public partial class AddArea : WebPage
    {
        LandAttribute laDAL = new LandAttribute();        //创建DAL对象
        LandInfo liDAL = new LandInfo();        //创建DAL对象
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                var ATId = Request.QueryString["ATId"];           //编辑分类Id
                var detATId = Request.QueryString["detATId"];            //删除分类Id
                var ATName = HttpUtility.UrlDecode(Request.QueryString["ATName"]);         
                #region 删除分类
                if (!string.IsNullOrEmpty(detATId))
                {
                    #region 查询分类是否有品牌关联
                    string sqlWhere = "";
                    List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
                    sqlWhere = "  LId=@detATId ";
                    var parameter = new SqlParameter("@detATId", DbType.AnsiString);
                    parameter.Value = detATId;
                    parameters.Add(parameter);
                    DataSet dts = liDAL.GetList(sqlWhere, parameters);     //通过商品分类Id查找关系表数据
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("该分类已被内容使用，不能删除");
                        Response.End();
                    }
                    #endregion
                    #region 判断分类是否存在子分类
                    else
                    {
                        Response.Write(laDAL.Delete(Convert.ToInt32(detATId)) ? "删除成功" : "删除失败");
                        Response.End();
                    }
                    #endregion
                }
                #endregion
                #region  添加、修改、添加子分类
                else
                {
                    if (string.IsNullOrEmpty(ATName))
                    {
                        Response.Write("商品分类名称不能为空");
                        Response.End();
                    }

                    #region 修改商品分类
                    WebSite.Area.Model.LandAttribute laMdoel = new WebSite.Area.Model.LandAttribute();     //商品分类实体
                    if (!string.IsNullOrEmpty(ATId))
                    {
                        try
                        {
                            laMdoel = laDAL.GetModel(Convert.ToInt32(ATId));
                            if (laMdoel != null)
                            {
                                string sqlWhere = "";
                                List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
                                sqlWhere = "  LAName=@ATName and LAId!=@ATId ";  //查询条件
                                var parameter = new SqlParameter("@ATName", DbType.AnsiString);
                                parameter.Value = ATName;
                                parameters.Add(parameter);
                                var parameter1 = new SqlParameter("@ATId", DbType.AnsiString);
                                parameter1.Value = ATId;
                                parameters.Add(parameter1);
                                var ds = laDAL.GetList(sqlWhere, parameters);            //通过商品分类名称及商品Id查询商品分类名称是否存在
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Response.Write("该商品分类名称已存在");
                                    Response.End();
                                }
                                laMdoel.LAName = ATName;
                                Response.Write(laDAL.Update(laMdoel) ? "保存成功" : "保存失败");
                                Response.End();
                            }
                        }
                        catch (System.Threading.ThreadAbortException ex)
                        {
                            throw ex;
                        }
                        catch
                        {
                            Response.Write("保存失败");
                            Response.End();
                        }

                    }
                    #endregion
                    #region 添加子分类、添加分类
                    else
                    {
                        try
                        {
                            string sqlWhere = "";
                            List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
                            sqlWhere = "  LAName=@ATName  and LAId=@ATId ";
                            var parameter = new SqlParameter("@ATName", DbType.AnsiString);
                            parameter.Value = ATName;
                            parameters.Add(parameter);
                            var parameter1 = new SqlParameter("@ATId", DbType.AnsiString);
                            parameter1.Value = ATId;
                            parameters.Add(parameter1);
                            var ds = laDAL.GetList(sqlWhere, parameters);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Response.Write("该商品分类名称已存在");
                                Response.End();
                            }
                            laMdoel.LAName = ATName;    
                            Response.Write(laDAL.Add(laMdoel) > 0 ? "保存成功" : "保存失败");
                            Response.End();
                        }
                        catch (System.Threading.ThreadAbortException ex)
                        {
                            throw ex;
                        }
                        catch
                        {
                            Response.Write("保存失败");
                            Response.End();
                        }
                    }
                    #endregion
                }
                #endregion
            }
        }
    }
}