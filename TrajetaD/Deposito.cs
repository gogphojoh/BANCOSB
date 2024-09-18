using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace BANCOSB;

public class Deposito
{
    private static string connectionString = "Data Source=UFO;Initial Catalog=BancoSB;Integrated Security=True";
    public decimal Saldo(string Tarjeta)
    {
        
        string query = "SELECT Saldo FROM Debito WHERE Numero = @NumeroTarjeta";

            // Establecer la conexión a la base de datos y ejecutar la consulta
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NumeroTarjeta", Tarjeta);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        
                        decimal saldo = reader.GetDecimal(0);
                        
                        return saldo;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    
                    return 0;
                }
            }
    }
    
    public void InDatos()
    {
        
    }
    public dynamic Depositar(string Tarjeta, decimal Cantiada)
    {
        
        decimal saldo = Saldo(Tarjeta);
        decimal ActualizarSaldo1 =   saldo + Cantiada;
        string query = "UPDATE Debito SET Saldo = @ActualizarSaldo1 WHERE Numero = @NumeroTarjeta";
        
         using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@ActualizarSaldo1", ActualizarSaldo1);
                command.Parameters.AddWithValue("@NumeroTarjeta", Tarjeta);

                
                int rowsAffected = command.ExecuteNonQuery();

                
                
                return  ActualizarSaldo1;
            }
        
        }
    }

    public dynamic Retiro(string Tarjeta, decimal Cantiada)
    {
        
        decimal saldo = Saldo(Tarjeta);
        decimal ActualizarSaldo1 =   saldo - Cantiada;
        string query = "UPDATE Debito SET Saldo = @ActualizarSaldo1 WHERE Numero = @NumeroTarjeta";
        
         using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                
                command.Parameters.AddWithValue("@ActualizarSaldo1", ActualizarSaldo1);
                command.Parameters.AddWithValue("@NumeroTarjeta", Tarjeta);

                
                int rowsAffected = command.ExecuteNonQuery();

                
                
                return  ActualizarSaldo1;
            }
        
        }
    }
     public dynamic CambioPin(string NuevoPIN, string numeroTarjeta)
    {
        
         string query = "UPDATE Debito SET PIN = @NuevoPIN WHERE Numero = @NumeroTarjeta";

        
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            
            using (SqlCommand command = new SqlCommand(query, connection))
            {
             
                command.Parameters.AddWithValue("@NuevoPIN", NuevoPIN);
                command.Parameters.AddWithValue("@NumeroTarjeta", numeroTarjeta);

               
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
    public dynamic ValidarPin (string NuevoPIN)
    {
        foreach (char caracter in NuevoPIN)
        {
            if (!char.IsDigit(caracter)) 
            {
                return false; 
            }
        }
        return true; 
    }
}