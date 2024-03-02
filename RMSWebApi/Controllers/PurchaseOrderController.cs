using Microsoft.AspNetCore.Mvc;
using RMSWebApi.RepoImplement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        [Route("GetAllPurchaseOrders")]
        public List<PurchaseOrderDTO> GetAllPurchaseOrders()
        {
            try
            {
                return unitOfWork.PurchaseOrderRepo.GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetByPurchaseOrdersId")]
        public PurchaseOrderDTO GetByPurchaseOrdersId(int id)
        {
            return unitOfWork.PurchaseOrderRepo.GetById(id);
        }
        [HttpPost]
        [Route("AddPurchaseOrders")]
        public bool AddPurchaseOrders(PurchaseOrderDTO Record)
        {
            try
            {
                unitOfWork.PurchaseOrderRepo.UpdateRecord(Record);
                bool success = unitOfWork.SaveAll();
                return success;
            }catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("DeletePurchaseOrders")]
        public bool DeletePurchaseOrders(int id)
        {
            try
            {
                unitOfWork.PurchaseOrderRepo.DeleteRecord(id);
                bool Success = unitOfWork.SaveAll();
                return Success;
            }
            catch(Exception ex)
            {
                throw ;
            }
        }
        [HttpPost]
        [Route("UpdatePurchaseOrders")]
        public async Task<IActionResult> UpdatePurchaseOrders(PurchaseOrderDTO Record)
        {
            try
            {
                unitOfWork.PurchaseOrderRepo.UpdateRecord(Record);
                bool success = unitOfWork.SaveAll();
                //return success;
                return Ok();
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
    }
}
