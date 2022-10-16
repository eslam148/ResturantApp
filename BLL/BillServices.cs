using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillServices
    {
        Context DBcontext = new Context();
        public int AddBill(int Quntaty,String KindOfPay,String KindOfInvoice, int sellerId,int CustomerID,int itemdId)
        {
            Bill bill = new Bill
            {
                Quantity = Quntaty,
                KindOfPay = KindOfPay,
                KindOfInvoice = KindOfInvoice,
                sellerId = sellerId,
                CustomerID = CustomerID,
                itemdId = itemdId
            };
            return DBcontext.SaveChanges();

        }
    }
}
