using com.course.blog.adminui.Helpers;
using com.course.blog.entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.adminui.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.FullName = HttpContext.Session.Get<User>("User").FullName;
            return View();
        }
    }
}
