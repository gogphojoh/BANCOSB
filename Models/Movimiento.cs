using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BANCOSB.Models
{
    public class Movimiento
    {
        
        public DateTime Fecha { get; set; }
        public string? Tipo { get; set; }
        public decimal Monto { get; set; }
    
    }
}