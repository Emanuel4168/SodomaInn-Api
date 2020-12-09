using SodomaInn.Core.Dto;
using SodomaInn.Core.Utils;
using SodomaInn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodomaInn.Business.Managers
{
    class ReservacionManager
    {
        public bool GenerarReservacion(ReservacionDto reservacion)
        {
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    bool success = context.Database.SqlQuery<bool>($"usp_ReservarHabitacion '{reservacion.FechaInicio.Date.ToString("S")}','{reservacion.FechaFin.Date.ToString("S")}',{reservacion.IdHabitacion},{reservacion.IdCliente}").FirstOrDefault();
                    return success;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
