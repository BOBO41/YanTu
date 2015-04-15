<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CMAuditArticle.aspx.cs" Inherits="WebSite.Web.Manage.CM.CMAuditArticle" %>

<%@ Register Src="/UserControl/Pager.ascx" TagName="Pager" TagPrefix="uc1" %>
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

    $(function () {
        $("#cbSelectAll").click(function () {
            if ($(this).attr("checked")) {

                $("#tabList input").attr("checked", $(this).attr("checked"));
            }
            else {
                $("#tabList input").attr("checked", false);
            }
        })
    })


</script>
<body class="pd">
    <form id="form1" runat="server">
        <div class="modal hide fade" id="myModal">
            <div class="modal-body">
            </div>
        </div>
        <div class="pannel">
            <div class="pannel-header">
                <strong>文章列表</strong>
            </div>
            <div class="pannel-body">

                <div class="form-inline">
                    文章标题：<input type="text" runat="server" id="txtProName" placeholder="文章标题" class="input-small" />

                    审核状态：<asp:DropDownList runat="server" ID="ddlStatus" Width="120px" OnSelectedIndexChanged="btnSearch_Click" AutoPostBack="True">
                        <asp:ListItem Value="4" Selected="True">审核状态</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="1">已审核</asp:ListItem>
                    </asp:DropDownList>
                    栏目：  
                    <asp:DropDownList ID="ddlColumn" runat="server" Width="120px" OnSelectedIndexChanged="ddlColumn_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    类型：<asp:DropDownList runat="server" ID="ddlType" Width="120px" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success" OnClick="btnSearch_Click" Text="搜索" />
                </div>
                <div class="btn-toolbar" style="margin-top: 10px">

                    <asp:LinkButton ID="btnCheck" class="btn btn-mini" OnCommand="btnCheck_Click" runat="server">审核</asp:LinkButton>
                    <asp:LinkButton ID="btnoBackCheck" class="btn btn-mini" OnCommand="btnBackCheck_Click" OnClientClick="return confirm('你确定要取消审核吗？')" runat="server">取消审核</asp:LinkButton>

                </div>
                <div class="class">
                    <table class="table table-bordered" border="0" style="width: 100%" id="tabList">
                        <tr>
                            <th class="id" nowrap="nowrap" style="text-align: center">
                                <input type="checkbox" name="cbSelectAll" id="cbSelectAll"></th>
                            <th nowrap="nowrap" style="text-align: center">标题
                            </th>
                            <th nowrap="nowrap" style="text-align: center">栏目
                            </th>
                            <th nowrap="nowrap" style="text-align: center">类型
                            </th>
                            <th nowrap="nowrap" style="text-align: center">发布时间
                            </th>
                            <th nowrap="nowrap" style="text-align: center">所属区域
                            </th>
                            <th nowrap="nowrap" style="text-align: center">状态
                            </th>
                            <th nowrap="nowrap" style="text-align: center">审核人
                            </th>
                            <th nowrap="nowrap" style="text-align: center">审核时间
                            </th>
                            <th nowrap="nowrap" style="text-align: center">置顶
                            </th>
                        </tr>
                        <asp:Repeater ID="rptArticle" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="text-align: center">
                                        <asp:CheckBox ID="cbSelect" Name="cbSelect" ToolTip='<%#Eval("AId") %>' Text="" runat="server" /></td>
                                    <input value='<%#Eval("AId") %>' type="hidden" />
                                    <td>
                                        <div class="class-one" style="width: 100%">
                                            <%#Eval("Title")%>
                                        </div>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("ColName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("ATName")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("AddTime")%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#GetArea(Eval("AId").ToString())%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("Status").ToString()=="0"?"<span class=\"label label-important\">未审核</span>":"<span class=\"label label-success\">已审核</span>" %>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("Status").ToString()=="1"?Eval("CEmplName"):""%>
                                    </td>
                                    <td style="text-align: center">
                                        <%#Eval("Status").ToString()=="1"?Eval("CheckTime"):""%>
                                    </td>
                                    <td style="text-align: center">
                                        <a href="#javascript:void(0)" onclick="updatetop(<%#Eval("AId")%>,<%#Eval("IsTop") %>,this)"><%#Eval("IsTop").ToString()=="0"?"<span class=\"label\">未置顶</span>":"<span class=\"label label-info\">已置顶</span>" %></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                    <uc1:Pager ID="Pager" runat="server" />
                </div>
            </div>
        </div>
        <script type="text/javascript">

            function updatetop(aid, top, obj) {
                $.ajax({
                    type: 'POST',
                    url: '/Manage/CM/Ajax/UpdateTop.aspx?aid=' + aid + '&top=' + top,
                    success: function (data) {
                        if (data = "修改成功") {
                            if (top == 1) {
                                obj.innerHTML = '<span class=\"label\">未置顶</span>';
                                obj.setAttribute("onclick", "updatetop('" + aid + "',0,this)");
                            }
                            else {
                                obj.innerHTML = '<span class=\"label label-info\"> 已置顶</span>';
                                obj.setAttribute("onclick", "updatetop('" + aid + "',1,this)");
                            }
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
