using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LibrarySystem.Services.Common.Contracts;
using LibrarySystem.Services.Data;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Web.UnitTests.Controllers.MyBooksControllerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        [Category("MyBooksController.Constructor")]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNullIdentityService()
        {
            // Arrange
            var mockedBookService = new Mock<IBookService>();
            var mockedIdentityService = new Mock<IIdentityService>();
            var mockedUserService = new Mock<IUserService>();
            //Act
            //Asssert
            Assert.Throws<ArgumentNullException>(
                () => new MyBooksController(mockedBookService.Object, null, mockedUserService.Object));
        }

        [Test]
        [Category("MyBooksController.Constructor")]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNullBookService()
        {
            // Arrange
            var mockedBookService = new Mock<IBookService>();
            var mockedIdentityService = new Mock<IIdentityService>();
            var mockedUserService = new Mock<IUserService>();

            //Act
            //Asssert
            Assert.Throws<ArgumentNullException>(
                () => new MyBooksController(null, mockedIdentityService.Object, mockedUserService.Object));
        }

        [Test]
        [Category("MyBooksController.Constructor")]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNullUserService()
        {
            // Arrange
            var mockedBookService = new Mock<IBookService>();
            var mockedIdentityService = new Mock<IIdentityService>();
            var mockedUserService = new Mock<IUserService>();

            //Act
            //Asssert
            Assert.Throws<ArgumentNullException>(
                () => new MyBooksController(mockedBookService.Object, mockedIdentityService.Object, null));
        }

        [Test]
        [Category("MyBooksController.Constructor")]
        public void Constructor_ShouldNotThrow_WhenPassedValidInput()
        {
            // Arrange
            var mockedBookService = new Mock<IBookService>();
            var mockedIdentityService = new Mock<IIdentityService>();
            var mockedUserService = new Mock<IUserService>();
            //Act
            //Asssert
            Assert.DoesNotThrow(() => new MyBooksController(mockedBookService.Object, mockedIdentityService.Object, mockedUserService.Object));
        }

        [Test]
        [Category("MyBooksController.Constructor")]
        public void Constructor_ShouldCreateAnInstanceOfHomeController_WhenPassedValidInput()
        {
            // Arrange
            var mockedBookService = new Mock<IBookService>();
            var mockedIdentityService = new Mock<IIdentityService>();
            var mockedUserService = new Mock<IUserService>();

            //Act
            var sut = new MyBooksController(mockedBookService.Object, mockedIdentityService.Object, mockedUserService.Object);

            //Asssert
            Assert.That(sut, Is.InstanceOf<MyBooksController>());
        }
    }
}
