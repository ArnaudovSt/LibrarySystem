using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using LibrarySystem.Services.Common.Contracts;
using LibrarySystem.Services.Data.Contracts;

namespace LibrarySystem.Web.Controllers
{
    [Authorize]
    public class MyBooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IIdentityService identityService;

        public MyBooksController(IBookService bookService, IIdentityService identityService)
        {
            Guard.WhenArgument(bookService, "Book Service").IsNull().Throw();
            Guard.WhenArgument(identityService, "Identity Service").IsNull().Throw();

            this.bookService = bookService;
            this.identityService = identityService;
        }

        // GET: MyBooks
        public ActionResult Index()
        {
            return View();
        }
    }
}