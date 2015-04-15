<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMArticleType.aspx.cs" Inherits="WebSite.Web.Manage.CM.CMArticleType" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <title>设置</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="/themes/js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="/themes/js/wiimedia-market.js"></script>
</head>
<script type="text/javascript">
    function goDel(ATId) {
        if (!confirm("确实要删除吗?")) {
            return false;
        }
        $.ajax({
            type: 'POST', url: '/Manage/CM/Ajax/AddArticleType.aspx?detATId=' + ATId, success: function (data) {
                if (data == "删除成功") {
                    window.location = window.location;
                } else {
                    alert(data);
                }
            }
        });
    }
    function addData(ATId, PTParentId, title) {
        window.top.$op = this.window;
        window.top.$modal = window.top.$.scojs_modal({ remote: 'AddArticleType.aspx?ATId=' + ATId + "&dataTime=<%=DateTime.Now.Second%>", title: title });
        window.top.$modal.show();
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
                <strong>内容类型</strong>
            </div>
            <div class="pannel-body">
                <div class="form-inline">
                    <a onclick="addData('','','新增内容类型');" href="javascript:void(0);" data-title="新增内容类型" class="btn btn-mini">新增</a>
                </div>
                <div class="class">
                    <table class="table table-bordered" border="0" style="width: 100%">
                        <tr>
                            <th style="text-align: center" nowrap="nowrap">内容类型名称
                            </th>
                            <th style="text-align: center" nowrap="nowrap">样式风格
                            </th>
                            <th style="text-align: center" nowrap="nowrap">操作
                            </th>
                        </tr>
                        <%
                            System.Data.DataTable table1 = GetNewDataTable(dataTable, "");
                            if (table1 != null)
                            {
                                if (table1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < table1.Rows.Count; i++)
                                    {
                        %>
                        <tr>
                            <td>
                                <div class="class-one" style="width: 100%; text-align: center">
                                    <%= table1.Rows[i]["ATName"]%>
                                </div>
                            </td>
                            <td style="text-align: center"><%= GetStyle( table1.Rows[i]["DisplayCss"].ToString())%>
                            </td>
                            <td style="text-align: center">
                                <a onclick="addData('<%=table1.Rows[i]["ATId"]%>','','编辑类型信息')" href="javascript:void(0);" class="btn btn-mini">编辑</a>

                                <a onclick="goDel(<%=table1.Rows[i]["ATId"]%>);" href="javascript:void(0)" class='btn btn-mini'>删除</a>
                            </td>
                        </tr>
                        <% }
                                }
                            }
                        %>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
