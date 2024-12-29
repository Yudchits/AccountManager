using AccountManagerWinForm.Forms.Accounts;
using AccountManagerWinForm.Forms.Common;
using AccountManagerWinForm.Forms.Resource;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagerWinForm.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureWinForm(this IServiceCollection services)
        {
            services.AddTransient<GetAllResourcesForm>();
            services.AddTransient<CreateResourceForm>();
            services.AddTransient<GetAccountsByResourceIdForm>();
            services.AddSingleton<MessageForm>();
        }
    }
}