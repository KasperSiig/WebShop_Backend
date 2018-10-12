using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebShop.Core;
using WebShop.Core.Entity;
using WebShop.Core.Entity.Relations;

namespace WebShop.Infrastructure.Data.Repositories
{
    public class ChairRepository : IChairRepository
    {
        private readonly WebShopContext _ctx;

        public ChairRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Chair> GetChairs()
        {
            var chairs = _ctx.Chairs
                .Include(c => c.Designer)
                .Include(c => c.Maker)
                .Include(c => c.ChairColors)
                .Include(c => c.ChairTags);

            foreach (var chair in chairs)
            {
                foreach (var chairColor in chair.ChairColors)
                {
                    chairColor.Color = _ctx.Colors.FirstOrDefault(c => c.Id.Equals(chairColor.ColorId));
                }

                foreach (var chairTag in chair.ChairTags)
                {
                    chairTag.Tag = _ctx.Tags.FirstOrDefault(t => t.Id.Equals(chairTag.TagId));
                }
            }
            return chairs;
        }

        public Chair GetChair(int id)
        {
            return _ctx.Chairs
                .Include(c => c.Designer)
                .FirstOrDefault(c => c.Id == id);
        }

        public void UpdateChair(Chair chair)
        {
            foreach (var chairColor in chair.ChairColors)
            {
                var color = _ctx.Colors.FirstOrDefault(c => c.Name.Equals(chairColor.Color.Name));
                if (color == null)
                {
                    chairColor.Color = new Color(){Name = chairColor.Color.Name};
                }
                else
                {
                    chairColor.Color = color;
                }
            }
            foreach (var chairTag in chair.ChairTags)
            {
                var tag = _ctx.Tags.FirstOrDefault(t => t.Name.Equals(chairTag.Tag.Name));
                if (tag == null)
                {
                    chairTag.Tag = new Tag(){Name = chairTag.Tag.Name};
                }
                else
                {
                    chairTag.Tag = tag;
                }
            }

            _ctx.Chairs.Update(chair);
            _ctx.SaveChanges();
        }

        public void DeleteChair(int chairId)
        {
            _ctx.Chairs.Remove(GetChair(chairId));
            _ctx.SaveChanges();
        }

        public Chair AddChair(Chair chair)
        {
            foreach (var chairColor in chair.ChairColors)
            {
                var color = _ctx.Colors.FirstOrDefault(c => c.Name.Equals(chairColor.Color.Name));
                if (color == null)
                {
                    chairColor.Color = new Color(){Name = chairColor.Color.Name};
                }
                else
                {
                    chairColor.Color = color;
                }
            }
            foreach (var chairTag in chair.ChairTags)
            {
                var tag = _ctx.Tags.FirstOrDefault(t => t.Name.Equals(chairTag.Tag.Name));
                if (tag == null)
                {
                    chairTag.Tag = new Tag(){Name = chairTag.Tag.Name};
                }
                else
                {
                    chairTag.Tag = tag;
                }
            }

            var designer = _ctx.Designers.FirstOrDefault(d =>
                d.FirstName.ToLower().Equals(chair.Designer.FirstName.ToLower()));
            if (designer == null)
            {
                chair.Designer = new Designer()
                {
                    FirstName = chair.Designer.FirstName,
                    LastName = chair.Designer.LastName,
                    CountryOfOrigin = chair.Designer.CountryOfOrigin
                };
            }
            else
            {
                chair.Designer = designer;
            }
            
            
            var chairAdded = _ctx.Add(chair).Entity;
            _ctx.SaveChanges();
            return chairAdded;
        }

        public int Count()
        {
            return _ctx.Chairs.Count();
        }

        public void FillMissingProps(Chair chair)
        {
            chair.ChairTags.ForEach(chairTag => _ctx.Attach(chairTag));
            chair.ChairColors.ForEach(chairColor => _ctx.Attach(chairColor));
            foreach (var chairColor in chair.ChairColors)
            {
                chairColor.Color = _ctx.Colors.FirstOrDefault(c => c.Id == chairColor.ColorId);
            }

            foreach (var chairTag in chair.ChairTags)
            {
                chairTag.Tag = _ctx.Tags.FirstOrDefault(t => t.Id == chairTag.TagId);
            }
        }
        
    }
}