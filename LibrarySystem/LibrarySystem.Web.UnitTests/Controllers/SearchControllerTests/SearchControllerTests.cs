using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using LibrarySystem.Data.Models;
using LibrarySystem.Services.Common;
using LibrarySystem.Services.Common.Contracts;
using Moq;
using NUnit.Framework;
using LibrarySystem.Web.Controllers;
using LibrarySystem.Services.Data.Contracts;
using LibrarySystem.Web.Infrastructure.Attributes;
using LibrarySystem.Web.ViewModels.Book;
using LibrarySystem.Web.ViewModels.Search;
using TestStack.FluentMVCTesting;

namespace LibrarySystem.Web.UnitTests.Controllers.SearchControllerTests
{
    [TestFixture]
    public class SearchControllerTests
    {
        [Test]
        [Category("SearchController.Constructor")]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNull()
        {
            // Arrange
            //Act
            //Asssert
            Assert.Throws<ArgumentNullException>(() => new SearchController(null));
        }

        [Test]
        [Category("SearchController.Constructor")]
        public void Constructor_ShouldNotThrow_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<IBookService>();

            //Act
            //Asssert
            Assert.DoesNotThrow(() => new SearchController(mockedService.Object));
        }

        [Test]
        [Category("SearchController.Constructor")]
        public void Constructor_ShouldCreateAnInstanceOfSearchController_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<IBookService>();

            //Act
            var sut = new SearchController(mockedService.Object);

            //Asssert
            Assert.That(sut, Is.InstanceOf<SearchController>());
        }

        [Test]
        [Category("SearchController.Index")]
        public void Index_ShouldReturnDefaultView_WhenPassedValidInput()
        {
            // Arrange
            var mockedService = new Mock<IBookService>();

            //Act
            var sut = new SearchController(mockedService.Object);

            //Asssert
            sut.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }

        [Test]
        [Category("SearchController.Search")]
        public void Search_ShouldHaveHttpPostAttribute()
        {
            // Arrange
            var method = typeof(SearchController).GetMethod("Search");

            //Act
            //Asssert
            Assert.True(method.GetCustomAttributes(typeof(HttpPostAttribute), false).Any());
        }

        [Test]
        [Category("SearchController.Search")]
        public void Search_ShouldHaveAjaxOnlyAttribute()
        {
            // Arrange
            var method = typeof(SearchController).GetMethod("Search");

            //Act
            //Asssert
            Assert.True(method.GetCustomAttributes(typeof(AjaxOnlyAttribute), false).Any());
        }

        [Test]
        [Category("SearchController.Search")]
        public void Search_ShouldHaveValidateAntiForgeryTokenAttribute()
        {
            // Arrange
            var method = typeof(SearchController).GetMethod("Search");

            //Act
            //Asssert
            Assert.True(method.GetCustomAttributes(typeof(ValidateAntiForgeryTokenAttribute), false).Any());
        }
    }
}
