using System;
using System.Collections.Generic;
using System.IO;
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
                throw new InvalidDataException("A chair needs to have a name");
            }
            if (chair.Price == 0)
            {
                throw new InvalidDataException("A chair needs to have a price");
            }
            if (chair.Price < 0)
            {
                throw new InvalidDataException("A chair needs to have a positive price");
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

        public List<Chair> GetChairsPaged(int page, int itemsOnPage)
        {
            if (page <= 0 || itemsOnPage <= 0){
                throw new InvalidDataException("The page and items per page must be more then zero");
            }
            if(page - 1 * itemsOnPage > _ChairRepo.Count())
            {
                throw new ArgumentException("Index out of bound, page number to high");
            }

            return _ChairRepo.GetChairs()
                             .Skip((page - 1) * itemsOnPage)
                             .Take(itemsOnPage)
                             .ToList();
        }

        public void UpdateChair(Chair Chair)
        {
            _ChairRepo.UpdateChair(Chair);
        }
    }
}
