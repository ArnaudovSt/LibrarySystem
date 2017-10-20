using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bytes2you.Validation;

namespace LibrarySystem.Data.UnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly LibrarySystemDbContext context;

        public EfUnitOfWork(LibrarySystemDbContext context)
        {
            Guard.WhenArgument(context, "Unit of work dbcontext").IsNull().Throw();

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
