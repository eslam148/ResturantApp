using DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemServices
    {
        Context DB;

        public int AddItem( String Name, int BuyPrice, int SallPric, int Quantaty, int SupplierID, int CategoryId)
        {
            Context DB = new Context();
            Item item = new Item
            {
                Name = Name,
                BuyPrice = BuyPrice,
                SellPrice = SallPric,
                Quantity = Quantaty,
                SupplierId = SupplierID,
                CategoryId = CategoryId
            };

            DB.items.Add(item);
            return DB.SaveChanges();
        }

        public List<ItemData> GetStayedItems()
        {
             DB = new Context();
            List<ItemData> itemDataslist = new List<ItemData>();
            var StayedItems = DB.items.Where(i => i.SelledQuantity == 0).ToList();
            foreach (var item in StayedItems)
            {
                ItemData itemData = new ItemData();
                itemData.ID = item.Id;
                itemData.Name = item.Name;
                itemData.BuyPrice = item.BuyPrice;
                itemData.SellPrice = item.SellPrice;
                itemData.Quantity = item.Quantity;
                itemData.SelledQuantity = item.SelledQuantity;
                itemData.CategoryId = item.CategoryId;
                var cat = DB.categories.Select(c => c).Where(c => c.Id == item.CategoryId).FirstOrDefault();
                itemData.CategoryName = cat.Name;
                itemData.SupplierID = item.SupplierId;
                var sup = DB.suppliers.Select(s => s).Where(s => s.Id == item.SupplierId).FirstOrDefault();
                itemData.SupplierName = sup.Name;

                itemDataslist.Add(itemData);
            }
            return itemDataslist;
        }
        public List<ItemData> GetItemsLessThanTen()
        {
             DB = new Context();
            List<ItemData> itemDataslist = new List<ItemData>();
            var ItemsLessThanTen = DB.items.Where(i => i.Quantity < 10).ToList();
            foreach (var item in ItemsLessThanTen)
            {
                ItemData itemData = new ItemData();
                itemData.ID = item.Id;
                itemData.Name = item.Name;
                itemData.BuyPrice = item.BuyPrice;
                itemData.SellPrice = item.SellPrice;
                itemData.Quantity = item.Quantity;
                itemData.SelledQuantity = item.SelledQuantity;
                itemData.CategoryId = item.CategoryId;
                var cat = DB.categories.Select(c => c).Where(c => c.Id == item.CategoryId).FirstOrDefault();
                itemData.CategoryName = cat.Name;
                itemData.SupplierID = item.SupplierId;
                var sup = DB.suppliers.Select(s => s).Where(s => s.Id == item.SupplierId).FirstOrDefault();
                itemData.SupplierName = sup.Name;
                itemDataslist.Add(itemData);
            }
            return itemDataslist;
        }

        public List<ItemData> GetAllItems()
        {
             DB = new Context();
            List<ItemData> itemDataslist = new List<ItemData>();
            var Items = DB.items.Select(i=>i).ToList();
            foreach (var item in Items)
            {
                ItemData itemData = new ItemData();
                itemData.ID = item.Id;
                itemData.Name = item.Name;
                itemData.BuyPrice = item.BuyPrice;
                itemData.SellPrice = item.SellPrice;
                itemData.Quantity = item.Quantity;
                itemData.SelledQuantity = item.SelledQuantity;
                itemData.CategoryId = item.CategoryId;
                var cat = DB.categories.Select(c => c).Where(c => c.Id == item.CategoryId).FirstOrDefault();
                itemData.CategoryName = cat.Name;
                itemData.SupplierID = item.SupplierId;
                var sup = DB.suppliers.Select(s => s).Where(s => s.Id == item.SupplierId).FirstOrDefault();
                itemData.SupplierName = sup.Name;
                itemDataslist.Add(itemData);
            }
            return itemDataslist;
        }

        public List<ItemData> GetSelledItems()
        {
             DB = new Context();
            List<ItemData> itemDataslist = new List<ItemData>();
            var Items = DB.items.Where(i => i.SelledQuantity > 0).ToList();
            foreach (var item in Items)
            {
                ItemData itemData = new ItemData();
                itemData.ID = item.Id;
                itemData.Name = item.Name;
                itemData.BuyPrice = item.BuyPrice;
                itemData.SellPrice = item.SellPrice;
                itemData.Quantity = item.Quantity;
                itemData.SelledQuantity = item.SelledQuantity;
                itemData.CategoryId = item.CategoryId;
                var cat = DB.categories.Select(c => c).Where(c => c.Id == item.CategoryId).FirstOrDefault();
                itemData.CategoryName = cat.Name;
                itemData.SupplierID = item.SupplierId;
                var sup = DB.suppliers.Select(s => s).Where(s => s.Id == item.SupplierId).FirstOrDefault();
                itemData.SupplierName = sup.Name;
                itemDataslist.Add(itemData);
            }
            return itemDataslist;
        }
        public int updateItems(int ItemId,int Quntaty,int SelledPrice,int BuyPrice)
        {
             DB = new Context();
            var item = DB.items.Where(i => i.Id==ItemId).FirstOrDefault();
            item.Quantity+=Quntaty;
            item.SellPrice = SelledPrice;
            item.BuyPrice = BuyPrice;
            return DB.SaveChanges();
        }
    }
}
