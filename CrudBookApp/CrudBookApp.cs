using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week09.Classes;
using CrudBookApp.Classes;

namespace CrudBookApp
{
    class CrudBookApp 
    {
        static void Main(string[] args)
        {
            /*4. Create a console app named CrudBookApp to connect to local database.*/

            /*4.1. Use SQL parameters for that -> Not done */
            Console.WriteLine("Please insert the table's name you want to connect:");
            string tableName = Console.ReadLine();

            /*4.2. Print the inserted id (Execute scalar with select identity) -> Not sure that is correct*/
            using (var connection = firstConnection.GetConnection(tableName))
            {               
                Console.WriteLine("2. Enter the Publisher's id:");
                int PublisherId = Convert.ToInt32(Console.ReadLine());
                ExScalar.InsertedId(connection, PublisherId);

                firstConnection.Dispose(connection);
                
            }
            /*Update a book (read id from console) */
            using (var connection = firstConnection.GetConnection(tableName))
            {
                
                Console.WriteLine("a. Enter the book's title:");
                string newTitle = Console.ReadLine();
                Console.WriteLine("b. Enter the book's publisher Id:");
                int newPublisherId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("c. Enter the book's publish year:");
                int newYear = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("d. Enter the book's price:");
                decimal newPrice = Convert.ToDecimal(Console.ReadLine());

                Book.Update(connection, newTitle, newPublisherId, newYear, newPrice);

                firstConnection.Dispose(connection);
            }


            Console.ReadKey();
        }        
    }       
}
