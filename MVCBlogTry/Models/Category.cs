using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlogTry.Models
{
    public class Category
    {
        public Category()
        {
            this.Article_Category = new HashSet<Article_Category>();

        }
        [Key]
        [Display(Name="Id kategori : ")]
        public int Id { get; set; }

        [Display(Name = "Nazwa kategori : ")]
        [Required]
        public string Category_Name{ get; set; }

        [Display(Name = "Id rodzica : ")]
        public int ParentId { get; set; }

        #region SEO

        [Display(Name = "Tytuł google : ")]
        [MaxLength(72)]
        public string MetaTitle { get; set; }

        [Display(Name = "Opis google : ")]
        [MaxLength(160)]
        public string MetaDescription { get; set; }

        [Display(Name ="Słowa kluczowe google : ")]
        [MaxLength(160)]
        public string MetaKeywords { get; set; }

        [Display(Name = "Treść strony : ")]
        [MaxLength(500)]
        public string SiteContent { get; set; }

        public ICollection<Article_Category> Article_Category { get; set; }


        #endregion

    }
}