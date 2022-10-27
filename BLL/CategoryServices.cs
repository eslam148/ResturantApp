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

        public List<CategoryData> GetAllCategories()
        {
            List<Category> categoriesList =  DBcontext.categories.Select(c=>c).ToList();
            List<CategoryData> categoriesData = new List<CategoryData>();

                foreach (var item in categoriesList)
                {
                    CategoryData itemRecord = new CategoryData();
                    itemRecord.ID = item.Id;
                    itemRecord.Name = item.Name;
                    categoriesData.Add(itemRecord);
                }
            return categoriesData;
        }
    }
}
