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
            return _ctx.Chairs
                .Include(c => c.Designer)
                .Include(c => c.Maker)
                .Include(c => c.ChairColors)
                .Include(c => c.ChairTags);
        }

        public Chair GetChair(int id)
        {
            return _ctx.Chairs
                .Include(c => c.Designer)
                .FirstOrDefault(c => c.Id == id);
        }

        public void UpdateChair(Chair chair)
        {
            var chairUpdated = _ctx.Chairs.Update(chair).Entity;
            _ctx.SaveChanges();
        }

        public void DeleteChair(int chairId)
        {
            _ctx.Chairs.Remove(GetChair(chairId));
            _ctx.SaveChanges();
        }

        public Chair AddChair(Chair chair)
        {
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