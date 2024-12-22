using AP.MyGameStore.Application.Behaviours;
using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AP.MyGameStore.Application.Extensions
{
    public static class Registrator
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IStoresService, StoresService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            
            return services;
        }

    }
}
