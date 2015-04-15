// JavaScript Document
$(function () {



    //////////////////////////////////
    $(".tabbox .tab li").not(".active").hover(function () { $(this).addClass("hover") }, function () { $(this).removeClass("hover") })
    //////////////////////////////////
    var $tab_li = $(".tabbox .tab li");
    var $tab_box = $(".tabbox .divbox");
    $tab_li.click(function () {
        $(this).addClass("active").siblings().removeClass("active");
        var index = $tab_li.index(this);
        $tab_box.eq(index).show().siblings(".divbox").hide();
    })
    //////////////////////////////////
    $(".table tr:odd").addClass("odd");
    $(".table tr").hover(function () { $(this).addClass("hover") }, function () { $(this).removeClass("hover") });
    //$(".table tr").click(function(){
    //			$(this).addClass("active").siblings("tr").removeClass("active");
    //		})
    //		//

    ///////////////////////////////////////

    $("body.left .nav li").click(function () {
        $(this).addClass("active").siblings("li").removeClass("active");
    })
    //////////////////////////////
    $(".module h3").click(function () {
        $(this).siblings().toggle();

    })
    $(".module h3").hover(function () { $(this).addClass("hover") }, function () { $(this).removeClass("hover") });
    //////////









    //$(".table").alterBgColor(); //应用插件



    $(".be-box .be-info").css("z-index", "9999");
})
