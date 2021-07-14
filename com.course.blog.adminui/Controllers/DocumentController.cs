using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.adminui.Controllers
{
    public class DocumentController : BaseController
    {
        public IActionResult DocumentProcess()
        {
            return View();
        }

        public ActionResult Documents()
        {
            return View();
        }
    }
}
