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

        public void AddCustomerS( string _name, int _phone, string _add)
        {
            Customer c = new Customer();
            
            c.Name = _name;
            c.Phone = _phone;
            c.Address = _add;
            db.customers.Add(c);
            db.SaveChanges();
        }
    }
}
