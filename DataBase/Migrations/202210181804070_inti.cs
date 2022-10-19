namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inti : DbMigration
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KindOfPay = c.String(),
                        KindOfInvoice = c.String(),
                        sellerId = c.Int(nullable: false),
                        Billtems_Id = c.Int(),
                        CustomerBill_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sellers", t => t.sellerId, cascadeDelete: true)
                .ForeignKey("dbo.Billtems", t => t.Billtems_Id)
                .ForeignKey("dbo.CustomerBills", t => t.CustomerBill_Id)
                .Index(t => t.sellerId)
                .Index(t => t.Billtems_Id)
                .Index(t => t.CustomerBill_Id);
            
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
                        SelledQuantity = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Billtems_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Billtems", t => t.Billtems_Id)
                .Index(t => t.SupplierId)
                .Index(t => t.CategoryId)
                .Index(t => t.Billtems_Id);
            
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
                "dbo.CustomerBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        BillID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerBills", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Bills", "CustomerBill_Id", "dbo.CustomerBills");
            DropForeignKey("dbo.Items", "Billtems_Id", "dbo.Billtems");
            DropForeignKey("dbo.Items", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Bills", "Billtems_Id", "dbo.Billtems");
            DropForeignKey("dbo.Bills", "sellerId", "dbo.Sellers");
            DropIndex("dbo.CustomerBills", new[] { "CustomerID" });
            DropIndex("dbo.Items", new[] { "Billtems_Id" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "SupplierId" });
            DropIndex("dbo.Bills", new[] { "CustomerBill_Id" });
            DropIndex("dbo.Bills", new[] { "Billtems_Id" });
            DropIndex("dbo.Bills", new[] { "sellerId" });
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerBills");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Categories");
            DropTable("dbo.Items");
            DropTable("dbo.Sellers");
            DropTable("dbo.Bills");
            DropTable("dbo.Billtems");
        }
    }
}
