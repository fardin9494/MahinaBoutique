using AccountManagement.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastracture.EfCore;
using AccountManagement.Infrastracture.EfCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AccountManagement.Infrastracture.Config
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string ConnectionString)
        {
            service.AddTransient<IAccountRepository,AccountRepository>();
            service.AddTransient<IAccountApplication,AccontApplication>();
            service.AddTransient<IRoleRepository,RoleRepository>();
            service.AddTransient<IRoleApplication,RoleApplication>();


            service.AddDbContext<AccountContext>(x => x.UseSqlServer(ConnectionString));

        }
    }
}
