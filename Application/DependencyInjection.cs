using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;
using System.Reflection;
using Domain.Bus;
using Application.Common;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient<IMediatorHandler, CommandBus>();
            return services;
        }
    }
}
