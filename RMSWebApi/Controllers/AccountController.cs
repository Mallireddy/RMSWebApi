using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace RMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IConfiguration config = null;
        public AccountController(IConfiguration cfg)
        {
            config = cfg;   
        }
        [HttpPost]
        public string GenerateToken(LoginDTO inp)
        {
            var handler = new JwtSecurityTokenHandler();
            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(config.GetSection("JWTValue:Key").Value);
            var TDesc = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] { 
                    new Claim(ClaimTypes.Name,inp.Email),
                    new Claim(ClaimTypes.Role,"Admin")
                }),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(keyBytes),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = handler.CreateToken(TDesc);
            var TokenString = handler.WriteToken(token);
            return TokenString;
        }
    }
}
