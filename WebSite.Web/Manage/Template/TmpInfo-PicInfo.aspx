<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TmpInfo-PicInfo.aspx.cs" Inherits="WebSite.Web.Manage.Template.TmpInfoPicInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/css/main.css" rel="stylesheet" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/js/bootstrap/js/bootstrap.min.js"></script>
    <script src="/js/page.js"></script>
    <%--分类相关--%>
    <script>
        <%--新增分类--%>
        $(".cre-infotype").live("click", function () {
            window.top.$op = window;
            window.top.$tmp = $(this);
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/Ajax_Type/AddPackageType.aspx?spid=<%=Request.QueryString["spid"]%>', title: '新增分类' });
            window.top.$modal.show();
            return false;
        });
        <%--编辑分类--%>
        $(".ren-infotype").live("click", function () {
            window.top.$op = window;
            window.top.$tmp = $(this).parent().parent();
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/Ajax_Type/EditPackageType.aspx?spid=<%=Request.QueryString["spid"]%>&itid=' + $(this).parent().parent().attr("data-typeid"), title: '编辑分类' });
            window.top.$modal.show();
            return false;
        });
        <%--上移分类--%>
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
        <%--下移分类--%>
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
        <%--删除分类--%>
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
        <%--点击分类跳转--%>
        $(".li-type").live("click", function () {
            window.location = "/Manage/Template/Redircet.aspx?itid=" + $(this).attr("data-typeid") + "&spid=<%=Request.QueryString["spid"]%>";
            return false;
        });
    </script>


    <script>
        <%--新增热点--%>
        $(".new-info").live("click", function () {
            window.top.$op = window;
            window.top.$tmp = $(this);
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/News/AddHotPic.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=' + $(this).attr("data-sortnum") + '&bgw=' + $(this).attr("data-bgw") + '&bgh=' + $(this).attr("data-bgh"), title: '新增热点' });
            window.top.$modal.show();
            //window.top.uploader3.reset();
            return false;
        });
        <%--编辑块内容--%>
        $(".edit-pic").live("click", function () {
            window.top.$op = window;
            window.top.$tmp = $(this);
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/News/AddHotPic.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=' + $(this).attr("data-sortnum") + '&bgw=' + $(this).attr("data-bgw") + '&bgh=' + $(this).attr("data-bgh") + '&iid=' + $(this).attr("data-iid"), title: '编辑热点' });
            window.top.$modal.show();
            //window.top.uploader3.reset();
            return false;
        });
        <%--删除热点--%>
        $(".del-pic").live("click", function () {
            var iid = $(this).attr("data-iid");
            if (confirm("该热点下的所有图片将会被删除，确认删除？")) {
                $.ajax({
                    type: 'POST',
                    url: '/Manage/News/Ajax_AddHotPic.aspx?diid=' + iid,
                    success: function (data) {
                        var arr = data.split("|~|");
                        if (arr[0] == 0) {
                            window.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>";
                        } else {
                            alert(arr[1]);
                        }
                    }
                });
            }
            return false;
        });
        <%--选择块内容--%>
        $(".select-info").live("click", function () {
            window.top.$op = window;
            window.top.$tmp = $(this);
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/News/SelInfo.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=' + $(this).attr("data-sortnum"), title: '选择已有内容' });
            window.top.$modal.show();
            return false;
        });
        <%--背景图--%>
        $(".edit-bpic").live("click", function () {
            window.top.$op = window;
            window.top.$tmp = $(this);
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/News/EditBPic.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&bgw=' + $(this).attr("data-bgw") + '&bgh=' + $(this).attr("data-bgh"), title: '编辑背景图' });
            window.top.$modal.show();
            return false;
        });
        <%--标记块内容--%>
        $(".sin-info").live("click", function () {
            var iid = $(this).attr("data-iid");
            $.ajax({
                type: 'POST',
                url: '/Manage/Systems/Ajax_Infos/Ajax_AdminInfo.aspx?iid=' + iid,
                success: function (data) {
                    var arr = data.split("|~|");
                    if (arr[0] == 0) {
                        window.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>";
                    } else {
                        alert(arr[1]);
                    }
                }
            });
            return false;
        });
    </script>
    <script>
        <%--删除页面--%>
        $(".delpage").live("click", function () {
            if (confirm("你确定要删除该页模板吗？")) {
                $.ajax({
                    type: 'POST',
                    url: '/Manage/Template/Ajax_DelTempInfo.aspx?tiid=<%=Request.QueryString["tiid"]%>',
                    success: function (data) {
                        var arr = data.split("|~|");
                        if (arr[0] == 0) {
                            window.location = "/Manage/News/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&itid=<%=Request.QueryString["itid"]%>&pid=" + arr[1];
                        } else {
                            alert(arr[1]);
                        }
                    }
                });
            }
            return false;
        });
        <%--修改页码--%>
        $(".editpno").live("click", function () {
            var tipage = $(".iptpno").val();
            if (isNaN(tipage)) {
                alert("请填写正确的页码");
                return false;
            }
            $.ajax({
                type: 'POST',
                url: '/Manage/Template/Ajax_DelTempInfo.aspx?rtiid=<%=Request.QueryString["tiid"]%>&tipage=' + tipage,
                success: function (data) {
                    var arr = data.split("|~|");
                    if (arr[0] == 0) {
                        alert("修改页码成功");
                        window.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>";
                    } else {
                        alert(arr[1]);
                    }
                }
            });
            return false;
        });
        <%--跳转页码--%>
        $(".repage").live("click", function () {
            var tipage = $(".iptpno").val();
            if (isNaN(tipage)) {
                alert("请填写正确的页码");
                return false;
            }
            var count = $(this).attr("data-count");
            var parcount = $(this).attr("data-parcount");
            if (tipage < 1 || tipage > count) {
                alert("请填写正确的页码");
            } else {
                window.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&parcount=" + parcount + "&repage=" + tipage + "&itid=<%=Request.QueryString["itid"]%>";
            }
            return false;
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                    <div class="row pidiv">
                        <asp:Literal ID="litNewPage" runat="server"></asp:Literal>
                        <asp:Literal ID="litInfo1" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="text-center" style="background-color: #fff; padding-top: 5px;">
                    <table border="0" cellpadding="3" cellspacing="0" style="margin: auto;">
                        <tbody>
                            <tr>
                                <asp:Literal ID="litPager" runat="server"></asp:Literal>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
