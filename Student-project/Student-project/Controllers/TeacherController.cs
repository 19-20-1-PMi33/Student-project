using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Student_project.Controllers
{
    [Authorize(Policy = "Teacher")]
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}