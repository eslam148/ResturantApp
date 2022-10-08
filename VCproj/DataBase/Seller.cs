using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VCproj.DataBase
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Item> Items { get; set; }
    }
}
