using System;
using System.Linq;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["CategoryType"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
