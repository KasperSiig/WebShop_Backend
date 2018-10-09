using System;
using System.Collections.Generic;
using WebShop.Core.Entity;

namespace WebShop.Core
{
    public interface IChairRepository
    {
        IEnumerable<Chair> GetChairs();
        Chair GetChair(int id);
        void UpdateChair(Chair chair);
        void DeleteChair(int chairId);
        Chair AddChair(Chair chair);
        int Count();
    }
}
