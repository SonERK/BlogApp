using com.course.blog.adminui.Helpers;
using com.course.blog.adminui.Models;
using com.course.blog.entities.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using X.PagedList;

namespace com.course.blog.adminui.Controllers
{
    public class ArticleController : BaseController
    {
        private readonly DbBlog _context;
        private readonly IWebHostEnvironment _environment;
        public ArticleController(DbBlog context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult ArticleProcess()
        {
            ViewBag.Categories = _context.Categories.Where(c => c.IsActive).Select(s => new SelectListItem { Text = s.Detail, Value = s.CategoryId.ToString() });

            ViewBag.SubCategories = _context.SubCategories.Where(s => s.CategoryId < 0).Select(s => new SelectListItem { Text = s.Detail, Value = s.CategoryId.ToString() });

            return View();
        }

        public IActionResult Articles(ArticleViewModel model)
        {
            ViewBag.Categories = _context.Categories.Where(c => c.IsActive).Select(s => new SelectListItem { Text = s.Detail, Value = s.CategoryId.ToString() });

            ViewBag.SubCategories = _context.SubCategories.Where(c => c.IsActive && c.CategoryId == model.CategoryId).Select(s => new SelectListItem { Text = s.Detail, Value = s.SubCategoryId.ToString() });

            model.Articles = _context.Articles.Where(a => model.SubCategoryId == null || a.SubCategoryId == model.SubCategoryId).ToPagedList(model.Page ?? 1, 20);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("ArticlePartial", model);
            }
            else
            {
                ViewBag.Articles = model;
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult SaveArticle(Article article)
        {
            var user = HttpContext.Session.Get<User>("User");

            article.ArticleId = Guid.NewGuid();
            article.UserId = user.UserId;
            article.IsActive = true;
            article.SaveDate = DateTime.Now;
            article.ReadCount = 0;

            _context.Articles.Add(article);

            return Json(_context.SaveChanges() > 0);
        }

        [HttpPost]
        public JsonResult GetArticle(Guid id)
        {
            if (_context.Articles.Any(a => a.ArticleId == id))
            {
                var candidate = _context.Articles.Find(id);

                return Json(new
                {
                    articleId = candidate.ArticleId,
                    categoryId = candidate.SubCategory.CategoryId,
                    subcategoryId = candidate.SubCategoryId,
                    subject = candidate.Subject,
                    shortDetail = candidate.ShortDetail,
                    tags = candidate.Tags,
                    detail = candidate.Detail,
                });
            }
            else
            {
                return Json(null);
            }
        }

        [HttpPost]
        public JsonResult UpdateArticle(Guid id, Article article)
        {
            if (_context.Articles.Any(a => a.ArticleId == id))
            {
                var candidate = _context.Articles.Find(id);

                candidate.SubCategoryId = article.SubCategoryId;
                candidate.Subject = article.Subject;
                candidate.ShortDetail = article.ShortDetail;
                candidate.Tags = article.Tags;
                candidate.Detail = article.Detail;
                candidate.Detail = article.Detail;

                candidate.SaveDate = DateTime.Now;

                return Json(_context.SaveChanges() > 0);
            }
            else
            {
                return Json(false);
            }
        }

        [HttpPost]
        public JsonResult ChangeStatus(Guid id)
        {
            if (_context.Articles.Any(a => a.ArticleId == id))
            {
                var candidate = _context.Articles.Find(id);

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

        [HttpPost]
        public JsonResult GetSubCategories(int categoryId)
        {
            return Json(_context.SubCategories.Where(s => s.IsActive && s.CategoryId == categoryId).Select(s => new { text = s.Detail, id = s.SubCategoryId }));
        }

        [HttpPost]
        public JsonResult UploadCover(IFormFile file)
        {
            var fileType = Path.GetExtension(file.FileName);

            if (fileType == ".jpg" || fileType == ".jpeg" || fileType == ".png" || fileType == ".bmp")
            {
                var fileName = Path.ChangeExtension(Path.GetRandomFileName(), fileType);

                var filePath = $"{_environment.WebRootPath}/images/{fileName}";

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }

                var id = Guid.Parse(Request.Form["articleId"]);

                var candidate = _context.Articles.Find(id);
                candidate.CoverPhoto = fileName;

                return Json(_context.SaveChanges() > 0);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
