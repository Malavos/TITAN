using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace api_lm
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CashController : Controller
    {
        [HttpGet]
        [Route("login")]
        [ProducesResponseType(201, Type = typeof(BsonDocument))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCashes()
        {
            return Ok();
        }


    }
}
