using System.Collections.Generic;
using WebShop.Core.ApplicationService;
using WebShop.Core.Entity;

namespace WebShop.Infrastructure.Data.Repositories
{
    public class FilterRepository : IFilterRepository
    {
        private readonly WebShopContext _ctx;

        public FilterRepository(WebShopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Tag> ReadTags()
        {
            return _ctx.Tags;
        }

        public IEnumerable<Designer> ReadDesigners()
        {
            return _ctx.Designers;
        }

        public IEnumerable<Color> ReadColors()
        {
            return _ctx.Colors;
        }

        public IEnumerable<Maker> ReadMakers()
        {
            return _ctx.Makers;
        }
    }
}