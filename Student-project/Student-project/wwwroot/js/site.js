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

$("#FacultySelectAdd1").change(function () {
    let faculty = document.getElementById("FacultySelectAdd1").value;
    getDepartmentsByFacultyAdd(faculty);
});

var getDepartmentsByFacultyAdd = function (faculty) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetDepartmentsByFaculty",
        data: 'faculty=' + faculty,
        success: function (data) {
            $("select[id=DepartmentSelect]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};

$("#FacultySelectDelete").change(function () {
    let faculty = document.getElementById("FacultySelectDelete").value;
    getDepartmentsByFacultyDelete(faculty);
    $("select[id=fullNameSelect]").html("");
});

$("#DepartmentSelectDelete").change(function () {
    let department = document.getElementById("DepartmentSelectDelete").value;
    getTeacherByDepartmentDelete(department);
});

var getDepartmentsByFacultyDelete = function (faculty) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetDepartmentsByFaculty",
        data: 'faculty=' + faculty,
        success: function (data) {
            $("select[id=DepartmentSelectDelete]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};
var getTeacherByDepartmentDelete = function (department) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetTeachersByDepartment",
        data: 'department=' + department,
        success: function (data) {
            $("select[id=fullNameSelect]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};