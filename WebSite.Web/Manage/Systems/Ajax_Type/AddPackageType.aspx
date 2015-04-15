<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPackageType.aspx.cs" Inherits="WebSite.Web.Manage.Systems.Ajax_Type.AddPackageType" %>

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
            /*width: 100px;*/
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
    <style>
        .imglist {
            padding: 0;
            margin: 0;
            list-style: none;
            overflow: hidden;
            zoom: 1;
        }

            .imglist li {
                float: left;
                /*width: 100px;*/
                margin-right: 8px;
                margin-bottom: 15px;
                text-align: center;
                display: inline;
            }

                .imglist li img {
                    display: block;
                    background-color: #181d23;
                    /*width: 100px;*/
                    /*height: 100px;*/
                    margin-bottom: 5px;
                }

                .imglist li .load {
                    line-height: 5px;
                    height: 5px;
                    background-color: #ccc;
                    position: relative;
                    margin-top: 8px;
                }

                    .imglist li .load .pre {
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
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>分类名称：</label>
                    <div class="controls">
                        <input type="text" id="txtName" placeholder="分类名称" runat="server" />
                    </div>
                </div>
                <%--<div class="control-group">
                    <label class="control-label" for="inputPassword"><span style="color: red;">*</span>分类图标：</label>
                    <div class="controls">
                        <a href="javascript:;" class="btn btn-default btn-sm type-add" data-original-title="" title="">选择文件</a><div id="queuedivtablecontainer">
                            <asp:Literal ID="litPic" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>--%>
                <label class="control-label" for="inputPassword"><span style="color: red;">*</span>分类图标</label>
                <div class="controls" style="margin-left: 50px">
                    <div>
                        <ul class="imglist" id="hotpiccontainer" style="margin-top: 50px; /* margin: 0; */
    padding-left: 40px;">
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification1.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification1.png" name="radclass"></span>
                                </div>
                            </li>
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification2.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification2.png" name="radclass"></span>
                                </div>
                            </li>
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification3.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification3.png" name="radclass"></span>
                                </div>
                            </li>
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification4.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification4.png" name="radclass"></span>
                                </div>
                            </li>
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification5.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification5.png" name="radclass"></span>
                                </div>
                            </li>
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification6.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification6.png" name="radclass"></span>
                                </div>
                            </li>
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification7.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification7.png" name="radclass"></span>
                                </div>
                            </li>
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification8.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification8.png" name="radclass"></span>
                                </div>
                            </li>
                            <li>
                                <div class="upsigin">
                                    <div>
                                        <img src="/UploadFiles/classification9.png"><%--<span> 完成</span>--%>
                                    </div>
                                    <span>
                                        <input id="Radio1" type="radio" value="classification9.png" name="radclass"></span>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a onclick="goAddptype();" class="btn btn-success">确定</a>
            <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button>
        </div>
        <script>
            function goAddptype() {
                var name = $("#txtName").val();
                if ("" == name) {
                    alert("请填写分类名称");
                    return false;
                }
                var cimg = $("input[name='radclass']:checked").val();
                if (cimg == "" || cimg == undefined) {
                    alert("请选择分类图标");
                    return false;
                }
                $.ajax({
                    type: 'POST',
                    url: "/Manage/Systems/AJAX/CreatePackageType.aspx?spid=<%=Request.QueryString["spid"]%>&sortnum=" + window.top.$tmp.attr("data-sort") + "&name=" + escape($("#txtName").val()) + "&atta=" + cimg,
                    success: function (data) {
                        var arr = data.split("|~|");
                        if (arr[0] == 0) {
                            window.top.$op.location = "/Manage/Template/Redircet.aspx?spid=<%=Request.QueryString["spid"]%>&itid=" + arr[1];
                            window.top.$modal.destroy();
                        } else {
                            alert(arr[1]);
                        }
                    }
                });
            }
        </script>
    </form>
</body>
</html>
