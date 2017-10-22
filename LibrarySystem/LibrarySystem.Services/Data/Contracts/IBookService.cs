using System;
using System.Linq;
using LibrarySystem.Data.Models;

namespace LibrarySystem.Services.Data.Contracts
{
    public interface IBookService
    {
        IQueryable<Book> GetBookById(Guid id);

        IQueryable<Book> Search(string searchPhrase, string category);

        IQueryable<Book> GetLatestAddedBook();

        IQueryable<Book> GetBooksWithHighestRating();

        double GetBookRating(Guid id);
    }
}