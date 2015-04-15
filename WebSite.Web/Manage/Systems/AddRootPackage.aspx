<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRootPackage.aspx.cs" Inherits="WebSite.Web.Manage.Systems.AddRootPackage" %>

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
        <div id="rpkgdiv">
            <div class="form-horizontal">
                <div class="modal-body">
                    <div class="control-group">
                        <label class="control-label" for="inputPassword"><span style="color: red;">*</span>新资源包名称：</label>
                        <div class="controls">
                            <input type="text" id="txtName" placeholder="新资源包名称" runat="server" />
                        </div>
                    </div>
                    <div class="control-group" id="cretype" runat="server">
                        <label class="control-label"><span style="color: red;">*</span>创建方式：</label>
                        <div class="controls">
                            <input id="rboSingle" type="radio" runat="server" name="rboSelectType" value="1" onclick="hideorg();" />
                            创建空白包
                        <input id="rboDouble" type="radio" runat="server" name="rboSelectType" value="14" onclick="shorg();" />
                            复制已有包
                        </div>
                    </div>
                    <div class="control-group" id="dorg" runat="server" style="display: none">
                        <label class="control-label" for="inputPassword"><span style="color: red;">*</span>资源包：</label>
                        <div class="controls">
                            <asp:DropDownList runat="server" ID="ddlOrgName" onchange="ChangeProvince();">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="stapkg" style="display: none" class="control-group">
                        <label class="control-label" for="inputPassword"><span style="color: red;">*</span>铁路局：</label>
                        <div class="controls">
                            <select id="ddlCity" name="ddlCity" onchange="ChangeCity();">
                            </select>
                            <asp:HiddenField ID="hfCity" runat="server" />
                        </div>
                    </div>
                    <script>
                        function ckdata() {
                            var name = document.getElementById("<%=txtName.ClientID%>").value;
                            if (name == "") {
                                alert("请输入新资源包名称");
                                return false;
                            }
                            var type = document.getElementById("rboDouble").checked;
                            var rpid = document.getElementById("<%=ddlOrgName.ClientID%>").value;
                            var orgid = document.getElementById("ddlCity").value;
                            if (type) {
                                if (rpid == "-1") {
                                    alert("请选择待复制的资源包");
                                    return false;
                                } else {
                                    if (orgid == "-1" || "" == orgid || undefined == orgid) {
                                        alert("请选择铁路局");
                                        return false;
                                    }
                                }
                            }
                            document.getElementById("rpkgdiv").style.display = "none";
                            document.getElementById("rpkgdiving").style.display = "block";
                            window.top.$(".modal-header a").remove();
                            return true;
                        }
                        function shorg() {
                            document.getElementById("dorg").style.display = "block";
                        }
                        function hideorg() {
                            document.getElementById("dorg").style.display = "none";
                            document.getElementById("<%=hfCity.ClientID%>").value = "";
                        }
                        function ChangeCity() {
                            document.getElementById("<%=hfCity.ClientID%>").value = document.getElementById("ddlCity").value;
                    }
                    function ChangeProvince() {
                        document.getElementById("ddlCity").options.length = 0;
                        var province = document.getElementById("<%=ddlOrgName.ClientID%>");
                        if (province.value != "") {
                            $.ajax({
                                type: 'POST',
                                url: '/Manage/Systems/AJAX/GetCityList.aspx?pId=' + province.value,
                                success: function (data) {
                                    if (data != "") {
                                        var array = data.split(",");
                                        document.getElementById("ddlCity").options.add(new Option("请选择铁路局", "-1"));
                                        document.getElementById("<%=hfCity.ClientID%>").value = -1;
                                        for (var i = 1; i < array.length; i++) {
                                            var city = array[i].split("|");
                                            document.getElementById("ddlCity").options.add(new Option(city[1], city[0]));
                                        }
                                        document.getElementById("stapkg").style.display = "block";
                                        //$('#ddlCity').selectmenu('refresh');
                                    } else {
                                        document.getElementById("stapkg").style.display = "none";
                                        document.getElementById("<%=hfCity.ClientID%>").value = "";
                                    }
                                }
                            });
                        } else {
                            document.getElementById("stapkg").style.display = "none";
                            document.getElementById("<%=hfCity.ClientID%>").value = "";
                        }
                    }
                    </script>
                </div>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnSub" CssClass="btn btn-success" runat="server" Text="确定" OnClick="btnSub_Click" OnClientClick="return ckdata();" />
                <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
            </div>
        </div>
        <div id="rpkgdiving" style="display: none">
            <div class="form-horizontal">
                <div class="modal-body">
                    <p style="text-align: center; font-size: 22px;">资源包正在拼命的生成中,请稍候...</p>
                </div>
            </div>
            <%--<div class="modal-footer">
                <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button></div>--%>
        </div>
    </form>
</body>
</html>
