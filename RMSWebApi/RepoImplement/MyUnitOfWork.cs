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
        public PurchaseOrderRepoImplement PurchaseOrderRepo
        {
            get
            {
                try
                {
                    if (purchaseOrderRepo == null)
                    {
                        purchaseOrderRepo = new PurchaseOrderRepoImplement(context);
                    }
                }catch (Exception ex)
                {
                    throw;
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
            catch (Exception ex)
            {
                throw;  
            }
        }
    }
}
