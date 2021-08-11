using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace com.course.blog.webui.Models
{
    public class ArticleViewModel
    {
        public Guid ArticleId { get; set; }
        public string SubCategory { get; set; }
        public string CoverPhoto { get; set; }
        public string Subject { get; set; }
        public string ShortDetail { get; set; }
        public string Detail { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
        public DateTime? SaveDate { get; set; }
        public List<string> Tags { get; set; }
    }
}
