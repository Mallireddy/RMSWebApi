using RMSWebApi.RepoInterface;
using RMSWebApi.RepoImplement;
using System;

namespace RMSWebApi.RepoImplement
{
    public class MyUnitOfWork
    {
       // ProductRepoImplement productRepo;
       // OrderRepoImplement orderRepo;
        PurchaseOrderRepoImplement purchaseOrderRepo;   
        MyAppDbContext context;
        public MyUnitOfWork(MyAppDbContext ctx)
        {
            context = ctx;
        }
       /* public ProductRepoImplement ProductRepo
        {
            get
            {
                 if(productRepo == null)
                {
                    productRepo = new ProductRepoImplement(context);
                } 
                 return productRepo;
            }
        }
        public OrderRepoImplement OrderRepo
        {
            get
            {
                if (orderRepo == null)
                {
                    orderRepo = new OrderRepoImplement(context);
                }
                return orderRepo;
            }
        }*/
        public PurchaseOrderRepoImplement PurchaseOrderRepo
        {
            get
            {
                if (purchaseOrderRepo == null)
                {
                    purchaseOrderRepo = new PurchaseOrderRepoImplement(context);
                }
                return purchaseOrderRepo;
            }
        }
        public bool SaveAll()
        {
            try
            {
                context.SaveChanges();  
                return true;
            }
            catch (Exception e)
            {
               return false;    
            }
        }
    }
}
