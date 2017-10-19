using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Data.Models.Abstractions;

namespace LibrarySystem.Data.Models
{
    public class Lending : DataModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
