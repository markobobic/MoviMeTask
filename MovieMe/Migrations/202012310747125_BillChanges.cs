namespace MovieMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BillChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bills", "Buyer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bills", new[] { "Buyer_Id" });
            DropColumn("dbo.Bills", "Tax");
            DropColumn("dbo.Bills", "Buyer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "Buyer_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Bills", "Tax", c => c.Double(nullable: false));
            CreateIndex("dbo.Bills", "Buyer_Id");
            AddForeignKey("dbo.Bills", "Buyer_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
