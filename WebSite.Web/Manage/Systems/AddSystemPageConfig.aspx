<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSystemPageConfig.aspx.cs" Inherits="WebSite.Web.Manage.Systems.AddSystemPageConfig" %>

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
                    <div class="control-label"><span style="color: red">*</span>功能名称：</div>
                    <div class="controls">
                        <input type="text" id="txtPCNames" runat="server" placeholder="请输入功能名称" />
                    </div>
                </div>

                <div class="control-group">
                    <div class="control-label">功能说明：</div>
                    <div class="controls">
                        <input type="text" id="txtPCMemo" runat="server" placeholder="请输入功能说明" />
                    </div>
                </div>

                <div class="control-group">
                    <div class="control-label"><span style="color: red">*</span>链接页面：</div>
                    <div class="controls">
                        <input type="text" id="txtPCHrefUrl" runat="server" placeholder="请输入链接页面" />
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
                var PCNames = $("#txtPCNames").val();
                var PCMemo = $("#txtPCMemo").val();
                var PCHrefUrl = $("#txtPCHrefUrl").val();
                $.ajax({
                    type: 'POST', url: '/Manage/Systems/AJAX/PageInfo.aspx?pageid=<%=Request.QueryString["pageid"]%>&pc_id=<%=Request.QueryString["pc_id"]%>&PCNames=' + encodeURI(encodeURI(PCNames)) + "&PCMemo=" + encodeURI(encodeURI(PCMemo)) + "&PCHrefUrl=" + encodeURI(encodeURI(PCHrefUrl)), success: function (data) {
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
