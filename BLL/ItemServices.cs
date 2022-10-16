using DataBase;
using System;
using System.Collections.Generic;
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
    }
}
