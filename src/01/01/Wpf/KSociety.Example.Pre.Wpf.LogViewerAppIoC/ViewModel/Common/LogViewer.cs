using CommunityToolkit.Mvvm.ComponentModel;
using KSociety.Log.Serilog.Sinks.RichTextBoxQueue.Wpf.Sinks.RichTextBoxQueue;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Controls;

namespace KSociety.Example.Pre.Wpf.LogViewerAppIoC.ViewModel.Common
{
    public class LogViewer : ObservableObject
    {
        private readonly ILogger<LogViewer> _logger;
        private readonly IRichTextBoxQueueSink _richTextBoxQueueSink;

        #region [Fields]

        private readonly System.Windows.Controls.RichTextBox _richTextBox;

        private readonly object _syncRoot;

        #endregion

        public LogViewer()
        {
            _syncRoot = new object();
        }

        public LogViewer(IRichTextBoxQueueSink richTextBoxQueueSink, ILogger<LogViewer> logger, System.Windows.Controls.RichTextBox richTextBox)
            : this()
        {
            _richTextBoxQueueSink = richTextBoxQueueSink;
            _logger = logger;
            _richTextBox = richTextBox;

            try
            {
                _richTextBoxQueueSink.AddRichTextBox(_richTextBox, syncRoot: _syncRoot);
                LogMessages(logger);
            }
            catch (Exception ex)
            {
                ;
            }

            _richTextBox.TextChanged += RichTextBoxOnTextChanged;
        }

        private static void RichTextBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is RichTextBox richTextBox)
            {
                richTextBox.ScrollToEnd();
            }
        }

        private void LogMessages(ILogger<LogViewer> logger)
        {
            //const string result = "COM11": Tx-> "AA-34-00-22" : "?4\u0000\"";
            //const string result = "?4\u0000\"";
            //const string result = "?4\u0000\"";
            const string result = "test";

            logger.LogDebug("Your {0} message: {1}", "Trace", result);
            logger.LogDebug("Your {0} message: {1}", "Debug", result);
            logger.LogInformation("Your {0} message: {1}", "Information", result);
            logger.LogWarning("Your {0} message: {1}", "Warning", result);
            logger.LogError("Your {0} message: {1}", "Error", result);
        }
    }
}
