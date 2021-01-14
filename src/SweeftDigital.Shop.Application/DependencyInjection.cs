using AutoMapper;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using SweeftDigital.Shop.Application.Behaviours;
using System.Reflection;

namespace SweeftDigital.Shop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CashingBehaviour<,>));
            //services.AddTransient(typeof(IRequestPreProcessor<>), typeof(LoggingBehaviour<>));

            return services;
        }
    }
}
