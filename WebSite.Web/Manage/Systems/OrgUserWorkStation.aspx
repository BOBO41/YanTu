<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrgUserWorkStation.aspx.cs" Inherits="WebSite.Web.Manage.Systems.OrgUserWorkStation" %>

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
        function addData() {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddOrgWorStaUser.aspx', title: '新增工作站人员' });
            window.top.$modal.show();
            return false;
        }
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
    </script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div class="tabbable">
            <ul class="nav nav-tabs mb0" style="margin-bottom: 0px;">
                <li><a href="/Manage/Systems/OrgUserDep.aspx">我公司人员</a></li>
                <li><a href="/Manage/Systems/OrgUserTech.aspx">农技推广站人员</a></li>
                <li class="active"><a href="/Manage/Systems/OrgUserWorkStation.aspx">工作站人员</a></li>
                <%--<li><a href="/Manage/Systems/OrgUserLogistics.aspx">物流公司人员</a></li>--%>
                <%--<li><a href="/Manage/Systems/OrgUserSupplier.aspx">厂家人员</a></li>--%>
            </ul>
            <div class="pannel" style="border-top: none">
                <div class="pannel-body">
                    <div class="form-inline">
                        姓名：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="姓名" />
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                    </div>
                    <div class="btn-toolbar">
                        <a href="javascript:void(0);" class="btn btn-mini" onclick="addData('<%= Request.QueryString["AreaId"] %>');">新增</a>
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
                            <th nowrap="nowrap">工作站</th>
                            <th nowrap="nowrap">创建时间</th>
                            <%--<th class="act" nowrap="nowrap">设置角色</th>--%>
                            <th nowrap="nowrap">操作</th>
                        </tr>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="id">
                                        <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("EmplId") %>' Text="" runat="server" /></td>
                                    <td style="text-align: center"><%#Eval("EmplName")%></td>
                                    <td style="text-align: center"><%#Eval("Sex").ToString()=="1" ? "男":"女"%></td>
                                    <td style="text-align: center"><%#Eval("Phone")%></td>
                                    <td style="text-align: center"><%#Eval("HomeAddress")%></td>
                                    <td style="text-align: center"><%#Eval("OrgName")%></td>
                                    <td style="text-align: center"><%#Convert.ToDateTime(Eval("Addtime")).ToString("yyyy-MM-dd")%></td>
                                    <%--<td><%#Eval("Status").ToString()=="0"?"<font color=red>已删除</font>":"<font color=green>正常</font>"%></td>--%>
                                    <%--<td class="act"><a href="javascript:void(0);" class="btn btn-mini" onclick="openModal('/Manage/Systems/SystemSetRole.aspx?adn_id=<%#Eval("UId")%>','设置角色')">设置角色</a></td>--%>
                                    <td style="text-align: center">
                                        <a href="javascript:void(0);" class="btn btn-mini" onclick="openModal('/Manage/Systems/AddOrgWorStaUser.aspx?empId=<%#Eval("EmplId")%>','编辑工作站人员信息')">编辑</a>

                                        <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("EmplId")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <uc1:Pager ID="Pager1" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
