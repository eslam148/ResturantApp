using DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Context: DbContext
    {
        public Context() : base(@"Data source = .; initial catalog = inventory1; integrated security = true;")
        {

        }
        public DbSet<Item> items { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Seller> sellers { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Bill> Bills { get; set; }
    }
}
