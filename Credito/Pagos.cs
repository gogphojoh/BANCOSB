using MySql.Data.MySqlClient;
using System;

namespace BANCOSB
{
    public class Pagos
    {
        // Connection string for MySQL database
        string connectionString = "Server=localhost;Database=BancoSB;User ID=root;Password=;";

        // Method to retrieve the debt of a credit card
        public dynamic Versaldo(string numeroCredito)
        {
            string query = "SELECT Deuda FROM Credito WHERE Numero = @Numero";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Numero", numeroCredito);

                    // Execute the query and retrieve the result
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        // Convert result to decimal
                        decimal deuda = Convert.ToDecimal(result);
                        return deuda;
                    }
                    else
                    {
                        return "Error"; // Return error if no result found
                    }
                }
            }
        }

        // Method to pay a debt
        public dynamic PagarTraje(string numeroCredito, decimal Pago)
        {
            // Get current debt
            decimal Cantidad = Versaldo(numeroCredito);
            // Calculate new debt after payment
            decimal nuevaDeuda = Cantidad - Pago;
            
            string query = "UPDATE Credito SET Deuda = @NuevaDeuda WHERE Numero = @Numero";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Update debt with the new value
                    command.Parameters.AddWithValue("@NuevaDeuda", nuevaDeuda);
                    command.Parameters.AddWithValue("@Numero", numeroCredito);

                    // Execute the update query
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return nuevaDeuda; // Return updated debt if the update was successful
                    }
                    else
                    {
                        return false; // Return false if the update failed
                    }
                }
            }
        }
    }
}
