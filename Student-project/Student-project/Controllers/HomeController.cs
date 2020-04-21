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
            string user = HttpContext.Request.Cookies["UserID"];
            var marks = db.Marks.Where(x=>x.StudentId == user)
                .Include(x=>x.Exams.Subjects)
                .Include(x=>x.Exams.Teachers)
                .Include(x=>x.Students)
                .ToList();

            return View(marks);
        }

        public IActionResult Statistics()
        {
            string user = HttpContext.Request.Cookies["UserID"];
            var student = db.Students.Find(user);
            double groupMark = db.Marks.Where(x => x.Students.Group == student.Group).Sum(x => x.Mark) / db.Marks.Count(x => x.Students.Group == student.Group);
            ViewBag.GroupMark = groupMark;
            var studentsMark = db.Marks.Where(x => x.StudentId == user)
                .Include(x => x.Students)
                .ToList();

            return View(studentsMark);
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
