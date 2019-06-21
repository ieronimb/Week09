using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp.Classes
{
    public class Select
    {
        int PublisherId { get; set; }


        /*  https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/retrieving-data-using-a-datareader  */
        public static void getTopTen(SqlConnection connection)
        {
            using (connection)
            {
                using (SqlCommand command = new SqlCommand("select top 10 PublisherId, Name from Publisher", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        Console.WriteLine("{0}\t\t{1}", reader.GetName(0), reader.GetName(1));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t\t{1}", reader.GetInt32(0), reader.GetString(1));
                        }
                        reader.NextResult();
                    }
                    reader.Close();
                }
            }
        }



        public static void numberOfBooks(SqlConnection connection)
        {
            using (connection)
            {

                using (SqlCommand command = new SqlCommand("select        p.Name, " +
                                                                        " count(b.BookId) as NumberofBooks" +
                                                                        " from Publisher p left join Book b on p.PublisherId = b.PublisherId" +
                                                                        " Group by p.Name", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        Console.WriteLine("{0}\t\t{1}", reader.GetName(0), reader.GetName(1));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t\t{1}", reader.GetString(0), reader.GetInt32(1));
                        }
                        reader.NextResult();
                    }
                    reader.Close();
                }
            }
        }     


               
        public static void BookCosts(SqlConnection connection, int publisherId)
        {
            using (connection)
            {

                using (SqlCommand command = new SqlCommand("select        p.Name, " +
                                                                        " sum(b.Price) as TotalPrice" +
                                                                        " from Publisher p left join Book b on p.PublisherId = b.PublisherId" +
                                                                        " Group by p.Name", connection))
                {

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.HasRows)
                    {
                        Console.WriteLine("{0}\t\t{1}", reader.GetName(0), reader.GetName(1));

                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t\t{1}", reader.GetString(0), reader.GetDecimal(1));
                        }
                        reader.NextResult();
                    }
                    reader.Close();
                }
            }
        }
    }
}
