namespace WebShop.Core.Entity.Relations
{
    public class ChairColor
    {
        public int ChairId { get; set; }
        public Chair Chair { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}