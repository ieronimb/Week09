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
            /*3.1. - Number of rows from the Publisher table (Execute scalar)*/
            using (var connection = firstConnection.GetConnection())//importat References de la proiectul Week 09
            {               
             
                SqlCommand command = new SqlCommand("select count(*) from Publisher", connection);
                int count = (int)command.ExecuteScalar();
                Console.WriteLine(">Number of rows in <Publisher> table: {0};", count);
            }
            /*3.2. - Top 10 publishers (Id, Name) (SQL Data Reader)*/
            using (var connection = firstConnection.GetConnection())
            {
                Console.WriteLine("\n>Top 10 publishers from <Publisher> table are:\n");
                getTopTen(connection);
            }

            /*3.3. - Number of books for each publisher (Publiher Name, Number of Books)*/
            using (var connection = firstConnection.GetConnection())
            {
                Console.WriteLine("Number of books for each publisher are:\n");
                numberOfBooks(connection);
                firstConnection.Dispose(connection);
            }

            /*The total price for books for a publisher*/
            using (var connection = firstConnection.GetConnection())
            {
                Console.WriteLine(">Enter the Publisher's id:");
                int publisherId = Convert.ToInt32(Console.ReadLine());              
                PublisherCostBook(connection, publisherId);

                firstConnection.Dispose(connection);
            }
            Console.ReadKey();
        }





        /*  https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader  */
        static void getTopTen(SqlConnection connection)
        {
            using (connection)
            {
                using(SqlCommand command = new SqlCommand("select top 10 PublisherId, Name from Publisher", connection))
                {                 
                  
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        Console.WriteLine("{0}\t\t{1}", reader.GetName(0),reader.GetName(1));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t\t{1}", reader.GetInt32(0),reader.GetString(1));
                        }
                        reader.NextResult();
                    }
                    //reader.Close();
                }
            }
        }


        static void numberOfBooks(SqlConnection connection)
        {
            using (connection)
            {
               
                using (SqlCommand command = new SqlCommand("select        p.Name, " +
                                                                        " count(b.BookId) as NumberofBooks"+
                                                                        " from Publisher p left join Book b on p.PublisherId = b.PublisherId" +
                                                                        " Group by p.Name", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        Console.WriteLine("{0}\t\t{1}", reader.GetName(0),reader.GetName(1));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t\t{1}", reader.GetString(0),reader.GetInt32(1));
                        }
                        reader.NextResult();
                    }
                    reader.Close();
                }
            }
        }

        public static void PublisherCostBook(SqlConnection connection, int publisherId)
        {
            try
            {

                var selectString = "SELECT * FROM Book";
                                           


                selectString += string.Format($"Where PublisherId = @PublisherId;" +
                                             $"SELECT CAST(scope_identity() AS int)");

                SqlCommand command = new SqlCommand
                {


                    Connection = connection,
                    CommandText = selectString
                };               

                SqlParameter publisherIdSqlParameter = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "publisherId",
                    Value = publisherId
                };               
                command.Parameters.Add(publisherIdSqlParameter);

                var returnedValue = command.ExecuteScalar();

                Console.WriteLine(returnedValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
