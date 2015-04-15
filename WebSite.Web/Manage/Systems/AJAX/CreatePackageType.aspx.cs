using System;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems.AJAX
{
    public partial class CreatePackageType : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        string ePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            ePath = Server.MapPath("/UpLoad/");
            try
            {
                var id = Request.QueryString["spid"];
                var sortnum = Request.QueryString["sortnum"];
                var itid = Request.QueryString["itid"];
                var atta = Request.QueryString["atta"];
                var name = Server.UrlDecode(Request.QueryString["name"]);
                #region 原上传分类图标

                if (!string.IsNullOrEmpty(id))
                {
                    if (!string.IsNullOrEmpty(itid))
                    {
                        var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                        if (null != itmodel)
                        {
                            itmodel.IName = name;
                            if (atta != itmodel.AttaID)
                            {
                                itmodel.AttaID = atta;
                            }
                            if (_infoTypeDal.Exists(Convert.ToInt32(itid), itmodel.IName, Convert.ToInt32(itmodel.SPID)))
                            {
                                Response.Write("1|~|分类名称已经存在！");
                                Response.End();
                            }
                            var upres = _infoTypeDal.Update(itmodel);
                            if (upres)
                            {
                                Response.Write("0|~|" + itid);
                                Response.End();
                            }
                            else
                            {
                                Response.Write("1|~|操作失败");
                                Response.End();
                            }
                        }
                    }
                    else
                    {
                        var maxid = _infoTypeDal.GetMaxId(Convert.ToInt32(id));
                        if (maxid > 8)
                        {
                            Response.Write("1|~|最多只能创建8个分类");
                            Response.End();
                        }
                        else
                        {
                            var model = new Admin.Model.InfoType
                            {
                                IName = name,
                                SortNum = Convert.ToInt32(sortnum),
                                Status = 1,
                                SPID = Convert.ToInt32(id),
                                AttaID = atta
                            };
                            if (_infoTypeDal.Exists(0, name, Convert.ToInt32(id)))
                            {
                                Response.Write("1|~|分类名称已经存在！");
                                Response.End();
                            }
                            var typeid = _infoTypeDal.Add(model);
                            if (typeid > 0)
                            {
                                Response.Write("0|~|" + typeid);
                                Response.End();
                            }
                            else
                            {
                                Response.Write("1|~|操作失败");
                                Response.End();
                            }
                        }
                    }
                }
                else
                {
                    Response.Write("1|~|操作失败");
                    Response.End();
                }

                #endregion

                #region 原上传分类图标

                //if (!string.IsNullOrEmpty(id))
                //{
                //    if (!string.IsNullOrEmpty(itid))
                //    {
                //        var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                //        if (null != itmodel)
                //        {
                //            itmodel.IName = HttpUtility.UrlDecode(HttpUtility.UrlDecode(Request.QueryString["name"]));
                //            if (atta != itmodel.AttaID)
                //            {
                //                var fi = new FileInfo(ePath + atta);
                //                if (fi.Exists)
                //                {
                //                    fi.MoveTo(Server.MapPath("/UploadFiles/" + atta));
                //                }
                //                itmodel.AttaID = atta;
                //            }
                //            var upres = _infoTypeDal.Update(itmodel);
                //            if (upres)
                //            {
                //                Response.Write("0|~|" + itid);
                //                Response.End();
                //            }
                //            else
                //            {
                //                Response.Write("1|~|操作失败");
                //                Response.End();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        var maxid = _infoTypeDal.GetMaxId(Convert.ToInt32(id));
                //        if (maxid > 8)
                //        {
                //            Response.Write("1|~|最多只能创建8个分类");
                //            Response.End();
                //        }
                //        else
                //        {
                //            var fi = new FileInfo(ePath + atta);
                //            if (fi.Exists)
                //            {
                //                fi.MoveTo(Server.MapPath("/UploadFiles/" + atta));
                //            }
                //            var model = new Admin.Model.InfoType
                //            {
                //                IName = Request.QueryString["name"],
                //                SortNum = Convert.ToInt32(sortnum),
                //                Status = 1,
                //                SPID = Convert.ToInt32(id),
                //                AttaID = atta
                //            };
                //            var typeid = _infoTypeDal.Add(model);
                //            if (typeid > 0)
                //            {
                //                Response.Write("0|~|" + typeid);
                //                Response.End();
                //            }
                //            else
                //            {
                //                Response.Write("1|~|操作失败");
                //                Response.End();
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    Response.Write("1|~|操作失败");
                //    Response.End();
                //}

                #endregion

            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ee)
            {
                Response.Write("1|~|" + ee.Message);
                Response.End();
            }
        }

    }
}