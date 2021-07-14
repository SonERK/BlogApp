using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.adminui.Controllers
{
    public class CategoryController : BaseController
    {
        public IActionResult CategoryProcess()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }
    }
}
