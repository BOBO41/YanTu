<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSystemRoleInfo.aspx.cs" Inherits="WebSite.Web.Manage.Systems.AddSystemRoleInfo" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>沿途后台</title>
</head>
<body>
    <form id="form1" runat="server" style="margin: 0">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <div class="control-label"><span style="color: red">*</span>角色名称：</div>
                    <div class="controls">
                        <input type="text" id="txtRoleNames" runat="server" placeholder="请输入角色名称" />
                    </div>
                </div>
                <div class="control-group">
                    <div class="control-label">角色说明：</div>
                    <div class="controls">
                        <input type="text" id="txtRoleMemo" runat="server" placeholder="请输入角色说明" />
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAdd();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script language="javascript">
            function goAdd() {
                var RoleName = $("#txtRoleNames").val();
                var RoleMemo = $("#txtRoleMemo").val();
                var IsSuper = $('input[name=rboIsSuper]:checked').val();
                $.ajax({
                    type: 'POST', url: '/Manage/Systems/AJAX/RoleInfo.aspx?role_id=<%=Request.QueryString["role_id"]%>&RoleName=' + encodeURI(encodeURI(RoleName)) + "&RoleMemo=" + encodeURI(encodeURI(RoleMemo)) + "&IsSuper=" + IsSuper, success: function (data) {
                        if (data == "保存成功") {
                            window.top.$op.location = window.top.$op.location;
                            window.top.$modal.destroy();
                        } else {
                            alert(data);
                        }
                    }
                });
            }
        </script>
    </form>
</body>
</html>
