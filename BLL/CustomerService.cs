using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerService
    {
        Context db = new Context();

        public int AddCustomer( string _name, int _phone, string _add)
        {
            Customer c = new Customer();
            
            c.Name = _name;
            c.Phone = _phone;
            c.Address = _add;
            db.customers.Add(c);
            return db.SaveChanges();
        }

        public List<CustomerData> GetCustomer()
        {

            List<CustomerData> list = new List<CustomerData>();
            var res = db.customers.Select(c => c).ToList();
            for (int i = 0; i < res.Count; i++)
            {
                CustomerData cd = new CustomerData();
                cd.ID = res[i].Id;
                cd.Address = res[i].Address;
                cd.Phone = res[i].Phone;
                cd.Name = res[i].Name;
                list.Add(cd);
            }
            return list;
        }
    }
}
