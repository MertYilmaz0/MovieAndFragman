var apiurl = "http://localhost:52154/api/"
var apikey = "YWhtZXRtZXJ0YmlsYWw="


function GetLastThirdMovie() {
    $.ajax({
        type: "Get",
        async: false,
        url: apiurl + "fragman/GetLastThirdFragman",
        headers: { "ApiKey": apikey },
        success: function (response) {
            $.ajax({
                type: "Post",
                async: false,
                url: "Movie/LastThird",
                data: JSON.stringify(response),
                contentType: "application/json; charset=utf-8",
                success: function (output) {
                    $("#thirdMovie").html(output)
                }
            })
        }
    })
}

function GetFragmanListAll(method) {
    $.ajax({
        type: "Get",
        url: apiurl + "Fragman/GetAllFragman",
        headers: { "ApiKey": apikey },
        success: function (response) {
            $.ajax({
                type: "Post",
                url: method,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(response),
                success: function (data) {
                    $("#singleFragman").html(data);
                }
            })
        }

    })
}

function GetMovieByCId(id) {
    $.ajax({
        type: "GET",
        url: apiurl + "fragman/GetByGenreId?id=" + id,
        headers: { "ApiKey": apikey },
        success: function (response) {
            $.ajax({
                type: "Post",
                url: "GetMovieList",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(response),
                success: function (data) {
                    $("#singleFragman").html(data);
                }
            })
        }
    })
}

function GetFragmanByName(name) {
    if (name == "") {
        GetFragmanListAll("GetMovieList")
    } else {
        $.ajax({
            type: "GET",
            url: apiurl + "fragman/GetByName?name=" + name,
            headers: { "ApiKey": apikey },
            success: function (response) {                
                $.ajax({
                    type: "Post",
                    url: "GetMovieList",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(response),
                    success: function (data) {                        
                        $("#singleFragman").html(data);
                    }
                })
            }
        })
    }
}

function SwiperScript() {


    // SLIDER
    var interleaveOffset = 0.5;
    var swiperOptions = {
        loop: true,
        speed: 500,
        parallax: true,
        autoplay: {
            delay: 5000,
            disableOnInteraction: false,
        },
        grabCursor: true,
        watchSlidesProgress: true,
        pagination: {
            el: '.swiper-pagination',
            clickable: true,
            renderBullet: function (index, className) {
                return '<span class="' + className + '"><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 30 30"><circle r="13" cy="15" cx="15"></circle></svg></span>';
            },
        },
        on: {
            progress: function () {
                var swiper = this;
                for (var i = 0; i < swiper.slides.length; i++) {
                    var slideProgress = swiper.slides[i].progress;
                    var innerOffset = swiper.width * interleaveOffset;
                    var innerTranslate = slideProgress * innerOffset;
                    swiper.slides[i].querySelector(".slide-inner").style.transform =
                        "translate3d(" + innerTranslate + "px, 0, 0)";
                }
            },
            touchStart: function () {
                var swiper = this;
                for (var i = 0; i < swiper.slides.length; i++) {
                    swiper.slides[i].style.transition = "";
                }
            },
            setTransition: function (speed) {
                var swiper = this;
                for (var i = 0; i < swiper.slides.length; i++) {
                    swiper.slides[i].style.transition = speed + "ms";
                    swiper.slides[i].querySelector(".slide-inner").style.transition =
                        speed + "ms";
                }
            }
        }
    };

    var swiper = new Swiper(".main-slider", swiperOptions);
} (jQuery)