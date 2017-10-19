using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LibrarySystem.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class User : IdentityUser
    {
        private ICollection<Lending> lendings;
        private ICollection<Book> wantToRead;

        public User()
        {
            this.lendings = new HashSet<Lending>();
            this.wantToRead = new HashSet<Book>();
        }

        public virtual ICollection<Lending> Lendings
        {
            get
            {
                return this.lendings;
            }

            set
            {
                this.lendings = value;
            }
        }

        public virtual ICollection<Book> WantToRead
        {
            get
            {
                return this.wantToRead;
            }

            set
            {
                this.wantToRead = value;
            }
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}