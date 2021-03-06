﻿using System;
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

        void Add(string modelAuthorFirstName, string modelAuthorLastName, string modelDescription, string modelGenreName, string modelIsbn, int modelPageCount, string modelTitle, int modelYearOfPublishing);

        IQueryable<Book> GetBooksByUserId(Guid id);
    }
}