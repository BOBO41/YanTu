<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackageAdmit.aspx.cs" Inherits="WebSite.Web.Manage.Systems.PackageAdmit" %>

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
        $("#cbSelectAll").click(function () {
            if ($(this).attr("checked")) {
                $("#divPage .cbsList:enabled").attr("checked", $(this).attr("checked"));
            } else {
                $("#divPage .cbsList:enabled").attr("checked", false);
            }
        });
    })
</script>
<body>
    <form id="form1" runat="server" class="mb0">
        <div class="form-horizontal" id="divPage" style="padding: 0px;">
            <asp:HiddenField runat="server" ID="hidRoleId" />
            <div class="modal-body">
                <div class="pannel-header" style="text-align: center">
                    <strong>
                        <asp:Literal ID="litPackage" runat="server"></asp:Literal></strong>
                </div>
                <div class="control-group">
                    <table class="table table-bordered tabpkg" width="100%" border="0" cellspacing="0" style="margin-bottom: 0px;">
                        <tr>
                            <th class="id" nowrap="nowrap">
                                <input type="checkbox" name="cbSelectAll" id="cbSelectAll" /></th>
                            <th nowrap="nowrap">分站名称</th>
                            <th nowrap="nowrap">负责人</th>
                            <th nowrap="nowrap">负责人电话</th>
                            <th nowrap="nowrap">资源包状态</th>
                            <th nowrap="nowrap">到期时间</th>
                        </tr>
                        <asp:Repeater ID="rptListWork" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="id">
                                        <input id="cbList" class="cbsList" <%#GetCBStatus(Eval("spstatus"),Eval("OrgId"),Eval("RPID"))%> type="checkbox" name="cbsList" value="<%#Eval("SPID") %>" />
                                    </td>
                                    <td style="text-align: center"><%#Eval("OrgName")%></td>
                                    <td style="text-align: center"><%#Eval("OrgAddress")%></td>
                                    <td style="text-align: center"><%#Eval("OrgPhone")%></td>
                                    <td style="text-align: center">
                                        <%#GetStatus(Eval("spstatus"))%>
                                    </td>
                                    <td style="text-align: center"><%#Convert.ToDateTime(Eval("EndDate"))<DateTime.Now?"<span class=\"label label-important\">已到期</span>":Convert.ToDateTime(Eval("EndDate")).ToString("yyyy-MM-dd")%></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAdd();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script language="javascript">
            function goAdd() {
                var spids = "";
                var un = $(".tabpkg td .label-important,.tabpkg td .label-warning").length;
                $("input[name='cbsList']:checked").each(function () {
                    spids += $(this).val() + ",";
                });
                if (spids == "") {
                    alert("请选择要送审的分站");
                    return false;
                }
                var rs = true;
                if (un > 0) {
                    rs = confirm("还有未完稿的分站，确定提交审核吗？");
                }
                if (rs) {
                    $.ajax({
                        type: 'POST', url: '/Manage/Systems/AJAX/PkgManage.aspx?rpid=<%=Request.QueryString["empId"]%>&spids=' + spids, success: function (data) {
                            if (data == "1") {
                                alert("送审完成,您可以在铁路局资源包管理页面查看");
                                window.top.$op.location = window.top.$op.location;
                                window.top.$modal.destroy();
                            } else {
                                alert("送审失败");
                            }
                        }
                    });
                }
            }
        </script>
    </form>
</body>
</html>
