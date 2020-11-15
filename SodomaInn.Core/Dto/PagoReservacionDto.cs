using System;
using System.Collections.Generic;
using System.Text;

namespace SodomaInn.Core.Dto
{
    public class PagoReservacionDto
    {
        public int IdPago { get; set; }
        public string FormaPago { get; set; }
        public decimal MontoPago { get; set; }
        public decimal Comision { get; set; }
        public string Referencia { get; set; }
        public int IdReservacion { get; set; }
    }
}
