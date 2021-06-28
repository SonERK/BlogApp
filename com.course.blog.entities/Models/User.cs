using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.course.blog.entities.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }    
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PictureUrl { get; set; }
        public string Biography { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
