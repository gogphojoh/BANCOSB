using System.Data.SqlClient;
using BANCOSB.Models;
namespace BANCOSB;

public class Anualidad
{
    private static string connectionString = "Data Source=UFO;Initial Catalog=BancoSB;Integrated Security=True";

    public dynamic Tipo(string numeroTarjeta)
    {

string query = "SELECT PagoAnu FROM Credito WHERE Numero = @NumeroTarjeta";


    using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {

            command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

            try
            {
    
                connection.Open();

                
                object result = command.ExecuteScalar();

            
                if (result != null && result != DBNull.Value)
                {
                    string pagoAnu = Convert.ToString(result);
                    return pagoAnu;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    public dynamic Anul(string numeroTarjeta)
    {
        
    string query = "SELECT anualidad FROM Credito WHERE Numero = @NumeroTarjeta";

   
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {
    
        command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

        try
        {
        
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                decimal  anualidad = Convert.ToDecimal(result);
                return anualidad;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
           return ex.Message;
        }
    }
    }

    public dynamic ModAnul(string numeroTarjeta,decimal Canti)
    {
         string query = "UPDATE Credito SET anualidad = @NuevoValorAnualidad WHERE Numero = @NumeroTarjeta";

    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        
        command.Parameters.AddWithValue("@NuevoValorAnualidad", Canti);
        command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

        try
        {
        
            connection.Open();

            
            int filasAfectadas = command.ExecuteNonQuery();

            
            if (filasAfectadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    }
}
