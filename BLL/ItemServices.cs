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
        Context DB = new Context();

        public int AddItem( String Name, int BuyPrice, int SallPric, int Quantaty, int SupplierID, int CategoryId)
        {

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
                item.CategoryId = item.CategoryId;
                itemDataslist.Add(itemData);
            }
            return itemDataslist;
        }
        public List<ItemData> GetItemsLessThanTen()
        {
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
                itemDataslist.Add(itemData);
            }
            return itemDataslist;
        }

        public List<ItemData> GetAllItems()
        {
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
                itemDataslist.Add(itemData);
            }
            return itemDataslist;
        }

        public List<ItemData> GetSelledItems()
        {
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
                itemDataslist.Add(itemData);
            }
            return itemDataslist;
        }
        public int updateItems(int ItemId,int Quntaty,int SelledPrice,int BuyPrice)
        {
            var item = DB.items.Where(i => i.Id==ItemId).FirstOrDefault();
            item.Quantity+=Quntaty;
            item.SellPrice = SelledPrice;
            item.BuyPrice = BuyPrice;
            return DB.SaveChanges();
        }
    }
}
