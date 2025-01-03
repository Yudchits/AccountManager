using AccountManager.Application.Extensions;
using AccountManager.Infrastructure.Extensions;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Forms;
using AccountManagerWinForm.Forms.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AccountManagerWinForm
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            Application.ThreadException += 
                new ThreadExceptionEventHandler(HandleThreadExceptions);

            AppDomain.CurrentDomain.UnhandledException += 
                new UnhandledExceptionEventHandler(HandleUnhandledExceptions);

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

            Application.Run(ServiceProvider.GetRequiredService<IndexForm>());
        }

        private static void HandleUnhandledExceptions(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            HandleException(exception);
        }

        private static void HandleThreadExceptions(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void HandleException(Exception exception)
        {
            var messageForm = ServiceProvider?.GetRequiredService<MessageForm>();
            if (messageForm != null)
            {
                messageForm.Message = exception.Message;
                messageForm.ShowDialog();
            }
        }
    }
}