using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Week09.Classes
{
    public class InsertPublisher
    {
        public static void NewPublisher(SqlConnection connection, int publisherId, string name)
        {
            try
            {

                var selectString = @"INSERT INTO [dbo].[Publisher]
                                                ([PublisherId]
                                                ,[Name])
                                     VALUES
                                                (@publisherId
                                                ,@name);
                                    SELECT CAST(scope_identity() AS int)";

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = selectString
                };

                SqlParameter nameSqlParameter = new SqlParameter
                {
                    DbType = DbType.String,
                    ParameterName = "name",
                    Value = name
                };

                SqlParameter publisherIdSqlParameter = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "publisherId",
                    Value = publisherId
                };

                command.Parameters.Add(nameSqlParameter);
                command.Parameters.Add(publisherIdSqlParameter);         
                         
                int returnedValue = (int)command.ExecuteScalar();

                Console.WriteLine(returnedValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
