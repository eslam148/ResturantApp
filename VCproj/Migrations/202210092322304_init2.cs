namespace VCproj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        KindOfPay = c.String(),
                        KindOfInvoice = c.String(),
                        sellerId = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        itemdId = c.Int(nullable: false),
                        category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.sellerId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.category_Id)
                .Index(t => t.sellerId)
                .Index(t => t.CustomerID)
                .Index(t => t.category_Id);
            
            CreateTable(
                "dbo.ItemBills",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Bill_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Bill_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bills", t => t.Bill_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Bill_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "category_Id", "dbo.Categories");
            DropForeignKey("dbo.Bills", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Bills", "sellerId", "dbo.Sellers");
            DropForeignKey("dbo.ItemBills", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.ItemBills", "Item_Id", "dbo.Items");
            DropIndex("dbo.ItemBills", new[] { "Bill_Id" });
            DropIndex("dbo.ItemBills", new[] { "Item_Id" });
            DropIndex("dbo.Bills", new[] { "category_Id" });
            DropIndex("dbo.Bills", new[] { "CustomerID" });
            DropIndex("dbo.Bills", new[] { "sellerId" });
            DropTable("dbo.ItemBills");
            DropTable("dbo.Bills");
        }
    }
}
