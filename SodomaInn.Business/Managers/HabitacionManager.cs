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
    public class HabitacionManager
    {
        public bool AgregarHabitacion(HabitacionDto habitacion)
        {
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    Habitacion habitacionDB =  ObjectMapper.Map<HabitacionDto,Habitacion>(habitacion);
                    context.Habitacion.Add(habitacionDB);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ActualizarHabitacion(HabitacionDto habitacion)
        {
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    Habitacion habitacionDB = context.Habitacion.FirstOrDefault(h => h.IdHabitacion == habitacion.IdHabitacion);
                    habitacionDB.Identificador = habitacion.Identificador;
                    habitacionDB.IdTipoHabitacion = habitacion.IdTipoHabitacion;
                    habitacionDB.Estatus = habitacion.Estatus;
                    habitacionDB.Disponible = habitacion.Disponible;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool BajaHabitacion(int idHabitacion)
        {
            try
            {
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    Habitacion habitacionDB = context.Habitacion.FirstOrDefault(h => h.IdHabitacion == idHabitacion);
                    habitacionDB.Estatus = false;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<HabitacionDto> GetHabitacionesPorTipo(int tipo)
        {
            try
            {
                List<HabitacionDto> habitaciones = new List<HabitacionDto>();
                using (SodomaInnEntities context = new SodomaInnEntities())
                {
                    var habitacionesDb = context.Habitacion.Where(h => h.IdTipoHabitacion == tipo || tipo == 0);
                    foreach (var habitacion in habitacionesDb)
                    {
                        habitaciones.Add(ObjectMapper.Map<Habitacion, HabitacionDto>(habitacion));
                    }
                    return habitaciones;
                }
                
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
