using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SellerService
    {
        Context db = new Context();


        public void AddSeller( string _name, int _phone, string _add)
        {
            Seller s = new Seller();
           
            s.Name = _name;
            s.Phone = _phone;
            s.Address = _add;
            db.sellers.Add(s);
            db.SaveChanges();
        }
    }
}
