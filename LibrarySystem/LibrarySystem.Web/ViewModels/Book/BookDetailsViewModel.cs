using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibrarySystem.Data.Models;
using LibrarySystem.Web.Infrastructure.Contracts;

namespace LibrarySystem.Web.ViewModels.Book
{
    public class BookDetailsViewModel : IMapFrom<Data.Models.Book>
    {
        public ICollection<Genre> Genres { get; set; }
    }
}