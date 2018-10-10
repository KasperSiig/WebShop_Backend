using System.Collections.Generic;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService
{
    public interface IFilterService
    {
        List<Tag> GetTags();
        List<Designer> GetDesigners();
        List<Color> GetColors();
        List<Maker> GetMakers();
    }
}