<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite.Web.Manage.Adver.Default" %>

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

        function adprev(atta) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ content: "<div class=\"form-horizontal\"><div class=\"modal-body\" style=\"text-align: center;\"><img style=\"width:453px;height:234px;\" src=\"/UploadFiles/" + atta + "\"></div></div><div class=\"modal-footer\"><button class=\"btn\" data-dismiss=\"modal\" aria-hidden=\"true\">关闭</button></div>" });
            window.top.$modal.show();
        }

        function addData() {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Adver/AddAd.aspx', title: '新增广告' });
            window.top.$modal.show();
        }
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Adver/AddAd.aspx?aid=' + aId, title: '编辑广告' });
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
                <strong>广告管理</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    标题：<input type="text" runat="server" id="txtRealName" class="input-small" placeholder="标题" />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" Text="搜索" OnClick="btnSearch_Click" />
                </div>
                <div class="btn-toolbar">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                    <asp:LinkButton ID="btnDelAll" class="btn btn-mini" OnClientClick="return confirm('你确定要删除吗？')" runat="server" OnClick="btnDelAll_Click">删除</asp:LinkButton>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cbSelAll" id="cbSelAll" /></th>
                        <th nowrap="nowrap">标题</th>
                        <th nowrap="nowrap">创建时间</th>
                        <th nowrap="nowrap" class="act">操作</th>
                    </tr>
                    <asp:Repeater ID="rptListWork" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <asp:CheckBox ID="cbList" Name="cbList" ToolTip='<%#Eval("AID") %>' Text="" runat="server" /></td>
                                <td style="text-align: center"><%#Eval("AName")%></td>
                                <td style="text-align: center"><%#Convert.ToDateTime(Eval("CreateDate")).ToString("yyyy-MM-dd")%></td>
                                <td style="text-align: center">
                                    <a href="javascript:void(0);" class="btn btn-mini" data-title="预览广告" onclick="adprev('<%#Eval("AImg")%>')">预览</a>
                                    <a href="javascript:void(0);" class="btn btn-mini" data-title="编辑广告" onclick="editData('<%#Eval("AID")%>')">编辑</a>
                                    <asp:LinkButton ID="lbtnDel" CssClass="btn btn-mini" CommandName='<%#Eval("AID")%>' OnCommand="lbtnDel_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
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
