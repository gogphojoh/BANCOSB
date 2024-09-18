using System.Data.SqlClient;
using BANCOSB.Models;
namespace BANCOSB;

public class Hipoteca
{
    string connectionString = "Server=localhost;Database=BancoSB;User ID=root;Password=;";

    public dynamic AdedoC(string numeroTarjeta)
    {
         string query = "SELECT adeudoC FROM Credito WHERE Numero = @NumeroTarjeta";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {

            command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

            try
            {
                connection.Open();
                
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    decimal adeudoC = Convert.ToDecimal(result);

                   return adeudoC;
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
    public dynamic MesPagoC(string numeroTarjeta)
    {
        string query = "SELECT mesC FROM Credito WHERE Numero = @NumeroTarjeta";

        
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            
            command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

            try
            {
            
                connection.Open();

                
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    decimal mesC = Convert.ToDecimal(result);
                    return mesC;
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

    public dynamic modPagoMC(string numeroTarjeta,decimal nuevoMesC)
    {
          string query = "UPDATE Credito SET mesC = @NuevoMesC WHERE Numero = @NumeroTarjeta";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
        
            command.Parameters.AddWithValue("@NuevoMesC", nuevoMesC);
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

    public dynamic PagoCapi(string numeroTarjeta)
    {
        string query = "SELECT mesC, pagoCapiC FROM Credito WHERE Numero = @NumeroTarjeta";

        
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
                    
                    decimal MesC = Convert.ToDecimal(reader["mesC"]);
                    decimal PagoCapiC = Convert.ToDecimal(reader["pagoCapiC"]);

                    return new HipoCasa
                    {
                        mesC = MesC,
                        pagoCapiC = PagoCapiC
                    };
                }
                else
                {
                    return "No se encontró ningún registro para el número de tarjeta proporcionado.";
                }
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
    
    public dynamic Pagoscapi(string numeroTarjeta,decimal nuevoPagoCapi )
    {
          string query = "UPDATE Credito SET pagoCapiC = @NuevoPagoCapi WHERE Numero = @NumeroTarjeta";


        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
    
            command.Parameters.AddWithValue("@NuevoPagoCapi", nuevoPagoCapi);
            command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

            try
            {
    
                connection.Open();

            
                int rowsAffected = command.ExecuteNonQuery();

            
                if (rowsAffected > 0)
                {
                    return nuevoPagoCapi;
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

    public dynamic CanCapi (string numeroTarjeta)
    {
        string query = "SELECT pagoCapiC FROM Credito WHERE Numero = @NumeroTarjeta";
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
                decimal pagoCapiCActual = Convert.ToDecimal(result);
                return pagoCapiCActual;
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

    public dynamic PcompletoC(string numeroTarjeta,decimal nuevoAdeudoC)
    {
        decimal nuevoPagoCapiC = 0;

         string query = "UPDATE Credito SET pagoCapiC = @NuevoPagoCapiC, adeudoC = @NuevoAdeudoC WHERE Numero = @NumeroTarjeta";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
    
            command.Parameters.AddWithValue("@NuevoPagoCapiC", nuevoPagoCapiC);
            command.Parameters.AddWithValue("@NuevoAdeudoC", nuevoAdeudoC);
            command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

            try
            {
    
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                
                if (rowsAffected > 0)
                {
                    return nuevoAdeudoC;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return  ex.Message;
            }
        }
    }
    public dynamic AdeudoH(string numeroTarjeta)
    {
          string query = "SELECT adeudoH FROM Credito WHERE Numero = @NumeroTarjeta";

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
                decimal adeudoH = Convert.ToDecimal(result);
                return adeudoH;
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

    public dynamic mesH(string numeroTarjeta)
    {
    
        string query = "SELECT mesH FROM Credito WHERE Numero = @NumeroTarjeta";


        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            
            command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

            try
            {
        
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null)
                {
    
                    decimal mesH = Convert.ToDecimal(result);

                    return mesH;
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

    public dynamic ModmesH(string numeroTarjeta, decimal nuevoMesH)
    {
        string query = "UPDATE Credito SET mesH = @NuevoMesH WHERE Numero = @NumeroTarjeta";

    
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        
        command.Parameters.AddWithValue("@NuevoMesH", nuevoMesH);
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

    public dynamic PagoComH(string numeroTarjeta)
    {
        string query = "SELECT mesH, pagoHipoteca FROM Credito WHERE Numero = @NumeroTarjeta";

  
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(query, connection))
    {
        
        command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

        try
        {
            
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                
                  if (reader.Read())
                {
            
                    decimal MesH = Convert.ToDecimal(reader["mesH"]);
                    decimal PagoHipoteca = Convert.ToDecimal(reader["pagoHipoteca"]);

        
                    return new HipoH
                    {
                        mesH = MesH,
                        pagoHipoteca = PagoHipoteca
                    };
                }
                else
                {
                    return "No se encontró ningún registro para el número de tarjeta proporcionado.";
                }
            }
        }
        catch (Exception ex)
        {
           return ex.Message;
        }
    }
    }

    public dynamic PagoHipo(string numeroTarjeta,decimal nuevoPagoHipoteca)
    {
         string query = "UPDATE Credito SET pagoHipoteca = @NuevoPagoHipoteca WHERE Numero = @NumeroTarjeta";

        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            
            command.Parameters.AddWithValue("@NuevoPagoHipoteca", nuevoPagoHipoteca);
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
    public dynamic CamHipo(string numeroTarjeta)
    {
         string query = "SELECT pagoHipoteca FROM Credito WHERE Numero = @NumeroTarjeta";

  
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
                   decimal pagoHipoteca = Convert.ToDecimal(result);
                   return pagoHipoteca;
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

    public dynamic PagoComHi(string numeroTarjeta, decimal nuevoAdeudoH)
    {
        decimal nuevoPagoCapital = 0;
        string query = "UPDATE Credito SET adeudoH = @NuevoAdeudoH, pagoHipoteca = @NuevoPagoHipoteca WHERE Numero = @NumeroTarjeta";


        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            
            command.Parameters.AddWithValue("@NuevoAdeudoH", nuevoAdeudoH);
            command.Parameters.AddWithValue("@NuevoPagoHipoteca ", nuevoPagoCapital);
            command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

            try
            {
                
                connection.Open();

            
                int rowsAffected = command.ExecuteNonQuery();

                
                if (rowsAffected > 0)
                {
                    return nuevoAdeudoH;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return  ex.Message;
            }
        }
    }
}