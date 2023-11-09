using _0_SelfBuildFramwork.Application;
using _0_SelfBuildFramwork.Infrastracture;
using AccountManagement.Infrastracture.Config;
using BlogManagement.Infrastracture.Config;
using CommentManagement.Infrastracture.Config;
using DiscountManagement.Infrastracture.Config;
using InventoryManagement.Infrastracture.Config;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Infrastracture.Config;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            var ConnectionString = Configuration.GetConnectionString("MahinaBoutique");
            ShopmanagmentBootstrapper.Configure(services,ConnectionString);
            DiscountManagementBootStrapper.Configure(services,ConnectionString);
            InventoryManagementBootstrapper.Configure(services,ConnectionString);
            BlogManagementBootstrapper.Configure(services,ConnectionString);
            CommentManagementBootstrapper.Configure(services,ConnectionString);
            AccountManagementBootstrapper.Configure(services,ConnectionString);

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });
            services.Configure<CookieTempDataProviderOptions>(options =>
            {
                options.Cookie.IsEssential = true;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });


            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin ,UnicodeRanges.Arabic));
            services.AddTransient<IFileUploader,FileUploader>();
            services.AddTransient<IAuthHelper,AuthHelper>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddAuthorization(option => {
            option.AddPolicy("AdminArea", builder => builder.RequireRole(new List<string> { Roles.SystemAdmin , Roles.SystemManager }));
            option.AddPolicy("Shop",builder => builder.RequireRole(new List<string> {Roles.SystemManager}));
            option.AddPolicy("Discount",builder => builder.RequireRole(new List<string> {Roles.SystemManager}));
            option.AddPolicy("Account",builder => builder.RequireRole(new List<string> {Roles.SystemManager}));
                });   
                

            services.AddRazorPages()
                .AddMvcOptions(option => option.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(option => 
            { option.Conventions.AuthorizeAreaFolder("Administration","/","AdminArea");
              option.Conventions.AuthorizeAreaFolder("Administration","/Shop","Shop");
              option.Conventions.AuthorizeAreaFolder("Administration","/Discount","Discount");
              option.Conventions.AuthorizeAreaFolder("Administration","/Account","Account");
                
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
