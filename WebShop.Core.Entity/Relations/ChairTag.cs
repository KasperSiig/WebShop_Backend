namespace WebShop.Core.Entity.Relations
{
    public class ChairTag
    {
        public int ChairId { get; set; }
        public Chair Chair { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}