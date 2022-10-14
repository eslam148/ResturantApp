using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int Quantity { get; set; }
        public int SelledQuantity { get; set; }
        [ForeignKey("supplier")]
        public int SupplierId { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        //public string
        public Category Category { get; set; }
        public Supplier supplier { get; set; }
        public List<Seller> sellers { get; set; }
        public List<Bill> Bills { get; set; }
    }
}
