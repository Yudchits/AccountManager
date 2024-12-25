using AccountManager.Application.Extensions;
using AccountManager.Infrastructure.Extensions;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Forms.Resource;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows.Forms;

namespace AccountManagerWinForm
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureServices(services =>
            {
                services.ConfigureInfrastructure();
                services.ConfigureApplication();
                services.ConfigureWinForm();
            });

            var host = builder.Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<GetAllResourcesForm>());
        }
    }
}