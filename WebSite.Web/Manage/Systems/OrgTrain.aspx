<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgTrain.aspx.cs" Inherits="WebSite.Web.Manage.Systems.OrgTrain" %>

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
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddOrgTrain.aspx?aId=' + aId, title: '新增铁路局' });
            window.top.$modal.show();
        }
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddOrgTrain.aspx?OrgId=' + aId, title: '编辑铁路局信息' });
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
                <strong>铁路局</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    铁路局名称：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="铁路局名称" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData('<%=Request.QueryString["AreaId"] %>');">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">铁路局名称</th>
                        <th nowrap="nowrap">负责人</th>
                        <th nowrap="nowrap">负责人电话</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("OrgId") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("OrgName")%></td>
                                <td style="text-align: center"><%#Eval("OrgAddress")%></td>
                                <td style="text-align: center"><%#Eval("OrgPhone")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("Addtime")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" data-title="编辑铁路局信息" onclick="editData('<%#Eval("OrgId")%>')">编辑</a>
                                    <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("OrgId")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
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
