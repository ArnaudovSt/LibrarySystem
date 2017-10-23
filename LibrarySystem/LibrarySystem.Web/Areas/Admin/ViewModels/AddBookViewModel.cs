using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibrarySystem.Web.Areas.Admin.ViewModels
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(128, ErrorMessage = "Book Title Invalid Length", MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [RegularExpression(@"^(97(8|9))?\d{9}(\d|X)$", ErrorMessage = "Book ISBN Invalid Length")]
        public string ISBN { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(2048, ErrorMessage = "Book Description Invalid Length", MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        [Range(1, 32768, ErrorMessage = "Book PageCount cannot be {0}. It must be between {1} and {2}.")]
        public int PageCount { get; set; }

        [Required]
        [Range(1, 4096, ErrorMessage = "Book YearOfPublishing cannot be {0}. It must be between {1} and {2}.")]
        public int YearOfPublishing { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Author FirstName Invalid Length", MinimumLength = 1)]
        public string AuthorFirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Author LastName Invalid Length", MinimumLength = 1)]
        public string AuthorLastName { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "Genre Name Invalid Length", MinimumLength = 1)]
        public string GenreName { get; set; }
    }
}