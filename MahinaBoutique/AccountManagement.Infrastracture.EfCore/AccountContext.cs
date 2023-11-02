using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastracture.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;

namespace AccountManagement.Infrastracture.EfCore
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AccountContext( DbContextOptions<AccountContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
