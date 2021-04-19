function GetLastThirdMovie() {
    $.ajax({
        type: "get",
        async: false,
        url: "../../../ajax/GetThird",
        success: function (response) {
            $("#thirdMovie").html(response)
        }
    })
}

function GetFragmanListAll() {
    $.ajax({
        type: "get",
        url: "../../../ajax/GetAllFragman",
        success: function (response) {
            $("#singleFragman").html(response)
        }
    })
}

function GetMovieByCId(id) {
    $.ajax({
        type: "get",
        url: "../../../ajax/GetFragmansByCId?id=" + id,
        success: function (response) {
            $("#singleFragman").html(response);
        }
    })
}

function GetFragmanByName(name) {
    if (name == "") {
        GetFragmanListAll()
    } else {
        $.ajax({
            type: "get",
            url: "../../../ajax/GetFragmansByName?name=" + name,
            success: function (response) {
                $("#singleFragman").html(response);
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
        url: "../../../ajax/AddRating?fid=" + frag + "&uid=" + user,        
        success: function (response) {
            if (!response.check) {
                alertify.error(response.message)
            }
        }
    })
}

function GetBtnMyList(path) {
    $.ajax({
        type: "Get",
        url: path,
        success: function (response) {
            $("#btnMyList").html(response)
            btnScript()
        }
    })
}
function btnScript() {
    $('#myList').click(function () {
        $("#myListItem").toggle();
    });
}

function DeleteFromList(id) {
    $.ajax({
        type: "Get",
        url: "../../../mylist/Delete?id=" + id,
        success: function (response) {
            GetBtnMyList("../../../mylist/getbtn")
            alertify.success("Film izlenecekler listesinden kaldırıldı.")
        }
    })
}