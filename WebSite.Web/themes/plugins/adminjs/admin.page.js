// JavaScript Document
$(function () {

    /**/
    /*主框架 导航跳转*/
    var frame = $("#mainFrame");
    var alink = $(".dl-menu li a ");
    alink.click(function () {
        //alert("跳转到页面"+$(this).children().find('a').attr('name'));	
        frame.attr("src", $(this).attr('name'));
    })

    /*	$('.sys-nav >li:odd').addClass('odd');
        $('.sys-nav >li').last().addClass('last');
        $(".sys-nav >li").hover(function(){$(this).addClass("hover");},function(){$(this).removeClass("hover")})*/
    /**/


    $('.toolbox .btn-click').click(function () {
        $(this).siblings('.toolbox-body').show();
        $(this).addClass('active');
    })
    $('.toolbox .toolbox-body').hover(function () { }, function () {
        $(this).hide();

        $(this).siblings('.btn-click').removeClass('active');
    })

    $('.pannel .pannel-header span').hover(function () { $(this).addClass('hover'); }, function () { $(this).removeClass('hover'); })
    $('.pannel .pannel-header .b').click(function () {
        $(this).parent().siblings('.pannel-body').toggle();
        $(this).children().children('i').toggleClass('icon-chevron-down');
    })


    $('.dl-menu dl dt').hover(function () { $(this).addClass('hover'); }, function () { $(this).removeClass('hover'); })
    /*$('.dl-menu dl dt').click(function(){
		$(this).parent('dl').toggleClass('active');
		$(this).parent().siblings('dl').removeClass('active');
			
	})*/

    $('.dl-menu dl dt').click(function () {
        if ($(this).parent('dl').hasClass('active')) {
            $(this).parent('dl').removeClass('active');
            $(this).siblings("ul").hide();
        } else {
            $('.dl-menu dl').removeClass('active');
            $(this).parent('dl').addClass('active');
            $(".dl-menu dl>ul").hide();
            $(this).siblings("ul").slideDown();
        }
    })


    $('.dl-menu>dl>ul>li').click(function () {
        $('.dl-menu>dl>ul>li').removeClass('active');
        $(this).addClass('active');
    })

    /**/
    $('.qybox .list li').click(function () {
        $(this).siblings('li').removeClass('active');
        $(this).addClass('active');;
        /*$(this).parent().parent().siblings('.tnav').text($(this).children('a').text());*/
    })

    /**/
    $('.table-selected  tr').click(function () {
        $(this).siblings('tr').removeClass('active');
        $(this).addClass('active');;
    })
    $('.table tr:odd').addClass('odd');
    $('.table tr').hover(function () { $(this).addClass('hover'); }, function () { $(this).removeClass('hover'); })





})