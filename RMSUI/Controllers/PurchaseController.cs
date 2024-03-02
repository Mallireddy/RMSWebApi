using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMSUI.Controllers
{
    public class PurchaseController : Controller
    {
        public async Task< IActionResult> PurchasesGet()
        {
            using (var client = new HttpClient())
            {               
                client.BaseAddress = new Uri("http://localhost:26154/");
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync("api/PurchaseOrder/GetAllPurchaseOrders"))
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
        public IActionResult Purchases()
        {
            return View();
        }
        public IActionResult Retailer()
        {
            return View();
        }
        public IActionResult Wholesale()
        {
            return View();
        }
    }
}
