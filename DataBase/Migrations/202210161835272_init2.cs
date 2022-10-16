namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SellerCustomers", "Seller_Id", "dbo.Sellers");
            DropForeignKey("dbo.SellerCustomers", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.ItemSellers", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.ItemSellers", "Seller_Id", "dbo.Sellers");
            DropIndex("dbo.SellerCustomers", new[] { "Seller_Id" });
            DropIndex("dbo.SellerCustomers", new[] { "Customer_Id" });
            DropIndex("dbo.ItemSellers", new[] { "Item_Id" });
            DropIndex("dbo.ItemSellers", new[] { "Seller_Id" });
            AddColumn("dbo.Items", "SelledQuantity", c => c.Int(nullable: false));
            DropTable("dbo.SellerCustomers");
            DropTable("dbo.ItemSellers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ItemSellers",
                c => new
                    {
                        Item_Id = c.Int(nullable: false),
                        Seller_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Item_Id, t.Seller_Id });
            
            CreateTable(
                "dbo.SellerCustomers",
                c => new
                    {
                        Seller_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Seller_Id, t.Customer_Id });
            
            DropColumn("dbo.Items", "SelledQuantity");
            CreateIndex("dbo.ItemSellers", "Seller_Id");
            CreateIndex("dbo.ItemSellers", "Item_Id");
            CreateIndex("dbo.SellerCustomers", "Customer_Id");
            CreateIndex("dbo.SellerCustomers", "Seller_Id");
            AddForeignKey("dbo.ItemSellers", "Seller_Id", "dbo.Sellers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ItemSellers", "Item_Id", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SellerCustomers", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SellerCustomers", "Seller_Id", "dbo.Sellers", "Id", cascadeDelete: true);
        }
    }
}
