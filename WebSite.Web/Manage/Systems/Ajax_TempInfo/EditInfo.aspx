<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditInfo.aspx.cs" Inherits="WebSite.Web.Manage.Systems.Ajax_TempInfo.EditInfo" %>

<!DOCTYPE html>

<html>
<head>
    <meta charset="utf-8">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <title>沿途后台</title>
    <style>
        .upsigin {
            width: 220px;
            float: left;
            margin-top: 10px;
        }

        .load {
            line-height: 5px;
            height: 5px;
            background-color: #ccc;
            position: relative;
            margin-top: 8px;
        }

            .load .pre {
                display: block;
                width: 1%;
                height: 5px;
                background-color: #0C0;
            }
    </style>
</head>

<body>
    <form id="form1" runat="server" style="margin: 0">
        <div class="form-horizontal">
            <div class="modal-body">
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>标题</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="标题" runat="server" />
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>背景图</label>
                    <div class="controls">
                        <a href="javascript:;" class="btn btn-default btn-sm type-add" data-original-title="" title="">选择文件</a> <font color="red">大小<%= Request.QueryString["bgw"] %>*<%= Request.QueryString["bgh"] %></font>
                        <div id="queuedivtablecontainer">
                            <asp:Literal ID="litPic" runat="server"></asp:Literal></div>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label"><span style="color: red;">*</span>内容类型</label>
                    <div class="controls">
                        <input id="radInfo" type="radio" runat="server" checked="True" name="rbntype" value="0" />
                        内容
                        <input id="radAds" type="radio" runat="server" name="rbntype" value="1" />
                        广告
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label">
                        <span style="color: red">*</span>标签：</label>
                    <div class="controls">
                        <table id="tabUser" width="100%" border="0" cellspacing="0">
                            <tr>
                                <%
                                    System.Data.DataSet dt = GetLabel();    //查询商品分类
                                    if (dt != null)
                                    {
                                        if (dt.Tables[0].Rows.Count > 0)
                                        {
                                            for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                                            {   
                                %>
                                <td style="text-align: right; width: 10px">
                                    <input type="checkbox" class="a-lab" name="cboProType" id='cboProType<%= dt.Tables[0].Rows[i]["ALID"] %>' value="<%= dt.Tables[0].Rows[i]["ALID"] %>" <%= selectCheck(dt.Tables[0].Rows[i]["ALID"].ToString() )%>>
                                </td>
                                <td style="text-align: left">
                                    <%= dt.Tables[0].Rows[i]["LName"] %>
                                </td>
                                <% if (i != 0 && (i + 1) % 2 == 0)
                                   { %>
                            </tr>
                            <tr>
                                <% }%>
                                <%}
                                        }
                                    } %>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="control-group">
                    <label class="control-label"><span style="color: red;">*</span>类型</label>
                    <div class="controls">
                        <input id="rbNews" type="radio" runat="server" name="rboSelectType" value="1" />
                        资讯
                        <input id="rbVideo" type="radio" runat="server" name="rboSelectType" value="2" />
                        视频
                        <input id="rbTopic" type="radio" runat="server" name="rboSelectType" value="3" />
                        专题
                    </div>
                </div>
                <div style="display: none">
                    <div style="margin-top: 5px;" id="ddladlink">
                        选择链接:
                    <asp:Literal ID="litselinfo" runat="server"></asp:Literal>
                    </div>
                </div>
                <div id="dorg" runat="server">
                    <div class="control-group">
                        <label class="control-label" for="inputPassword"><%--<span style="color: red;">*</span>--%>广告视频</label>
                        <div class="controls">
                            <a href="javascript:;" class="btn btn-default btn-sm advideo-add" data-original-title="" title="">选择文件</a> <font color="red">mp4格式视频文件</font>
                            <asp:Literal ID="litpausevideo" runat="server"></asp:Literal><div id="advideocontainer"></div>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="inputPassword"><%--<span style="color: red;">*</span>--%>广告时长</label>
                        <div class="controls">
                            <input type="text" id="txtADTime" placeholder="广告时长" runat="server" style="ime-mode: Disabled" onkeyup="check(this);" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="inputPassword"><%--<span style="color: red;">*</span>--%>暂停广告</label>
                        <div class="controls">
                            <a href="javascript:;" class="btn btn-default btn-sm adpic1-add" data-original-title="" title="">选择文件</a> <font color="red">大小800*442</font>
                            <div id="adpcontainer">
                                <asp:Literal ID="litpausepic" runat="server"></asp:Literal></div>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="inputPassword"><span style="color: red;">*</span>视频</label>
                        <div class="controls">
                            <a href="javascript:;" class="btn btn-default btn-sm video-add" data-original-title="" title="">选择文件</a> <font color="red">300M以下的MP4格式视频</font>
                            <div id="videocontainer">
                                <asp:Literal ID="litVideo" runat="server"></asp:Literal></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <a href="javascript:;" onclick="goAddeinfo();" class="btn btn-success">确定</a>
                <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
            </div>

            <script>
                $(document).ready(function () { window.top.uploader6.reset(); });
                function check(obj) {
                    if (isNaN(obj.value)) {
                        alert("请输入数字");
                        obj.value = "";
                    }
                }
                $(".a-lab").live("click", function () {
                    var len = $("input[name='cboProType']:checked").length;
                    if (len > 3) {
                        $(this).attr("checked", false);
                        alert("最多只能选择3个标签");
                    }
                });
                function goAddeinfo() {
                    var batta = $(".upatta").attr("data-file");
                    var name = $("#txtName").val();
                    var vatta = $(".upatta2").attr("data-file");
                    var itype = $("input[name='rboSelectType']:checked").val();
                    var labs = "";
                    var ntype = $("input[name='rbntype']:checked").val();
                    var adpause = "";
                    var adpauseid = "";
                    $(".upatta6").each(function () {
                        adpause += $(this).attr("data-file") + ":";
                        adpauseid += $(this).find("select").val() + ":";
                    });
                    var adpausepic = $(".upatta5").attr("data-file");
                    var adpausepicid = $(".upatta5 .ddlinfo").val();
                    var pausetime = $("#txtADTime").val();
                    $("input[name='cboProType']:checked").each(function () {
                        labs += $(this).val() + ",";
                    });
                    if (name == "" || name == undefined) {
                        alert("请填写标题");
                        return false;
                    }
                    if (batta == "" || batta == undefined) {
                        alert("请上传背景图片");
                        return false;
                    }
                    if (itype == 2) {
                        if (adpause != "" && adpause != undefined) {
                            if (pausetime == "" || pausetime == undefined) {
                                alert("请填写广告时长");
                                return false;
                            }
                        }
                        if (vatta == "" || vatta == undefined) {
                            alert("请上传视频文件");
                            return false;
                        }
                    }
                    $.ajax({
                        type: 'POST',
                        url: "/Manage/Systems/Ajax_Infos/AddFirstInfo.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>&sortnum=<%=Request.QueryString["sortnum"]%>&name=" + escape(name) + "&adpause=" + escape(adpause) + "&pausetime=" + pausetime + "&adpausepic=" + escape(adpausepic) + "&adpauseid=" + adpauseid + "&adpausepicid=" + adpausepicid + "&batta=" + escape(batta) + "&vatta=" + escape(vatta) + "&ntype=" + ntype + "&itype=" + itype + "&iid=<%=Request.QueryString["iid"]%>&labs=" + labs,
                        success: function (data) {
                            var arr = data.split("|~|");
                            if (arr[0] == 0) {
                                window.top.$modal.destroy();
                                window.top.$op.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&tiid=<%=Request.QueryString["tiid"]%>&itid=<%=Request.QueryString["itid"]%>";
                            } else {
                                alert(arr[1]);
                            }
                        }
                    });
                }
            </script>
        </div>
    </form>
</body>
</html>
