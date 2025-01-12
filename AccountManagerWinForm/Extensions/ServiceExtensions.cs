using AccountManagerWinForm.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagerWinForm.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureWinForm(this IServiceCollection services)
        {
            services.AddTransient<IFormFactory, FormFactory>();
        }
    }
}