using AccountManager.Application.Common;
using AccountManager.Application.Extensions;
using AccountManager.Infrastructure.Extensions;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms;
using AccountManagerWinForm.Forms.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Windows.Forms;

namespace AccountManagerWinForm
{
    public static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static IndexForm? IndexForm { get; private set; }

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

            IndexForm = ServiceProvider.GetRequiredService<IFormFactory>().CreateIndexForm();
            Application.Run(IndexForm);
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
            MessageType type = exception switch
            {
                BadRequestException => MessageType.WARN,
                InternalServerException => MessageType.ERROR,
                ConflictException => MessageType.ERROR,
                NotFoundException => MessageType.ERROR,
                _ => MessageType.ERROR
            };

            var messageForm = new MessageForm(exception.Message, type);
            messageForm.ShowDialog();
        }
    }
}