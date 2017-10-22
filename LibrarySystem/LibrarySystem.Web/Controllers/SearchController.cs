using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using LibrarySystem.Common;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Infrastructure.Attributes;
using LibrarySystem.Web.ViewModels.Search;
using LibrarySystem.Web.Infrastructure.Extensions;
using LibrarySystem.Web.ViewModels.Book;

namespace LibrarySystem.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookService bookService;

        public SearchController(IBookService bookService)
        {
            Guard.WhenArgument(bookService, "Book Service").IsNull().Throw();

            this.bookService = bookService;
        }

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public PartialViewResult Search(SearchViewModel model)
        {

            var resultBooks = this.bookService.Search(model.SearchedWord, model.Category)
                .QueryTo<BookViewModel>()
                .ToList();

            var resultView = new SearchResultsViewModel()
            {
                Books = resultBooks
            };

            return PartialView(GlobalConstants.SearchResultsPartial, resultView);
        }
    }
}