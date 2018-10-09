using System;
using System.Collections.Generic;

namespace WebShop.Core.Entity
{
    public class Chair
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Color> Colors { get; set; }
        public Designer Designer { get; set; }
        public Maker Maker { get; set; }
        public string Description { get; set; }
        public string PictureURL { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categorys { get; set; }
    }
}