using System.Collections;
using System.Collections.Generic;
using WebShop.Core.Entity;

namespace WebShop.Core.ApplicationService
{
    public interface IFilterRepository
    {
        IEnumerable<Tag> ReadTags();
        IEnumerable<Designer> ReadDesigners();
        IEnumerable<Color> ReadColors();
        IEnumerable<Maker> ReadMakers();
    }
}