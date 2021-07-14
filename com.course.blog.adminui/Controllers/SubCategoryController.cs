using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.adminui.Controllers
{
    public class SubCategoryController : BaseController
    {
        public IActionResult SubCategoryProcess()
        {
            return View();
        }

        public ActionResult SubCategories()
        {
            return View();
        }
    }
}
