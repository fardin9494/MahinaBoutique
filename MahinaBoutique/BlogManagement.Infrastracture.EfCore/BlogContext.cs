using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastracture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogManagement.Infrastracture.EfCore
{
    public class BlogContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public BlogContext(DbContextOptions<BlogContext> option) : base (option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var asembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(asembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
