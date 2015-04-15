<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAdInfoPic.aspx.cs" Inherits="WebSite.Web.Manage.News.AddAdInfoPic" %>

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
    <form id="form1" runat="server" style="margin: 0">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>标题：</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="标题" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>广告图片</label>
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
            <a onclick="goAddipic();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function goAddipic() {
                var batta = $(".upatta").attr("data-file");
                var name = $("#txtName").val();
                if (name == "" || name == undefined) {
                    alert("请填写标题");
                    return false;
                }
                if (batta == "" || batta == undefined) {
                    alert("请上传广告图片");
                    return false;
                }
                $.ajax({
                    type: 'POST',
                    url: "/Manage/News/Ajax_AddAdInfoPic.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=<%=Request.QueryString["sortnum"]%>&name=" + escape(name) + "&batta=" + escape(batta) + "&iid=<%=Request.QueryString["iid"]%>",
                    success: function (data) {
                        var arr = data.split("|~|");
                        if (arr[0] == 0) {
                            window.top.$modal.destroy();
                            window.top.$op.location = "/Manage/News/RedircetAD.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["ptiid"]%>&itid=<%=Request.QueryString["itid"]%>";
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
