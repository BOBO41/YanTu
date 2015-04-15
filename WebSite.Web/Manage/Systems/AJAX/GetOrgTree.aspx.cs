using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class GetOrgTree : UI.WebPage
    {
        private readonly StringBuilder _stringBuilder = new StringBuilder();
        OrgArea proTypeDal = new OrgArea();             //商品分类Dal对象
        protected void Page_Load(object sender, EventArgs e)
        {
            //VerifyPage("", false);
            if (!IsPostBack)
            {
                var id = Request.QueryString["id"];
                BuildTree(id);
                Response.Write(_stringBuilder.ToString());
                Response.End();
            }
        }

        private void BuildTree2(string id)
        {
            if (id == "")
            {
                id = "1";
            }
            List<SqlParameter> parameters = new List<SqlParameter>();            //sql参数存储对象
            var parameter = new SqlParameter("@ParentId", DbType.AnsiString);
            parameter.Value = id;
            parameters.Add(parameter);
            DataSet dataset = proTypeDal.GetList("", parameters);             //查询所有类别信息
            _stringBuilder.Append("[");
            var i = 0;
            foreach (DataRow trow in dataset.Tables[0].Rows)
            {
                if (i != 0)
                {
                    _stringBuilder.Append(",");
                }
                var text = trow["AreaName"].ToString().Trim();
                var no = trow["AreaId"].ToString().Trim();
                var pid = trow["ParentId"];
                var href = "ProductSpecMain.aspx?AreaId=" + no;

                _stringBuilder.Append("{\"id\": " + no + ",\"pId\":" + pid + ",\"name\":\"" + text + "\"}");
                i++;
            }
            _stringBuilder.Append("]");
        }


        /// <summary>
        /// 构建栏目树
        /// </summary>
        private void BuildTree(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["menu"]))
                {
                    List<SqlParameter> parameters = new List<SqlParameter>(); //sql参数存储对象
                    DataSet myset = proTypeDal.GetList(" Status=1 ", parameters); //查询所有类别信息
                    if (id == "")
                    {
                        id = "1";
                    }
                    foreach (
                        var iRow in myset.Tables[0].Rows.Cast<DataRow>().Where(iRow => iRow["AreaId"].ToString() == id))
                    {
                        iRow["ParentId"] = DBNull.Value;
                    }
                    myset.Relations.Add("NodeRelation", myset.Tables[0].Columns["AreaId"],
                        myset.Tables[0].Columns["ParentId"], false);
                    _stringBuilder.Append("[");
                    var i = 0;
                    if (i != 0)
                    {
                        _stringBuilder.Append(",");
                    }
                    foreach (DataRow mRow in myset.Tables[0].Rows)
                    {
                        if (!mRow.IsNull("ParentId")) continue;
                        var text = mRow["AreaName"].ToString().Trim();
                        var no = mRow["AreaId"].ToString().Trim();
                        var href = Request.QueryString["menu"]+"?AreaId=" + no;
                        if (mRow.GetChildRows("NodeRelation").Length <= 0)
                        {
                            _stringBuilder.Append("{\"state\":\"open\",\"data\":{\"title\": \"" + text +
                                                  "\",\"icon\": \"jstree-iconla\",\"attr\": { \"href\": \"" + href +
                                                  "\", \"target\": \"center\" }},\"attr\": { \"id\": \"" + no + "\" }");
                        }
                        else
                        {
                            _stringBuilder.Append("{\"state\":\"open\",\"data\":{\"title\": \"" + text + "\",\"attr\": { \"href\": \"" + href +
                                                  "\", \"target\": \"center\" }},\"attr\": { \"id\": \"" + no + "\" }");
                        }
                        //_stringBuilder.Append("{\"data\":{\"title\": \"" + text + "\",\"attr\": { \"href\": \"" + href +
                        //                      "\", \"target\": \"center\" }},\"attr\": { \"id\": \"" + no + "\" }");

                        BuildSubTree(mRow);
                        _stringBuilder.Append("}");
                        i++;
                    }
                    _stringBuilder.Append("]");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 递归添加子节点
        /// </summary>
        /// <param name="cRow"></param>
        private void BuildSubTree(DataRow cRow)
        {
            var i = 0;
            _stringBuilder.Append(",\"children\":[");
            foreach (var iRow in cRow.GetChildRows("NodeRelation"))
            {
                if (i != 0)
                {
                    _stringBuilder.Append(",");
                }
                var text = iRow["AreaName"].ToString().Trim();
                var no = iRow["AreaId"].ToString().Trim();
                var href = Request.QueryString["menu"] + "?AreaId=" + no;
                //_stringBuilder.Append("{\"data\":{\"title\": \"" + text + "\",\"attr\": { \"href\": \"" + href + "\", \"target\": \"center\" }},\"attr\": { \"id\": \"" + no + "\" }");
                if (iRow.GetChildRows("NodeRelation").Length <= 0)
                {
                    _stringBuilder.Append("{\"data\":{\"title\": \"" + text +
                                          "\",\"icon\": \"jstree-iconla\",\"attr\": { \"href\": \"" + href +
                                          "\", \"target\": \"center\" }},\"attr\": { \"id\": \"" + no + "\" }");
                }
                else
                {
                    _stringBuilder.Append("{\"data\":{\"title\": \"" + text + "\",\"attr\": { \"href\": \"" + href +
                                          "\", \"target\": \"center\" }},\"attr\": { \"id\": \"" + no + "\" }");
                }
                i++;
                BuildSubTree(iRow);
                _stringBuilder.Append("}");
            }
            _stringBuilder.Append("]");
        }


    }

}