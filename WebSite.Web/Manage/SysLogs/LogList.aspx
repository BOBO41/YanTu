<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogList.aspx.cs" Inherits="WebSite.Web.Manage.SysLogs.LogList" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>设置</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="/themes/js/jquery-1.8.0.min.js"></script>
    <script src="/themes/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script src="/themes/sco.js/js/sco.modal.js"></script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <div class="modal hide fade" id="myModal">
            <div class="modal-body">
            </div>
        </div>
        <div class="pannel">
            <div class="pannel-header">
                <strong>日志列表</strong>
            </div>
            <div class="pannel-body">

                <asp:HiddenField ID="hidAreaId" runat="server" />
                <div class="form-inline">
                    日志类别：<asp:DropDownList runat="server" ID="ddlStatus" Width="120px" OnSelectedIndexChanged="btnSearch_Click" AutoPostBack="True">
                        <asp:ListItem Value="ProductInfo" Selected="True">商品日志</asp:ListItem>
                        <asp:ListItem Value="CMArticle">内容日志</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" OnClick="btnSearch_Click" Text="搜索" />
                </div>
                <div class="class">
                    <table class="table table-bordered" border="0" style="width: 100%" id="tabList">
                        <tr>
                            <th class="id" nowrap="nowrap" style="text-align: center">
                                <input type="checkbox" name="cbSelectAll" id="cbSelectAll"></th>
                            <th nowrap="nowrap" style="text-align: center">操作人
                            </th>
                            <th nowrap="nowrap" style="text-align: center">信息ID
                            </th>
                            <th nowrap="nowrap" style="text-align: center">信息标题
                            </th>
                            <th nowrap="nowrap" style="text-align: center">值对比
                            </th>
                            <th nowrap="nowrap" style="text-align: center">修改时间
                            </th>
                        </tr>
                        <asp:Repeater ID="rptArticle" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="text-align: center">
                                        <asp:CheckBox ID="cbSelect" Name="cbSelect" ToolTip='<%#Eval("LLID") %>' Text="" runat="server" /></td>
                                    <input value='<%#Eval("LLID") %>' type="hidden" />
                                    <td style="text-align: center">
                                        <%#Eval("EmplName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("PId")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("Title")%>
                                    </td>
                                    <td style="text-align: center">
                                        <a data-trigger="modal" href="ValueCompare.aspx?LId=<%#Eval("LLID") %>&datatime=<%=DateTime.Now.Second %>" data-title="值对比" class="btn btn-mini">查看</a>

                                    </td>
                                    <td style="text-align: center">
                                        <%#Convert.ToDateTime(Eval("MDate")).ToString("yyyy-MM-dd")%>
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <uc1:Pager ID="Pager" runat="server" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
