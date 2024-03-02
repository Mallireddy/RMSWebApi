using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Linq;
using System;
using System.Text;

namespace RMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IConfiguration config = null;
        MyAppDbContext context = null;
        public AccountController(IConfiguration cfg, MyAppDbContext ctx)
        {
            config = cfg;
            context = ctx;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inp"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(LoginDTO inp)
        {
            string token = null;
            string checkUser = null;

            // Validate user credentials
            var user = context.Users.SingleOrDefault(u => u.UserName == inp.Email && u.Password == inp.Password);

            if (user != null)
            {
                // Check user role
                checkUser = (from obj in context.Users
                             join r in context.Roles on obj.RoleId equals r.RoleId
                             where obj.UserName == inp.Email
                             select r.RoleName).FirstOrDefault();

                if (checkUser != null)
                {
                    var handler = new JwtSecurityTokenHandler();
                    byte[] keyBytes = Encoding.UTF8.GetBytes(config.GetSection("JWTValue:Key").Value);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, checkUser)
                        }),
                        Expires = DateTime.Now.AddMinutes(20),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var jwtToken = handler.CreateToken(tokenDescriptor);
                    token = handler.WriteToken(jwtToken);
                }
            }

            if (token != null && checkUser != null)
            {
                var result = new
                {
                    Token = token,
                    CheckUser = checkUser
                };

                return Ok(result);
            }
            else
            {
                // Return a 401 Unauthorized status if credentials are invalid
                return Unauthorized();
            }
        }
        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult RegisterUser(UserInfo user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }
            // Hash the password before saving it
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;

            context.Users.Add(user);
            context.SaveChanges();

            return Ok("User added successfully");

        }
        [HttpGet]
        [Route("UserRoles")]
        public IActionResult UserRoles()
        {
          var Result = context.Roles.ToList();
            return Ok(Result);
        }
    }
}
