<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgDep.aspx.cs" Inherits="WebSite.Web.Manage.Systems.OrgDep" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <link href="/themes/sco.js/css/scojs.css" rel="stylesheet" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
    <script type="text/javascript">
        var $modal;
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
            if (aId == null || aId == "") {
                alert("请选选择区域");
                return false;
            }
            $modal = $.scojs_modal({ remote: 'AddOrgDepUser.aspx?aId=' + aId, title: '新增部门人员' });
            $modal.show();
        }
    </script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel">
            <div class="pannel-header"><strong>部门</strong></div>
            <div class="pannel-body">
                <div class="form-inline">
                    <input type="text" runat="server" id="txtRealName" class="input-small" placeholder="姓名" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <div class="btn-toolbar">
                    <a data-title="新增部门人员" href="#" class="btn btn-mini" onclick="addData('<%= Request.QueryString["AreaId"] %>');">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">人员姓名</th>
                        <th nowrap="nowrap">性别</th>
                        <th nowrap="nowrap">电话</th>
                        <th nowrap="nowrap">地址</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th class="act" nowrap="nowrap">操作</th>
                    </tr>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("EmplId") %>' Text="" runat="server" /></td>
                                <td><%#Eval("EmplName")%></td>
                                <td><%#Eval("Sex")%></td>
                                <td><%#Eval("Phone")%></td>
                                <td><%#Eval("HomeAddress")%></td>
                                <td><%#Eval("Addtime")%></td>
                                <%--<td><%#Eval("Status").ToString()=="0"?"<font color=red>已删除</font>":"<font color=green>正常</font>"%></td>--%>
                                <td class="act">
                                    <a data-trigger="modal" href="AddOrgDepUser.aspx?empId=<%#Eval("EmplId")%>" data-title="编辑部门人员信息">编辑</a>
                                    <asp:LinkButton ID="lbtnDel" CommandName='<%#Eval("EmplId")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
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
