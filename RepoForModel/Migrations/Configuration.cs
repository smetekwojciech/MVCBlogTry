namespace RepoForModel.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RepoForModel.Models.MVCBlogTryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RepoForModel.Models.MVCBlogTryContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
            SeedArticles(context);
            SeedCategories(context);
            SeedArticle_Category(context);


        }

        private void SeedRoles(MVCBlogTryContext context)
        {
            var RoleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());

            if (!RoleManager.RoleExists("Admin"))
            {
                var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                Role.Name = "Admin";
                RoleManager.Create(Role);
            }
        }

        private void SeedUsers(MVCBlogTryContext context)
        {
            var Store = new UserStore<User>(context);
            var Manager = new UserManager<User>(Store);



            if (!context.Users.Any(u=>u.UserName=="Admin"))
            {
                var User = new User { UserName = "Admin" };
                var AdminResult = Manager.Create(User, "12345678");
                if (AdminResult.Succeeded)
                {
                    Manager.AddToRole(User.Id, "Admin");
                }
            }
        }
        private void SeedArticles(MVCBlogTryContext context)
        {
            var idUser = context.Set<User>().Where(u => u.UserName == "Admin").FirstOrDefault().Id;
            for (int i = 1; i < 10; i++)
            {
                var article = new Article()
                {
                    Id = i,
                    UserId = idUser,
                    Text = "Text of Article " + i.ToString(),
                    Title = "Title " + i.ToString(),
                    DateAdded = DateTime.Now.AddDays(-i)

                };

                context.Set<Article>().AddOrUpdate(article);
            }
            context.SaveChanges();
        }

        private void SeedCategories(MVCBlogTryContext context)
        {
            for (int i = 1; i < 10; i++)
            {
                var category = new Category()
                {
                    Id = i,
                    Category_Name = "Category Name " + i.ToString(),
                    SiteContent = "Text of Article " + i.ToString(),
                    MetaTitle = "Title of Catgory " + i.ToString(),
                    MetaDescription = "Category Description " + i.ToString(),
                    MetaKeywords = "Keywords for category number " + i.ToString(),
                    ParentId = i

                };

                context.Set<Category>().AddOrUpdate(category);
            }
            context.SaveChanges();
        }

        private void SeedArticle_Category(MVCBlogTryContext context)
        {
            for (int i = 1; i < 10; i++)
            {
                var artcategory = new Article_Category()
                {
                    Id = i,
                    ArticleId = i / 2 + 1,
                    CategoryId = i / 2 + 2   
                };
                context.Set<Article_Category>().AddOrUpdate(artcategory);
            }
            context.SaveChanges();


        }
    }
}
