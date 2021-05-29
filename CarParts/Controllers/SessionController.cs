using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PriceComparer.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        [HttpGet("set")]
        public IActionResult setsession(string key, string data)
        {
            HttpContext.Session.SetString(key, data);
            return Ok("session data set");
        }

        [HttpGet("get")]
        public IActionResult getsessiondata(string key)
        {
            var sessionData = HttpContext.Session.GetString(key);
            return Ok(sessionData);
        }
    }
}
