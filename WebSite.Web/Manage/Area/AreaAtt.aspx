<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaAtt.aspx.cs" Inherits="WebSite.Web.Manage.Area.AreaAtt" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>设置</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="/themes/js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="/themes/js/wiimedia-market.js"></script>
</head>
<script type="text/javascript">
    function goDel(ATId) {
        if (!confirm("确实要删除吗?")) {
            return false;
        }
        $.ajax({
            type: 'POST', url: '/Manage/Area/Ajax/DelAreaAtt.aspx?laid=' + ATId, success: function (data) {
                if (data == "删除成功") {
                    window.location = window.location;
                } else {
                    alert(data);
                }
            }
        });
    }
    function addData(ATId, PTParentId, title) {
        window.top.$op = this.window;
        window.top.$modal = window.top.$.scojs_modal({ remote: 'AddAreaAtt.aspx?ATId=' + ATId + "&dataTime=<%=DateTime.Now.Second%>", title: title });
        window.top.$modal.show();
    }
</script>
<body class="pd">
    <form id="form1" runat="server">
        <div class="modal hide fade" id="myModal">
            <div class="modal-body">
            </div>
        </div>
        <div class="pannel">
            <div class="pannel-header">
                <strong>土壤属性</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    <a onclick="addData('','','新增土壤属性');" href="javascript:void(0);" data-title="新增土壤属性" class="btn btn-mini">新增</a>
                    <asp:LinkButton ID="btndelList" class="btn btn-mini" OnCommand="btndelList_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>

                </div>
                <div class="class">
                    <table class="table table-bordered" border="0" style="width: 100%">
                        <tr>
                            <th style="text-align: center" class="id" nowrap="nowrap">
                                <input type="checkbox" name="cbSelectAll" id="cbSelectAll"></th>
                            <th style="text-align: center" nowrap="nowrap">土壤属性
                            </th>
                            <th style="text-align: center" nowrap="nowrap">操作
                            </th>
                        </tr>
                        <asp:Repeater ID="rptAreaAtt" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="text-align: center; vertical-align: middle">
                                        <asp:CheckBox ID="cbSelect" Name="cbSelect" ToolTip='<%#Eval("LAId") %>' Text="" runat="server" /></td>

                                    <input value='<%#Eval("LAId") %>' type="hidden" />

                                    <td>
                                        <div class="class-one" style="width: 100%; text-align: center">
                                            <%#Eval("LAName")%>
                                        </div>
                                    </td>
                                    <td style="text-align: center">
                                        <a onclick="addData('<%#Eval("LAId")%>','','编辑土壤属性')" href="javascript:void(0);" class="btn btn-mini">编辑</a>

                                        <a onclick="goDel(<%#Eval("LAId")%>);" href="javascript:void(0)" class='btn btn-mini'>删除</a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
