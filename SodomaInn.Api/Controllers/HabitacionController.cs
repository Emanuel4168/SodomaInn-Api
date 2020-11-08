using SodomaInn.Business.Managers;
using SodomaInn.Core.Dto;
using SodomaInn.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SodomaInn.Api.Controllers
{
    public class HabitacionController : ApiController
    {
        private HabitacionManager habitacionManager;

        public HabitacionController()
        {
            habitacionManager = new HabitacionManager();
        }

        [HttpPost]
        [Route("Habitacion/AgregarHabitacion")]
        public IHttpActionResult AgregarHabitacion([FromBody]HabitacionDto habitacion)
        {
            bool success = habitacionManager.AgregarHabitacion(habitacion);
            return Json(success);
        }

        [HttpPost]
        [Route("Habitacion/ActualizarHabitacion")]
        public IHttpActionResult ActualizarHabitacion([FromBody]HabitacionDto habitacion)
        {
            bool success = habitacionManager.ActualizarHabitacion(habitacion);
            return Json(success);
        }

        [HttpPost]
        [Route("Habitacion/BajaHabitacion")]
        public IHttpActionResult BajaHabitacion([FromBody]int idHabitacion)
        {
            bool success = habitacionManager.BajaHabitacion(idHabitacion);
            return Json(success);
        }

        [HttpGet]
        [Route("Habitacion/GetHabitacionesPorTipo")]
        public IHttpActionResult GetHabitacionesPorTipo([FromUri]int tipo)
        {
            var habitaciones = habitacionManager.GetHabitacionesPorTipo(tipo);
            return Json(habitaciones);
        }
    }
}
