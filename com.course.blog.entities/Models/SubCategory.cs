using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace com.course.blog.entities.Models
{
    public class SubCategory : BaseEntity
    {
        [Key]
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(250)]
        public string Detail { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
