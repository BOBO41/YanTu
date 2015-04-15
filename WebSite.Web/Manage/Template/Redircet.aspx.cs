using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Template
{
    public partial class Redircet : UI.WebPage
    {
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Templates _templatesDal = new Templates();
        private readonly Infos _infosDal = new Infos();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            if (!IsPostBack)
            {
                #region 模板id

                var tiid = Request.QueryString["tiid"];
                var itid = Request.QueryString["itid"];
                var spid = Request.QueryString["spid"];
                var pid = Request.QueryString["pid"];
                var repage = Request.QueryString["repage"];
                var parcount = Request.QueryString["parcount"];
                if (!string.IsNullOrEmpty(repage) && !string.IsNullOrEmpty(parcount))
                {
                    List<SqlParameter> parDef = new List<SqlParameter>();
                    parDef.Add(new SqlParameter("@ParentID", DbType.AnsiString) { Value = parcount });
                    parDef.Add(new SqlParameter("@TIPage", DbType.AnsiString) { Value = repage });
                    parDef.Add(new SqlParameter("@ITID", DbType.AnsiString) { Value = itid });
                    var model = _tempInfoDal.GetModel(" ParentID=@ParentID and TIPage=@TIPage and ITID=@ITID ", parDef);
                    if (null != model)
                    {
                        var template = _templatesDal.GetModel(Convert.ToInt32(model.TID));
                        if (null != template)
                        {
                            Response.Redirect(template.TLink + "?itid=" + model.ITID + "&tiid=" + model.TIID + "&spid=" + spid, true);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(tiid))
                {
                    var model = _tempInfoDal.GetModel(Convert.ToInt32(tiid));
                    if (null != model)
                    {
                        var template = _templatesDal.GetModel(Convert.ToInt32(model.TID));
                        if (null != template)
                        {
                            Response.Redirect(template.TLink + "?itid=" + model.ITID + "&tiid=" + tiid + "&spid=" + spid, true);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(pid))
                {
                    List<SqlParameter> parDef = new List<SqlParameter>();
                    parDef.Add(new SqlParameter("@ParentID", DbType.AnsiString) { Value = pid });
                    var timodel = _tempInfoDal.GetModel(" ParentID=@ParentID and TIPage=1 ", parDef);
                    if (null != timodel)
                    {
                        var template = _templatesDal.GetModel(Convert.ToInt32(timodel.TID));
                        if (null != template)
                        {
                            var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(timodel.ITID));
                            Response.Redirect(template.TLink + "?itid=" + timodel.ITID + "&tiid=" + timodel.TIID + "&spid=" + itmodel.SPID,
                                true);
                        }
                    }
                    else
                    {
                        var imodel = _infosDal.GetModel(Convert.ToInt32(pid));
                        if (null != imodel)
                        {
                            var tiModel = _tempInfoDal.GetModel(Convert.ToInt32(imodel.TIID));
                            if (null != tiModel)
                            {
                                var itmodel = _infoTypeDal.GetModel(Convert.ToInt32(tiModel.ITID));
                                if (null != itmodel)
                                {
                                    Response.Redirect("/Manage/Systems/CreateFirstPage.aspx" + "?page=1&spid=" + itmodel.SPID + "&itid=" + itmodel.ITID + "&pid=" + pid, true);
                                }
                            }
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(itid))
                {
                    var model = _infoTypeDal.GetModel(Convert.ToInt32(itid));
                    if (null != model)
                    {
                        List<SqlParameter> parDef = new List<SqlParameter>();
                        var itModel = _tempInfoDal.GetModel(" ITID=" + itid + " and TIPage=1 and ParentID=0 ", parDef);
                        if (null != itModel)
                        {
                            var template = _templatesDal.GetModel(Convert.ToInt32(itModel.TID));
                            if (null != template)
                            {
                                Response.Redirect(template.TLink + "?spid=" + model.SPID + "&tiid=" + itModel.TIID + "&itid=" + itid, true);
                            }
                        }
                        else
                        {
                            Response.Redirect("/Manage/Systems/CreateFirstPage.aspx" + "?page=1&spid=" + model.SPID + "&itid=" + itid, true);
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(spid))
                {
                    List<SqlParameter> parDef = new List<SqlParameter>();
                    parDef.Add(new SqlParameter("@SPID", DbType.AnsiString) { Value = spid });
                    var itmodel = _infoTypeDal.GetModel(" SPID=@SPID and SortNum=1 ", parDef);
                    if (null != itmodel)
                    {
                        List<SqlParameter> parDef1 = new List<SqlParameter>();
                        var tiModel = _tempInfoDal.GetModel(" ITID=" + itmodel.ITID + " and TIPage=1 and ParentID=0 ", parDef1);
                        if (null != tiModel)
                        {
                            var template = _templatesDal.GetModel(Convert.ToInt32(tiModel.TID));
                            if (null != template)
                            {
                                Response.Redirect(template.TLink + "?itid=" + itmodel.ITID + "&tiid=" + tiModel.TIID + "&spid=" + itmodel.SPID, true);
                            }
                        }
                        else
                        {
                            Response.Redirect("/Manage/Systems/CreateFirstPage.aspx" + "?page=1&spid=" + itmodel.SPID + "&itid=" + itmodel.ITID, true);
                        }
                    }
                    else
                    {
                        Response.Redirect("/Manage/Systems/CreateFirstPage.aspx?page=1&spid=" + spid, true);
                    }
                }

                #endregion

            }
        }
    }
}