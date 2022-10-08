namespace VCproj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.Items", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.SellerItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.SellerItems", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.CustomerSellers", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.CustomerSellers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SellerItems", new[] { "Item_Id" });
            DropIndex("dbo.SellerItems", new[] { "Seller_Id" });
            DropIndex("dbo.CustomerSellers", new[] { "Seller_Id" });
            DropIndex("dbo.CustomerSellers", new[] { "Customer_Id" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "SupplierId" });
            DropTable("dbo.SellerItems");
            DropTable("dbo.CustomerSellers");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Customers");
            DropTable("dbo.Sellers");
            DropTable("dbo.Items");
            DropTable("dbo.Categories");
        }
    }
}
