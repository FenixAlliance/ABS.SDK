using System.Diagnostics;

namespace FenixAlliance.ABS.SDK.Helpers
{
    public static class PowerShellHelpers
    {
        public static void StartProcessAsync(string command = "powershell.exe", string arguments = "mongod")
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo(command, arguments)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };

            process = Process.Start(processInfo);
        }
    }
}