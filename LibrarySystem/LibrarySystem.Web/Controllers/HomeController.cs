using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using LibrarySystem.Common;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Infrastructure.Extensions;
using LibrarySystem.Web.ViewModels.Book;
using LibrarySystem.Web.ViewModels.Home;

namespace LibrarySystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;

        public HomeController(IBookService bookService)
        {
            Guard.WhenArgument(bookService, "Book Service").IsNull().Throw();

            this.bookService = bookService;
        }

        [OutputCache(Location = System.Web.UI.OutputCacheLocation.Server, Duration = GlobalConstants.HomeViewCacheDuration, VaryByCustom = GlobalConstants.CacheVaryByCustom)]
        public ActionResult Index()
        {
            var latest = this.bookService
                .GetLatestAddedBook()
                .QueryTo<LatestAddedBookViewModel>()
                .FirstOrDefault();

            var topRated = this.bookService
                .GetBooksWithHighestRating()
                .QueryTo<BookViewModel>()
                .ToList();

            var resultViewModel = new HomeViewModel()
            {
                LatestBook = latest,
                TopRatedBooks = topRated
            };

            return View(resultViewModel);
        }
    }
}