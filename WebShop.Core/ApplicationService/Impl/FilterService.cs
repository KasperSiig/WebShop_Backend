using System.Collections.Generic;
using System.Linq;
using WebShop.Core.ApplicationService;
using WebShop.Core.Entity;

namespace WebShop.Core
{
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _filterRepo;

        public FilterService(IFilterRepository filterRepository)
        {
            _filterRepo = filterRepository;
        }

        public List<Tag> GetTags()
        {
            return _filterRepo.ReadTags().ToList();
        }

        public List<Designer> GetDesigners()
        {
            return _filterRepo.ReadDesigners().ToList();
        }

        public List<Color> GetColors()
        {
            return _filterRepo.ReadColors().ToList();
        }

        public List<Maker> GetMakers()
        {
            return _filterRepo.ReadMakers().ToList();
        }
    }
}