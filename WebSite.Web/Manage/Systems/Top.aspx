<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="WebSite.Web.Manage.Systems.Top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../themes/default/main.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="logo">沿途</div>
            <div class="userinfo" id="divLogged" runat="server">
                欢迎您，<strong><asp:Literal ID="litUserName" runat="server"></asp:Literal></strong> 登录成功！ <a href="#">通知</a> | <a href="ChangePass.aspx" target="mainFrame">密码更改</a><strong>
                    <asp:LinkButton ID="lbtnLogout" runat="server" OnClick="lbtnLogout_Click">[退出]</asp:LinkButton></strong>
            </div>
            <asp:Literal ID="litError" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
