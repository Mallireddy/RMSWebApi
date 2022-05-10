/*using RMSWebApi.DTO;
using RMSWebApi.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMSWebApi.RepoImplement
{
    public class ProductRepoImplement : IBaseRepo<ProductDTO>
    {
        MyAppDbContext context;
        public ProductRepoImplement(MyAppDbContext ctx)
        {
            context = ctx;
        }
        public bool Add(ProductDTO inp)
        {
           
            try
            {
                var prod = new Product()
                {
                    ProductName = inp.ProductName,
                    Quatity = inp.Quatity,
                    Price = inp.Price,
                    ProductGenre = inp.ProductGenre,
                };
                context.Products.Add(prod);
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            var SelProds = context.Products.Find(id);
            if (SelProds != null)
            {
                context.Products.Remove(SelProds);
                return true;
            }
            return false;   
        }

        public List<ProductDTO> GetAll()
        {
            var res= (from obj in context.Products
                     select new ProductDTO() { 
                     ProductId = obj.ProductId,
                     ProductName = obj.ProductName,
                     Quatity = obj.Quatity, 
                     Price = obj.Price,
                     ProductGenre = obj.ProductGenre,   

                     }).ToList();
            return res;
        }

        public ProductDTO getOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(ProductDTO inp)
        {
            var SelProds = (from obj in context.Products
                          where obj.ProductId == inp.ProductId
                          select obj).FirstOrDefault();
            if(SelProds != null)
            {
                SelProds.ProductName = inp.ProductName;
                SelProds.Quatity = inp.Quatity;
                SelProds.Price = inp.Price;
                SelProds.ProductGenre = inp.ProductGenre;
                return true;
            }
            return false;

        }
    }
}*/
