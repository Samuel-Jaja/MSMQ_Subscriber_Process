using System;
using System.Diagnostics;
using System.Windows;

namespace MSMQ_Subscriber_Process
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ActivateMsmq();
        }

        private static void ActivateMsmq()
        {
            // Path to the PowerShell script file
            string scriptFilePath = @".\automate_publicmsmq.ps1";

            // Create the PowerShell process start info
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptFilePath}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            // Start the PowerShell process
            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();

                // Read the output and error streams
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                // Display the output and error
                Console.WriteLine(output);
                Console.WriteLine(error);
            }
        }
    }
}
