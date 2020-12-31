namespace MovieMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingDbTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BillItems", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.BillItems", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.BillItems", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.BillItems", new[] { "Bill_Id" });
            DropIndex("dbo.BillItems", new[] { "Film_Id" });
            DropIndex("dbo.BillItems", new[] { "Genre_Id" });
            AddColumn("dbo.Bills", "Buyer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Films", "Bill_Id", c => c.Int());
            CreateIndex("dbo.Bills", "Buyer_Id");
            CreateIndex("dbo.Films", "Bill_Id");
            AddForeignKey("dbo.Bills", "Buyer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Films", "Bill_Id", "dbo.Bills", "Id");
            DropColumn("dbo.Bills", "Buyer");
            DropTable("dbo.BillItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BillItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bill_Id = c.Int(),
                        Film_Id = c.Int(),
                        Genre_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bills", "Buyer", c => c.String(nullable: false, maxLength: 50));
            DropForeignKey("dbo.Films", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.Bills", "Buyer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Films", new[] { "Bill_Id" });
            DropIndex("dbo.Bills", new[] { "Buyer_Id" });
            DropColumn("dbo.Films", "Bill_Id");
            DropColumn("dbo.Bills", "Buyer_Id");
            CreateIndex("dbo.BillItems", "Genre_Id");
            CreateIndex("dbo.BillItems", "Film_Id");
            CreateIndex("dbo.BillItems", "Bill_Id");
            AddForeignKey("dbo.BillItems", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.BillItems", "Film_Id", "dbo.Films", "Id");
            AddForeignKey("dbo.BillItems", "Bill_Id", "dbo.Bills", "Id");
        }
    }
}
