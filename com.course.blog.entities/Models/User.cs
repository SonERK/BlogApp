using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace com.course.blog.entities.Models
{
    public class User: BaseEntity
    {
        [Key]
        public Guid UserId { get; set; }
        [MaxLength(150)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string UserName { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string PictureUrl { get; set; }
        [MaxLength(500)]
        public string Biography { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
