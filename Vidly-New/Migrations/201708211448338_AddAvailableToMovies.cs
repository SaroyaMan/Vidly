namespace Vidly_New.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Available", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET Available = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Available");
        }
    }
}
