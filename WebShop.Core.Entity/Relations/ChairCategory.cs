namespace WebShop.Core.Entity.Relations
{
    public class ChairCategory
    {
        public int ChairId { get; set; }
        public Chair Chair { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}