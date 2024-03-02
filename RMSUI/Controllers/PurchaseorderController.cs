using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RMSUI.Controllers
{
    public class PurchaseorderController : Controller
    {
        public IActionResult getAllPurchaseorder()
        {
            return View();
        }
        /// <summary>
        /// This method used for getting the purchaseorder details
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Purchaseordergetall()
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
        public ActionResult Addpurchaseorder()
        {
            return View();
        }
    }
}
