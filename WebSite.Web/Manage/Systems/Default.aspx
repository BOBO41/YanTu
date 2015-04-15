<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite.Web.Manage.Systems.Default" %>

<%@ Register TagPrefix="CuteWebUI" Namespace="CuteWebUI" Assembly="CuteWebUI.AjaxUploader, Version=3.0.0.0, Culture=neutral, PublicKeyToken=f834c9a9d8e72b84" %>
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta charset="utf-8">
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <link href="/themes/sco.js/css/scojs.css" rel="stylesheet" />
    <script src="/themes/js/jquery.min.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
    <script src="/themes/plugins/jquerylayout/jquery.ui.all.js"></script>
    <script src="/themes/plugins/jquerylayout/jquery.layout.min.js"></script>
    <link href="/Scripts/jquery-ui-1.8.7.custom.css" rel="stylesheet" />
    <script src="/Scripts/jquery-ui-1.8.7.custom.min.js"></script>
    <script type="text/javascript">
        $('body').on('hidden', '.modal', function () {
            $(this).removeData('modal');
        });
        var $modal;
        var $op;
        var $tmp;
        $(document).ready(function () {
            $('body').layout({ resizable: false });
        });
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
    </script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <!--[if lt IE 9]>
        <script src="/js/html5shiv.min.js"></script>
        <script src="/js/respond.min.js"></script>
    <![endif]-->
</head>

