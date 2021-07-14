using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.adminui.Controllers
{
    public class ArticleController : BaseController
    {
        public IActionResult ArticleProcess()
        {
            return View();
        }

        public ActionResult Articles()
        {
            return View();
        }
    }
}
