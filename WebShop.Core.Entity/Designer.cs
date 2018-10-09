using System.Collections.Generic;

namespace WebShop.Core.Entity
{
    public class Designer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryOfOrigin { get; set; }
        public List<Chair> Chairs { get; set; }

        public override bool Equals(object obj)
        {
            var designer = obj as Designer;
            return designer != null &&
                   Id == designer.Id;
        }
    }
}