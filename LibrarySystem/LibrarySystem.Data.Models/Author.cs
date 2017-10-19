using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Data.Models.Abstractions;

namespace LibrarySystem.Data.Models
{
    public class Author : DataModel
    {
        private ICollection<Book> books;

        public Author()
        {
            this.books = new HashSet<Book>();
        }

        [Required]
        [StringLength(20, ErrorMessage = "Author FirstName Invalid Length", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Author LastName Invalid Length", MinimumLength = 1)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", this.FirstName, this.LastName);
            }
        }

        public virtual ICollection<Book> Books
        {
            get
            {
                return this.books;
            }

            set
            {
                this.books = value;
            }
        }
    }
}
