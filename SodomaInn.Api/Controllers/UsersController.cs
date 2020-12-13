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
    public class UsersController : ApiController
    {
        public UserManager userManager;

        public UsersController()
        {
            userManager = new UserManager();
        }

        [HttpPost]
        [Route("User/Login")]
        public IHttpActionResult LogIn([FromBody]UserDto user)
        {
            UserDto userData = userManager.LogIn(user);
            return Json(userData);
        }

        [HttpOptions]
        [Route("User/Login")]
        public IHttpActionResult LogInOptions()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "POST,OPTIONS");
            return Ok();
        }

        [HttpPost]
        [Route("User/SignIn")]
        public IHttpActionResult SignIn([FromBody]UserDto user)
        {
            bool result = userManager.SignIn(user);
            return Json(result);
        }

        [HttpOptions]
        [Route("User/SignIn")]
        public IHttpActionResult SignInOptions()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "POST,OPTIONS");
            return Ok();
        }
    }
}
