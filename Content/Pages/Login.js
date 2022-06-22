$(document).ready(function () {
    getLogList();
})



var SaveMvcTwo = function () {
    var name = $("#txtName").val();
    var contact = $("#txtContact").val();

    var model = { Name: name, Contact: contact };

    $.ajax({
        url: "/Login/SaveLogin",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json.charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Success");
        }
    });
};

var getLogList = function () {
    $.ajax({
        url: "/Login/GetLoginList",
        method: "post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (responce) {
            console.log(responce);
            var html = "";
            $("#tblLogin tbody").empty();
            $.each(responce.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.Contact + "</td><td>  <input type='Submit' value='Delete' onclick='dltdata(" + elementValue.Id + ")' /> </td></tr>";
            });
            $("#tblLogin tbody").append(html);
            getLogList();
        }
    });
}



var dltdata = function (id) {
    var model = { Id: id };
    $.ajax({
        url: "/Login/DltLogin",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/Json;charset=utf-8",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully");
        }
    });
}