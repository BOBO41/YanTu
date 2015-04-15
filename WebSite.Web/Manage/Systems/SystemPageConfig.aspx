<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemPageConfig.aspx.cs" Inherits="WebSite.Web.Manage.Systems.SystemPageConfig" %>

<!DOCTYPE HTML>
<html>
<head>
    <meta charset="utf-8" />
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
</head>
<script type="text/javascript">
    $(function () {
        $(".class .class-one").click(function () {
            $(this).parent().parent().parent().parent().next(".divbox-one").toggle();
            $(this).toggleClass("icon-closed");

        })
        $(".class .class-two").click(function () {
            $(this).toggleClass(".class-three").parent().parent().parent().parent().next(".divbox-two").toggle();
            $(this).toggleClass("icon-closed");
        })

        ////////////////////////////////////////////////////////
        $(".class .class-one").parent().hover(function () { $(this).addClass("active"); }, function () { $(this).removeClass("active"); });
        $(".class .class-two").parent().hover(function () { $(this).addClass("active"); }, function () { $(this).removeClass("active"); });
    })
    function addData() {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddSystemPageConfig.aspx?dateTime=<%=DateTime.Now.Second %>', title: '新增' });
        window.top.$modal.show();
    }
    function editData(aId) {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddSystemPageConfig.aspx?pc_id=' + aId + "&dateTime=<%=DateTime.Now.Second %>", title: '编辑功能信息' });
        window.top.$modal.show();
    }
    function addSubData(aId) {
        window.top.$op = this;
        window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddSystemPageConfig.aspx?pageid=' + aId + "&dateTime=<%=DateTime.Now.Second %>", title: '添加子功能' });
        window.top.$modal.show();
    }
</script>
<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel">
            <div class="pannel-header">
                <strong>功能管理</strong>
            </div>
            <asp:HiddenField runat="server" ID="hidPcid" />
            <div class="pannel-body">
                <div class="form-inline">
                    <a href="javascript:void(0);" class="btn btn-mini" onclick="addData();">新增</a>
                </div>
                <table class="table table-bordered" border="0" id="tabList">
                    <tr>
                        <th align="left" nowrap="nowrap">功能名称
                        </th>
                        <th align="left" nowrap="nowrap">功能说明
                        </th>
                        <th align="left" nowrap="nowrap">链接页面
                        </th>
                        <th class="act" nowrap="nowrap">添加子功能
                        </th>
                        <th class="act" nowrap="nowrap">操作</th>
                    </tr>

                    <%
      
                        System.Data.DataTable table1 = GetNewDataTable(dataTable, " PC_ParentId=0 ");
                        if (table1 != null)
                        {
                            if (table1.Rows.Count > 0)
                            {
                                for (int i = 0; i < table1.Rows.Count; i++)
                                {


                    %>

                    <tr>
                        <td>
                            <div class="class-one" style="width: 100%; padding-left: 15px;">
                                <i class="icon-folder-open"></i><strong><%= table1.Rows[i]["PC_Name"]%></strong>
                            </div>
                        </td>
                        <td>
                            <%= table1.Rows[i]["PC_Memo"]%>
                        </td>
                        <td>
                            <%= table1.Rows[i]["PC_HrefUrl"]%>
                        </td>
                        <td class="act">
                            <a href="javascript:void(0);" onclick="addSubData('<%=table1.Rows[i]["PC_Id"].ToString()%>')" class="btn btn-mini">添加子功能</a>
                        </td>
                        <td align="center" class="act">
                            <a href="javascript:void(0);" onclick="editData('<%=table1.Rows[i]["PC_Id"]%>')" class="btn btn-mini">编辑</a>
                            <a onclick="goDel(<%=table1.Rows[i]["PC_Id"]%>);" href="javascript:void(0)" class="btn btn-mini">删除</a>
                        </td>
                        <script language="javascript">

                            function goDel(id) {
                                if (!confirm("确实要删除吗?")) {
                                    return false;
                                }
                                $.ajax({
                                    type: 'POST', url: '/Manage/Systems/AJAX/PageInfo.aspx?detpg_id=' + id, success: function (data) {
                                        if (data == "删除成功") {

                                            alert(data);
                                            window.location = window.location;
                                        } else {
                                            alert(data);
                                        }
                                    }
                                });
                            }
                        </script>
                    </tr>

                    <div class="divbox-one">

                        <%  
                                    System.Data.DataTable table2 = GetNewDataTable(dataTable,
                                                                                      " PC_ParentId='" + table1.Rows[i]["PC_Id"] + "' ");

                                    if (table2 != null)
                                    {
                                        if (table2.Rows.Count > 0)
                                        {

                                            for (int k = 0; k < table2.Rows.Count; k++)
                                            {

                        %>

                        <tr>
                            <td>
                                <div class="class-two" style="width: 100%; padding-left: 15px;">
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <i class="icon-th-list"></i><%= table2.Rows[k]["PC_Name"]%>
                                </div>
                            </td>
                            <td>
                                <%= table2.Rows[k]["PC_Memo"]%>
                            </td>
                            <td>
                                <%= table2.Rows[k]["PC_HrefUrl"]%>
                            </td>
                            <td align="center"></td>
                            <td align="center" class="act">
                                <a href="javascript:void(0);" onclick="editData('<%=table2.Rows[k]["PC_Id"]%>')" class="btn btn-mini">编辑</a>
                                <a onclick="goDel2(<%=table2.Rows[k]["PC_Id"]%>);" href="javascript:void(0)" class="btn btn-mini">删除</a>
                            </td>

                            <script language="javascript">

                                function goDel2(id) {
                                    if (!confirm("确实要删除吗?")) {
                                        return false;
                                    }
                                    $.ajax({
                                        type: 'POST', url: '/Manage/Systems/AJAX/PageInfo.aspx?detpg_id=' + id, success: function (data) {
                                            if (data == "删除成功") {

                                                alert(data);
                                                window.location = window.location;
                                            } else {
                                                alert(data);
                                            }
                                        }
                                    });
                                }
                            </script>
                        </tr>

                        <% }
                                        }
                                    }%>
                    </div>
                    <% }
                            }
                        } %>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
