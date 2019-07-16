using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Austins_Blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int BlogPostId { get; set;}
        public string AustinId { get; set; } 
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updaed { get; set; }
        public string UpdateReason { get; set; }

        //virtual navigation section
        public virtual BlogPost BlogPost { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}