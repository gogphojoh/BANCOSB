using System.Net;
using System.Net.Mail;

namespace BANCOSB;

public class Correo
{
    public dynamic Mandar (string Tipo, Decimal monto)
    {
         DateTime fechaActual = DateTime.Now;
        string remitente = "toni.antonio1109@gmail.com";
        string destinatario = "usuario.sbp200@gmail.com";
        string asunto = "STARTBANK";
        string cuerpoMensaje = $" !! {Tipo} realizado exitosamente!!  \nMonto {monto} \nFecha {fechaActual}  \n Saludos Cordiales  att. STARTBANK S.A de C.V ";

        // Configura el cliente SMTP con el servidor SMTP de Gmail
        SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
        clienteSmtp.Port = 587; // Puerto de Gmail
        clienteSmtp.EnableSsl = true; // Habilita SSL

        
        clienteSmtp.Credentials = new NetworkCredential(remitente, "komq fini nske koxi");

        
        MailMessage mensaje = new MailMessage(remitente, destinatario, asunto, cuerpoMensaje);

        try
        {
        
            clienteSmtp.Send(mensaje);
            return"Correo electrónico enviado correctamente.";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    

}