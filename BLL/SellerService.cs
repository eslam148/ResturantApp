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
        public List<SellerData> GetSeller()
        {
            
            List<SellerData> list=new List<SellerData>();
            var res=db.sellers.Select(s =>s).ToList();
            for (int i = 0; i < res.Count; i++)
            {
                SellerData sd = new SellerData();
                sd.ID = res[i].Id;
                sd.Address = res[i].Address;
                sd.Phone = res[i].Phone;
                sd.Name = res[i].Name;
                list.Add(sd);
            }
            return list;
        }
    }
}
