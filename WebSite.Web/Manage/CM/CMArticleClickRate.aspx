<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMArticleClickRate.aspx.cs" Inherits="WebSite.Web.Manage.CM.CMArticleClickRate" %>

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
                <strong>文章列表</strong>
            </div>
            <div class="pannel-body">

                <div class="form-inline">
                    文章标题：<input type="text" runat="server" id="txtProName" placeholder="文章标题" class="input-small" />

                    栏目：  
                    <asp:DropDownList ID="ddlColumn" runat="server" Width="120px" OnSelectedIndexChanged="ddlColumn_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" OnClick="btnSearch_Click" Text="搜索" />
                </div>
                <div class="btn-toolbar" style="margin-top: 10px">
                    <asp:LinkButton ID="btnExport" class="btn btn-mini" OnCommand="btnExport_Command"  runat="server">导出</asp:LinkButton>
                </div>
                <div class="class">
                    <table class="table table-bordered" border="0" style="width: 100%" id="tabList">
                        <tr>
                            <th nowrap="nowrap" style="text-align: center">标题
                            </th>
                            <th nowrap="nowrap" style="text-align: center">栏目
                            </th>
                            <th nowrap="nowrap" style="text-align: center">访问量(次)
                            </th>
                        </tr>
                        <asp:Repeater ID="rptArticle" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="class-one" style="width: 100%">
                                            <%#Eval("Title")%>
                                        </div>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("ColName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("Hits")%>
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
