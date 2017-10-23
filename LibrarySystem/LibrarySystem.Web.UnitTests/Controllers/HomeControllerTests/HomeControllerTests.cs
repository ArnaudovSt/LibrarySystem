using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web.Mvc;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Web.UnitTests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        [Category("HomeController.Constructor")]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNull()
        {
            // Arrange
            //Act
            //Asssert
            Assert.Throws<ArgumentNullException>(() => new HomeController(null));
        }

        [Test]
        [Category("HomeController.Constructor")]
        public void Constructor_ShouldNotThrow_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<IBookService>();

            //Act
            //Asssert
            Assert.DoesNotThrow(() => new HomeController(mockedService.Object));
        }

        [Test]
        [Category("HomeController.Constructor")]
        public void Constructor_ShouldCreateAnInstanceOfHomeController_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<IBookService>();

            //Act
            var sut = new HomeController(mockedService.Object);

            //Asssert
            Assert.That(sut, Is.InstanceOf<HomeController>());
        }

        [Test]
        [Category("HomeController.Index")]
        public void Index_ShouldHaveOutputCacheAttribute()
        {
            // Arrange
            var method = typeof(HomeController).GetMethod("Index");

            //Act
            //Asssert
            Assert.True(method.GetCustomAttributes(typeof(OutputCacheAttribute), false).Any());
        }
    }
}
