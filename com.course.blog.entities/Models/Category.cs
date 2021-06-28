using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace com.course.blog.entities.Models
{
    public class Category : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(250)]
        public string Detail { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
