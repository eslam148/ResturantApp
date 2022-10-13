namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.sellerId, cascadeDelete: true)
                .Index(t => t.sellerId)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BuyPrice = c.Int(nullable: false),
                        SellPrice = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.SupplierId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SellerCustomers",
                c => new
                    {
                        Seller_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seller_Id, t.Customer_Id })
                .ForeignKey("dbo.Sellers", t => t.Seller_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Seller_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.ItemSellers",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Seller_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Seller_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id, cascadeDelete: true)
                .Index(t => t.Item_Id)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.BillItems",
                c => new
                    {
                        Bill_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bill_Id, t.Item_Id })
                .ForeignKey("dbo.Bills", t => t.Bill_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Bill_Id)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "sellerId", "dbo.Sellers");
            DropForeignKey("dbo.BillItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.BillItems", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.Bills", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Items", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ItemSellers", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.ItemSellers", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.SellerCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.SellerCustomers", "Seller_Id", "dbo.Sellers");
            DropIndex("dbo.BillItems", new[] { "Item_Id" });
            DropIndex("dbo.BillItems", new[] { "Bill_Id" });
            DropIndex("dbo.ItemSellers", new[] { "Seller_Id" });
            DropIndex("dbo.ItemSellers", new[] { "Item_Id" });
            DropIndex("dbo.SellerCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.SellerCustomers", new[] { "Seller_Id" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "SupplierId" });
            DropIndex("dbo.Bills", new[] { "CustomerID" });
            DropIndex("dbo.Bills", new[] { "sellerId" });
            DropTable("dbo.BillItems");
            DropTable("dbo.ItemSellers");
            DropTable("dbo.SellerCustomers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Sellers");
            DropTable("dbo.Customers");
            DropTable("dbo.Bills");
        }
    }
}
