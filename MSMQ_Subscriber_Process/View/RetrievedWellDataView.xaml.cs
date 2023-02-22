using MSMQ_Subscriber_Process.ViewModel;
using System.Diagnostics;
using System.Windows;

namespace MSMQ_Subscriber_Process.View
{
    /// <summary>
    /// Interaction logic for RetrievedWellDataView.xaml
    /// </summary>
    public partial class RetrievedWellDataView : Window
    {
        public RetrievedWellDataView()
        {
            InitializeComponent();
            DataContext = new RetrievedWellDataViewModel();
            //string scriptPath = @"C:\path\to\activate-msmq.ps1"; // Replace with the actual path to the PowerShell script file
            //ProcessStartInfo psi = new ProcessStartInfo("powershell.exe", "-ExecutionPolicy Bypass -File \"" + scriptPath + "\"");
            //psi.WindowStyle = ProcessWindowStyle.Hidden;
            //Process.Start(psi);



        }
    }
}
