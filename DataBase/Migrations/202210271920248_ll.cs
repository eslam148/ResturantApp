namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerBills", "BillID", "dbo.Bills");
            DropIndex("dbo.CustomerBills", new[] { "BillID" });
            CreateTable(
                "dbo.CustomerBillBills",
                c => new
                    {
                        CustomerBill_Id = c.Int(nullable: false),
                        Bill_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerBill_Id, t.Bill_Id })
                .ForeignKey("dbo.CustomerBills", t => t.CustomerBill_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bills", t => t.Bill_Id, cascadeDelete: true)
                .Index(t => t.CustomerBill_Id)
                .Index(t => t.Bill_Id);
            
            AddColumn("dbo.Bills", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Bills", "Customer_Id");
            AddForeignKey("dbo.Bills", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerBillBills", "Bill_Id", "dbo.Bills");
            DropForeignKey("dbo.CustomerBillBills", "CustomerBill_Id", "dbo.CustomerBills");
            DropIndex("dbo.CustomerBillBills", new[] { "Bill_Id" });
            DropIndex("dbo.CustomerBillBills", new[] { "CustomerBill_Id" });
            DropIndex("dbo.Bills", new[] { "Customer_Id" });
            DropColumn("dbo.Bills", "Customer_Id");
            DropTable("dbo.CustomerBillBills");
            CreateIndex("dbo.CustomerBills", "BillID");
            AddForeignKey("dbo.CustomerBills", "BillID", "dbo.Bills", "Id", cascadeDelete: true);
        }
    }
}
