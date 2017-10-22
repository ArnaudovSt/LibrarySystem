using System;

namespace LibrarySystem.Services.Data.Contracts
{
    public interface IRatingService
    {
        double GetRating(Guid bookId, Guid userId);

        void AddRating(Guid bookId, Guid userId, double rating);
    }
}