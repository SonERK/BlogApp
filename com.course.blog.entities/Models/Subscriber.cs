using System;
using System.ComponentModel.DataAnnotations;

namespace com.course.blog.entities.Models
{
    public class Subscriber : BaseEntity
    {
        [Key]
        public Guid SubscriberId { get; set; }
        [MaxLength(250)]
        public string MailAddress { get; set; }
        [MaxLength(150)]
        public string FullName { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
