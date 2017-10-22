using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibrarySystem.Web.ViewModels.Book;

namespace LibrarySystem.Web.ViewModels.Search
{
    public class SearchResultsViewModel
    {
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}