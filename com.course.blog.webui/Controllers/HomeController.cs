using com.course.blog.entities.Models;
using com.course.blog.webui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace com.course.blog.webui.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbBlog _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DbBlog context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index(PagedArticleViewModel model)
        {
            model.Articles = _context.Articles.Where(a => a.IsActive && a.SubCategory.CategoryId == 1).ToPagedList(model.Page ?? 1, 3);

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

        public IActionResult ContentPage(Guid? id)
        {
            if (id == Guid.Empty || _context.Articles.Any(a => a.ArticleId == id && !a.IsActive))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.PopularPosts = _context.Articles.Where(a => a.IsActive).Take(4).OrderByDescending(o => o.ReadCount).Select(s => new ArticleViewModel
            {
                ArticleId = s.ArticleId,
                Subject = s.Subject,
                SaveDate = s.SaveDate,
            }).ToList();

            ViewBag.SubCategories = _context.SubCategories.Where(s => s.IsActive).Take(4).Select(s => new SubCategoryViewModel
            {
                SubCategoryId = s.SubCategoryId,
                SubCategoryName = s.Detail,
                Count = s.Articles.Count
            }).ToList();

            var articles = _context.Articles.Where(a => a.ArticleId == id && a.IsActive).ToList().Select(s => new ArticleViewModel
            {
                ArticleId = s.ArticleId,
                Subject = s.Subject,
                SubCategory = s.SubCategory.Detail,
                Tags = s.Tags.Split(' ').ToList(),
                FullName = s.User.FullName,
                Biography = s.User.Biography,
                SaveDate = s.SaveDate,
                Detail = s.Detail
            }).First();


            return View(articles);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult Subscribe(Subscriber subscriber)
        {
            if (!_context.Subscribers.Any(s => s.MailAddress == subscriber.MailAddress))
            {
                subscriber.SubscriberId = Guid.NewGuid();
                subscriber.SaveDate = DateTime.Now;
                subscriber.IsActive = true;

                _context.Subscribers.Add(subscriber);

                return Json(_context.SaveChanges());
            }
            else
            {
                return Json(false);
            }
        }
    }
}
