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
        public ActionResult LoginIntoSite(string UserName, string Password)
        {
            if(db.Students.Find(UserName) != null && Password == UserName)
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return Content($"Невірний логін чи пароль");
            }
        }
    }
}