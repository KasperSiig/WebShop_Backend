using System.Collections.Generic;
using WebShop.Core.Entity.Relations;

namespace WebShop.Core.Entity
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChairTag> ChairTags { get; set; }
    }
}