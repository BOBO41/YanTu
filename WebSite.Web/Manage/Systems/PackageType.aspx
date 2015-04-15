<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PackageType.aspx.cs" Inherits="WebSite.Web.Manage.Systems.PackageType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>沿途后台</title>
    <link href="/themes/default/Master.min.css" rel="stylesheet" type="text/css" />
    <link href="/themes/default/pad.css" rel="stylesheet" />
    <script src="/themes/js/jquery.min.js"></script>
    <script src="/themes/plugins/adminjs/admin.page.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#cbSelAll").click(function () {
                if ($(this).attr("checked")) {
                    $("#tabList input").attr("checked", $(this).attr("checked"));
                } else {
                    $("#tabList input").attr("checked", false);
                }
            });
        });
        function addData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddLabel.aspx?aId=' + aId, title: '新增标签' });
            window.top.$modal.show();
        }
        function editData(aId) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: '/Manage/Systems/AddLabel.aspx?OrgId=' + aId, title: '编辑标签' });
            window.top.$modal.show();
        }
        function openModal(url, title) {
            window.top.$op = this.window;
            window.top.$modal = window.top.$.scojs_modal({ remote: url, title: title });
            window.top.$modal.show();
        }
        function navIframe(url) {
            $("#mainFrame", top.document.body).attr("src", url);
        }
    </script>
    <style>
        ul {
            margin: 0px;
        }

            ul li {
                display: block;
                margin-bottom: 10px;
            }

                ul li img {
                    vertical-align: middle;
                }

        .ax_形状 {
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            color: #333333;
            text-align: center;
            line-height: normal;
        }

        #u0 {
            left: 40px;
            top: 50px;
            width: 960px;
            height: 580px;
            border: 1px solid #d6d6d6;
        }

        .ax_菜单 {
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            color: #000000;
            text-align: center;
            line-height: normal;
        }

        #u2 {
            position: absolute;
            left: 40px;
            top: 240px;
            width: 100px;
            border: 1px solid #d6d6d6;
        }

        .ax_h1 {
            font-family: "Arial Bold", "Arial";
            font-weight: 700;
            font-style: normal;
            font-size: 32px;
            color: #333333;
            text-align: left;
            line-height: normal;
        }

        #u20 {
            position: absolute;
            left: 55px;
            top: 123px;
            width: 70px;
            height: 37px;
        }

        .ax_image {
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            color: #000000;
            text-align: center;
            line-height: normal;
        }

        #u22 {
            position: absolute;
            left: 40px;
            top: 170px;
            width: 100px;
            height: 60px;
        }

        #u24 {
            position: absolute;
            left: 170px;
            top: 100px;
            width: 60px;
            height: 50px;
        }

        #u26 {
            position: absolute;
            left: 250px;
            top: 100px;
            width: 100%;
            height: 37px;
        }

        #u28 {
            position: absolute;
            left: 170px;
            top: 170px;
            width: 760px;
            height: 360px;
            border: 1px solid #d6d6d6;
        }

        .ax_html__ {
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            color: #000000;
            text-align: center;
            line-height: normal;
        }

        #u30 {
            position: absolute;
            left: 940px;
            top: 338px;
            width: 50px;
            height: 25px;
        }

        #u31 {
            position: absolute;
            left: 330px;
            top: 560px;
            width: 100px;
            height: 25px;
        }

        #u32 {
            position: absolute;
            left: 680px;
            top: 560px;
            width: 100px;
            height: 25px;
        }

        .ax_文本框_单行_ {
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            color: #000000;
            text-align: left;
            line-height: normal;
        }

        #u33 {
            position: absolute;
            left: 530px;
            top: 560px;
            width: 40px;
            height: 25px;
        }

        #u34 {
            position: absolute;
            left: 480px;
            top: 560px;
            width: 50px;
            height: 22px;
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-size: 18px;
        }

        #u36 {
            position: absolute;
            left: 580px;
            top: 560px;
            width: 40px;
            height: 25px;
        }

        #u37 {
            position: absolute;
            left: 220px;
            top: 210px;
            width: 330px;
            height: 100px;
            border: 1px solid #d6d6d6;
        }

        #u39 {
            position: absolute;
            left: 565px;
            top: 210px;
            width: 330px;
            height: 100px;
            border: 1px solid #d6d6d6;
        }

        #u41 {
            position: absolute;
            left: 220px;
            top: 350px;
            width: 675px;
            height: 100px;
            border: 1px solid #d6d6d6;
        }

        #u43 {
            position: absolute;
            left: 460px;
            top: 610px;
            width: 70px;
            height: 25px;
        }

        #u44 {
            position: absolute;
            left: 565px;
            top: 610px;
            width: 75px;
            height: 25px;
        }

        #u45 {
            position: absolute;
            left: 654px;
            top: 242px;
            width: 153px;
            height: 37px;
        }

        #u47 {
            position: absolute;
            left: 370px;
            top: 382px;
            width: 360px;
            height: 37px;
        }

        #u49 {
            position: absolute;
            left: 304px;
            top: 240px;
            width: 153px;
            height: 37px;
        }

        #u49_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 153px;
            height: 37px;
        }

        #u50 {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 153px;
            white-space: nowrap;
        }

        p {
            margin: 0px;
        }

        #u47_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 360px;
            height: 37px;
        }

        #u48 {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 360px;
            word-wrap: break-word;
        }

        #u45_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 153px;
            height: 37px;
        }

        #u46 {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 153px;
            white-space: nowrap;
        }

        input {
            padding: 1px 0px 1px 0px;
            box-sizing: border-box;
            -moz-box-sizing: border-box;
        }

        #u44_input {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 75px;
            height: 25px;
            background-image: url(../../resources/images/transparent.gif);
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            text-decoration: none;
            color: #000000;
            text-align: center;
        }

        #u43_input {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 70px;
            height: 25px;
            background-image: url(../../resources/images/transparent.gif);
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            text-decoration: none;
            color: #000000;
            text-align: center;
        }

        #u41_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 675px;
            height: 100px;
        }

        #u42 {
            position: absolute;
            left: 2px;
            top: 42px;
            width: 671px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u39_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 330px;
            height: 100px;
        }

        #u40 {
            position: absolute;
            left: 2px;
            top: 42px;
            width: 326px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u37_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 330px;
            height: 100px;
        }

        #u38 {
            position: absolute;
            left: 2px;
            top: 42px;
            width: 326px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u36_input {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 40px;
            height: 25px;
            background-image: url(../../resources/images/transparent.gif);
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            text-decoration: none;
            color: #000000;
            text-align: center;
        }

        #u34_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 50px;
            height: 22px;
        }

        #u35 {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 50px;
            word-wrap: break-word;
        }

        #u33_input {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 40px;
            height: 25px;
            background-image: none;
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            text-decoration: none;
            color: #000000;
            text-align: left;
        }

        #u32_input {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 25px;
            background-image: url(../../resources/images/transparent.gif);
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            text-decoration: none;
            color: #000000;
            text-align: center;
        }

        #u31_input {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 25px;
            background-image: url(../../resources/images/transparent.gif);
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            text-decoration: none;
            color: #000000;
            text-align: center;
        }

        #u30_input {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 50px;
            height: 25px;
            background-image: url(../../resources/images/transparent.gif);
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            text-decoration: none;
            color: #000000;
            text-align: center;
        }

        #u28_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 760px;
            height: 360px;
        }

        #u29 {
            position: absolute;
            left: 2px;
            top: 172px;
            width: 756px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u26_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 70px;
            height: 37px;
        }

        #u27 {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100%;
            word-wrap: break-word;
        }

        #u24_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 60px;
            height: 50px;
        }

        #u25 {
            position: absolute;
            left: 2px;
            top: 17px;
            width: 56px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u22_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 60px;
        }

        #u23 {
            position: absolute;
            left: 2px;
            top: 22px;
            width: 96px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u20_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 70px;
            height: 37px;
        }

        #u21 {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 70px;
            word-wrap: break-word;
        }

        #u2_menu {
            left: -3px;
            top: -3px;
            width: 106px;
            height: 246px;
        }

        .ax_表格 {
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            color: #333333;
            text-align: center;
            line-height: normal;
        }

        #u3 {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 105px;
            height: 245px;
        }

        .ax_表格单元 {
            font-family: "Arial Regular", "Arial";
            font-weight: 400;
            font-style: normal;
            font-size: 13px;
            color: #333333;
            text-align: left;
            line-height: normal;
        }

        #u4 {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
            text-align: center;
            line-height: 6px;
        }

        #u6 {
            position: absolute;
            left: 0px;
            top: 30px;
            width: 100px;
            height: 30px;
            text-align: center;
        }

        #u8 {
            position: absolute;
            left: 0px;
            top: 60px;
            width: 100px;
            height: 30px;
            text-align: center;
        }

        #u10 {
            position: absolute;
            left: 0px;
            top: 90px;
            width: 100px;
            height: 30px;
            text-align: center;
        }

        #u12 {
            position: absolute;
            left: 0px;
            top: 120px;
            width: 100px;
            height: 30px;
            text-align: center;
        }

        #u14 {
            position: absolute;
            left: 0px;
            top: 150px;
            width: 100px;
            height: 30px;
            text-align: center;
        }

        #u16 {
            position: absolute;
            left: 0px;
            top: 180px;
            width: 100px;
            height: 30px;
            text-align: center;
        }

        #u18 {
            position: absolute;
            left: 0px;
            top: 210px;
            width: 100px;
            height: 30px;
            text-align: center;
        }

        #u18_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
        }

        #u19 {
            position: absolute;
            left: 2px;
            top: 7px;
            width: 96px;
            word-wrap: break-word;
        }

        #u16_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
        }

        #u17 {
            position: absolute;
            left: 2px;
            top: 7px;
            width: 96px;
            word-wrap: break-word;
        }

        #u14_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
        }

        #u15 {
            position: absolute;
            left: 2px;
            top: 7px;
            width: 96px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u12_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
        }

        #u13 {
            position: absolute;
            left: 2px;
            top: 7px;
            width: 96px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u10_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
        }

        #u11 {
            position: absolute;
            left: 2px;
            top: 7px;
            width: 96px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u8_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
        }

        #u9 {
            position: absolute;
            left: 2px;
            top: 7px;
            width: 96px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u6_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
        }

        #u7 {
            position: absolute;
            left: 2px;
            top: 7px;
            width: 96px;
            visibility: hidden;
            word-wrap: break-word;
        }

        #u4_img {
            position: absolute;
            left: 0px;
            top: 0px;
            width: 100px;
            height: 30px;
        }

        #u5 {
            position: absolute;
            left: 2px;
            top: 12px;
            width: 96px;
            word-wrap: break-word;
        }

        #u0_img {
            left: 0px;
            top: 0px;
            width: 960px;
            height: 600px;
        }

        #u1 {
            position: absolute;
            left: 2px;
            top: 292px;
            width: 956px;
            visibility: hidden;
            word-wrap: break-word;
        }
    </style>
