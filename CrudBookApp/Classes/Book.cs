using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBookApp.Classes
{
    public class Book
    {
        
        string newTitle { get; set;}
        int newPublisherId { get; set; }
        int newYear { get; set; }
        decimal newPrice { get; set; }


        public static void Update(SqlConnection connection, string newTitle, int newPublisherId, int newYear, decimal newPrice)
        {
            try
            {                
                using (connection)
                {                    
                    using (SqlCommand command = new SqlCommand("UPDATE Book SET Title=@newTitle, PublisherId=@newPublisherId, " +
                                                                "Year=@newYear, Price=@newPrice", connection))
                    {                     
                                                
                        command.Parameters.AddWithValue("@newTitle", newTitle);
                        command.Parameters.AddWithValue("@newPublisherId", newPublisherId);
                        command.Parameters.AddWithValue("@newYear", newYear);
                        command.Parameters.AddWithValue("@newPrice", newPrice);



                        /*Number of rows*/
                        int rows =Convert.ToInt32(command.ExecuteNonQuery());
                        Console.WriteLine(rows);                       
                    }
                }
            }
            catch (SqlException ex)

            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
