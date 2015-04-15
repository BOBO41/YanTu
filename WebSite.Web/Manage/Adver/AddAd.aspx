<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddAd.aspx.cs" Inherits="WebSite.Web.Manage.Adver.AddAd" %>

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
            width: 100px;
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
                        <a href="javascript:;" class="btn btn-default btn-sm type-add" data-original-title="" title="">选择文件</a> <font color="red"></font>
                        <div id="queuedivtablecontainer">
                            <asp:Literal ID="litPic" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAdd();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function goAdd() {
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
                    url: "/Manage/Adver/Ajax_AddAd.aspx?name=" + escape(name) + "&batta=" + batta + "&aid=<%=Request.QueryString["aid"]%>",
                    success: function (data) {
                        var arr = data.split("|~|");
                        if (arr[0] == 0) {
                            window.top.$op.location = window.top.$op.location;
                            window.top.$modal.destroy();
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
