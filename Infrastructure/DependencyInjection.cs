using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<AppDb>(_ => new AppDb(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
