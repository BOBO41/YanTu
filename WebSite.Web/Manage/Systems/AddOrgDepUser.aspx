<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOrgDepUser.aspx.cs" Inherits="WebSite.Web.Manage.Systems.AddOrgDepUser" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>沿途后台</title>
</head>

<body>
    <iframe id="ifrSub" name="ifrSub" width="100%" height="100%" frameborder="0" style="display: none" src=""></iframe>
    <form id="form1" runat="server" style="margin: 0" target="ifrSub">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>姓名</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="姓名" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>用户名</label>
                    <div class="controls">
                        <input type="text" id="txtUserName" placeholder="用户名" runat="server" autocomplete="off" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>密码</label>
                    <div class="controls">
                        <span id="box">
                            <input id="txtPwd" runat="server" name="txtPwd" placeholder="密码" type="text" cssclass="input_txt border_radius" onfocus="this.type='password';" autocomplete="off" /></span>
                        <span id="click"><a href="javascript:ps()">显示密码</a></span>
                        <script language="JavaScript">
                            function ps() {
                                document.getElementById("box").innerHTML = "<input type=\"text\"  id=\"txtPwd\" name=\"txtPwd\"  placeholder=\"密码\" value=" + $("#txtPwd").val() + ">";
                                click.innerHTML = "<a href=\"javascript:txt()\">隐藏密码</a>"
                            }
                            function txt() {
                                document.getElementById("box").innerHTML = "<input type=\"password\"  id=\"txtPwd\" name=\"txtPwd\" placeholder=\"密码\"  cssclass=\"input_txt border_radius\" value=" + $("#txtPwd").val() + ">";
                                click.innerHTML = "<a href=\"javascript:ps()\">显示密码</a>"
                            }
                            function shorg() {
                                document.getElementById("dorg").style.display = "block";
                            }
                            function hideorg() {
                                document.getElementById("dorg").style.display = "none";
                            }
                        </script>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>确认密码</label>
                    <div class="controls">
                        <span>
                            <input id="txtpw" runat="server" name="txtPw" placeholder="确认密码" type="text" cssclass="input_txt border_radius" onfocus="this.type='password';" autocomplete="off" /></span>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>性别</label>
                    <div class="controls">
                        <select id="ddlSex" runat="server">
                            <option value="1" selected="selected">男</option>
                            <option value="0">女</option>
                        </select>
                    </div>
                </div>
                <%--<div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>出生日期</label>
                    <div class="controls">
                        <input type="text" id="txtBirthDay" placeholder="出生日期 2114-01-01" runat="server" onfocus="WdatePicker()" />
                    </div>
                </div>--%>
                <%--<div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>地址</label>
                    <div class="controls">
                        <input type="text" id="txtAddr" placeholder="地址" runat="server" />
                    </div>
                </div>--%>
                <div class="control-group">
                    <label class="control-label"><span style="color: red;">*</span>人员类型：</label>
                    <div class="controls">
                        <input id="rboSingle" type="radio" runat="server" name="rboSelectType" value="1" onclick="hideorg();" />
                        系统管理员
                        <input id="rboSinglestaadmin" type="radio" runat="server" name="rboSelectType" value="15" onclick="shorg();" />
                        分站管理员
                        <input id="rboDouble" type="radio" runat="server" name="rboSelectType" value="14" onclick="shorg();" />
                        分站编辑
                        
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>手机</label>
                    <div class="controls">
                        <input type="text" id="txtCell" placeholder="手机" runat="server" />
                    </div>
                </div>
                <div class="control-group" id="dorg" runat="server">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>所属分站：</label>
                    <div class="controls">
                        <asp:DropDownList runat="server" ID="ddlOrgName">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnSub" CssClass="btn btn-success" runat="server" Text="确定" OnClick="btnSub_Click" />
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
    </form>
</body>
</html>
