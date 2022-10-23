using DataBase.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Context :DbContext
    {
        public  DbSet<Item> items { get; set; }
        public  DbSet<Category> categories { get; set; }
        public  DbSet<Seller> sellers { get; set; }
        public  DbSet<Customer> customers { get; set; }
        public  DbSet<Supplier> suppliers { get; set; }
        public  DbSet<Bill> Bills { get; set; }
        public  DbSet<Billtems> BillItems { get; set; }
        public  DbSet<CustomerBill> CustomerBill { get; set; }

        public Context() : base(@"Data source = DESKTOP-HH9RCV9\SQLEXPRESS; initial catalog = Inventory; integrated security = true;")
        {
        }
     
      

    }
}
