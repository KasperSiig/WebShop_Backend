using System.Collections.Generic;

namespace WebShop.Core.Entity
{
    public class Category
    {
        public int Id { get; set; };
        public string Name { get; set; }
        public List<Chair> Chairs { get; set; }
    }
}