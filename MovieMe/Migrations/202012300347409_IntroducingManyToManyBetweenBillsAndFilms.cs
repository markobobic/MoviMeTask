namespace MovieMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntroducingManyToManyBetweenBillsAndFilms : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Bill_Id", "dbo.Bills");
            DropIndex("dbo.Films", new[] { "Bill_Id" });
            CreateTable(
                "dbo.FilmBills",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Bill_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Bill_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bills", t => t.Bill_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Bill_Id);
            
            DropColumn("dbo.Films", "Bill_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "Bill_Id", c => c.Int());
            DropForeignKey("dbo.FilmBills", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.FilmBills", "Film_Id", "dbo.Films");
            DropIndex("dbo.FilmBills", new[] { "Bill_Id" });
            DropIndex("dbo.FilmBills", new[] { "Film_Id" });
            DropTable("dbo.FilmBills");
            CreateIndex("dbo.Films", "Bill_Id");
            AddForeignKey("dbo.Films", "Bill_Id", "dbo.Bills", "Id");
        }
    }
}
