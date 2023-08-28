using System;
using System.Text.Json.Serialization;
using Integration.Storm.Builder;
using Integration.Storm.Extensions;
using Integration.Storm.Managers;
using Integration.Storm.Model.Product;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Model.Commerce.Extensions;
using Model.Commerce.Managers;
using Storefront.Models;
using JsonNullableDateTimeConverter = Model.Commerce.Extensions.JsonNullableDateTimeConverter;

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

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonNullableDateTimeConverter());
                options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter());
                options.JsonSerializerOptions.Converters.Add(new JsonDateTimeOffsetConverter());
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.IgnoreReadOnlyProperties = false;
                options.JsonSerializerOptions.AllowTrailingCommas = true;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });

            // Accessor for creating interaction to services
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IStormConnectionManager, NorceConnectionManager>();
            services.AddTransient<IProductBuilder<StormProductItem, StormProduct>, ProductBuilder>();
            services.AddTransient<IProductManager, StormProductManager>();
            services.AddTransient<ICategoryManager, StormCategoryManager>();
            services.AddTransient<IBuyableExtension, DefaultBuyableExtension>();
            services.AddTransient<IBasketManager, StormBasketManager>();
            services.AddTransient<IAccountManager, StormAccountManager>();
            services.AddTransient<IApplicationManager, StormApplicationManager>();
            services.AddTransient<ICheckoutManager, StormCheckoutManager>();
            services.AddTransient<IFormCheckoutProvider, StormKcoManager>();

            // Local services
            services.AddScoped<ISessionModel, SessionModel>();

            services.AddMemoryCache();

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
