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
            List<Category> categoriesList =  DBcontext.categories.ToList();
            List<CategoryData> categoriesData = new List<CategoryData>();

            foreach (Category category in categoriesList)
            {
                CategoryData categoryRecord = new CategoryData();

                categoryRecord.ID = category.Id;
                categoryRecord.Name = category.Name;

                foreach (var item in category.items)
                {
                    ItemData itemRecord = new ItemData();

                    itemRecord.ID = item.Id;
                    itemRecord.Name = item.Name;
                    itemRecord.BuyPrice = item.BuyPrice;
                    itemRecord.SellPrice = item.SellPrice;
                    itemRecord.Quantity = item.Quantity;
                    itemRecord.SelledQuantity = item.SelledQuantity;
                    itemRecord.SupplierID = item.SupplierId;

                    categoryRecord.Items.Add(itemRecord);
                }

                categoriesData.Add(categoryRecord);
            }

            return categoriesData;
        }
    }
}
