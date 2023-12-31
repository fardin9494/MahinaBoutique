﻿using _0_SelfBuildFramwork.Infrastracture;
using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastracture.Config.Permissions;
using InventoryManagement.Infrastracture.EfCore;
using InventoryManagement.Infrastracture.EfCore.Repositories;
using MahinaBoutique.Query.Contract.Inventory;
using MahinaBoutique.Query.Query;
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
            service.AddTransient<IInventoryApplication, InventoryApplication>();
            service.AddTransient<IPermissionExposer, InventoryPermissionExposer>();
            service.AddTransient<IInventoryQuery, InventoryQuery>();

            service.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
