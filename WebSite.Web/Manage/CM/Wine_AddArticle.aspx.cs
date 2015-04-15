using System;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;
using DotNet.Framework.Common;
using WebSite.CM.DAL;
using WebSite.Lib.Security;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.CM
{
    public partial class Wine_AddArticle : WebPage
    {
        private string AId = "";        //文章分类Id变量
        WebSite.CM.DAL.CMColumn cDAL = new WebSite.CM.DAL.CMColumn();
        WebSite.CM.DAL.CMArticle aDAL = new WebSite.CM.DAL.CMArticle();        //创建文章分类DAL对象
        WebSite.CM.DAL.CMArticleType atDAL = new WebSite.CM.DAL.CMArticleType();
        CMAttchment attDAL = new CMAttchment();
        WebSite.CM.Model.CMArticle aModel = new WebSite.CM.Model.CMArticle();
        WebSite.CM.Model.CMAttchment attModel = new WebSite.CM.Model.CMAttchment();
        const string imgPath = "/UpLoad/Image/"; //图片存储路径
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                AId = Request.QueryString["AId"] == null ? "" : Request.QueryString["AId"];         //获取文章分类Id
                if (!IsPostBack)
                {
                    DBindLm();
                    //DBingType();
                    if (!string.IsNullOrEmpty(AId))        //判断文章分类Id是否为空
                    {
                        this.lblTitle.Text = "修改内容";
                        WebSite.CM.Model.CMArticle aModel = aDAL.GetModel(Convert.ToInt32(AId));          //通过文章分类Id查询文章分类信息
                        if (aModel != null)
                        {
                            this.txtTitle.Value = aModel.Title;        //给文章分类名称文本框赋值
                            this.ddlColumn.SelectedValue = aModel.ColId.ToString();
                            //this.ddlType.SelectedValue = aModel.ATId.ToString();
                            if (aModel.IsTop == 1)                //是否幻灯
                            {
                                rboIsTopTrue.Checked = true;
                                rboIsTopFalse.Checked = false;
                            }
                            else
                            {
                                rboIsTopTrue.Checked = false;
                                rboIsTopFalse.Checked = true;
                            }
                            //if (aModel.IsSplendid == 1)                //是否幻灯
                            //{
                            //    rboIsFlashTrue.Checked = true;
                            //    rboIsFlashFalse.Checked = false;
                            //}
                            //else
                            //{
                            //    rboIsFlashTrue.Checked = false;
                            //    rboIsFlashFalse.Checked = true;
                            //}
                            if (aModel.IsSplendid == 1)            //幻灯图
                            {
                                Image2.Visible = true;
                                Image2.ImageUrl = imgPath + attDAL.GetModel(Convert.ToInt32(AId), 0).AttName;
                            }

                            this.txtAuthor.Value = aModel.Author;
                            this.txtFrom.Value = aModel.Source;
                            this.tarDescription.Value = aModel.Description;
                            this.tarContent.Value = aModel.Content;
                        }
                    }
                }
            }
            catch
            {
                Response.Redirect("AddArticle.aspx");
            }
        }
        /// <summary>
        /// 绑定栏目
        /// </summary>
        private void DBindLm()
        {
            ddlColumn.Items.Add(new ListItem("请选择栏目", "0"));
            var dataTable = cDAL.GetDateList().Tables[0];
            var table1 = GetNewDataTable(dataTable, " Level=1 ", " ColId ");
            for (int i = 0; i < table1.Rows.Count; i++)
            {
                ddlColumn.Items.Add(new ListItem(table1.Rows[i]["ColName"].ToString(),//绑定父类
                                                 table1.Rows[i]["ColID"].ToString()));
                var table2 = GetNewDataTable(dataTable, " ParentID='" + table1.Rows[i]["ColID"] + "'", " ColId ");
                if (table2.Rows.Count > 0)
                {
                    for (int k = 0; k < table2.Rows.Count; k++)
                    {
                        ddlColumn.Items.Add(new ListItem(HttpUtility.HtmlDecode("&nbsp;┠┄┄" + table2.Rows[k]["ColName"]),//绑定子类
                                                         table2.Rows[k]["ColID"].ToString()));
                        var table3 = GetNewDataTable(dataTable, " ParentID='" + table2.Rows[k]["ColID"] + "'",
                                                 " ColId");
                        if (table3.Rows.Count > 0)
                        {

                            for (int j = 0; j < table3.Rows.Count; j++)
                            {
                                ddlColumn.Items.Add(new ListItem(HttpUtility.HtmlDecode("&nbsp;┠┄┄┄┄" + table3.Rows[j]["ColName"]),//绑定二级子类
                                                         table3.Rows[j]["ColID"].ToString()));
                            }
                        }
                    }
                }
            }
        }
        ///// <summary>
        ///// 绑定类型
        ///// </summary>
        //private void DBingType()
        //{
        //    ddlType.Items.Add(new ListItem("请选择类型", "0"));
        //    var dataTable = atDAL.GetDateList().Tables[0];
        //    var table1 = GetNewDataTable(dataTable, "", " ATId ");
        //    for (int i = 0; i < table1.Rows.Count; i++)
        //    {
        //        ddlType.Items.Add(new ListItem(table1.Rows[i]["ATName"].ToString(), table1.Rows[i]["ATId"].ToString()));
        //    }
        //}
        public DataTable GetNewDataTable(DataTable dt, string condition, string sortOrder)
        {
            var newdt = dt.Clone();
            var dr = dt.Select(condition, sortOrder);
            foreach (var t in dr)
            {
                newdt.ImportRow(t);
            }
            return newdt;
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region 获取字段值并赋给变量
            string title = txtTitle.Value.Trim();//标题
            string col = ddlColumn.SelectedValue;//栏目
            //string type = ddlType.SelectedValue;//类型
            string author = txtAuthor.Value.Trim();//作者 
            string from = txtFrom.Value.Trim();//来源
            string description = tarDescription.Value.Trim();//导读
            string content = tarContent.Value.Trim();//详细内容 
            bool isTop = rboIsTopTrue.Checked;//是否置顶
            //bool isFlash = rboIsFlashTrue.Checked;//是否幻灯
            #endregion
            #region  验证输入内容
            if (string.IsNullOrEmpty(title))
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入标题');</script>");
                txtTitle.Focus();
                return;
            }
            if (string.IsNullOrEmpty(col) || col == "0") //判断栏目
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择栏目');</script>");
                ddlColumn.Focus();
                return;
            }
            //if (string.IsNullOrEmpty(type) || type == "0") //判断类型
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择类型');</script>");
            //    ddlType.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(author)) //判断库存是否为空
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入作者');</script>");
            //    txtAuthor.Focus();
            //    return;
            //}
            //if (string.IsNullOrEmpty(from)) //判断库存是否为空
            //{
            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入来源');</script>");
            //    txtFrom.Focus();
            //    return;
            //}
            //if (Request.QueryString["AId"] == "0")
            //{
            //    if (isFlash)
            //    {
            //        if (!fuPFlash.HasFile)
            //        {
            //            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请选择幻灯图片');</script>");
            //            fuPFlash.Focus();
            //            return;
            //        }
            //    }
            //}
            if (string.IsNullOrEmpty(description)) //判断商品概述是否为空
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入导读');</script>");
                tarDescription.Focus();
                return;
            }
            if (string.IsNullOrEmpty(content)) //判断商品概述是否为空
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请输入详细内容');</script>");
                tarContent.Focus();
                return;
            }

            #endregion
            //修改信息
            if (!string.IsNullOrEmpty(AId)) //判断商品Id是否为空，如果不为空就是编辑数据
            {
                #region 修改内容
                try
                {
                    #region 查询编辑对象，并赋值给对象字段
                    //查询编辑的商品信息
                    aModel = aDAL.GetModel(Convert.ToInt32(AId)); //查询产品信息
                    if (aModel != null) //判断编辑果品对象是否为空
                    {
                        aModel.Title = title; //商品名称
                        aModel.ColId = Convert.ToInt32(col); //产品概述
                        //aModel.ATId = Convert.ToInt32(type); //产品描述
                        aModel.Author = author;
                        aModel.Source = from;
                        aModel.Description = description;
                        aModel.Content = content;
                        aModel.CheckTime = DateTime.Now;
                        //aModel.PEmplId=  修改人
                        //审核人
                        if (isTop)
                        {
                            aModel.IsTop = 1;
                        }
                        else
                        {
                            aModel.IsTop = 0;
                        }
                        //if (isFlash)
                        //{
                        //    aModel.IsSplendid = 1;
                        //}
                        //else
                        //{
                        //    aModel.IsSplendid = 0;
                        //}
                    #endregion

                            if (!fuPFlash.HasFile && attDAL.GetModel(Convert.ToInt32(AId), 0) == null)
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "",
                                    "<script>alert('请选择幻灯');</script>");
                                fuPFlash.Focus();
                                return;
                            }

                            if (fuPFlash.HasFile)
                            {
                                int sizeFlash;
                                string msgFlash;
                                string imgFlashUrl;
                                if (attDAL.Exists(Convert.ToInt32(AId), 0)) //判断图片地址是否存在
                                {
                                    attModel = attDAL.GetModel(Convert.ToInt32(AId), 0);
                                    DirFile.DeleteFile(attModel.AttName); // 删除图片地址

                                    UpImg(ref fuPFlash, out imgFlashUrl, out msgFlash, imgPath, out sizeFlash);
                                    //上传图片(无水印)
                                    if (string.IsNullOrEmpty(imgFlashUrl))
                                    {
                                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                                            "<script>alert('" + msgFlash + "');</script>");
                                        return;
                                    }
                                    attModel.AttName = imgFlashUrl; //幻灯地址
                                    if (!attDAL.Update(attModel))
                                    {
                                        return;
                                    }
                                }
                                else
                                {
                                    UpImg(ref fuPFlash, out imgFlashUrl, out msgFlash, imgPath, out sizeFlash);
                                    //上传图片(无水印)
                                    if (string.IsNullOrEmpty(imgFlashUrl))
                                    {
                                        Page.ClientScript.RegisterStartupScript(GetType(), "",
                                            "<script>alert('" + msgFlash + "');</script>");
                                        return;
                                    }
                                    attModel.AttName = imgFlashUrl; //幻灯地址
                                    attModel.Type = 0;
                                    attModel.AId = Convert.ToInt32(AId);
                                    attModel.Status = 1;
                                    if (!(attDAL.Add(attModel) > 0))
                                    {
                                        return;
                                    }
                                }

                            }
                        
                        bool re = aDAL.Update(aModel);
                        if (re)
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                        "<script>alert('修改成功'); window.location = 'CMArticle.aspx';</script>", false);//跳转页面
                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                        "<script>alert('修改失败'); ", false);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                #endregion
            }
            else //新增信息
            {
                #region 新增信息
                try
                {
                    #region 给果品实体对象字段赋值
                    aModel.Title = title; //商品名称
                    aModel.ColId = Convert.ToInt32(col); //产品概述
                    //aModel.ATId = Convert.ToInt32(type); //产品描述
                    aModel.Author = author;
                    aModel.Source = from;
                    aModel.Description = description;
                    aModel.Content = content;
                    aModel.Status = 0;
                    aModel.AddTime = DateTime.Now;
                    if (isTop)
                    {
                        aModel.IsTop = 1;
                    }
                    else
                    {
                        aModel.IsTop = 0;
                    }
                    //if (isFlash)
                    //{
                    //    aModel.IsSplendid = 1;
                    //}
                    //else
                    //{
                    //    aModel.IsSplendid = 0;
                    //}
                    #endregion

                        if (!fuPFlash.HasFile)
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "",
                                "<script>alert('请选择幻灯');</script>");
                            fuPFlash.Focus();
                            return;
                        }
                        if (fuPFlash.HasFile)
                        {
                            int sizeFlash;
                            string msgFlash;
                            string imgFlashUrl;
                            UpImg(ref fuPFlash, out imgFlashUrl, out msgFlash, imgPath, out sizeFlash);//上传图片                   
                            if (string.IsNullOrEmpty(imgFlashUrl))
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "",
                                    "<script>alert('" + msgFlash + "');</script>");
                                return;
                            }

                            attModel.Type = 0;
                            attModel.AttName = imgFlashUrl; //幻灯地址
                            attModel.Status = 1;
                        }
                        aModel.ATId = 1;
                    int re = aDAL.Add(aModel); //增加方法
                    if (re > 0) //判断商品增加是否成功
                    {
                        attModel.AId = re;
                        if (attDAL.Add(attModel) > 0)
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
"<script>alert('新增成功'); window.location = 'CMArticle.aspx';</script>", false);//跳转页面

                        }
                        else
                        {
                            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                                "<script>alert('新增失败'); ", false);
                        }
                    }
                    else
                    {
                        System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(), "",
                            "<script>alert('新增失败'); ", false);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
        }
        /// <summary>
        /// 取消方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("CMArticle.aspx");
        }
        /// <summary>
        /// 上传图片(无水印)
        /// </summary>
        /// <param name="upfile_href">ref上传空间ID</param>
        /// <param name="imgurl">out返回的图片路径</param>
        /// <param name="msg">out提示消息</param>
        /// <param name="imgPath">图片存放路径</param>
        public static void UpImg(ref FileUpload upfile_href, out string imgurl, out string msg, string imgPath, out int size)
        {
            string datatime = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
            if (upfile_href.HasFile)
            {
                string fileName = upfile_href.FileName;
                string fileExition = System.IO.Path.GetExtension(fileName).ToLower();
                string imgType = "|.gif|.png|.jpeg|.jpg|.bmp";
                string strDay = System.DateTime.Now.ToString("yyyyMM");
                string path = HttpContext.Current.Server.MapPath(imgPath + "/");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                if (fileName == "")
                {
                    msg = "请选择上传的图片";
                    imgurl = "";
                    size = 0;
                    return;
                }
                if (imgType.IndexOf(fileExition) > 0)
                {
                    string NewFileName = datatime + fileExition;
                    upfile_href.PostedFile.SaveAs(path + NewFileName);
                    size = upfile_href.PostedFile.ContentLength;
                    imgurl = NewFileName;
                    msg = "上传成功!";
                    JXY_UPLOAD_IMG.MakeThumbnail(HttpContext.Current.Server.MapPath("/UpLoad/Image/" + imgurl), HttpContext.Current.Server.MapPath("/UpLoad/Image/Wine_" + NewFileName), 150, 220, "Cut");
                }
                else
                {
                    msg = "上传图片格式错误";
                    imgurl = "";
                    size = 0;
                }
            }
            else
            {
                imgurl = "";
                msg = "请选择上传的图片";
                size = 0;
            }
        }

        /// <summary>
        /// 上传附件
        /// </summary>
        /// <param name="upfile_href">ref上传空间ID</param>
        /// <param name="imgurl">out返回的附件路径</param>
        /// <param name="msg">out提示消息</param>
        /// <param name="imgPath">附件存放路径</param>
        public static void UpAtt(ref FileUpload upfile_href, out string atturl, out string msg, string attPath, out int size)
        {
            string datatime = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
            if (upfile_href.HasFile)
            {
                string fileName = upfile_href.FileName;
                string fileExition = System.IO.Path.GetExtension(fileName).ToLower();
                string imgType = "|.gif|.png|.jpeg|.jpg|.bmp";
                string strDay = System.DateTime.Now.ToString("yyyyMM");
                string path = HttpContext.Current.Server.MapPath(imgPath + "/");
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                if (fileName == "")
                {
                    msg = "请选择上传的图片";
                    atturl = "";
                    size = 0;
                    return;
                }
                if (imgType.IndexOf(fileExition) > 0)
                {
                    string NewFileName = datatime + fileExition;
                    upfile_href.PostedFile.SaveAs(path + NewFileName);
                    size = upfile_href.PostedFile.ContentLength;
                    atturl = NewFileName;
                    msg = "上传成功!";
                    JXY_UPLOAD_IMG.MakeThumbnail(HttpContext.Current.Server.MapPath("/UpLoad/Image/" + atturl), HttpContext.Current.Server.MapPath("/UpLoad/Image/Wine_" + NewFileName), 150, 220, "Cut");
                }
                else
                {
                    msg = "上传图片格式错误";
                    atturl = "";
                    size = 0;
                }
            }
            else
            {
                atturl = "";
                msg = "请选择上传的图片";
                size = 0;
            }
        }

    }
}