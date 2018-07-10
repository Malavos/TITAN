using Common.Models;
using Common.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Net;

namespace api_lm.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        //private MongoClient InitalizeMongo()
        //{
        //    var mongoClient = new MongoClient("mongodb://Hittorito:MyLifeForAiur41!1337@party-gg-shard-00-00-up6bv.mongodb.net:27017,party-gg-shard-00-01-up6bv.mongodb.net:27017,party-gg-shard-00-02-up6bv.mongodb.net:27017/test?ssl=true&replicaSet=party-gg-shard-0&authSource=admin");
        //    return mongoClient;
        //}


        /// <summary>
        /// Authenticates the user in the system.
        /// </summary>
        /// <param name="user">Username.</param>
        /// <param name="password">Username password.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("login")]
        [ProducesResponseType(201, Type = typeof(BsonDocument))]
        [ProducesResponseType(400)]
        public IActionResult Login(string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
                return StatusCode(400, Common.Constantes.Mensagens.Alertas.SENHA_USUARIO_OBRIGATORIO);

            var provider = new MongoProvider();
            var database = provider.GetApplicationDatabase(provider.InitializeDatabase(Database.ConnectionString));
            var collection = database.GetCollection<BsonDocument>("users", null);
            //var builder = Builders<BsonDocument>.Filter;
            var filter = Builders<BsonDocument>.Filter.Eq("user", user);
            var userObject = collection.Find(filter).FirstOrDefault();

            if (userObject == null)
                return StatusCode(400, Common.Constantes.Mensagens.Alertas.SENHA_USUARIO_OBRIGATORIO);

            if (userObject["password"] != password)
                return StatusCode(StatusCodes.Status401Unauthorized, Common.Constantes.Mensagens.Alertas.LOGIN_INVALIDO);

            return Ok(Common.Constantes.Mensagens.LOGIN_SUCESSO);
        }

        [HttpPut]
        [Route("register")]
        [ProducesResponseType(201, Type = typeof(Boolean))]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
        public IActionResult RegisterUser([FromBody]UserModel model)
        {
            if (model == null)
                return StatusCode(400, Common.Constantes.Mensagens.Excecoes.ARGUMENTOS_NULOS);

            if (string.IsNullOrWhiteSpace(model.Password) || string.IsNullOrWhiteSpace(model.PasswordConfirmation) || string.IsNullOrWhiteSpace(model.Email) || string.IsNullOrWhiteSpace(model.Name))
                return StatusCode(400, Common.Constantes.Mensagens.Excecoes.ARGUMENTOS_INVALIDOS);
            //throw new ArgumentException(Common.Constantes.Mensagens.Excecoes.ARGUMENTOS_INVALIDOS);

            if (model.Password.Trim() != model.PasswordConfirmation.Trim())
                return StatusCode(400, Common.Constantes.Mensagens.Excecoes.SENHA_INVALIDA);

            var user = new BsonDocument
            {
                { "Name", model.Name },
                { "Email", model.Email},
                { "Password", model.Password },
                { "PhoneNumber", model.PhoneNumber},
                { "AreaCodePhoneNumber" , model.AreaCodePhoneNumber },
                { "CreationDate", new BsonDateTime(DateTime.UtcNow) },
                { "UserOriginalAgent" , model.UserOriginalAgent },
                { "UserLastAgent", model.UserLastAgent }
            };

            (new MongoProvider().GetApplicationDatabase(new MongoProvider().InitializeDatabase(Database.ConnectionString))).GetCollection<BsonDocument>("users", null).InsertOne(user);
            //var database = provider.GetApplicationDatabase(provider.InitializeDatabase(Database.ConnectionString));
            //var collection = database.GetCollection<BsonDocument>("users", null);

            return Ok(true);
        }
    }
}