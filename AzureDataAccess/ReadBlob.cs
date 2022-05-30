using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDataAccess
{
    class ReadBlob
    {
       public async void GetBlobs(string blobName)
        {
            Console.WriteLine("Hello World!");
            string containerName = "students";
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blob = containerClient.GetBlobClient(blobName);
            var response = await blob.DownloadAsync();
            using (var streamReader = new StreamReader(response.Value.Content))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = await streamReader.ReadLineAsync();
                    Console.WriteLine(line);
                }
            }
        }
       
    }
}
