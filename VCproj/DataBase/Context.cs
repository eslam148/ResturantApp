using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCproj.DataBase
{
    public class Context: DbContext
    {
        public Context() : base(@"Data source = DESKTOP-T2U4HGU; initial catalog = inventory; integrated security = true;")
        {

        }
        DbSet<Item> items { get; set; }
        DbSet<Category>categories { get; set; }
        DbSet<Seller> sellers { get; set; }
        DbSet<Customer> customers { get; set; }
        DbSet<Supplier> suppliers { get; set; }
        DbSet<Bill> Bills { get; set; }


    }
}
