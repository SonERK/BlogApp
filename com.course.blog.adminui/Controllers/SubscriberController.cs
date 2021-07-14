using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.adminui.Controllers
{
    public class SubscriberController : BaseController
    {
        public IActionResult SubscriberProcess()
        {
            return View();
        }

        public ActionResult Subscribers()
        {
            return View();
        }
    }
}
