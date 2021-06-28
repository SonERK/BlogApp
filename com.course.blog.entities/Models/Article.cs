using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.course.blog.entities.Models
{
    public class Article : BaseEntity
    {
        [Key]
        public Guid ArticleId { get; set; }
        public int SubCategoryId { get; set; }
        public Guid UserId { get; set; }
        public string Subject { get; set; }
        public string ShortDetail { get; set; }
        public string Detail { get; set; }
        public int ReadCount { get; set; }
        public string CoverPhoto { get; set; }
        public string Tags { get; set; }

        public virtual User User { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
