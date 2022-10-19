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
                supplierRecord.Phone = supplier.Phone;
                supplierRecord.Address = supplier.Address;
                suppliersData.Add(supplierRecord);
            }

            return suppliersData;
        }

    }
}
