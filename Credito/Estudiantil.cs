using System.Data.SqlClient;
using BANCOSB.Models;
namespace BANCOSB;

public class Estudiantil
{
    private static string connectionString = "Data Source=UFO;Initial Catalog=BancoSB;Integrated Security=True";

    public dynamic MeseDE(string numeroTarjeta)
    {
        string query = "SELECT MesesEs FROM Credito WHERE Numero = @NumeroTarjeta";
   
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
                   int mesesEs = Convert.ToInt32(result);
                   return mesesEs;
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

    public dynamic DeudaES(string numeroTarjeta)
    {
          string query = "SELECT DeudaEstu FROM Credito WHERE Numero = @NumeroTarjeta";

    
    

    
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
                    decimal deudaEstu = Convert.ToDecimal(result);
                    return deudaEstu;
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
    public dynamic PagosmesES(string numeroTarjeta)
    {
        string query = "SELECT CanDeudaEstu FROM Credito WHERE Numero = @NumeroTarjeta";
    

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
                    decimal cantidadDeudaEstu = Convert.ToDecimal(result);
                    return cantidadDeudaEstu;
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
    public dynamic PagoCons(string numeroTarjeta)
    {
        string query = "SELECT pagoDeuaEs FROM Credito WHERE Numero = @NumeroTarjeta";

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
                    decimal pagoDeudaEstu = Convert.ToDecimal(result);
                    return pagoDeudaEstu;
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
    public dynamic Calmes(string numeroTarjeta,decimal nuevaCanDeudaEstu, int nuevosMesesEs)
    {
         string query = "UPDATE Credito SET MesesEs = @NuevosMesesEs, CanDeudaEstu = @NuevaCanDeudaEstu WHERE Numero = @NumeroTarjeta";

    
    using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            
            command.Parameters.AddWithValue("@NuevosMesesEs", nuevosMesesEs);
            command.Parameters.AddWithValue("@NuevaCanDeudaEstu", nuevaCanDeudaEstu);
            command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

            try
            {
                
                connection.Open();

                
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
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
    public dynamic Vercanti (string numeroTarjeta)
    {
         string query = "SELECT CanDeudaEstu, pagoDeuaEs FROM Credito WHERE Numero = @NumeroTarjeta";


    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {

        command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

        try
        {
    
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                
                decimal CanDeudaEstu = Convert.ToDecimal(reader["CanDeudaEstu"]);
                decimal PagoDeudaEstu = Convert.ToDecimal(reader["pagoDeuaEs"]);

                    
                    return new Estudiante
                    {
                        canDeudaEstu = CanDeudaEstu,
                        pagoDeudaEstu = PagoDeudaEstu
                    };
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

    public dynamic PagoConti(string numeroTarjeta, decimal canti)
    {
        string query = "UPDATE Credito SET pagoDeuaEs = @NuevoValorPagoDeudaEstu WHERE Numero = @NumeroTarjeta";

    
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        
        command.Parameters.AddWithValue("@NuevoValorPagoDeudaEstu", canti);
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

    public dynamic Pagotradi(string numeroTarjeta,int nuevosMesesEs, decimal nuevaDeudaEstu)
    {
        decimal nuevoPagoDeudaEstu = 0;
     string query = "UPDATE Credito SET DeudaEstu = @NuevaDeudaEstu, MesesEs = @NuevosMesesEs, pagoDeuaEs = @NuevoPagoDeudaEstu WHERE Numero = @NumeroTarjeta";


    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        
        command.Parameters.AddWithValue("@NuevaDeudaEstu", nuevaDeudaEstu);
        command.Parameters.AddWithValue("@NuevosMesesEs", nuevosMesesEs);
        command.Parameters.AddWithValue("@NuevoPagoDeudaEstu", nuevoPagoDeudaEstu);
        command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

        try
        {
        
            connection.Open();

        
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
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    }
}