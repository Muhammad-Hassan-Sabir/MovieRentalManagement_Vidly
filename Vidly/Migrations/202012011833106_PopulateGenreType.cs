namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreType : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "GenresId");
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_GenresId");
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");

        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenresId", newName: "IX_GenreId");
            RenameColumn(table: "dbo.Movies", name: "GenresId", newName: "GenreId");
        }
    }
}
