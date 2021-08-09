using com.course.blog.entities.Models;
using X.PagedList;

namespace com.course.blog.adminui.Models
{
    public class ArticleViewModel
    {
        public int? Page { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public IPagedList<Article> Articles { get; set; }
    }
}
