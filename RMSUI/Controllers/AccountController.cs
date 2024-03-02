using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RMSUI.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RMSUI.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetToken([FromBody] LoginModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:26154/");
                try
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
                    model.Password = hashedPassword;
                    // Serialize the loginDto object to JSON
                    var requestData = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    // Make a POST request to the "GenerateToken" endpoint
                    using (HttpResponseMessage response = await client.PostAsync("api/Account/GenerateToken", requestData))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseContent = await response.Content.ReadAsStringAsync();
                        // Deserialize the JSON into TokenResponse object
                        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);

                        // Assuming the server returns JSON, you might want to return it as JSON
                        //return Ok(JsonConvert.DeserializeObject(responseContent));
                        return Ok(tokenResponse);
                    }
                }
                catch (HttpRequestException ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
        }
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser user)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:26154/");
                try
                {
                    var requestData = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                    // Make a POST request to the "GenerateToken" endpoint
                    using (HttpResponseMessage response = await client.PostAsync("api/Account/RegisterUser", requestData))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return Ok(responseContent);
                    }
                }
                catch (HttpRequestException ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
        }
        public async Task<IActionResult> Userroles()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:26154/");
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("api/Account/UserRoles"))
                    {
                        response.EnsureSuccessStatusCode();
                        var responseContent = await response.Content.ReadAsStringAsync();
                        return Ok(responseContent);
                    }
                }
                catch (HttpRequestException ex)
                {
                    return BadRequest($"Error: {ex.Message}");
                }
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }
        public ActionResult Dashbord()
        {
            return View();
        }


    }
}
