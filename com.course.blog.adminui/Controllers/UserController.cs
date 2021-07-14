using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.adminui.Controllers
{
    public class UserController : BaseController
    {
        public IActionResult UserProcess()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
    }
}
