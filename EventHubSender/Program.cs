using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;

namespace EventHubSender
{
    class Program
    {
        static string eventHubName = "geotractrialeventhub";
        static string connectionString = "Endpoint=sb://geotractrialeventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=lxdA7gs2HBIoXh5WdIHM1CmnWFWTGUhL9r+vLWy7y+Y=";

        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl-C to stop the sender process");
            Console.WriteLine("Press Enter to start now");
            Console.ReadLine();
            SendingRandomMessages();
        }

        static void SendingRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
            AvlMessageGenerator messageGenerator = new AvlMessageGenerator();
            Random randomNumberGenerator = new Random();
            Random randomCoordinateGenerator = new Random();
            while (true)
            {
                try
                {
                    // Serialize to JSON 
                    var message = JsonConvert.SerializeObject(messageGenerator.Generate(randomNumberGenerator.Next(4), randomCoordinateGenerator.Next(22)));
                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, message);
                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(message)));
                }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }

                Thread.Sleep(2000);
            }
        }
    }
}
