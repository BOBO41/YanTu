<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="WebSite.Web.Manage.Systems.UserRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
</head>
<body class="pd">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        </asp:ScriptManagerProxy>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="searchbar">
                    当前机构：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                        <asp:ListItem Value="1">公司</asp:ListItem>
                        <%--<asp:ListItem Value="4">农技推广告站</asp:ListItem>
                        <asp:ListItem Value="5">工作站</asp:ListItem>
                        <asp:ListItem Value="2">物流公司</asp:ListItem>--%>
                    </asp:DropDownList>
                    当前角色：<asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <table style="width: 550px; margin: 8px;" class="tableForm bg">
                    <tr>
                        <td style="padding: 15px;">
                            <strong class="mb block">人员列表</strong>
                            <asp:ListBox ID="lstBoxLeft" runat="server" Height="380px" Width="200px" CssClass="inputText listbox" OnSelectedIndexChanged="lbtnToRight_one_Click" AutoPostBack="True"></asp:ListBox>
                        </td>
                        <td style="width: 200px; text-align: center;">
                            <asp:LinkButton ID="lbtnToRight_All" runat="server" OnClick="lbtnToRight_All_Click"
                                CssClass="button ma mb">全部-&gt;&gt;</asp:LinkButton><%--<br />
                            <asp:LinkButton ID="lbtnToRight_one" runat="server" OnClick="lbtnToRight_one_Click"
                                CssClass="button ma mb">选中-&gt;&gt;</asp:LinkButton>--%>
                            <div class="line-x">
                            </div>
                            <%--<asp:LinkButton ID="lbtnToLeft_one" runat="server" OnClick="lbtnToLeft_one_Click"
                                CssClass="button ma mb">&lt;&lt;-选中</asp:LinkButton><br />--%>
                            <asp:LinkButton ID="lbtnToLeft_All" runat="server" OnClick="lbtnToLeft_All_Click"
                                CssClass="button ma mb">&lt;&lt;-全部</asp:LinkButton>
                        </td>
                        <td style="padding: 15px;">
                            <strong class="mb block">授权角色</strong>
                            <asp:ListBox ID="lstBoxRight" CssClass="inputText listbox" runat="server" Height="380px"
                                Width="200px" OnSelectedIndexChanged="lbtnToLeft_one_Click" AutoPostBack="True"></asp:ListBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
