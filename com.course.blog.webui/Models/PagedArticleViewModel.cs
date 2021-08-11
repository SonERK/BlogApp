using com.course.blog.entities.Models;
using X.PagedList;

namespace com.course.blog.webui.Models
{
    public class PagedArticleViewModel
    {
        public int? Page { get; set; }
        public IPagedList<Article> Articles { get; set; }
    }
}
