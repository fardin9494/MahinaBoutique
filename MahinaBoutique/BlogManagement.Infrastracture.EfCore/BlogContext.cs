using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogManagement.Infrastracture.EfCore
{
    public class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }

        public BlogContext(DbContextOptions<BlogContext> option) : base (option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
