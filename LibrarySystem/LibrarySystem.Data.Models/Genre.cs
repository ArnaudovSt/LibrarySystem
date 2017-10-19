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
    public class Genre : DataModel
    {
        private ICollection<Book> books;

        public Genre()
        {
            this.books = new HashSet<Book>();
        }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(64, ErrorMessage = "Genre Name Invalid Length", MinimumLength = 1)]
        public string Name { get; set; }

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
