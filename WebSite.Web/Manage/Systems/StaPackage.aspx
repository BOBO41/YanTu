<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaPackage.aspx.cs" Inherits="WebSite.Web.Manage.Systems.StaPackage" %>

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
        function exppkg(rpid, orgid) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ content: '<div class=\"form-horizontal\"><div class=\"modal-body\"><p style=\"text-align: center;font-size: 22px;\">资源包正在拼命的生成中,请稍候(时间大概2-15分钟)...</p></div></div>' });
            window.top.$modal.show();
            window.top.$(".modal-header a").remove();
            $.ajax({
                type: 'POST', url: "/Manage/Pkg/ExOrgpkg.aspx?rpid=" + rpid + "&orgid=" + orgid, success: function (data) {
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

        function expupkg(rpid, orgid) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ content: '<div class=\"form-horizontal\"><div class=\"modal-body\"><p style=\"text-align: center;font-size: 22px;\">资源包正在拼命的生成中,请稍候(时间大概2-15分钟)...</p></div></div>' });
            window.top.$modal.show();
            window.top.$(".modal-header a").remove();
            $.ajax({
                type: 'POST', url: "/Manage/Pkg/ExOrgUpkg.aspx?rpid=" + rpid + "&orgid=" + orgid, success: function (data) {
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
                <strong>铁路局资源包</strong>
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
                        <th nowrap="nowrap">铁路局名称</th>
                        <%--<th nowrap="nowrap">创建时间</th>--%>
                        <th nowrap="nowrap" class="act" style="width:200px">操作</th>
                    </tr>
                    <asp:Literal ID="litMsg" runat="server"></asp:Literal>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("OrgId") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("OrgName")%></td>
                                <%--<td style="text-align: center"><%#Eval("CreateDate")==DBNull.Value?"":Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>--%>
                                <td style="text-align: center">
                                    <a href="/Manage/Systems/PkgStationList.aspx?orgid=<%#Eval("OrgId") %>&rpid=<%=name %>" class="btn btn-mini" data-title="查看详情">查看详情</a>
                                    <a href="javascript:;" onclick="exppkg('<%= name %>','<%#Eval("OrgId")%>')" class="btn btn-mini" data-title="导出完整包">完整包</a> <%# IsCopy(Eval("OrgId")) %>
                                    
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
