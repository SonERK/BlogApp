using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.course.blog.entities.Models
{
    public class Subscriber : BaseEntity
    {
        [Key]
        public Guid SubscriberId { get; set; }
        public string MailAddress { get; set; }
        public string FullName { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
