using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlogTry.Models
{
    public class Article
    {
        public Article()
        {
            this.Article_Category = new Hashset<Article_Category>();
        }

        [Key]
        [Display(Name = "Id :")]
        public int Id { get; set; }


        [Display(Name = "Tekst :")]
        [MaxLength(5000)]
        public string Text { get; set; }

        [Display(Name = "Tytuł :")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Display(Name = "Data Dodania:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateAdded { get; set; }

        public virtual ICollection<Article_Category> Article_Category { get; set; }
        public virtual User User { get; set; }
    }
}