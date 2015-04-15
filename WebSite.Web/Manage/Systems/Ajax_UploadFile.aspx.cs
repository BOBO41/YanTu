using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using CuteWebUI;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WebSite.Web.UI;

namespace WebSite.Web.Manage.Systems
{
    public partial class Ajax_UploadFile : WebPage
    {
        readonly JavaScriptSerializer json = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {
            VerifyPage("", false);
            try
            {
                if (!string.IsNullOrEmpty(Request.Form["id"]))
                {
                    var id = HttpUtility.HtmlDecode(Request.Form["id"]);

                    MvcUploader uploader = new MvcUploader(Context);
                    Guid guid = new Guid(id);
                    MvcUploadFile file = uploader.GetUploadedFile(guid);
                    string datatime = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    //string ePath = System.Configuration.ConfigurationManager.AppSettings["EmailTmpDir"];
                    //if (!Directory.Exists(ePath)) //判断是否存在      
                    //{
                    //    Directory.CreateDirectory(ePath);//创建新路径    
                    //}
                    var fname = "";
                    if (file.FileName.LastIndexOf('.') != -1)
                    {
                        fname = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                    }
                    file.MoveTo(Server.MapPath("/UpLoad/") + guid + file.FileName);

                    Response.Write("{\"err\":0,\"msg\":\"Finish" + guid + file.FileName + "\"}");
                    Response.End();
                }
                else
                {
                    Response.Write("{\"err\":1,\"msg\":\"出错了，请重试\"}");
                    Response.End();
                }
            }
            catch (System.Threading.ThreadAbortException ex)
            {
            }
            catch (Exception ee)
            {
                var hastable = new Hashtable();
                hastable.Add("err", 1);
                hastable.Add("msg", ee.Message);
                var res = json.Serialize(hastable);
                Response.Write(res);
                Response.End();
            }

        }

        protected string GetIcon(string fileName)
        {
            var icon = "";
            try
            {
                var extension = fileName.Substring(fileName.LastIndexOf('.') + 1).ToLower();
                if (extension == "doc" || extension == "docx")
                {
                    icon = "doc";
                }
                else if (extension == "jpg" || extension == "bmp" || extension == "jpeg" || extension == "png")
                {
                    icon = "jpg";
                }
                else if (extension == "rar" || extension == "zip" || extension == "7z")
                {
                    icon = "rar";
                }
                else if (extension == "pdf")
                {
                    icon = "pdf";
                }
                else if (extension == "xls" || extension == "xlsx")
                {
                    icon = "xlsx";
                }
                else if (extension == "pptx" || extension == "ppt")
                {
                    icon = "pptx";
                }
                else if (extension == "vsd")
                {
                    icon = "vsd";
                }
                else if (extension == "wma" || extension == "wav" || extension == "mp3" || extension == "aac" || extension == "ra" || extension == "ram" || extension == "mp2" || extension == "ogg" || extension == "aif" || extension == "mpega" || extension == "amr" || extension == "mid" || extension == "midi" || extension == "m4a")
                {
                    icon = "wma";
                }
                return icon;
            }
            catch (Exception)
            {
                return icon;
            }

        }

    }
}