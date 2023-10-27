using BlogManagement.Application;
using BlogManagement.Application.Contract.Article;
using BlogManagement.Application.Contract.ArticleCategory;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastracture.EfCore;
using BlogManagement.Infrastracture.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlogManagement.Infrastracture.Config
{
    public class BlogManagementBootstrapper
    {
        public static void Configure(IServiceCollection service,string ConnectionString)
        {
            service.AddTransient<IArticleCategoryApplication ,ArticleCategoryApplication>();
            service.AddTransient<IArticleCategoryRepository ,ArticleCategoryRepository>();
            service.AddTransient<IArticleApplication ,ArticleApplication>();
            service.AddTransient<IArticleRepository ,ArticleRepository>();
            

            service.AddDbContext<BlogContext>(x => x.UseSqlServer(ConnectionString));
        }
    }
}
