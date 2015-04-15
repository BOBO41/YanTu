<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="WebSite.Web.Manage.Systems.ResetPassword" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>设置</title>
    <link href="../../themes/default/main.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="../../themes/js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../../themes/js/wiimedia-market.js"></script>
    <script type="text/javascript" src="../../themes/js/bootstrap.modal.js"></script>
</head>
<body class="wraper">
    <form id="form1" runat="server" class="form-horizontal">
        <div class="modal">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h3>
                    <asp:Label Text="重置密码" runat="server" ID="lblTitle"></asp:Label></h3>
            </div>
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label">输入密码：</label>
                    <div class="controls">
                        <asp:TextBox ID="txtPwdOne" runat="server" TextMode="Password"></asp:TextBox><span style="color: red">*</span>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">再次输入密码：</label>
                    <div class="controls">
                        <asp:TextBox ID="txtPwdTwo" runat="server" TextMode="Password"></asp:TextBox><span style="color: red">*</span>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a onclick="goAdd();" class="btn btn-primary">确定</a>
            </div>
            <script language="javascript">

                function goAdd() {
                    var pwdOne = $("#txtPwdOne").val();
                    var pwdTwo = $("#txtPwdTwo").val();
                    $.ajax({
                        type: 'POST', url: '/Manage/Systems/AJAX/ResPassword.aspx?uid=<%=Request.QueryString["uid"]%>&pwdOne=' + encodeURI(encodeURI(pwdOne)) + "&pwdTwo=" + encodeURI(encodeURI(pwdTwo)), success: function (data) {
                            if (data == "密码重置成功") {

                                alert(data);
                                window.location = '/Manage/Systems/SystemMember.aspx';
                            } else {
                                alert(data);
                            }
                        }
                    });
                }
            </script>
        </div>
    </form>
</body>
</html>
