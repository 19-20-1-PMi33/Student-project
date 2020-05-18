using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_project.Repository;
using Student_project.Form;
using Student_project.Model;

namespace Student_project.Controllers
{
    public class LoginController : Controller
    {
        CDBContext db = new CDBContext();
        [AllowAnonymous]
        public IActionResult Index()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginIntoSite(AuthenticationModel user)
        {
            if (ModelState.IsValid)
            {
                Students student = await db.Students.FirstOrDefaultAsync(u => u.ID == user.Login && u.Password == user.Password);
                if (student != null)
                {
                    await Authenticate(user.Login,"Student"); 

                    return RedirectToAction("Index", "Home");
                }
                Admin admin = await db.Admins.FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);
                if (admin != null)
                {
                    await Authenticate(user.Login, "Admin"); 

                    return RedirectToAction("Index", "Admin");
                }
                Teachers teacher = await db.Teachers.FirstOrDefaultAsync(u => u.Email == user.Login && u.Password == user.Password);
                if (teacher != null)
                {
                    await Authenticate(user.Login, "Teacher");

                    return RedirectToAction("Index", "Teacher");
                }
                ModelState.AddModelError(string.Empty, "Невірний логін чи пароль");
            }
            return View("Index");
        }
        private async Task Authenticate(string userName, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}