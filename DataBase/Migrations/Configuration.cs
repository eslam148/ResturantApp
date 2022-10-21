namespace DataBase.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBase.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataBase.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            List<Supplier> suppliers = new List<Supplier>();
            suppliers.Add(new Supplier
            {
                Name="Eslam",
                Address="Cairo",
                Phone=011183923
            });
            suppliers.Add(new Supplier
            {
                Name="Amira",
                Address="Sohag",
                Phone=011183923
            });
            suppliers.Add(new Supplier
            {
                Name="Norahan",
                Address="Alix",
                Phone=011183923
            });
            suppliers.Add(new Supplier
            {
                Name="Mohamed",
                Address="Luxor",
                Phone=011183923
            });
           
            List<Category> categories = new List<Category>();
            categories.Add(new Category
            {
                Name="Phone"
            });
            categories.Add(new Category
            {
                Name="Eat"
            });
            categories.Add(new Category
            {
                Name="Elctronic"
            });
            List<Item> items = new List<Item>();
            items.Add(new Item
            {
                Name = "Samasunge",
                BuyPrice = 5500,
                SellPrice = 4000,
                Quantity = 5,
                SelledQuantity=0,
                CategoryId = 1,
                SupplierId = 1


            });
            items.Add(new Item
            {
                Name = "Hand Blinder",
                BuyPrice = 200,
                SellPrice = 2200,
                Quantity = 10,
                SelledQuantity=0,
                CategoryId = 3,
                SupplierId = 2


            });
            items.Add(new Item
            {
                Name = "Samasunge A52",
                BuyPrice = 8500,
                SellPrice = 8000,
                Quantity = 5,
                SelledQuantity=0,
                CategoryId = 1,
                SupplierId = 1

            });
            items.Add(new Item
            {
                Name = "Oppo Reno 5",
                BuyPrice = 5500,
                SellPrice = 4000,
                Quantity = 5,
                SelledQuantity=0,
                CategoryId = 1,
                SupplierId = 4

            });

            List<Seller> sellers = new List<Seller>();
            sellers.Add(new Seller
            {
                Name="Ahmed",
                Address = "Sohage",
                Phone = 0123849358
            });
            sellers.Add(new Seller
            {
                Name="Eslam",
                Address = "Alix",
                Phone = 0123849358

            });
            context.sellers.AddRange(sellers);
            context.suppliers.AddRange(suppliers);
            context.categories.AddRange(categories);
            context.items.AddRange(items);
            base.Seed(context);

        }
    }
}
