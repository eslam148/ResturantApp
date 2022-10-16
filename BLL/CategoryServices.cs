using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     public class CategoryServices
    {
        Context DBcontext = new Context();
        public int AddCategory(string name)
        {
            Category category = new Category
            {
                Name = name
            };

            DBcontext.categories.Add(category);
            return DBcontext.SaveChanges();
        }
    }
}
