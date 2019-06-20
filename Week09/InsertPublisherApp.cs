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
        /*With this console read the name of publisher and insert a new publisher to database.
        //Use SQL parameters for that. Print the inserted id(Execute scalar with select identity)  - nu e facut*/

        static void Main(string[] args)
        {
            using (var connection = firstConnection.GetConnection())
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
