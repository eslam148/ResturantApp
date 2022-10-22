namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billtems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        itemdId = c.Int(nullable: false),
                        BillId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.itemdId, cascadeDelete: true)
                .Index(t => t.itemdId)
                .Index(t => t.BillId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KindOfPay = c.Boolean(nullable: false),
                        sellerId = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        dateOfBill = c.DateTime(nullable: false),
                        dateOfPay = c.DateTime(nullable: false),
                        RestOfTheInvoicePrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.sellerId, cascadeDelete: true)
                .Index(t => t.sellerId);
            
            CreateTable(
                "dbo.CustomerBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        BillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bills", t => t.BillID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.BillID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
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
                        SelledQuantity = c.Int(nullable: false),
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
                        Phone = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billtems", "itemdId", "dbo.Items");
            DropForeignKey("dbo.Items", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Billtems", "BillId", "dbo.Bills");
            DropForeignKey("dbo.Bills", "sellerId", "dbo.Sellers");
            DropForeignKey("dbo.CustomerBills", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CustomerBills", "BillID", "dbo.Bills");
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "SupplierId" });
            DropIndex("dbo.CustomerBills", new[] { "BillID" });
            DropIndex("dbo.CustomerBills", new[] { "CustomerID" });
            DropIndex("dbo.Bills", new[] { "sellerId" });
            DropIndex("dbo.Billtems", new[] { "BillId" });
            DropIndex("dbo.Billtems", new[] { "itemdId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Sellers");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerBills");
            DropTable("dbo.Bills");
            DropTable("dbo.Billtems");
        }
    }
}
