using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Services.Data;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Services.UnitTests.Data.UserServiceTests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        [Category("UserService.Constructor")]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNull()
        {
            // Arrange
            //Act
            //Asssert
            Assert.Throws<ArgumentNullException>(() => new UserService(null));
        }

        [Test]
        [Category("UserService.Constructor")]
        public void Constructor_ShouldCreateAnInstanceOfUserService_WhenPassedValidInput()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<User>>();

            //Act
            var result = new UserService(mockedRepo.Object);

            //Asssert
            Assert.That(result, Is.InstanceOf<UserService>());
        }

        [Test]
        [Category("UserService.AddBook")]
        public void AddBook_ShouldAddBookToUsersWantToReadCollection_WhenPassedValidArguments()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<User>>();
            var guid = Guid.NewGuid();
            var book = new Book();
            var bookCollection = new List<Book>();
            var user = new User()
            {
                Id = guid.ToString(),
                WantToRead = bookCollection
            };

            var query = new List<User>()
            {
                user
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new UserService(mockedRepo.Object);

            //Act
            sut.AddBook(guid, book);

            //Asssert
            CollectionAssert.Contains(user.WantToRead, book);
        }

        [Test]
        [Category("UserService.AddBook")]
        public void AddBook_ShouldNotAddBookToUsersWantToReadCollection_WhenPassedInvalidUserId()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<User>>();
            var guid = Guid.NewGuid();
            var book = new Book();
            var bookCollection = new List<Book>();
            var user = new User()
            {
                Id = guid.ToString(),
                WantToRead = bookCollection
            };

            var query = new List<User>()
            {
                user
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new UserService(mockedRepo.Object);

            //Act
            sut.AddBook(Guid.NewGuid(), book);

            //Asssert
            CollectionAssert.IsEmpty(user.WantToRead);
        }
    }
}
