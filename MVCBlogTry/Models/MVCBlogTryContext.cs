using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCBlogTry.Models
{
    

    public class MVCBlogTryContext : IdentityDbContext
    {
        public MVCBlogTryContext()
            : base("DefaultConnection")
        {
        }

        public static MVCBlogTryContext Create()
        {
            return new MVCBlogTryContext();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> SetOfUsers { get; set; }
        public DbSet<Article_Category> Article_Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<Article>().HasRequired(x => x.User).WithMany(x => x.Articles).HasForeignKey(x => x.UserId).WillCascadeOnDelete(true);
           
        }
    }
}