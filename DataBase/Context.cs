using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Context :DbContext
    {
        public virtual DbSet<Item> items { get; set; }
        public virtual DbSet<Category> categories { get; set; }
        public virtual DbSet<Seller> sellers { get; set; }
        public virtual DbSet<Customer> customers { get; set; }
        public virtual DbSet<Supplier> suppliers { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Billtems> BillItems { get; set; }
        public virtual DbSet<CustomerBill> CustomerBill { get; set; }

        public Context() : base(@"Data source = .; initial catalog = Inventory; integrated security = true;")
        {

        }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
