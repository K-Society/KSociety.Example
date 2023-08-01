using Autofac;
using Autofac.Extensions.DependencyInjection;
using KSociety.Example.Pre.Wpf.LogViewerAppIoC.Helper;
using KSociety.Log.Serilog.Sinks.RichTextBoxQueue.Wpf;
using KSociety.Log.Serilog.Sinks.RichTextBoxQueue.Wpf.Sinks.RichTextBoxQueue;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using System;
using System.Windows;

namespace KSociety.Example.Pre.Wpf.LogViewerAppIoC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static RichTextBoxQueueSink _richTextBoxQueueSink;
        private readonly IHost _host;
        private static IConfigurationRoot? _configuration;
        private IServiceProvider ServiceProvider { get; set; }

        public object? Resolve(Type? type, object? key, string? name)
        {
            if (type is null)
            {
                return null;
            }

            if (type is not null && key is null)
            {
                return ServiceProvider.GetService(type);
            }

            if (type is not null && key is not null)
            {
                return ActivatorUtilities.CreateInstance(ServiceProvider, type, key);
            }

            return null;
        }

        public App()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(_configuration).CreateLogger();

            _richTextBoxQueueSink = new RichTextBoxQueueSink();

            var logEventSink = (ILogEventSink)Serilog.Log.Logger;

            var loggerConfiguration = new LoggerConfiguration()
                .WriteTo.Sink(logEventSink)
                .MinimumLevel.Verbose()
                .WriteTo.RichTextBoxQueue(_richTextBoxQueueSink);

            Serilog.Log.Logger = loggerConfiguration.CreateLogger();

            try
            {
                var builder = CreateHostBuilder();
                
                _host = builder.Build();

            }
            catch (Exception ex)
            {
                ;
            }
        }

        private static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddConfiguration(_configuration);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<KSociety.Example.Pre.Wpf.LogViewerAppIoC.ViewModel.Common.LogViewer>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory(ConfigureContainer))
                .UseConsoleLifetime();

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new Bindings.Log(_richTextBoxQueueSink));
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            if (ProcessUtil.PriorProcess() != null)
            {
                string messageBoxText = @"Another instance of the app is already running.";
                string caption = "Conflicting instance";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;

                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
                Current.Shutdown();
                return;
            }

            base.OnStartup(e);
            var serviceScope = _host.Services.CreateScope();
            ServiceProvider = serviceScope.ServiceProvider;

            DiSource.Resolver = Resolve;

            try
            {
                var mainWindows = ServiceProvider.GetRequiredService<MainWindow>();

                Current.MainWindow = mainWindows;
                mainWindows.Show();
            }
            catch (Exception ex)
            {
                ;
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await Serilog.Log.CloseAndFlushAsync();
            using (_host)
            {
                await _host.StopAsync();
            }

            base.OnExit(e);
        }
    }
}
