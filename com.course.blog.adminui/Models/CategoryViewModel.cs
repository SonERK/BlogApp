using com.course.blog.entities.Models;
using X.PagedList;

namespace com.course.blog.adminui.Models
{
    public class CategoryViewModel
    {
        public int? Page { get; set; }
        public IPagedList<Category> Categories { get; set; }
    }
}
