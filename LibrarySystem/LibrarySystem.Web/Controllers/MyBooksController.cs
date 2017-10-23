using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Services.Common.Contracts;
using LibrarySystem.Services.Data;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Infrastructure.Extensions;
using LibrarySystem.Web.ViewModels.Book;

namespace LibrarySystem.Web.Controllers
{
    [Authorize]
    public class MyBooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IIdentityService identityService;
        private readonly IUserService userService;

        public MyBooksController(IBookService bookService, IIdentityService identityService, IUserService userService)
        {
            Guard.WhenArgument(bookService, "Book Service").IsNull().Throw();
            Guard.WhenArgument(identityService, "Identity Service").IsNull().Throw();
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();

            this.bookService = bookService;
            this.identityService = identityService;
            this.userService = userService;
        }

        // GET: MyBooks
        public ActionResult Index()
        {
            var books = this.bookService
                .GetBooksByUserId(identityService.GetUserId())
                .QueryTo<BookViewModel>()
                .ToList();

            return View(books);
        }
    }
}