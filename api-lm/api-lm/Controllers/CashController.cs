using Microsoft.AspNetCore.Authorization;
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
        /// <summary>
        /// Get the logged in user cashes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("login")]
        [ProducesResponseType(201, Type = typeof(BsonDocument))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize]
        public IActionResult GetCashes()
        {


            return Ok();
        }


    }
}
