<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelRecInfo.aspx.cs" Inherits="WebSite.Web.Manage.News.SelRecInfo" %>

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
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>推荐内容：</label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlOrgName">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAddrecinf();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function goAddrecinf() {
                var siid = $("#<%=ddlOrgName.ClientID%>").val();
                if (siid == "-1") {
                    alert("请先选择推荐内容");
                    return false;
                }
                $.ajax({
                    type: 'POST',
                    url: "/Manage/News/Ajax_SelRecInfo.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=<%=Request.QueryString["sortnum"]%>&iid=<%=Request.QueryString["iid"]%>&siid=" + siid,
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
