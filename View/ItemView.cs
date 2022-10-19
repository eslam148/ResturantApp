using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class ItemView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int Quantity { get; set; }
        public int SelledQuantity { get; set; }
        public int SupplierID { get; set; }
        public int CategoryId { get; set; }
    }
}
