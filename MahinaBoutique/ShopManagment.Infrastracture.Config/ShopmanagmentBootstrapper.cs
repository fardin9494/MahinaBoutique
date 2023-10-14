﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using ShopManagement.InfraStracture.EfCore;
using ShopManagement.InfraStracture.EfCore.Repositories;
using ShopManagment.InfraStracture.EfCore.Repositories;
using System;

namespace ShopManagement.Infrastracture.Config
{
    public class ShopmanagmentBootstrapper
    {
        public static void Configure(IServiceCollection services,string Connectionstring)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductRepository, ProductReposiory>();
            services.AddTransient<Application.Contract.Product.IProductApplication, ProductApplication>();
            services.AddTransient<IProductPictureApplication,ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository,ProductPictureRepository>();
            services.AddTransient<ISlideRepository,SlideRepository>();
            services.AddTransient<Application.Contract.Slide.ISlideApplication, SlideApplication>();

            services.AddDbContext<ShopContext>(x => x.UseSqlServer(Connectionstring));
        }
    }
}
