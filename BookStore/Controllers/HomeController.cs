using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using BookStore.Models.ViewModels;
using System.Linq;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;
        //private object b;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        //public object CategoryType { get; private set; }

        //This will get all the info for the books and put them into the index page
        public IActionResult Index(string CategoryType, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b=>b.Category == CategoryType || CategoryType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (CategoryType == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == CategoryType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            //var blah = repo.Books
            //    .OrderBy(b => b.Title)
            //    .Skip((pageNum - 1) * pageSize)
            //    .Take(pageSize);

            return View(x);
        }
    }
}
