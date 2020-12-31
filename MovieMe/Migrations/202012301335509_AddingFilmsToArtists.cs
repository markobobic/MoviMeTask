namespace MovieMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFilmsToArtists : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FilmBills", newName: "BillFilms");
            DropForeignKey("dbo.Actors", "Film_Id", "dbo.Films");
            DropIndex("dbo.Actors", new[] { "Film_Id" });
            DropPrimaryKey("dbo.BillFilms");
            CreateTable(
                "dbo.FilmActors",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Actor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Actor_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Actor_Id);
            
            AddPrimaryKey("dbo.BillFilms", new[] { "Bill_Id", "Film_Id" });
            DropColumn("dbo.Actors", "Film_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Actors", "Film_Id", c => c.Int());
            DropForeignKey("dbo.FilmActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.FilmActors", "Film_Id", "dbo.Films");
            DropIndex("dbo.FilmActors", new[] { "Actor_Id" });
            DropIndex("dbo.FilmActors", new[] { "Film_Id" });
            DropPrimaryKey("dbo.BillFilms");
            DropTable("dbo.FilmActors");
            AddPrimaryKey("dbo.BillFilms", new[] { "Film_Id", "Bill_Id" });
            CreateIndex("dbo.Actors", "Film_Id");
            AddForeignKey("dbo.Actors", "Film_Id", "dbo.Films", "Id");
            RenameTable(name: "dbo.BillFilms", newName: "FilmBills");
        }
    }
}
