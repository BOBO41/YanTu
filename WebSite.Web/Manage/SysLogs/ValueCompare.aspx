<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValueCompare.aspx.cs" Inherits="WebSite.Web.Manage.SysLogs.ValueCompare" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>沿途后台</title>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
</head>

<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <table class="table table-bordered" style="width: 100%;" border="0" cellspacing="0">
                    <tr>
                        <th style="width: 10px">修改内容</th>
                        <th style="width: 50px">原值</th>
                        <th style="width: 50px">新值</th>
                    </tr>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <tr style="border-bottom: 1px solid black;">
                                <td style="color: red">
                                    <%#Eval("FName") %>
                                </td>
                                <td><%#Eval("OValue") %></td>
                                <td><%#Eval("NValue") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
