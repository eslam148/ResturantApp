using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
       
        public bool KindOfPay { get; set; }

        [ForeignKey("seller")]
        public int sellerId { get; set; }
        public  Seller seller { get; set; }
        public  List<Billtems> Billtems { get; set; }
        public  List<CustomerBill> CustomerBills { get; set; }

        public int TotalPrice { get; set; }
        public DateTime dateOfBill { get; set; }

        public DateTime dateOfPay { get; set; }

        public int RestOfTheInvoicePrice{ get; set; }


    }
}
