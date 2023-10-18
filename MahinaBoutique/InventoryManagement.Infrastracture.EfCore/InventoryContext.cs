using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryManagement.Infrastracture.EfCore
{
    public class InventoryContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> option):base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InventoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
