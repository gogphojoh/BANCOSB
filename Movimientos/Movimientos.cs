using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BANCOSB.Models;

namespace BANCOSB
{
    public class Movimientos
    {
        string connectionString = "Data Source=UFO;Initial Catalog=BancoSB;Integrated Security=True";

        public List<Movimiento> ReguitarM(string idUsuario, string trajeTP)
        {
            List<Movimiento> movimientos = new List<Movimiento>();
            string query = "SELECT * FROM Movimiento WHERE ID_Usuario = @ID_Usuario AND TrajeTP = @TrajeTP";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                        command.Parameters.AddWithValue("@TrajeTP", trajeTP);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movimiento movimiento = new Movimiento
                                {
                                    Fecha = Convert.ToDateTime(reader["Fecha"]),
                                    Tipo = Convert.ToString(reader["Tipo"]),
                                    Monto = Convert.ToDecimal(reader["Monto"])
                                };
                                movimientos.Add(movimiento);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }

            return movimientos;
        }
    


        
        public dynamic BusID(string Tarjeta)
        {
            

           
            string queryCredito = "SELECT ID_Usuario FROM Credito WHERE Numero = @NumeroTarjeta";
            
          
            string queryDebito = "SELECT ID_Usuario FROM Debito WHERE Numero = @NumeroTarjeta";

           
           

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
               
                    connection.Open();

                    
                    using (SqlCommand commandCredito = new SqlCommand(queryCredito, connection))
                    {
                        
                        commandCredito.Parameters.AddWithValue("@NumeroTarjeta", Tarjeta);

                        
                        object resultCredito = commandCredito.ExecuteScalar();

                        if (resultCredito != null)
                        {
                          
                            return resultCredito;
                        }
                        else
                        {
                           
                            using (SqlCommand commandDebito = new SqlCommand(queryDebito, connection))
                            {
                              
                                commandDebito.Parameters.AddWithValue("@NumeroTarjeta", Tarjeta);

                                
                                object resultDebito = commandDebito.ExecuteScalar();

                                if (resultDebito != null)
                                {
                                   
                                    return resultDebito;
                                }
                                else
                                {
                                  
                                    return"No se encontró ningún usuario con ese número de tarjeta en las tablas Credito y Debito.";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                return"Error: " + ex.Message;
            }
        }
        public dynamic guadarM(int idUsuario, string trajeTP, string tipo, decimal monto )
        {
           
            DateTime fecha = DateTime.Now;
            
           
            string query = "INSERT INTO Movimiento (ID_Usuario, Fecha, Tipo, Monto, TrajeTP) VALUES (@ID_Usuario, @Fecha, @Tipo, @Monto, @TrajeTP)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   
                    connection.Open();

                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                        command.Parameters.AddWithValue("@Fecha", fecha);
                        command.Parameters.AddWithValue("@Tipo", tipo);
                        command.Parameters.AddWithValue("@Monto", monto);
                        command.Parameters.AddWithValue("@TrajeTP", trajeTP);

                        
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
            catch (Exception ex)
            {
               
                return"Error: " + ex.Message;
            }
        }
    }
 
}


    
    
