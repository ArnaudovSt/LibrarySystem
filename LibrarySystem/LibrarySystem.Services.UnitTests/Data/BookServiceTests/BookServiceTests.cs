using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Common;
using LibrarySystem.Data.Models;
using LibrarySystem.Services.Data;
using Moq;
using NUnit.Framework;
using LibrarySystem.Data.Repositories;

namespace LibrarySystem.Services.UnitTests.Data.BookServiceTests
{
    [TestFixture]
    public class BookServiceTests
    {
        [Test]
        [Category("BookService.Constructor")]
        public void Constructor_ShouldThrowArgumentNullException_WhenPassedNull()
        {
            // Arrange
            //Act
            //Asssert
            Assert.Throws<ArgumentNullException>(() => new BookService(null));
        }

        [Test]
        [Category("BookService.Constructor")]
        public void Constructor_ShouldCreateAnInstanceOfBookService_WhenPassedValidInput()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            //Act
            var result = new BookService(mockedRepo.Object);

            //Asssert
            Assert.That(result, Is.InstanceOf<BookService>());
        }

        [Test]
        [Category("BookService.GetBookById")]
        public void GetBookById_ShouldReturnCorrectQuery_WhenPassedExistingId()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var guid = Guid.NewGuid();
            var book = new Book() { Id = guid };
            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBookById(guid);

