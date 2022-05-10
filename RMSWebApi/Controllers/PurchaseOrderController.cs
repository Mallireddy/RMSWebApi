using Microsoft.AspNetCore.Mvc;
using RMSWebApi.RepoImplement;
using System.Collections.Generic;

namespace RMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        MyUnitOfWork unitOfWork = null;
        public PurchaseOrderController(MyUnitOfWork uw)
        {
            unitOfWork = uw;
        }
        [HttpGet]
        public List<PurchaseOrderDTO> GetAll()
        {
            return unitOfWork.PurchaseOrderRepo.GetAll();

        }
        [HttpPost]
        public bool AddRecord(PurchaseOrderDTO Record)
        {
            unitOfWork.PurchaseOrderRepo.AddRecord(Record);
            bool Success = unitOfWork.SaveAll();
            return Success;
        }
        [HttpDelete]
        public bool DeleteRecord(int id)
        {
            unitOfWork.PurchaseOrderRepo.DeleteRecord(id);
            bool Success = unitOfWork.SaveAll();
            return Success;

        }
        [HttpPut]
        public bool UpdateRecord(PurchaseOrderDTO Record)
        {
            unitOfWork.PurchaseOrderRepo.UpdateRecord(Record);
            bool success = unitOfWork.SaveAll();
            return success;
        }
    }
}
