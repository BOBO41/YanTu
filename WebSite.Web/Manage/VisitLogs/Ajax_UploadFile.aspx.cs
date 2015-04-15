using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.Script.Serialization;
using CuteWebUI;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace WebSite.Web.Manage.VisitLogs
{
    public partial class Ajax_UploadFile : UI.WebPage
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

                    if (file.FileName.LastIndexOf('.') != -1)
                    {
                        var extension = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                        if (".csv" == extension.ToLower())
                        {
                            var path = Server.MapPath("/TempFile/Excel/") + datatime + ".csv";
                            file.MoveTo(path);
                            var res = import_Click(path);
                            if (res)
                            {
                                Response.Write("{\"err\":0,\"msg\":\"Finish" + guid + file.FileName + "\"}");
                                Response.End();
                            }
                            else
                            {
                                Response.Write("{\"err\":1,\"msg\":\"出错了，请重试\"}");
                                Response.End();
                            }
                        }
                        else
                        {
                            Response.Write("{\"err\":1,\"msg\":\"格式错误\"}");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("{\"err\":1,\"msg\":\"格式错误\"}");
                        Response.End();
                    }
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

        protected bool import_Click(string path)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DbCommand dbCommand = db.GetStoredProcCommand("ImportCsvbulk");
                db.AddInParameter(dbCommand, "@path", DbType.AnsiString, path);
                db.AddParameter(dbCommand, "ReturnValue", DbType.Int32, ParameterDirection.ReturnValue, "", DataRowVersion.Current, null);
                db.ExecuteNonQuery(dbCommand);
                var res = db.GetParameterValue(dbCommand, "ReturnValue").ToString();
                if ("0" == res)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}