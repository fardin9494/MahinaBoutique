using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastracture.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace DiscountManagement.Infrastracture.EFCore
{
    public class DiscountContext:DbContext
    {
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }

        public DiscountContext(DbContextOptions<DiscountContext> option):base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
