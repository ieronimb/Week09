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
        //Use SQL parameters for that.Print the inserted id(Execute scalar with select identity)  - nu e facut*/

        static void Main(string[] args)
        {
            using (var connection = firstConnection.GetConnection())
            {
                InsertPublisher.NewPublisher(connection, 6, "Carturesti");                
                firstConnection.Dispose(connection);

                Console.ReadKey();
            }        
            
        }
    }
}
