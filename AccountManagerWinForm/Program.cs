using AccountManager.Application.Common;
using AccountManager.Application.Common.Exceptions;
using AccountManager.Application.Extensions;
using AccountManager.Infrastructure.Extensions;
using AccountManagerWinForm.Extensions;
using AccountManagerWinForm.Factories;
using AccountManagerWinForm.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
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

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders();
                logging.AddNLog();
            })
            .ConfigureServices(services =>
            {
                services.ConfigureInfrastructure();
                services.ConfigureApplication();
                services.ConfigureWinForm(configuration);
            });

            var host = builder.Build();
            ServiceProvider = host.Services;

            IndexForm = ServiceProvider.GetRequiredService<IFormFactory>().CreateIndexForm();
            
            var authForm = ServiceProvider.GetRequiredService<IFormFactory>().CreateAuthForm();
            if (authForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(IndexForm);
            }
            else
            {
                Application.Exit();
            }
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
                ConflictException => MessageType.WARN,
                NotFoundException => MessageType.WARN,
                _ => MessageType.ERROR
            };

            var messageForm = ServiceProvider
                ?.GetRequiredService<IFormFactory>()
                .CreateMessageDialogForm(exception.Message, type);

            messageForm?.ShowDialog();
        }
    }
}