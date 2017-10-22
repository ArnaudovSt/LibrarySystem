using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Web.ViewModels.Search
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Search phrase is required!")]
        [MaxLength(30, ErrorMessage = "Search phrase too long!")]
        public string SearchedWord { get; set; }

        [Required]
        public string Category { get; set; }
    }
}