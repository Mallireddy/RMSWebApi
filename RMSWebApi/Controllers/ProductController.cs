/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RMSWebApi.DTO;
using System;
using System.Collections.Generic;
using RMSWebApi.RepoImplement;
using Microsoft.AspNetCore.Authorization;

namespace RMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class ProductController : ControllerBase
    {
        MyUnitOfWork unitOfWork = null;
        public ProductController(MyUnitOfWork uw)
        {
           unitOfWork = uw; 
        }
        [HttpGet]
        public List<ProductDTO> GetAll()
        {
           return unitOfWork.ProductRepo.GetAll();    

        }
        [HttpPost]
        public bool Add(ProductDTO inp)
        {
          unitOfWork.ProductRepo.Add(inp);
           bool Success= unitOfWork.SaveAll();  
            return Success;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            unitOfWork.ProductRepo.Delete(id);
            bool Success= unitOfWork.SaveAll();
            return Success;

        }
        [HttpPut]
        public bool Update(ProductDTO inp)
        {
            unitOfWork.ProductRepo.Update(inp);
            bool success= unitOfWork.SaveAll();
            return success;
        }
        
    }
}*/
