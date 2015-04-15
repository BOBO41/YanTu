<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMColumnClickRate.aspx.cs" Inherits="WebSite.Web.Manage.CM.CMColumnClickRate" %>

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
    function showcolumn(id) {
        $.ajax({
            type: 'POST', url: '/Manage/CM/Ajax/ColumnShow.aspx?id=' + id, success: function (data) {
                if (data != "") {
                    var array = data.split(",");
                    for (var i = 0; i < array.length; i++) {
                        if (array[i] == "") {
                            continue;
                        }
                        if ($("." + array[i] + "").css('display').toString() == 'none') {
                            $("." + array[i] + "").css('display', '');
                        }
                        else { $("." + array[i] + "").css('display', 'none'); }

                    }
                } else {
                    return;
                }
            }
        });
    }
</script>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel">

            <div class="pannel-header">
                <strong>栏目列表</strong>
            </div>

            <div class="pannel-body">
                <div class="form-inline">
                    <asp:LinkButton ID="btnExport" class="btn btn-mini" OnCommand="btnExport_Command" runat="server">导出</asp:LinkButton>
                </div>
                <div class="class">
                    <table class="table table-bordered" border="0" style="width: 100%">
                        <tr>
                            <th style="width: 60%">栏目名称
                            </th>
                            <th style="text-align: center; width: 25%">访问量(次)
                            </th>
                        </tr>


                        <%
                            System.Data.DataTable table1 = GetNewDataTable(dataTable, " ParentId=0 ");
                            if (table1 != null)
                            {
                                if (table1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < table1.Rows.Count; i++)
                                    {
                        %>

                        <tr onclick="showcolumn('<%=table1.Rows[i]["ColId"]%>')">
                            <td>
                                <div class="class-one" style="width: 100%">
                                    <i class="icon-folder-open"></i>&nbsp;<%= table1.Rows[i]["ColName"]%>
                                </div>
                            </td>
                            <td style="text-align: center"><%= table1.Rows[i]["ClickRate"]%></td>
                        </tr>
                        <%  
                                        System.Data.DataTable table2 = GetNewDataTable(dataTable, " ParentId='" + table1.Rows[i]["ColId"] + "' ");

                                        if (table2 != null)
                                        {
                                            if (table2.Rows.Count > 0)
                                            {

                                                for (int k = 0; k < table2.Rows.Count; k++)
                                                {
                        %>

                        <tr class="<%=table2.Rows[k]["ColId"]%>" onclick="showcolumn('<%=table2.Rows[k]["ColId"]%>')">
                            <td>
                                <div class="class-two" style="width: 100%">
                                    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<i class="icon-folder-open"></i>&nbsp;<%= table2.Rows[k]["ColName"]%>
                                </div>
                            </td>

                            <td style="text-align: center"><%= table2.Rows[k]["ClickRate"]%></td>
                        </tr>
                        <%  
                                                    System.Data.DataTable table3 = GetNewDataTable(dataTable, " ParentId='" + table2.Rows[k]["ColId"] + "' ");

                                                    if (table3 != null)
                                                    {
                                                        if (table3.Rows.Count > 0)
                                                        {
                                                            for (int g = 0; g < table3.Rows.Count; g++)
                                                            {
                        %>

                        <tr class="<%=table3.Rows[g]["ColId"]%>">
                            <td>
                                <div class="class-two" style="width: 100%">
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<i class="icon-folder-open"></i>&nbsp;<%= table3.Rows[g]["ColName"]%>
                                </div>
                            </td>
                            <td style="text-align: center"><%= table3.Rows[g]["ClickRate"]%></td>
                        </tr>
                        <% }
                                                        }
                                                    }%>
                        <% }
                                            }
                                        }%>

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
