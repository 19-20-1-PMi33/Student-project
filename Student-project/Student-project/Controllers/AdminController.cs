using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student_project.Model;
using Student_project.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Student_project.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        CDBContext db = new CDBContext();

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Student()
        {
            return View();
        }
        public IActionResult Teacher()
        {
            return View();
        }
        public IActionResult AcGroup()
        {
            return View();
        }
        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult GetGroupsByFaculty(string faculty)
        {
            try
            {
                var model = db.Groups.Where(x => x.Departments.Faculty == faculty).ToList();

                return PartialView("GroupPartial", model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return PartialView("GroupPartial", db.Groups.ToList());
            }
        }
        [HttpGet]
        public IActionResult GetStudentsByGroup(string group)
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
        public IActionResult AddStudent()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fullname = Request.Form["FullNameAdd"].ToString();
                    var studentId = Request.Form["StudentIdAdd"].ToString();
                    var group = Request.Form["GroupAdd"].ToString();
                    var fullnamesplit = fullname.Trim().Replace("  ", " ").Split(" ");
                    if (db.Students.Find(studentId) != null)
                    {
                        return UnprocessableEntity();
                    }
                    else
                    {
                        var student = new Students
                        {
                            LastName = fullnamesplit[0],
                            FirstName = fullnamesplit[1],
                            MiddleName = fullnamesplit[2],
                            ID = studentId,
                            Group = group,
                            Password = studentId
                        };
                        db.Students.Add(student);
                        db.SaveChanges();
                    }
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return NoContent();
        }
        [HttpPost]
        public IActionResult DeleteStudent()
        {
            var studentId = Request.Form["StudentIdDelete"].ToString();
            if (studentId == string.Empty)
            {
                return UnprocessableEntity();
            }
            else if (ModelState.IsValid)
            {
                try
                {
                    var student = db.Students.Where(x => x.ID == studentId).First();
                    foreach (var item in db.Marks.Where(x => x.Students.ID == studentId))
                    {
                        db.Marks.Remove(item);
                    }
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return NoContent();
        }

        [HttpGet]
        public IActionResult GetDepartmentsByFaculty(string faculty)
        {
            try
            {
                var model = db.Departments.Where(x => x.Faculty == faculty).ToList();

                return PartialView("DepartmentPartial", model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return PartialView("DepartmentPartial", db.Departments.ToList());
            }
        }

        [HttpPost]
        public IActionResult AddTeacher()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fullname = Request.Form["FullNameAdd"].ToString();
                    var department = Request.Form["DepartmentAdd"].ToString();
                    var stupin = Request.Form["StupinAdd"].ToString();
                    var email = Request.Form["EmailAdd"].ToString();
                    var fullnamesplit = fullname.Trim().Replace("  ", " ").Split(" ");
                    var secname = fullnamesplit[0];
                    var firname = fullnamesplit[1];
                    var midname = fullnamesplit[2];
                    if (db.Teachers.Count(x => x.LastName == secname && x.FirstName == firname && x.MiddleName == midname) == 1)
                    {
                        return UnprocessableEntity();
                    }
                    else
                    {
                        var teacher = new Teachers
                        {
                            LastName = secname,
                            FirstName = firname,
                            MiddleName = midname,
                            Department = department,
                            Email = email,
                            Type = stupin,
                            Password = email
                        };
                        db.Teachers.Add(teacher);
                        db.SaveChanges();
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
        public IActionResult GetTeachersByDepartment(string department)
        {
            try
            {
                var model = db.Teachers.Where(x => x.Department == department).ToList();

                return PartialView("TeacherPartial", model);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return PartialView("TeacherPartial", db.Teachers.ToList());
            }
        }

        [HttpPost]
        public IActionResult DeleteTeacher()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tcr = Request.Form["TeacherIdDelete"].ToString();
                    var teachersId = Convert.ToInt32(tcr);
                    var teacher = db.Teachers.Where(x => x.ID == teachersId).First();
                    foreach (var item in db.Marks.Where(x => x.Exams.Teacher == teachersId))
                    {
                        db.Marks.Remove(item);
                    }
                    foreach (var item in db.Exams.Where(x => x.Teacher == teachersId))
                    {
                        db.Exams.Remove(item);
                    }
                    db.Teachers.Remove(teacher);
                    db.SaveChanges();
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddGroup()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var teacherId = Convert.ToInt32(Request.Form["TeacherIdAdd"].ToString());
                    var group = Request.Form["GroupAdd"].ToString();
                    var year = Convert.ToInt32(Request.Form["YearAdd"].ToString());
                    var subject = Request.Form["SubjectAdd"].ToString();
                    if (db.Exams.Where(x => x.Teacher == teacherId && x.GroupName == group && x.Year == year && x.Subject == subject).Count() == 1)
                    {
                        return UnprocessableEntity();
                    }
                    else
                    {
                        var acgroup = new Exams
                        {
                            Teacher = teacherId,
                            GroupName = group,
                            Year = year,
                            Subject = subject,
                        };
                        db.Exams.Add(acgroup);
                        db.SaveChanges();
                    }
                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return NoContent();
        }
        [HttpPost]
        public IActionResult DeleteGroup()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var tch = Request.Form["TeacherIdDelete"].ToString();
                    var teacherId = Convert.ToInt32(tch);
                    var group = Request.Form["GroupDelete"].ToString();
                    var year = Convert.ToInt32(Request.Form["YearDelete"].ToString());
                    var subject = Request.Form["SubjectDelete"].ToString();

                    var acgroup = db.Exams.Where(x => x.GroupName == group && x.Subject == subject && x.Teacher == teacherId && x.Year == year).First();

                    foreach (var item in db.Marks.Where(x => x.Exam == acgroup.Key))
                    {
                        db.Marks.Remove(item);
                    }

                    db.Exams.Remove(acgroup);
                    db.SaveChanges();

                }
                catch (ArgumentException ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            return NoContent();
        }
    }
}