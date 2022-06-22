$(document).ready(function () {
    getColorList();
})


var savesms = function () {
    var id = $("#hdnId").val();
    var name = $("#txtName").val();
    var mail = $("#txtMail").val();
    var color = $("#txtColor").val();
    var mobile = $("#txtMobileNo").val();


    var model = {
        Id: id, Name: name, Mail: mail, Color: color, MobileNo: mobile
    };

    if (name == "") {
        alert("Please Enter Name");
    }
    else if (mobile == "") {
        alert("Please Enter Mobile No.");
    }
    else if (mobile == "/^[0-9]{10}") {
        alert("Please valid Mobile No.");
    }
    else if (color == "") {
        alert("Please Select Category");
    }
    else {
        $.ajax({
            url: "/Color/Savesms",
            method: "post",
            data: JSON.stringify(model),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (response) {
                alert("submit successfully");

            }
        });
    }
}



var getColorList = function () {
    $.ajax({
        url: "/Color/GetColorList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (responce) {
            console.log(responce);
            var html = "";
            $("#tblColor tbody").empty();
            $.each(responce.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.Mail + "</td><td>" + elementValue.Color + "</td><td> <input type='Submit' value='Delete' onclick='dltdata(" + elementValue.Id + ")' /> </td> <td> <input type = 'submit' value='Edit' class='btn-primary' onClick='editData(" + elementValue.Id + ")'/> </td ></tr > ";
            })
            $("#tblColor tbody").append(html);
           // getColorList();
        }
    });
};


var dltdata = function (id) {
    
    var model = { Id: id };
    $.ajax({
        url: "/Color/DltColor",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully");
        }
    });
}

var editData = function (id) {

    var model = { Id: id };
    $.ajax({
        url: "/Color/GetEditData",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (responce) {
            console.log(responce);
            $("#hdnId").val(responce.model.Id);
            $("#txtName").val(responce.model.Name);
            $("#txtMail").val(responce.model.Mail);
            $("#txtColor").val(responce.model.Color);
        }
    });
}

var ClearData = function () {
    $("#hdnId").val("");
    $("#txtName").val("");
    $("#txtMail").val("");
    $("#txtColor").val("");
}