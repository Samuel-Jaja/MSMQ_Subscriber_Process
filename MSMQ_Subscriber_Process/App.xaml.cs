using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
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
            //PowerShell powerShell = PowerShell.Create();
            //powerShell.AddScript(@"
            //# Check if MSMQ is installed
            //if ((Get-WindowsFeature MSMQ).Installed -ne $true) {
            //    # Install MSMQ
            //    Install-WindowsFeature MSMQ -IncludeManagementTools

            //    # Enable MSMQ
            //    Enable-WindowsOptionalFeature -FeatureName MSMQ-Server -All
            //    Enable-WindowsOptionalFeature -FeatureName MSMQ-Container -All
            //}
            //# Restart the MSMQ service
            //Restart-Service MSMQ
            //");
            //powerShell.Invoke();
        }
    }
}
