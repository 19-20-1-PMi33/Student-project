using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            var students = db.Students
                .Include(x => x.Groups)
                .Include(x => x.Groups.Departments)
                .Include(x => x.Groups.Departments.Faculties)
                .ToList();
            return View(students);
        }
        public IActionResult Teacher()
        {
            var teachers = db.Teachers
                .Include(x => x.Departments)
                .Include(x => x.Departments.Faculties)
                .ToList();
            return View(teachers);
        }
        public IActionResult AcGroup()
        {
            var exams = db.Exams
                .Include(x => x.Groups)
                .Include(x => x.Teachers)
                .Include(x => x.Groups.Departments)
                .Include(x => x.Groups.Departments.Faculties)
                .Include(x => x.Subjects)
                .ToList();
            return View(exams);
        }
        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public IActionResult GetGroupsByFaculty(string faculty)
        {
            var model = db.Groups.Where(x => x.Departments.Faculty == faculty).ToList();

            return PartialView("GroupPartial", model);
        }
        [HttpGet]
        public IActionResult GetStudentsByGroup(string group)
        {
            try
            {
                var model = db.Students.Where(x => x.Group == group).ToList();


                return PartialView("StudentPartial", model);
            }
            catch(ArgumentException ex)
            {
                _logger.LogError(ex.Message);

                return PartialView("StudentPartial", db.Students.ToList());
            }
        }
        [HttpPost]
        public IActionResult AddStudent()
        {
            var fullname = Request.Form["FullNameAdd"].ToString();
            var studentId = Request.Form["StudentIdAdd"].ToString();
            var group = Request.Form["GroupAdd"].ToString();
            var spec = Request.Form["SpecAdd"].ToString();
            var fullnamesplit = fullname.Trim().Replace("  ", " ").Split(" ");
            var student = new Students
            {
                LastName = fullnamesplit[0],
                FirstName = fullnamesplit[1],
                MiddleName = fullnamesplit[2],
                ID = studentId,
                Group = group,
                Specialty = spec,
                Password = studentId
            };
            db.Students.Add(student);
            db.SaveChanges();

            return View("Student",db.Students.ToList());
        }
        [HttpPost]
        public IActionResult DeleteStudent()
        {
            var studentId = Request.Form["StudentIdDelete"].ToString();
            foreach (var item in db.Marks.Where(x=>x.Students.ID == studentId))
            {
                db.Marks.Remove(item);
            }
            var student = db.Students.Find(studentId);
            db.Students.Remove(student);
            db.SaveChanges();
            return View("Student", db.Students.ToList());
        }
    }
}