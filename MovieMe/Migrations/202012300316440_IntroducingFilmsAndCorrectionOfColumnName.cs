namespace MovieMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntroducingFilmsAndCorrectionOfColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "ShortDescription", c => c.String());
            AddColumn("dbo.Directors", "ShortDescription", c => c.String());
            AddColumn("dbo.Producers", "ShortDescription", c => c.String());
            DropColumn("dbo.Actors", "ShorDescription");
            DropColumn("dbo.Directors", "ShorDescription");
            DropColumn("dbo.Producers", "ShorDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producers", "ShorDescription", c => c.String());
            AddColumn("dbo.Directors", "ShorDescription", c => c.String());
            AddColumn("dbo.Actors", "ShorDescription", c => c.String());
            DropColumn("dbo.Producers", "ShortDescription");
            DropColumn("dbo.Directors", "ShortDescription");
            DropColumn("dbo.Actors", "ShortDescription");
        }
    }
}
