using System;
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

        public BookService(IEfRepostory<Book> bookRepository)
        {
            Guard.WhenArgument(bookRepository, "bookRepository").IsNull().Throw();

            this.bookRepository = bookRepository;
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
    }
}
