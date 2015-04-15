<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChooseAdTemplate.aspx.cs" Inherits="WebSite.Web.Manage.Systems.ChooseAdTemplate" %>

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
        $(".sel-temp").live("click", function () {
            var itid = $(".li-type.active").attr("data-typeid");
            if (itid == "" || itid == undefined) {
                alert("请先新增或者选择分类");
                return false;
            }
            var tid = $("input[name='iptTemp']:checked").val();
            if (tid == "" || tid == undefined) {
                alert("请选择模板");
                return false;
            }
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ content: '<div class=\"form-horizontal\"><div class=\"modal-body\"><p style=\"text-align: center;font-size: 22px;\">模板正在拼命的生成中,请稍候...</p></div></div>' });
            window.top.$modal.show();
            window.top.$(".modal-header a").remove();
            $.ajax({
                type: 'POST',
                url: '/Manage/Systems/Ajax_TempInfo/AddTempInfo.aspx?itid=' + itid + '&spid=<%=Request.QueryString["spid"] %>&pid=<%=Request.QueryString["pid"] %>&tid=' + $("input[name='iptTemp']:checked").val(),
                success: function (data) {
                    window.top.$modal.destroy();
                    var arr = data.split("|~|");
                    if (arr[0] == 0) {
                        window.location = "/Manage/News/RedircetAD.aspx?itid=" + itid + "&pid=<%=Request.QueryString["pid"] %>&page=<%=Request.QueryString["page"] %>&spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["ptiid"]%>";
                    } else {
                        alert(arr[1]);
                    }
                }
            });
            return false;
        });
    </script>
</head>

<body>
    <form runat="server" id="form8">
        <div class="header clearfix">
            <div class="backup"><a href="/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&itid=<%=Request.QueryString["itid"]%>" class="back_btn backfirst">返回首页</a><a href="/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&pid=<%=Request.QueryString["pid"] %>&page=<%=Request.QueryString["page"] %>&tiid=<%=Request.QueryString["ptiid"]%>&itid=<%=Request.QueryString["itid"]%>" class="back_btn">返回上级</a></div>

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
                <div class="tmp-box">
                    <ul class="row">
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <li class="col-sm-3">
                                    <img src="/images/<%#Eval("TImg") %>"><input type="radio" name="iptTemp" value="<%#Eval("TID") %>" />
                                    <%#Eval("TName") %> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="text-center" style="padding-bottom: 45px; padding-left: 0px;"><a href="javascript:;" class="btn btn-danger btn-sm sel-temp">确定</a></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

