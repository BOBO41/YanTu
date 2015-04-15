$(function() {

    $('.menu li').hover(
        function() {
            $(this).addClass('hover');
            $(this).children('.nav').show();
            $(this).children('.arrow').show();
        },
        function() {
            $(this).removeClass('hover');
            $(this).children('.nav').hide();
            $(this).children('.arrow').hide();
        }
    );
    //$('.box ').hover(
    //    function() {
    //        $(this).children('.btnbox').show();
    //    },
    //    function() {
    //        $(this).children('.btnbox').hide();
    //    }
    //);
    //$('.newsbox ').hover(
    //    function () {
    //        $(this).children('.btnbox').show();
    //    },
    //    function () {
    //        $(this).children('.btnbox').hide();
    //    }
    //);
    $('.newsbox .tmenu ul li').hover(
        function() {
            $(this).children('.del').show();
        },
        function() {
            $(this).children('.del').hide();
        }
    );
    $('.news-pic').hover(
        function () {
            $(this).children('a').show();
        },
        function () {
            $(this).children('a').hide();
        }
    );
})