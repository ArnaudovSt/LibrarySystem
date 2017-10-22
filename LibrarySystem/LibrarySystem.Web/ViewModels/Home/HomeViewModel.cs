using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibrarySystem.Web.ViewModels.Book;

namespace LibrarySystem.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public LatestAddedBookViewModel LatestBook { get; set; }

        public ICollection<BookViewModel> TopRatedBooks { get; set; }
    }
}