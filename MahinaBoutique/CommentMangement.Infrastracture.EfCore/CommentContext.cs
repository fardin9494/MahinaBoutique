using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastracture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastracture.EfCore
{
    public class CommentContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        public CommentContext( DbContextOptions<CommentContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
