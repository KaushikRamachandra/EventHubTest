using Microsoft.ServiceBus.Messaging;
using System;

namespace EventhubReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            string eventHubConnectionString = "Endpoint=sb://geotractrialeventhub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=lxdA7gs2HBIoXh5WdIHM1CmnWFWTGUhL9r+vLWy7y+Y=";
            string eventHubName = "geotractrialeventhub";
            string storageAccountName = "portalvhds0qbh0pd57kwfp";
            string storageAccountKey = "oI1gqiaip7eHZop1sS3XrYN4Sr2NTMksMZBA5UPCvwJAiRmH8FRrJ1QBU/QhGk5QLFU9oijuaR9K4VOoUZDw1g==";
            string storageConnectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", storageAccountName, storageAccountKey);

            string eventProcessorHostName = Guid.NewGuid().ToString();
            EventProcessorHost eventProcessorHost = new EventProcessorHost(eventProcessorHostName, eventHubName, EventHubConsumerGroup.DefaultGroupName, eventHubConnectionString, storageConnectionString);
            Console.WriteLine("Registering EventProcessor...");
            var options = new EventProcessorOptions();
            options.ExceptionReceived += (sender, e) => { Console.WriteLine(e.Exception); };
            eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>(options).Wait();

            Console.WriteLine("Receiving. Press enter key to stop worker.");
            Console.ReadLine();
            eventProcessorHost.UnregisterEventProcessorAsync().Wait();
        }
    }
}
