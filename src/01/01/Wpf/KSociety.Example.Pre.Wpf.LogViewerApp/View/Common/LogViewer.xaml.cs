using KSociety.Log.Serilog.Sinks.RichTextBox.Wpf;
using Serilog;
using System.Windows.Controls;

namespace KSociety.Example.Pre.Wpf.LogViewerApp.View.Common
{
    /// <summary>
    /// Interaction logic for LogViewer.xaml
    /// </summary>
    public partial class LogViewer
    {
        private readonly object _syncRoot = new();

        public LogViewer()
        {
            InitializeComponent();

            const string outputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message}{NewLine:1}{Exception:1}";

            var loggerConfiguration = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.RichTextBox(RichTextBox, outputTemplate: outputTemplate, syncRoot: _syncRoot);

            Serilog.Log.Logger = loggerConfiguration.CreateLogger();

            LogMessages(Serilog.Log.Logger);

        }

        private void RichTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is RichTextBox richTextBox)
            {
                richTextBox.ScrollToEnd();
            }
        }

        private static void LogMessages(ILogger logger)
        {
            const string result = "test";

            logger.Verbose("Your {0} message: {1}", "Trace", result);
            logger.Debug("Your {0} message: {1}", "Debug", result);
            logger.Information("Your {0} message: {1}", "Information", result);
            logger.Warning("Your {0} message: {1}", "Warning", result);
            logger.Error("Your {0} message: {1}", "Error", result);
        }
    }
}
