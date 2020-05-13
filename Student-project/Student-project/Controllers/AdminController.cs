using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Student_project.Repository;

namespace Student_project.Controllers
{
    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        CDBContext db = new CDBContext();
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
            return View();
        }
    }
}