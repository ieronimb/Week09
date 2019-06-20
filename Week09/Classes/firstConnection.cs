using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Week09.Classes
{
    public class firstConnection
    {
        /*1. Create a console app named InsertPublisherApp to connect to local database.*/

        //-- Code for a connection object
        public static SqlConnection GetConnection()
        {
            string stringConnect = "Data Source=.;Initial Catalog=Week9;Integrated Security=True";
            SqlConnection connect = new SqlConnection(stringConnect);
            connect.Open();
            return connect;
        }

        //-- To close the connection and dispose object
        public static void Dispose(SqlConnection connect)
        {
            if (connect.State == System.Data.ConnectionState.Open)
                connect.Close();
                connect.Dispose();
        }
    }
}

