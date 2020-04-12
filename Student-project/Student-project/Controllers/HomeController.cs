using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Student_project.Models;
using Student_project.Repository;

namespace Student_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        CDBContext db = new CDBContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var student = db.Students.FindAsync(HttpContext.Request.Cookies["UserID"]).Result;
            var group = db.Groups.FindAsync(student.Group).Result;
            ViewBag.StudentName = $"{student.LastName} {student.FirstName} {student.MiddleName}";
            ViewBag.StudentGroup = group.GroupName;
            ViewBag.StudentSpeciality = student.Specialty;
            ViewBag.GroupDepartment = group.Department;
            ViewBag.Faculty = db.Departments.FindAsync(group.Department).Result.Faculty;
            return View();
        }
        public IActionResult Exit()
        {
            HttpContext.Response.Cookies.Delete("UserId");
            return RedirectToAction("Index", "Login");
        }   
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
