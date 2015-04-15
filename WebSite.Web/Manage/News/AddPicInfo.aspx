<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPicInfo.aspx.cs" Inherits="WebSite.Web.Manage.News.AddPicInfo" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>沿途后台</title>
    <style>
        .upsigin {
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
    </style>
</head>

<body>
    <form id="form94" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <%--<div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>标题</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="标题" runat="server" />
                    </div>
                </div>--%>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>背景图</label>
                    <div class="controls">
                        <a href="javascript:;" class="btn btn-default btn-sm type-add" data-original-title="" title="">选择文件</a> <font color="red">大小<%= Request.QueryString["bgw"] %>*<%= Request.QueryString["bgh"] %></font>
                        <div id="queuedivtablecontainer">
                            <asp:Literal ID="litPic" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>文字内容</label>
                    <div class="controls">
                        <textarea id="txtContext" cols="20" rows="8" placeholder="文字内容" runat="server" style="width: 100%;" onkeyup="check(this);"></textarea>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>文字大小</label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlSize">
                            <asp:ListItem Value="-1" Text="请选择" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="14" Text="小"></asp:ListItem>
                            <asp:ListItem Value="18" Text="中"></asp:ListItem>
                            <asp:ListItem Value="22" Text="大"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>文字颜色</label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlColor">
                            <asp:ListItem Value="-1" Text="请选择" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="ffffff" Text="白色"></asp:ListItem>
                            <asp:ListItem Value="ff6a81" Text="粉色"></asp:ListItem>
                            <asp:ListItem Value="00ff24" Text="绿色"></asp:ListItem>
                            <asp:ListItem Value="fff600" Text="亮黄"></asp:ListItem>
                            <asp:ListItem Value="ff6600" Text="橘色"></asp:ListItem>
                            <asp:ListItem Value="00ffde" Text="湖蓝"></asp:ListItem>
                            <asp:ListItem Value="7ea2ff" Text="淡蓝"></asp:ListItem>
                            <asp:ListItem Value="ff0000" Text="红色"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>文字位置</label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlPosi">
                            <asp:ListItem Value="-1" Text="请选择" Selected="True"></asp:ListItem>
                            <%--<asp:ListItem Value="1" Text="上边"></asp:ListItem>--%>
                            <asp:ListItem Value="bottom" Text="下边"></asp:ListItem>
                            <asp:ListItem Value="left" Text="左边"></asp:ListItem>
                            <asp:ListItem Value="right" Text="右边"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAddpin();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function check(obj) {
                if ($("#txtContext").val().length > 1000) {
                    alert("文字内容字数超出1000字，请修改");
                    return false;
                }
            }
            function goAddpin() {
                var batta = $(".upatta").attr("data-file");
                //var name = $("#txtName").val();
                var name = "";
                var context = $("#txtContext").val();
                //if (name == "" || name == undefined) {
                //    alert("请填写标题");
                //    return false;
                //}
                if (batta == "" || batta == undefined) {
                    alert("请上传背景图片");
                    return false;
                }
                if (context.length > 1000) {
                    alert("文字内容字数超出1000字，请修改");
                    return false;
                }
                var csize = $("#<%=ddlSize.ClientID%>").val();
                if (csize == "-1") {
                    alert("请选择文字大小");
                    return false;
                }
                var ccolor = $("#<%=ddlColor.ClientID%>").val();
                if (ccolor == "-1") {
                    alert("请选择文字颜色");
                    return false;
                }
                var cposi = $("#<%=ddlPosi.ClientID%>").val();
                if (cposi == "-1") {
                    alert("请选择文字位置");
                    return false;
                }
                context = context.replace(/\n\r/g, "<BR>");
                context = context.replace(/\n/g, "<BR>");
                context = context.replace(/\s/g, "&nbsp;");
                $.ajax({
                    type: 'POST',
                    url: "/Manage/News/Ajax_AddPicInfo.aspx",
                    data: "spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=<%=Request.QueryString["sortnum"]%>&iid=<%=Request.QueryString["iid"]%>&name=" + escape(name) + "&batta=" + escape(batta) + "&context=" + escape(context).replace(/\+/g, '%2B') + "&csize=" + csize + "&ccolor=" + ccolor + "&cposi=" + cposi,
                    success: function (data) {
                        var arr = data.split("|~|");
                        if (arr[0] == 0) {
                            window.top.$modal.destroy();
                            window.top.$op.location = "/Manage/News/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>pid=<%=Request.QueryString["pid"]%>";
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
