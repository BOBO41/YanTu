<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite.Web._Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="favicon.ico">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>沿途后台管理系统</title>
    <link href="themes/default/main.css" rel="stylesheet" type="text/css">
</head>
<frameset rows="60,*" cols="*" border="0" frameborder="no" framespacing="0">
  <frame name="topFrame" title="topFrame" id="topFrame" src="Top.aspx" noresize="noresize" scrolling="No">
  <frameset cols="80,*" border="0" frameborder="no" framespacing="0">
    <frame name="leftFrame" title="leftFrame" id="leftFrame" src="left.html" noresize="noresize" scrolling="No">
    <frame name="mainFrame" title="mainFrame" id="mainFrame" src="home.html">
  </frameset>
</frameset>
<noframes><body></body></noframes>
</html>
