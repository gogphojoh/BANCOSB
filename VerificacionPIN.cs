using MySql.Data.MySqlClient;
using System;

namespace BANCOSB
{
    public class Verificacion
    {
        // Connection string for MySQL database
        private static string connectionString = "Server=localhost;Database=BancoSB;User ID=root;Password=;";

        // Method to verify the card number (either credit or debit)
        public bool Verificacion_T(string numeroTarjeta)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check if card number exists in the Credito table
                    string queryCredito = "SELECT COUNT(*) FROM Credito WHERE Numero = @Numero";
                    using (MySqlCommand command = new MySqlCommand(queryCredito, connection))
                    {
                        command.Parameters.AddWithValue("@Numero", numeroTarjeta);
                        int countCredito = Convert.ToInt32(command.ExecuteScalar());
                        if (countCredito > 0)
                        {
                            return true;
                        }
                    }

                    // Query to check if card number exists in the Debito table
                    string queryDebito = "SELECT COUNT(*) FROM Debito WHERE Numero = @Numero";
                    using (MySqlCommand command = new MySqlCommand(queryDebito, connection))
                    {
                        command.Parameters.AddWithValue("@Numero", numeroTarjeta);
                        int countDebito = Convert.ToInt32(command.ExecuteScalar());
                        if (countDebito > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }

            return false;
        }

        // Method to verify both the card number and PIN
        public dynamic Verificar_P(string numeroTarjeta, string pin)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check card number and PIN in the Credito table
                    string queryCredito = "SELECT COUNT(*) FROM Credito WHERE Numero = @Numero AND PIN = @PIN";
                    using (MySqlCommand command = new MySqlCommand(queryCredito, connection))
                    {
                        command.Parameters.AddWithValue("@Numero", numeroTarjeta);
                        command.Parameters.AddWithValue("@PIN", pin);
                        int countCredito = Convert.ToInt32(command.ExecuteScalar());
                        if (countCredito > 0)
                        {
                            return "C"; // Return "C" if it's a credit card
                        }
                    }

                    // Query to check card number and PIN in the Debito table
                    string queryDebito = "SELECT COUNT(*) FROM Debito WHERE Numero = @Numero AND PIN = @PIN";
                    using (MySqlCommand command = new MySqlCommand(queryDebito, connection))
                    {
                        command.Parameters.AddWithValue("@Numero", numeroTarjeta);
                        command.Parameters.AddWithValue("@PIN", pin);
                        int countDebito = Convert.ToInt32(command.ExecuteScalar());
                        if (countDebito > 0)
                        {
                            return "D"; // Return "D" if it's a debit card
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al verificar el PIN: " + ex.Message);
                }
            }

            return false;
        }
    }
}
