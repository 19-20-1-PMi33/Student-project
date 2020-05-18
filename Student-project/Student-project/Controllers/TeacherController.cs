using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_project.Model;
using Student_project.Repository;

namespace Student_project.Controllers
{
    [Authorize(Policy = "Teacher")]
    public class TeacherController : Controller
    {
        CDBContext db = new CDBContext();
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
        public IActionResult Mark()
        {
            return View();
        }
        public async Task<IActionResult> Exit()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}