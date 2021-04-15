(function ($) {
    'use strict';

    var browserWindow = $(window);

    browserWindow.on('load', function () {
        $('.preloader').fadeOut(3000, function () {
            $(this).remove();
        });
    });

})(jQuery); 
