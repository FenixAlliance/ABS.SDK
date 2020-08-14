using System.Diagnostics;

namespace FenixAlliance.SDK.Helpers
{
    public static class PowerShellHelpers
    {
        public static void StartProcessAsync(string command = "powershell.exe", string arguments = "mongod")
        {
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo(command, arguments);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;

            process = Process.Start(processInfo);
        }
    }
}