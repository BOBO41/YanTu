<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSite.Web.Login" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <title>登录</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="/themes/js/jquery-1.8.0.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script src="/themes/plugins/adminjs/admin.login.js"></script>
</head>
<body class="login">
    <div class="loginbox">
        <%--<div class="login-logo"></div>--%>
        <div class="title">登录你的沿途管理员帐号</div>
        <form class="border_radius" id="focus" name="form1" runat="server">
            <label><%--<span>账号</span>--%><asp:TextBox ID="TextBox1" placeholder="账号" runat="server" CssClass="input_txt border_radius"></asp:TextBox></label>
            <label><%--<span>密码</span>--%><asp:TextBox ID="TextBox2" runat="server" placeholder="密码" TextMode="Password" CssClass="input_txt border_radius"></asp:TextBox></label>
            <asp:Button ID="Button1" runat="server" class="btn btn-large btn-block btn-success" Text="登 录" OnClick="btnLogin_Click" />
        </form>
    </div>
</body>
</html>
