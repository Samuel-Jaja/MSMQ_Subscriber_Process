using MSMQ_Subscriber_Process.ViewModel;
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


        }
    }
}
