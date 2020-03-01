using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Service.Models;

namespace Service.Controllers
{
    public class AccountController : ApiController
    {
        SECURITY_DBEntities db = new SECURITY_DBEntities();
        [Route("Account/GetUser")]
        [HttpGet]
        public IHttpActionResult GetUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var Result = db.UserMasters.Where(m => m.UserName == identity.Name);
            return Ok(Result);
        }
    }
}
