using CommentManagement.Application;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastracture.EfCore;
using CommentManagement.Infrastracture.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CommentManagement.Infrastracture.Config
{
    public class CommentManagementBootstrapper
    {
        public static void Configure(IServiceCollection Service, string ConnectionString)
        {
            Service.AddTransient<ICommentApplication, CommentAppplication>();
            Service.AddTransient<ICommentRepository, CommentRepository>();

            Service.AddDbContext<CommentContext>(x => x.UseSqlServer(ConnectionString));
        }
    }
}