</head>

<body class="pd">
    <form id="form1" runat="server">
        <div class="pannel">
            <div class="pannel-header">
                <strong>返回</strong>
            </div>
            <div class="pannel-body">
                <div id="base">
                    <div class="ax_形状" id="u0">
                        <div class="text" id="u1">
                            <p><span>&nbsp;</span></p>
                        </div>
                    </div>
                    <div class="ax_菜单" id="u2">
                        <ul>
                            <asp:Literal ID="litType1" runat="server"></asp:Literal><asp:Literal ID="litType2" runat="server"></asp:Literal><asp:Literal ID="litType3" runat="server"></asp:Literal><asp:Literal ID="litType4" runat="server"></asp:Literal><asp:Literal ID="litType5" runat="server"></asp:Literal><asp:Literal ID="litType6" runat="server"></asp:Literal><asp:Literal ID="litType7" runat="server"></asp:Literal>
                            <asp:Literal ID="litType8" runat="server"></asp:Literal>
                        </ul>
                    </div>
                    <div class="ax_h1" id="u20">
                        <div class="text" id="u21">
                            <p>
                                <span>分类</span>
                            </p>
                        </div>
                    </div>
                    <div class="ax_image" id="u22">
                        <img class="img " id="u22_img" src="images/home/u22.png">
                        <div class="text" id="u23">
                            <p><span>&nbsp;</span></p>
                        </div>
                    </div>
                    <div class="ax_image" id="u24">
                        <img class="img " id="u24_img" src="images/home/u24.png">
                        <div class="text" id="u25" style="transform-origin: 28px 7px; top: 18px;">
                            <p><span>&nbsp;</span></p>
                        </div>
                    </div>
                    <div class="ax_h1" id="u26">
                        <div class="text" id="u27">
                            <p>
                                <span>
                                    <asp:Literal ID="litOrg" runat="server"></asp:Literal></span>
                            </p>
                        </div>
                    </div>
                    <div class="ax_形状" id="u28">
                        <div class="text" id="u29">
                            <p><span>&nbsp;</span></p>
                        </div>
                    </div>
                    <div class="ax_html__" id="u30">
                        <button class="btn" type="button">新增</button>
                    </div>
                    <div class="ax_html__" id="u31">
                        <button class="btn" type="button">上一页</button>
                    </div>
                    <div class="ax_html__" id="u32">
                        <button class="btn" type="button">下一页</button>
                    </div>
                    <div class="ax_文本框_单行_" id="u33">
                        <input id="u33_input" type="text" value="">
                    </div>
                    <div class="ax_h1" id="u34">
                        <div class="text" id="u35">
                            <p><span>页码:</span></p>
                        </div>
                    </div>
                    <div class="ax_html__" id="u36">
                        <button class="btn" type="button">修改</button>
                    </div>
                    <div class="ax_形状" id="u37">
                        <div class="text" id="u38">
                            <p><span>&nbsp;</span></p>
                        </div>
                    </div>
                    <div class="ax_形状" id="u39">
                        <div class="text" id="u40">
                            <p><span>&nbsp;</span></p>
                        </div>
                    </div>

                    <div class="ax_形状" id="u41">
                        <div class="text" id="u42">
                            <p><span>&nbsp;</span></p>
                        </div>
                    </div>

                    <div class="ax_html__" id="u43">
                        <button class="btn" type="button">未通过</button>
                    </div>

                    <div class="ax_html__" id="u44">
                        <button class="btn" type="button">删除</button>
                    </div>

                    <div class="ax_h1" id="u45">
                        <div class="text" id="u46">
                            <p><span>Heading 1</span></p>
                        </div>
                    </div>

                    <div class="ax_h1" id="u47">
                        <div class="text" id="u48">
                            <p><span>Heading 1</span><span>55555555555</span></p>
                        </div>
                    </div>

                    <div class="ax_h1" id="u49">
                        <div class="text" id="u50">
                            <p><span>Heading 1</span></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
