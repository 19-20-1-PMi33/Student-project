using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
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
            string user = HttpContext.Request.Cookies["UserID"];
            var student = db.Students.Where(x => x.ID == user)
                .Include(x => x.Groups)
                .Include(x=>x.Groups.Departments)
                .First();

            return View(student);
        }
        public IActionResult Marks()
        {
            var student = db.Students.FindAsync(HttpContext.Request.Cookies["UserID"]).Result;
            ViewBag.StudentName = $"{student.LastName} {student.FirstName} {student.MiddleName}";
            var marks = db.Marks.Where(x=>x.StudentId == student.ID)
                .Include(x=>x.Exams.Subjects)
                .Include(x=>x.Exams.Teachers)
                .ToList();

            return View(marks);
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
