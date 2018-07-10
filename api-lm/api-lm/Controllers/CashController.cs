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
        [ProducesResponseType(HttpStatusCode.BadRequest)]
        [ProducesResponseType(HttpStatusCode.NoContent)]



    }
}
