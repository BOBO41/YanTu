<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddSystemAdminUser.aspx.cs" Inherits="WebSite.Web.Manage.Systems.AddSystemAdminUser" %>

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

<body class="wraper">
    <form id="form1" runat="server" class="form-horizontal">
        <div class="modal">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h3>
                    <asp:Label Text="新增用户信息 " runat="server" ID="lblTitle"></asp:Label></h3>
                <asp:HiddenField runat="server" ID="hidadn_id" />
                <asp:HiddenField runat="server" ID="hidDptid" />
            </div>
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label"><span style="color: red">*</span>用户姓名：</label>
                    <div class="controls">
                        <input type="text" id="txtAdnUserName" runat="server" placeholder="请输入用户姓名" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label"><span style="color: red">*</span>真实姓名：</label>
                    <div class="controls">
                        <input type="text" id="txtAdnRealName" runat="server" placeholder="请输入真实姓名" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red">*</span>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;码：</label>
                    <div class="controls">
                        <asp:TextBox ID="txtAdnPassWord" runat="server" TextMode="Password"></asp:TextBox>
                    </div>
                </div>

                <%--   <div class="control-group">
                    <label class="control-label" for="inputPassword">是否工作人员：</label>
                    <div class="controls">
                        <asp:RadioButton runat="server" ID="rboIsWorkTrue" Checked="true" GroupName="rboIsWork" />是
                                <asp:RadioButton runat="server" ID="rboIsWorkFalse" GroupName="rboIsWork" />否
                    </div>
                </div>--%>
                <div class="control-group" style="display: none">
                    <label class="control-label" for="inputPassword">是否置业顾问：</label>
                    <div class="controls">
                        <asp:RadioButton runat="server" ID="rboIsConsultantOK" Checked="true" GroupName="rboIsConsultant" />是
                                <asp:RadioButton runat="server" ID="rboIsConsultantNO" GroupName="rboIsConsultant" />否
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red">*</span>身份证号：</label>
                    <div class="controls">
                        <input type="text" id="txtAdnSelfCard" runat="server" placeholder="请输入身份证号" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword">联系电话：</label>
                    <div class="controls">
                        <input type="text" id="txtAdnMobile" runat="server" placeholder="请输入联系电话" />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a onclick="goAdd();" class="btn btn-primary">确定</a>
            </div>
            <script language="javascript">
                function goAdd() {
                    var AdnUserName = $("#txtAdnUserName").val();
                    var AdnRealName = $("#txtAdnRealName").val();
                    var AdnPassWord = $("#txtAdnPassWord").val();
                    //var IsWork = $('input[name=rboIsWork]:checked').val();

                    var IsConsultant = $('input[name=rboIsConsultant]:checked').val();
                    var AdnSelfCard = $("#txtAdnSelfCard").val();
                    var AdnMobile = $("#txtAdnMobile").val();
                    $.ajax({
                        type: 'POST', url: '/Manage/Systems/AJAX/AdminUser.aspx?adn_id=<%=Request.QueryString["adn_id"]%>&AdnUserName=' + encodeURI(encodeURI(AdnUserName)) + "&AdnRealName=" + encodeURI(encodeURI(AdnRealName)) + "&AdnPassWord=" + AdnPassWord + "&AdnIsConsultant=" + IsConsultant + "&AdnSelfCard=" + AdnSelfCard + "&AdnMobile=" + AdnMobile + "&dpt_id=<%=Request.QueryString["dpt_id"]%>", success: function (data) {
                            if (data == "保存成功" || data == "删除成功") {

                                alert(data);
                                window.location = window.location;
                            } else {
                                alert(data);
                            }
                        }
                    });
                }
            </script>
        </div>
    </form>
</body>
</html>
