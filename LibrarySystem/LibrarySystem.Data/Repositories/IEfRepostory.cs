using System.Linq;
using LibrarySystem.Data.Models.Contracts;

namespace LibrarySystem.Data.Repositories
{
    public interface IEfRepostory<T> where T : class, IDeletable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}