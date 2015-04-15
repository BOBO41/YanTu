<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelInfo.aspx.cs" Inherits="WebSite.Web.Manage.Systems.Ajax_TempInfo.SelInfo" %>

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
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="formselinfo" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal sel-infow">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>已有内容：</label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlOrgName">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAddsel();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function goAddsel() {
                var siid = $("#<%=ddlOrgName.ClientID%>").val();
                if (siid == "-1") {
                    alert("请先选择已有内容");
                    return false;
                }
                $("#formselinfo").html("<div class=\"form-horizontal\"><div class=\"modal-body\"><p style=\"text-align: center;font-size: 22px;\">数据正在处理中,请稍候...</p></div></div><div class=\"modal-footer\"><button class=\"btn\" data-dismiss=\"modal\" aria-hidden=\"true\">关闭</button></div>");
                $.ajax({
                    type: 'POST',
                    url: "/Manage/Systems/Ajax_Infos/AddSelInfo.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=<%=Request.QueryString["sortnum"]%>&siid=" + siid,
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
