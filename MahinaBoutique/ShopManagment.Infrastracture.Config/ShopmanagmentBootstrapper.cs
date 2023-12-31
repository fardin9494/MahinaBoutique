﻿using _0_SelfBuildFramwork.Infrastracture;
using MahinaBoutique.Query.Contract;
using MahinaBoutique.Query.Contract.Product;
using MahinaBoutique.Query.Contract.ProductCategory;
using MahinaBoutique.Query.Contract.Slide;
using MahinaBoutique.Query.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Order;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.Services;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.Infrastracture.AccountAcl;
using ShopManagement.Infrastracture.InventoryAcl;
using ShopManagement.InfraStracture.EfCore;
using ShopManagement.InfraStracture.EfCore.Repositories;
using ShopManagment.Infrastracture.Config.Permissions;
using ShopManagment.InfraStracture.EfCore.Repositories;

namespace ShopManagement.Infrastracture.Config
{
    public class ShopmanagmentBootstrapper
    {
        public static void Configure(IServiceCollection services,string Connectionstring)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductRepository, ProductReposiory>();
            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductPictureApplication,ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository,ProductPictureRepository>();
            services.AddTransient<ISlideRepository,SlideRepository>();
            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideQuery, SlideQuery>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            services.AddTransient<IProductQuery, ProductQuery>();
            services.AddTransient<IPermissionExposer, ShopPermissionExposer>();
            services.AddTransient<ICartCalculator, CartCalculator>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderApplication, OrderApplication>();
            services.AddSingleton<ICartService, CartService>();
            services.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();
            services.AddTransient<IShopAccountAcl, ShopAccountAcl>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(Connectionstring));
        }
    }
}
