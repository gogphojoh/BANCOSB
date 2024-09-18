using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace BANCOSB.Controllers;

[ApiController]
[Route("Tarjeta")]
public class ClienteController : ControllerBase
{
    Verificacion VER = new Verificacion();
    Deposito TrajetaD = new Deposito();
    Servicio SERV = new Servicio();
    Movimientos HistoriaM = new Movimientos();
    Pagos Pago = new Pagos();
    Hipoteca Hipo = new Hipoteca();
    Estudiantil Estu = new Estudiantil();
    Anualidad Anu = new Anualidad();
    Correo Nota = new Correo();

    [HttpGet]
    [Route("Verificar")]
    public  bool VerificarTarjeta(string numeroTarjeta)
        {
           bool Respuesta = VER.Verificacion_T(numeroTarjeta);
           return Respuesta;
        }


    [HttpGet]
    [Route("VerificacionPIN")]
        public dynamic VerificarPIN(string numeroTarjeta, string pin)
        {
         
            dynamic Respuesta = VER.Verificar_P(numeroTarjeta, pin);
            return Respuesta;
        }

        [HttpGet]
        [Route("VerSaldo")]
        public IActionResult VerSaldo(string Tarjeta)
        {
            try
            {
                decimal saldo = TrajetaD.Saldo(Tarjeta);
                return Ok(new { saldo = saldo });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { error = "Internal Server Error", details = ex.Message });
            }
        }


    [HttpPost("numeroTarjeta")]
    [Route("Deposito")]
     public decimal ActualizarSaldo(string numeroTarjeta, decimal Deposito)
    {
        decimal Cantiada = TrajetaD.Depositar(numeroTarjeta, Deposito);
        int ID = HistoriaM.BusID(numeroTarjeta);
        HistoriaM.guadarM(ID,"D","Deposito",Deposito);
        Nota.Mandar("Deposito",Deposito);
        return Cantiada;


    }
    [HttpPost("numeroTarjeta")]
    [Route("Retiro")]
    public decimal RetiroD(string numeroTarjeta, decimal Retiros)
    {   
        decimal Cantiada = TrajetaD.Retiro(numeroTarjeta, Retiros);
        int ID = HistoriaM.BusID(numeroTarjeta);
        HistoriaM.guadarM(ID,"D","Retiros",Retiros);
        Nota.Mandar("Retiros",Retiros);
        return Cantiada;
        
    }
    [HttpPost("numeroTarjeta")]
    [Route("CambioPIN")]
    public dynamic CambioPIN(string numeroTarjeta, string NuevoPIN)
    {
        bool Validar = TrajetaD.ValidarPin(NuevoPIN);
        int ID = HistoriaM.BusID(numeroTarjeta);
        HistoriaM.guadarM(ID,"D","CambioPIN",0);
        Nota.Mandar("CambioPIN",0);
        if (Validar == true)
        {
        dynamic Cambio = TrajetaD.CambioPin(NuevoPIN,numeroTarjeta);
        return Cambio;  
        }
        else
        {
            return false;
        }

    }
          
        

    [HttpGet]
    [Route("ServicioEX")]
        public dynamic ServicioI(string numeroServicio)
        {
            
           dynamic servicioInfo = SERV.Cantiada_S(numeroServicio);
           return servicioInfo;
            

            
        }

    [HttpPost("numero")]
    [Route("PagoS")]
    public dynamic Pago_Se(string numero,decimal pago, decimal Cantotal)
    {
        dynamic Pago = SERV.Can_Pagar(numero, pago,Cantotal);
        return Pago;
    }
    

    
    [HttpGet]
    [Route("Historial")]
    public dynamic Histo (string numeroTarjeta, string TipoT)
    {
        int ID1 = HistoriaM.BusID(numeroTarjeta);
        string ID = Convert.ToString(ID1);
       dynamic Reguis = HistoriaM.ReguitarM(ID,TipoT);
       
       return Reguis;
    }

    [HttpGet]
    [Route("CreSal")]
    public dynamic SaldoCre(string numeroCredito)
    {
        
        dynamic Saldo = Pago.Versaldo(numeroCredito);
        return Saldo;
    }

    [HttpPost("numero")]
    [Route("Pagocredi")]
    public dynamic pagoCredi(string numero, decimal cantidad)
    {
        Nota.Mandar("Pago de trajeta",cantidad);
        dynamic resul= Pago.PagarTraje(numero, cantidad);
        
        return resul;
    }
    // Hipoteca
    [HttpGet]
    [Route("AutoHC")]
    public dynamic AutoHC(string numeroCredito)
    {
        
        decimal AdedoC = Hipo.AdedoC(numeroCredito);
        return AdedoC;
    }

    [HttpPost("numero")]
    [Route("VerpagoC")]
    public dynamic VerpagoC(string numero)
    {   
        decimal AdedoC = Hipo.AdedoC(numero);   
        decimal MesPagoC = Hipo.MesPagoC(numero);
        if(MesPagoC == 0)
        {
            decimal NewMesPC=AdedoC/12;
            Hipo.modPagoMC(numero,NewMesPC);
            dynamic resul = Hipo.PagoCapi(numero);
            return resul;

        }
        else
        {
            dynamic resul = Hipo.PagoCapi(numero);
             return resul;
        }

       
    }
    [HttpPost("numero")]
    [Route("CapitarC")]
    public dynamic CapitarC(string numero, decimal canti)
    {
        dynamic resul = Hipo.Pagoscapi(numero,canti);
        return resul;
    }
     [HttpPost("numero")]
    [Route("PagocomC")]
    public dynamic PagocomC(string numero, decimal canti)
    {
        dynamic adeudo = Hipo.AdedoC(numero);
        dynamic Capi = Hipo.CanCapi(numero);
        decimal newCan= adeudo-(canti+Capi);

        dynamic resul = Hipo.PcompletoC(numero,newCan);
        return resul;
        
    }
     [HttpGet]
    [Route("casaHC")]
    public dynamic casaHC(string numeroCredito)
    {
        
        decimal AdedoH = Hipo.AdeudoH(numeroCredito);
        return AdedoH;
    }

    [HttpPost("numero")]
    [Route("VerpagoH")]
    public dynamic VerpagoH(string numero)
    {   
        decimal AdeudoH = Hipo.AdeudoH(numero);   
        decimal MesPagoH = Hipo.mesH(numero);
        if(MesPagoH == 0)
        {
            decimal NewMesPH=AdeudoH/12;
            Hipo.ModmesH(numero,NewMesPH);
            dynamic resul = Hipo.PagoComH(numero);
            return resul;

        }
        else
        {
            dynamic resul = Hipo.PagoComH(numero);
             return resul;
        }
    }
     [HttpPost("numero")]
    [Route("CapitarH")]
    public dynamic CapitarH(string numero, decimal canti)
    {
        dynamic resul = Hipo.PagoHipo(numero,canti);
        return resul;
    }

    [HttpPost("numero")]
    [Route("PagocomH")]
    public dynamic PagocomH(string numero, decimal canti)
    {
        dynamic adeudo = Hipo.AdeudoH(numero);
        dynamic Capi = Hipo.CamHipo(numero);
        decimal newCan= adeudo-(canti+Capi);

        dynamic resul = Hipo.PagoComHi(numero,newCan);
        return resul;
        
    }

    [HttpPost("numero")]
    [Route("Deuestu")]
    public dynamic Deuestu(string numero)
    {
        int tiempo = Estu.MeseDE(numero);
        return tiempo;
        
    }
    [HttpPost("numero")]
    [Route("MesesEs")]
    public dynamic MesesEs(string numero, int tiempo)
    {
        decimal canti= Estu.DeudaES(numero);
        decimal newpago=canti/tiempo;
        dynamic resul = Estu.Calmes(numero,newpago,tiempo);
        return resul;
        
        
    }

    [HttpGet]
    [Route("VerCantiEs")]
    public dynamic VerCantiEs(string numero)
    {
        dynamic Cantiades = Estu.Vercanti(numero);
        return Cantiades;
    }
    [HttpPost("numero")]
    [Route("PagoConti")]
    public dynamic PagoConti(string numero, int Canti)
    {
        bool resul = Estu.PagoConti(numero,Canti);
        return resul;
    }

    [HttpPost("numero")]
    [Route("PagoTradi")]
    public dynamic PagoTradi(string numero, int Canti)
    {
        int tiempo = Estu.MeseDE(numero);
        int newTiem = tiempo-1;
        decimal deuda = Estu.DeudaES(numero);
        decimal pagoCa =Estu.PagoCons(numero);
        decimal newdeuda = deuda - (Canti+pagoCa);
        dynamic resul = Estu.Pagotradi (numero,newTiem,newdeuda);
        
        return resul;
    }


     [HttpGet]
    [Route("VerAnual")]
    public dynamic VerAnual(string numero)
    {
        dynamic Cantiades = Anu.Tipo(numero);
        if (Cantiades == "Y")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [HttpPost("numero")]
    [Route("NoPago")]
    public dynamic NoPago(string numero)
    {
       dynamic Canti=Anu.Anul(numero);
       decimal DeuN = Canti*0.965m;
        int resul= Convert.ToInt32(DeuN);
        return resul;

    }
    [HttpPost("numero")]
    [Route("PagoAnu")]
    public dynamic PagoAnu(string numero)
    {
       dynamic Canti=Anu.Anul(numero);
      return Canti;

    }





}




        
    
    


