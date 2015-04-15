<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemSetPage.aspx.cs" Inherits="WebSite.Web.Manage.Systems.SystemSetPage" %>

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
                $("#tabpage input").attr("checked", $(this).attr("checked"));
                $("#tabpg input").attr("checked", $(this).attr("checked"));
            }
            else {
                $("#tabpage input").attr("checked", false);
                $("#tabpg input").attr("checked", false);
            }
        })
    })

    $(function () {
        $(".class .class-one").click(function () {
            $(this).parent().parent().parent().parent().next(".divbox-one").toggle();
            $(this).toggleClass("icon-closed");

        })
        $(".class .class-two").click(function () {
            $(this).toggleClass(".class-three").parent().parent().parent().parent().next(".divbox-two").toggle();
            $(this).toggleClass("icon-closed");
        })
        $(".class .class-one").parent().hover(function () { $(this).addClass("active"); }, function () { $(this).removeClass("active"); });
        $(".class .class-two").parent().hover(function () { $(this).addClass("active"); }, function () { $(this).removeClass("active"); });
    })
</script>
<body>
    <form id="form1" runat="server" class="mb0">
        <div class="form-horizontal" id="divPage" style="padding:0px;">
            <asp:HiddenField runat="server" ID="hidRoleId" />
            <div class="modal-body">
                <div class="control-group">
                    <div class="class">
                        <table class="table table-bordered" width="100%" border="0" cellspacing="0" style="margin-bottom:0px;">
                            <tr>
                                <th align="center" class="id" nowrap="nowrap">
                                    <input type="checkbox" name="cbSelectAll" id="cbSelectAll"></th>
                                <th nowrap="nowrap" nowrap="nowrap">功能名称
                                </th>
                            </tr>
                        </table>
                        <%
      
                            System.Data.DataTable table1 = GetNewDataTable(dataTable, " PC_ParentId=0 ");
                            if (table1 != null)
                            {
                                if (table1.Rows.Count > 0)
                                {
                                    for (int i = 0; i < table1.Rows.Count; i++)
                                    {

                        %>
                        <table class="table table-bordered" width="100%" border="0" cellspacing="0" id="tabpg">
                            <tr>
                                <td style="width: 6%; text-align: center" nowrap="nowrap">
                                    <input type="checkbox" name="cbSelectPage" <%=selectCheck(table1.Rows[i]["PC_Id"].ToString())%> id="cbSelectPage">
                                    <input value='<%= table1.Rows[i]["PC_Id"]%>' type="hidden" />
                                </td>
                                <td style="width: 95%" nowrap="nowrap">
                                    <div class="class-one" style="width: 100%">
                                        <strong><%= table1.Rows[i]["PC_Name"]%></strong>
                                    </div>
                                </td>
                            </tr>
                        </table>
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
                            <table class="table table-bordered" width="100%" border="0" cellspacing="0" id="tabpage">
                                <tr style="width: 20%">
                                    <td style="width: 15%; text-align: left" nowrap="nowrap">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;    
                                     <input type="checkbox" name="cbSelect" <%=selectCheck(table2.Rows[k]["PC_Id"].ToString())%> id="cbSelect">
                                        <input value='<%= table2.Rows[k]["PC_Id"]%>' type="hidden" />
                                    </td>
                                    <td style="width: 95%" nowrap="nowrap">
                                        <div class="class-two" style="width: 100%">
                                            <%= table2.Rows[k]["PC_Name"]%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            <% }
                                            }
                                        }%>
                        </div>
                        <% }
                                }
                            } %>
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
                var checkList = $("#tabpg input[type='checkbox']");     //查找到所有checkbox的值  集合
                var hdList = $("#tabpg input[type='hidden']");
                var checkpgList = $("#tabpage input[type='checkbox']");     //查找到所有checkbox的值  集合
                var hdpgList = $("#tabpage input[type='hidden']");
                var gid_str = "";
                for (var i = 0; i < checkList.length; i++) {//遍历所有的值   
                    if (checkList[i].checked) {//是否是被选择
                        var link_id = hdList[i].value;//选择的标识的值
                        gid_str += link_id + '_'; //组成一个字符串
                    }
                }
                for (var j = 0; j < checkpgList.length; j++) {//遍历所有的值   
                    if (checkpgList[j].checked) {//是否是被选择
                        var link_id = hdpgList[j].value;//选择的标识的值
                        gid_str += link_id + '_'; //组成一个字符串
                    }
                }
                $.ajax({
                    type: 'POST', url: '/Manage/Systems/AJAX/PageInfo.aspx?role_id=<%=Request.QueryString["role_id"]%>&gid_str=' + gid_str, success: function (data) {
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
