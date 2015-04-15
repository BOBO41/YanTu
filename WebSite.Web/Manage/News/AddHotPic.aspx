<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHotPic.aspx.cs" Inherits="WebSite.Web.Manage.News.AddHotPic" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>沿途后台</title>
    <style>
        .upatta img {
            width: 220px;
        }
         .upsigin {
             float: left;
             margin-top: 10px;
         }
         .upatta .upsigin {
             width: 220px;
             float: left;
             margin-top: 10px;
         }
         .upatta2 .upsigin {
             width: 220px;
             float: left;
             margin-top: 10px;
         }
        .load {
            line-height: 5px;
            height: 5px;
            background-color: #ccc;
            position: relative;
            margin-top: 8px;
        }

        .load .pre {
            display: block;
            width: 1%;
            height: 5px;
            background-color: #0C0;
        }

        .imglist {
            padding: 0;
            margin: 0;
            list-style: none;
            overflow: hidden;
            zoom: 1;
        }

        .imglist li {
            float: left;
            width: 100px;
            margin-right: 8px;
            margin-bottom: 15px;
        }

        .imglist li img {
            display: block;
            background-color: #ccc;
            width: 100px;
            height: 100px;
            margin-bottom: 8px;
        }

        .imglist li .load {
            line-height: 5px;
            height: 5px;
            background-color: #ccc;
            position: relative;
            margin-top: 8px;
        }

        .imglist li .load .pre {
            display: block;
            width: 1%;
            height: 5px;
            background-color: #0C0;
        }
    </style>
</head>

<body>
    <form id="form89" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>标题</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="标题" runat="server" />
                    </div>
                </div>
                <div class="control-group" id="cretype" runat="server">
                    <label class="control-label"><span style="color: red;">*</span>热点类型：</label>
                    <div class="controls">
                        <input id="rboSingle" type="radio" runat="server" name="rboSelectType" value="1" onclick="hideorg();" />
                        图片热点
                        <input id="rboDouble" type="radio" runat="server" name="rboSelectType" value="2" onclick="shorg();" />
                        视频热点
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">热点图标</label>
                    <div class="controls">
                        <a href="javascript:;" class="btn btn-default btn-sm type-add" data-original-title="" title="">选择文件</a> <%--<font color="red">大小<%= Request.QueryString["bgw"] %>*<%= Request.QueryString["bgh"] %></font>--%>
                        <div id="queuedivtablecontainer">
                            <asp:Literal ID="litPic" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>位置X</label>
                    <div class="controls">
                        <input type="text" id="txtXPosition" placeholder="位置X" runat="server" style="ime-mode: Disabled" onkeyup="check(this);" /><font color="red">0到980的数值</font>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>位置Y</label>
                    <div class="controls">
                        <input type="text" id="txtYPosition" placeholder="位置Y" runat="server" style="ime-mode: Disabled" onkeyup="check(this);" /><font color="red">0到500的数值</font>
                    </div>
                </div>
                <div class="control-group" id="dorg" runat="server" style="display: none">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>热点图片</label>
                    <div class="controls">
                        <a href="javascript:;" class="btn btn-default btn-sm hotpic-add" data-original-title="" title="">选择文件</a> <font color="red"><%--大小<%= Request.QueryString["bgw"] %>*<%= Request.QueryString["bgh"] %> --%>最多15张</font>
                        <div>
                            <ul class="imglist" style="margin-top: 5px;">
                                <asp:Literal ID="litHotPic" runat="server"></asp:Literal>
                            </ul>
                            <ul class="imglist" id="hotpiccontainer">
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="control-group" id="dvideo" runat="server" style="display: none">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>热点视频</label>
                    <div class="controls">
                        <a href="javascript:;" class="btn btn-default btn-sm video-add" data-original-title="" title="">选择文件</a> <font color="red"><%--最多15个--%>mp4格式视频文件</font>
                        <div>
                            <%--<ul class="imglist" style="margin-top: 5px;">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </ul>
                            <ul class="imglist" id="hotvideocontainer">
                            </ul>--%>
                            <div id="videocontainer">
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAddhpic();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            $(document).ready(function () { window.top.uploader3.reset(); window.top.uploader4.reset(); });
            function check(obj) {
                if (isNaN(obj.value)) {
                    alert("请输入数字");
                    obj.value = "";
                }
            }
            function shorg() {
                document.getElementById("dvideo").style.display = "block";
                document.getElementById("dorg").style.display = "none";
            }
            function hideorg() {
                document.getElementById("dorg").style.display = "block";
                document.getElementById("dvideo").style.display = "none";
            }
            function goAddhpic() {
                var batta = "";
                var name = $("#txtName").val();
                var xposition = $("#txtXPosition").val();
                var yposition = $("#txtYPosition").val();
                var aatta = $(".upatta").attr("data-file");
                var adtype = $("input[name='rboSelectType']:checked").val();
                if (name == "" || name == undefined) {
                    alert("请填写标题");
                    return false;
                }
                if (xposition == "" || xposition == undefined) {
                    alert("请填写位置X");
                    return false;
                }
                if (0 > xposition || xposition > 980) {
                    alert("请填写正确的位置X数值");
                    return false;
                }
                if (yposition == "" || yposition == undefined) {
                    alert("请填写位置Y");
                    return false;
                }
                if (0 > yposition || yposition > 500) {
                    alert("请填写正确的位置Y数值");
                    return false;
                }
                if (adtype == 2) {
                    $(".upatta2").each(function () {
                        batta += $(this).attr("data-file") + ":";
                    });
                    if (batta == "" || batta == undefined) {
                        alert("请上传视频文件");
                        return false;
                    }
                } else {
                    $(".upatta3").each(function () {
                        batta += $(this).attr("data-file") + ":";
                    });
                    if (batta == "" || batta == undefined) {
                        alert("请上传热点图片");
                        return false;
                    }
                }
                $.ajax({
                    type: 'POST',
                    url: "/Manage/News/Ajax_AddHotPic.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=<%=Request.QueryString["sortnum"]%>&name=" + escape(name) + "&batta=" + escape(batta) + "&adtype=" + adtype + "&aatta=" + aatta + "&iid=<%=Request.QueryString["iid"]%>&xposition=" + xposition + "&yposition=" + yposition,
                    success: function (data) {
                        var arr = data.split("|~|");
                        if (arr[0] == 0) {
                            window.top.$modal.destroy();
                            window.top.$op.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>";
                        } else {
                            alert(arr[1]);
                        }
                    }
                });
            }
        </script>
    </form>
</body>
</html>