            //Asssert
            Assert.That(query, Is.EquivalentTo(result));
        }

        [Test]
        [Category("BookService.GetBookById")]
        public void GetBookById_ShouldReturnCorrectBook_WhenPassedExistingId()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var guid = Guid.NewGuid();
            var book = new Book() { Id = guid };
            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBookById(guid).First();

            //Asssert
            Assert.That(book, Is.SameAs(result));
        }

        [Test]
        [Category("BookService.GetBookById")]
        public void GetBookById_ShouldReturnEmptyQuery_WhenPassedNonExistingId()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var guid = Guid.NewGuid();
            var book = new Book();
            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBookById(guid);

            //Asssert
            Assert.That(result, Is.Empty);
        }

        [Test]
        [Category("BookService.GetBookById")]
        public void GetBookById_ShouldReturnNull_WhenPassedNonExistingId()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var guid = Guid.NewGuid();
            var book = new Book();
            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBookById(guid).FirstOrDefault();

            //Asssert
            Assert.That(result, Is.Null);
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldThrowArgumentException_WhenPassedNonExistingCategory()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var sut = new BookService(mockedRepo.Object);

            //Act
            //Asssert
            Assert.Throws<ArgumentException>(() => sut.Search("_", "nonexisting category"));
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnCorrectQuery_WhenSearchedByTitle()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(testTitle, GlobalConstants.TitleSearchCategory);

            //Asssert
            Assert.That(result, Is.EquivalentTo(query));
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnEmptyQuery_WhenSearchedByNonExistingTitle()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";
            string empty = "empty";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(empty, GlobalConstants.TitleSearchCategory);

            //Asssert
            Assert.That(result, Is.Empty);
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnCorrectBook_WhenSearchedByTitle()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(testTitle, GlobalConstants.TitleSearchCategory).First();

            //Asssert
            Assert.That(result, Is.SameAs(book));
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnCorrectQuery_WhenSearchedByAuthor()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(testAuthor, GlobalConstants.AuthorSearchCategory);

            //Asssert
            Assert.That(result, Is.EquivalentTo(query));
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnEmptyQuery_WhenSearchedByNonExistingAuthor()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";
            string empty = "empty";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor,
                LastName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(empty, GlobalConstants.AuthorSearchCategory);

            //Asssert
            Assert.That(result, Is.Empty);
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnCorrectBook_WhenSearchedByAuthor()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(testAuthor, GlobalConstants.AuthorSearchCategory).First();

            //Asssert
            Assert.That(result, Is.SameAs(book));
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnCorrectQuery_WhenSearchedByGenre()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(testGenre, GlobalConstants.GenreSearchCategory);

            //Asssert
            Assert.That(result, Is.EquivalentTo(query));
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnEmptyQuery_WhenSearchedByNonExistingGenre()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";
            string empty = "empty";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(empty, GlobalConstants.GenreSearchCategory);

            //Asssert
            Assert.That(result, Is.Empty);
        }

        [Test]
        [Category("BookService.Search")]
        public void Search_ShouldReturnCorrectBook_WhenSearchedByGenre()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            string testTitle = "testTitle";
            string testAuthor = "testAuthor";
            string testGenre = "testGenre";

            var book = new Book()
            {
                Title = testTitle,
            };

            book.Authors.Add(new Author()
            {
                FirstName = testAuthor
            });

            book.Genres.Add(new Genre()
            {
                Name = testGenre
            });

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.Search(testGenre, GlobalConstants.GenreSearchCategory).First();

            //Asssert
            Assert.That(result, Is.SameAs(book));
        }

        [Test]
        [Category("BookService.GetLatestAddedBook")]
        public void GetLatestAddedBook_ShouldReturnCorrectQuery_WhenPassedValidArguments()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            var firstBook = new Book()
            {
                CreatedOn = new DateTime()
            };

            var secondBook = new Book()
            {
                CreatedOn = new DateTime().AddDays(1)
            };

            var query = new List<Book>()
            {
                firstBook,
                secondBook
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetLatestAddedBook();

            //Asssert
            CollectionAssert.Contains(result, secondBook);
            CollectionAssert.DoesNotContain(result, firstBook);
        }

        [Test]
        [Category("BookService.GetLatestAddedBook")]
        public void GetLatestAddedBook_ShouldReturnEmptyQuery_WhenBookCollectionIsEmpty()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            var query = new List<Book>().AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetLatestAddedBook();

            //Asssert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        [Category("BookService.GetBooksWithHighestRating")]
        public void GetBooksWithHighestRating_ShouldReturnCorrectQuery_WhenPassedValidArguments()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            var first = new Book()
            {
                Ratings = new List<Rating>()
                {
                   new Rating()
                   {
                       Value = 1.1
                   }
                }
            };

            var second = new Book()
            {
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Value = 1.2
                    }
                }
            };

            var third = new Book()
            {
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Value = 1.3
                    }
                }
            };

            var fourth = new Book()
            {
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Value = 1.4
                    }
                }
            };

            var fifth = new Book()
            {
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Value = 1.5
                    }
                }
            };

            var sixth = new Book()
            {
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Value = 1.6
                    }
                }
            };

            var seventh = new Book()
            {
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Value = 1.7
                    }
                }
            };

            var eight = new Book()
            {
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Value = 1.8
                    }
                }
            };

            var ninth = new Book()
            {
                Ratings = new List<Rating>()
                {
                    new Rating()
                    {
                        Value = 1.9
                    }
                }
            };

            var query = new List<Book>()
            {
                first,
                second,
                third,
                fourth,
                fifth,
                sixth,
                seventh,
                eight,
                ninth
            }.AsQueryable();

            var expected = new List<Book>()
            {
                second,
                third,
                fourth,
                fifth,
                sixth,
                seventh,
                eight,
                ninth
            };

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBooksWithHighestRating();

            //Asssert
            CollectionAssert.DoesNotContain(result, first);
            CollectionAssert.AreEquivalent(result, expected);
        }

        [Test]
        [Category("BookService.GetBooksWithHighestRating")]
        public void GetBooksWithHighestRating_ShouldReturnEmptyQuery_WhenPassedEmptyBooksList()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();

            var query = new List<Book>().AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBooksWithHighestRating();

            //Asssert
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        [Category("BookService.GetBookRating")]
        public void GetBookRating_ShouldReturnZero_WhenBookHasNoRatings()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var guid = Guid.NewGuid();
            var book = new Book()
            {
                Id = guid
            };
            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBookRating(guid);

            //Asssert
            Assert.That((int)result, Is.EqualTo(0));
        }

        [Test]
        [Category("BookService.GetBookRating")]
        public void GetBookRating_ShouldReturnCorrectRating_WhenBookHasRatings()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var guid = Guid.NewGuid();

            var rating = new Rating()
            {
                Value = 1
            };

            var book = new Book()
            {
                Id = guid,
                Ratings = new List<Rating>()
                {
                    rating
                }
            };

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBookRating(guid);

            //Asssert
            Assert.That((int)result, Is.EqualTo(1));
        }

        [Test]
        [Category("BookService.GetBooksByUserId")]
        public void GetBooksByUserId_ShouldReturnCorrectQuery_WhenPassedValidArguments()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var guid = Guid.NewGuid();
            var user = new User()
            {
                Id = guid.ToString(),
            };

            var book = new Book()
            {
                WantedBy = new List<User>()
                {
                    user
                }
            };

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBooksByUserId(guid);

            //Asssert
            CollectionAssert.AreEquivalent(result, query);
        }

        [Test]
        [Category("BookService.GetBooksByUserId")]
        public void GetBooksByUserId_ShouldReturnEmptyQuery_WhenSearchedByNonexistingGuid()
        {
            // Arrange
            var mockedRepo = new Mock<IEfRepostory<Book>>();
            var guid = Guid.NewGuid();
            var user = new User()
            {
                Id = guid.ToString(),
            };

            var book = new Book()
            {
                WantedBy = new List<User>()
                {
                    user
                }
            };

            var query = new List<Book>()
            {
                book
            }.AsQueryable();

            mockedRepo.Setup(x => x.All).Returns(query);

            var sut = new BookService(mockedRepo.Object);

            //Act
            var result = sut.GetBooksByUserId(Guid.NewGuid());

            //Asssert
            CollectionAssert.IsEmpty(result);
        }
    }
}

