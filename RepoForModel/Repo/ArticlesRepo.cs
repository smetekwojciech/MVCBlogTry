using RepoForModel.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RepoForModel.Repo
{
    public class ArticlesRepo
    {
        private MVCBlogTryContext db = new MVCBlogTryContext();
        public IQueryable<Article> GetArticles()
        {
            db.Database.Log = message => Trace.WriteLine(message);
            return db.Articles.AsNoTracking();
        }
    }
}