using System.Collections.Generic;
using LibrarySystem.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Data.Migrations
{
    using LibrarySystem.Common;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class MigrationsConfiguration : DbMigrationsConfiguration<LibrarySystem.Data.LibrarySystemDbContext>
    {
        public MigrationsConfiguration()
        {
            // TODO: !!!
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LibrarySystem.Data.LibrarySystemDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedSampleData(context);
        }

        private void SeedSampleData(LibrarySystemDbContext context)
        {
            if (!context.Books.Any())
            {
                Author markSeemann =  new Author { FirstName = "Mark", LastName = "Seemann"};

                Author royOsherove =  new Author { FirstName = "Roy", LastName = "Osherove"};

                Author martinFowler =  new Author { FirstName = "Martin", LastName = "Fowler"};

                Genre software =  new Genre { Name = "Software" };

                Genre technical =  new Genre { Name = "Technical" };

                Genre programming = new Genre { Name = "Programming" };

                Book theBook = new Book
                               {
                                   Title = "Dependency Injection in .NET",
                                   ISBN = "9781935182504",
                                   Description = @"Dependency Injection in .NET introduces DI and provides a practical guide for applying it in .NET applications.
                                    The book presents the core patterns in plain C#, so you'll fully understand how DI works. Then you'll learn to integrate DI
                                    with standard Microsoft technologies like ASP.NET MVC, and to use DI frameworks like StructureMap, Castle Windsor, and Unity.
                                    By the end of the book, you'll be comfortable applying this powerful technique in your everyday .NET development.",
                                   PageCount = 584,
                                   YearOfPublishing = 2011,
                                   InitialQuantity = 42,
                                   Available = 42,
                                   Authors = new HashSet<Author>()
                                   {
                                       markSeemann
                                   },
                                   Genres = new HashSet<Genre>()
                                   {
                                       software
                                   }
                               };

                Book theArtOfUnitTesting = new Book
                                           {
                                               Title = "The Art of Unit Testing",
                                               ISBN = "9781933988276",
                                               Description = @"The Art of Unit Testing builds on top of what's already been written about this important topic. It guides you step by step
                                    from simple tests to tests that are maintainable, readable, and trustworthy. It covers advanced subjects like mocks, stubs,
                                    and frameworks such as Typemock Isolator and Rhino Mocks. And you'll learn about advanced test patterns and organization,
                                    working with legacy code and even untestable code. The book discusses tools you need when testing databases and other technologies.",
                                               PageCount = 320,
                                               YearOfPublishing = 2009,
                                               InitialQuantity = 37,
                                               Available = 37,
                                               Authors = new HashSet<Author>()
                                               {
                                                   royOsherove
                                               },
                                               Genres = new HashSet<Genre>()
                                               {
                                                   software,
                                                   technical
                                               }
                                           };

                Book patternsOfEnterpriseAppArchitecture = context.Books
                                                               .Where(b => b.ISBN == "9780321127426")
                                                               .SingleOrDefault() ?? new Book
                                                           {
                                                               Title = "Patterns of Enterprise Application Architecture",
                                                               ISBN = "9780321127426",
                                                               Description = @"These pages are a brief overview of each of the patterns in P of EAA. They aren't intended to stand alone, but merely as a quick
                                    aide-memoire for those familiar with them, and a handy link if you want to refer to one online. In the future I may add some
                                    post-publication comments into the material here, but we'll see how that works out.",
                                                               PageCount = 533,
                                                               YearOfPublishing = 2003,
                                                               InitialQuantity = 31,
                                                               Available = 31,
                                                               Authors = new HashSet<Author>()
                                                               {
                                                                   martinFowler
                                                               },
                                                               Genres = new HashSet<Genre>()
                                                               {
                                                                   software,
                                                                   programming
                                                               },
                                                           };
                context.Books.Add(theBook);
                context.Books.Add(theArtOfUnitTesting);
                context.Books.Add(patternsOfEnterpriseAppArchitecture);
            }
        }

        private void SeedAdmin(LibrarySystemDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "123qwe";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdminRole };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, GlobalConstants.AdminRole);
            }
        }
    }
}
