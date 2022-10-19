using DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillServices
    {
        Context DBcontext = new Context();
        public int AddBill(String KindOfPay,String KindOfInvoice, int sellerId)
        {
            Bill bill = new Bill
            {
                KindOfPay = KindOfPay,
                KindOfInvoice = KindOfInvoice,
                sellerId = sellerId,
            };
            DBcontext.Bills.Add(bill);
            return DBcontext.SaveChanges();

        }

        public int AddToBill(int Quntaty, int CustomerID, int itemdId)
        {
            int BillID = DBcontext.Bills.OrderBy(i=> i.Id).Select(i=>i.Id).FirstOrDefault();
            Billtems ib = new Billtems
            {
                itemdId=itemdId,
                BillId = BillID,
                Quantity=Quntaty
            };

            CustomerBill cb = new CustomerBill
            {
                CustomerID = CustomerID,
                BillID = BillID
            };

            DBcontext.CustomerBill.Add(cb);
            DBcontext.BillItems.Add(ib);
            return DBcontext.SaveChanges();

        }
        public int GetBillID()
        {
            int BillID = DBcontext.Bills.OrderByDescending(i => i.Id).Select(i => i.Id).FirstOrDefault();
            return BillID;
        }
    }
}
