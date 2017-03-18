
$('#department_dropworn').change(function () {
    $.ajax({
        type: "GET",
        url: "../Course/Index1",
        data: { dept_id: $('DepartmentId').val() },
        datatype: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

        }
    });
});