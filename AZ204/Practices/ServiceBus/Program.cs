// See https://aka.ms/new-console-template for more information
using Azure.Messaging.ServiceBus;

string serviceBusConnectionString = "Endpoint=sb://sbnamespacedcs.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=IcNsgQNVSBRB4ePz/zjrAE+j9lkoSU0ma6M4DQ/7JsU=";
string serviceBusQueue = "messagequeue";

async Task SendMessages(ServiceBusClient client, int numMessages)
{
    var sender = client.CreateSender(serviceBusQueue);

    for (int i = 0; i < numMessages; i++)
    {
        await sender.SendMessageAsync(new ServiceBusMessage($"Message {i}"));
        Console.WriteLine($"Published Message {i}");
        await Task.Delay(100);
    }

    await sender.DisposeAsync();
}

async Task GetMessages(ServiceBusClient client)
{
    var receiver = client.CreateReceiver(serviceBusQueue);

    do
    {
        var result = await receiver.ReceiveMessageAsync();
        if (result != null)
        {
            Console.WriteLine($"Received Message {result.Body}");            
        }
        await Task.Delay(100);
    } while (true);
}

var client = new ServiceBusClient(serviceBusConnectionString);

await SendMessages(client, 10);

await GetMessages(client);
