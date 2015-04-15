<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OrgTree.ascx.cs" Inherits="WebSite.Web.UserControl.OrgTree" %>
<link href="/themes/js/jstree/themes/classic/style.css" rel="stylesheet" type="text/css" />
<script src="/themes/js/jstree/_lib/jquery.cookie.js" type="text/javascript"></script>
<script src="/themes/js/jstree/_lib/jquery.jstree.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        function customMenu(node) {
            var items = {
                create: {
                    label: "新增",
                    action: function (obj) { this.create(obj); }
                },
                rename: {
                    id: "rename",
                    label: "修改",
                    action: function (obj) { this.rename(obj); }
                },
                remove: {
                    label: "删除",
                    action: function (obj) { if (this.is_selected(obj)) { this.remove(); } else { this.remove(obj); } }
                }
            };
            $.ajax({
                type: "post",
                url: "/Manage/Systems/AJAX/CheckPC.aspx",
                data: "id=" + node[0].attributes.id.value,
                async: false,
                success: function (r) {
                    if (r == "yes" || node[0].attributes.id.value == 1) {
                        items.remove._disabled = true;
                    } else {
                        items.remove._disabled = false;
                    }
                }
            });
            return items;
        }
        $("#openall").click(function () {
            $("#demo1").jstree("open_all");
        });
        $("#closeall").click(function () {
            $("#demo1").jstree("close_all");
        });
        $.ajaxSetup({ cache: false });
        //            $("#demo1").bind("loaded.jstree", function(e, data) {
        //                data.inst.open_all(-1);
        //            });
        $.jstree._themes = "../js/jstree/themes/";
        $("#demo1").jstree({
            "themes": {
                "theme": "classic",
                "dots": false,
                "icons": true
            },
            "plugins": ["themes", "json_data", "crrm", "ui", "cookies", "contextmenu"],
            "json_data": {
                "ajax": {
                    "url": "/Manage/Systems/AJAX/GetOrgTree.aspx?menu=<%= Request.QueryString["menu"]%>",
                    "data": function (n) {
                        return { id: n.attr ? n.attr("id").replace("node_", "") : 610000 };
                    }
                }
            },
            "contextmenu": { 'items': customMenu }
        })
            .bind("select_node.jstree", function (e, data) {
                var href = data.rslt.obj.children("a").attr("href");
                $("#ifrOrg").attr('src', href);
                $("#PCNo").val(data.rslt.obj.attr("id"));
            }).bind("create.jstree", function (e, data) {
                $.post(
                    "/Manage/Systems/AJAX/AddPC.aspx",
                    {
                        "id": data.rslt.parent.attr("id").replace("node_", ""),
                        "name": data.rslt.name
                    },
                    function (r) {
                        if (r == "保存成功") {
                            data.inst.refresh();
                        } else {
                            alert(r);
                            $.jstree.rollback(data.rlbk);
                        }
                    }
                );
            })
                .bind("rename.jstree", function (e, data) {
                    if (data.rslt.old_name != data.rslt.new_name) {
                        $.post(
                        "/Manage/Systems/AJAX/EditPC.aspx",
                        {
                            "id": data.rslt.obj.attr("id").replace("node_", ""),
                            "name": data.rslt.new_name
                        },
                        function (r) {
                            if (r == "修改成功") {
                                data.inst.refresh();
                            } else {
                                alert(r);
                                $.jstree.rollback(data.rlbk);
                            }
                        }
                    );
                    }
                })
                .bind("remove.jstree", function (e, data) {
                    $.post(
                        "/Manage/Systems/AJAX/DelPC.aspx",
                        {
                            "id": data.rslt.obj.attr("id").replace("node_", "")
                        },
                        function (r) {
                            if (r != "删除成功") {
                                alert(r);
                                $.jstree.rollback(data.rlbk);
                            }
                        }
                    );
                });
    });
</script>

<h3 class="titbar mb">区域</h3>
<div id='pagetree' style="padding-left: 15px;">
    <input id="PCNo" type="hidden" />
    <div id="demo1" class="demo" style="width: 100%;">
    </div>
</div>
