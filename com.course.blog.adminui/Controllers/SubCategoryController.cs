using com.course.blog.adminui.Models;
using com.course.blog.entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace com.course.blog.adminui.Controllers
{
    public class SubCategoryController : BaseController
    {
        private readonly DbBlog _context;
        public SubCategoryController(DbBlog context)
        {
            _context = context;
        }
        public IActionResult SubCategoryProcess()
        {
            ViewBag.Categories = _context.Categories.Where(c => c.IsActive).Select(s => new SelectListItem { Text = s.Detail, Value = s.CategoryId.ToString() });

            return View();
        }

        public ActionResult SubCategories(SubCategoryViewModel model)
        {
            ViewBag.Categories = _context.Categories.Where(c => c.IsActive).Select(s => new SelectListItem { Text = s.Detail, Value = s.CategoryId.ToString() });

            model.SubCategories = _context.SubCategories.Where(s => model.CategoryId == null || s.CategoryId == model.CategoryId).ToPagedList(model.Page ?? 1, 20);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("SubCategoryPartial", model);
            }
            else
            {
                ViewBag.SubCategories = model;
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult SaveSubCategory(int categoryId, string subCategoryName)
        {
            if (!_context.SubCategories.Any(c => c.Detail == subCategoryName))
            {
                var candidate = new SubCategory
                {
                    CategoryId = categoryId,
                    Detail = subCategoryName,
                    SaveDate = DateTime.Now,
                    IsActive = true
                };

                _context.SubCategories.Add(candidate);

                return Json(_context.SaveChanges() > 0);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult GetSubCategory(int id)
        {
            if (_context.SubCategories.Any(c => c.SubCategoryId == id))
            {
                var candidate = _context.SubCategories.Find(id);

                return Json(new { categoryId = candidate.CategoryId, subCategoryName = candidate.Detail });
            }
            else
            {
                return Json(null);
            }
        }

        [HttpPost]
        public JsonResult UpdateSubCategory(int id, int categoryId, string subCategoryName)
        {
            if (_context.SubCategories.Any(c => c.SubCategoryId == id))
            {
                var candidate = _context.SubCategories.Find(id);

                candidate.CategoryId = categoryId;
                candidate.Detail = subCategoryName;
                candidate.SaveDate = DateTime.Now;

                return Json(_context.SaveChanges() > 0);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            if (_context.SubCategories.Any(c => c.CategoryId == id))
            {
                var candidate = _context.SubCategories.Find(id);

                candidate.IsActive = !candidate.IsActive;
                candidate.SaveDate = DateTime.Now;

                _context.SaveChanges();

                return Json(candidate.IsActive);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
