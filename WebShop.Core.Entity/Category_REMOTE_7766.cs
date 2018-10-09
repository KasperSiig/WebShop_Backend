using System.Collections.Generic;
using WebShop.Core.Entity.Relations;

namespace WebShop.Core.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChairCategory> ChairCategories { get; set; }
    }
}