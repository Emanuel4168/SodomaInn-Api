using System;
using System.Collections.Generic;
using System.Text;

namespace SodomaInn.Core.Dto
{
    public class TipoHabitacionDto
    {
        public int IdTipoHabitacion { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioNoche { get; set; }
        public int MaximoHuespedes { get; set; }
    }
}
