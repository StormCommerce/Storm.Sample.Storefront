using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Integration.Storm.Builder;
using Integration.Storm.Extensions;
using Integration.Storm.Managers;
using Integration.Storm.Model.Product;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Model.Commerce.Extensions;
using Model.Commerce.Managers;
using Storefront.Models;

/******************************************************************************
 ** Author: Fredrik Gustavsson, Jolix AB, www.jolix.se
 ** Purpose: Sample code for how to build an integration from a frontend
 **          solution to communicate with Storm Commerce (storm.io)
 ** Copyright (C) Jolix AB, Storm Commerce AB
 ******************************************************************************/
namespace storefront
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(2);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();

            // Accessor for creating interaction to services
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddTransient<IStormConnectionManager, StormConnectionManager>();
            services.AddTransient<IProductBuilder<StormProductItem, StormProduct>, ProductBuilder>();
            services.AddTransient<IProductManager, StormProductManager>();
            services.AddTransient<ICategoryManager, StormCategoryManager>();
            services.AddTransient<IBuyableExtension, DefaultBuyableExtension>();
            services.AddTransient<IBasketManager, StormBasketManager>();

            // Local services
            services.AddScoped<ISessionModel, SessionModel>();

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
