var SaveMvcTwo = function () {
    var name = $("#txtName").val();
    var mail = $("#txtMail").val();
    var team = $("#txtTeam").val();
    var age = $("#txtAge").val();

    alert("hello");


    var model = {
        Name: name, Mail: mail, Team: team, Age:age
    };

    $.ajax({
        url: "/Reg/SaveReg",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            alert("Success");
        }
    }
    )
};