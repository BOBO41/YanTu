<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemDepartmentInfo.aspx.cs" Inherits="WebSite.Web.Manage.Systems.SystemDepartmentInfo" %>

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
</script>
<body class="wraper">
    <form id="form1" runat="server">
        <div class="modal hide fade" id="myModal">
            <div class="modal-body">
            </div>
        </div>
        <div class="main">
            <div class="con tainer">
                <div class="module">
                    <h3>组织机构管理</h3>
                    <div class="pd">
                        <div class="tabbox">
                            <ul class="tab">
                                <%
      
                                    System.Data.DataTable table = GetUrl();
                                    if (table != null)
                                    {
                                        if (table.Rows.Count > 0)
                                        {
                                            for (int i = 0; i < table.Rows.Count; i++)
                                            {
                                                if (table.Rows[i]["PC_Name"].ToString() == "组织机构管理")
                                                {
                                %>
                                <li class="active"><%= table.Rows[i]["PC_Name"] %></li>
                                <%
                                                }
                                                else
                                                {
                                                                    
                                %>
                                <li onclick="window.location.href='<%= table.Rows[i]["PC_HrefUrl"] %>?id=<%= table.Rows[i]["PC_ParentId"] %>&dateTime=<%=DateTime.Now.Second %>'"><%= table.Rows[i]["PC_Name"] %></li>
                                <%
                                                }
                                            }
                                        }
                                    } %>
                            </ul>

                            <div class="divbox" style="display: block">
                                <table width="100%" border="0" cellspacing="0" style="width: 100%; height: 100%">
                                    <tr>
                                        <td valign="top">
                                            <div class="main">
                                                <div class="con tainer">
                                                    <div class="tabbox">

                                                        <div class="divbox" style="display: block">
                                                            <table width="100%" border="0" cellspacing="0" style="width: 100%; height: 100%">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <div class="module">
                                                                            <div class="form-search">
                                                                                <div class="pd">
                                                                                    组织机构名称：<input type="text" runat="server" style="width: 140px" id="txtDptName" />
                                                                                    <asp:HiddenField runat="server" ID="HidDPTId" />
                                                                                    <asp:Button ID="btnSearchDpt" runat="server" CssClass="btn" OnClick="btnSearchDpt_Click" Text="搜索" />

                                                                                </div>

                                                                            </div>
                                                                        </div>
                                                                        <div class="btn-group" style="margin-top: 10px">
                                                                            <a data-toggle="modal" class="btn btn-mini" href="AddSystemDepartmentInfo.aspx?dt=<%=DateTime.Now.ToString("fff") %>" data-backdrop="false" data-target="#myModal">新增</a>
                                                                        </div>
                                                                        <div class="class">
                                                                            <table class="table table-bordered" width="100%" border="0" cellspacing="0">
                                                                                <tr>
                                                                                    <th nowrap="nowrap" nowrap="nowrap">组织机构名称</th>
                                                                                    <th nowrap="nowrap" nowrap="nowrap" style="width: 15%">添加子组织机构</th>
                                                                                    <th nowrap="nowrap" nowrap="nowrap" style="width: 9%">编辑</th>
                                                                                    <th nowrap="nowrap" nowrap="nowrap" style="width: 9%">删除</th>
                                                                                </tr>
                                                                            </table>
                                                                            <%
      
                                                                                System.Data.DataTable table1 = GetNewDataTable(dataTable, " Dpt_ParentId=0 ");
                                                                                if (table1 != null)
                                                                                {
                                                                                    if (table1.Rows.Count > 0)
                                                                                    {
                                                                                        for (int i = 0; i < table1.Rows.Count; i++)
                                                                                        {


                                                                            %>
                                                                            <table class="table table-bordered" width="100%" border="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td nowrap="nowrap">
                                                                                        <div class="class-one" style="width: 100%">
                                                                                            <strong><%= table1.Rows[i]["Dpt_Name"]%></strong>
                                                                                        </div>
                                                                                    </td>
                                                                                    <td style="width: 15%; text-align: center" nowrap="nowrap">
                                                                                        <a data-toggle="modal" href="AddSystemDepartmentInfo.aspx?dptid=<%=table1.Rows[i]["Dpt_Id"]%>&dt=<%=DateTime.Now.ToString("fff") %>" data-backdrop="false" data-target="#myModal">添加子部门</a>
                                                                                    </td>
                                                                                    <td style="width: 9%; text-align: center" nowrap="nowrap">
                                                                                        <a data-toggle="modal" href="AddSystemDepartmentInfo.aspx?dpt_id=<%=table1.Rows[i]["Dpt_Id"]%>&dt=<%=DateTime.Now.ToString("fff") %>"  data-backdrop="false" data-target="#myModal">编辑</a>
                                                                                    </td>
                                                                                    <td style="width: 9%; text-align: center" nowrap="nowrap">
                                                                                        <a onclick="goDel(<%=table1.Rows[i]["Dpt_Id"]%>);" href="javascript:void(0)">删除</a>
                                                                                    </td>
                                                                                    <script language="javascript">

                                                                                        function goDel(id) {
                                                                                            if (!confirm("确实要删除吗?")) {
                                                                                                return false;
                                                                                            }
                                                                                            $.ajax({
                                                                                                type: 'POST', url: '/Manage/Systems/AJAX/DepartmentInfo.aspx?detdpt_id=' + id, success: function (data) {
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
                                                                            </table>
                                                                            <div class="divbox-one">

                                                                                <%  
                                                                                            System.Data.DataTable table2 = GetNewDataTable(dataTable,
                                                                                                                                              " Dpt_ParentId='" + table1.Rows[i]["Dpt_Id"] + "' ");

                                                                                            if (table2 != null)
                                                                                            {
                                                                                                if (table2.Rows.Count > 0)
                                                                                                {

                                                                                                    for (int k = 0; k < table2.Rows.Count; k++)
                                                                                                    {

                                                                                %>
                                                                                <table class="table table-bordered" width="100%" border="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td nowrap="nowrap">
                                                                                            <div class="class-two" style="width: 100%">
                                                                                                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<%= table2.Rows[k]["Dpt_Name"]%>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td style="width: 15%; text-align: center" nowrap="nowrap"></td>
                                                                                        <td style="width: 9%; text-align: center">
                                                                                            <a data-toggle="modal" href="AddSystemDepartmentInfo.aspx?dpt_id=<%=table2.Rows[k]["Dpt_Id"]%>&dt=<%=DateTime.Now.ToString("fff") %>" data-backdrop="false" data-target="#myModal">编辑</a>
                                                                                        </td>
                                                                                        <td style="width: 9%; text-align: center" nowrap="nowrap">
                                                                                            <a onclick="goDel2(<%=table2.Rows[k]["Dpt_Id"]%>);" href="javascript:void(0)">删除</a>
                                                                                        </td>
                                                                                        <script language="javascript">

                                                                                            function goDel2(id) {
                                                                                                if (!confirm("确实要删除吗?")) {
                                                                                                    return false;
                                                                                                }
                                                                                                $.ajax({
                                                                                                    type: 'POST', url: '/Manage/Systems/AJAX/DepartmentInfo.aspx?detdpt_id=' + id, success: function (data) {
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
                                                                                </table>
                                                                                <% }
                                                                                                }
                                                                                            }%>
                                                                            </div>
                                                                            <% }
                                                                                    }
                                                                                }
                                                                            %>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
