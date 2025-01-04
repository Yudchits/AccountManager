using AccountManagerWinForm.Forms;
using AccountManagerWinForm.Forms.Account;
using AccountManagerWinForm.Forms.Common;
using AccountManagerWinForm.Forms.Resource;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagerWinForm.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureWinForm(this IServiceCollection services)
        {
            services.AddSingleton<IndexForm>();
            services.AddSingleton<MessageForm>();
            services.AddTransient<ResourcesForm>();
            services.AddTransient<AccountsForm>();
        }
    }
}