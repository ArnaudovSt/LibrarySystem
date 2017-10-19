using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.UnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly LibrarySystemDbContext context;

        public EfUnitOfWork(LibrarySystemDbContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
