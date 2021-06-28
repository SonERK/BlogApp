using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace com.course.blog.entities.Models
{
    public class Article : BaseEntity
    {
        [Key]
        public Guid ArticleId { get; set; }
        public int SubCategoryId { get; set; }
        public Guid UserId { get; set; }
        [MaxLength(250)]
        public string Subject { get; set; }
        [MaxLength(500)]
        public string ShortDetail { get; set; }
        public string Detail { get; set; }
        public int ReadCount { get; set; }
        [MaxLength(100)]
        public string CoverPhoto { get; set; }
        [MaxLength(250)]
        public string Tags { get; set; }

        public virtual User User { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
