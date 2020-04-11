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
        [ActionName("Login")]
        public IActionResult LoginIntoSite(Student_project.Model.Students student)
        {
            var _student = db.Students.Find(student.ID);
            if (_student == null || _student.Password != student.Password)
            {
                ModelState.AddModelError("Password", "Невірний номер заліковки чи пароль");
                //HttpContext.Response.Cookies.Append("userID", UserName);
                //return Redirect("/Home/Index");
            }
            if (ModelState.IsValid)
            {
                HttpContext.Response.Cookies.Append("userID", student.ID);
                return RedirectToAction("Index", "Home");
            }
            //else
            //{
            //    return Content($"Невірний логін чи пароль");
            //}
            return View("Index");
        }
    }
}