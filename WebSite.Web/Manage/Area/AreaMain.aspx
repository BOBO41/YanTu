<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaMain.aspx.cs" Inherits="WebSite.Web.Manage.Area.AreaMain" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
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
            if (aId == null || aId == "") {
                alert("请选择区域");
                return false;
            }
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddAreaImp.aspx?aId=' + aId + "&dataTime=<%= DateTime.Now.Second%>", title: '新增地块' });
            window.top.$modal.show();
        }
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddAreaImp.aspx?OrgId=' + aId + "&dataTime=<%=DateTime.Now.Second%>", title: '编辑地块' });
            window.top.$modal.show();
        }
        function addFarmer(lId, areaid) {

            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddAreaFarmer.aspx?lid=' + lId + '&aid=' + areaid + "&dataTime=<%=DateTime.Now.Second%>", title: '设置农户' });
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
        <div class="tabbable">
            <div class="pannel">
                <div class="pannel-header">
                    <strong>地块</strong>
                </div>
                <div class="pannel-body">
                    <div class="form-inline">
                        地区/地块：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="地区/地块" />
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
                            <th nowrap="nowrap" style="text-align: center">名称</th>
                            <th nowrap="nowrap" style="text-align: center">区域</th>
                            <th nowrap="nowrap" style="text-align: center">面积(亩)</th>
                            <th nowrap="nowrap" style="text-align: center">土壤属性</th>
                            <th nowrap="nowrap" style="text-align: center">说明</th>
                            <th nowrap="nowrap" style="text-align: center">设置农户</th>
                            <th nowrap="nowrap" style="text-align: center">操作</th>

                        </tr>
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="id" style="text-align: center">
                                        <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("LId") %>' Text="" runat="server" /></td>
                                    <td style="text-align: center"><%#Eval("LName")%></td>
                                    <td style="text-align: center"><%#Eval("AreaName") %></td>
                                    <td style="text-align: center"><%#Eval("LArea")%></td>
                                    <td style="text-align: center"><%#BindAtt(Eval("LId"))%></td>
                                    <td style="text-align: center"><%#Eval("LMemo")%></td>
                                    <td style="text-align: center"><a href="javascript:void(0);" class="btn btn-mini" data-title="设置农户" onclick="addFarmer('<%#Eval("LId")%>','<%#Eval("AreaId") %>')">设置农户</a></td>
                                    <td class="act">
                                        <a href="javascript:void(0);" class="btn btn-mini" data-title="编辑地块" onclick="editData('<%#Eval("LId")%>')">编辑</a>
                                        <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("LId")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('确定要删除吗？')" runat="server">删除</asp:LinkButton>
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

