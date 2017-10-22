using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.Web.ViewModels.Rating
{
    public class RatingViewModel
    {
        public Guid Id { get; set; }

        public double BookRating { get; set; }

        public double UserRating { get; set; }
    }
}