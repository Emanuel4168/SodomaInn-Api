using SodomaInn.Business.Managers;
using SodomaInn.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SodomaInn.Api.Controllers
{
    public class ReservacionController : ApiController
    {
        public ReservacionManager reservacionManager;

        public ReservacionController()
        {
            reservacionManager = new ReservacionManager();
        }

        [HttpPost]
        [Route("Reservacion/CrearReservacion")]
        public IHttpActionResult CrearReservacion([FromBody]ReservacionDto reservacion)
        {
            int value = reservacionManager.GenerarReservacion(reservacion);
            return Json(value);
        }

        [HttpOptions]
        [Route("Reservacion/CrearReservacion")]
        public IHttpActionResult CrearReservacionOptions()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "POST,OPTIONS");
            return Ok();
        }

        [HttpGet]
        [Route("Reservacion/GetReservaciones")]
        public IHttpActionResult GetReservaciones(int status)
        {
            var reservaciones  = reservacionManager.GetReservaciones(status);
            return Json(reservaciones);
        }

        [HttpPost]
        [Route("Reservacion/GuardarServicioReservacion")]
        public IHttpActionResult GuardarServicioReservacion(ServiciosReservacionDTO serviciosReservacion)
        {
            bool success = reservacionManager.GuardarServicioReservacion(serviciosReservacion);
            return Json(success);
        }

        [HttpOptions]
        [Route("Reservacion/GuardarServicioReservacion")]
        public IHttpActionResult GuardarServicioReservacionOptions()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "POST,OPTIONS");
            return Ok();
        }

        [HttpPost]
        [Route("Reservacion/Check")]
        public IHttpActionResult Check([FromUri]int idReservacion, [FromUri]int estatus)
        {
            bool success = reservacionManager.Check(idReservacion, estatus);
            return Json(success);
        }

        [HttpOptions]
        [Route("Reservacion/Check")]
        public IHttpActionResult CheckOptions()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "POST,OPTIONS");
            return Ok();
        }

        [HttpGet]
        [Route("Reservacion/GetServicesByReserrvation")]
        public IHttpActionResult GetServicesByReserrvation(int idReservacion)
        {
            var servicios = reservacionManager.GetServicesByReserrvation(idReservacion);
            return Json(servicios);
        }
    }
}
