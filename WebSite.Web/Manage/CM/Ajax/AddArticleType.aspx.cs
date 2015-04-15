using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace WebSite.Web.Manage.CM.Ajax
{
    public partial class AddArticleType : System.Web.UI.Page
    {
        WebSite.CM.DAL.CMArticleType atDAL = new WebSite.CM.DAL.CMArticleType();        //创建商品分类DAL对象
        WebSite.CM.DAL.CMArticle aDAL = new WebSite.CM.DAL.CMArticle();        //创建商品品牌DAL对象
        protected void Page_Load(object sender, EventArgs e)
        {
            //VerifyPage("", false);
            if (!IsPostBack)
            {
                var ATId = Request.QueryString["ATId"];           //编辑分类Id
                var detATId = Request.QueryString["detATId"];            //删除商品分类Id
                var ATName = HttpUtility.UrlDecode(Request.QueryString["ATName"]);         //商品名称
                var DisplayCss = HttpUtility.UrlDecode(Request.QueryString["DisplayCss"]);         //商品名称
                #region 删除分类
                if (!string.IsNullOrEmpty(detATId))
                {
                    #region 查询分类是否有品牌关联
                    string sqlWhere = "";
                    List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
                    sqlWhere = "  ATId=@detATId ";
                    var parameter = new SqlParameter("@detATId", DbType.AnsiString);
                    parameter.Value = detATId;
                    parameters.Add(parameter);
                    DataSet dts = aDAL.GetList(sqlWhere, parameters);     //通过商品分类Id查找关系表数据
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("该类型已被内容使用，不能删除");
                        Response.End();
                    }
                    #endregion
                    #region 判断分类是否存在子分类
                    else
                    {
                        Response.Write(atDAL.Delete(Convert.ToInt32(detATId)) ? "删除成功" : "删除失败");
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
                        Response.Write("类型名称不能为空");
                        Response.End();
                    }

                    #region 修改商品分类
                    WebSite.CM.Model.CMArticleType atMdoel = new WebSite.CM.Model.CMArticleType();     //商品分类实体
                    if (!string.IsNullOrEmpty(ATId))
                    {
                        try
                        {
                            atMdoel = atDAL.GetModel(Convert.ToInt32(ATId));
                            if (atMdoel != null)
                            {
                                string sqlWhere = "";
                                List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
                                sqlWhere = "  ATName=@ATName and ATId!=@ATId ";  //查询条件
                                var parameter = new SqlParameter("@ATName", DbType.AnsiString);
                                parameter.Value = ATName;
                                parameters.Add(parameter);
                                var parameter1 = new SqlParameter("@ATId", DbType.AnsiString);
                                parameter1.Value = ATId;
                                parameters.Add(parameter1);
                                var ds = atDAL.GetList(sqlWhere, parameters);            //通过商品分类名称及商品Id查询商品分类名称是否存在
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Response.Write("该类型名称已存在");
                                    Response.End();
                                }
                                atMdoel.ATName = ATName;
                                atMdoel.DisplayCss = DisplayCss;
                                switch (DisplayCss)
                                {
                                    case "红色":
                                        atMdoel.ColorValue = "#b94a48";
                                        break;
                                    case "黄色":
                                        atMdoel.ColorValue = "#f89406";
                                        break;
                                    case "绿色":
                                        atMdoel.ColorValue = "#468847";
                                        break;
                                }
                                atMdoel.DisplayCss = DisplayCss;
                                Response.Write(atDAL.Update(atMdoel) ? "保存成功" : "保存失败");
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
                            sqlWhere = "  ATName=@ATName  and ATId=@ATId ";
                            var parameter = new SqlParameter("@ATName", DbType.AnsiString);
                            parameter.Value = ATName;
                            parameters.Add(parameter);
                            var parameter1 = new SqlParameter("@ATId", DbType.AnsiString);
                            parameter1.Value = ATId;
                            parameters.Add(parameter1);
                            var ds = atDAL.GetList(sqlWhere, parameters);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Response.Write("该类型名称已存在");
                                Response.End();
                            }
                            atMdoel.ATName = ATName;    //商品分类名称
                            atMdoel.DisplayCss = DisplayCss;
                            switch (DisplayCss)
                            {
                                case "红色":
                                    atMdoel.ColorValue = "#b94a48";
                                    break;
                                case "黄色":
                                    atMdoel.ColorValue = "#f89406";
                                    break;
                                case "绿色":
                                    atMdoel.ColorValue = "#468847";
                                    break;
                            }
                            Response.Write(atDAL.Add(atMdoel) > 0 ? "保存成功" : "保存失败");
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