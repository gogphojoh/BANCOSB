using MySql.Data.MySqlClient;
using System;

namespace MySQLConnectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define connection string
            string connectionString = "Server=localhost;Database=BancoSB;User ID=root;Password=;";

            // Create connection
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open connection
                    conn.Open();
                    Console.WriteLine("Connection successful!");

                    // Your SQL queries or operations here

                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
