using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Data.Models.Abstractions;
using LibrarySystem.Web.Models;

namespace LibrarySystem.Data.Models
{
    public class Rating : DataModel
    {
        [Required]
        [Range(0.0, 5.0, ErrorMessage = "Invalid Book Rating")]
        public float Value { get; set; }

        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
