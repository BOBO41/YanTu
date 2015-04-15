<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSystemDepartmentInfo.aspx.cs" Inherits="WebSite.Web.Manage.Systems.AddSystemDepartmentInfo" %>

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
<script language="javascript">
    function goAdd(adn_id) {
        $.ajax({
            type: 'POST', url: 'AddSystemAdminUser.aspx?adn_id=' + adn_id, success: function (data) {
                if (data == "添加成功" || data == "修改成功") {

                } else {
                    alert(data);
                }
            }
        });
    }
</script>
<body class="wraper">
    <form id="form1" runat="server" class="form-horizontal">
        <div class="modal">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h3>
                    <asp:Label Text="新增组织机构信息 " runat="server" ID="lblTitle"></asp:Label></h3>
                <asp:HiddenField ID="dept_id" runat="server" />
                <asp:HiddenField runat="server" ID="hidDptid" />
            </div>
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label"><span style="color: red">*</span>组织机构名称：</label>
                    <div class="controls">
                        <input type="text" id="txtDeptName" runat="server" placeholder="请输入组织机构名称" class="required" />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a onclick="goAdd();" class="btn btn-primary">确定</a>
            </div>
            <script language="javascript">

                function goAdd() {
                    var DeptName = $("#txtDeptName").val();
                    $.ajax({
                        type: 'POST', url: '/Manage/Systems/AJAX/DepartmentInfo.aspx?dpt_id=<%=Request.QueryString["dpt_id"]%>&dptid=<%=Request.QueryString["dptid"]%>&DeptName=' + encodeURI(encodeURI(DeptName)), success: function (data) {
                            if (data == "保存成功") {

                                alert(data);
                                window.location = window.location;
                            } else {
                                alert(data);
                            }
                        }
                    });
                }
            </script>
        </div>
    </form>
</body>
</html>
