<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RootPackage.aspx.cs" Inherits="WebSite.Web.Manage.Systems.RootPackage" %>

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
        function addData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddRootPackage.aspx?aId=' + aId, title: '新增资源包' });
            window.top.$modal.show();
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
                <strong>总站资源包</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    资源包名称：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="资源包名称" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData('<%=Request.QueryString["AreaId"] %>');">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('该资源包及下属的分站资源包将被删除,确定删除？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">资源包名称</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("RPID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("RPName")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center">
                                    <%#GetStatus(Eval("Status"),Eval("RPID"))%>
                                    <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("RPID")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('该资源包及下属的分站资源包将被删除,确定删除？')" runat="server">删除</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <uc1:Pager ID="Pager1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
