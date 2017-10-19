using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using LibrarySystem.Data.Models;
using LibrarySystem.Data.Models.Contracts;
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

        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Book> Books { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Lending> Lendings { get; set; }
        public IDbSet<Rating> Ratings { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                            e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public static LibrarySystemDbContext Create()
        {
            return new LibrarySystemDbContext();
        }

        // TODO: !!!
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}