using RMSWebApi.RepoInterface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMSWebApi.RepoImplement
{
    public class PurchaseOrderRepoImplement : IBaseRepo<PurchaseOrderDTO>
    {
        MyAppDbContext context;
        public PurchaseOrderRepoImplement(MyAppDbContext ctx)
        {
            context = ctx;
        }
        public bool AddRecord(PurchaseOrderDTO Record)
        {
            try
            {
                var Pors = new PurchaseOrder()
                {
                   BookId=Record.BookId,    
                   BookTitle=Record.BookTitle,
                   Quantity=Record.Quantity,
                   Price=Record.Price,
                   TotalOrderPrice=Record.TotalOrderPrice,
                };
                context.PurchaseOrders.Add(Pors);
            }
            catch (Exception ex)
            {
                throw;
            }
            return true;
        }

        public bool DeleteRecord(int id)
        {
            try
            {
                var CurPOrs = context.PurchaseOrders.Find(id);
                if (CurPOrs != null)
                {
                    context.PurchaseOrders.Remove(CurPOrs);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<PurchaseOrderDTO> GetAll()
        {
            try
            {
                var res = (from obj in context.PurchaseOrders
                           join Bobj in context.BooKs on obj.BookId equals Bobj.BookId
                           select new PurchaseOrderDTO()
                           {
                               PurchaseOrderId = obj.PurchaseOrderId,
                               BookId = obj.BookId,
                               BookTitle = obj.BookTitle,
                               Quantity = obj.Quantity,
                               Price = obj.Price,
                               TotalOrderPrice = obj.TotalOrderPrice,
                               Genres = obj.Genres,
                           }).ToList();
                return res;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public PurchaseOrderDTO GetById(int id)
        {
            try
            {
                PurchaseOrderDTO purchaseOrderDTO = new PurchaseOrderDTO();
                var Purchase = (from obj in context.PurchaseOrders
                                where obj.PurchaseOrderId == id
                                select obj).FirstOrDefault();
                if (Purchase != null)
                {
                    purchaseOrderDTO.PurchaseOrderId = Purchase.PurchaseOrderId;
                    purchaseOrderDTO.BookId = Purchase.BookId;
                    purchaseOrderDTO.BookTitle = Purchase.BookTitle;
                    purchaseOrderDTO.Quantity = Purchase.Quantity;
                    purchaseOrderDTO.Price = Purchase.Price;
                    purchaseOrderDTO.TotalOrderPrice = Purchase.TotalOrderPrice;
                    return purchaseOrderDTO;
                }
                return purchaseOrderDTO;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public bool UpdateRecord(PurchaseOrderDTO Record)
        {
            try
            {
                var CurPOrs = context.PurchaseOrders.FirstOrDefault(D => D.PurchaseOrderId == Record.PurchaseOrderId);
                if (CurPOrs != null)
                {
                    CurPOrs.BookTitle = Record.BookTitle;
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
