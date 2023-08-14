using Microsoft.Data.SqlClient;

namespace Core
{
    public class DBConnection
    {
        private SqlConnection? conn;

        private DBConnection()
        {

        }

        private DBConnection(String connectiontString)
        {
            try 
            {
                var conn = new SqlConnection(connectiontString);
                conn.Open();
                this.conn = conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static DBConnection? Instance { get; set; }

        public static SqlConnection? Connection
        { 
            get
            {
                return DBConnection.Instance?.conn;
            }
        }

        public static bool Init(String connectiontString)
        {
            DBConnection.Instance = new DBConnection(connectiontString);
            return DBConnection.Connection != null;
        }
    }
}
