<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemMember.aspx.cs" Inherits="WebSite.Web.Manage.Systems.SystemMember" %>

<%@ Register Src="../../UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>设置</title>
    <link href="../../themes/default/main.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="../../themes/js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../../themes/js/wiimedia-market.js"></script>
    <script type="text/javascript" src="../../themes/js/bootstrap.modal.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
</head>
<script type="text/javascript">
    $(function () {
        $("#cboSelectAll").click(function () {
            if ($(this).attr("checked")) {
                $("#tabMember input").attr("checked", $(this).attr("checked"));
            } else {
                $("#tabMember input").attr("checked", false);
            }
        });
    })
</script>
<body class="wraper">
    <form id="form1" runat="server">
        <div class="modal hide fade" id="myModal">
            <div class="modal-body">
            </div>
        </div>
        <div class="modal hide fade" id="divPage">
            <div class="modal-body">
            </div>
        </div>
        <div class="main">
            <div class="con tainer">
                <div class="module">
                    <h3>会员管理</h3>
                    <div class="pd">
                        <div class="tabbox">
                            <ul class="tab">
                                <%
      
                                    System.Data.DataTable table = GetUrl();
                                    if (table != null)
                                    {
                                        if (table.Rows.Count > 0)
                                        {
                                            for (int i = 0; i < table.Rows.Count; i++)
                                            {
                                                if (table.Rows[i]["PC_Name"].ToString() == "会员管理")
                                                {
                                %>
                                <li class="active"><%= table.Rows[i]["PC_Name"] %></li>
                                <%
                                                }
                                                else
                                                {
                                                                    
                                %>
                                <li onclick="window.location.href='<%= table.Rows[i]["PC_HrefUrl"] %>?id=<%= table.Rows[i]["PC_ParentId"] %>&dateTime=<%=DateTime.Now.Second %>'"><%= table.Rows[i]["PC_Name"] %></li>
                                <%
                                                }
                                            }
                                        }
                                    } %>
                            </ul>
                            <div class="divbox chtest" style="display: block">
                                <div class="module">
                                    <div class="form-search">
                                        <div class="pd">
                                            真实姓名：<input type="text" runat="server" id="txtRealName" style="width: 140px" />
                                            手机号码：<input type="text" runat="server" id="txtCell" style="width: 140px" />
                                            创建时间：
                                            <input id="txtCreateDate" type="text" class="Wdate" style="width: 120px" onfocus="WdatePicker()" runat="server" />
                                            至&nbsp;<input id="txtcreateDateEnd" type="text" class="Wdate" style="width: 120px" onfocus="WdatePicker()" runat="server" />
                                            <asp:Button ID="btnSearchRole" runat="server" CssClass="btn" OnClick="btnSearchMember_Click" Text="搜索" />
                                        </div>
                                    </div>

                                </div>
                                <div class="btn-group" style="margin-top: 10px">
                                    <asp:LinkButton ID="btndelMember" class="btn btn-mini" OnCommand="btndelMember_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
                                </div>

                                <table class="table table-bordered table-striped" width="100%" border="0" cellspacing="0" id="tabMember">
                                    <tr>
                                        <th align="center" class="id" nowrap="nowrap">
                                            <input type="checkbox" name="cboSelectAll" id="cboSelectAll"></th>
                                        <th nowrap="nowrap" nowrap="nowrap" style="width: 6%">真实姓名</th>
                                        <th nowrap="nowrap" nowrap="nowrap" style="width: 10%">联系电话</th>

                                        <th nowrap="nowrap" nowrap="nowrap" style="width: 10%">电子邮件</th>
                                        <th nowrap="nowrap" nowrap="nowrap">联系地址</th>
                                        <th nowrap="nowrap" nowrap="nowrap" style="width: 10%">创建时间</th>
                                        <th nowrap="nowrap" nowrap="nowrap" style="width: 7%">删除</th>
                                    </tr>
                                    <asp:Repeater ID="RepeaterMyMember" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td align="center">
                                                    <asp:CheckBox ID="cbSalesMember" Name="cbSalesMember" ToolTip='<%#Eval("UID") %>' Text="" runat="server" /></td>
                                                <td nowrap="nowrap" style="width: 6%" align="center"><%#Eval("RealName")%></td>
                                                <td style="width: 10%" nowrap="nowrap" align="center"><%#Eval("Mobile")%></td>

                                                <td style="width: 10%" nowrap="nowrap" align="center"><%#Eval("Email")%></td>
                                                <td nowrap="nowrap"><%#Eval("CusAddr")%></td>
                                                <td style="width: 10%" nowrap="nowrap" align="center"><%#Eval("CreateDate")%></td>
                                                <td nowrap="nowrap" style="width: 7%" align="center">
                                                    <asp:LinkButton ID="btnDeleteMember" CommandName='<%#Eval("UID")%>' OnCommand="btnDeleteMember_Click" OnClientClick="return confirm('你确定要删除吗？')" runat="server">删除</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                                <uc1:Pager ID="Pager1" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
