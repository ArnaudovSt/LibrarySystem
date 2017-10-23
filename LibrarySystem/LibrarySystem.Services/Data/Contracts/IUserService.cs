using System;
using LibrarySystem.Data.Models;

namespace LibrarySystem.Services.Data
{
    public interface IUserService
    {
        void AddBook(Guid userId, Book book);
    }
}