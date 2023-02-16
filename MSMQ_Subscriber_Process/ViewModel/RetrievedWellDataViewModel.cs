using MSMQ.Messaging;
using MSMQ_Subscriber_Process.Model;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
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
            RetrievedWellDataModels = new ObservableCollection<WellDataModel>();
            RetrieveWellCommandAction();
        }
        //string publicQueueName = "publicmsmq";

        //MODIFIIY FOR SERVER(SUBSCRIBER) 
        //readonly string publicQueuePath = "FormatName:DIRECT=OS:<cclng-pc5188>\\public$\\publicmsmq";
        //readonly string publicQueuePath = "FormatName:DIRECT=TCP:192.168.1.151\\PUBLIC$\\publicmsmq";
        readonly string publicQueuePath = "FormatName:DIRECT=OS:CCLNG-PC5188.svr.cyphercrescent.com\\publicmsmq";
        
        //readonly string publicQueuePath = "FormatName:PUBLIC=PublicMsmq@192.168.1.151:1801";
        //readonly string privateQueuePath = @".\private$\MSMQ_MessagingApp";

        /// <summary>
        /// This method connects to queue and listens for incoming data( well data) from 
        /// the queue using the ReceiveCompleted event handled by the delegate eventHandler 
        /// which holds a referecnce to OnReceiveCompleted.
        /// BeginReceive initiates asynchronous receive operation.
        /// </summary>
        public void RetrieveWellCommandAction()
        {
            //// Define the name of the queue to search for
            //string queueName = "publicmsmq";

            //// Define the DSI query to search for the queue
            //string query = "(&(objectCategory=msmqQueueAlias)(objectClass=msmqQueueAlias)(cn=" + queueName + "))";

            //// Set the scope of the search to the entire domain
            //DirectorySearcher searcher = new(new DirectoryEntry("LDAP://" + Domain.GetComputerDomain().Name));

            //// Set the properties to retrieve from the search results
            //searcher.PropertiesToLoad.Add("msmqQueueFormatName");

            //// Set the filter to the DSI query
            //searcher.Filter = query;

            //// Perform the search and retrieve the format name of the queue
            //SearchResult? result = searcher.FindOne();

            //string formatName = (string)result.Properties["msmqQueueFormatName"][0];
            ////string formatName = "FormatName:DIRECT = TCP:192.168.1.151:1801\\Public$\\PublicMsmq";

            //// Create a MessageQueue object to represent the queue
            //MessageQueue queue = new(formatName);

            MessageQueue queue = new(publicQueuePath);
            queue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnReceiveCompleted);
            queue.BeginReceive();
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
