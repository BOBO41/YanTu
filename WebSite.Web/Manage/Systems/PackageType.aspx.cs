using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebSite.Admin.DAL;

namespace WebSite.Web.Manage.Systems
{
    public partial class PackageType : UI.WebPage
    {
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly Admin.DAL.StaPackage _staPackageDal = new Admin.DAL.StaPackage();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", true);
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["spid"]))
                {
                    var sta = _staPackageDal.GetModel(Convert.ToInt32(Request.QueryString["spid"]));
                    if (null != sta)
                    {
                        var orgModel = _orgOrganizeDal.GetModel(Convert.ToInt64(sta.OrgId));
                        if (null != orgModel)
                        {
                            litOrg.Text = orgModel.OrgName;
                        }
                    }
                    #region

                    List<SqlParameter> pars1 = new List<SqlParameter>();
                    var par1 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
                    pars1.Add(par1);
                    var type1 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars1);
                    if (null != type1)
                    {
                        litType1.Text = "<li data-typeid=\"" + type1.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                        type1.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type1.IName +
                                        "</pre></li>";
                    }
                    else
                    {
                        litType1.Text = "<li data-typeid=\"\"><a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"addtype('1')\">新建分类</a></li>";
                    }

                    #endregion

                    #region

                    List<SqlParameter> pars2 = new List<SqlParameter>();
                    var par2 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
                    pars2.Add(par2);
                    var type2 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars2);
                    if (null != type2)
                    {
                        litType2.Text = "<li data-typeid=\"" + type2.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                        type2.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type2.IName +
                                        "</pre></li>";
                    }
                    else
                    {
                        litType2.Text = "<li data-typeid=\"\"><a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"addtype('2')\">新建分类</a></li>";
                    }

                    #endregion

                    #region

                    List<SqlParameter> pars3 = new List<SqlParameter>();
                    var par3 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
                    pars3.Add(par3);
                    var type3 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars3);
                    if (null != type3)
                    {
                        litType3.Text = "<li data-typeid=\"" + type3.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                        type3.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type3.IName +
                                        "</pre></li>";
                    }
                    else
                    {
                        litType3.Text = "<li data-typeid=\"\"><a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"addtype('3')\">新建分类</a></li>";
                    }

                    #endregion

                    #region

                    List<SqlParameter> pars4 = new List<SqlParameter>();
                    var par4 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
                    pars4.Add(par4);
                    var type4 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars4);
                    if (null != type4)
                    {
                        litType4.Text = "<li data-typeid=\"" + type4.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                        type4.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type4.IName +
                                        "</pre></li>";
                    }
                    else
                    {
                        litType4.Text = "<li data-typeid=\"\"><a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"addtype('4')\">新建分类</a></li>";
                    }

                    #endregion

                    #region

                    List<SqlParameter> pars5 = new List<SqlParameter>();
                    var par5 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
                    pars5.Add(par5);
                    var type5 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars5);
                    if (null != type5)
                    {
                        litType5.Text = "<li data-typeid=\"" + type5.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                        type5.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type5.IName +
                                        "</pre></li>";
                    }
                    else
                    {
                        litType5.Text = "<li data-typeid=\"\"><a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"addtype('5')\">新建分类</a></li>";
                    }

                    #endregion

                    #region

                    List<SqlParameter> pars6 = new List<SqlParameter>();
                    var par6 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
                    pars6.Add(par6);
                    var type6 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars6);
                    if (null != type6)
                    {
                        litType6.Text = "<li data-typeid=\"" + type6.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                        type6.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type6.IName +
                                        "</pre></li>";
                    }
                    else
                    {
                        litType6.Text = "<li data-typeid=\"\"><a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"addtype('6')\">新建分类</a></li>";
                    }

                    #endregion

                    #region

                    List<SqlParameter> pars7 = new List<SqlParameter>();
                    var par7 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
                    pars7.Add(par7);
                    var type7 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars7);
                    if (null != type7)
                    {
                        litType7.Text = "<li data-typeid=\"" + type7.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                        type7.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type7.IName +
                                        "</pre></li>";
                    }
                    else
                    {
                        litType7.Text = "<li data-typeid=\"\"><a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"addtype('7')\">新建分类</a></li>";
                    }

                    #endregion

                    #region

                    List<SqlParameter> pars8 = new List<SqlParameter>();
                    var par8 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
                    pars8.Add(par8);
                    var type8 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars8);
                    if (null != type8)
                    {
                        litType8.Text = "<li data-typeid=\"" + type8.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                        type8.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type8.IName +
                                        "</pre></li>";
                    }
                    else
                    {
                        litType8.Text = "<li data-typeid=\"\"><a href=\"javascript:;\" class=\"btn btn-mini\" onclick=\"addtype('8')\">新建分类</a></li>";
                    }

                    #endregion
                }
            }
        }

        protected void c()
        {
            #region

            List<SqlParameter> pars8 = new List<SqlParameter>();
            var par8 = new SqlParameter("@SPID", DbType.AnsiString) { Value = Request.QueryString["spid"] };
            pars8.Add(par8);
            var type8 = _infoTypeDal.GetModel(" SPID=@SPID and Status=1 and SortNum=1 ", pars8);
            if (null != type8)
            {
                litType8.Text = "<li data-typeid=\"" + type8.ITID + "\"><pre><img alt=\"\" src=\"/UploadFiles/" +
                                type8.AttaID + "\" style=\"width: 26px; height: 32px;\">" + type8.IName +
                                "</pre></li>";
            }

            #endregion
        }
    }
}