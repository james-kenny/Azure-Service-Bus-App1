using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting..");

            string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            
            QueueClient Client = QueueClient.CreateFromConnectionString(connectionString, "serversncodedemoqueue");

            // Create message, passing a string message for the body.
            BrokeredMessage message = new BrokeredMessage("");

            // Set some addtional custom app-specific properties.
            message.Properties["UserCode"] = "dascdcasas";
            message.Properties["UserId"] = "4550";

            try
            {
                // Send message to the queue.
                Client.Send(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.WriteLine("Complete..");
            Console.ReadKey();
        }
    }
}
