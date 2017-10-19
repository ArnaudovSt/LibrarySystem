using LibrarySystem.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Data
{
    public class LibrarySystemDbContext : IdentityDbContext<User>
    {
        private const string LocalDbConnection = "LocalConnection";

        public LibrarySystemDbContext()
            : base(LocalDbConnection, throwIfV1Schema: false)
        {
        }

        public static LibrarySystemDbContext Create()
        {
            return new LibrarySystemDbContext();
        }
    }
}