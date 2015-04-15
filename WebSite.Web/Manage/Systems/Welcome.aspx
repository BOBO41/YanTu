<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="WebSite.Web.Manage.Systems.Welcome" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>无标题文档</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">

    <script src="/js/jquery.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
</head>
<style>
    p {
        font-size: 18px;
    }
</style>
<body class="pd" style="text-align: center; padding-top: 10%">
    <h3>【欢迎进入，沿途后台管理系统！本系统适配浏览器：IE8及以上，最新版chrome/360安全浏览器/FireFox】</h3>
    <h4>您可以点击以下链接下载安装最新版</h4>
    <p><a target="_blank" href="http://down.tech.sina.com.cn/content/40975.html">chrome</a></p>
    <p><a target="_blank" href="http://www.firefox.com.cn/">FireFox</a></p>
    <p><a target="_blank" href="http://se.360.cn/">360安全浏览器</a></p>
    <div class="row-fluid" style="display: none">

        <div style="width: 49%; float: left;">
            <div class="pannel">
                <div class="pannel-header"><span class="b"><a href="#"><i class="icon-chevron-up"></i></a></span><strong>最近一月的订单分布</strong></div>
                <%--<div class="pannel-body"><div id='orderChart' style="width: 100%; height: 300px;"></div></div>--%>
            </div>
        </div>
        <div style="width: 49%; float: right;">
            <div class="pannel">
                <div class="pannel-header"><span class="b"><a href="#"><i class="icon-chevron-up"></i></a></span><strong>最近一月的商品销量</strong></div>
                <%--<div class="pannel-body"><div id='proChart' style="width: 100%; height: 300px"></div></div>--%>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="display: none">

        <div style="width: 49%; float: left;">
            <div class="pannel">
                <div class="pannel-header"><span class="b"><a href="#"><i class="icon-chevron-up"></i></a></span><strong>最近一月的点赞排行榜</strong></div>
                <%--<div class="pannel-body"><div id='mod3' style="width: 100%; height: 300px"></div></div>--%>
            </div>
        </div>
        <div style="width: 49%; float: right;">
            <div class="pannel">
                <div class="pannel-header"><span class="b"><a href="#"><i class="icon-chevron-up"></i></a></span><strong>最近一月的被浏览最多的新闻</strong></div>
                <%--<div class="pannel-body"><div id='mod4' style="width: 100%; height: 300px"></div></div>--%>
            </div>
        </div>
    </div>
</body>
</html>
