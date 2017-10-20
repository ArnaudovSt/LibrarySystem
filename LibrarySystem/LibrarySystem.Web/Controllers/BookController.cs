using LibrarySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bytes2you.Validation;
using LibrarySystem.Services.Common;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Infrastructure.Extensions;
using LibrarySystem.Web.ViewModels.Book;

namespace LibrarySystem.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            Guard.WhenArgument(bookService, "Book Service").IsNull().Throw();

            this.bookService = bookService;
        }
        // GET: Book
        public ActionResult Index(Guid id)
        {
            var book = bookService
                .GetBookById(id)
                .QueryTo<DbTestViewModel>()
                .FirstOrDefault();

            return View(book);
        }
    }
}