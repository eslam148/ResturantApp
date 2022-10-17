using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ItemData> Items { get; set; }

        public CategoryData()
        {
            Items = new List<ItemData>();
        }

    }
}
