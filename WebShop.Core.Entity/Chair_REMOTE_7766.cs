using System;
using System.Collections.Generic;
using WebShop.Core.Entity.Relations;

namespace WebShop.Core.Entity
{
    public class Chair
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<ChairColor> ChairColors { get; set; }
        public Designer Designer { get; set; }
        public Maker Maker { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public List<ChairTag> ChairTags { get; set; }
        public List<ChairCategory> ChairCategories { get; set; }
    }
}