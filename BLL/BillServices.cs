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
        public int AddBill(bool KindOfPay, int sellerId,int totalPrice,int DownPayment)
        {
            Bill bill;
            if (KindOfPay == true) {
                bill = new Bill
                {
                    KindOfPay = KindOfPay,
                    //  KindOfInvoice = KindOfInvoice,
                    sellerId = sellerId,
                    TotalPrice = totalPrice,
                    RestOfTheInvoicePrice = 0,
                    dateOfBill = DateTime.Now,
                    dateOfPay=  DateTime.Now
                };
            }
            else
            {
                bill = new Bill
                {
                    KindOfPay = KindOfPay,
                    //  KindOfInvoice = KindOfInvoice,
                    sellerId = sellerId,
                    TotalPrice = totalPrice,
                    RestOfTheInvoicePrice = totalPrice - DownPayment,
                    dateOfBill = DateTime.Now,
                    dateOfPay=  DateTime.Now
                };
            }
           
            DBcontext.Bills.Add(bill);
            return DBcontext.SaveChanges();

        }

        public int AddToBill(int Quntaty, int CustomerID, int itemId)
        {
            var item = DBcontext.items.Where(i=>i.Id==itemId).FirstOrDefault();
            if(item.Quantity<Quntaty)
            {
                return 0;
            }
            item.Quantity -= Quntaty;
            item.SelledQuantity+= Quntaty;

            int BillID = DBcontext.Bills.OrderByDescending(i=> i.Id).Select(i=>i.Id).FirstOrDefault();
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
           
            foreach (var item in Bill)
            {
                var Goods = DBcontext.items.FirstOrDefault(i => i.Id==item.itemdId);
                data.Add(new BillData
                {
                    id = BillID,
                    itemdata =new ItemData{ 
                        ID = Goods.Id,
                        Name = Goods.Name,
                        Quantity =item.Quantity 
                    }
                });

            }

            return data ;
        }

        public List<int> GetBillOfCustomer(int CustomerID)
        {
            var Bill = DBcontext.CustomerBill.Where(b => b.CustomerID == CustomerID)
                .Select(i=>i.BillID).ToList();
            return Bill;
        }

        public int ReturnItem(int BillID , int ItemID,int RetrunedQuantaty)
        {
            var BillItem = DBcontext.BillItems.FirstOrDefault(b => b.BillId == BillID && b.itemdId == ItemID);
            var bill = DBcontext.Bills.FirstOrDefault(b => b.Id==BillID);
            var item = DBcontext.items.FirstOrDefault(i => i.Id == ItemID);
            if(item == null)
            {
                return 0;
            }
            int amount = RetrunedQuantaty*item.SellPrice;
            bill.TotalPrice-=amount;
            bill.RestOfTheInvoicePrice -= amount;
            

            BillItem.Quantity -=RetrunedQuantaty;
            var Item = DBcontext.items.FirstOrDefault(i => i.Id == ItemID);
            Item.Quantity+=RetrunedQuantaty;
            Item.SelledQuantity-=RetrunedQuantaty;
            return DBcontext.SaveChanges();
            
            
        }
        public int UpdateBill(int BillId, int AamountOfMoney)
        {
            int res;
            var Bill = DBcontext.Bills.Where(b => b.Id == BillId).FirstOrDefault();
            if (Bill != null) { 
                if (Bill.RestOfTheInvoicePrice > AamountOfMoney&& !Bill.KindOfPay )
                {
                    Bill.RestOfTheInvoicePrice -= AamountOfMoney;
                    Bill.dateOfPay = DateTime.Now;
                    res = DBcontext.SaveChanges();
                    return res;

                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }
    }
}
