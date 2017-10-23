using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bytes2you.Validation;
using LibrarySystem.Common;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Areas.Admin.ViewModels;
using LibrarySystem.Web.Infrastructure.Attributes;

namespace LibrarySystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class CrudController : Controller
    {
        private readonly IBookService bookService;

        public CrudController(IBookService bookService)
        {
            Guard.WhenArgument(bookService, "Book Service").IsNull().Throw();

            this.bookService = bookService;
        }

        // GET: Admin/Crud
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [SaveChanges]
        public ActionResult Index(AddBookViewModel model)
        {
            this.bookService.Add(model.AuthorFirstName,
                model.AuthorLastName,
                model.Description,
                model.GenreName,
                model.ISBN,
                model.PageCount,
                model.Title,
                model.YearOfPublishing);

            return RedirectToAction("Index");
        }
    }
}