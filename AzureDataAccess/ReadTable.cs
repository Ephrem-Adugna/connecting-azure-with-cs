using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace AzureDataAccess
{
   public static class ReadTable
    {
        public static void InsertToTable()
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            TableServiceClient tableClient = new TableServiceClient(connectionString);
            var table = tableClient.GetTableClient("Students");
            var entity = new TableEntity("Students", "1")
{
    { "Fname", "Ephrem" },
    { "Lname", "Adugna" },
    { "Age", 15 }
};
            table.AddEntity(entity);
        }
        public static void GetTable()
        {
            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            TableServiceClient tableClient = new TableServiceClient(connectionString);
            var table = tableClient.GetTableClient("Students");
            var entity = table.GetEntity<StudentModel>("Students", "1");
            Console.WriteLine($"Fname: {entity.Value.Fname}, Lname: {entity.Value.Lname}, Age: {entity.Value.Age}");
        }
    }
}
