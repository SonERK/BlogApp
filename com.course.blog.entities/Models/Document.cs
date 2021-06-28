using System;
using System.ComponentModel.DataAnnotations;

namespace com.course.blog.entities.Models
{
    public class Document : BaseEntity
    {
        [Key]
        public Guid DocumentId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Path { get; set; }
        [MaxLength(250)]
        public string ShortDetail { get; set; }
        public Guid? ArticleId { get; set; }
        public Guid UserId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
