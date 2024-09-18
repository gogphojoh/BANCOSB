namespace BANCOSB;
using System.Data.SqlClient;
using BANCOSB.Models;

class Servicio
{
     private static string connectionString = "Data Source=UFO;Initial Catalog=BancoSB;Integrated Security=True";
    public  dynamic Cantiada_S (string numeroServicio)
    {
        
         

        try
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                string query = "SELECT Cantida, TipoSE FROM Servicios WHERE S_Numeros = @NumeroServicio";

                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    command.Parameters.AddWithValue("@NumeroServicio", numeroServicio);

                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        
                        if (reader.Read())
                        {
                            decimal cantidad = reader.GetDecimal(0);
                            string tipoServicio = reader.GetString(1);

                            return new Servicios
                            {
                                Cantidad = cantidad,
                                TipoSE = tipoServicio
                            };

                        }
                        else
                        {
                           
                            return false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return false;
        }
    
    }

    public dynamic Can_Pagar (string NumeroS, Decimal Cantiada, decimal total)
    {
        decimal Cambio = Cantiada-total;
        string query = "UPDATE Servicios SET Cantida = @NuevaCantidad WHERE S_Numeros = @NumeroServicios";
         using (SqlConnection connection = new SqlConnection(connectionString))
        {
            
            
            connection.Open();
            
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@NuevaCantidad", Cambio);
                command.Parameters.AddWithValue("@NumeroServicios", NumeroS);

                
                int rowsAffected = command.ExecuteNonQuery();

                
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}