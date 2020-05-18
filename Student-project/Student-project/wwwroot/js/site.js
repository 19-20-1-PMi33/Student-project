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
    getGroupsByFacultyAdd1(faculty);
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
var getGroupsByFacultyAdd1 = function (faculty) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetGroupsByFaculty",
        data: 'faculty=' + faculty,
        success: function (data) {
            $("select[id=GroupSelectDelete]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};
$("#FacultySelectAdd").change(function () {
    let faculty = document.getElementById("FacultySelectAdd").value;
    getDepartmentsByFacultyDelete1(faculty);
    getGroupsByFacultyAdd2(faculty);
    $("select[id=fullNameSelectAdd]").html("");
});

$("#DepartmentSelectAdd").change(function () {
    let department = document.getElementById("DepartmentSelectAdd").value;
    getTeacherByDepartmentDelete1(department);
    $("select[id=fullNameSelectAdd]").html("");
});

var getDepartmentsByFacultyDelete1 = function (faculty) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetDepartmentsByFaculty",
        data: 'faculty=' + faculty,
        success: function (data) {
            $("select[id=DepartmentSelectAdd]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};
var getTeacherByDepartmentDelete1 = function (department) {
    $.ajax({
        type: "GET",
        url: "/Admin/GetTeachersByDepartment",
        data: 'department=' + department,
        success: function (data) {
            $("select[id=fullNameSelectAdd]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};
var getGroupsByFacultyAdd2 = function (faculty) {
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
$("#add-student-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Admin/AddStudent",
        data: $("#add-student-form").serialize(),
        success: function () {
            toastr.success('Студент доданий успішно.', 'Успіх', { timeOut: 3000 });
        },
        error: function (data) {
            if (data.status === 422) {
                toastr.error('Студент вже існує з таким номером заліковки', 'Помилка', { timeOut: 3000 });
            } else {
            toastr.error('Перевірте правильність заповнення полів.', 'Помилка', { timeOut: 3000 });
            }
        }
    });
});
$("#delete-student-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Admin/DeleteStudent",
        data: $("#delete-student-form").serialize(),
        success: function () {
            toastr.success('Студент видалений успішно.', 'Успіх', { timeOut: 3000 });
        },
        error: function () {
            toastr.error('Перевірте правильність заповнення полів.', 'Помилка', { timeOut: 3000 });
        }
    });
});
$("#add-teacher-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Admin/AddTeacher",
        data: $("#add-teacher-form").serialize(),
        success: function () {
            toastr.success('Викладач доданий успішно.', 'Успіх', { timeOut: 3000 });
        },
        error: function (data) {
            if (data.status === 422) {
                toastr.error('Такий викладач вже існує', 'Помилка', { timeOut: 3000 });
            } else {
                toastr.error('Перевірте правильність заповнення полів.', 'Помилка', { timeOut: 3000 });
            }
        }
    });
});
$("#delete-teacher-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Admin/DeleteTeacher",
        data: $("#delete-teacher-form").serialize(),
        success: function () {
            toastr.success('Викладач видалений успішно.', 'Успіх', { timeOut: 3000 });
        },
        error: function () {
            toastr.error('Перевірте правильність заповнення полів.', 'Помилка', { timeOut: 3000 });
        }
    });
});
$("#add-group-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Admin/AddGroup",
        data: $("#add-group-form").serialize(),
        success: function () {
            toastr.success('Академічна група додана успішно.', 'Успіх', { timeOut: 3000 });
        },
        error: function (data) {
            if (data.status === 422) {
                toastr.error('Вже існує така академічна група', 'Помилка', { timeOut: 3000 });
            } else {
                toastr.error('Перевірте правильність заповнення полів.', 'Помилка', { timeOut: 3000 });
            }
        }
    });
});
$("#delete-group-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Admin/DeleteGroup",
        data: $("#delete-group-form").serialize(),
        success: function () {
            toastr.success('Академічна група видалена успішно.', 'Успіх', { timeOut: 3000 });
        },
        error: function () {
            toastr.error('Перевірте правильність заповнення полів.', 'Помилка', { timeOut: 3000 });
        }
    });
});

$("#TeacherSubject").change(function () {
    let subject = document.getElementById("TeacherSubject").value;
    getGroupsBySubjectTeacher(subject);
    $("select[id=fullNameSelectTeacher]").html("");
});

$("#GroupSelectTeacher").change(function () {
    let group = document.getElementById("GroupSelectTeacher").value;
    getStudentsByGroupTeacher(group);
});

var getGroupsBySubjectTeacher = function (subject) {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetGroupsBySubjectTeacher",
        data: 'subject=' + subject,
        success: function (data) {
            $("select[id=GroupSelectTeacher]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};
var getStudentsByGroupTeacher = function (group) {
    $.ajax({
        type: "GET",
        url: "/Teacher/GetStudentsByGroupTeacher",
        data: 'group=' + group,
        success: function (data) {
            $("select[id=fullNameSelectTeacher]").html(data);
        },
        error: function (data) {
            console.log(data);
        }
    });
};
$("#add-mark-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Teacher/AddMark",
        data: $("#add-mark-form").serialize(),
        success: function () {
            toastr.success('Оцінка додана успішно.', 'Успіх', { timeOut: 3000 });
        },
        error: function () {
            toastr.error('Перевірте правильність заповнення полів.', 'Помилка', { timeOut: 3000 });
        }
    });
});
$("#change-password-form").submit(function (e) {
    e.preventDefault();
    $.ajax({
        type: "POST",
        url: "/Teacher/ChangePass",
        data: $("#change-password-form").serialize(),
        success: function () {
            toastr.success('Пароль успішно змінений.', 'Успіх', { timeOut: 3000 });
        },
        error: function () {
            toastr.error('Перевірте правильність заповнення полів.', 'Помилка', { timeOut: 3000 });
        }
    });
});