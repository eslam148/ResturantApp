using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
namespace BLL
{
    public class supplierServices
    {
        Context context = new Context();
        public int  AddSupplier(string Name,int phone,string Address)
        { 
            Supplier supplier = new Supplier();
            supplier.Address = Address;
            supplier.Name = Name;
            supplier.Phone = phone;
            context.suppliers.Add(supplier);
            int res =context.SaveChanges();
            return res;

        }

        public List<SupplierData> GetAllSuppliers()
        {
            List<Supplier> suppliersList = context.suppliers.ToList();
            List<SupplierData> suppliersData = new List<SupplierData>();

            foreach (Supplier supplier in suppliersList)
            {
                SupplierData supplierRecord = new SupplierData();

                supplierRecord.ID = supplier.Id;
                supplierRecord.Name = supplier.Name;

                foreach (var item in supplier.Items)
                {
                    ItemData itemRecord = new ItemData();

                    itemRecord.ID = item.Id;
                    itemRecord.Name = item.Name;
                    itemRecord.BuyPrice = item.BuyPrice;
                    itemRecord.SellPrice = item.SellPrice;
                    itemRecord.Quantity = item.Quantity;
                    itemRecord.SelledQuantity = item.SelledQuantity;
                    itemRecord.SupplierID = item.SupplierId;

                    supplierRecord.Items.Add(itemRecord);
                }

                suppliersData.Add(supplierRecord);
            }

            return suppliersData;
        }

    }
}
