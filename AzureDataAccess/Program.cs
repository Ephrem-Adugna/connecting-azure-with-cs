using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;
using AzureDataAccess;
namespace AzureDataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            // var readBlob = new ReadBlob();
            // //readBlob.GetBlobs("test.txt");
            // var queue =  new Queue();
            //  //queue.SendMessage();
            //queue.ReadMessages();
            ReadTable.GetTable();
            Console.ReadLine();
        }
    }
}
