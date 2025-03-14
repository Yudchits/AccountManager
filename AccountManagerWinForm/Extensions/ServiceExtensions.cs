using AccountManager.Application.Common;
using AccountManagerWinForm.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagerWinForm.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureWinForm(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.Configure<UserContextSettings>(configuration.GetSection("Cryptography:Hash:UserContext"));
            services.AddTransient<IFormFactory, FormFactory>();
        }
    }
}