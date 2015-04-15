<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemSetRole.aspx.cs" Inherits="WebSite.Web.Manage.Systems.SystemSetRole" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>沿途后台</title>
</head>
<script type="text/javascript">
    $(function () {
        $("#cboSelectAll").click(function () {
            if ($(this).attr("checked")) {

                $("#tabSetRole input").attr("checked", $(this).attr("checked"));
            } else {
                $("#tabSetRole input").attr("checked", false);
            }
        });
    })
</script>
<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal" style="padding: 0px;">
            <div class="modal-body">
                <table class="table table-bordered" border="0" id="tabSetRole" style="margin-bottom: 0px;">
                    <tr>
                        <th class="id" nowrap="nowrap">
                            <input type="checkbox" name="cboSelectAll" id="cboSelectAll"></th>
                        <th nowrap="nowrap">角色名称</th>
                        <%--<th nowrap="nowrap" nowrap="nowrap">是否超管</th>--%>
                        <th nowrap="nowrap">角色状态</th>
                    </tr>
                    <asp:Repeater ID="RepeaterMyRole" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="id">
                                    <input type="checkbox" name="cbSalesRole" <%#selectCheck(Eval("Role_Id").ToString())%> id="cbSalesRole">
                                    <input value='<%#Eval("Role_Id") %>' type="hidden" />
                                </td>
                                <td><%#Eval("Role_Name")%></td>
                                <%--<td nowrap="nowrap"><%#Eval("Role_IsSuper")%></td>--%>
                                <td><font color="red"><%#Eval("Role_Status")%></font></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <script language="javascript">
                    function goAdd() {
                        var checkList = $("#tabSetRole input[type='checkbox']");     //查找到所有checkbox的值  集合
                        var hdList = $("#tabSetRole input[type='hidden']");
                        var gid_str = "";
                        for (var i = 1; i < checkList.length; i++) {//遍历所有的值   
                            if (checkList[i].checked) {//是否是被选择
                                var link_id = hdList[i - 1].value;//选择的标识的值
                                gid_str += link_id + '_'; //组成一个字符串
                            }
                        }
                        $.ajax({
                            type: 'POST', url: '/Manage/Systems/AJAX/RoleInfo.aspx?adnUser_id=<%=Request.QueryString["adn_id"]%>&gid_str=' + gid_str, success: function (data) {
                                if (data == "保存成功") {
                                    alert(data);
                                    window.top.$modal.destroy();
                                } else {
                                    alert(data);
                                }
                            }
                        });
                    }
                </script>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAdd();" class="btn btn-success" id="btnSave">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
