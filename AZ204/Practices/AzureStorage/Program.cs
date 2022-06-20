using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Threading.Tasks;



string blobServiceEndpoint = "https://mediastordcs.blob.core.windows.net/";
string storageAccountName = "mediastordcs";
string storageAccountKey = "MNGMmJVKOjZeSJcy+VkDxVpk6iVrMI5Fe/Qg3TmMhYGnsuRbCvnC41xApcqyL9dZMcH3GHhGIVOJ+AStpW0hTg==";

BlobServiceClient blobServiceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), 
                                                            new StorageSharedKeyCredential(storageAccountName, storageAccountKey), null);


Console.WriteLine("\nCONTAINERS LIST:");
var containers = blobServiceClient.GetBlobContainers();
foreach (var item in containers)
{
  Console.WriteLine(item.Name);
}

Console.WriteLine("\nBLOBS LIST:");

var containerClient = blobServiceClient.GetBlobContainerClient("raster-graphics");
foreach (var blobItem in containerClient.GetBlobs())
{
  Console.WriteLine(blobItem.Name);
}

Console.WriteLine("\nCREATE CONTAINER:");
blobServiceClient.CreateBlobContainer("vector-graphics");

Console.WriteLine("\nUPLOAD FILE IN CONTAINER:");
blobServiceClient.GetBlobContainerClient("vector-graphics").UploadBlob("graph.svg", 
                        File.OpenRead("C:/Users/didaccampanals/Documents/Cursos/Azure/AZ204/Starter/Images/graph.svg"));
