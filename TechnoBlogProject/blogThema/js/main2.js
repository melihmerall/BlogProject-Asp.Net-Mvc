(function ($) {
    "use strict"

    // Mobile dropdown
    $('.has-dropdown>a').on('click', function () {
        $(this).parent().toggleClass('active');
    });

    // Aside Nav
    $(document).click(function (event) {
        if (!$(event.target).closest($('#nav-aside')).length) {
            if ($('#nav-aside').hasClass('active')) {
                $('#nav-aside').removeClass('active');
                $('#nav').removeClass('shadow-active');
            } else {
                if ($(event.target).closest('.aside-btn').length) {
                    $('#nav-aside').addClass('active');
                    $('#nav').addClass('shadow-active');
                }
            }
        }
    });
    $('.nav-aside-close').on('click', function () {
        $('#nav-aside').removeClass('active');
        $('#nav').removeClass('shadow-active');
    });


    $('.search-btn').on('click', function () {
        $('#nav-search').toggleClass('active');
    });

    $('.search-close').on('click', function () {
        $('#nav-search').removeClass('active');
    });

    // Kaymalý header
    $.stellar({
        responsive: true
    });
    $(document).ready(function () {
        $(window).scroll(function () {
            if ($(document).scrollTop() == 0) {
                $('.nav-top').removeClass('headingg');
            } else {
                $('.nav-top').addClass('headingg');
            }
        });
    });

})(jQuery);
