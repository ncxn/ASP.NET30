using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomizedIdentity(this IApplicationBuilder app)
        {
            //app.UseIdentityServer();
            //app.UseWhen(
            //    context => context.Request.Path.StartsWithSegments("/api"),
            //    a => a.Use(async (context, next) =>
            //    {
            //        if (!context.User.Identity.IsAuthenticated)
            //        {
            //            var principal = new ClaimsPrincipal();

            //            var bearerAuthResult = await context.AuthenticateAsync(JwtBearerDefaults.AuthenticationScheme);
            //            if (bearerAuthResult?.Principal != null)
            //            {
            //                principal.AddIdentities(bearerAuthResult.Principal.Identities);
            //            }

            //            context.User = principal;
            //        }

            //        await next();
            //    }));

            //app.UseAuthorization();
            return app;
        }
    }
}
