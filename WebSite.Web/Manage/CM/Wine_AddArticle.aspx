<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wine_AddArticle.aspx.cs" Inherits="WebSite.Web.Manage.CM.Wine_AddArticle" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>设置</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/themes/js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="/themes/js/wiimedia-market.js"></script>
    <script type="text/javascript" src="/themes/js/bootstrap.modal.js"></script>
    <link rel="stylesheet" href="/themes/js/kindeditor-4.1.6/themes/default/default.css" />
    <script charset="utf-8" src="/themes/js/kindeditor-4.1.6/kindeditor-min.js"></script>
    <script charset="utf-8" src="/themes/js/kindeditor-4.1.6/lang/zh_CN.js"></script>
    <script type="text/javascript" src="/themes/js/My97DatePicker/WdatePicker.js"></script>
</head>
<body class="pd">
    <form id="form5" runat="server" style="padding: 0px">
        <div class="pannel">
            <div class="pannel-header">
                <strong>
                    <asp:Literal ID="lblTitle" runat="server" Text="新增内容"></asp:Literal></strong>
            </div>

            <div class="pannel-body">
                <table style="width: 100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="text-align: right; width: 80px"><span style="color: red">*</span>标题：
                        </td>
                        <td colspan="3">
                            <input type="text" runat="server" id="txtTitle" class="input-block-level" placeholder="请输入标题" maxlength="20" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right">
                            <div style="text-align: right; width: 100px;"><span style="color: red">*</span>栏目：</div>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlColumn" runat="server" class="input-block-level">
                            </asp:DropDownList>
                        </td>
                        <%--<td style="text-align: right;">
                            <span style="color: red">*</span>类型：</td>--%>
                        <%--<td>
                            <asp:DropDownList ID="ddlType" runat="server" class="input-block-level">
                            </asp:DropDownList></td>--%>
                    </tr>
                    <tr>
<%--                        <td style="text-align: right">是否幻灯显示：</td>
                        <td style="padding-left: 0px" class="pd">
                            <asp:RadioButton runat="server" ID="rboIsFlashTrue" GroupName="rboIsFlash" />是
                                <asp:RadioButton runat="server" ID="rboIsFlashFalse" Checked="true" GroupName="rboIsFlash" />否
                        </td>--%>
                        <td style="text-align: right">是否置顶：</td>
                        <td style="padding-left: 0px" class="pd">
                            <asp:RadioButton runat="server" ID="rboIsTopTrue" GroupName="rboIsTop" />是
                                <asp:RadioButton runat="server" ID="rboIsTopFalse" Checked="true" GroupName="rboIsTop" />否
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">引导图：</td>
                        <td>
                            <asp:FileUpload ID="fuPFlash" runat="server" /></td>
<%--                        <td style="text-align: right">附件：</td>
                        <td>
                            <asp:FileUpload ID="fuAtt" runat="server" /></td>--%>
                    </tr>
                    <tr>
                        <td style="text-align: right">&nbsp;</td>
                        <td>
                            <asp:Image ID="Image2" runat="server" Width="300px" Height="129px" Visible="False" CssClass="img" /></td>
                        <td style="text-align: right">&nbsp;</td>
                        <td>
                            <asp:Literal ID="litAtt" runat="server"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">作者：</td>
                        <td class="pd" style="padding-left: 0px">
                            <input type="text" id="txtAuthor" runat="server" placeholder="请输入作者" class="input-block-level" /></td>
                        <td style="text-align: right">来源：</td>
                        <td class="pd" style="padding-left: 0px">
                            <input type="text" id="txtFrom" runat="server" placeholder="请输入来源" class="input-block-level" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right"><span style="color: red">*</span>导读：</td>
                        <td colspan="3" class="pd" style="padding-left: 0px">
                            <textarea id="tarDescription" rows="5" class="input-block-level" runat="server" maxlength="240"></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; vertical-align: top"><span style="color: red">*</span>详细内容：</td>
                        <td colspan="3">
                            <textarea id="tarContent" style="width: 99%;height:500px" name="tarContent" maxlength="500" runat="server" class="input-block-level"></textarea>
                        </td>
                    </tr>
                    
                </table>
            </div>
            <script>
                var editor;
                KindEditor.ready(function (K) {

                    editor = K.create('textarea[name="tarContent"]', {
                        uploadJson: '/themes/js/kindeditor-4.1.6/asp.net/upload_json.ashx',
                        fileManagerJson: '/themes/js/kindeditor-4.1.6/asp.net/file_manager_json.ashx',
                        allowFileManager: true
                    });
                });
            </script>
            <div class="text-center">
                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" OnClick="btnSave_Click" Text="确定" />
                <asp:Button ID="btnCancel" runat="server" class="btn" OnClick="btnCancel_Click" Text="取消" />
            </div>
        </div>
    </form>
</body>
</html>

