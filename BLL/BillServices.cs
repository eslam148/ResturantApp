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

        public int AddToBill(int Quntaty, int CustomerID, int itemId)
        {
            var item = DBcontext.items.Where(i=>i.Id==itemId).FirstOrDefault();
            item.Quantity -= Quntaty;
            item.SelledQuantity+= Quntaty;

            int BillID = DBcontext.Bills.OrderBy(i=> i.Id).Select(i=>i.Id).FirstOrDefault();
            Billtems ib = new Billtems
            {
                itemdId=itemId,
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
        public List<BillData> GetBillInfo(int BillID)
        {
            var Bill = DBcontext.BillItems.Where(b => b.BillId == BillID).ToList();
            List<BillData> data = new List<BillData>();
            int ID = BillID;
            foreach (var item in Bill)
            {
                var Goods = DBcontext.items.FirstOrDefault(i => i.Id==item.itemdId);
                data.Add(new BillData
                {
                    id = item.BillId,
                    itemdata =new ItemData{ 
                        ID = Goods.Id,
                        Name = Goods.Name,
                        Quantity =item.Quantity 
                    }
                });

            }

            return data ;
        }
    }
}
