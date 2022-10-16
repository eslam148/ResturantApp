using System;
using System.Collections.Generic;
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
    }
}
