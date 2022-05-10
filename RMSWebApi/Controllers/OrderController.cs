/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMSWebApi.DTO;
using RMSWebApi.RepoImplement;
using System.Collections.Generic;

namespace RMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        MyUnitOfWork unitOfWork = null;
        public OrderController(MyUnitOfWork uw)
        {
            unitOfWork = uw;
        }
        [HttpGet]
        public List<OrderDTO> GetAll()
        {
            return unitOfWork.OrderRepo.GetAll();

        }
        [HttpPost]
        public bool Add(OrderDTO inp)
        {
            unitOfWork.OrderRepo.Add(inp);
            bool Success = unitOfWork.SaveAll();
            return Success;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            unitOfWork.OrderRepo.Delete(id);
            bool Success = unitOfWork.SaveAll();
            return Success;

        }
        [HttpPut]
        public bool Update(OrderDTO inp)
        {
            unitOfWork.OrderRepo.Update(inp);
            bool success = unitOfWork.SaveAll();
            return success;
        }

    }
}*/
