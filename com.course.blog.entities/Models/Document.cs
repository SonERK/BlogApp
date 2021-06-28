using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.course.blog.entities.Models
{
    public class Document : BaseEntity
    {
        [Key]
        public Guid DocumentId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ShortDetail { get; set; }
        public Guid? ArticleId { get; set; }
        public Guid UserId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
