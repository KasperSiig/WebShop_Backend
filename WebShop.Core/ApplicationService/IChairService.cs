using System;
using System.Collections.Generic;
using WebShop.Core.Entity;

namespace WebShop.Core
{
    public interface IChairService
    {
        Chair AddChair(Chair chair);
        Chair GetChairById(int id);
        void DeleteChair(int id);
        List<Chair> GetAllChairs();
        List<Chair> GetChairsPaged(int page, int itemsOnPage);
        void UpdateChair(Chair Chair);
        List<Chair> filterChairs(List<Chair> chairs, Filter filter);
    }
}

