using WebShop.Core.Entity;

namespace WebShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(WebShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var staalstel = new Tag()
            {
                Name = "Stålstel"
            };

            var trebenet = new Tag()
            {
                Name = "Trebenet"
            };
        }
    }
}