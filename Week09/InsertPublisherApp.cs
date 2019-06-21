using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Week09.Classes;


namespace Week09
{
    class InsertPublisherApp
    {
        /*1. Create a console app named InsertPublisherApp to connect to local database.
          2. With this console read the name of publisher and insert a new publisher to database.
          2.1. Use SQL parameters for that. 
          2.2. Print the inserted id(Execute scalar with select identity)  -> Not done*/

        static void Main(string[] args)
        {
            Console.WriteLine("Please insert the table's name you want to connect:");
            string tableName = Console.ReadLine();
            using (var connection = firstConnection.GetConnection(tableName))
            {   
                
                Console.WriteLine("1. Enter the Publisher's name:");
                string name = Console.ReadLine();
                Console.WriteLine("2. Enter the Publisher's id:");
                int PublisherId = Convert.ToInt32(Console.ReadLine());
                InsertPublisher.NewPublisher(connection, PublisherId, name);
                Console.WriteLine($"The {name} publisher with id: {PublisherId} was added to <Publisher> table.");
                firstConnection.Dispose(connection);

                Console.ReadKey();
            }        
            
        }
    }
}
