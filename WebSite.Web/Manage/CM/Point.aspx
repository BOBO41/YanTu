<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Point.aspx.cs" Inherits="WebSite.Web.Manage.CM.Point" %>

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
<script type="text/javascript">
    var flag = 0;
    $(function () {
        $("td").dblclick(function () {
            if (flag == 0) {
                var v = $(this).html();
                flag += 1;
                var a = $(this).get(0);
                var num = $(a).attr("id");
                $(this).html("<input type='text' value='" + v + "' onblur=\"setvalue(this,'" + num + "')\"  onkeydown=\"if(event.keyCode==13) setvalue(this,'" + num + "')\" style=\"text-align: center;width:40px\"/>");
            }
        });
    });
    function setvalue(op, id) {
        $.ajax({
            type: 'POST', url: '/Manage/CM/Ajax/UpdatePoint.aspx?id=' + id + '&op=' + op.value, success: function (data) {
                if (data == "更新成功") {
                    op.parentNode.innerHTML = op.value;
                    flag -= 1;
                } else {
                    alert(data);
                }
            }
        });
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
                <strong>购买价格</strong>
            </div>
            <div class="pannel-body">
                <div class="class">
                    <table class="table table-bordered" border="0" style="width: 100%" id="tabList">
                        <tr>
                            <th nowrap="nowrap" style="text-align: center; width: 50%">商品价格(元)
                            </th>
                            <th nowrap="nowrap" style="text-align: center; width: 50%">赠送积分(积分)
                            </th>
                        </tr>
                        <tr>
                            <td style="text-align: center;" id="<%=RID %>,1"><%=RxValue %></td>
                            <td style="text-align: center" id="<%=RID %>,2"><%=RyValue %></td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
