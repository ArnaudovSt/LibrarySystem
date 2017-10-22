using System;
using System.Linq;
using LibrarySystem.Data.Models;

namespace LibrarySystem.Services.Data.Contracts
{
    public interface IBookService
    {
        IQueryable<Book> GetBookById(Guid id);

        IQueryable<Book> Search(string searchPhrase, string category);
    }
}