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
            //PowerShell powershell = PowerShell.Create();
            //powershell.AddScript(@"
            //# check if msmq is installed
            //if ((get-windowsfeature msmq).installed -ne $true) {
            //    # install msmq
            //    install-windowsfeature msmq -includemanagementtools

            //    # enable msmq
            //    enable-windowsoptionalfeature -featurename msmq-server -all
            //    enable-windowsoptionalfeature -featurename msmq-container -all
            //}
            //# restart the msmq service
            //restart-service msmq
            //");
            //powershell.Invoke();
        }
    }
}
