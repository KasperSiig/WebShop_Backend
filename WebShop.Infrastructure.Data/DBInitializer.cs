using System.Collections.Generic;
using WebShop.Core.Entity;
using WebShop.Core.Entity.Relations;

namespace WebShop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(WebShopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var staalstel = ctx.Tags.Add(new Tag()
            {
                Name = "Stålstel"
            }).Entity;

            var trebenet = ctx.Tags.Add(new Tag()
            {
                Name = "Trebenet"
            }).Entity;

            var red = ctx.Colors.Add(new Color()
            {
                Name = "rød"
            }).Entity;

            var blue = ctx.Colors.Add(new Color()
            {
                Name = "blå"
            }).Entity;

            var arne = ctx.Designers.Add(new Designer()
            {
                FirstName = "Arne",
                LastName = "Jakobsen",
                CountryOfOrigin = "Danmark"
            }).Entity;

            var lise = ctx.Designers.Add(new Designer()
            {
                FirstName = "Lise",
                LastName = "Andersen",
                CountryOfOrigin = "Sverige"
            }).Entity;

            var maker = ctx.Makers.Add(new Maker()
            {
                Name = "Maker of Chairs"
            }).Entity;

            var maker1 = ctx.Makers.Add(new Maker()
            {
                Name = "Maker of Chairs Too"
            }).Entity;

            var egg = ctx.Chairs.Add(new Chair()
            {
                ChairColors = new List<ChairColor>
                {
                    new ChairColor()
                    {
                        Color = red
                    }                   
                },
                ChairTags = new List<ChairTag>
                {
                    new ChairTag()
                    {
                        Tag = staalstel
                    }
                },
                Description = "Dette er en meget fin stol",
                Designer = arne,
                Maker = maker,
                Name = "Ægget",
                Price = 43599.0,
                PictureURL = "assets/imgs/chairs/chair7.png"
            }).Entity;
            
            var newegg = ctx.Chairs.Add(new Chair()
            {
                ChairColors = new List<ChairColor>
                {
                    new ChairColor()
                    {
                        Color = red
                    }                   
                },
                ChairTags = new List<ChairTag>
                {
                    new ChairTag()
                    {
                        Tag = staalstel
                    }
                },
                Description = "Dette er en meget fin stol",
                Designer = arne,
                Maker = maker,
                Name = "Nyt æg",
                Price = 43599.0,
                PictureURL = "assets/imgs/chairs/chair2.png"
            }).Entity;
            
            var newegg2 = ctx.Chairs.Add(new Chair()
            {
                ChairColors = new List<ChairColor>
                {
                    new ChairColor()
                    {
                        Color = red
                    }                   
                },
                ChairTags = new List<ChairTag>
                {
                    new ChairTag()
                    {
                        Tag = trebenet
                    }
                },
                Description = "Dette er en meget fin stol",
                Designer = arne,
                Maker = maker,
                Name = "Stort æg",
                Price = 43599.0,
                PictureURL = "assets/imgs/chairs/chair3.png"
            }).Entity;
            
            var newegg1 = ctx.Chairs.Add(new Chair()
            {
                ChairColors = new List<ChairColor>
                {
                    new ChairColor()
                    {
                        Color = red
                    }                   
                },
                ChairTags = new List<ChairTag>
                {
                    new ChairTag()
                    {
                        Tag = staalstel
                    }
                },
                Description = "Dette er en meget fin stol",
                Designer = arne,
                Maker = maker,
                Name = "Træls æg",
                Price = 43599.0,
                PictureURL = "assets/imgs/chairs/chair7.png"
            }).Entity;
            
            var neweggdw1 = ctx.Chairs.Add(new Chair()
            {
                ChairColors = new List<ChairColor>
                {
                    new ChairColor()
                    {
                        Color = red
                    }                   
                },
                ChairTags = new List<ChairTag>
                {
                    new ChairTag()
                    {
                        Tag = staalstel
                    }
                },
                Description = "Dette er en meget fin stol",
                Designer = arne,
                Maker = maker,
                Name = "Lille æg",
                Price = 43599.0,
                PictureURL = "assets/imgs/chairs/chair4.png"
            }).Entity;

            ctx.SaveChanges();
        }
    }
}