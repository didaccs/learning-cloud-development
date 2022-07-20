using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Consumer;
using System.Text;

const string connectionString = "Endpoint=sb://eventhubdcs.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=lfZDrfUqVP5KjeciY6WZ9lztXXpRBxWw0CBf7Lqx3RU=";
const string hubName = "event";

async Task SendMessages(int numMessages)
{
    var producerClient = new EventHubProducerClient(connectionString, hubName);
    var eventBatch = await producerClient.CreateBatchAsync();

    for (int i = 0; i < numMessages; i++)
    {
        eventBatch.TryAdd(new EventData($"Event number {i}"));
        Console.WriteLine($"Published Message {i}");
        await Task.Delay(100);
    }

    await producerClient.SendAsync(eventBatch);

    eventBatch.Dispose();
}


async Task ReceiveMessages()
{
    string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;
    var producerClient = new EventHubConsumerClient(consumerGroup, connectionString, hubName);
    var eventBatch = producerClient.ReadEventsAsync();

    await foreach (var item in eventBatch)
    {
        var message = Encoding.UTF8.GetString(item.Data.EventBody);
        Console.WriteLine($"Received message {message}");
    }

    await producerClient.DisposeAsync();
}

await SendMessages(3);
await ReceiveMessages();