<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMColumn.aspx.cs" Inherits="WebSite.Web.Manage.CM.CMColumn" %>

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
    //$(function () {
    //    $(".class .class-one").click(function () {
    //        $(this).parent().parent().parent().parent().next(".divbox-one").toggle();
    //        $(this).toggleClass("icon-closed");

    //    })
    //    $(".class .class-two").click(function () {
    //        $(this).toggleClass(".class-three").parent().parent().parent().parent().next(".divbox-two").toggle();
    //        $(this).toggleClass("icon-closed");
    //    })

    //    ////////////////////////////////////////////////////////
    //    $(".class .class-one").parent().hover(function () { $(this).addClass("active"); }, function () { $(this).removeClass("active"); });
    //    $(".class .class-two").parent().hover(function () { $(this).addClass("active"); }, function () { $(this).removeClass("active"); });
    //})
    function showcolumn(id) {
        $.ajax({
            type: 'POST', url: '/Manage/CM/Ajax/ColumnShow.aspx?id=' + id, success: function (data) {
                if (data != "") {
                    var array = data.split(",");
                    for (var i = 0; i < array.length; i++) {
                        if (array[i]=="") {
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
    function goDel(ColId) {
        if (!confirm("确实要删除吗?")) {
            return false;
        }
        $.ajax({
            type: 'POST', url: '/Manage/CM/Ajax/AddColumn.aspx?detColId=' + ColId, success: function (data) {
                if (data == "删除成功") {
                    window.location = window.location;
                } else {
                    alert(data);
                }
            }
        });
    }
    function addData(ColId, PTColId, title) {
        window.top.$op = this.window;
        window.top.$modal = window.top.$.scojs_modal({ remote: 'AddColumn.aspx?PTColId=' + PTColId + '&ColId=' + ColId + "&dataTime=<%=DateTime.Now.Second%>", title: title });
        window.top.$modal.show();
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
                    <a onclick="addData('','','新增栏目')" href="javascript:void(0);" class="btn btn-mini">新增</a>

                </div>
                <div class="class">
                    <table class="table table-bordered" border="0" style="width: 100%">
                        <tr>
                            <th style="width: 60%">栏目名称
                            </th>
                            <th style="text-align: center; width: 25%">添加子功能
                            </th>
                            <th style="text-align: center; width: 15%">操作
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
                            <td style="text-align: center">
                                <a onclick="addData('','<%=table1.Rows[i]["ColId"]%>','添加子栏目信息')" href="javascript:void(0);" data-title="添加子栏目信息" class="btn btn-mini">添加子栏目</a>
                            </td>
                            <td style="text-align: center">
                                <a onclick="addData('<%=table1.Rows[i]["ColId"]%>','','编辑栏目信息')" href="javascript:void(0);" data-title="编辑栏目信息" class="btn btn-mini">编辑</a>
                                <a onclick="goDel(<%=table1.Rows[i]["ColId"]%>);" href="javascript:void(0)" class='btn btn-mini'>删除</a>
                            </td>
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
                            <td style="text-align: center">
                                <a onclick="addData('','<%=table2.Rows[k]["ColId"]%>','添加子栏目信息')" href="javascript:void(0);" data-title="添加子栏目信息" class="btn btn-mini">添加子栏目</a>
                            </td>
                            <td style="text-align: center">
                                <a onclick="addData('<%=table2.Rows[k]["ColId"]%>','','编辑栏目信息')" href="javascript:void(0);" data-title="编辑栏目信息" class="btn btn-mini">编辑</a>

                                <a onclick="goDel(<%=table2.Rows[k]["ColId"]%>);" href="javascript:void(0)" class='btn btn-mini'>删除</a>
                            </td>
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
                            <td style="text-align: center"></td>
                            <td style="text-align: center">
                                <a onclick="addData('<%=table3.Rows[g]["ColId"]%>','','编辑栏目信息')" href="javascript:void(0);" data-title="编辑栏目信息" class="btn btn-mini">编辑</a>

                                <a onclick="goDel(<%=table3.Rows[g]["ColId"]%>);" href="javascript:void(0)" class='btn btn-mini'>删除</a>
                            </td>
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
