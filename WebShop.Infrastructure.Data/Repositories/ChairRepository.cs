using System.Collections.Generic;
using System.Linq;
using WebShop.Core;
using WebShop.Core.Entity;

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
            return _ctx.Chairs;
        }

        public Chair GetChair(int id)
        {
            return _ctx.Chairs.FirstOrDefault(c => c.Id == id);
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
    }
}