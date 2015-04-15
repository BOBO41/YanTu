<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateFirstPage.aspx.cs" Inherits="WebSite.Web.Manage.Systems.CreateFirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/main.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.min.js"></script>
    <script src="/js/bootstrap/js/bootstrap.min.js"></script>
    <script src="/js/page.js"></script>
    <script>
        $(".cre-infotype").live("click", function () {
            window.top.$op = window;
            window.top.$tmp = $(this);
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/Ajax_Type/AddPackageType.aspx?spid=<%=Request.QueryString["spid"]%>', title: '新增分类' });
            window.top.$modal.show();
            return false;
        });
        $(".ren-infotype").live("click", function () {
            window.top.$op = window;
            window.top.$tmp = $(this).parent().parent();
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/Ajax_Type/EditPackageType.aspx?spid=<%=Request.QueryString["spid"]%>&itid=' + $(this).parent().parent().attr("data-typeid"), title: '编辑分类' });
            window.top.$modal.show();
            return false;
        });
        $(".up").live("click", function () {
            var itid = $(this).parent().attr("data-typeid");
            $.ajax({
                type: 'POST',
                url: '/Manage/Systems/Ajax_Type/SortPackageType.aspx?type=up&itid=' + itid,
                success: function (data) {
                    var arr = data.split("|~|");
                    if (arr[0] == 0) {
                        window.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&itid=" + itid;
                    } else {
                        alert(arr[1]);
                    }
                }
            });
            return false;
        });
        $(".down").live("click", function () {
            var itid = $(this).parent().attr("data-typeid");
            $.ajax({
                type: 'POST',
                url: '/Manage/Systems/Ajax_Type/SortPackageType.aspx?type=down&itid=' + itid,
                success: function (data) {
                    var arr = data.split("|~|");
                    if (arr[0] == 0) {
                        window.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&itid=" + itid;
                    } else {
                        alert(arr[1]);
                    }
                }
            });
            return false;
        });
        $(".del-infotype").live("click", function () {
            var itid = $(this).parent().parent().attr("data-typeid");
            if (confirm("该分类下的所有资讯将会被删除，确认删除？")) {
                $.ajax({
                    type: 'POST',
                    url: '/Manage/Systems/Ajax_Type/DelPackageType.aspx?itid=' + itid,
                    success: function (data) {
                        var arr = data.split("|~|");
                        if (arr[0] == 0) {
                            window.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>";
                        } else {
                            alert(arr[1]);
                        }
                    }
                });
            }
            return false;
        });
        $(".li-type").live("click", function () {
            window.location = "/Manage/Template/Redircet.aspx?itid=" + $(this).attr("data-typeid") + "&spid=<%=Request.QueryString["spid"]%>";
            return false;
        });
    </script>
</head>

<body>
    <form runat="server" id="form8">
        <div class="header clearfix">
                <asp:Literal ID="litStaName" runat="server"></asp:Literal>
        </div>
        <div class="wraper">
            <div class="menu">
                <h3>分类</h3>
                <h3>MENU</h3>
                <ul>
                    <asp:Literal ID="litType" runat="server"></asp:Literal>
                </ul>
            </div>
            <div class="main">
                <div style="line-height: 600px; text-align: center; font-size: 16px;">
                    <a href="/Manage/Systems/ChooseTemplate.aspx?itid=<%=Request.QueryString["itid"]%>&spid=<%=Request.QueryString["spid"] %>&page=<%=Request.QueryString["page"] %>&pid=<%=Request.QueryString["pid"] %>" class="btn btn-default btn-lg">选择模版</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

