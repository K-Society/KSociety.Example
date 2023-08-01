using System.Windows;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Pre.Wpf.LogViewerAppIoC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ILogger<MainWindow> logger)
        {
            InitializeComponent();

            //var logger = loggerFactory.CreateLogger<MainWindow>();

            logger.LogInformation("Main Window");
            
            //Serilog.Log.Logger.Information("Main Window");
        }
    }
}
