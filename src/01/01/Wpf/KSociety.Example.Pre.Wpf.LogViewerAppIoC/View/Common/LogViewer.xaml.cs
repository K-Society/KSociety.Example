using System.Windows.Controls;

namespace KSociety.Example.Pre.Wpf.LogViewerAppIoC.View.Common
{
    /// <summary>
    /// Interaction logic for LogViewer.xaml
    /// </summary>
    public partial class LogViewer : UserControl
    {
        public LogViewer()
        {
            InitializeComponent();
            DataContext = Helper.DiSource.Resolver is null ? new ViewModel.Common.LogViewer() : Helper.DiSource.Resolver(typeof(ViewModel.Common.LogViewer), RichTextBox, null);
        }
    }
}
