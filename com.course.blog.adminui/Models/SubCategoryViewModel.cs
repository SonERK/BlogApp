using com.course.blog.entities.Models;
using X.PagedList;

namespace com.course.blog.adminui.Models
{
    public class SubCategoryViewModel
    {
        public int? Page { get; set; }
        public int? CategoryId { get; set; }
        public IPagedList<SubCategory> SubCategories { get; set; }
    }
}
