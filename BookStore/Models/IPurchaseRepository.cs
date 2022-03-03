using System;
using System.Linq;
namespace BookStore.Models
{
    public interface IPurchaseRepository
    {
       public IQueryable<Purchase> Purchase { get; }

        public void SavePurhcase(Purchase purchase);
    }
}
