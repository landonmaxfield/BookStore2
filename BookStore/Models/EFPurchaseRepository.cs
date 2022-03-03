using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;

        public EFPurchaseRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Purchase> Purchase => context.Purchase.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurhcase(Purchase purchase) 
        {
            context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                context.Purchase.Add(purchase);
            }

            context.SaveChanges();
        }
    }
}
