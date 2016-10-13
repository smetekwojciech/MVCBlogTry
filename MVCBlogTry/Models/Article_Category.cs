using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlogTry.Models
{
    public class Article_Category
    {
        public Article_Category()
        {

        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ArticleId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Article Article { get; set; }

    }
}