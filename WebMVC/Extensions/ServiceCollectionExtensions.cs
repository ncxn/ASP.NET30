using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMVC.DataProvider;
using WebMVC.Models;

namespace WebMVC.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentity<Users, Roles>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredUniqueChars = 0;
                    //options.ClaimsIdentity.UserNameClaimType = JwtRegisteredClaimNames.Sub;
                })
                .AddRoleStore<RoleProvider>()
                .AddUserStore<UserProvidercs>()
                .AddDefaultTokenProviders();
            //services.AddTransient<UserData>();
            //services.AddIdentityServer(options =>
            //{
            //    options.Events.RaiseErrorEvents = true;
            //    options.Events.RaiseInformationEvents = true;
            //    options.Events.RaiseFailureEvents = true;
            //    options.Events.RaiseSuccessEvents = true;
            //})
            //     .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
            //     .AddInMemoryApiResources(IdentityServerConfig.Apis)
            //     .AddInMemoryClients(IdentityServerConfig.Clients)
            //     .AddAspNetIdentity<User>()
            //     .AddProfileService<SimplProfileService>()
            //     .AddDeveloperSigningCredential(); // not recommended for production - you need to store your key material somewhere secure

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie()
            //    .AddFacebook(x =>
            //    {
            //        x.AppId = configuration["Authentication:Facebook:AppId"];
            //        x.AppSecret = configuration["Authentication:Facebook:AppSecret"];

            //        x.Events = new OAuthEvents
            //        {
            //            OnRemoteFailure = ctx => HandleRemoteLoginFailure(ctx)
            //        };
            //    })
            //    .AddGoogle(x =>
            //    {
            //        x.ClientId = configuration["Authentication:Google:ClientId"];
            //        x.ClientSecret = configuration["Authentication:Google:ClientSecret"];
            //        x.Events = new OAuthEvents
            //        {
            //            OnRemoteFailure = ctx => HandleRemoteLoginFailure(ctx)
            //        };
            //    })
            //    .AddLocalApi(JwtBearerDefaults.AuthenticationScheme, option => {
            //        option.ExpectedScope = "api.simplcommerce";
            //    });

            //services.ConfigureApplicationCookie(x =>
            //{
            //    x.LoginPath = new PathString("/login");
            //    x.Events.OnRedirectToLogin = context =>
            //    {
            //        if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == (int)HttpStatusCode.OK)
            //        {
            //            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //            return Task.CompletedTask;
            //        }

            //        context.Response.Redirect(context.RedirectUri);
            //        return Task.CompletedTask;
            //    };
            //    x.Events.OnRedirectToAccessDenied = context =>
            //    {
            //        if (context.Request.Path.StartsWithSegments("/api") && context.Response.StatusCode == (int)HttpStatusCode.OK)
            //        {
            //            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            //            return Task.CompletedTask;
            //        }

            //        context.Response.Redirect(context.RedirectUri);
            //        return Task.CompletedTask;
            //    };
            //});
            return services;
        }
    }
}
