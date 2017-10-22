using System;
using System.Collections.Generic;
using LibrarySystem.Data.Models;
using LibrarySystem.Web.Infrastructure.Contracts;

namespace LibrarySystem.Web.ViewModels.Book
{
    public class BookViewModel : IMapFrom<Data.Models.Book>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}