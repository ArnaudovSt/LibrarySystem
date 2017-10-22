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
using LibrarySystem.Services.Common.Contracts;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Infrastructure.Attributes;
using LibrarySystem.Web.Infrastructure.Extensions;
using LibrarySystem.Web.ViewModels.Book;
using LibrarySystem.Web.ViewModels.Rating;

namespace LibrarySystem.Web.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IIdentityService identityService;
        private readonly IRatingService ratingService;

        public BookController(IBookService bookService, IIdentityService identityService, IRatingService ratingService)
        {
            Guard.WhenArgument(bookService, "Book Service").IsNull().Throw();
            Guard.WhenArgument(identityService, "Identity Service").IsNull().Throw();
            Guard.WhenArgument(ratingService, "Rating Service").IsNull().Throw();

            this.bookService = bookService;
            this.identityService = identityService;
            this.ratingService = ratingService;
        }

        // GET: Book
        public ActionResult BookDetails(Guid id)
        {
            var book = bookService
                .GetBookById(id)
                .QueryTo<BookDetailsViewModel>()
                .FirstOrDefault();

            return View(book);
        }

        [ChildActionOnly]
        public PartialViewResult GetRating(Guid id)
        {
            var bookRating = this.bookService.GetBookRating(id);

            Guid userId = this.identityService.GetUserId();

            var userRating = this.ratingService.GetRating(id, userId);

            var ratingModel = new RatingViewModel()
            {
                Id = id,
                BookRating = bookRating,
                UserRating = userRating
            };

            return this.PartialView("_RatingPartial", ratingModel);
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        [SaveChanges]
        public ActionResult Vote(Guid id, double rating)
        {
            Guid userId = this.identityService.GetUserId();

            this.ratingService.AddRating(id, userId, rating);

            return JavaScript("location.reload(true)");
        }
    }
}