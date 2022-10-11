using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tables
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string KindOfPay { get; set; }
        public string KindOfInvoice{get;set;}
        [ForeignKey("seller")]
        public int sellerId { get; set; }
        [ForeignKey("customer")]
        public int CustomerID { get; set; }
        [ForeignKey("items")]
        public int itemdId { get; set; }
        public Seller seller { get; set; }
        public Category category { get; set; }
       public List<Item> items { get; set; } 
        public Customer customer { get; set; }
    }
}
