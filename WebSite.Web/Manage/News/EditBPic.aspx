<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditBPic.aspx.cs" Inherits="WebSite.Web.Manage.News.EditBPic" %>

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
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>背景图</label>
                    <div class="controls">
                        <a href="javascript:;" class="btn btn-default btn-sm type-add" data-original-title="" title="">选择文件</a> <font color="red">大小<%= Request.QueryString["bgw"] %>*<%= Request.QueryString["bgh"] %></font>
                        <div id="queuedivtablecontainer">
                            <asp:Literal ID="litPic" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAddpicx();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function goAddpicx() {
                var batta = $(".upatta").attr("data-file");
                if (batta == "" || batta == undefined) {
                    alert("请上传背景图片");
                    return false;
                }
                $.ajax({
                    type: 'POST',
                    url: "/Manage/News/Ajax_AddHotPic.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&bpic=" + escape(batta),
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
