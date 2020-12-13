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
    public class ReservacionManager
    {
        public int GenerarReservacion(ReservacionDto reservacion)
        {
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    int success = context.Database.ExecuteSqlCommand($"usp_ReservarHabitacion '{reservacion.FechaInicio.Date.ToString("yyyyMMdd")}','{reservacion.FechaFin.Date.ToString("yyyyMMdd")}',{reservacion.IdHabitacion},{reservacion.IdCliente},{reservacion.NombreCliente},{reservacion.Telefono},{reservacion.Email}");
                    return success;
                }
            }
            catch (Exception e)
            {
                return -2;
            }
        }

        public List<ReservacionDto> GetReservaciones(int estatus)
        {
            List<ReservacionDto> reservaciones = new List<ReservacionDto>();
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    var reservacionesDB = context.Database.SqlQuery<Reservacion>($"select r.* from Reservacion r inner join Habitacion h on r.IdHabitacion = h.IdHabitacion where h.Disponible = {estatus}");
                    foreach (Reservacion reservacionDB in reservacionesDB)
                    {
                        reservaciones.Add(ObjectMapper.Map<Reservacion, ReservacionDto>(reservacionDB));
                    }

                    return reservaciones;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool GuardarServicioReservacion(ServiciosReservacionDTO serviciosReservacion)
        {
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    ServiciosReservacion newService = new ServiciosReservacion();
                    newService.IdReservacion = serviciosReservacion.IdReservacion;
                    newService.IdServicio = serviciosReservacion.IdServicio;
                    context.ServiciosReservacion.Add(newService);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Check(int idReservacion, int estatus)
        {
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    var reservacion = context.Reservacion.FirstOrDefault(r => r.IdReservacion == idReservacion);
                    int idHabitacion = reservacion.IdHabitacion;
                    var habitacion = context.Habitacion.FirstOrDefault(h => h.IdHabitacion == idHabitacion);
                    habitacion.Disponible = estatus;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CatalogoServiciosDTO> GetServicesByReserrvation(int idReservacion)
        {
            List<CatalogoServiciosDTO> serviciosReservacion = new List<CatalogoServiciosDTO>();
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    var serviciosDB = context.Database.SqlQuery<CatalogoServicios>($"select c.* from ServiciosReservacion s inner join catalogoservicios c on s.idservicio = c.idservicio where idreservacion = {idReservacion}");
                    foreach (CatalogoServicios servicio in serviciosDB)
                    {
                        serviciosReservacion.Add(ObjectMapper.Map<CatalogoServicios, CatalogoServiciosDTO>(servicio));
                    }

                    return serviciosReservacion;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //private string GetMessageByID(int id)
        //{
        //    if (id > 0)
        //    {
        //        return "";
        //    }

        //    switch (id)
        //    {
        //        case -1:
        //            return "No hay habitaciones disponibles con el criterio seleccionado";
        //        //case -2:
        //        //    return "";
        //        //case -3:
        //        //    return "";
        //        default:
        //            return "";
        //    }
        //}
    }
}
