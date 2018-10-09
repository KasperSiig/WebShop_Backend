using System.Collections.Generic;

namespace WebShop.Core.Entity
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Chair> Chairs { get; set; }

        public override bool Equals(object obj)
        {
            var color = obj as Color;
            return color != null &&
                   Id == color.Id;
        }
    }
}