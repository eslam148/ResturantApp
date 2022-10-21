namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hh : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Items", new[] { "SupplierId" });
            CreateIndex("dbo.Items", "SupplierId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Items", new[] { "SupplierId" });
            CreateIndex("dbo.Items", "SupplierId");
        }
    }
}
