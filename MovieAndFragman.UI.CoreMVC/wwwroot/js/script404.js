window.requestAnimFrame = (function () {
    return window.requestAnimationFrame ||
        window.webkitRequestAnimationFrame ||
        window.mozRequestAnimationFrame ||
        window.oRequestAnimationFrame ||
        window.msRequestAnimationFrame ||
        function (callback) {
            window.setTimeout(callback, 1000 / 60);
        };
})();

var noise = (function () {
    var ب_ب;
    var ಥ_ಥ;
    var imgData;
    var px;
    var w;
    var h;
    var static;

    var flicker = function () {
        ب_ب = document.getElementById('canv');
        ಥ_ಥ = ب_ب.getContext('2d');
        ب_ب.width = w = 700;
        ب_ب.height = h = 500;
        ಥ_ಥ.fillStyle = 'hsla(255,255%,255%,1)';
        ಥ_ಥ.fillRect(0, 0, w, h);
        ಥ_ಥ.fill();
        imgData = ಥ_ಥ.getImageData(0, 0, w, h);
        px = imgData.data;
        static();
    };

    static = function () {
        setInterval(function () {
            window.requestAnimFrame(static);
            flicks();
        }, 30);
    }
    var flicks = function () {
        for (var i = 0; i < px.length; i += 4) {
            var col = (Math.random() * 255) + 50;
            px[i] = col;
            px[i + 1] = col;
            px[i + 2] = col;
        }
        ಥ_ಥ.putImageData(imgData, 0, 0);
    };

    return {
        init: flicker
    };
}());

noise.init();