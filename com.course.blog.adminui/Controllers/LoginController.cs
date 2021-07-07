using com.course.blog.adminui.Helpers;
using com.course.blog.entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.adminui.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbBlog _context;
        public LoginController(DbBlog context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateSession(string userName, string password)
        {
            var encryptedPassword = password.CreateMD5();

            if (_context.Users.Any(a => a.UserName == userName && a.Password == encryptedPassword))
            {
                var user = _context.Users.First(u => u.UserName == userName && u.Password == encryptedPassword);

                HttpContext.Session.Set<User>("User", user);

                return Json(new { status=true,url="/Admin/Index"});
            }
            else
            {
                return Json(new { status = false });
            }
        }
    }
}
