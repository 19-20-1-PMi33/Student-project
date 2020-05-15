// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#FacultySelect").change(function () {
    let faculty = document.getElementById("FacultySelect").value;
    getGroupsByFaculty(faculty);
    $("select[id=fullNameSelect]").html("");
});

$("#GroupSelect").change(function () {
    let group = document.getElementById("GroupSelect").value;
    getStudentsByGroup(group);
});

var getGroupsByFaculty = function (faculty) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetGroupsByFaculty",
        data: 'faculty=' + faculty,
        success: function (data) {
            $("select[id=GroupSelect]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};
var getStudentsByGroup = function (group) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetStudentsByGroup",
        data: 'group=' + group,
        success: function (data) {
            $("select[id=fullNameSelect]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};

$("#FacultySelectAdd").change(function () {
    let faculty = document.getElementById("FacultySelectAdd").value;
    getGroupsByFacultyAdd(faculty);
});

var getGroupsByFacultyAdd = function (faculty) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetGroupsByFaculty",
        data: 'faculty=' + faculty,
        success: function (data) {
            $("select[id=GroupSelectAdd]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};