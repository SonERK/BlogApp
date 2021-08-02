using com.course.blog.adminui.Models;
using com.course.blog.entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace com.course.blog.adminui.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly DbBlog _context;
        public CategoryController(DbBlog context)
        {
            _context = context;
        }

        public IActionResult CategoryProcess()
        {
            return View();
        }

        public IActionResult Categories(CategoryViewModel model)
        {
            model.Categories = _context.Categories.ToPagedList(model.Page ?? 1, 20);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("CategoryPartial", model);
            }
            else
            {
                ViewBag.Categories = model;
                return View(model);
            }

        }

        [HttpPost]
        public JsonResult SaveCategory(string categoryName)
        {
            if (!_context.Categories.Any(c => c.Detail == categoryName))
            {
                var category = new Category
                {
                    Detail = categoryName,
                    SaveDate=DateTime.Now,
                    IsActive = true
                };

                _context.Categories.Add(category);

                return Json(_context.SaveChanges() > 0);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
