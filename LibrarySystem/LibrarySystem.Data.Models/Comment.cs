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
    public class Comment : DataModel
    {
        [DataType(DataType.MultilineText)]
        [StringLength(2048, ErrorMessage = "Invalid Comment Length", MinimumLength = 1)]
        public string Content { get; set; }

        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }
}
