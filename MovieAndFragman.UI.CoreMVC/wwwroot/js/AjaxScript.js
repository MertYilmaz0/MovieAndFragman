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

function GetRating(id) {
    $.ajax({
        type: "GET",
        url: "../GetRating?id=" + id,
        success: function (response) {
            $("#rating").html(response)
        }
    })
}

function AddRating(frag, user) {
    $.ajax({
        type: "Get",
        url: apiurl + "fragman/AddRating?fid=" + frag + "&uid=" + user,
        headers: { "ApiKey": apikey },
        success: function (response) {
            if (!response.check) {
                alertify.error(response.message)
            }
        }
    })
}