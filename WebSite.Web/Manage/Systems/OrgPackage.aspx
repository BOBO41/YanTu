<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgPackage.aspx.cs" Inherits="WebSite.Web.Manage.Systems.OrgPackage" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#cbSelAll").click(function () {
                if ($(this).attr("checked")) {
                    $("#tabList input").attr("checked", $(this).attr("checked"));
                } else {
                    $("#tabList input").attr("checked", false);
                }
            });
        });
        function createtype(obj,orgid) {
            $(obj).unbind('click');
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ content: '<div class=\"form-horizontal\"><div class=\"modal-body\"><p style=\"text-align: center;font-size: 22px;\">资源包正在创建中,请稍候...</p></div></div>' });
            window.top.$modal.show();
            window.top.$(".modal-header a").remove();
            var rpid = $("#<%= ddlSendType.ClientID%>").val();
            $.ajax({
                type: 'POST', url: '/Manage/Systems/AJAX/CreateStaPackage.aspx?orgid=' + orgid + '&rpid=' + rpid, success: function (data) {
                    window.top.$modal.destroy();
                    if (data != 0) {
                        window.location = "CreateFirstPage.aspx?spid=" + data;
                    } else {
                        alert("操作失败");
                    }
                }
            });
        }
        function finpkg(spid) {
            $.ajax({
                type: 'POST', url: '/Manage/Systems/AJAX/PkgManage.aspx?fspid=' + spid, success: function (data) {
                    if (data == 1) {
                        window.location = window.location;
                    } else {
                        alert("操作失败");
                    }
                }
            });
        }

        function exppkg(spid) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ content: '<div class=\"form-horizontal\"><div class=\"modal-body\"><p style=\"text-align: center;font-size: 22px;\">资源包正在拼命的生成中,请稍候...</p></div></div>' });
            window.top.$modal.show();
            window.top.$(".modal-header a").remove();
            $.ajax({
                type: 'POST', url: "/Manage/Pkg/Expkg.aspx?spid=" + spid, success: function (data) {
                    window.top.$modal.destroy();
                    var arr = data.split("|~|");
                    if (arr[0] == 0) {
                        window.location = arr[1];
                    } else {
                        alert(arr[1]);
                    }
                }
            });
        }

        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddRootPackage.aspx?empId=' + aId, title: '编辑资源包信息' });
            window.top.$modal.show();
        }
        function padmit(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/PackageAdmit.aspx?empId=' + aId, title: '选择送审的分站资源包' });
            window.top.$modal.show();
        }
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
        function navIframe(url) {
            $("#mainFrame", top.document.body).attr("src", url);
        }
    </script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel" style="border-top: none">
            <div class="pannel-header">
                <strong>分站资源包</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    总站资源包：<asp:DropDownList style="width:auto" ID="ddlSendType" runat="server" OnSelectedIndexChanged="ddlOrderStatus_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">分站资源包名称</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("SPID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center">默认资源包</td>
                                <td style="text-align: center"><%#Eval("CreateDate")==DBNull.Value?"":Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center"><%#GetStatus(Eval("spstatus"),Eval("OrgId"),Eval("SPID"))%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="rptSp" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("SPID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center">资源包-<%#Eval("OrgName") %></td>
                                <td style="text-align: center"><%#Eval("CreateDate")==DBNull.Value?"":Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center">
                                    <%#GetStatus(Eval("spstatus"),Eval("OrgId"),Eval("SPID"))%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
