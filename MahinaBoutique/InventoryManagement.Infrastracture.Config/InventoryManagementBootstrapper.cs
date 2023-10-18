using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastracture.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryManagement.Infrastracture.Config
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection service,string connectionstring)
        {
            service.AddTransient<IInventoryRepository, InventoryRepository>();

            service.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
