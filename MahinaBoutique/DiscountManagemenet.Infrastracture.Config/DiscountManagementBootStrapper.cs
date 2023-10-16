using DiscountManagement.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastracture.EFCore;
using DiscountManagement.Infrastracture.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
        
namespace DiscountManagement.Infrastracture.Config
{
    public static class DiscountManagementBootStrapper
    {
        public static void Configure(IServiceCollection service, string connectionstring)
        {
            service.AddTransient<ICustomerDiscountApplication,CustomerDiscountApplication>();
            service.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();

            service.AddDbContext<DiscountContext>(x => x.UseSqlServer(connectionstring));
        }
    }
}
