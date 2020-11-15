using System;
using System.Collections.Generic;
using System.Text;

namespace SodomaInn.Core.Dto
{
    public class ReservacionDto
    {
        public int IdReservacion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public int IdHabitacion { get; set; }
        public int IdCliente { get; set; }

        public  List<PagoReservacionDto> PagosReservacion { get; set; }
    }
}
