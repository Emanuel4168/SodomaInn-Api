using System;
using System.Collections.Generic;
using System.Text;

namespace SodomaInn.Core.Dto
{
    public class HabitacionDto
    {
        public int IdHabitacion { get; set; }
        public string Identificador { get; set; }
        public bool Disponible { get; set; }
        public int IdTipoHabitacion { get; set; }
        public bool Estatus { get; set; }

        public TipoHabitacionDto TiposHabitacion { get; set; }
    }
}
