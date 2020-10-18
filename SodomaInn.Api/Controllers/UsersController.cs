using SodomaInn.Business.Managers;
using SodomaInn.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public IHttpActionResult LogIn([FromBody]UserDto user)
        {
            UserDto userData = userManager.LogIn(user);
            return Json(user);
        }
    }
}
