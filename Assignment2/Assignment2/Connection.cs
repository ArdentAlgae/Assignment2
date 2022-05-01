using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Assignment2
{
    class Connection
    {
        private const string db = "hris";
        private const string username = "kit206g2a";
        private const string password = "group2a";
        private const string server = "alacritas.cis.utas.edu.au";

        public static void readData(string table, string[] columns)
        {
            MySqlDataReader reader = null;
            MySqlConnection conn;
            string commandString;

            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, username, password);
            conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                commandString = String.Format("select {0} from {1}", String.Join(", ", columns), table);
                MySqlCommand command = new MySqlCommand(commandString, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1}", reader[0], reader.GetString(1));
                }
            }
            catch 
            {
                Console.WriteLine("Database error");
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
