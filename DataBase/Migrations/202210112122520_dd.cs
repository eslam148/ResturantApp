namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
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
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
            
            CreateTable(
                "dbo.CustomerSellers",
                c => new
                    {
                        Customer_Id = c.Int(nullable: false),
                        Seller_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Customer_Id, t.Seller_Id })
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.Seller_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Seller_Id);
            
            CreateTable(
                "dbo.SellerItems",
                c => new
                    {
                        Seller_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seller_Id, t.Item_Id })
                .ForeignKey("dbo.Sellers", t => t.Seller_Id, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .Index(t => t.Seller_Id)
                .Index(t => t.Item_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "category_Id", "dbo.Categories");
            DropForeignKey("dbo.Items", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SellerItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.SellerItems", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.CustomerSellers", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.CustomerSellers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Bills", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Bills", "sellerId", "dbo.Sellers");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ItemBills", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.ItemBills", "Item_Id", "dbo.Items");
            DropIndex("dbo.SellerItems", new[] { "Item_Id" });
            DropIndex("dbo.SellerItems", new[] { "Seller_Id" });
            DropIndex("dbo.CustomerSellers", new[] { "Seller_Id" });
            DropIndex("dbo.CustomerSellers", new[] { "Customer_Id" });
            DropIndex("dbo.ItemBills", new[] { "Bill_Id" });
            DropIndex("dbo.ItemBills", new[] { "Item_Id" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "SupplierId" });
            DropIndex("dbo.Bills", new[] { "category_Id" });
            DropIndex("dbo.Bills", new[] { "CustomerID" });
            DropIndex("dbo.Bills", new[] { "sellerId" });
            DropTable("dbo.SellerItems");
            DropTable("dbo.CustomerSellers");
            DropTable("dbo.ItemBills");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Customers");
            DropTable("dbo.Sellers");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
            DropTable("dbo.Bills");
        }
    }
}
