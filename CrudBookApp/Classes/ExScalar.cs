using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBookApp.Classes
{
    public class ExScalar
    {
        int id { get; set; }

        public static void InsertedId(SqlConnection connection, int id)
        {
            try
            {                              
                SqlCommand command = new SqlCommand("Select publisherId, Name from [Publisher] where publisherId=@id", connection);
               
                SqlParameter nameSqlParameter = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "id",
                    Value = id
                };
                command.Parameters.AddWithValue("@id", id);
                int returnedValue = Convert.ToInt32(command.ExecuteScalar());
                Console.WriteLine(returnedValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
