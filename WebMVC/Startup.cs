using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebMVC.Extensions;
using WebMVC.Models;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC
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
            services.AddControllersWithViews();
            services.AddSession();
           
            // Add identity types
            services.AddCustomizedIdentity(Configuration);

            //Database service by ADO.NET
            var connectionString = Configuration.GetSection("DbConnection:ConnectionString").Value;
            services.AddTransient<MySqlAppDb>(_ => new MySqlAppDb(connectionString));

            //Messages service

            //services.AddTransient<IEmailSender, MessageServices>(implementation =>
            //    new MessageServices(
            //        this.Configuration["EmailSender:Host"],
            //        this.Configuration.GetValue<int>("EmailSender:Port"),
            //        this.Configuration.GetValue<bool>("EmailSender:EnableSSL"),
            //        this.Configuration["EmailSender:UserName"],
            //        this.Configuration["EmailSender:Password"],
            //        this.Configuration["EmailSender:SenderEmail"]));
            //services.AddTransient<ISmsSender, MessageServices>();



            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseSession();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseCustomizedIdentity();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller}/{action}",
                    defaults: new { controller = "Dashboard", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "{controller}/{id?}");
            });
        }
    }
}
