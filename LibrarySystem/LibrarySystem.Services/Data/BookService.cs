using System;
using System.Linq;
using Bytes2you.Validation;
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
    }
}
