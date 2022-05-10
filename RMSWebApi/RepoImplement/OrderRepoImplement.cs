/*using RMSWebApi.DTO;
using RMSWebApi.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMSWebApi.RepoImplement
{
    public class OrderRepoImplement : IBaseRepo<OrderDTO>
    {
        MyAppDbContext context;
        public OrderRepoImplement(MyAppDbContext ctx)
        {
            context = ctx;
        }
        public bool Add(OrderDTO inp)
        {
            try
            {
                var ors = new Order()
                {
                   Quantity=inp.Quantity,   
                   Price=inp.Price, 
                   TotalOrderPrice=inp.TotalOrderPrice,
                   productGenre=inp.productGenre,
                   CustomerId=inp.CustomerId,   
                   CustomerName=inp.CustomerName,   
                   ProductId=inp.ProductId,
                    
                };
                context.Orders.Add(ors);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            var SelOrs = context.Orders.Find(id);
            if (SelOrs != null)
            {
                context.Orders.Remove(SelOrs);
                return true;
            }
            return false;
        }

        public List<OrderDTO> GetAll()
        {
            var res = (from obj in context.Orders
                       select new OrderDTO()
                       {
                           OrderId = obj.OrderId,
                           Quantity = obj.Quantity,
                           Price = obj.Price,
                           TotalOrderPrice = obj.TotalOrderPrice,
                           CustomerId = obj.CustomerId,
                           CustomerName = obj.CustomerName,
                           productGenre = obj.productGenre,
                           ProductId = obj.ProductId,
                          

                       }).ToList();
            return res;
        }

        public OrderDTO getOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(OrderDTO inp)
        {
           var SelOrs=(from obj in context.Orders
                      where obj.OrderId == inp.OrderId  
                      select obj).FirstOrDefault();
            if(SelOrs != null)
            {
                SelOrs.Quantity = inp.Quantity;
                SelOrs.Price = inp.Price;
                SelOrs.TotalOrderPrice = inp.TotalOrderPrice;
                SelOrs.productGenre = inp.productGenre;
                SelOrs.CustomerId = inp.CustomerId;
                SelOrs.CustomerName = inp.CustomerName;
                SelOrs.ProductId = inp.ProductId;
               
                return true;

            }
            return false;
        }
    }
}*/
