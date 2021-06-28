using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.course.blog.entities.Models
{
    public class BaseEntity
    {
        public DateTime? SaveDate { get; set; }
        public bool IsActive { get; set; }
    }
}
