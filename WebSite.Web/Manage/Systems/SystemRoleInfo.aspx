<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemRoleInfo.aspx.cs" Inherits="WebSite.Web.Manage.Systems.SystemRoleInfo" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8" />
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
</head>
<script type="text/javascript">
    $(function () {
        $("#cboSelectAll").click(function () {
            if ($(this).attr("checked")) {
                $("#tabRole input").attr("checked", $(this).attr("checked"));
            } else {
                $("#tabRole input").attr("checked", false);
            }
        });
    });
    function addData() {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddSystemRoleInfo.aspx', title: '新增角色' });
        window.top.$modal.show();
    }
    function editData(aId) {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddSystemRoleInfo.aspx?role_id=' + aId, title: '编辑角色信息' });
        window.top.$modal.show();
    }
    function openModal(url, title) {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
        window.top.$modal.show();
    }
</script>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel">
            <div class="pannel-header">
                <strong>角色管理</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    角色名称：<input type="text" runat="server" id="txtRoleName" placeholder="角色名称" class="input-small" />
                    <asp:Button ID="btnSearchRole" runat="server" CssClass="btn btn-success" OnClick="btnSearchRole_Click" Text="搜索" />
                </div>
                <%--<div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                    <asp:LinkButton ID="btndelRole" class="btn btn-mini" OnCommand="btndelRole_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
                </div>--%>
                <table class="table table-bordered" border="0" id="tabRole">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cboSelectAll" id="cboSelectAll"></th>
                        <th nowrap="nowrap">角色名称</th>
                        <th nowrap="nowrap">角色说明</th>
                        <%--<th nowrap="nowrap">角色状态</th>--%>
                        <th nowrap="nowrap" class="act">设置功能</th>
                        <%--<th nowrap="nowrap">操作</th>--%>
                    </tr>
                    <asp:Repeater ID="RepeaterMyRole" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbSalesRole" Name="cbSalesRole" ToolTip='<%#Eval("Role_Id") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("Role_Name")%></td>
                                <td style="text-align: center"><%#Eval("Role_Memo")%> </td>
                                <%--<td style="text-align: center"><span class="label label-success"><%#Eval("Role_Status")%></span></td>--%>
                                <td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" onclick="openModal('SystemSetPage.aspx?role_id=<%#Eval("Role_Id")%>&dateTime=<%=DateTime.Now.Second %>','设置功能')">设置功能</a>
                                </td>
                                <%--<td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" onclick="editData('<%#Eval("Role_Id")%>')">编辑</a>
                                    <asp:LinkButton ID="btnDeleteRole" CssClass="btn btn-mini" CommandName='<%#Eval("Role_Id")%>' OnCommand="btnDeleteRole_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
                                </td>--%>
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
