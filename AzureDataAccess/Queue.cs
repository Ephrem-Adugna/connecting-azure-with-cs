using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;
namespace AzureDataAccess
{
    class Queue
    {
       

        public void SendMessage()
        {
            
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            QueueClient queueClient = new QueueClient(connectionString, "smsqueue");
            if (queueClient.Exists())
            {
                for (int i = 0; i < 10; i++)
                {
                    var student = new StudentModel();
                    student.Fname = "FNAME " + i;
                    student.Lname = "LNAME " + i;
                    queueClient.SendMessage($"{student.Fname} {student.Lname}");

                }
            }

        }
        public void ReadMessages()
        {

            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            QueueClient queueClient = new QueueClient(connectionString, "smsqueue");
         
                var message = queueClient.ReceiveMessage();
            Console.WriteLine(message.Value.Body);

        }
    }
}
