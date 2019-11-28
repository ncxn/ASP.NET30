using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;
using System.Reflection;
using Domain.Bus;
using Application.Common;
using Application.Interfaces;
using Application.Node.NodeCreate;

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

            // Command Bus using MediatR
            services.AddScoped<IMediatorHandler, CommandBus>();

            // Command
            services.AddScoped<IRequestHandler<NodeCreateCommand, bool>, NodeCreateHandler>();
            return services;
        }
    }
}
