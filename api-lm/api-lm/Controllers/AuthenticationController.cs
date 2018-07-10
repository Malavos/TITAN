using Common.Providers;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace api_lm
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Token([FromBody]AuthRequest user)
        {

            if (!ModelState.IsValid) return BadRequest("Token failed to generate");
            //Get our bitch ass user from :b:ongo
            var provider = new MongoProvider();
            var database = provider.GetApplicationDatabase(provider.InitializeDatabase(Database.ConnectionString));
            var collection = database.GetCollection<BsonDocument>("users", null);
            //var builder = Builders<BsonDocument>.Filter;
            var filter = Builders<BsonDocument>.Filter.Eq("Email", user.User);
            var userObject = collection.Find(filter).FirstOrDefault();

            if (userObject == null)
            {
                return Unauthorized();
            }

            //Add Claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
                new Claim(JwtRegisteredClaimNames.Sub, "data"),
                new Claim(JwtRegisteredClaimNames.Email, "data"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var truestKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenAuthentication:SecretKey"]));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rlyaKithdrYVl6Z80ODU350md")); //Secrets
            var creds = new SigningCredentials(truestKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(userObject["Email"].AsString,
                _configuration["TokenAuthentication:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = DateTime.Now.AddMinutes(30),
                token_type = "bearer"
            });
        }
    }
}
