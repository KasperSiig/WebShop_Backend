using System.Collections.Generic;
using WebShop.Core.Entity.Relations;

namespace WebShop.Core.Entity
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD
        public List<Chair> Chairs { get; set; }

        public override bool Equals(object obj)
        {
            var color = obj as Color;
            return color != null &&
                   Id == color.Id;
        }
=======
        public List<ChairColor> ChairColors { get; set; }
>>>>>>> fluentapi
    }
}