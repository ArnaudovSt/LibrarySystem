using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Common;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Services.Data;
using Moq;
using NUnit.Framework;

namespace LibrarySystem.Services.UnitTests.Data.RatingServiceTests
{
    [TestFixture]
    public class RatingServiceTests
    {
        [Test]
        [Category("RatingService.Constructor")]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNull()
        {
            // Arrange
            //Act
            //Asssert
            Assert.Throws<ArgumentNullException>(() => new RatingService(null));
        }

        [Test]
        [Category("RatingService.Constructor")]
        public void Constructor_ShouldCreateAnInstanceOfRatingService_WhenPassedValidInput()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Rating>>();

            //Act
            var result = new RatingService(mockedRepo.Object);

            //Asssert
            Assert.That(result, Is.InstanceOf<RatingService>());
        }

        [Test]
        [Category("RatingService.GetRating")]
        public void GetRating_ShouldReturnRatingDefaultValue_WhenThereAreNoRatings()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Rating>>();
            var guid = Guid.NewGuid();
            var sut = new RatingService(mockedRepo.Object);
            //Act
            var result = sut.GetRating(guid, guid);
            //Asssert
            Assert.That(result, Is.EqualTo(GlobalConstants.BookRatingDefaultValue));
        }

        [Test]
        [Category("RatingService.GetRating")]
        public void GetRating_ShouldReturnCorrectRatingValue_WhenPassedValidArguments()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Rating>>();
            var guid = Guid.NewGuid();

            var rating = new Rating()
            {
                BookId = guid,
                UserId = guid,
                Value = 1
            };

            var query = new List<Rating>()
            {
                rating
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new RatingService(mockedRepo.Object);

            //Act
            var result = sut.GetRating(guid, guid);

            //Asssert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [Category("RatingService.AddRating")]
        public void AddRating_ShouldAddRating_WhenPassedValidArguments()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Rating>>();
            var guid = Guid.NewGuid();
            var rating = 1;

            var expected = new Rating()
            {
                BookId = guid,
                UserId = guid,
                Value = 1
            };

            var sut = new RatingService(mockedRepo.Object);
            mockedRepo.Setup(x => x.Add(It.IsAny<Rating>()));

            //Act
            sut.AddRating(guid, guid, rating);

            //Asssert
            mockedRepo.Verify(x => x.Add(It.Is<Rating>(r => r.BookId == guid && r.UserId == guid && r.Value == rating)), Times.Once);
        }
    }
}
