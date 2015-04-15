<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLabel.aspx.cs" Inherits="WebSite.Web.Manage.Systems.AddLabel" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">

    <title>沿途后台</title>
</head>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>标签名称：</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="标签名称" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnSub" CssClass="btn btn-success" runat="server" Text="确定" OnClick="btnSub_Click" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
