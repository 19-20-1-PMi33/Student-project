using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student_project.Model;
using Student_project.Repository;

namespace Student_project.Controllers
{
    [Authorize(Policy = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> _logger;
        CDBContext db = new CDBContext();

        public TeacherController(ILogger<TeacherController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Course()
        {
            var id = Convert.ToInt32(User.Identity.Name);
            var teacher = db.Teachers.Find(id);
            ViewData["FullName"] = $"{teacher.LastName} {teacher.FirstName[0]}.{teacher.MiddleName[0]}.";
            var courseforteachers = db.Exams.Where(x => x.Teacher == id)
                .OrderByDescending(x => x.Year)
                .ThenBy(x => x.Subject)
                .ThenBy(x => x.GroupName)
                .ToList();
            return View(courseforteachers);
        }
        public IActionResult PasswordChange()
        {
            return View();
        }
        public IActionResult Mark()
        {
            var id = Convert.ToInt32(User.Identity.Name);
            ViewData["TeacherID"] = id;
            return View();
        }
        public async Task<IActionResult> ChangePass()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var oldPass = Request.Form["oldpass"].ToString();
                    var newPass = Request.Form["newpass"].ToString();
                    var repOldPass = Request.Form["rep_newpass"].ToString();
                    var teacherId = Convert.ToInt32(User.Identity.Name);

                    var teacher = await db.Teachers.FindAsync(teacherId);

                    if(teacher.Password == oldPass && newPass == repOldPass)
                    {
                        teacher.Password = newPass;
                        db.SaveChanges();
                    }
                    else
                    {
                        return UnprocessableEntity();
                    }

                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetGroupsBySubjectTeacher(string subject)
        {
            try
            {
                var teacherId = Convert.ToInt32(User.Identity.Name);
                var teacher = await db.Teachers.FindAsync(teacherId);

                var model = db.Exams
                    .Where(x => x.Groups.Departments.Faculty == teacher.Departments.Faculty && x.Subject == subject && x.Teacher == teacherId).ToList();

                return PartialView("GroupPartial", model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return PartialView("GroupPartial", db.Exams.Select(x=>x.GroupName).Distinct().ToList());
            }
        }
        [HttpGet]
        public IActionResult GetStudentsByGroupTeacher(string group)
        {
            try
            {
                var model = db.Students.Where(x => x.Group == group).ToList();

                return PartialView("StudentPartial", model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return PartialView("StudentPartial", db.Students.ToList());
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddMark()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var mark = Convert.ToInt32(Request.Form["Mark"]);
                    if (mark > 100 || mark < 0)
                    {
                        return ValidationProblem();
                    }
                    else
                    {
                        var teacherId = Convert.ToInt32(User.Identity.Name);
                        var year = Convert.ToInt32(Request.Form["TeacherYear"].ToString());
                        var subject = Request.Form["TeacherSubject"].ToString();
                        var group = Request.Form["GroupSelectTeacher"].ToString();
                        var studentId = Request.Form["fullNameSelectTeacher"].ToString();
                        var exam = db.Exams.Where(x => x.Year == year && x.Subject == subject && x.GroupName == group && x.Teacher == teacherId).First();
                        var student = await db.Students.FindAsync(studentId);
                        var studentMark = db.Marks.Where(x => x.StudentId == student.ID && x.Exam == exam.Key).Count();
                        if (studentMark == 0)
                        {
                            var newmark = new Marks
                            {
                                StudentId = student.ID,
                                Exam = exam.Key,
                                Mark = mark
                            };
                            db.Marks.Add(newmark);
                            db.SaveChanges();
                        }
                        else
                        {
                            var editstudentMark = db.Marks.Where(x => x.StudentId == student.ID && x.Exam == exam.Key).First();
                            editstudentMark.Mark = mark;
                            db.SaveChanges();
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return NoContent();
        }
        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}