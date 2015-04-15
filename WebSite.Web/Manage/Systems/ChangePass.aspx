<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="WebSite.Web.Manage.Systems.ChangePass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
                    <label class="control-label" for="inputPassword">老密码：</label>
                    <div class="controls">
                        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" placeholder="老密码"></asp:TextBox>
                    </div>
                </div>

                <div class="control-group">
                    <label class="control-label" for="inputPassword">新密码：</label>
                    <div class="controls">
                        <asp:TextBox ID="txtNewPwd" runat="server" placeholder="新密码" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">重复新密码：</label>
                    <div class="controls">
                        <asp:TextBox ID="txtNewPwd2" runat="server" placeholder="重复新密码" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label"></label>
                    <div class="controls">
                    </div>
                </div>

            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="Button1" runat="server" Text="确定" class="btn btn-success" OnClick="btnSave_Click" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
