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
       
        public string KindOfPay { get; set; }
        public string KindOfInvoice { get; set; }



        [ForeignKey("seller")]
        public int sellerId { get; set; }
        public virtual Seller seller { get; set; }

        public virtual List<Billtems> Billtems { get; set; }

        public virtual List<CustomerBill> CustomerBills { get; set; }
    }
}
