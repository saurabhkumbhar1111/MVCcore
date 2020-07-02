using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MvcCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        // GET: api/<SecurityController>
        
        private string GenerateKey(string username)
        {
            // Security Key
            var securityKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes("238420983409284098230948"));
            // Algorithm
            var credentials = new
                    SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Claims
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Email, "sample@gmail.com"),
                new Claim("Admin", "true"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken("finishingschool",
              "finishingschool",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            string tokenstring = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenstring;
        }

        // GET api/<SecurityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SecurityController>
        [HttpPost]
        public IActionResult Post([FromBody] User obj)
        {
            if((obj.username=="Saurabh") && (obj.password == "pass123"))
            {
                obj.token = GenerateKey(obj.username);
                obj.password = "";
                return Ok(obj);
            }
            else
            {
                return StatusCode(401, "Not a valid user");
            }
        }

        // PUT api/<SecurityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SecurityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