<body>
    <form runat="server" id="form86">
        <div style="display: none">
            <asp:ScriptManager ID="Scriptmanager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <CuteWebUI:UploadAttachments ID="UploadAttachments1" UploadTypePriority="HTML5,Flash,IFrame,Silverlight" runat="server" MultipleFilesUpload="false"></CuteWebUI:UploadAttachments>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <CuteWebUI:UploadAttachments ID="UploadAttachments2" UploadTypePriority="HTML5,Flash,IFrame,Silverlight" runat="server" MultipleFilesUpload="false"></CuteWebUI:UploadAttachments>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <CuteWebUI:UploadAttachments ID="UploadAttachments3" UploadTypePriority="HTML5,Flash,IFrame,Silverlight" runat="server" MultipleFilesUpload="True" MaxFilesLimit="15" MaxFilesLimitMsg="最多只能上传{0}个文件."></CuteWebUI:UploadAttachments>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <CuteWebUI:UploadAttachments ID="UploadAttachments4" UploadTypePriority="HTML5,Flash,IFrame,Silverlight" runat="server" MultipleFilesUpload="false" MaxFilesLimitMsg="最多只能上传{0}个文件."></CuteWebUI:UploadAttachments>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
                    <CuteWebUI:UploadAttachments ID="UploadAttachments5" UploadTypePriority="HTML5,Flash,IFrame,Silverlight" runat="server" MultipleFilesUpload="false"></CuteWebUI:UploadAttachments>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <CuteWebUI:UploadAttachments ID="UploadAttachments6" UploadTypePriority="HTML5,Flash,IFrame,Silverlight" runat="server" MultipleFilesUpload="True" MaxFilesLimit="3" MaxFilesLimitMsg="最多只能上传{0}个文件."></CuteWebUI:UploadAttachments>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="ui-layout-center" style="overflow: hidden;">
            <iframe id="mainFrame" name="mainFrame" width="100%" height="100%" frameborder="0" scrolling="auto" src="/Manage/Systems/Welcome.aspx"></iframe>
        </div>
        <div class="ui-layout-north" style="overflow: visible;">
            <div class="top clearfix">
                <div class="pull-left">
                    <div class="logo" onclick="window.location='/Manage/Systems/Default.aspx'" style="cursor: pointer">
                        <asp:Literal ID="litTitle" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="pull-right">
                    <div class="top-info">
                        <i class="icon-user icon-white"></i>
                        <asp:Literal ID="litUserName" runat="server"></asp:Literal>
                        登陆成功！<br>
                        <a href="javascript:void(0);" onclick="openModal('/Manage/Systems/ChangePass.aspx','修改密码')"><i class="icon-lock icon-white"></i>修改密码</a>
                        <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click"><i class=" icon-remove-circle icon-white"></i>退出系统</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="bar">
                <div class="pull-left"><i class="icon-user"></i>当前用户角色 <strong style="color: #C30;">系统管理员</strong></div>
                <div class="pull-right"><i class="icon-time"></i>年月日 时分秒</div>
            </div>
        </div>
        <div class="ui-layout-west">
            <h3 class="titbar mb">系统菜单</h3>
            <div class="dl-menu">
                <asp:Literal ID="litRoleTree" runat="server"></asp:Literal>
            </div>
        </div>
        <%--背景图片--%>
        <script>
            $(".type-add").live("click", function () {
                window.top.uploader.reset();
                window.top.uploader.startbrowse();
            });
            var hasStarted = false;
            var startTime = 0;
            var fullSize = 0;
            var finishSize = 0;
            var queueSize = 0;
            var filecount = 0;
            var fileupedcount = 0;
            var filepercent = 0;
            var filespeed = 0;
            var timeleft = 0;
            var uploader = document.getElementById("<%=UploadAttachments1.ClientID %>");
            uploader.handlequeueui = myqueueuihandler;
            function myqueueuihandler(list) {
                filecount = list.length;
                fullSize = 0;
                finishSize = 0;
                queueSize = 0;
                document.getElementById("queuedivtablecontainer").style.display = "";
                var container = document.getElementById("queuedivtablecontainer");
                container.innerHTML = "";
                fileupedcount = 0;
                for (var i = 0; i < list.length; i++) {
                    var name = list[i].FileName;
                    var size = list[i].FileSize; // (or -1)
                    var stat = list[i].Status; // Finish|Error|Upload|Queue
                    var func = list[i].Cancel;
                    var emsg = list[i].GetClientData();
                    var fid = list[i].InitGuid;

                    if (stat != "Error" && emsg != "remove") {
                        var div = document.createElement("div");
                        div.className = "upatta";
                        var divatt = document.createElement("div");
                        divatt.className = "upsigin";
                        div.appendChild(divatt);
                        var divfile = document.createElement("div");
                        divfile.className = "at-file";
                        divatt.appendChild(divfile);
                        fullSize += size;

                        var img = document.createElement("img");
                        img.id = "at-img";
                        img.style.width = 220;
                        //img.style.height = 100;
                        var spanname = document.createElement("span");
                        spanname.className = "at-name";
                        if (name.length > 10) {
                            spanname.innerHTML = name.substring(0, 10) + "...";
                        } else {
                            spanname.innerHTML = name;
                        }
                        div.title = name;

                        var tstat = document.createElement("span");
                        tstat.className = "at-pre";
                        tstat.style.float = "right";
                        if (stat == "Upload") {
                            tstat.id = "tstat";
                            fileupedcount++;
                            tstat.innerHTML = filepercent + "%";
                        }
                        if (stat == "Queue") {
                            queueSize += size;
                            tstat.innerHTML = "排队ing";
                        }
                        if (stat == "Error") {
                            fileupedcount++;
                            finishSize += size;
                            tstat.innerHTML = "失败";
                            tstat.title = emsg;
                        }
                        if (stat == "Finish") {
                            fileupedcount++;
                            finishSize += size;
                            tstat.innerHTML = " 完成";
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
                                            tstat.innerHTML = "失败";
                                        }
                                        if (data.err == 0) {
                                            //$("#txtFileName").val(data.msg.split("|")[1]);
                                            div.setAttribute("data-file", data.msg.substring(6));
                                            img.src = "/UpLoad/" + data.msg.substring(6);
                                            divfile.appendChild(img);
                                        }
                                        list[i].SetClientData(data.msg);
                                    }
                                });
                            } else {
                                div.setAttribute("data-file", emsg.substring(6));
                            }
                        }

                        //var tsize = document.createElement("span");
                        //tsize.className = "at-size";
                        //tsize.innerHTML = FormatSize(size);

                        //var lastspan = document.createElement("span");
                        //var last = document.createElement("a");
                        //last.href = "javascript:void(0)";
                        //last.className = "glyphicon glyphicon-remove delfile";
                        //last.setAttribute("data-attid", fid);
                        //last.title = "移除文件";
                        //last.onclick = func;
                        //lastspan.appendChild(last);

                        //divfile.appendChild(lastspan);

                        //divfile.appendChild(tsize);

                        divfile.appendChild(spanname);

                        divfile.appendChild(tstat);

                        var divBar = document.createElement("div");
                        divBar.className = "load";
                        var spanBar = document.createElement("span");
                        spanBar.className = "pre";
                        divBar.appendChild(spanBar);
                        if (stat == "Upload") {
                            spanBar.style.width = filepercent + "%";
                            spanBar.id = "progressInfo";
                            spanBar.innerHTML = "&nbsp;";
                        } else if (stat == "Queue") {
                            spanBar.style.width = 0;
                            spanBar.innerHTML = "&nbsp;";
                        }
                        else {
                            spanBar.style.width = "100%";
                            spanBar.innerHTML = "&nbsp;";
                        }
                        divatt.appendChild(divBar);
                        container.appendChild(div);
                    }
                }
                return false; //hide the default;
            }

            uploader.handleselect = myhandleuploadselect;
            function myhandleuploadselect(files) {
                var folderid = "0";
                var sames = [];
                var items = uploader.getitems();
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    if (file.FileSize > 614400) {
                        alert("请上传小于600K的图片");
                        file.Cancel();
                    } else {
                        file.SetClientData(folderid);
                    }
                }
                if (sames.length > 0) {
                }
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

            uploader.handlestart = myhandleuploadstart;
            function myhandleuploadstart() {
                if (hasStarted) return;
                hasStarted = true;
                startTime = new Date().getTime();
            }

            uploader.handlestop = myhandleuploadstop;
            function myhandleuploadstop() {
                hasStarted = false;
            }

            function CuteWebUI_AjaxUploader_OnTaskComplete(task) {

            }

            uploader.handlepostback = myhandleuploadpostback;
            function myhandleuploadpostback() {
                hasStarted = false;
                return false;
            }

            uploader.handleprogress = myhandleuploadprogress;
            function myhandleuploadprogress(enable, filename, begintime, uploadedsize, totalsize) {
                var progressInfo = document.getElementById("progressInfo");
                if (fullSize < 0) {
                    progressInfo.innerHTML = "";
                    return true;
                }
                if (!enable)
                    return false;
                if (!totalsize)
                    return false;
                var size1 = finishSize + uploadedsize;
                var size2 = queueSize + totalsize - uploadedsize;
                var size3 = size1 + size2;
                var seconds = (new Date().getTime() - startTime) / 1000;
                var speed = size1 / seconds;
                timeleft = size2 / speed;
                filepercent = Math.round(uploadedsize / totalsize * 100);
                filespeed = FormatSize(Math.round(speed));
                progressInfo.style.width = filepercent + "%";
                var tstat = document.getElementById("tstat");
                tstat.innerHTML = filepercent + "%(" + filespeed + "/s)";
                return false;
            }
            function CuteWebUI_AjaxUploader_OnError(msg) {
                return false;
            }
            function CuteWebUI_AjaxUploader_OnTaskError(obj, msg, reason) {
                var items = uploader.getitems();
                for (var j = 0; j < items.length; j++) {
                    var item = items[j];
                    if (item.FileName == obj.FileName && obj.initguid == item.initguid) {
                        item.SetClientData(msg);
                    }
                }
                return false;
            }
        </script>

        <%--单文件视频--%>
        <script>
            $(".video-add").live("click", function () {
                window.top.uploader2.reset();
                window.top.uploader2.startbrowse();
            });
            var hasStarted2 = false;
            var startTime2 = 0;
            var fullSize2 = 0;
            var finishSize2 = 0;
            var queueSize2 = 0;
            var filecount2 = 0;
            var fileupedcount2 = 0;
            var filepercent2 = 0;
            var filespeed2 = 0;
            var timeleft2 = 0;
            var uploader2 = document.getElementById("<%=UploadAttachments2.ClientID %>");
            uploader2.handlequeueui = myqueueuihandler2;
            function myqueueuihandler2(list) {
                filecount2 = list.length;
                fullSize2 = 0;
                finishSize2 = 0;
                queueSize2 = 0;
                document.getElementById("videocontainer").style.display = "";
                var container = document.getElementById("videocontainer");
                container.innerHTML = "";
                fileupedcount2 = 0;
                for (var i = 0; i < list.length; i++) {
                    var name = list[i].FileName;
                    var size = list[i].FileSize; // (or -1)
                    var stat = list[i].Status; // Finish|Error|Upload|Queue
                    var func = list[i].Cancel;
                    var emsg = list[i].GetClientData();
                    var fid = list[i].InitGuid;
                    if (stat != "Error" && emsg != "remove") {
                        var div = document.createElement("div");
                        div.className = "upatta2";
                        var divatt = document.createElement("div");
                        divatt.className = "upsigin";
                        div.appendChild(divatt);
                        var divfile = document.createElement("div");
                        divfile.className = "at-file";
                        divatt.appendChild(divfile);
                        fullSize2 += size;

                        var img = document.createElement("img");
                        img.id = "at-img";
                        img.style.width = 100;
                        img.style.height = 100;
                        var spanname = document.createElement("span");
                        spanname.className = "at-name";
                        if (name.length > 10) {
                            spanname.innerHTML = name.substring(0, 10) + "...";
                        } else {
                            spanname.innerHTML = name;
                        }
                        div.title = name;

                        var tstat = document.createElement("span");
                        tstat.className = "at-pre";
                        tstat.style.float = "right";
                        if (stat == "Upload") {
                            tstat.id = "tstat2";
                            fileupedcount2++;
                            tstat.innerHTML = filepercent2 + "%";
                        }
                        if (stat == "Queue") {
                            queueSize2 += size;
                            tstat.innerHTML = "排队ing";
                        }
                        if (stat == "Error") {
                            fileupedcount2++;
                            finishSize2 += size;
                            tstat.innerHTML = "失败";
                            tstat.title = emsg;
                        }
                        if (stat == "Finish") {
                            fileupedcount2++;
                            finishSize2 += size;
                            tstat.innerHTML = " 完成";
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
                                            tstat.innerHTML = "失败";
                                        }
                                        if (data.err == 0) {
                                            //$("#txtFileName").val(data.msg.split("|")[1]);
                                            div.setAttribute("data-file", data.msg.substring(6));
                                            //img.src = "/UpLoad/" + data.msg.substring(6);
                                        }
                                        list[i].SetClientData(data.msg);
                                    }
                                });
                            } else {
                                div.setAttribute("data-file", emsg.substring(6));
                            }
                        }

                        //var tsize = document.createElement("span");
                        //tsize.className = "at-size";
                        //tsize.innerHTML = FormatSize(size);

                        //var lastspan = document.createElement("span");
                        //var last = document.createElement("a");
                        //last.href = "javascript:void(0)";
                        //last.className = "glyphicon glyphicon-remove delfile";
                        //last.setAttribute("data-attid", fid);
                        //last.title = "移除文件";
                        //last.onclick = func;
                        //lastspan.appendChild(last);

                        //divfile.appendChild(lastspan);

                        //divfile.appendChild(tsize);
                        //divfile.appendChild(img);
                        divfile.appendChild(spanname);

                        divfile.appendChild(tstat);

                        var divBar = document.createElement("div");
                        divBar.className = "load";
                        var spanBar = document.createElement("span");
                        spanBar.className = "pre";
                        divBar.appendChild(spanBar);
                        if (stat == "Upload") {
                            spanBar.style.width = filepercent2 + "%";
                            spanBar.id = "progressInfo2";
                            spanBar.innerHTML = "&nbsp;";
                        } else if (stat == "Queue") {
                            spanBar.style.width = 0;
                            spanBar.innerHTML = "&nbsp;";
                        }
                        else {
                            spanBar.style.width = "100%";
                            spanBar.innerHTML = "&nbsp;";
                        }
                        divatt.appendChild(divBar);
                        container.appendChild(div);
                    }
                }
                return false; //hide the default;
            }

            uploader2.handleselect = myhandleuploadselect2;
            function myhandleuploadselect2(files) {
                var folderid = "0";
                var sames = [];
                var items = uploader2.getitems();
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    if (file.FileSize > 314572800) {
                        alert("请上传小于300M的视频文件");
                        file.Cancel();
                    } else {
                        file.SetClientData(folderid);
                    }
                }
                if (sames.length > 0) {
                }
            }

            function ToFixed(num) {

                if (num > 100)
                    return Math.round(num);
                if (num > 10)
                    return num.toFixed(1);
                return num.toFixed(2);
            }

            function FormatSize2(bytecount) {
                var str = bytecount + ' B';
                if (Number(bytecount) >= 2048) { str = ToFixed(bytecount / 1024) + ' KB'; }
                if (Number(bytecount) >= 2097152) { str = ToFixed(bytecount / 1048576) + ' MB'; }
                if (Number(bytecount) >= 2147483648) { str = ToFixed(bytecount / 1073741824) + ' GB'; }
                return str;
            }

            uploader2.handlestart = myhandleuploadstart2;
            function myhandleuploadstart2() {
                if (hasStarted2) return;
                hasStarted2 = true;
                startTime2 = new Date().getTime();
            }

            uploader2.handlestop = myhandleuploadstop2;
            function myhandleuploadstop2() {
                hasStarted2 = false;
            }

            function CuteWebUI_AjaxUploader_OnTaskComplete(task) {

            }

            uploader2.handlepostback = myhandleuploadpostback2;
            function myhandleuploadpostback2() {
                hasStarted2 = false;
                return false;
            }

            uploader2.handleprogress = myhandleuploadprogress2;
            function myhandleuploadprogress2(enable, filename, begintime, uploadedsize, totalsize) {
                var progressInfo = document.getElementById("progressInfo2");
                if (fullSize2 < 0) {
                    progressInfo.innerHTML = "";
                    return true;
                }
                if (!enable)
                    return false;
                if (!totalsize)
                    return false;
                var size1 = finishSize2 + uploadedsize;
                var size2 = queueSize2 + totalsize - uploadedsize;
                var size3 = size1 + size2;
                var seconds = (new Date().getTime() - startTime) / 1000;
                var speed = size1 / seconds;
                timeleft2 = size2 / speed;
                filepercent2 = Math.round(uploadedsize / totalsize * 100);
                filespeed2 = FormatSize2(Math.round(speed));
                progressInfo.style.width = filepercent2 + "%";
                var tstat = document.getElementById("tstat2");
                tstat.innerHTML = filepercent2 + "%(" + filespeed2 + "/s)";
                return false;
            }
            function CuteWebUI_AjaxUploader_OnError(msg) {
                return false;
            }
            function CuteWebUI_AjaxUploader_OnTaskError(obj, msg, reason) {
                var items = uploader2.getitems();
                for (var j = 0; j < items.length; j++) {
                    var item = items[j];
                    if (item.FileName == obj.FileName && obj.initguid == item.initguid) {
                        item.SetClientData(msg);
                    }
                }
                return false;
            }
        </script>

        <%--热点图片--%>
        <script>
            $(".delfile").live("click", function () {
                $(this).parent().parent().parent().remove();
            });
            $(".del-hotpic").live("click", function () {
                $(this).parent().remove();
            });
            $(".hotpic-add").live("click", function () {
                if ($(".upatta3").length > 15) {
                    alert("最多只能上传15张图片");
                    return false;
                }
                window.top.uploader3.startbrowse();
            });
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
            var uploader3 = document.getElementById("<%=UploadAttachments3.ClientID %>");
            uploader3.handlequeueui = myqueueuihandler3;
            function myqueueuihandler3(list) {
                filecount3 = list.length;
                fullSize3 = 0;
                finishSize3 = 0;
                queueSize3 = 0;
                var container = document.getElementById("hotpiccontainer");
                container.innerHTML = "";
                fileupedcount3 = 0;
                for (var i = 0; i < list.length; i++) {
                    var name = list[i].FileName;
                    var size = list[i].FileSize; // (or -1)
                    var stat = list[i].Status; // Finish|Error|Upload|Queue
                    var func = list[i].Cancel;
                    var emsg = list[i].GetClientData();
                    var fid = list[i].InitGuid;
                    if (stat != "Error" && emsg != "remove") {
                        var div = document.createElement("li");
                        div.className = "upatta3";
                        var divatt = document.createElement("div");
                        divatt.className = "upsigin";
                        div.appendChild(divatt);
                        var divfile = document.createElement("div");
                        divfile.className = "at-file";
                        divatt.appendChild(divfile);
                        fullSize3 += size;

                        var img = document.createElement("img");
                        img.id = "at-img";
                        img.style.width = 100;
                        img.style.height = 100;
                        var spanname = document.createElement("span");
                        spanname.className = "at-name";
                        if (name.length > 5) {
                            spanname.innerHTML = name.substring(0, 5) + "...";
                        } else {
                            spanname.innerHTML = name;
                        }
                        div.title = name;

                        var tstat = document.createElement("span");
                        tstat.className = "at-pre";
                        if (stat == "Upload") {
                            tstat.id = "tstat3";
                            fileupedcount3++;
                            tstat.innerHTML = filepercent3 + "%";
                        }
                        if (stat == "Queue") {
                            queueSize3 += size;
                            tstat.innerHTML = "排队ing";
                        }
                        if (stat == "Error") {
                            fileupedcount3++;
                            finishSize3 += size;
                            tstat.innerHTML = "失败";
                            tstat.title = emsg;
                        }
                        if (stat == "Finish") {
                            fileupedcount3++;
                            finishSize3 += size;
                            tstat.innerHTML = " 完成";
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
                                            tstat.innerHTML = "失败";
                                        }
                                        if (data.err == 0) {
                                            //$("#txtFileName").val(data.msg.split("|")[1]);
                                            div.setAttribute("data-file", data.msg.substring(6));
                                            img.src = "/UpLoad/" + data.msg.substring(6);
                                        }
                                        list[i].SetClientData(data.msg);
                                    }
                                });
                            } else {
                                div.setAttribute("data-file", emsg.substring(6));
                                img.src = "/UpLoad/" + emsg.substring(6);
                            }
                        }

                        //var tsize = document.createElement("span");
                        //tsize.className = "at-size";
                        //tsize.innerHTML = FormatSize(size);

                        var lastspan = document.createElement("span");
                        var last = document.createElement("a");
                        last.href = "javascript:void(0)";
                        last.className = "glyphicon glyphicon-remove delfile";
                        last.setAttribute("data-attid", fid);
                        last.title = "移除文件";
                        last.onclick = func;
                        last.innerHTML = "删除";
                        lastspan.appendChild(last);

                        //divfile.appendChild(lastspan);

                        //divfile.appendChild(tsize);
                        divfile.appendChild(img);
                        divfile.appendChild(spanname);

                        divfile.appendChild(tstat);

                        var divBar = document.createElement("div");
                        divBar.className = "load";
                        var spanBar = document.createElement("span");
                        spanBar.className = "pre";
                        divBar.appendChild(spanBar);
                        if (stat == "Upload") {
                            spanBar.style.width = filepercent3 + "%";
                            spanBar.id = "progressInfo3";
                            spanBar.innerHTML = "&nbsp;";
                        } else if (stat == "Queue") {
                            spanBar.style.width = 0;
                            spanBar.innerHTML = "&nbsp;";
                        }
                        else {
                            spanBar.style.width = "100%";
                            spanBar.innerHTML = "&nbsp;";
                        }
                        divatt.appendChild(divBar);
                        divatt.appendChild(lastspan);
                        container.appendChild(div);
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
                return false;
            }

            uploader3.handleprogress = myhandleuploadprogress3;
            function myhandleuploadprogress3(enable, filename, begintime, uploadedsize, totalsize) {
                var progressInfo = document.getElementById("progressInfo3");
                if (fullSize3 < 0) {
                    progressInfo.innerHTML = "";
                    return true;
                }
                if (!enable)
                    return false;
                if (!totalsize)
                    return false;
                var size1 = finishSize3 + uploadedsize;
                var size2 = queueSize3 + totalsize - uploadedsize;
                var size3 = size1 + size2;
                var seconds = (new Date().getTime() - startTime) / 1000;
                var speed = size1 / seconds;
                timeleft3 = size2 / speed;
                filepercent3 = Math.round(uploadedsize / totalsize * 100);
                filespeed3 = FormatSize(Math.round(speed));
                progressInfo.style.width = filepercent3 + "%";
                var tstat = document.getElementById("tstat3");
                tstat.innerHTML = filepercent3 + "%(" + filespeed3 + "/s)";
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
                    }
                }
                return false;
            }
        </script>

        <%--热点视频--%>
        <script>
            $(".hotvideo-add").live("click", function () {
                if ($(".upatta4").length > 15) {
                    alert("最多只能上传15个视频");
                    return false;
                }
                window.top.uploader4.startbrowse();
            });
            var hasStarted4 = false;
            var startTime4 = 0;
            var fullSize4 = 0;
            var finishSize4 = 0;
            var queueSize4 = 0;
            var filecount4 = 0;
            var fileupedcount4 = 0;
            var filepercent4 = 0;
            var filespeed4 = 0;
            var timeleft4 = 0;
            var uploader4 = document.getElementById("<%=UploadAttachments4.ClientID %>");
            uploader4.handlequeueui = myqueueuihandler4;
            function myqueueuihandler4(list) {
                filecount4 = list.length;
                fullSize4 = 0;
                finishSize4 = 0;
                queueSize4 = 0;
                var container = document.getElementById("hotvideocontainer");
                container.innerHTML = "";
                fileupedcount4 = 0;
                for (var i = 0; i < list.length; i++) {
                    var name = list[i].FileName;
                    var size = list[i].FileSize; // (or -1)
                    var stat = list[i].Status; // Finish|Error|Upload|Queue
                    var func = list[i].Cancel;
                    var emsg = list[i].GetClientData();
                    var fid = list[i].InitGuid;
                    if (stat != "Error" && emsg != "remove") {
                        var div = document.createElement("li");
                        div.className = "upatta4";
                        var divatt = document.createElement("div");
                        divatt.className = "upsigin";
                        div.appendChild(divatt);
                        var divfile = document.createElement("div");
                        divfile.className = "at-file";
                        divatt.appendChild(divfile);
                        fullSize4 += size;

                        var img = document.createElement("img");
                        img.id = "at-img";
                        img.style.width = 100;
                        img.style.height = 100;
                        var spanname = document.createElement("span");
                        spanname.className = "at-name";
                        if (name.length > 5) {
                            spanname.innerHTML = name.substring(0, 5) + "...";
                        } else {
                            spanname.innerHTML = name;
                        }
                        div.title = name;

                        var tstat = document.createElement("span");
                        tstat.className = "at-pre";
                        if (stat == "Upload") {
                            tstat.id = "tstat4";
                            fileupedcount4++;
                            tstat.innerHTML = filepercent4 + "%";
                        }
                        if (stat == "Queue") {
                            queueSize4 += size;
                            tstat.innerHTML = "排队ing";
                        }
                        if (stat == "Error") {
                            fileupedcount4++;
                            finishSize4 += size;
                            tstat.innerHTML = "失败";
                            tstat.title = emsg;
                        }
                        if (stat == "Finish") {
                            fileupedcount4++;
                            finishSize4 += size;
                            tstat.innerHTML = " 完成";
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
                                            tstat.innerHTML = "失败";
                                        }
                                        if (data.err == 0) {
                                            //$("#txtFileName").val(data.msg.split("|")[1]);
                                            div.setAttribute("data-file", data.msg.substring(6));
                                            //img.src = "/UpLoad/" + data.msg.substring(6);
                                        }
                                        list[i].SetClientData(data.msg);
                                    }
                                });
                            } else {
                                div.setAttribute("data-file", emsg.substring(6));
                                //img.src = "/UpLoad/" + emsg.substring(6);
                            }
                        }

                        //var tsize = document.createElement("span");
                        //tsize.className = "at-size";
                        //tsize.innerHTML = FormatSize(size);

                        var lastspan = document.createElement("span");
                        var last = document.createElement("a");
                        last.href = "javascript:void(0)";
                        last.className = "glyphicon glyphicon-remove delfile";
                        last.setAttribute("data-attid", fid);
                        last.title = "移除文件";
                        last.onclick = func;
                        last.innerHTML = "删除";
                        lastspan.appendChild(last);

                        //divfile.appendChild(lastspan);

                        //divfile.appendChild(tsize);
                        //divfile.appendChild(img);
                        divfile.appendChild(spanname);

                        divfile.appendChild(tstat);

                        var divBar = document.createElement("div");
                        divBar.className = "load";
                        var spanBar = document.createElement("span");
                        spanBar.className = "pre";
                        divBar.appendChild(spanBar);
                        if (stat == "Upload") {
                            spanBar.style.width = filepercent4 + "%";
                            spanBar.id = "progressInfo4";
                            spanBar.innerHTML = "&nbsp;";
                        } else if (stat == "Queue") {
                            spanBar.style.width = 0;
                            spanBar.innerHTML = "&nbsp;";
                        }
                        else {
                            spanBar.style.width = "100%";
                            spanBar.innerHTML = "&nbsp;";
                        }
                        divatt.appendChild(divBar);
                        divatt.appendChild(lastspan);
                        container.appendChild(div);
                    }
                }
                return false; //hide the default;
            }

            uploader4.handleselect = myhandleuploadselect4;
            function myhandleuploadselect4(files) {
                var folderid = "0";
                var sames = [];
                var items = uploader4.getitems();
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    file.SetClientData(folderid);
                }
                if (sames.length > 0) {
                }
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

            uploader4.handlestart = myhandleuploadstart4;
            function myhandleuploadstart4() {
                if (hasStarted4) return;
                hasStarted4 = true;
                startTime4 = new Date().getTime();
            }

            uploader4.handlestop = myhandleuploadstop4;
            function myhandleuploadstop4() {
                hasStarted4 = false;
            }

            function CuteWebUI_AjaxUploader_OnTaskComplete(task) {

            }

            uploader4.handlepostback = myhandleuploadpostback4;
            function myhandleuploadpostback4() {
                hasStarted4 = false;
                return false;
            }

            uploader4.handleprogress = myhandleuploadprogress4;
            function myhandleuploadprogress4(enable, filename, begintime, uploadedsize, totalsize) {
                var progressInfo = document.getElementById("progressInfo4");
                if (fullSize4 < 0) {
                    progressInfo.innerHTML = "";
                    return true;
                }
                if (!enable)
                    return false;
                if (!totalsize)
                    return false;
                var size1 = finishSize4 + uploadedsize;
                var size2 = queueSize4 + totalsize - uploadedsize;
                var size3 = size1 + size2;
                var seconds = (new Date().getTime() - startTime) / 1000;
                var speed = size1 / seconds;
                timeleft4 = size2 / speed;
                filepercent4 = Math.round(uploadedsize / totalsize * 100);
                filespeed4 = FormatSize(Math.round(speed));
                progressInfo.style.width = filepercent4 + "%";
                var tstat = document.getElementById("tstat4");
                tstat.innerHTML = filepercent4 + "%(" + filespeed4 + "/s)";
                return false;
            }
            function CuteWebUI_AjaxUploader_OnError(msg) {
                return false;
            }
            function CuteWebUI_AjaxUploader_OnTaskError(obj, msg, reason) {
                var items = uploader4.getitems();
                for (var j = 0; j < items.length; j++) {
                    var item = items[j];
                    if (item.FileName == obj.FileName && obj.initguid == item.initguid) {
                        item.SetClientData(msg);
                    }
                }
                return false;
            }
        </script>

        <%--暂停广告--%>
        <script>
            $(".adpic1-add").live("click", function () {
                window.top.uploader5.reset();
                window.top.uploader5.startbrowse();
            });
            var hasStarted5 = false;
            var startTime5 = 0;
            var fullSize5 = 0;
            var finishSize5 = 0;
            var queueSize5 = 0;
            var filecount5 = 0;
            var fileupedcount5 = 0;
            var filepercent5 = 0;
            var filespeed5 = 0;
            var timeleft5 = 0;
            var uploader5 = document.getElementById("<%=UploadAttachments5.ClientID %>");
            uploader5.handlequeueui = myqueueuihandler5;
            function myqueueuihandler5(list) {
                filecount5 = list.length;
                fullSize5 = 0;
                finishSize5 = 0;
                queueSize5 = 0;
                document.getElementById("adpcontainer").style.display = "";
                var container = document.getElementById("adpcontainer");
                container.innerHTML = "";
                fileupedcount5 = 0;
                for (var i = 0; i < list.length; i++) {
                    var sele = document.getElementById("ddladlink").cloneNode(true);
                    var name = list[i].FileName;
                    var size = list[i].FileSize; // (or -1)
                    var stat = list[i].Status; // Finish|Error|Upload|Queue
                    var func = list[i].Cancel;
                    var emsg = list[i].GetClientData();
                    var fid = list[i].InitGuid;

                    if (stat != "Error" && emsg != "remove") {
                        var div = document.createElement("div");
                        div.className = "upatta5";
                        var divatt = document.createElement("div");
                        divatt.className = "upsigin";
                        div.appendChild(divatt);
                        var divfile = document.createElement("div");
                        divfile.className = "at-file";
                        divatt.appendChild(divfile);
                        fullSize5 += size;

                        var img = document.createElement("img");
                        img.id = "at-img";
                        img.style.width = 220;
                        //img.style.height = 100;
                        var spanname = document.createElement("span");
                        spanname.className = "at-name";
                        if (name.length > 10) {
                            spanname.innerHTML = name.substring(0, 10) + "...";
                        } else {
                            spanname.innerHTML = name;
                        }
                        div.title = name;

                        var tstat = document.createElement("span");
                        tstat.className = "at-pre";
                        tstat.style.float = "right";
                        if (stat == "Upload") {
                            tstat.id = "tstat5";
                            fileupedcount5++;
                            tstat.innerHTML = filepercent5 + "%";
                        }
                        if (stat == "Queue") {
                            queueSize5 += size;
                            tstat.innerHTML = "排队ing";
                        }
                        if (stat == "Error") {
                            fileupedcount5++;
                            finishSize5 += size;
                            tstat.innerHTML = "失败";
                            tstat.title = emsg;
                        }
                        if (stat == "Finish") {
                            fileupedcount5++;
                            finishSize5 += size;
                            tstat.innerHTML = " 完成";
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
                                            tstat.innerHTML = "失败";
                                        }
                                        if (data.err == 0) {
                                            //$("#txtFileName").val(data.msg.split("|")[1]);
                                            div.setAttribute("data-file", data.msg.substring(6));
                                            img.src = "/UpLoad/" + data.msg.substring(6);
                                            divfile.appendChild(img);
                                        }
                                        list[i].SetClientData(data.msg);
                                    }
                                });
                            } else {
                                div.setAttribute("data-file", emsg.substring(6));
                            }
                        }

                        //var tsize = document.createElement("span");
                        //tsize.className = "at-size";
                        //tsize.innerHTML = FormatSize(size);

                        //var lastspan = document.createElement("span");
                        //var last = document.createElement("a");
                        //last.href = "javascript:void(0)";
                        //last.className = "glyphicon glyphicon-remove delfile";
                        //last.setAttribute("data-attid", fid);
                        //last.title = "移除文件";
                        //last.onclick = func;
                        //lastspan.appendChild(last);

                        //divfile.appendChild(lastspan);

                        //divfile.appendChild(tsize);

                        divfile.appendChild(spanname);

                        divfile.appendChild(tstat);

                        var divBar = document.createElement("div");
                        divBar.className = "load";
                        var spanBar = document.createElement("span");
                        spanBar.className = "pre";
                        divBar.appendChild(spanBar);
                        if (stat == "Upload") {
                            spanBar.style.width = filepercent5 + "%";
                            spanBar.id = "progressInfo5";
                            spanBar.innerHTML = "&nbsp;";
                        } else if (stat == "Queue") {
                            spanBar.style.width = 0;
                            spanBar.innerHTML = "&nbsp;";
                        }
                        else {
                            spanBar.style.width = "100%";
                            spanBar.innerHTML = "&nbsp;";
                        }
                        divatt.appendChild(divBar);
                        sele.id = "ddladlinkad";
                        divatt.appendChild(sele);
                        container.appendChild(div);
                    }
                }
                return false; //hide the default;
            }

            uploader5.handleselect = myhandleuploadselect5;
            function myhandleuploadselect5(files) {
                var folderid = "0";
                var sames = [];
                var items = uploader5.getitems();
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    if (file.FileSize > 614400) {
                        alert("请上传小于600K的图片");
                        file.Cancel();
                    } else {
                        file.SetClientData(folderid);
                    }
                }
                if (sames.length > 0) {
                }
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

            uploader5.handlestart = myhandleuploadstart5;
            function myhandleuploadstart5() {
                if (hasStarted5) return;
                hasStarted5 = true;
                startTime5 = new Date().getTime();
            }

            uploader5.handlestop = myhandleuploadstop5;
            function myhandleuploadstop5() {
                hasStarted5 = false;
            }

            function CuteWebUI_Ajaxuploader_OnTaskComplete(task) {

            }

            uploader5.handlepostback = myhandleuploadpostback5;
            function myhandleuploadpostback5() {
                hasStarted5 = false;
                return false;
            }

            uploader5.handleprogress = myhandleuploadprogress5;
            function myhandleuploadprogress5(enable, filename, begintime, uploadedsize, totalsize) {
                var progressInfo = document.getElementById("progressInfo5");
                if (fullSize5 < 0) {
                    progressInfo.innerHTML = "";
                    return true;
                }
                if (!enable)
                    return false;
                if (!totalsize)
                    return false;
                var size1 = finishSize5 + uploadedsize;
                var size2 = queueSize5 + totalsize - uploadedsize;
                var size3 = size1 + size2;
                var seconds = (new Date().getTime() - startTime5) / 1000;
                var speed = size1 / seconds;
                timeleft5 = size2 / speed;
                filepercent5 = Math.round(uploadedsize / totalsize * 100);
                filespeed5 = FormatSize(Math.round(speed));
                progressInfo.style.width = filepercent5 + "%";
                var tstat = document.getElementById("tstat5");
                tstat.innerHTML = filepercent5 + "%(" + filespeed5 + "/s)";
                return false;
            }
            function CuteWebUI_Ajaxuploader_OnError(msg) {
                return false;
            }
            function CuteWebUI_Ajaxuploader_OnTaskError(obj, msg, reason) {
                var items = uploader5.getitems();
                for (var j = 0; j < items.length; j++) {
                    var item = items[j];
                    if (item.FileName == obj.FileName && obj.initguid == item.initguid) {
                        item.SetClientData(msg);
                    }
                }
                return false;
            }
        </script>

        <%--广告视频--%>
        <script>
            $(".delfile").live("click", function () {
                $(this).parent().parent().parent().remove();
            });
            $(".advideo-add").live("click", function () {
                if ($(".upatta6").length >= 3) {
                    alert("最多只能上传3个广告视频");
                    return false;
                }
                window.top.uploader6.startbrowse();
            });
            var hasStarted6 = false;
            var startTime6 = 0;
            var fullSize6 = 0;
            var finishSize6 = 0;
            var queueSize6 = 0;
            var filecount6 = 0;
            var fileupedcount6 = 0;
            var filepercent6 = 0;
            var filespeed6 = 0;
            var timeleft6 = 0;
            var uploader6 = document.getElementById("<%=UploadAttachments6.ClientID %>");
            uploader6.handlequeueui = myqueueuihandler6;
            function myqueueuihandler6(list) {
                filecount6 = list.length;
                fullSize6 = 0;
                finishSize6 = 0;
                queueSize6 = 0;
                document.getElementById("advideocontainer").style.display = "";
                var container = document.getElementById("advideocontainer");
                container.innerHTML = "";
                fileupedcount6 = 0;
                for (var i = 0; i < list.length; i++) {
                    var sele = document.getElementById("ddladlink").cloneNode(true);
                    var name = list[i].FileName;
                    var size = list[i].FileSize; // (or -1)
                    var stat = list[i].Status; // Finish|Error|Upload|Queue
                    var func = list[i].Cancel;
                    var emsg = list[i].GetClientData();
                    var fid = list[i].InitGuid;
                    if (stat != "Error" && emsg != "remove") {
                        var div = document.createElement("div");
                        div.className = "upatta6";
                        var divatt = document.createElement("div");
                        divatt.className = "upsigin";
                        div.appendChild(divatt);
                        var divfile = document.createElement("div");
                        divfile.className = "at-file";
                        divatt.appendChild(divfile);
                        fullSize6 += size;

                        var img = document.createElement("img");
                        img.id = "at-img";
                        img.style.width = 100;
                        img.style.height = 100;
                        var spanname = document.createElement("span");
                        spanname.className = "at-name";
                        if (name.length > 10) {
                            spanname.innerHTML = name.substring(0, 10) + "...";
                        } else {
                            spanname.innerHTML = name;
                        }
                        div.title = name;

                        var tstat = document.createElement("span");
                        tstat.className = "at-pre";
                        tstat.style.float = "right";
                        if (stat == "Upload") {
                            tstat.id = "tstat6";
                            fileupedcount6++;
                            tstat.innerHTML = filepercent6 + "%";
                        }
                        if (stat == "Queue") {
                            queueSize6 += size;
                            tstat.innerHTML = "排队ing";
                        }
                        if (stat == "Error") {
                            fileupedcount6++;
                            finishSize6 += size;
                            tstat.innerHTML = "失败";
                            tstat.title = emsg;
                        }
                        if (stat == "Finish") {
                            fileupedcount6++;
                            finishSize6 += size;
                            tstat.innerHTML = " 完成";
                            if (emsg.substring(0, 6) != "Finish") {
                                $.ajax({
                                    type: "post",
                                    url: "/Manage/Systems/Ajax_UploadFile.aspx",
                                    data: "id=" + fid + "&fid=" + emsg,
                                    async: false,
                                    dataType: 'json',
                                    success: function (data) {
                                        if (data.err == 1) {
                                            list[i].Status = "Error";
                                            tstat.innerHTML = "失败";
                                        }
                                        if (data.err == 0) {
                                            //$("#txtFileName").val(data.msg.split("|")[1]);
                                            div.setAttribute("data-file", data.msg.substring(6));
                                            //img.src = "/UpLoad/" + data.msg.substring(6);
                                        }
                                        list[i].SetClientData(data.msg);
                                    }
                                });
                            } else {
                                div.setAttribute("data-file", emsg.substring(6));
                            }
                        }

                        //var tsize = document.createElement("span");
                        //tsize.className = "at-size";
                        //tsize.innerHTML = FormatSize(size);

                        var lastspan = document.createElement("span");
                        var last = document.createElement("a");
                        last.href = "javascript:void(0)";
                        last.className = "glyphicon glyphicon-remove delfile";
                        last.setAttribute("data-attid", fid);
                        last.title = "移除文件";
                        last.onclick = func;
                        last.innerHTML = "删除";
                        lastspan.appendChild(last);

                        //divfile.appendChild(lastspan);

                        //divfile.appendChild(tsize);
                        //divfile.appendChild(img);
                        divfile.appendChild(spanname);

                        divfile.appendChild(tstat);

                        var divBar = document.createElement("div");
                        divBar.className = "load";
                        var spanBar = document.createElement("span");
                        spanBar.className = "pre";
                        divBar.appendChild(spanBar);
                        if (stat == "Upload") {
                            spanBar.style.width = filepercent6 + "%";
                            spanBar.id = "progressInfo6";
                            spanBar.innerHTML = "&nbsp;";
                        } else if (stat == "Queue") {
                            spanBar.style.width = 0;
                            spanBar.innerHTML = "&nbsp;";
                        }
                        else {
                            spanBar.style.width = "100%";
                            spanBar.innerHTML = "&nbsp;";
                        }
                        divatt.appendChild(divBar);
                        sele.removeAttribute("id");
                        divatt.appendChild(sele);
                        divatt.appendChild(lastspan);
                        container.appendChild(div);
                    }
                }
                return false; //hide the default;
            }

            uploader6.handleselect = myhandleuploadselect6;
            function myhandleuploadselect6(files) {
                var folderid = "0";
                var sames = [];
                var items = uploader6.getitems();
                for (var i = 0; i < files.length; i++) {
                    var file = files[i];
                    if (file.FileSize > 314572800) {
                        //alert("请上传小于300M的视频文件");
                        file.Cancel();
                    } else {
                        file.SetClientData(folderid);
                    }
                }
                if (sames.length > 0) {
                }
            }

            function ToFixed(num) {

                if (num > 100)
                    return Math.round(num);
                if (num > 10)
                    return num.toFixed(1);
                return num.toFixed(2);
            }

            function FormatSize6(bytecount) {
                var str = bytecount + ' B';
                if (Number(bytecount) >= 2048) { str = ToFixed(bytecount / 1024) + ' KB'; }
                if (Number(bytecount) >= 2097152) { str = ToFixed(bytecount / 1048576) + ' MB'; }
                if (Number(bytecount) >= 2147483648) { str = ToFixed(bytecount / 1073741824) + ' GB'; }
                return str;
            }

            uploader6.handlestart = myhandleuploadstart6;
            function myhandleuploadstart6() {
                if (hasStarted6) return;
                hasStarted6 = true;
                startTime6 = new Date().getTime();
            }

            uploader6.handlestop = myhandleuploadstop6;
            function myhandleuploadstop6() {
                hasStarted6 = false;
            }

            function CuteWebUI_AjaxUploader_OnTaskComplete(task) {

            }

            uploader6.handlepostback = myhandleuploadpostback6;
            function myhandleuploadpostback6() {
                hasStarted6 = false;
                return false;
            }

            uploader6.handleprogress = myhandleuploadprogress6;
            function myhandleuploadprogress6(enable, filename, begintime, uploadedsize, totalsize) {
                var progressInfo = document.getElementById("progressInfo6");
                if (fullSize6 < 0) {
                    progressInfo.innerHTML = "";
                    return true;
                }
                if (!enable)
                    return false;
                if (!totalsize)
                    return false;
                var size1 = finishSize6 + uploadedsize;
                var size2 = queueSize6 + totalsize - uploadedsize;
                var size3 = size1 + size2;
                var seconds = (new Date().getTime() - startTime) / 1000;
                var speed = size1 / seconds;
                timeleft6 = size2 / speed;
                filepercent6 = Math.round(uploadedsize / totalsize * 100);
                filespeed6 = FormatSize6(Math.round(speed));
                progressInfo.style.width = filepercent6 + "%";
                var tstat = document.getElementById("tstat6");
                tstat.innerHTML = filepercent6 + "%(" + filespeed6 + "/s)";
                return false;
            }
            function CuteWebUI_AjaxUploader_OnError(msg) {
                return false;
            }
            function CuteWebUI_AjaxUploader_OnTaskError(obj, msg, reason) {
                var items = uploader6.getitems();
                for (var j = 0; j < items.length; j++) {
                    var item = items[j];
                    if (item.FileName == obj.FileName && obj.initguid == item.initguid) {
                        item.SetClientData(msg);
                    }
                }
                return false;
            }
        </script>
    </form>
</body>
</html>

