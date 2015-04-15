<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemConfig.aspx.cs" Inherits="WebSite.Web.Manage.Systems.SystemConfig" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>设置</title>
    <link href="../../themes/default/main.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="../../themes/js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="../../themes/js/wiimedia-market.js"></script>
    <script type="text/javascript" src="../../themes/js/bootstrap.modal.js"></script>
</head>
<script type="text/javascript">
    function aClick(obj) {
        $("#pagetree td a").removeClass("treeSelect");
        $(obj).addClass("treeSelect");
    };

</script>
<body class="wraper">
    <form id="form1" runat="server">
        <div class="modal hide fade" id="myModal">
            <div class="modal-body">
            </div>
        </div>
        <div class="main">
            <div class="con tainer">
                <div class="module">
                    <h3>用户管理</h3>
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
                                                if (table.Rows[i]["PC_Name"].ToString() == "用户管理")
                                                {
                                %>
                                <li class="active"><%= table.Rows[i]["PC_Name"] %></li>
                                <%
                                                }
                                                else
                                                {
                                                                    
                                %>
                                <li onclick="window.location.href='<%= table.Rows[i]["PC_HrefUrl"] %>?id=<%= table.Rows[i]["PC_ParentId"] %>'"><%= table.Rows[i]["PC_Name"] %></li>
                                <%
                                                }
                                            }
                                        }
                                    } %>
                             
                            </ul>
                            <div class="module">
                                <table width="100%" border="0" cellspacing="0" style="width: 100%; height: 100%">
                                    <tr>
                                        <td width="150" valign="top" style="border-right: solid 1px #eee">
                                            <div id='pagetree' style="overflow-x: hidden; overflow-y: auto; width: 160px;">
                                                <asp:TreeView ID="tvDaiLi" runat="server" CssClass="blank" ShowLines="True">
                                                    <NodeStyle BorderStyle="None" />
                                                    <ParentNodeStyle BorderStyle="None" />
                                                    <RootNodeStyle BorderStyle="None" />
                                                    <SelectedNodeStyle BackColor="#ECE7DF" BorderStyle="None" />
                                                </asp:TreeView>
                                            </div>
                                        </td>
                                        <td valign="top">
                                            <iframe width="100%" height="550" id="frmcenter" name="center" src="SystemConfigMain.aspx"
                                                frameborder="0" scrolling="auto"></iframe>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
