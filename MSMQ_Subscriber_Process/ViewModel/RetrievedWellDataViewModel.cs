using MSMQ.Messaging;
using MSMQ_Subscriber_Process.Model;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;

namespace MSMQ_Subscriber_Process.ViewModel
{
    /// <summary>
    /// RetrievedWellDataViewModel handles the logic between the model and view to Subscribe to Data.
    /// The class uses MSMQ Messaging Nuget Package and BindableBase class from Prism Framework for notify property change.
    /// </summary>
    public class RetrievedWellDataViewModel:BindableBase
    {
        public RetrievedWellDataViewModel()
        {
            machineName = Environment.MachineName;
            RetrievedWellDataModels = new ObservableCollection<WellDataModel>();
            RetrieveWellCommandAction();
        }
        private readonly string machineName;
        readonly string publicQueuePath = ConfigurationManager.AppSettings["PublicQueuePath"] ?? "default value";
        readonly string privateQueuePath = ConfigurationManager.AppSettings["PrivateQueuePath"] ?? "default value";
        private string GetMachinePublicQueuePath() => $"{machineName}{publicQueuePath}";

        /// <summary>
        /// This method retrives data from public or private queues.
        /// This method connects and listens to the queue for incoming data( well data) from 
        /// using the ReceiveCompleted Event, handled by the delegate EventHandler 
        /// which holds a referecnce to OnReceiveCompleted.
        /// BeginReceive initiates asynchronous receive operation it leaves no data in queue.
        /// </summary>
        public void RetrieveWellCommandAction()  
        {
            try
            {
                if (MessageQueue.Exists(GetMachinePublicQueuePath()))
                {
                    MessageQueue queue = new(GetMachinePublicQueuePath());
                    queue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnReceiveCompleted);
                    queue.BeginReceive();
                }
                else
                {
                    MessageQueue queue = new(privateQueuePath);
                    queue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnReceiveCompleted);
                    queue.BeginReceive();
                }
            }
            catch (MessageQueueException ex)
            {
                MessageBox.Show("An error occured while checking the queue to fetch data:" + ex.Message);
            }
        }

        /// <summary>
        /// This method represents a callback for an asynchronous receive operation on a message queue.
        /// The method responds to the delegate handler, it casts the sender object recieved to MessageQueue type, deserializes format.
        /// The EndReceive method of the queue object is called to retrieve the results of the asynchronous receive operation
        /// initiated by BeginReceive.
        /// 
        /// The Application.Current property returns the current instance of the Application class, which represents the running
        /// WPF application. The Dispatcher property of the Application class returns the Dispatcher object associated with the 
        /// current thread. The Dispatcher is responsible for executing code that updates the user interface.
        /// 
        /// The Invoke method of the Dispatcher is used to execute code on the user interface thread, which is required for any 
        /// operations that update the user interface. The Invoke method takes a delegate (Action) as an argument, which is the 
        /// code that needs to be executed.
        /// 
        /// By using Invoke, the item is added to the collection on the user interface thread, which ensures that the operation
        /// is thread-safe and that the user interface is updated correctly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            MessageQueue queue = (MessageQueue)sender;
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(WellDataModel) });
            Message message = queue.EndReceive(e.AsyncResult);
            WellDataModel wellDatamodel = (WellDataModel)message.Body;
            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                RetrievedWellDataModels.Add(wellDatamodel);
            });
            queue.BeginReceive();
        }

        /// <summary>
        /// The retrievedWellDataModels is an observable collection
        /// (dynamic collection) that keeps the undelying model in sync  with the UI.
        /// </summary>
        private ObservableCollection<WellDataModel> retrievedWellDataModels;
        public ObservableCollection<WellDataModel> RetrievedWellDataModels
        {
            get { return retrievedWellDataModels; }
            set { retrievedWellDataModels = value; }
        }
    }
}
