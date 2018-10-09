using System;
using System.Collections.Generic;
using System.Linq;
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
            chair.Id = 0;

            if (chair.Name == null){
                throw new ArgumentException("A chair needs to have a name");
            }
            if (chair.Price == 0)
            {
                throw new ArgumentException("A chair needs to have a price");
            }
            if (chair.Price < 0)
            {
                throw new ArgumentException("A chair needs to have a positive price");
            }

            return _ChairRepo.AddChair(chair);
        }

        public Chair GetChairById(int id)
        {
            var chair = _ChairRepo.GetChair(id);

            if (chair == null){
                throw new ArgumentException("There was not found a chair with this id");
            }

            return chair;
        }

        public void DeleteChair(int id){
            _ChairRepo.DeleteChair(id);
        }

        public List<Chair> GetAllChairs(){
            return _ChairRepo.GetChairs().ToList();
        }


    }
}
