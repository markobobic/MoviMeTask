namespace MovieMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNameToFilms : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "Name");
        }
    }
}
