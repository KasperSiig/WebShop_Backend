using System;
using WebShop.Core.Entity;

namespace WebShop.Core
{
    public class ChairService : IChairService
    {
        private readonly IChairRepository _ChairRepo;

        public ChairService(IChairRepository chairRepository)
        {
            _ChairRepo = chairRepository;
        }

        public Chair AddChair(Chair chair)
        {
            return _ChairRepo.AddChair(chair);
        }
    }
}
