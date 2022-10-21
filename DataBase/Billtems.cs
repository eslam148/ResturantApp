using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Billtems
    {
        public int  Id { get; set; }


        [ForeignKey("items")]
        public int itemdId { get; set; }
        public virtual Item items { get; set; }


        [ForeignKey("Bills")]
        public int BillId { get; set; }
        public virtual Bill Bills { get; set; }


        public int Quantity { get; set; }
    }
}
