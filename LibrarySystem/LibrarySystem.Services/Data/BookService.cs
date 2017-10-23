using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Bytes2you.Validation;
using LibrarySystem.Common;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Services.Data.Contracts;

namespace LibrarySystem.Services.Data
{
    public class BookService : IBookService
    {
        private readonly IEfRepostory<Book> bookRepository;
        private readonly IEfRepostory<Genre> genresRepository;
        private readonly IEfRepostory<Author> authorRepository;

        public BookService(IEfRepostory<Book> bookRepository, IEfRepostory<Genre> genresRepository, IEfRepostory<Author> authorRepository)
        {
            Guard.WhenArgument(bookRepository, "Book Repository").IsNull().Throw();
            Guard.WhenArgument(genresRepository, "Genre Repository").IsNull().Throw();
            Guard.WhenArgument(bookRepository, "Author Repository").IsNull().Throw();

            this.bookRepository = bookRepository;
            this.genresRepository = genresRepository;
            this.authorRepository = authorRepository;
        }

        public IQueryable<Book> GetBookById(Guid id)
        {
            return this.bookRepository.All.Where(b => b.Id == id);
        }

        public IQueryable<Book> Search(string searchPhrase, string category)
        {
            string searchPhraseLower = searchPhrase.ToLower();

            switch (category)
            {
                case GlobalConstants.TitleSearchCategory:
                    {
                        return this.bookRepository.All
                            .Where(b => b.Title.ToLower()
                            .Contains(searchPhraseLower));
                    }

                case GlobalConstants.AuthorSearchCategory:
                    {
                        return this.bookRepository.All
                            .Where(b => b.Authors.Any(a => a.FirstName.ToLower().Contains(searchPhraseLower) ||
                            a.LastName.ToLower().Contains(searchPhraseLower)));
                    }

                case GlobalConstants.GenreSearchCategory:
                    {
                        return this.bookRepository.All
                            .Where(b => b.Genres.Any(g => g.Name.ToLower()
                            .Contains(searchPhraseLower)));
                    }

                default: throw new ArgumentException("Invalid Category!");
            }
        }

        public IQueryable<Book> GetLatestAddedBook()
        {
            return this.bookRepository.All.OrderByDescending(b => b.CreatedOn).Take(1);
        }

        public IQueryable<Book> GetBooksWithHighestRating()
        {
            return this.bookRepository.All.OrderByDescending(b => b.Ratings.Sum(r => r.Value) / b.Ratings.Count).Take(GlobalConstants.HomeViewNumberOfBooksWithHighestRating);
        }

        public double GetBookRating(Guid id)
        {
            var book = this.bookRepository.All
                .Where(b => b.Id == id)
                .Include(b => b.Ratings)
                .FirstOrDefault();

            if (book.Ratings != null && book.Ratings.Count > 0)
            {
                return book.Ratings.Sum(r => r.Value) / book.Ratings.Count;
            }

            return 0;
        }

        public void Add(string modelAuthorFirstName, string modelAuthorLastName, string modelDescription, string modelGenreName,
            string modelIsbn, int modelPageCount, string modelTitle, int modelYearOfPublishing)
        {
            var author =
                authorRepository.All.FirstOrDefault(a => a.FirstName == modelAuthorFirstName &&
                                                         a.LastName == modelAuthorLastName) ??
                new Author() { FirstName = modelAuthorFirstName, LastName = modelAuthorLastName };

            var genre = genresRepository.All.FirstOrDefault(g => g.Name == modelGenreName) ??
                        new Genre() { Name = modelGenreName };

            var book = new Book()
            {
                Authors = new List<Author>() {author},
                Genres = new List<Genre>() {genre},
                Ratings = new List<Rating>(),
                Description = modelDescription,
                ISBN = modelIsbn,
                PageCount = modelPageCount,
                Title = modelTitle,
                YearOfPublishing = modelYearOfPublishing
            };

            this.bookRepository.Add(book);
        }

        public IQueryable<Book> GetBooksByUserId(Guid id)
        {
            return this.bookRepository.All
                .Where(b => b.WantedBy.Any(u => u.Id == id.ToString()));
        }
    }
}
