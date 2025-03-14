using AccountManager.Application.Common.Behaviours;
using AccountManager.Application.Context;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AccountManager.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddSingleton(UserContext.Instance);
            services.AddSingleton(DirectoryContext.Instance);

            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(executingAssembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(executingAssembly));
            services.AddValidatorsFromAssembly(executingAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        }
    }
}