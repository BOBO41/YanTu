using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Admin.DAL;
using WebSite.Lib;

namespace WebSite.Web.Manage.Pkg
{
    public partial class ExOrgpkg : UI.WebPage
    {
        private ArrayList fileList = new ArrayList();
        private StringBuilder json = new StringBuilder();
        private readonly StaPackage _staPackageDal = new StaPackage();
        private readonly RootPackage _rootPackageDal = new RootPackage();
        private readonly OrgOrganize _orgOrganizeDal = new OrgOrganize();
        private readonly Advertisement _adDal = new Advertisement();
        private readonly InfoType _infoTypeDal = new InfoType();
        private readonly TempInfo _tempInfoDal = new TempInfo();
        private readonly Infos _infosDal = new Infos();
        private readonly AttaList _attaListDal = new AttaList();
        private readonly OrgPkgList _orgPkgListDal = new OrgPkgList();
        private readonly AdInfos _adInfosDal = new AdInfos();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            var ePath = Server.MapPath("/UploadFiles/");
            var pkgPath = Server.MapPath("/Packages/");
            if (!IsPostBack)
            {
                var rpid = Request.QueryString["rpid"];
                var orgid = Request.QueryString["orgid"];
                if (!string.IsNullOrEmpty(orgid) && !string.IsNullOrEmpty(rpid))
                {
                    Database db = DatabaseFactory.CreateDatabase();
                    var rpmodel = _rootPackageDal.GetModel(Convert.ToInt32(rpid));
                    var orgmodel = _orgOrganizeDal.GetModel(Convert.ToInt64(orgid));
                    if (null != rpmodel && null != orgmodel)
                    {
                        try
                        {
                            #region

                            var fname = rpmodel.RPName + "-" + orgmodel.OrgName + "-" + orgmodel.OrgId + "-" + CurrentUser.UId;
                            var storePath = Server.MapPath("/Packages/" + fname);
                            if (Directory.Exists(storePath)) //判断是否存在      
                            {
                                try
                                {
                                    Directory.Delete(storePath, true);
                                }
                                catch (Exception)
                                {
                                    Response.Write("1|~|文件正在使用中,或上次的导出操作未完成,请稍后再试!");
                                    Response.End();
                                }

                            }
                            var fizip = new FileInfo(Server.MapPath("/Packages/" + fname + ".zip"));
                            if (fizip.Exists)
                            {
                                try
                                {
                                    fizip.Delete();
                                }
                                catch (Exception)
                                {
                                    Response.Write("1|~|文件正在使用中,或上次的导出操作未完成,请稍后再试!");
                                    Response.End();
                                }
                            }
                            storePath = Path.Combine(storePath, "data\\apps\\com.JT.bailianchiadv\\yantu");
                            Directory.CreateDirectory(storePath);
                            Directory.CreateDirectory(storePath + "/image");
                            Directory.CreateDirectory(storePath + "/video");
                            var imglist = new ArrayList();
                            var videolist = new ArrayList();
                            var videoliststr = "";
                            #endregion

                            json.Append("{"); //开始

                            #region 资源包信息

                            json.Append("\"pack_info\":");
                            json.Append("{");
                            json.Append("\"pack_id\":\"" + rpmodel.RPID + "\",");
                            json.Append("\"pack_name\":\"" + rpmodel.RPName + "\",");
                            json.Append("\"railway_bureau_id\":\"" + orgmodel.OrgId + "\",");
                            json.Append("\"railway_bureau\":\"" + orgmodel.OrgName + "\",");
                            json.Append("\"create_time\":\"" +
                                        Convert.ToDateTime(rpmodel.CreateDate).ToString("yyyy-MM-dd HH:mm:ss") +
                                        "\"");
                            json.Append("},");

                            #endregion

                            #region 广告信息

                            List<SqlParameter> parad = new List<SqlParameter>();
                            var addt = _adDal.GetList("", parad).Tables[0];
                            json.Append("\"ad_info\":");
                            json.Append("{");
                            json.Append("\"ad_interval\":\"2700\",");
                            json.Append("\"ad_list\":");
                            json.Append("[");
                            if (addt.Rows.Count > 0)
                            {
                                var tmp = "";
                                for (int i = 0; i < addt.Rows.Count; i++)
                                {
                                    var img = "";
                                    if (DBNull.Value != addt.Rows[i]["AImg"])
                                    {
                                        if (!string.IsNullOrEmpty(addt.Rows[i]["AImg"].ToString()))
                                        {
                                            img = addt.Rows[i]["AImg"].ToString().Substring(0, 36);
                                            if (addt.Rows[i]["AImg"].ToString().LastIndexOf('.') != -1)
                                            {
                                                img += addt.Rows[i]["AImg"].ToString().Substring(addt.Rows[i]["AImg"].ToString().LastIndexOf('.'));
                                            }
                                        }
                                    }
                                    tmp += "{\"ad_id\":\"" + addt.Rows[i]["AID"] + "\", \"image_path\":\"image/" +
                                           img + "\"},";
                                    imglist.Add(addt.Rows[i]["AImg"].ToString());
                                }
                                json.Append(tmp.Substring(0, tmp.Length - 1));
                            }
                            json.Append("]");
                            json.Append("},");

                            #endregion

                            #region 分站列表

                            json.Append("\"station_list\":");
                            json.Append("[");

                            var nsorgid = "";
                            #region 全国热点

                            List<SqlParameter> parns = new List<SqlParameter>();
                            var nsmodel = _orgOrganizeDal.GetModel(" OrgName='全国热点' ", parns);
                            if (null != nsmodel)
                            {
                                nsorgid = nsmodel.OrgId.ToString();
                                json.Append("{");
                                json.Append("\"station_id\":\"" + nsmodel.OrgId + "\",");
                                json.Append("\"station_name\":\"" + nsmodel.OrgName + "\",");
                                json.Append("\"station_engligh\":\"" + nsmodel.EnName + "\",");
                                json.Append("\"station_category_list\":");
                                json.Append("[");

                                var nspkg = _staPackageDal.GetNspkg(" OrgPkgList.RPID='" + rpmodel.RPID + "' and OrgPkgList.OrgId='" + orgmodel.OrgId + "' and OrgOrganize.OrgId='" + nsmodel.OrgId + "' ", new List<SqlParameter>());
                                if (nspkg.Rows.Count > 0)
                                {
                                    List<SqlParameter> parstaType = new List<SqlParameter>();
                                    var infoTypedt = _infoTypeDal.GetList(" SPID='" + nspkg.Rows[0]["SPID"] + "' order by SortNum", parstaType).Tables[0];
                                    if (infoTypedt.Rows.Count > 0)
                                    {
                                        var tmp = "";
                                        for (int i = 0; i < infoTypedt.Rows.Count; i++)
                                        {
                                            tmp += "{\"category_id\":\"" + infoTypedt.Rows[i]["ITID"] + "\",\"category_name\":\"" + infoTypedt.Rows[i]["IName"] + "\",";
                                            tmp += "\"category_icon_normal\":\"image/i" + infoTypedt.Rows[i]["AttaID"] + "\",";
                                            tmp += "\"category_icon_highlight\":\"image/" + infoTypedt.Rows[i]["AttaID"] + "\"";
                                            tmp += "},";
                                        }
                                        json.Append(tmp.Substring(0, tmp.Length - 1));
                                    }
                                }
                                json.Append("]");
                                json.Append("},");
                            }

                            #endregion

                            #region 分站热点

                            StringBuilder strSqlstas = new StringBuilder();
                            strSqlstas.Append("select StaPackage.*,OrgOrganize.OrgId,OrgOrganize.OrgName,OrgOrganize.EnName FROM StaPackage join OrgPkgList on OrgPkgList.SPID=StaPackage.SPID ");
                            strSqlstas.Append(" join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId ");
                            strSqlstas.Append(" where OrgPkgList.RPID='" + rpmodel.RPID + "' and OrgPkgList.OrgId='" + orgmodel.OrgId + "'  and OrgOrganize.OrgId!='" + nsorgid + "' ");

                            DbCommand dbCommandstas = db.GetSqlStringCommand(strSqlstas.ToString());

                            var stasdt = db.ExecuteDataSet(dbCommandstas).Tables[0];

                            if (stasdt.Rows.Count > 0)
                            {
                                var tmpsp = "";
                                for (int l = 0; l < stasdt.Rows.Count; l++)
                                {
                                    tmpsp += "{";
                                    tmpsp += "\"station_id\":\"" + stasdt.Rows[l]["OrgId"] + "\",";
                                    tmpsp += "\"station_name\":\"" + stasdt.Rows[l]["OrgName"] + "\",";
                                    tmpsp += "\"station_engligh\":\"" + stasdt.Rows[l]["EnName"] + "\",";
                                    tmpsp += "\"station_category_list\":";
                                    tmpsp += "[";
                                    List<SqlParameter> parstaType = new List<SqlParameter>();
                                    var infoTypedt = _infoTypeDal.GetList(" SPID='" + stasdt.Rows[l]["SPID"] + "' order by SortNum", parstaType).Tables[0];
                                    if (infoTypedt.Rows.Count > 0)
                                    {
                                        var tmp = "";
                                        for (int i = 0; i < infoTypedt.Rows.Count; i++)
                                        {
                                            tmp += "{\"category_id\":\"" + infoTypedt.Rows[i]["ITID"] + "\",\"category_name\":\"" + infoTypedt.Rows[i]["IName"] + "\",";
                                            tmp += "\"category_icon_normal\":\"image/i" + infoTypedt.Rows[i]["AttaID"] + "\",";
                                            tmp += "\"category_icon_highlight\":\"image/" + infoTypedt.Rows[i]["AttaID"] + "\"";
                                            tmp += "},";
                                        }
                                        tmpsp += tmp.Substring(0, tmp.Length - 1);
                                    }
                                    tmpsp += "]";
                                    tmpsp += "},";
                                }
                                json.Append(tmpsp.Substring(0, tmpsp.Length - 1));
                            }

                            #endregion

                            json.Append("],");

                            #endregion

                            #region 分类列表

                            json.Append("\"category_list\":");
                            json.Append("[");

                            StringBuilder strSqltype = new StringBuilder();
                            strSqltype.Append("select * from InfoType where SPID in(select StaPackage.SPID FROM StaPackage join OrgPkgList on OrgPkgList.SPID=StaPackage.SPID ");
                            strSqltype.Append(" join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId ");
                            strSqltype.Append(" where OrgPkgList.RPID='" + rpmodel.RPID + "' and OrgPkgList.OrgId='" + orgmodel.OrgId + "') ");

                            DbCommand dbCommandtype = db.GetSqlStringCommand(strSqltype.ToString());

                            var typedt = db.ExecuteDataSet(dbCommandtype).Tables[0];
                            if (typedt.Rows.Count > 0)
                            {
                                var tmp = "";
                                for (int i = 0; i < typedt.Rows.Count; i++)
                                {
                                    tmp += "{";
                                    tmp += "\"category_id\":\"" + typedt.Rows[i]["ITID"] + "\",";
                                    tmp += "\"category_name\":\"" + typedt.Rows[i]["IName"] + "\",";
                                    imglist.Add(typedt.Rows[i]["AttaID"].ToString());
                                    imglist.Add("i" + typedt.Rows[i]["AttaID"].ToString());
                                    tmp += "\"category_icon_normal\":\"image/i" + typedt.Rows[i]["AttaID"] + "\",";
                                    tmp += "\"category_icon_highlight\":\"image/" + typedt.Rows[i]["AttaID"] + "\",";
                                    tmp += "\"category_page_list\":";
                                    tmp += "[";

                                    List<SqlParameter> parTmpInfo = new List<SqlParameter>();
                                    var tmpinfoDt =
                                        _tempInfoDal.GetList(
                                            " ITID=" + typedt.Rows[i]["ITID"] + " and ParentID=0 order by TIPage ",
                                            parTmpInfo).Tables[0];
                                    if (tmpinfoDt.Rows.Count > 0)
                                    {
                                        var tmpInfo = "";
                                        for (int j = 0; j < tmpinfoDt.Rows.Count; j++)
                                        {
                                            tmpInfo += "{\"page_id\":\"" + tmpinfoDt.Rows[j]["TIID"] + "\"},";
                                        }
                                        tmp += tmpInfo.Substring(0, tmpInfo.Length - 1);
                                    }
                                    tmp += "]";
                                    tmp += "},";
                                }
                                json.Append(tmp.Substring(0, tmp.Length - 1));
                            }
                            json.Append("],");

                            #endregion

                            #region 页面列表

                            json.Append("\"page_list\":");
                            json.Append("[");

                            StringBuilder strSql = new StringBuilder();
                            strSql.Append("select TIID,ITID,TID,AttID,TIPage,ParentID FROM TempInfo ");
                            strSql.Append("where TID in(select TID from Templates where TType=1) ");
                            strSql.Append("and ITID in(select ITID from InfoType where ");
                            strSql.Append("SPID in (select StaPackage.SPID FROM StaPackage join OrgPkgList on OrgPkgList.SPID=StaPackage.SPID ");
                            strSql.Append(" join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId ");
                            strSql.Append(" where OrgPkgList.RPID='" + rpmodel.RPID + "' and OrgPkgList.OrgId='" + orgmodel.OrgId + "'))");

                            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());

                            var tidt = db.ExecuteDataSet(dbCommand).Tables[0];
                            if (tidt.Rows.Count > 0)
                            {
                                var tmp = "";
                                for (int i = 0; i < tidt.Rows.Count; i++)
                                {
                                    tmp += "{";
                                    tmp += "\"page_id\":\"" + tidt.Rows[i]["TIID"] + "\",";
                                    tmp += "\"page_layout_type\":\"" + tidt.Rows[i]["TID"] + "\",";
                                    tmp += "\"page_module_list\":";
                                    tmp += "[";
                                    List<SqlParameter> parInfo = new List<SqlParameter>();
                                    //var infosql = "select * from Infos join TmpInfoList on TmpInfoList.IID=Infos.IID where TmpInfoList.TIID=" + tidt.Rows[i]["TIID"] + " order by Infos.SortNum ";
                                    //DbCommand dbComInfo = db.GetSqlStringCommand(infosql);
                                    //var infoDt = db.ExecuteDataSet(dbComInfo).Tables[0];
                                    var infoDt =
                                        _infosDal.GetList(" TIID=" + tidt.Rows[i]["TIID"] + " order by SortNum", parInfo)
                                            .Tables[0];
                                    if (infoDt.Rows.Count > 0)
                                    {
                                        var tmpInfo = "";
                                        for (int j = 0; j < infoDt.Rows.Count; j++)
                                        {
                                            tmpInfo += "{";
                                            tmpInfo += "\"module_id\":\"" + tidt.Rows[i]["TID"] + "." +
                                                       infoDt.Rows[j]["SortNum"] + "\",";
                                            tmpInfo += "\"module_type\":\"" +
                                                       GetType(Convert.ToInt32(infoDt.Rows[j]["IType"])) + "\",";
                                            tmpInfo += "\"module_title\":\"" + infoDt.Rows[j]["IName"] + "\",";

                                            #region 背景图片

                                            var img = "";
                                            if (DBNull.Value != infoDt.Rows[j]["PicAttID"])
                                            {
                                                if (!string.IsNullOrEmpty(infoDt.Rows[j]["PicAttID"].ToString()))
                                                {
                                                    if ("C0pY" == infoDt.Rows[j]["PicAttID"].ToString().Substring(0, 4))
                                                    {
                                                        img = infoDt.Rows[j]["PicAttID"].ToString().Substring(40, 36);
                                                    }
                                                    else
                                                    {
                                                        img = infoDt.Rows[j]["PicAttID"].ToString().Substring(0, 36);
                                                    }
                                                    if (infoDt.Rows[j]["PicAttID"].ToString().LastIndexOf('.') != -1)
                                                    {
                                                        img +=
                                                            infoDt.Rows[j]["PicAttID"].ToString()
                                                                .Substring(
                                                                    infoDt.Rows[j]["PicAttID"].ToString()
                                                                        .LastIndexOf('.'));
                                                    }
                                                }
                                            }

                                            #endregion

                                            tmpInfo += "\"module_image_path\":\"image/" + img + "\",";
                                            tmpInfo += "\"module_topic_id\":\"" + infoDt.Rows[j]["IID"] + "\",";
                                            tmpInfo += "\"module_news_id\":\"" + infoDt.Rows[j]["IID"] + "\",";
                                            tmpInfo += "\"module_video_id\":\"" + infoDt.Rows[j]["IID"] + "\"";

                                            #region 视频内容

                                            if ("2" == infoDt.Rows[j]["IType"].ToString())
                                            {
                                                #region 内容视频

                                                var video = "";
                                                if (DBNull.Value != infoDt.Rows[j]["VideoAttID"])
                                                {
                                                    if (!string.IsNullOrEmpty(infoDt.Rows[j]["VideoAttID"].ToString()))
                                                    {
                                                        if ("C0pY" ==
                                                            infoDt.Rows[j]["VideoAttID"].ToString().Substring(0, 4))
                                                        {
                                                            video = infoDt.Rows[j]["VideoAttID"].ToString()
                                                                .Substring(40, 36);
                                                        }
                                                        else
                                                        {
                                                            video = infoDt.Rows[j]["VideoAttID"].ToString()
                                                                .Substring(0, 36);
                                                        }
                                                        if (infoDt.Rows[j]["VideoAttID"].ToString().LastIndexOf('.') !=
                                                            -1)
                                                        {
                                                            video +=
                                                                infoDt.Rows[j]["VideoAttID"].ToString()
                                                                    .Substring(
                                                                        infoDt.Rows[j]["VideoAttID"].ToString()
                                                                            .LastIndexOf('.'));
                                                        }
                                                    }
                                                }
                                                videolist.Add(infoDt.Rows[j]["VideoAttID"].ToString());

                                                #endregion

                                                videoliststr += "{\"video_id\":\"" + infoDt.Rows[j]["IID"] + "\",";
                                                videoliststr += "\"video_path\":\"video/" + video + "\",";
                                                videoliststr += "\"video_ad\":";
                                                videoliststr += "{";
                                                List<SqlParameter> parattli = new List<SqlParameter>();
                                                var attvideoDt =
                                                    _attaListDal.GetList(
                                                        " IID=" + infoDt.Rows[j]["IID"] + " order by ALID ", parattli)
                                                        .Tables[0];
                                                if (attvideoDt.Rows.Count > 0)
                                                {
                                                    videoliststr += "\"ad_seconds\":\"" + infoDt.Rows[j]["ADTime"] + "\",";
                                                    videoliststr += "\"ad_video_list\":";
                                                    videoliststr += "[";

                                                    var tmpattvideo = "";
                                                    for (int q = 0; q < attvideoDt.Rows.Count; q++)
                                                    {
                                                        #region 广告视频

                                                        var attvideo = "";
                                                        if (DBNull.Value != attvideoDt.Rows[q]["AttID"])
                                                        {
                                                            if (
                                                                !string.IsNullOrEmpty(
                                                                    attvideoDt.Rows[q]["AttID"].ToString()))
                                                            {
                                                                if ("C0pY" ==
                                                                    attvideoDt.Rows[q]["AttID"].ToString()
                                                                        .Substring(0, 4))
                                                                {
                                                                    attvideo = attvideoDt.Rows[q]["AttID"].ToString()
                                                                        .Substring(40, 36);
                                                                }
                                                                else
                                                                {
                                                                    attvideo =
                                                                        attvideoDt.Rows[q]["AttID"].ToString()
                                                                            .Substring(0, 36);
                                                                }
                                                                if (
                                                                    attvideoDt.Rows[q]["AttID"].ToString()
                                                                        .LastIndexOf('.') != -1)
                                                                {
                                                                    attvideo += attvideoDt.Rows[q]["AttID"].ToString()
                                                                        .Substring(attvideoDt.Rows[q]["AttID"].ToString()
                                                                            .LastIndexOf('.'));
                                                                }
                                                            }
                                                        }
                                                        videolist.Add(attvideoDt.Rows[q]["AttID"].ToString());

                                                        #endregion

                                                        tmpattvideo += "{";
                                                        tmpattvideo += "\"video_path\":\"video/" + attvideo + "\",";
                                                        tmpattvideo += "\"news_id\":\"" + attvideoDt.Rows[q]["AD_IID"] +
                                                                       "\"";
                                                        tmpattvideo += "},";
                                                    }
                                                    videoliststr += tmpattvideo.Substring(0, tmpattvideo.Length - 1);
                                                }

                                                videoliststr += "],";
                                                videoliststr += "\"ad_pause\":";
                                                videoliststr += "{";

                                                #region 暂停广告

                                                var pauseimg = "";
                                                if (DBNull.Value != infoDt.Rows[j]["ADPic"])
                                                {
                                                    if (!string.IsNullOrEmpty(infoDt.Rows[j]["ADPic"].ToString()))
                                                    {
                                                        if ("C0pY" ==
                                                            infoDt.Rows[j]["ADPic"].ToString().Substring(0, 4))
                                                        {
                                                            pauseimg = infoDt.Rows[j]["ADPic"].ToString()
                                                                .Substring(40, 36);
                                                        }
                                                        else
                                                        {
                                                            pauseimg = infoDt.Rows[j]["ADPic"].ToString()
                                                                .Substring(0, 36);
                                                        }
                                                        if (infoDt.Rows[j]["ADPic"].ToString().LastIndexOf('.') != -1)
                                                        {
                                                            pauseimg +=
                                                                infoDt.Rows[j]["ADPic"].ToString()
                                                                    .Substring(
                                                                        infoDt.Rows[j]["ADPic"].ToString()
                                                                            .LastIndexOf('.'));
                                                        }
                                                    }
                                                }
                                                imglist.Add(infoDt.Rows[j]["ADPic"].ToString());

                                                #endregion

                                                videoliststr += "\"image_path\":\"image/" + pauseimg + "\",";
                                                videoliststr += "\"news_id\":\"" + infoDt.Rows[j]["ADLink"] + "\"";
                                                videoliststr += "}";
                                                videoliststr += "}";
                                                videoliststr += "},";
                                            }

                                            #endregion

                                            tmpInfo += "},";

                                            imglist.Add(infoDt.Rows[j]["PicAttID"].ToString());

                                        }
                                        tmp += tmpInfo.Substring(0, tmpInfo.Length - 1);
                                    }
                                    tmp += "]";
                                    tmp += "},";
                                }
                                json.Append(tmp.Substring(0, tmp.Length - 1));
                            }
                            json.Append("],");

                            #endregion

                            #region 专题列表

                            json.Append("\"topic_list\":");
                            json.Append("[");

                            StringBuilder sqltopic = new StringBuilder();
                            sqltopic.Append("select * from Infos where TIID in(select TIID FROM TempInfo where  ");
                            sqltopic.Append("ITID in(select ITID from InfoType where SPID in ");
                            sqltopic.Append(
                                " (select StaPackage.SPID FROM StaPackage join OrgPkgList on OrgPkgList.SPID=StaPackage.SPID ");
                            sqltopic.Append(" join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId ");
                            sqltopic.Append(" where OrgPkgList.RPID='" + rpmodel.RPID + "' and OrgPkgList.OrgId='" + orgmodel.OrgId + "'))) and IType=3 ");

                            DbCommand dbCommandTopic = db.GetSqlStringCommand(sqltopic.ToString());

                            var iidt = db.ExecuteDataSet(dbCommandTopic).Tables[0];
                            if (iidt.Rows.Count > 0)
                            {
                                var tmp = "";
                                for (int i = 0; i < iidt.Rows.Count; i++)
                                {
                                    tmp += "{";
                                    tmp += "\"topic_id\":\"" + iidt.Rows[i]["IID"] + "\",";
                                    tmp += "\"topic_title\":\"" + iidt.Rows[i]["IName"] + "\",";
                                    tmp += "\"topic_page_list\":";
                                    tmp += "[";

                                    List<SqlParameter> parTmpInfotopic = new List<SqlParameter>();
                                    var tmpinfotopicDt =
                                        _tempInfoDal.GetList(" ParentID=" + iidt.Rows[i]["IID"] + " order by TIPage ",
                                            parTmpInfotopic).Tables[0];
                                    if (tmpinfotopicDt.Rows.Count > 0)
                                    {
                                        var tmpInfo = "";
                                        for (int j = 0; j < tmpinfotopicDt.Rows.Count; j++)
                                        {
                                            tmpInfo += "{\"page_id\":\"" + tmpinfotopicDt.Rows[j]["TIID"] + "\"},";
                                        }
                                        tmp += tmpInfo.Substring(0, tmpInfo.Length - 1);
                                    }

                                    tmp += "]";
                                    tmp += "},";
                                }
                                json.Append(tmp.Substring(0, tmp.Length - 1));
                            }
                            json.Append("],");

                            #endregion

                            #region 资讯列表

                            json.Append("\"news_list\":");
                            json.Append("[");

                            StringBuilder sqlNews = new StringBuilder();
                            sqlNews.Append("select * from Infos where TIID in(select TIID FROM TempInfo where  ");
                            sqlNews.Append("ITID in(select ITID from InfoType where SPID in ");
                            sqlNews.Append(
                                " (select StaPackage.SPID FROM StaPackage join OrgPkgList on OrgPkgList.SPID=StaPackage.SPID ");
                            sqlNews.Append(" join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId ");
                            sqlNews.Append(" where OrgPkgList.RPID='" + rpmodel.RPID + "' and OrgPkgList.OrgId='" + orgmodel.OrgId + "'))) and IType=1 ");

                            DbCommand dbCommandNews = db.GetSqlStringCommand(sqlNews.ToString());

                            var newsdt = db.ExecuteDataSet(dbCommandNews).Tables[0];
                            if (newsdt.Rows.Count > 0)
                            {
                                var tmp = "";
                                for (int i = 0; i < newsdt.Rows.Count; i++)
                                {
                                    tmp += "{";
                                    tmp += "\"news_id\":\"" + newsdt.Rows[i]["IID"] + "\",";
                                    tmp += "\"news_title\":\"" + newsdt.Rows[i]["IName"] + "\",";
                                    tmp += "\"content_list\":";
                                    tmp += "[";

                                    List<SqlParameter> parTmpInfoNews = new List<SqlParameter>();
                                    var tmpinfoNewsDt =
                                        _tempInfoDal.GetList(
                                            " ParentID=" + newsdt.Rows[i]["IID"] + " and TID in(15,16) order by TIPage ",
                                            parTmpInfoNews).Tables[0];
                                    if (tmpinfoNewsDt.Rows.Count > 0)
                                    {
                                        var tmpInfo = "";
                                        for (int j = 0; j < tmpinfoNewsDt.Rows.Count; j++)
                                        {
                                            tmpInfo += "{\"content_id\":\"" + tmpinfoNewsDt.Rows[j]["TIID"] + "\"},";
                                        }
                                        tmp += tmpInfo.Substring(0, tmpInfo.Length - 1);
                                    }

                                    tmp += "],";

                                    tmp += "\"news_ad\":";
                                    tmp += "{";
                                    List<SqlParameter> parti = new List<SqlParameter>();
                                    var tiAdDt = _tempInfoDal.GetModel(" ParentID=" + newsdt.Rows[i]["IID"] + " and TIPage is NULL and TID in(17,18) ", parti);

                                    if (null != tiAdDt)
                                    {
                                        List<SqlParameter> pari1 = new List<SqlParameter>();
                                        var imodel = _infosDal.GetModel(" TIID=" + tiAdDt.TIID, pari1);
                                        if (null != imodel)
                                        {
                                            tmp += "\"news_ad_id\":\"" + tiAdDt.TIID + "\",";

                                            var img = "";
                                            if (!string.IsNullOrEmpty(imodel.PicAttID))
                                            {
                                                if ("C0pY" == imodel.PicAttID.Substring(0, 4))
                                                {
                                                    img = imodel.PicAttID.Substring(40, 36);
                                                }
                                                else
                                                {
                                                    img = imodel.PicAttID.Substring(0, 36);
                                                }
                                                if (imodel.PicAttID.LastIndexOf('.') != -1)
                                                {
                                                    img += imodel.PicAttID.Substring(imodel.PicAttID.LastIndexOf('.'));
                                                }
                                            }
                                            tmp += "\"news_ad_image_path\":\"image/" + img + "\",";

                                            tmp += "\"news_ad_content\": {\"news_id\":\"" + imodel.IID +
                                                   "\", \"news_title\":\"" + imodel.IName + "\"},";
                                            List<SqlParameter> pari = new List<SqlParameter>();
                                            var idt = _adInfosDal.GetList(" IID=" + imodel.IID, pari).Tables[0];
                                            tmp += "\"recommend_news_list\": [";
                                            if (idt.Rows.Count > 0)
                                            {
                                                var tmpInfo = "";
                                                for (int j = 0; j < idt.Rows.Count; j++)
                                                {
                                                    var inmodel =
                                                        _infosDal.GetModel(Convert.ToInt32(idt.Rows[j]["Inf_IID"]));
                                                    if (null != inmodel)
                                                    {
                                                        tmpInfo += "{\"news_id\":\"" + inmodel.IID +
                                                                   "\", \"news_title\":\"" + inmodel.IName + "\"},";
                                                    }
                                                }
                                                tmp += tmpInfo.Substring(0, tmpInfo.Length - 1);
                                            }
                                            tmp += "]";
                                            imglist.Add(imodel.PicAttID);
                                        }
                                    }
                                    tmp += "}";

                                    tmp += "},";
                                }
                                json.Append(tmp.Substring(0, tmp.Length - 1));
                            }
                            json.Append("],");

                            #endregion

                            #region 内容列表

                            json.Append("\"content_list\":");
                            json.Append("[");

                            StringBuilder sqlCon = new StringBuilder();
                            sqlCon.Append("select TIID,ITID,TID,AttID,TIPage,ParentID FROM TempInfo ");
                            sqlCon.Append("where TID in(select TID from Templates where TType=2) ");
                            sqlCon.Append("and ITID in(select ITID from InfoType where ");
                            sqlCon.Append("SPID in (select StaPackage.SPID FROM StaPackage join OrgPkgList on OrgPkgList.SPID=StaPackage.SPID ");
                            sqlCon.Append(" join OrgOrganize on OrgOrganize.OrgId=StaPackage.OrgId ");
                            sqlCon.Append(" where OrgPkgList.RPID='" + rpmodel.RPID + "' and OrgPkgList.OrgId='" + orgmodel.OrgId + "')) order by TIPage ");

                            DbCommand dbCommandCon = db.GetSqlStringCommand(sqlCon.ToString());

                            var condt = db.ExecuteDataSet(dbCommandCon).Tables[0];
                            if (condt.Rows.Count > 0)
                            {
                                var tmp = "";
                                for (int i = 0; i < condt.Rows.Count; i++)
                                {
                                    var img = "";
                                    var txt = "";
                                    var atttmp = "";
                                    if (condt.Rows[i]["TID"].ToString() == "15")
                                    {
                                        List<SqlParameter> partxt = new List<SqlParameter>();
                                        var txtDt =
                                            _infosDal.GetList(" TIID=" + condt.Rows[i]["TIID"] + " order by SortNum ",
                                                partxt).Tables[0];
                                        if (txtDt.Rows.Count > 0)
                                        {
                                            txt += "\"text\":\"" + txtDt.Rows[0]["Context"] + "\",";
                                            txt += "\"text_position\": \"" + txtDt.Rows[0]["ConPosition"] + "\",";
                                            txt += "\"font_size\":\"" + txtDt.Rows[0]["ConSize"] + "\",";
                                            txt += "\"text_color\":\"#" + txtDt.Rows[0]["ConColor"] + "\"";

                                            if (DBNull.Value != txtDt.Rows[0]["PicAttID"])
                                            {
                                                if (!string.IsNullOrEmpty(txtDt.Rows[0]["PicAttID"].ToString()))
                                                {
                                                    atttmp = txtDt.Rows[0]["PicAttID"].ToString();
                                                    if ("C0pY" == txtDt.Rows[0]["PicAttID"].ToString().Substring(0, 4))
                                                    {
                                                        img = txtDt.Rows[0]["PicAttID"].ToString().Substring(40, 36);
                                                    }
                                                    else
                                                    {
                                                        img = txtDt.Rows[0]["PicAttID"].ToString().Substring(0, 36);
                                                    }
                                                    if (txtDt.Rows[0]["PicAttID"].ToString().LastIndexOf('.') != -1)
                                                    {
                                                        img += txtDt.Rows[0]["PicAttID"].ToString().Substring(txtDt.Rows[0]["PicAttID"].ToString().LastIndexOf('.'));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (DBNull.Value != condt.Rows[i]["AttID"])
                                        {
                                            if (!string.IsNullOrEmpty(condt.Rows[i]["AttID"].ToString()))
                                            {
                                                atttmp = condt.Rows[i]["AttID"].ToString();
                                                if ("C0pY" == condt.Rows[i]["AttID"].ToString().Substring(0, 4))
                                                {
                                                    img = condt.Rows[i]["AttID"].ToString().Substring(40, 36);
                                                }
                                                else
                                                {
                                                    img = condt.Rows[i]["AttID"].ToString().Substring(0, 36);
                                                }
                                                if (condt.Rows[i]["AttID"].ToString().LastIndexOf('.') != -1)
                                                {
                                                    img += condt.Rows[i]["AttID"].ToString().Substring(condt.Rows[i]["AttID"].ToString().LastIndexOf('.'));
                                                }
                                            }
                                        }
                                    }
                                    imglist.Add(atttmp);
                                    tmp += "{";
                                    tmp += "\"content_id\":\"" + condt.Rows[i]["TIID"] + "\",";
                                    tmp += "\"content_type\":\"" +
                                           (condt.Rows[i]["TID"].ToString() == "15" ? "text" : "image") + "\",";
                                    tmp += "\"content_image_path\":\"image/" + img + "\",";
                                    tmp += "\"text_info\":";
                                    tmp += "{";
                                    if (condt.Rows[i]["TID"].ToString() == "15")
                                    {
                                        tmp += txt;
                                    }
                                    tmp += "},";
                                    tmp += "\"hot_list\":";
                                    tmp += "[";
                                    if (condt.Rows[i]["TID"].ToString() == "16")
                                    {
                                        List<SqlParameter> parhot = new List<SqlParameter>();
                                        var hotDt =
                                            _infosDal.GetList(" TIID=" + condt.Rows[i]["TIID"] + " order by SortNum ",
                                                parhot)
                                                .Tables[0];
                                        if (hotDt.Rows.Count > 0)
                                        {
                                            var tmpInfo = "";
                                            for (int j = 0; j < hotDt.Rows.Count; j++)
                                            {
                                                tmpInfo += "{";
                                                tmpInfo += "\"hot_id\":\"" + hotDt.Rows[j]["IID"] + "\",";
                                                tmpInfo += "\"hot_center\":{\"x\":\"" + hotDt.Rows[j]["XPosition"] +
                                                           "\", \"y\":\"" + hotDt.Rows[j]["YPosition"] + "\"},";

                                                #region 热点图标

                                                var hoticon = "";
                                                if (DBNull.Value != hotDt.Rows[j]["ADPic"])
                                                {
                                                    if (!string.IsNullOrEmpty(hotDt.Rows[j]["ADPic"].ToString()))
                                                    {
                                                        if ("C0pY" == hotDt.Rows[j]["ADPic"].ToString().Substring(0, 4))
                                                        {
                                                            hoticon = hotDt.Rows[j]["ADPic"].ToString()
                                                                .Substring(40, 36);
                                                        }
                                                        else
                                                        {
                                                            hoticon = hotDt.Rows[j]["ADPic"].ToString().Substring(0, 36);
                                                        }
                                                        if (hotDt.Rows[j]["ADPic"].ToString().LastIndexOf('.') != -1)
                                                        {
                                                            hoticon +=
                                                                hotDt.Rows[j]["ADPic"].ToString()
                                                                    .Substring(
                                                                        hotDt.Rows[j]["ADPic"].ToString()
                                                                            .LastIndexOf('.'));
                                                        }
                                                    }
                                                }
                                                if (hoticon == "")
                                                {
                                                    tmpInfo += "\"hot_icon\":\"image/hand.png\",";
                                                    imglist.Add("hand.png");
                                                }
                                                else
                                                {
                                                    tmpInfo += "\"hot_icon\":\"image/" + hoticon + "\",";
                                                    imglist.Add(hotDt.Rows[j]["ADPic"].ToString());
                                                }

                                                #endregion

                                                #region 热点类型

                                                var hottype = "image";
                                                if ("2" == hotDt.Rows[j]["HotType"].ToString())
                                                {
                                                    hottype = "video";
                                                }
                                                tmpInfo += "\"hot_type\":\"" + hottype + "\",";

                                                #endregion

                                                tmpInfo += "\"hot_video_id\":\"" + hotDt.Rows[j]["IID"] + "\",";
                                                tmpInfo += "\"hot_image_list\":";
                                                tmpInfo += "[";
                                                if ("2" == hotDt.Rows[j]["HotType"].ToString())
                                                {
                                                    #region 热点视频列表

                                                    List<SqlParameter> parhotimg = new List<SqlParameter>();
                                                    var hotimgDt =
                                                        _attaListDal.GetList(" IID=" + hotDt.Rows[j]["IID"], parhotimg)
                                                            .Tables[0];
                                                    if (hotimgDt.Rows.Count > 0)
                                                    {
                                                        #region 旧视频列表

                                                        //var tmpimg = "";
                                                        //for (int k = 0; k < hotimgDt.Rows.Count; k++)
                                                        //{
                                                        //    var img1 = "";
                                                        //    if (DBNull.Value != hotimgDt.Rows[k]["AttID"])
                                                        //    {
                                                        //        if (
                                                        //            !string.IsNullOrEmpty(
                                                        //                hotimgDt.Rows[k]["AttID"].ToString()))
                                                        //        {
                                                        //            if ("C0pY" ==
                                                        //                hotimgDt.Rows[k]["AttID"].ToString()
                                                        //                    .Substring(0, 4))
                                                        //            {
                                                        //                img1 =
                                                        //                    hotimgDt.Rows[k]["AttID"].ToString()
                                                        //                        .Substring(40, 36);
                                                        //            }
                                                        //            else
                                                        //            {
                                                        //                img1 =
                                                        //                    hotimgDt.Rows[k]["AttID"].ToString()
                                                        //                        .Substring(0, 36);
                                                        //            }
                                                        //            if (
                                                        //                hotimgDt.Rows[k]["AttID"].ToString()
                                                        //                    .LastIndexOf('.') != -1)
                                                        //            {
                                                        //                img1 +=
                                                        //                    hotimgDt.Rows[k]["AttID"].ToString()
                                                        //                        .Substring(
                                                        //                            hotimgDt.Rows[k]["AttID"].ToString()
                                                        //                                .LastIndexOf('.'));
                                                        //            }
                                                        //        }
                                                        //    }
                                                        //    tmpimg += "{\"video_path\":\"video/" + img1 +
                                                        //              "\"},";
                                                        //    videolist.Add(hotimgDt.Rows[k]["AttID"].ToString());
                                                        //}
                                                        //tmpInfo += tmpimg.Substring(0, tmpimg.Length - 1);

                                                        #endregion

                                                        #region 新视频列表

                                                        var img1 = "";
                                                        if (DBNull.Value != hotimgDt.Rows[0]["AttID"])
                                                        {
                                                            if (
                                                                !string.IsNullOrEmpty(
                                                                    hotimgDt.Rows[0]["AttID"].ToString()))
                                                            {
                                                                if ("C0pY" ==
                                                                    hotimgDt.Rows[0]["AttID"].ToString()
                                                                        .Substring(0, 4))
                                                                {
                                                                    img1 =
                                                                        hotimgDt.Rows[0]["AttID"].ToString()
                                                                            .Substring(40, 36);
                                                                }
                                                                else
                                                                {
                                                                    img1 =
                                                                        hotimgDt.Rows[0]["AttID"].ToString()
                                                                            .Substring(0, 36);
                                                                }
                                                                if (
                                                                    hotimgDt.Rows[0]["AttID"].ToString()
                                                                        .LastIndexOf('.') != -1)
                                                                {
                                                                    img1 +=
                                                                        hotimgDt.Rows[0]["AttID"].ToString()
                                                                            .Substring(
                                                                                hotimgDt.Rows[0]["AttID"].ToString()
                                                                                    .LastIndexOf('.'));
                                                                }
                                                            }
                                                        }
                                                        videolist.Add(hotimgDt.Rows[0]["AttID"].ToString());

                                                        videoliststr += "{";
                                                        videoliststr += "\"video_id\":\"" + hotDt.Rows[j]["IID"] + "\",";
                                                        videoliststr += "\"video_path\":\"video/" + img1 + "\",";
                                                        videoliststr += "\"video_ad\":";
                                                        videoliststr += "{";
                                                        videoliststr += "}";
                                                        videoliststr += "},";
                                                        #endregion
                                                    }

                                                    #endregion
                                                }
                                                else if ("1" == hotDt.Rows[j]["HotType"].ToString())
                                                {
                                                    #region 热点图片列表

                                                    List<SqlParameter> parhotimg = new List<SqlParameter>();
                                                    var hotimgDt =
                                                        _attaListDal.GetList(" IID=" + hotDt.Rows[j]["IID"], parhotimg)
                                                            .Tables[0];
                                                    if (hotimgDt.Rows.Count > 0)
                                                    {
                                                        var tmpimg = "";
                                                        for (int k = 0; k < hotimgDt.Rows.Count; k++)
                                                        {
                                                            var img1 = "";
                                                            if (DBNull.Value != hotimgDt.Rows[k]["AttID"])
                                                            {
                                                                if (
                                                                    !string.IsNullOrEmpty(
                                                                        hotimgDt.Rows[k]["AttID"].ToString()))
                                                                {
                                                                    if ("C0pY" ==
                                                                        hotimgDt.Rows[k]["AttID"].ToString().Substring(0, 4))
                                                                    {
                                                                        img1 =
                                                                            hotimgDt.Rows[k]["AttID"].ToString()
                                                                                .Substring(40, 36);
                                                                    }
                                                                    else
                                                                    {
                                                                        img1 =
                                                                            hotimgDt.Rows[k]["AttID"].ToString()
                                                                                .Substring(0, 36);
                                                                    }
                                                                    if (
                                                                        hotimgDt.Rows[k]["AttID"].ToString()
                                                                            .LastIndexOf('.') != -1)
                                                                    {
                                                                        img1 +=
                                                                            hotimgDt.Rows[k]["AttID"].ToString()
                                                                                .Substring(
                                                                                    hotimgDt.Rows[k]["AttID"].ToString()
                                                                                        .LastIndexOf('.'));
                                                                    }
                                                                }
                                                            }
                                                            tmpimg += "{\"image_path\":\"image/" + img1 +
                                                                      "\"},";
                                                            imglist.Add(hotimgDt.Rows[k]["AttID"].ToString());
                                                        }
                                                        tmpInfo += tmpimg.Substring(0, tmpimg.Length - 1);
                                                    }

                                                    #endregion
                                                }
                                                tmpInfo += "]";
                                                tmpInfo += "},";
                                            }
                                            tmp += tmpInfo.Substring(0, tmpInfo.Length - 1);
                                        }
                                    }
                                    tmp += "]";
                                    tmp += "},";
                                }
                                json.Append(tmp.Substring(0, tmp.Length - 1));
                            }
                            json.Append("],");

                            #endregion

                            #region 视频列表

                            json.Append("\"video_list\":[");
                            if (!string.IsNullOrEmpty(videoliststr))
                            {
                                json.Append(videoliststr.Substring(0, videoliststr.Length - 1));
                            }
                            json.Append("]");

                            #endregion

                            json.Append("}"); //结束

                            #region 复制文件

                            if (imglist.Count > 0)
                            {
                                foreach (string imgid in imglist)
                                {
                                    if (!string.IsNullOrEmpty(imgid))
                                    {
                                        var fi = new FileInfo(ePath + imgid);
                                        if (fi.Exists)
                                        {
                                            if (imgid.Length >= 36)
                                            {
                                                var img1 = "";
                                                if ("C0pY" == imgid.Substring(0, 4))
                                                {
                                                    img1 = imgid.Substring(40, 36);
                                                }
                                                else
                                                {
                                                    img1 = imgid.Substring(0, 36);
                                                }
                                                if (imgid.LastIndexOf('.') != -1)
                                                {
                                                    img1 += imgid.Substring(imgid.LastIndexOf('.'));
                                                }
                                                fi.CopyTo(storePath + "/image/" + img1, true);
                                            }
                                            else
                                            {
                                                fi.CopyTo(storePath + "/image/" + imgid, true);
                                            }
                                        }
                                    }
                                }
                            }
                            if (videolist.Count > 0)
                            {
                                foreach (string vid in videolist)
                                {
                                    if (!string.IsNullOrEmpty(vid))
                                    {
                                        var fi = new FileInfo(ePath + vid);
                                        if (fi.Exists)
                                        {
                                            if (vid.Length >= 36)
                                            {
                                                var img1 = "";
                                                if ("C0pY" == vid.Substring(0, 4))
                                                {
                                                    img1 = vid.Substring(40, 36);
                                                }
                                                else
                                                {
                                                    img1 = vid.Substring(0, 36);
                                                }
                                                if (vid.LastIndexOf('.') != -1)
                                                {
                                                    img1 += vid.Substring(vid.LastIndexOf('.'));
                                                }
                                                fi.CopyTo(storePath + "/video/" + img1, true);
                                            }
                                            else
                                            {
                                                fi.CopyTo(storePath + "/video/" + vid, true);
                                            }
                                        }
                                    }
                                }
                            }

                            #endregion

                            System.IO.File.WriteAllText(storePath + "/config.json", json.ToString(), Encoding.UTF8);
                            string[] paths = new string[] { Server.MapPath("/Packages/" + fname) };
                            string error = "";
                            //打包
                            MuFileCompress.Pack(paths, Server.MapPath("/Packages/") + fname + ".zip", 6, "",
                                out error);
                            Directory.Delete(Server.MapPath("/Packages/" + fname), true);
                            if (error == "")
                            {
                                Response.Write("0|~|/Packages/" + fname + ".zip");
                                //DownLoadAttBytes(Server.MapPath("/Packages/") + fname + ".zip", fname + ".zip");
                            }
                            else
                            {
                                Response.Write("1|~|" + error);
                                Response.End();
                            }
                            Response.End();
                        }
                        catch (System.Threading.ThreadAbortException ex)
                        {
                        }
                        catch (Exception ee)
                        {
                            Response.Write("1|~|系统错误,请联系管理员!");
                            Response.End();
                        }
                    }
                }
                else
                {
                    Response.Write("1|~|资源包不存在!");
                    Response.End();
                }
            }
        }
        static public string EncodeFileNameForDownload(string FileName)
        {
            //string result = System.Web.HttpUtility.UrlEncode(FileName).Replace("+", " ");
            //此处为了解决文件名中文显示的问题System.Text.Encoding.Default改为System.Text.Encoding.UTF8 by：yzw 20111216

            string result = System.Web.HttpUtility.UrlEncode(System.Text.Encoding.UTF8.GetBytes(FileName)).Replace("+", " ");
            while (result.Length > 120)	//最大长度不超过156，保守取120
            {
                int dn = FileName.LastIndexOf(".");
                if (dn > 0)
                    FileName = FileName.Substring(0, dn - 1) + FileName.Substring(dn);
                else
                    FileName = FileName.Substring(0, FileName.Length - 1);

                //result = System.Web.HttpUtility.UrlEncode(FileName).Replace("+", " ");
                result = System.Web.HttpUtility.UrlEncode(System.Text.Encoding.UTF8.GetBytes(FileName)).Replace("+", " ");
            }
            return result;
        }

        public void DownLoadAttBytes(string filepath, string filename)
        {
            Stream iStream = null;
            // Buffer to read 10K bytes in chunk:
            var buffer = new Byte[10000];
            // Length of the file:
            int length;
            // Total bytes to read:
            long dataToRead;

            try
            {
                iStream = new FileStream(filepath, FileMode.Open,
                    FileAccess.Read, FileShare.Read);
                // Total bytes to read:
                dataToRead = iStream.Length;
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition",
                    "attachment; filename=" + EncodeFileNameForDownload(filename));
                // Read the bytes.
                while (dataToRead > 0)
                {
                    // Verify that the client is connected.
                    if (Response.IsClientConnected)
                    {
                        // Read the data in buffer.
                        length = iStream.Read(buffer, 0, 10000);

                        // Write the data to the current output stream.
                        Response.OutputStream.Write(buffer, 0, length);

                        // Flush the data to the HTML output.
                        Response.Flush();

                        buffer = new Byte[10000];
                        dataToRead = dataToRead - length;
                    }
                    else
                    {
                        //prevent infinite loop if user disconnects
                        dataToRead = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                //LogService.Write("FolderMgr:DownLoadAttBytes(Page page,string attId)");
                //LogService.Write(ex.Message);
            }
            finally
            {
                if (iStream != null)
                {
                    //Close the file.
                    iStream.Close();
                }
            }

        }
        protected string GetType(int iType)
        {
            var type = "";
            switch (iType)
            {
                case 1:
                    type = "news";
                    break;
                case 2: type = "video";
                    break;
                case 3: type = "topic";
                    break;
            }
            return type;
        }
    }
}