using SummaryPublisherApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week09.Classes;

namespace SummaryPublisherApp
{
    class SummaryPublisherApp
    {
        /*3.Create a new console app named SummaryPublisherApp. Here print to console:*/
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert the table's name you want to connect:");
            string tableName = Console.ReadLine();
            /*3.1. - Number of rows from the Publisher table (Execute scalar)*/
            using (var connection = firstConnection.GetConnection(tableName))//importat References de la proiectul Week 09
            {               
             
                SqlCommand command = new SqlCommand("select count(*) from Publisher", connection);
                int count = (int)command.ExecuteScalar();
                Console.WriteLine(">Number of rows in <Publisher> table: {0};", count);
            }
            /*3.2. - Top 10 publishers (Id, Name) (SQL Data Reader)*/
            using (var connection = firstConnection.GetConnection(tableName))
            {
                Console.WriteLine("\n>Top 10 publishers from <Publisher> table are:\n");
                Select.getTopTen(connection);
            }

            /*3.3. - Number of books for each publisher (Publiher Name, Number of Books)*/
            using (var connection = firstConnection.GetConnection(tableName))
            {
                Console.WriteLine("Number of books for each publisher are:\n");
                Select.numberOfBooks(connection);
                firstConnection.Dispose(connection);
            }
            /*The total price for books for a publisher*/
            using (var connection = firstConnection.GetConnection(tableName))
            {
                Console.WriteLine(">Enter the Publisher's id:");
                int publisherId = Convert.ToInt32(Console.ReadLine());              
                Select.BookCosts(connection, publisherId);
                firstConnection.Dispose(connection);
            }
            Console.ReadKey();
        }           
    }
}
