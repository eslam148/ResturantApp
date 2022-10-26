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
        public int  AddSupplier(string Name,string phone,string Address)
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
        public SupplierData GetSuppliersByID(int ID)
        {
            Supplier supplier = context.suppliers.Where(s=>s.Id == ID).FirstOrDefault();
            SupplierData suppliersData = new SupplierData();
            suppliersData.ID = supplier.Id;
            suppliersData.Name = supplier.Name;
            suppliersData.Phone = supplier.Phone;
            suppliersData.Address = supplier.Address;

            return suppliersData;
        }
    }
}
