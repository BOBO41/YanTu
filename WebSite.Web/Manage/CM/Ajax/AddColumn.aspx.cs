using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace WebSite.Web.Manage.CM.Ajax
{
    public partial class AddColumn : System.Web.UI.Page
    {
        WebSite.CM.DAL.CMColumn cDAL = new WebSite.CM.DAL.CMColumn();        //创建商品分类DAL对象
        WebSite.CM.DAL.CMArticle aDAL = new WebSite.CM.DAL.CMArticle();        //创建商品品牌DAL对象
        protected void Page_Load(object sender, EventArgs e)
        {
            //VerifyPage("", false);
            if (!IsPostBack)
            {
                var ColId = Request.QueryString["ColId"];           //编辑分类Id
                var PTColId = Request.QueryString["PTColId"];   //添加商品子分类分类Id
                var detColId = Request.QueryString["detColId"];            //删除商品分类Id
                var ColName = HttpUtility.UrlDecode(Request.QueryString["ColName"]);         //商品名称
                #region 删除分类
                if (!string.IsNullOrEmpty(detColId))
                {
                    #region 查询分类是否有品牌关联
                    string sqlWhere = "";
                    List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
                    sqlWhere = "  ColId=@detColId ";
                    var parameter = new SqlParameter("@detColId", DbType.AnsiString);
                    parameter.Value = detColId;
                    parameters.Add(parameter);
                    DataSet dts = aDAL.GetList(sqlWhere, parameters);     //通过商品分类Id查找关系表数据
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("该栏目下有文章，不能删除");
                        Response.End();
                    }
                    #endregion
                    #region 判断分类是否存在子分类
                    else
                    {
                        string sqlWhere1 = "";
                        List<SqlParameter> parameters1 = new List<SqlParameter>();     //创建查询参数集合
                        sqlWhere1 = "  ParentId=@ParentId ";
                        var parameter1 = new SqlParameter("@ParentId", DbType.AnsiString);
                        parameter1.Value = detColId;
                        parameters1.Add(parameter1);
                        DataSet dt = cDAL.GetList(sqlWhere1, parameters1);         //通过商品分类Id查找子分类
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            Response.Write("存在子栏目，不能删除，请先删除子栏目");
                            Response.End();
                        }
                        else
                        {
                            Response.Write(cDAL.Delete(Convert.ToInt32(detColId)) ? "删除成功" : "删除失败");
                            Response.End();
                        }
                    }
                    #endregion
                }
                #endregion
                #region  添加、修改、添加子分类
                else
                {
                    if (string.IsNullOrEmpty(ColName))
                    {
                        Response.Write("栏目名称不能为空");
                        Response.End();
                    }

                    #region 修改商品分类
                    WebSite.CM.Model.CMColumn cMdoel = new WebSite.CM.Model.CMColumn();     //商品分类实体
                    if (!string.IsNullOrEmpty(ColId))
                    {
                        try
                        {
                            cMdoel = cDAL.GetModel(Convert.ToInt32(ColId));
                            if (cMdoel != null)
                            {
                                string sqlWhere = "";
                                List<SqlParameter> parameters = new List<SqlParameter>();     //创建查询参数集合
                                sqlWhere = "  ColName=@ColName and ColId!=@ColId  and  ParentId=@PID";  //查询条件
                                var parameter = new SqlParameter("@ColName", DbType.AnsiString);
                                parameter.Value = ColName;
                                parameters.Add(parameter);
                                var parameter1 = new SqlParameter("@ColId", DbType.AnsiString);
                                parameter1.Value = ColId;
                                parameters.Add(parameter1);
                                var parameter2 = new SqlParameter("@PID", DbType.AnsiString);
                                parameter2.Value = cMdoel.ParentId;
                                parameters.Add(parameter2);
                                var ds = cDAL.GetList(sqlWhere, parameters);            //通过商品分类名称及商品Id查询商品分类名称是否存在
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    Response.Write("该栏目名称已存在");
                                    Response.End();
                                }
                                cMdoel.ColName = ColName;
                                Response.Write(cDAL.Update(cMdoel) ? "保存成功" : "保存失败");
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
                            sqlWhere = "  ColName=@PTName  and ParentId=@ColId ";
                            var parameter = new SqlParameter("@PTName", DbType.AnsiString);
                            parameter.Value = ColName;
                            parameters.Add(parameter);
                            var parameter1 = new SqlParameter("@ColId", DbType.AnsiString);
                            parameter1.Value = PTColId;
                            parameters.Add(parameter1);
                            var ds = cDAL.GetList(sqlWhere, parameters);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                Response.Write("该栏目名称已存在");
                                Response.End();
                            }
                            cMdoel.ColName = ColName;    //商品分类名称
                            cMdoel.ClickRate = 0;    //点击率
                            cMdoel.Status = 1;    //状态
                            if (!string.IsNullOrEmpty(PTColId))             //判断是添加子商品分类还是父商品分类
                            {
                                cMdoel.ParentId = Convert.ToInt32(PTColId);           //商品分类父节点字段
                                var proInfo = cDAL.GetModel(Convert.ToInt32(PTColId));
                                if (proInfo != null)
                                {
                                    cMdoel.Level = proInfo.Level + 1;            //分类级别
                                }
                            }
                            else
                            {
                                cMdoel.ParentId = 0;            //分类父节点
                                cMdoel.Level = 1;             //分类级别
                            }
                            cMdoel.AddTime = DateTime.Now;         //添加时间
                            Response.Write(cDAL.Add(cMdoel) > 0 ? "保存成功" : "保存失败");
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