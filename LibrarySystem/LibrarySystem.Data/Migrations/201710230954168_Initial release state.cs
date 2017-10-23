namespace LibrarySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialreleasestate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Ratings", "BookId", "dbo.Books");
            DropForeignKey("dbo.UserBooks", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            AddForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors", "Id");
            AddForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.Ratings", "BookId", "dbo.Books", "Id");
            AddForeignKey("dbo.UserBooks", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.UserBooks", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.UserBooks", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "BookId", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserBooks", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserBooks", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
