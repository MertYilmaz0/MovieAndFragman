(function ($) {
    'use strict';

    var browserWindow = $(window);

    browserWindow.on('load', function () {
        $('.preloader').fadeOut(10000, function () {
            $(this).remove();
        });
    });

})(jQuery);