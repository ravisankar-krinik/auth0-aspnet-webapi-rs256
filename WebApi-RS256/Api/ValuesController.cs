﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace Api
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("ping")]
        public IHttpActionResult NotSecured()
        {
            return this.Ok("All good. You don't need to be authenticated to call this.");
        }

        [Authorize]
        [HttpGet]
        [Route("secured/ping")]
        public IHttpActionResult Secured()
        {
            return Json((User as ClaimsPrincipal).Claims.Select(c => new { c.Type, c.Value }));
        }
    }
}