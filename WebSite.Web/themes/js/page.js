// JavaScript Document
$(function(){
	
	$('.adbox  .btn-box').click(function(){
		$(this).parent('.adbox').hide();	
		
	})
	
	
	$('.nav li.current').append("<span class='arrow'></span>");
	$('.nav li').click(function(){
         $(this).addClass('current').siblings('li').removeClass('current');
		 $(this).append("<span class='arrow'></span>");
		})
		
	/*左侧导航 自适应高度*/	
	
	 //初始化宽度、高度  
    $(".left").height($(window).height()); 
    //当文档窗口发生改变时 触发  
    $(window).resize(function(){  
        $(".left").height($(window).height()); 
    })  
	
	
	
	/**/
	$('.bar li a.ck').children().children('img').attr("src","themes/default/images/icon_heart_red.png");
	$('.bar li a.like').click(function(){
		$(this).children().children('img').attr("src","themes/default/images/icon_heart_red.png");
		//$(this).addClass('ck');
		 $(this).children('i').animate({ 
			width: "25px",
			height:"25px"
		  }, 1000 );
		
		return false;
		
	})
	
	/**/
	$('.listView').each(function(index, element) {
        $(this).children('li').first().addClass('first');
		$(this).children('li').last().addClass('last');
    });
	
	
	//$('.listView li').first().addClass('first');
	//$('.listView li').last().addClass('last');
	
	$('.panel-header').click(function(){
		$(this).next('.panel-body').toggle();
		$(this).parent().toggleClass('active');
		
	})
	
	/**/
	
	
	
	$('.table tr').last().addClass('noborder');
	
	
	
})