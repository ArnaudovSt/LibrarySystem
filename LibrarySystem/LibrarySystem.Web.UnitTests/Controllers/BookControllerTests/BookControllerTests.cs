using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LibrarySystem.Common;
using LibrarySystem.Services.Common.Contracts;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Controllers;
using LibrarySystem.Web.Infrastructure.Attributes;
using LibrarySystem.Web.ViewModels.Rating;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace LibrarySystem.Web.UnitTests.Controllers.BookControllerTests
{
    [TestFixture]
    public class BookControllerTests
    {
        [Category("BookController.Constructor")]
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullBookServiceIsPassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            // Act
            // Assert

            Assert.Throws<ArgumentNullException>(
                () => new BookController(null, identityServiceMock.Object, ratingServiceMock.Object));
        }

        [Category("BookController.Constructor")]
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullIdentityServiceIsPassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            // Act
            // Assert

            Assert.Throws<ArgumentNullException>(
                () => new BookController(bookServiceMock.Object, null, ratingServiceMock.Object));
        }

        [Category("BookController.Constructor")]
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullRatingServiceIsPassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            // Act
            // Assert

            Assert.Throws<ArgumentNullException>(
                () => new BookController(bookServiceMock.Object, identityServiceMock.Object, null));
        }

        [Category("BookController.Constructor")]
        [Test]
        public void Constructor_ShouldNotThrow_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            // Act
            // Assert

            Assert.DoesNotThrow(
                () => new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object));
        }

        [Category("BookController.Constructor")]
        [Test]
        public void Constructor_ShouldReturnInstanceOfBookController_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            // Act

            var result = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Assert

            Assert.That(result, Is.InstanceOf<BookController>());
        }

        [Category("BookController.GetRating")]
        [Test]
        public void GetRating_ShouldHaveChildActionOnlyAttribute()
        {
            // Arrange
            var method = typeof(BookController).GetMethod("GetRating");

            //Act
            //Assert
            Assert.True(method.GetCustomAttributes(typeof(ChildActionOnlyAttribute), false).Any());
        }

        [Category("BookController.GetRating")]
        [Test]
        public void GetRating_ShouldCallGetBookRatingOnBookService_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();

            bookServiceMock.Setup(b => b.GetBookRating(It.IsAny<Guid>()));

            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.GetRating(It.IsAny<Guid>(), It.IsAny<Guid>()));

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.GetRating(guid);
            // Assert

            bookServiceMock.Verify(x => x.GetBookRating(guid), Times.Once);
        }

        [Category("BookController.GetRating")]
        [Test]
        public void GetRating_ShouldCallGetUserIdOnIdentityService_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();

            bookServiceMock.Setup(b => b.GetBookRating(It.IsAny<Guid>()));

            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.GetRating(It.IsAny<Guid>(), It.IsAny<Guid>()));

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.GetRating(guid);
            // Assert

            identityServiceMock.Verify(x => x.GetUserId(), Times.Once);
        }

        [Category("BookController.GetRating")]
        [Test]
        public void GetRating_ShouldCallGetRatingOnRatingService_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();

            bookServiceMock.Setup(b => b.GetBookRating(It.IsAny<Guid>()));

            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.GetRating(It.IsAny<Guid>(), It.IsAny<Guid>()));

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.GetRating(guid);
            // Assert

            ratingServiceMock.Verify(x => x.GetRating(guid, guid), Times.Once);
        }

        [Category("BookController.GetRating")]
        [Test]
        public void GetRating_ShouldRenderPartialView_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();

            bookServiceMock.Setup(b => b.GetBookRating(It.IsAny<Guid>()));

            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.GetRating(It.IsAny<Guid>(), It.IsAny<Guid>()));

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.GetRating(guid);
            // Assert

            sut.WithCallTo(c => c.GetRating(guid))
                .ShouldRenderPartialView("_RatingPartial");
        }

        [Category("BookController.GetRating")]
        [Test]
        public void GetRating_ShouldRenderPartialViewWithCorrectModel_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();
            double rating = 1;

            bookServiceMock.Setup(b => b.GetBookRating(It.IsAny<Guid>())).Returns(rating);

            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.GetRating(It.IsAny<Guid>(), It.IsAny<Guid>())).Returns(rating);

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.GetRating(guid);
            // Assert

            sut.WithCallTo(c => c.GetRating(guid))
                .ShouldRenderPartialView("_RatingPartial")
                .WithModel<RatingViewModel>(x =>
                {
                    Assert.AreEqual(x.Id, guid);
                    Assert.AreEqual(x.BookRating, rating);
                    Assert.AreEqual(x.UserRating, rating);
                });
        }

        [Category("BookController.Vote")]
        [Test]
        public void GetRating_ShouldHaveHttpPostAttribute()
        {
            // Arrange
            var method = typeof(BookController).GetMethod("Vote");

            //Act
            //Assert
            Assert.True(method.GetCustomAttributes(typeof(HttpPostAttribute), false).Any());
        }


        [Category("BookController.Vote")]
        [Test]
        public void GetRating_ShouldHaveAjaxOnlyAttribute()
        {
            // Arrange
            var method = typeof(BookController).GetMethod("Vote");

            //Act
            //Assert
            Assert.True(method.GetCustomAttributes(typeof(AjaxOnlyAttribute), false).Any());
        }

        [Category("BookController.Vote")]
        [Test]
        public void GetRating_ShouldHaveValidateAntiForgeryTokenAttribute()
        {
            // Arrange
            var method = typeof(BookController).GetMethod("Vote");

            //Act
            //Assert
            Assert.True(method.GetCustomAttributes(typeof(ValidateAntiForgeryTokenAttribute), false).Any());
        }

        [Category("BookController.Vote")]
        [Test]
        public void GetRating_ShouldHaveSaveChangesAttribute()
        {
            // Arrange
            var method = typeof(BookController).GetMethod("Vote");

            //Act
            //Assert
            Assert.True(method.GetCustomAttributes(typeof(SaveChangesAttribute), false).Any());
        }

        [Category("BookController.Vote")]
        [Test]
        public void Vote_ShouldCallOnIdentityServiceGetUserId_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();
            double rating = 1;


            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.AddRating(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<double>()));

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.Vote(guid, rating);
            // Assert

            identityServiceMock.Verify(x => x.GetUserId(), Times.Once);
        }

        [Category("BookController.Vote")]
        [Test]
        public void Vote_ShouldCallOnRatingServiceAddRating_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();
            double rating = 1;


            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.AddRating(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<double>()));

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.Vote(guid, rating);
            // Assert

            ratingServiceMock.Verify(x => x.AddRating(guid, guid, rating), Times.Once);
        }

        [Category("BookController.Vote")]
        [Test]
        public void Vote_ShouldReturnJavaScriptResult_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();
            double rating = 1;


            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.AddRating(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<double>()));

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.Vote(guid, rating);
            // Assert

            sut.WithCallTo(c => c.Vote(guid, rating))
                .ValidateActionReturnType<JavaScriptResult>();
        }

        [Category("BookController.Vote")]
        [Test]
        public void Vote_ShouldReturnExactJavaScriptResult_WhenValidArgumentsArePassed()
        {
            // Arrange
            var bookServiceMock = new Mock<IBookService>();
            var identityServiceMock = new Mock<IIdentityService>();
            var ratingServiceMock = new Mock<IRatingService>();

            var guid = Guid.NewGuid();
            double rating = 1;


            identityServiceMock.Setup(i => i.GetUserId()).Returns(guid);

            ratingServiceMock.Setup(r => r.AddRating(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<double>()));

            var sut = new BookController(bookServiceMock.Object, identityServiceMock.Object, ratingServiceMock.Object);

            // Act
            sut.Vote(guid, rating);
            var result = sut.WithCallTo(c => c.Vote(guid, rating)).ActionResult as JavaScriptResult;
            // Assert

            Assert.AreEqual(result.Script, GlobalConstants.JavascriptRefresh);
        }
    }
}
