using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCBlogTry.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        #region additionalnotmapped
        [NotMapped]
        [Display(Name="Pan/Pani :")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

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
    }
}