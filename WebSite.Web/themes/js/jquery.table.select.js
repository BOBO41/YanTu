// JavaScript Document
//用以表格 隔行换色、全选、反选、单选高亮
//wangt5k@126.com    qq:303598805
//使用方法 导入此文件至页面

/*  页面中写入如下代码调用  

<script type="text/javascript">
$(function(){
$(".tableList")
.alterBgColor()  //应用插件
});
</script>



页面表格结构
<table class="">
<thead><tr><th></th></tr></thead>
<tbody><tr><td></td></tr></tbody>
</table>

*/



(function ($) {
    $.fn.extend({
        "alterBgColor": function (options) {
            //设置默认值
            options = $.extend({
                odd: "odd", /* 偶数行样式*/
                even: "even", /* 奇数行样式*/
                selected: "active" /* 选中行样式*/
            }, options);
            $("tbody>tr:odd", this).addClass(options.odd);
            $("tbody>tr:even", this).addClass(options.even);
            /* by:yzw
            $('tbody>tr', this).click(function () {
            //判断当前是否选中
            var hasSelected = $(this).hasClass(options.selected);
            //如果选中，则移出selected类，否则就加上selected类
            $(this)[hasSelected ? "removeClass" : "addClass"](options.selected).find(':checkbox').attr('checked', !hasSelected);
            //查找内部的checkbox,设置对应的属性。


            });
            */
            $('tbody>tr :checkbox', this).click(function () {
                var hasSelected = $(this).attr("checked");
                //alert(hasSelected);	
                if (hasSelected) {
                    $(this).parent().parent()["addClass"](options.selected);
                    $(this).attr("checked", true);
                }
                else {
                    $(this).parent().parent()["removeClass"](options.selected);
                    $(this).attr("checked", false);
                }
            });

            //表头中的checkbox （全选 反选）
            $("thead>tr th:first :checkbox:first ").click(function () {
                //判断当前是否选中
                var hasSelected = $(this).attr("checked");
                //如果选中，则移出selected类，否则就加上selected类
                $('tbody>tr')[!hasSelected ? "removeClass" : "addClass"](options.selected);
                if (hasSelected)
                    $('tbody>tr :checkbox').attr("checked", true);
                else
                    $('tbody>tr :checkbox').attr("checked", false);
            });
            // 如果单选框默认情况下是选择的，则高色.
            $('tbody>tr:has(:checked)', this).addClass(options.selected);
            return this;  //返回this，使方法可链。
        }
    });
})(jQuery);

