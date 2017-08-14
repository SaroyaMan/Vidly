namespace Vidly_New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertGenres : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Genres SET Name = 'Action' Where Id = 1");
            Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Comedy')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Sci-Fi')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Horror')");
            Sql("INSERT INTO Genres(Id, Name) VALUES(5, 'Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
