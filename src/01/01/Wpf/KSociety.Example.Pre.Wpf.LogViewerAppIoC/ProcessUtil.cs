using System.Diagnostics;
using System.Linq;

namespace KSociety.Example.Pre.Wpf.LogViewerAppIoC
{
    public static class ProcessUtil
    {
        public static Process? PriorProcess()
        {
            var current = Process.GetCurrentProcess();
            var process = Process.GetProcessesByName(current.ProcessName);
            return process.FirstOrDefault(p =>
                current.MainModule != null && p.MainModule != null && p.Id != current.Id &&
                p.MainModule.FileName == current.MainModule.FileName);
        }
    }
}