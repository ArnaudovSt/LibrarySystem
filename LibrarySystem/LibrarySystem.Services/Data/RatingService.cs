using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;
using LibrarySystem.Common;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.Repositories;
using LibrarySystem.Services.Data.Contracts;

namespace LibrarySystem.Services.Data
{
    public class RatingService : IRatingService
    {
        private readonly IEfRepostory<Rating> ratingRepository;

        public RatingService(IEfRepostory<Rating> ratingRepository)
        {
            Guard.WhenArgument(ratingRepository, "Rating Repository").IsNull().Throw();

            this.ratingRepository = ratingRepository;
        }

        public double GetRating(Guid bookId, Guid userId)
        {
            return this.ratingRepository.All.FirstOrDefault(r => r.BookId == bookId && r.UserId == userId)?.Value ?? GlobalConstants.BookRatingDefaultValue;
        }

        public void AddRating(Guid bookId, Guid userId, double rating)
        {
            this.ratingRepository.Add(new Rating()
            {
                BookId = bookId,
                UserId = userId,
                Value = rating
            });
        }
    }
}
