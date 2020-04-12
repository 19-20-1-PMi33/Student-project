using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_project.Repository;


namespace Student_project.Controllers
{
    public class LoginController : Controller
    {
        CDBContext db = new CDBContext();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginIntoSite(Student_project.Model.Students student)
        {
            var _student = db.Students.FindAsync(student.ID).Result;
            if (_student == null || _student.Password != student.Password)
            {
                ModelState.AddModelError("Password", "Невірний номер заліковки чи пароль");
            }
            if (ModelState.IsValid)
            {
                HttpContext.Response.Cookies.Append("userID", student.ID);
                return RedirectToAction("Index", "Home");
            }
            return View("Index");
        }
    }
}