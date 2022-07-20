using Azure;
using Azure.Messaging.EventGrid;

const string topicEndpoint = "https://hrtopicdcs.northeurope-1.eventgrid.azure.net/api/events";
const string subscricptionName = "iGZpFqLKIACPNqgLUxB4SxARm4gSVRYi6mlcEwn8pdw=";

EventGridPublisherClient client = new EventGridPublisherClient(new Uri(topicEndpoint), new AzureKeyCredential(subscricptionName));


async Task SendMessages(string fullName, string address)
{
    await client.SendEventAsync(new EventGridEvent(
         subject: $"New Employee: {fullName}",
         eventType: "Employees.Registration.New",
         dataVersion: "1.0",
         data: new
         {
             FullName = fullName,
             Address = address
         }
     ));
}

await SendMessages("Mario Fernandez Ruiz", "Castelao 100, Hospitalet");
await SendMessages("John Doe", "Massachussets");
await SendMessages("Elenaita", "En su puñetera casa");
await SendMessages("Darth Vader", "Estrella de la muerte");
