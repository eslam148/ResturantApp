using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class CustomerBill
    {
        public int Id { get; set; }
        [ForeignKey("customer")]
        public int CustomerID { get; set; }
        [ForeignKey("Bills")]
        public int BillID { get; set; }

        public  List<Bill> Bills { get; set; }
        public  Customer customer { get; set; }

    }
}
