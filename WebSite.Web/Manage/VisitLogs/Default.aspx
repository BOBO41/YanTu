<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite.Web.Manage.VisitLogs.Default" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader, Version=3.0.0.0, Culture=neutral, PublicKeyToken=f834c9a9d8e72b84" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#cbSelAll").click(function () {
                if ($(this).attr("checked")) {
                    $("#tabList input").attr("checked", $(this).attr("checked"));
                } else {
                    $("#tabList input").attr("checked", false);
                }
            });
        });

        function adprev(atta) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ content: "<div class=\"form-horizontal\"><div class=\"modal-body\" style=\"text-align: center;\"><img style=\"width:453px;height:234px;\" src=\"/UploadFiles/" + atta + "\"></div></div><div class=\"modal-footer\"><button class=\"btn\" data-dismiss=\"modal\" aria-hidden=\"true\">关闭</button></div>" });
            window.top.$modal.show();
        }

        function addData() {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Adver/AddAd.aspx', title: '新增广告' });
            window.top.$modal.show();
        }
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Adver/AddAd.aspx?aid=' + aId, title: '编辑广告' });
            window.top.$modal.show();
        }
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
        function navIframe(url) {
            $("#mainFrame", top.document.body).attr("src", url);
        }
    </script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div style="display: none">
            <asp:ScriptManager ID="Scriptmanager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <CuteWebUI:UploadAttachments ID="UploadAttachments3" UploadTypePriority="HTML5,Flash,IFrame,Silverlight" runat="server" MultipleFilesUpload="True"></CuteWebUI:UploadAttachments>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="pannel" style="border-top: none">
            <asp:HiddenField ID="hfsort" runat="server" />
            <div class="pannel-header">
                <strong>访问日志</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    资源包：<asp:DropDownList Style="width: auto" ID="ddlSendType" runat="server" OnSelectedIndexChanged="ddlOrderStatus_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    铁路局：<asp:DropDownList Style="width: auto" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                    开始日期：<input type="text" placeholder="开始日期" runat="server" onfocus="WdatePicker()" id="txtRealName" class="input-small" />
                    结束日期：<input type="text" placeholder="结束日期" runat="server" onfocus="WdatePicker()" id="Text1" class="input-small" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                    <asp:Button ID="btnCount" runat="server" CssClass="btn btn-success" Text="次数排序" OnClick="btnCount_Click" />
                    <asp:Button ID="btnTime" runat="server" CssClass="btn btn-success" Text="时间排序" OnClick="btnTime_Click" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btn btn-success" Text="导出" OnClick="btnExport_Click"/>
                </div>
                <div class="btn-toolbar" style="font-size: 14px;">
                    <%--<a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>--%>
                    <%--<asp:FileUpload ID="fuExcel" runat="server" Style="height: auto; line-height: 0; margin-right: 5px;" /><asp:Button ID="import" runat="server" Text="导入日志" class="btn btn-mini" OnClick="import_Click" />--%><a href="javascript:;" class="btn btn-mini import-add">导入日志</a>  .csv格式的日志文件
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <%--<th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>--%>
                        <th nowrap="nowrap">资源包名称</th>
                        <th nowrap="nowrap">资讯ID</th>
                        <th nowrap="nowrap">资讯标题</th>
                        <th nowrap="nowrap">资讯属性</th>
                        <th nowrap="nowrap">资讯类型</th>
                        <th nowrap="nowrap">所属分站</th>
                        <th nowrap="nowrap">分类名称</th>
                        <th nowrap="nowrap">阅读次数</th>
                        <th nowrap="nowrap">总阅读时间</th>
                        <th nowrap="nowrap">平均阅读时间</th>
                        <th nowrap="nowrap">首次阅读</th>
                        <th nowrap="nowrap">最后阅读</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <%--<td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("IID") %>' Text="" runat="server" /></td>--%>
                                <td style="text-align: center"><%#Eval("RPName")%></td>
                                <td style="text-align: center"><%#Eval("IID")%></td>
                                <td style="text-align: center"><%#Eval("IName")%></td>
                                <td style="text-align: center"><%#GetNType(Eval("NType"))%></td>
                                <td style="text-align: center"><%#GetIType(Eval("IType"))%></td>
                                <td style="text-align: center"><%#Eval("OrgName")%></td>
                                <td style="text-align: center"><%#Eval("TName")%></td>
                                <td style="text-align: center"><%#Eval("vcount")%></td>
                                <td style="text-align: center"><%#FormatTime(Eval("ttime"))%></td>
                                <td style="text-align: center"><%#FormatTime(Eval("atime"))%></td>
                                <td style="text-align: center"><%#Eval("minDate")%></td>
                                <td style="text-align: center"><%#Eval("maxDate")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <uc1:Pager ID="Pager1" runat="server" />
            </div>
            <script>
                var bar = function (event) {
                    uploader3.startbrowse();
                    ures = "";
                    sres = "";
                    //$('.import-add').unbind();
                };
                $('.import-add').bind('click', { dataname: 1 }, bar);

                var hasStarted3 = false;
                var startTime3 = 0;
                var fullSize3 = 0;
                var finishSize3 = 0;
                var queueSize3 = 0;
                var filecount3 = 0;
                var fileupedcount3 = 0;
                var filepercent3 = 0;
                var filespeed3 = 0;
                var timeleft3 = 0;
                var ures = "";
                var sres = "";
                var uploader3 = document.getElementById("<%=UploadAttachments3.ClientID %>");
                uploader3.handlequeueui = myqueueuihandler3;
                function myqueueuihandler3(list) {
                    filecount3 = list.length;
                    fullSize3 = 0;
                    finishSize3 = 0;
                    queueSize3 = 0;
                    fileupedcount3 = 0;
                    for (var i = 0; i < list.length; i++) {
                        var name = list[i].FileName;
                        var size = list[i].FileSize; // (or -1)
                        var stat = list[i].Status; // Finish|Error|Upload|Queue
                        var func = list[i].Cancel;
                        var emsg = list[i].GetClientData();
                        var fid = list[i].InitGuid;
                        if (stat != "Error" && emsg != "remove") {
                            if (stat == "Finish") {
                                fileupedcount3++;
                                finishSize3 += size;
                                if (emsg.substring(0, 6) != "Finish") {
                                    $.ajax({
                                        type: "post",
                                        url: "Ajax_UploadFile.aspx",
                                        data: "id=" + fid + "&fid=" + emsg,
                                        async: false,
                                        dataType: 'json',
                                        success: function (data) {
                                            if (data.err == 1) {
                                                list[i].Status = "Error";
                                                ures += name + ",";
                                            }
                                            if (data.err == 0) {
                                                sres += name + ",";
                                            }
                                            list[i].SetClientData(data.msg);
                                        }
                                    });
                                } else {
                                    //ures += name + ",";
                                }
                            }
                        }
                    }
                    return false; //hide the default;
                }

                uploader3.handleselect = myhandleuploadselect3;
                function myhandleuploadselect3(files) {
                    var folderid = "0";
                    var sames = [];
                    var items = uploader3.getitems();
                    for (var i = 0; i < files.length; i++) {
                        var file = files[i];
                        file.SetClientData(folderid);
                    }
                    if (sames.length > 0) {
                    }
                    window.top.$op = this.window;
                    window.top.$modal = window.top.$.scojs_modal({ content: '<div class=\"form-horizontal\"><div class=\"modal-body\"><p style=\"text-align: center;font-size: 22px;\">日志正在导入,请稍候...</p></div></div>' });
                    window.top.$modal.show();
                    window.top.$(".modal-header a").remove();
                }

                function ToFixed(num) {

                    if (num > 100)
                        return Math.round(num);
                    if (num > 10)
                        return num.toFixed(1);
                    return num.toFixed(2);
                }

                function FormatSize(bytecount) {
                    var str = bytecount + ' B';
                    if (Number(bytecount) >= 2048) { str = ToFixed(bytecount / 1024) + ' KB'; }
                    if (Number(bytecount) >= 2097152) { str = ToFixed(bytecount / 1048576) + ' MB'; }
                    if (Number(bytecount) >= 2147483648) { str = ToFixed(bytecount / 1073741824) + ' GB'; }
                    return str;
                }

                uploader3.handlestart = myhandleuploadstart3;
                function myhandleuploadstart3() {
                    if (hasStarted3) return;
                    hasStarted3 = true;
                    startTime3 = new Date().getTime();
                }

                uploader3.handlestop = myhandleuploadstop3;
                function myhandleuploadstop3() {
                    hasStarted3 = false;

                }

                function CuteWebUI_AjaxUploader_OnTaskComplete(task) {

                }

                uploader3.handlepostback = myhandleuploadpostback3;
                function myhandleuploadpostback3() {
                    hasStarted3 = false;
                    window.top.$modal.destroy();
                    alert("导入成功:" + sres + "\n" + "导入失败:" + ures);
                    window.location = "Default.aspx";
                    return false;
                }

                function CuteWebUI_AjaxUploader_OnError(msg) {
                    return false;
                }
                function CuteWebUI_AjaxUploader_OnTaskError(obj, msg, reason) {
                    var items = uploader3.getitems();
                    for (var j = 0; j < items.length; j++) {
                        var item = items[j];
                        if (item.FileName == obj.FileName && obj.initguid == item.initguid) {
                            item.SetClientData(msg);
                            ures += item.FileName + ",";
                        }
                    }
                    return false;
                }
            </script>
        </div>
    </form>
</body>
</html>
