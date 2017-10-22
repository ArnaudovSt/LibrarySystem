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
        public ICollection<Author> Authors;

        public ICollection<Genre> Genres;

        public ICollection<Comment> Comments;

        public ICollection<Rating> Ratings;

        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Description { get; set; }

        public int PageCount { get; set; }

        public int YearOfPublishing { get; set; }
    }
}